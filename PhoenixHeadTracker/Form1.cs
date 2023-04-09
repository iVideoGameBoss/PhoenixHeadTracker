using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Net;
using System.Net.Sockets;

/*
 * PhoenixHeadTracker - A head-tracking application for controlling the mouse cursor for video games
 *
 * Copyright (C) [2023] [iVideoGameBoss] 
 *
 * Github <https://github.com/iVideoGameBoss/PhoenixHeadTracker>
 * YouTube <https://www.youtube.com/@ivideogameboss>
 * Reddit <https://www.reddit.com/user/jaktharkhan>
 * Donate <https://paypal.me/ivideogameboss?country.x=US&locale.x=en_US>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */


namespace PhoenixHeadTracker
{

    public partial class Form1 : Form
    {
        [DllImport("AirAPI_Windows", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StartConnection();

        [DllImport("AirAPI_Windows", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopConnection();

        [DllImport("AirAPI_Windows", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetEuler();

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        static extern uint SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public InputUnion inputUnion;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mouseInput;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;

        }

        // This code initializes variables and objects for manipulating images and tracking mouse movements
        private Bitmap image1;                // holds the first image
        private Graphics graphics1;           // graphics object to manipulate the first image
        private PointF center1;              // center point of the first image
        private Bitmap image2;                // holds the second image
        private Graphics graphics2;           // graphics object to manipulate the second image
        private PointF center2;              // center point of the second image
        private Bitmap image3;                // holds the third image
        private Graphics graphics3;           // graphics object to manipulate the third image
        private PointF center3;              // center point of the third image

        private bool isMouseTrack = false;    // flag to indicate whether mouse tracking is enabled
        private bool isOpenTrack = false;     // flag to indicate whether open tracking is enabled

        // These variables are used to calculate changes in mouse movement
        private double previousX = 0;
        private double previousY = 0;
        private double previousRoll = 0;
        private double xMapped = 0;
        private double yMapped = 0;
        private double rollMapped = 0;
        private double deltaX = 0;
        private double deltaY = 0;
        private double deltaRoll = 0;
        private double xRot = 0.0;
        private double yRot = 0.0;
        private double rollRot = 0.0;

        // These variables are used to calculate rotational distance
        private double rotDistanceYaw = 0.0;
        private double rotDistancePitch = 0.0;
        private double rollDistanceRoll = 0.0;

        // These constants are used to identify Windows messages and mouse events
        private const int WM_INPUT = 0x00FF;
        private const int MOUSEEVENTF_MOVE = 0x0001;

        // These variables hold screen dimensions
        private int screenWidth = 1920;
        private int screenHeight = 1080;
        private int screenWidthScale = 1920;//3840
        private int screenHeightScale = 1080;//2160

        // These variables hold mouse position and roll
        private double x = 0;
        private double y = 0;
        private double roll = 0;

        // This variable holds input data
        private INPUT input;

        // This variable holds the handle to the active window
        private IntPtr hWnd;

        // These variables are used for network communication
        private UdpClient udpClient;
        private IPAddress ipAddress;
        private IPEndPoint endPoint;
        private int port;

        // These variables hold pointers and arrays for image manipulation
        private IntPtr ptr;
        private float[] arr;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the screen dimensions
            screenWidth = Screen.PrimaryScreen.Bounds.Width; // Gets the width of the primary screen
            screenHeight = Screen.PrimaryScreen.Bounds.Height; // Gets the height of the primary screen

            // Set the initial scaling factors to be equal to the screen size
            screenWidthScale = screenWidth;
            screenHeightScale = screenHeight;

            // Create a new instance of the INPUT struct to simulate mouse input
            input = new INPUT();
            input.type = 0; // Indicates that we want to simulate mouse input
            input.inputUnion.mouseInput.mouseData = 0; // No scroll wheel movement
            input.inputUnion.mouseInput.dwFlags = MOUSEEVENTF_MOVE; // Move the mouse
            input.inputUnion.mouseInput.time = 0; // Use the current system time
            input.inputUnion.mouseInput.dwExtraInfo = GetMessageExtraInfo(); // Set the extra information to 0

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the Euler angles from an external library and store them in an array
            ptr = GetEuler(); // Assume that GetEuler() returns a pointer to a float array
            arr = new float[3];

            // Copy the values from the pointer into the array
            Marshal.Copy(ptr, arr, 0, 3);

            // Calculate the x, y, and roll values based on screen size and user-defined speeds
            x = (arr[2] * (screenWidth * screenWidthScale) / trackBarYawSpeed.Value);
            y = (arr[1] * (screenHeight * screenHeightScale) / trackBarPitchSpeed.Value);
            roll = (arr[0] * (screenHeight * screenHeightScale) / trackBarRollSpeed.Value);

            // Map the calculated values to the xMapped, yMapped, and rollMapped variables
            xMapped = x;
            yMapped = y;
            rollMapped = roll;

            // Update the labels to display the current speed values
            labelYawSpeed.Text = string.Format("Yaw Speed: {0:0}", trackBarYawSpeed.Value);
            labelPitchSpeed.Text = string.Format("Pitch Speed: {0:0}", trackBarPitchSpeed.Value);
            labelRollSpeed.Text = string.Format("Roll Speed: {0:0}", trackBarRollSpeed.Value);

            // Check if any of the mapped degrees have changed
            if (xMapped != previousX || yMapped != previousY || rollMapped != previousRoll)
            {
                // Calculate the change in degrees for each axis
                deltaX = xMapped - previousX;
                deltaY = yMapped - previousY;
                deltaRoll = rollMapped - previousRoll;



                // Filter the degree changes for smoother rotation
                double filteredDeltaX, filteredDeltaY, filteredDeltaRoll;
                filterData(out filteredDeltaX, out filteredDeltaY, out filteredDeltaRoll,
                            deltaX, deltaY, deltaRoll);

                // Update the rotation variables with the filtered values
                xRot += (double)filteredDeltaX;
                yRot += (double)filteredDeltaY;
                rollRot += (double)filteredDeltaRoll;

                // Update the rotation labels with the new rotation values
                labelYawRotation.Text = xRot.ToString();
                labelPitchRotation.Text = yRot.ToString();
                labelRollRotation.Text = rollRot.ToString();

                // Save the previous degree values for the next comparison
                previousX = xMapped;
                previousY = yMapped;
                previousRoll = rollMapped;

                // Update the mouse filter and delay labels with their current values
                int mouseSmoothFilter = trackBarMouseSmooth.Value;
                labelMouseSmoothFilter.Text = string.Format("Mouse Smooth Filter: {0:0}", mouseSmoothFilter);
                int mouseDelayFilter = trackBarMouseDelay.Value;
                labelMouseDelayFilter.Text = string.Format("Mouse Delay Filter :: {0:0}", mouseDelayFilter);

                // Update the labels showing the current tracked rotation values
                labelMatchYaw.Text = string.Format("Track Yaw {0:0.00}", xRot);
                labelMatchPitch.Text = string.Format("Track Pitch {0:0.00}", yRot);
                labelMatchRoll.Text = string.Format("Track Roll {0:0.00}", rollRot);


                // Check if the track is open
                if (isOpenTrack == true)
                {
                    // Update x, y, and roll rotation distances based on the previous values
                    double tempX = xRot - arr[2];
                    xRot += rotDistanceYaw - tempX;

                    double tempY = yRot - arr[1];
                    yRot += rotDistancePitch - tempY;

                    double tempRoll = rollRot - arr[0];
                    rollRot += rollDistanceRoll - tempRoll;

                    // Filter the rotation data to smooth out noise and improve accuracy
                    double filteredRotX, filteredRotY, filteredRotRoll;
                    filterData(out filteredRotX, out filteredRotY, out filteredRotRoll,
                        xRot, yRot, rollRot);

                    // Compute the coordinates and orientation angles based on the filtered rotation data
                    double x = 0;
                    double y = 0;
                    double z = 0;
                    double yaw = filteredRotX * 90;
                    double pitch = filteredRotY * 90;
                    double roll = filteredRotRoll * 45;

                    // Update the UI labels with the orientation angles
                    labelMatchYaw.Text = string.Format("Track Yaw {0:0.00}", yaw);
                    labelMatchPitch.Text = string.Format("Track Pitch {0:0.00}", pitch);
                    labelMatchRoll.Text = string.Format("Track Roll {0:0.00}", roll);

                    // Adjust the orientation angles based on the rotation distances and inversion settings
                    yaw -= rotDistanceYaw - tempX;
                    pitch -= rotDistancePitch - tempY;
                    roll -= rollDistanceRoll - tempRoll;

                    if (checkBoxInvertYaw.Checked == true) yaw = -yaw;
                    if (checkBoxInvertPitch.Checked == true) pitch = -pitch;
                    if (checkBoxInvertRoll.Checked == true) roll = -roll;

                    // Zero out the orientation angles if the corresponding checkboxes are unchecked
                    if (checkBoxYaw.Checked == false) { yaw = 0; }
                    if (checkBoxPitch.Checked == false) { pitch = 0; }
                    if (checkBoxRoll.Checked == false) { roll = 0; }



                    // Create a new UDP client to communicate with the OpenTrack server

                    using (UdpClient udpClient = new UdpClient())
                    {
                        // Pack the coordinates and orientation angles into a byte array for sending over the network
                        byte[] data = new byte[6 * sizeof(double)];
                        Buffer.BlockCopy(new double[] { x, y, z, yaw, pitch, roll }, 0, data, 0, data.Length);
                        // Send the byte array over UDP to the specified endpoint
                        udpClient.Send(data, data.Length, endPoint);
                        // Close the udpClient to release any resources it's using
                    }
                    
                    // Update the log textbox with the byte array length (for debugging)
                    //textBoxLog1.Text = string.Format("{0}\r\n", 6 * sizeof(double));
                }


                // Check if mouse tracking is enabled
                if (isMouseTrack == true)
                {
                    // Apply a smoothing filter to the mouse input
                    for (int q = 0; q < mouseSmoothFilter; q++)
                    {
                        // Set the mouse delta values to the filtered values
                        input.inputUnion.mouseInput.dx = -(int)filteredDeltaX;
                        input.inputUnion.mouseInput.dy = -(int)filteredDeltaY;

                        // Allocate memory for the INPUT structure
                        IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(input));

                        // Convert the INPUT structure to a pointer
                        Marshal.StructureToPtr(input, lParam, false);

                        // Send the INPUT message to the specified window
                        uint result = SendMessage(hWnd, WM_INPUT, IntPtr.Zero, lParam);

                        // Free the memory used by the INPUT structure
                        Marshal.FreeHGlobal(lParam);

                        // Wait for a short amount of time before sending the next INPUT structure
                        System.Threading.Thread.Sleep(mouseDelayFilter);
                    }
                }

            }



            // Set the text values of three trackbars to the width and height of the screen
            tb_YawTrackValue.Text = screenWidth.ToString();
            tb_PitchTrackValue.Text = screenHeight.ToString();
            tb_RollTrackValue.Text = screenWidth.ToString();

            // Rotate the first image (Yaw)
            // Clear the graphics and set the rotation point to the center of the image
            // Rotate the graphics by the negative value of xRot
            // Draw the image at the top left corner of the graphics
            // Set the picture box to display the rotated image
            // Reset the graphics to its original state
            graphics1.Clear(Color.White);
            graphics1.TranslateTransform(center1.X, center1.Y);
            graphics1.RotateTransform((float)-xRot);
            graphics1.DrawImage(Properties.Resources.imageYaw, -center1.X, -center1.Y);
            pictureBox1.Image = image1;
            graphics1.ResetTransform();

            // Rotate the second image (Pitch)
            // Clear the graphics and set the rotation point to the center of the image
            // Rotate the graphics by the negative value of yRot
            // Draw the image at the top left corner of the graphics
            // Set the picture box to display the rotated image
            // Reset the graphics to its original state
            graphics2.Clear(Color.White);
            graphics2.TranslateTransform(center2.X, center2.Y);
            graphics2.RotateTransform((float)-yRot);
            graphics2.DrawImage(Properties.Resources.imagePitch, -center2.X, -center2.Y);
            pictureBox2.Image = image2;
            graphics2.ResetTransform();

            // Rotate the third image (Roll)
            // Clear the graphics and set the rotation point to the center of the image
            // Rotate the graphics by the positive value of rollRot
            // Draw the image at the top left corner of the graphics
            // Set the picture box to display the rotated image
            // Reset the graphics to its original state
            graphics3.Clear(Color.White);
            graphics3.TranslateTransform(center3.X, center3.Y);
            graphics3.RotateTransform((float)rollRot);
            graphics3.DrawImage(Properties.Resources.imageRoll, -center3.X, -center3.Y);
            pictureBox3.Image = image3;
            graphics3.ResetTransform();

            // Update the labels and text boxes with relevant information
            // Display the values of arr[2], arr[1], and arr[0] in the respective labels
            // Display the current position of the mouse in the text box
            labelRawYaw.Text = string.Format("Raw Yaw: {0:0.00}", arr[2]);
            labelRawPitch.Text = string.Format("Raw Pitch: {0:0.00}", arr[1]);
            labelRawRoll.Text = string.Format("Raw Roll: {0:0.00}", arr[0]);
            textBoxMouseLocation.Text = string.Format("Mouse X:{0} Mouse Y:{1}", Cursor.Position.X, Cursor.Position.Y);
        }

        private void filterData(out double filteredDeltaX, out double filteredDeltaY, out double filteredDeltaRoll,
                                double x, double y, double roll)
        {
            // Set the filter constant alpha (between 0 and 1) - higher values = smoother filter
            // This variable controls the weight given to new input values vs. the filtered output.
            // A higher value of alpha results in a smoother filter, but can make the filter less responsive to changes in input.

            double alpha = 0.2;

            // Define the number of raw input values to capture in the filter
            // This variable controls the number of raw input values that are used to compute the filtered output.
            // A larger value of numRawValues results in a slower response time but smoother output.
            // A smaller value of numRawValues results in a faster response time but noisier output.

            int numRawValues = trackBarDrift.Value;
            labelDriftFilter.Text = string.Format("Drift Filter: {0:0}", trackBarDrift.Value);

            // Define arrays for storing raw input values and filtered values
            // These arrays store the most recent raw input values and their corresponding filtered values.
            // The size of the arrays is equal to numRawValues.

            double[] rawDeltaX = new double[numRawValues];
            double[] rawDeltaY = new double[numRawValues];
            double[] rawDeltaRoll = new double[numRawValues];
            filteredDeltaX = 0;
            filteredDeltaY = 0;
            filteredDeltaRoll = 0;

            // Shift the raw input values down by one index
            // This loop shifts the raw input values down by one index in the arrays,
            // making room for the most recent input values to be added to the beginning.
            // The oldest input value is discarded.

            for (int i = numRawValues - 1; i > 0; i--)
            {
                rawDeltaX[i] = rawDeltaX[i - 1];
                rawDeltaY[i] = rawDeltaY[i - 1];
                rawDeltaRoll[i] = rawDeltaRoll[i - 1];
            }

            // Add the current raw input values to the beginning of the arrays
            // This step adds the most recent input values to the beginning of the arrays,
            // overwriting the oldest input value that was shifted out in the previous loop.

            rawDeltaX[0] = x;
            rawDeltaY[0] = y;
            rawDeltaRoll[0] = roll;

            // Apply the EMA filter to the raw input values
            // This loop applies the EMA (Exponential Moving Average) filter to the raw input values,
            // producing the filtered output values for deltaX, deltaY, and deltaRoll.
            // Each filtered output value is computed as a weighted average of the raw input values
            // and the previous filtered output value, with the weight given by alpha.

            for (int i = 0; i < numRawValues; i++)
            {
                filteredDeltaX = alpha * rawDeltaX[i] + (1 - alpha) * filteredDeltaX;
                filteredDeltaY = alpha * rawDeltaY[i] + (1 - alpha) * filteredDeltaY;
                filteredDeltaRoll = alpha * rawDeltaRoll[i] + (1 - alpha) * filteredDeltaRoll;
                //rawDeltaXTrack[i] = filteredDeltaX;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            // Set some initial variables to false, and enable certain UI elements
            isMouseTrack = false; // Tracks whether the mouse is being used to control a camera
            isOpenTrack = false; // Tracks whether an external program is being used to control a camera
            buttonReset.Enabled = true; // Enable a button to reset camera values
            trackBarYawSpeed.Enabled = true; // Enable a slider to control camera yaw speed
            trackBarPitchSpeed.Enabled = true; // Enable a slider to control camera pitch speed
            trackBarRollSpeed.Enabled = true; // Enable a slider to control camera roll speed
            trackBarDrift.Enabled = true; // Enable a slider to control camera drift
            labelDriftFilter.Enabled = true; // Enable a label for the camera drift slider
            groupBoxOpentrack.Enabled = true; // Enable a group box for controlling OpenTrack settings
            groupBoxMouseTrack.Enabled = true; // Enable a group box for controlling mouse tracking settings

            // Reset any camera values that need to be reset
            ResetValues();

            // Stop the timer that triggered this code
            (sender as Timer).Stop();

        }

        private void ResetValues()
        {
            // Initialize rotation and delta values to zero
            xRot = 0;
            yRot = 0;
            rollRot = 0;
            deltaX = 0;
            deltaY = 0;
            deltaRoll = 0;

            // Calculate distance between current and desired rotations
            rotDistanceYaw = xRot - arr[2]; // Distance in the yaw (horizontal) axis
            rotDistancePitch = yRot - arr[1]; // Distance in the pitch (vertical) axis
            rollDistanceRoll = rollRot - arr[0]; // Distance in the roll (tilt) axis

        }

        private void buttonStartOpentrack_Click(object sender, EventArgs e)
        {
            // Set up the OpenTrack connection
            isMouseTrack = false;           // Disable mouse tracking
            isOpenTrack = true;             // Enable OpenTrack connection
            buttonStopOpentrack.Enabled = true;   // Enable "Stop" button
            buttonStartOpentrack.Enabled = false; // Disable "Start" button
            textBoxIPAddress.Enabled = false;     // Disable IP address text box
            textBoxPort.Enabled = false;          // Disable port text box
            groupBoxMouseTrack.Enabled = false;   // Disable mouse tracking settings
            trackBarYawSpeed.Enabled = false;     // Disable yaw speed adjustment
            trackBarPitchSpeed.Enabled = false;   // Disable pitch speed adjustment
            trackBarRollSpeed.Enabled = false;    // Disable roll speed adjustment
            ResetValues();                        // Reset any other necessary values
            ipAddress = IPAddress.Parse(textBoxIPAddress.Text); // Use the loopback address for testing purposes, replace with actual IP address when deploying
            port = int.Parse(textBoxPort.Text); // Use the default OpenTrack server port number

            // Create a new IPEndPoint to store the IP address and port number of the OpenTrack server
            endPoint = new IPEndPoint(ipAddress, port);
        }

        private void buttonStopOpentrack_Click(object sender, EventArgs e)
        {
            // Set initial values for variables and controls
            isMouseTrack = false;               // Set mouse tracking to false
            isOpenTrack = false;                // Set open tracking to false
            buttonStopOpentrack.Enabled = false;// Disable the "Stop" button for open tracking
            buttonStartOpentrack.Enabled = true;// Enable the "Start" button for open tracking
            textBoxIPAddress.Enabled = true;    // Enable IP address textbox
            textBoxPort.Enabled = true;         // Enable port number textbox
            groupBoxMouseTrack.Enabled = true;  // Enable mouse tracking group box
            trackBarYawSpeed.Enabled = true;    // Enable yaw speed track bar
            trackBarPitchSpeed.Enabled = true;  // Enable pitch speed track bar
            trackBarRollSpeed.Enabled = true;   // Enable roll speed track bar

        }
        
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        protected override void WndProc(ref Message m)
        {

            // Check if the message is a WM_INPUT message
            if (m.Msg == WM_INPUT)
            {
                // Check if the LPARAM contains a valid input struct
                if (m.LParam != null)
                {
                    // Cast the LPARAM to an INPUT struct
                    INPUT raw = (INPUT)Marshal.PtrToStructure(m.LParam, typeof(INPUT));

                    try
                    {
                        // Check if mouse tracking is enabled
                        if (isMouseTrack)
                        {
                            // Send the raw input as mouse input
                            if (SendInput(1, new INPUT[] { raw }, Marshal.SizeOf(raw)) == 0)
                            {
                                // Display an error message if the input failed to send
                                textBoxLog1.Text = string.Format("Failed to send mouse input.");
                            }
                        }
                    }
                    finally
                    {
                        // Perform any necessary cleanup
                    }
                }
            }

            // Call the base class's WndProc method to handle the message
            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Call the StartConnection method to initiate a connection and store the result in a variable
            int result = StartConnection();

            // Check if the result is equal to 1 to confirm if the connection is successful
            if (result == 1)
            {
                // If the connection is successful, set the text of label2 to "Connected"
                label2.Text = "Connected";

                // Set the window handle to the base handle
                hWnd = base.Handle;

                // Create a new timer object and set the interval to 6 seconds
                Timer timer = new Timer();
                timer.Interval = 6000; // 6 seconds

                // Attach an event handler for the timer tick
                timer.Tick += new EventHandler(timer2_Tick);

                // Start the timer
                timer.Start();
            }
            else
            {
                // If the connection is not successful, set the text of label2 to "Not Connected"
                label2.Text = "Not Connected";
            }

            // Enable the timer1 object
            timer1.Enabled = true;
        }

        private void buttonMouseTrackOn_Click(object sender, EventArgs e)
        {
            // Enable mouse tracking and disable OpenTrack controls when starting to track
            isMouseTrack = true; // Set flag to indicate mouse tracking is active
            isOpenTrack = false; // Set flag to indicate OpenTrack is not active
            buttonMouseTrackOn.Enabled = false; // Disable button to start mouse tracking
            buttonMouseTrackOff.Enabled = true; // Enable button to stop mouse tracking
            trackBarYawSpeed.Enabled = false; // Disable control to adjust yaw speed
            trackBarPitchSpeed.Enabled = false; // Disable control to adjust pitch speed
            trackBarRollSpeed.Enabled = false; // Disable control to adjust roll speed
            groupBoxOpentrack.Enabled = false; // Disable group box containing OpenTrack controls

        }

        private void buttonMouseTrackOff_Click(object sender, EventArgs e)
        {
            isMouseTrack = false;    // This sets the value of the isMouseTrack variable to false
            isOpenTrack = false;     // This sets the value of the isOpenTrack variable to false
            buttonMouseTrackOn.Enabled = true;   // This enables the buttonMouseTrackOn button
            buttonMouseTrackOff.Enabled = false; // This disables the buttonMouseTrackOff button
            trackBarYawSpeed.Enabled = true;     // This enables the trackBarYawSpeed slider
            trackBarPitchSpeed.Enabled = true;   // This enables the trackBarPitchSpeed slider
            trackBarRollSpeed.Enabled = true;    // This enables the trackBarRollSpeed slider
            groupBoxOpentrack.Enabled = true;    // This enables the groupBoxOpentrack group box
        }

        public Form1()
        {
            // Initialize the form and its components
            InitializeComponent();

            // Create a new bitmap object for the first picture box with the same width and height as the picture box
            image1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Create a new graphics object from the first bitmap
            graphics1 = Graphics.FromImage(image1);

            // Create a new PointF object with the center coordinates of the first picture box
            center1 = new PointF(pictureBox1.Width / 2f, pictureBox1.Height / 2f);

            // Create a new bitmap object for the second picture box with the same width and height as the picture box
            image2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            // Create a new graphics object from the second bitmap
            graphics2 = Graphics.FromImage(image2);

            // Create a new PointF object with the center coordinates of the second picture box
            center2 = new PointF(pictureBox2.Width / 2f, pictureBox2.Height / 2f);

            // Create a new bitmap object for the second picture box with the same width and height as the picture box
            image3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);

            // Create a new graphics object from the second bitmap
            graphics3 = Graphics.FromImage(image3);

            // Create a new PointF object with the center coordinates of the second picture box
            center3 = new PointF(pictureBox3.Width / 2f, pictureBox3.Height / 2f);

            // Disable the timer
            timer1.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink2();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink3();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://github.com/iVideoGameBoss/PhoenixHeadTracker");
        }

        private void VisitLink2()
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://www.youtube.com/@ivideogameboss");
        }

        private void VisitLink3()
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://paypal.me/ivideogameboss?country.x=US&locale.x=en_US");
        }
    }
}
