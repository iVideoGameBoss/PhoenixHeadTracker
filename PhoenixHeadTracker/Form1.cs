using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;



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

        private Bitmap image1;
        private Graphics graphics1;
        private PointF center1;

        private Bitmap image2;
        private Graphics graphics2;
        private PointF center2;

        private Bitmap image3;
        private Graphics graphics3;
        private PointF center3;

        private bool isMouseTrack = false;

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

        private const int WM_INPUT = 0x00FF;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private int screenWidth = 1920;
        private int screenHeight = 1080;
        private int screenWidthScale = 1920;
        private int screenHeightScale = 1080;
        private int x = 0;
        private int y = 0;
        private int roll = 0;
        private INPUT input;
        private IntPtr hWnd;


        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the screen dimensions
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidthScale = screenWidth;
            screenHeightScale = screenHeight;
            input = new INPUT();
            input.type = 0;
            input.inputUnion.mouseInput.mouseData = 0;
            input.inputUnion.mouseInput.dwFlags = MOUSEEVENTF_MOVE;
            input.inputUnion.mouseInput.time = 0;
            input.inputUnion.mouseInput.dwExtraInfo = GetMessageExtraInfo();


        }


        protected override void WndProc(ref Message m)
        {

            if (m.Msg == WM_INPUT)
            {
                if (m.LParam != null)
                {
                    // Cast the lParam to a INPUT struct
                    INPUT raw = (INPUT)Marshal.PtrToStructure(m.LParam, typeof(INPUT));

                    try
                    {
                        if (isMouseTrack)
                        {
                            if (SendInput(1, new INPUT[] { raw }, Marshal.SizeOf(raw)) == 0)
                            {
                                textBoxLog.Text = string.Format("Failed to send mouse input.");
                            }
                        }

                    }
                    finally
                    {


                    }
                }
            }
            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Call the StartConnection method and store the result in a variable
            int result = StartConnection();

            // Check if the result is equal to 1
            if (result == 1)
            {
                // If the result is 1, set the text of label2 to "Connected"
                label2.Text = "Connected";
                hWnd = base.Handle;
                Timer timer = new Timer();
                timer.Interval = 6000; // 6 seconds
                timer.Tick += new EventHandler(timer2_Tick);
                timer.Start();

            }
            else
            {
                // If the result is not equal to 1, set the text of label2 to "Not Connected"
                label2.Text = "Not Connected";
            }

            // Enable the timer
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Get the Euler angles from the external library and store them in an array
            IntPtr ptr = GetEuler(); // assume that GetEuler() is a method that returns a pointer to a float array
            float[] arr = new float[3];
            Marshal.Copy(ptr, arr, 0, 3);

            // Calculate the x, y, rol values based on a very large n
            x = (int)(arr[2] * (screenWidth * screenWidthScale) / trackBarYawSpeed.Value);
            y = (int)(arr[1] * (screenHeight * screenHeightScale) / trackBarPitchSpeed.Value);
            roll = (int)(arr[0] * screenWidth * screenWidthScale / trackBarRollSpeed.Value);

            xMapped = x;
            yMapped = y;
            rollMapped = roll;

            labelYawSpeed.Text = string.Format("Yaw Speed: {0:0}", trackBarYawSpeed.Value);
            labelPitchSpeed.Text = string.Format("Pitch Speed: {0:0}", trackBarPitchSpeed.Value);
            labelRollSpeed.Text = string.Format("Roll Speed: {0:0}", trackBarRollSpeed.Value);

            if (xMapped != previousX || yMapped != previousY) // Check if Degrees has changed
            {
                deltaX = xMapped - previousX;
                deltaY = yMapped - previousY;
                deltaRoll = rollMapped - previousRoll;

                if (previousX == 0 || previousY == 0 || previousRoll == 0)
                {
                    xRot = 0;
                    yRot = 0;
                    rollRot = 0;
                    deltaX = 0;
                    deltaY = 0;
                }

                // Set the filter constant alpha (between 0 and 1) - higher values = smoother filter
                double alpha = 0.2;

                // Define the number of raw input values to capture in the filter
                int numRawValues = trackBarDrift.Value;
                labelDriftFilter.Text = string.Format("Drift Filter: {0:0}", trackBarDrift.Value);

                // Define arrays for storing raw input values and filtered values
                double[] rawDeltaX = new double[numRawValues];
                double[] rawDeltaY = new double[numRawValues];
                double[] rawDeltaRoll = new double[numRawValues];
                double filteredDeltaX = 0;
                double filteredDeltaY = 0;
                double filteredDeltaRoll = 0;

                // Shift the raw input values down by one index
                for (int i = numRawValues - 1; i > 0; i--)
                {
                    rawDeltaX[i] = rawDeltaX[i - 1];
                    rawDeltaY[i] = rawDeltaY[i - 1];
                    rawDeltaRoll[i] = rawDeltaRoll[i - 1];
                }

                // Add the current raw input values to the beginning of the arrays
                rawDeltaX[0] = deltaX;
                rawDeltaY[0] = deltaY;
                rawDeltaRoll[0] = deltaRoll;

                // Apply the EMA filter to the raw input values
                for (int i = 0; i < numRawValues; i++)
                {
                    filteredDeltaX = alpha * rawDeltaX[i] + (1 - alpha) * filteredDeltaX;
                    filteredDeltaY = alpha * rawDeltaY[i] + (1 - alpha) * filteredDeltaY;
                    filteredDeltaRoll = alpha * rawDeltaRoll[i] + (1 - alpha) * filteredDeltaRoll;
                }

                // Update the rotation variables with the filtered values
                xRot += (int)filteredDeltaX;
                yRot += (int)filteredDeltaY;
                rollRot += (int)filteredDeltaRoll;

                labelYawRotation.Text = xRot.ToString();
                labelPitchRotation.Text = yRot.ToString();
                labelRollRotation.Text = rollRot.ToString();

                previousX = xMapped;
                previousY = yMapped;
                previousRoll = rollMapped;
                int mouseSmoothFilter = trackBarMouseSmooth.Value;
                labelMouseSmoothFilter.Text = string.Format("Mouse Smooth Filter: {0:0}", mouseSmoothFilter);
                int mouseDelayFilter = trackBarMouseDelay.Value;
                labelMouseDelayFilter.Text = string.Format("Mouse Delay Filter :: {0:0}", mouseDelayFilter);

                if (isMouseTrack)
                {
                    for (int x = 0; x < mouseSmoothFilter; x++)
                    {
                        input.inputUnion.mouseInput.dx = -(int)filteredDeltaX;
                        input.inputUnion.mouseInput.dy = -(int)filteredDeltaY;

                        IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(input));
                        Marshal.StructureToPtr(input, lParam, false);
                        uint result = SendMessage(hWnd, WM_INPUT, IntPtr.Zero, lParam);
                        Marshal.FreeHGlobal(lParam);

                        // Wait a short amount of time before sending the next INPUT structure
                        System.Threading.Thread.Sleep(mouseDelayFilter);
                    }
                }
            }

            tb_YawTrackValue.Text = screenWidth.ToString();
            tb_PitchTrackValue.Text = screenHeight.ToString();
            tb_RollTrackValue.Text = screenWidth.ToString();

            // Rotate the first image (Yaw)
            graphics1.Clear(Color.White);
            graphics1.TranslateTransform(center1.X, center1.Y);
            graphics1.RotateTransform((float)-xRot);
            graphics1.DrawImage(Properties.Resources.image, -center1.X, -center1.Y);
            pictureBox1.Image = image1;
            graphics1.ResetTransform();

            // Rotate the second image (Pitch)
            graphics2.Clear(Color.White);
            graphics2.TranslateTransform(center2.X, center2.Y);
            graphics2.RotateTransform((float)-yRot);
            graphics2.DrawImage(Properties.Resources.imageYaw, -center2.X, -center2.Y);
            pictureBox2.Image = image2;
            graphics2.ResetTransform();

            // Rotate the second image (Pitch)
            graphics3.Clear(Color.White);
            graphics3.TranslateTransform(center3.X, center3.Y);
            graphics3.RotateTransform((float)rollRot);
            graphics3.DrawImage(Properties.Resources.imageYaw, -center3.X, -center3.Y);
            pictureBox3.Image = image3;
            graphics3.ResetTransform();

            // Update the labels and text boxes with relevant information
            labelRawYaw.Text = string.Format("Raw Yaw: {0:0.00}", arr[2]);
            labelRawPitch.Text = string.Format("Raw Pitch: {0:0.00}", arr[1]);
            labelRawRoll.Text = string.Format("Raw Roll: {0:0.00}", arr[0]);
            labelMatchYaw.Text = string.Format("Track Yaw {0:0.00}", xRot);
            labelMatchPitch.Text = string.Format("Track Pitch {0:0.00}", yRot);
            labelMatchRoll.Text = string.Format("Track Roll {0:0.00}", rollRot);
            textBoxMouseLocation.Text = string.Format("Mouse X:{0} Mouse Y:{1}", Cursor.Position.X, Cursor.Position.Y);

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            xRot = 0;
            yRot = 0;
            rollRot = 0;
            deltaX = 0;
            deltaY = 0;
            deltaRoll = 0;
        }

        private void buttonMouseTrackOn_Click(object sender, EventArgs e)
        {
            isMouseTrack = true;
            buttonMouseTrackOn.Enabled = false;
            buttonMouseTrackOff.Enabled = true;
            trackBarYawSpeed.Enabled = false;
            trackBarPitchSpeed.Enabled = false;
            trackBarRollSpeed.Enabled = false;
            trackBarDrift.Enabled = false;
            trackBarMouseSmooth.Enabled = false;
            trackBarMouseDelay.Enabled = false;
            labelMouseDelayFilter.Enabled = false;

        }

        private void buttonMouseTrackOff_Click(object sender, EventArgs e)
        {
            isMouseTrack = false;
            buttonMouseTrackOn.Enabled = true;
            buttonMouseTrackOff.Enabled = false;
            trackBarYawSpeed.Enabled = true;
            trackBarPitchSpeed.Enabled = true;
            trackBarRollSpeed.Enabled = true;
            trackBarDrift.Enabled = true;
            trackBarMouseSmooth.Enabled = true;
            trackBarMouseDelay.Enabled = true;
            labelMouseDelayFilter.Enabled = true;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            buttonMouseTrackOn.Enabled = true;
            buttonReset.Enabled = true;
            trackBarYawSpeed.Enabled = true;
            trackBarPitchSpeed.Enabled = true;
            trackBarRollSpeed.Enabled = true;
            trackBarDrift.Enabled = true;
            trackBarMouseSmooth.Enabled = true;
            trackBarMouseDelay.Enabled = true;
            labelMouseDelayFilter.Enabled = true;

            xRot = 0;
            yRot = 0;
            rollRot = 0;
            deltaX = 0;
            deltaY = 0;
            deltaRoll = 0;
            (sender as Timer).Stop();
        }

    }
}
