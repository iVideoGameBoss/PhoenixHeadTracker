using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*
 * PhoenixHeadTracker - A head-tracking application for controlling the mouse cursor
 *
 * Copyright (C) [2023] [iVideoGameBoss] 
 *
 * Github <https://github.com/iVideoGameBoss/PhoenixHeadTracker>
 * YouTube <https://www.youtube.com/@ivideogameboss>
 * Reddit <https://www.reddit.com/user/jaktharkhan>
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
        public static extern IntPtr GetQuaternion();

        [DllImport("AirAPI_Windows", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetEuler();

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private Bitmap image1;
        private Graphics graphics1;
        private PointF center1;

        private Bitmap image2;
        private Graphics graphics2;
        private PointF center2;

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

            // Disable the timer
            timer1.Enabled = false;
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
            }
            else
            {
                // If the result is not equal to 1, set the text of label2 to "Not Connected"
                label2.Text = "Not Connected";
            }

            // Enable the timer
            timer1.Enabled = true;
        }

        public static void moveMouse(int xDelta, int yDelta)
        {
            mouse_event(1, xDelta, yDelta, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the Euler angles from the external library and store them in an array
            IntPtr ptr = GetEuler(); // assume that GetEuler() is a method that returns a pointer to a float array
            float[] arr = new float[3];
            Marshal.Copy(ptr, arr, 0, 3);

            // Get the screen dimensions
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calculate the x and y values for the image rotation based on the Euler angles and track bar values
            int x = (int)((arr[2] / trackBar2.Value) * screenWidth);
            int y = (int)((arr[1] / trackBar1.Value) * screenHeight);

            // Rotate the first image (Yaw)
            graphics1.Clear(Color.White);
            graphics1.TranslateTransform(center1.X, center1.Y);
            graphics1.RotateTransform(-x);
            graphics1.DrawImage(Properties.Resources.image, -center1.X, -center1.Y);
            pictureBox1.Image = image1;
            graphics1.ResetTransform();

            // Rotate the second image (Pitch)
            graphics2.Clear(Color.White);
            graphics2.TranslateTransform(center2.X, center2.Y);
            graphics2.RotateTransform(-y);
            graphics2.DrawImage(Properties.Resources.imageYaw, -center2.X, -center2.Y);
            pictureBox2.Image = image2;
            graphics2.ResetTransform();

            // Update the labels and text boxes with relevant information
            labelRawYaw.Text = string.Format("Raw Yaw: {0:0.00}", arr[2]);
            labelRawPitch.Text = string.Format("Raw Pitch: {0:0.00}", arr[1]);
            labelYaw.Text = string.Format("Match Yaw ({0:0.00})", x);
            labelPitch.Text = string.Format("Match Pitch ({0:0.00})", y);
            textBoxMouseLocation.Text = string.Format("Mouse X:{0} Mouse Y:{1}", Cursor.Position.X, Cursor.Position.Y);
        }

        private void buttonMouseTrackOn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void buttonMouseTrackOff_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
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

        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://github.com/iVideoGameBoss/PhoenixHeadTracker");
        }
    }
}
