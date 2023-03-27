namespace PhoenixHeadTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxMouseLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelYaw = new System.Windows.Forms.Label();
            this.labelPitch = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelRawYaw = new System.Windows.Forms.Label();
            this.labelRawPitch = new System.Windows.Forms.Label();
            this.buttonMouseTrackOn = new System.Windows.Forms.Button();
            this.buttonMouseTrackOff = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "Connect Nreal Air";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Not Connected";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxMouseLocation
            // 
            this.textBoxMouseLocation.Location = new System.Drawing.Point(12, 482);
            this.textBoxMouseLocation.Name = "textBoxMouseLocation";
            this.textBoxMouseLocation.Size = new System.Drawing.Size(203, 20);
            this.textBoxMouseLocation.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current Mouse Location";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(254, 388);
            this.trackBar1.Maximum = 4000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(200, 45);
            this.trackBar1.TabIndex = 12;
            this.trackBar1.Value = 900;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(13, 388);
            this.trackBar2.Maximum = 4000;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(200, 45);
            this.trackBar2.TabIndex = 13;
            this.trackBar2.Value = 1440;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(591, 61);
            this.label3.TabIndex = 14;
            this.label3.Text = "Wait 5+ seconds for sensors to adjust after connection. Then use sliders to match" +
    " \'Raw Yaw\' to \'Match Yaw\' and \'Raw Pitch\' to \'Match Pitch\' roughly.";
            // 
            // labelYaw
            // 
            this.labelYaw.AutoSize = true;
            this.labelYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYaw.Location = new System.Drawing.Point(12, 139);
            this.labelYaw.Name = "labelYaw";
            this.labelYaw.Size = new System.Drawing.Size(125, 25);
            this.labelYaw.TabIndex = 15;
            this.labelYaw.Text = "Match Yaw:";
            // 
            // labelPitch
            // 
            this.labelPitch.AutoSize = true;
            this.labelPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPitch.Location = new System.Drawing.Point(249, 139);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(131, 25);
            this.labelPitch.TabIndex = 16;
            this.labelPitch.Text = "Match Pitch:";
            this.labelPitch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::PhoenixHeadTracker.Properties.Resources.imageYaw;
            this.pictureBox2.Location = new System.Drawing.Point(254, 175);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::PhoenixHeadTracker.Properties.Resources.image;
            this.pictureBox1.Location = new System.Drawing.Point(13, 175);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labelRawYaw
            // 
            this.labelRawYaw.AutoSize = true;
            this.labelRawYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawYaw.Location = new System.Drawing.Point(29, 114);
            this.labelRawYaw.Name = "labelRawYaw";
            this.labelRawYaw.Size = new System.Drawing.Size(108, 25);
            this.labelRawYaw.TabIndex = 17;
            this.labelRawYaw.Text = "Raw Yaw:";
            // 
            // labelRawPitch
            // 
            this.labelRawPitch.AutoSize = true;
            this.labelRawPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawPitch.Location = new System.Drawing.Point(266, 114);
            this.labelRawPitch.Name = "labelRawPitch";
            this.labelRawPitch.Size = new System.Drawing.Size(114, 25);
            this.labelRawPitch.TabIndex = 18;
            this.labelRawPitch.Text = "Raw Pitch:";
            // 
            // buttonMouseTrackOn
            // 
            this.buttonMouseTrackOn.Location = new System.Drawing.Point(245, 446);
            this.buttonMouseTrackOn.Name = "buttonMouseTrackOn";
            this.buttonMouseTrackOn.Size = new System.Drawing.Size(209, 23);
            this.buttonMouseTrackOn.TabIndex = 19;
            this.buttonMouseTrackOn.Text = "Start Mouse Track";
            this.buttonMouseTrackOn.UseVisualStyleBackColor = true;
            this.buttonMouseTrackOn.Click += new System.EventHandler(this.buttonMouseTrackOn_Click);
            // 
            // buttonMouseTrackOff
            // 
            this.buttonMouseTrackOff.Location = new System.Drawing.Point(245, 479);
            this.buttonMouseTrackOff.Name = "buttonMouseTrackOff";
            this.buttonMouseTrackOff.Size = new System.Drawing.Size(209, 23);
            this.buttonMouseTrackOff.TabIndex = 20;
            this.buttonMouseTrackOff.Text = "Stop Mouse Track";
            this.buttonMouseTrackOff.UseVisualStyleBackColor = true;
            this.buttonMouseTrackOff.Click += new System.EventHandler(this.buttonMouseTrackOff_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(495, 492);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "PhoenixHeadTracker";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(615, 514);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonMouseTrackOff);
            this.Controls.Add(this.buttonMouseTrackOn);
            this.Controls.Add(this.labelRawPitch);
            this.Controls.Add(this.labelRawYaw);
            this.Controls.Add(this.labelPitch);
            this.Controls.Add(this.labelYaw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMouseLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxMouseLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelYaw;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelRawYaw;
        private System.Windows.Forms.Label labelRawPitch;
        private System.Windows.Forms.Button buttonMouseTrackOn;
        private System.Windows.Forms.Button buttonMouseTrackOff;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

