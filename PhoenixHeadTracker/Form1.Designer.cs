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
            this.trackBarYawSpeed = new System.Windows.Forms.TrackBar();
            this.trackBarPitchSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMatchYaw = new System.Windows.Forms.Label();
            this.labelMatchPitch = new System.Windows.Forms.Label();
            this.labelRawYaw = new System.Windows.Forms.Label();
            this.labelRawPitch = new System.Windows.Forms.Label();
            this.buttonMouseTrackOn = new System.Windows.Forms.Button();
            this.buttonMouseTrackOff = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tb_YawTrackValue = new System.Windows.Forms.TextBox();
            this.tb_PitchTrackValue = new System.Windows.Forms.TextBox();
            this.labelRawRoll = new System.Windows.Forms.Label();
            this.labelMatchRoll = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarRollSpeed = new System.Windows.Forms.TrackBar();
            this.tb_RollTrackValue = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelYawRotation = new System.Windows.Forms.Label();
            this.labelPitchRotation = new System.Windows.Forms.Label();
            this.labelRollRotation = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelYawSpeed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPitchSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelRollSpeed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.trackBarDrift = new System.Windows.Forms.TrackBar();
            this.labelDriftFilter = new System.Windows.Forms.Label();
            this.labelMouseSmoothFilter = new System.Windows.Forms.Label();
            this.trackBarMouseSmooth = new System.Windows.Forms.TrackBar();
            this.labelMouseDelayFilter = new System.Windows.Forms.Label();
            this.trackBarMouseDelay = new System.Windows.Forms.TrackBar();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYawSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitchSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRollSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDrift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMouseSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMouseDelay)).BeginInit();
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
            this.textBoxMouseLocation.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxMouseLocation.Location = new System.Drawing.Point(633, 22);
            this.textBoxMouseLocation.Name = "textBoxMouseLocation";
            this.textBoxMouseLocation.ReadOnly = true;
            this.textBoxMouseLocation.Size = new System.Drawing.Size(203, 20);
            this.textBoxMouseLocation.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current Mouse Location";
            // 
            // trackBarYawSpeed
            // 
            this.trackBarYawSpeed.Enabled = false;
            this.trackBarYawSpeed.LargeChange = 1;
            this.trackBarYawSpeed.Location = new System.Drawing.Point(10, 398);
            this.trackBarYawSpeed.Maximum = 50000;
            this.trackBarYawSpeed.Minimum = 500;
            this.trackBarYawSpeed.Name = "trackBarYawSpeed";
            this.trackBarYawSpeed.Size = new System.Drawing.Size(200, 45);
            this.trackBarYawSpeed.TabIndex = 12;
            this.trackBarYawSpeed.Value = 5760;
            // 
            // trackBarPitchSpeed
            // 
            this.trackBarPitchSpeed.Enabled = false;
            this.trackBarPitchSpeed.LargeChange = 1;
            this.trackBarPitchSpeed.Location = new System.Drawing.Point(10, 398);
            this.trackBarPitchSpeed.Maximum = 50000;
            this.trackBarPitchSpeed.Minimum = 500;
            this.trackBarPitchSpeed.Name = "trackBarPitchSpeed";
            this.trackBarPitchSpeed.Size = new System.Drawing.Size(200, 45);
            this.trackBarPitchSpeed.TabIndex = 13;
            this.trackBarPitchSpeed.Value = 3240;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(824, 61);
            this.label3.TabIndex = 14;
            this.label3.Text = "Wait 5+ seconds for sensors to adjust after connection. Roll data is not used for" +
    " mouse track.";
            // 
            // labelMatchYaw
            // 
            this.labelMatchYaw.AutoSize = true;
            this.labelMatchYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatchYaw.Location = new System.Drawing.Point(14, 62);
            this.labelMatchYaw.Name = "labelMatchYaw";
            this.labelMatchYaw.Size = new System.Drawing.Size(120, 25);
            this.labelMatchYaw.TabIndex = 15;
            this.labelMatchYaw.Text = "Track Yaw:";
            // 
            // labelMatchPitch
            // 
            this.labelMatchPitch.AutoSize = true;
            this.labelMatchPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatchPitch.Location = new System.Drawing.Point(14, 62);
            this.labelMatchPitch.Name = "labelMatchPitch";
            this.labelMatchPitch.Size = new System.Drawing.Size(126, 25);
            this.labelMatchPitch.TabIndex = 16;
            this.labelMatchPitch.Text = "Track Pitch:";
            this.labelMatchPitch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawYaw
            // 
            this.labelRawYaw.AutoSize = true;
            this.labelRawYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawYaw.Location = new System.Drawing.Point(26, 37);
            this.labelRawYaw.Name = "labelRawYaw";
            this.labelRawYaw.Size = new System.Drawing.Size(108, 25);
            this.labelRawYaw.TabIndex = 17;
            this.labelRawYaw.Text = "Raw Yaw:";
            // 
            // labelRawPitch
            // 
            this.labelRawPitch.AutoSize = true;
            this.labelRawPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawPitch.Location = new System.Drawing.Point(26, 37);
            this.labelRawPitch.Name = "labelRawPitch";
            this.labelRawPitch.Size = new System.Drawing.Size(114, 25);
            this.labelRawPitch.TabIndex = 18;
            this.labelRawPitch.Text = "Raw Pitch:";
            // 
            // buttonMouseTrackOn
            // 
            this.buttonMouseTrackOn.Enabled = false;
            this.buttonMouseTrackOn.Location = new System.Drawing.Point(686, 434);
            this.buttonMouseTrackOn.Name = "buttonMouseTrackOn";
            this.buttonMouseTrackOn.Size = new System.Drawing.Size(150, 49);
            this.buttonMouseTrackOn.TabIndex = 19;
            this.buttonMouseTrackOn.Text = "Start Mouse Track";
            this.buttonMouseTrackOn.UseVisualStyleBackColor = true;
            this.buttonMouseTrackOn.Click += new System.EventHandler(this.buttonMouseTrackOn_Click);
            // 
            // buttonMouseTrackOff
            // 
            this.buttonMouseTrackOff.Enabled = false;
            this.buttonMouseTrackOff.Location = new System.Drawing.Point(686, 498);
            this.buttonMouseTrackOff.Name = "buttonMouseTrackOff";
            this.buttonMouseTrackOff.Size = new System.Drawing.Size(150, 45);
            this.buttonMouseTrackOff.TabIndex = 20;
            this.buttonMouseTrackOff.Text = "Stop Mouse Track";
            this.buttonMouseTrackOff.UseVisualStyleBackColor = true;
            this.buttonMouseTrackOff.Click += new System.EventHandler(this.buttonMouseTrackOff_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(710, 559);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "PhoenixHeadTracker";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(222, 12);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(266, 33);
            this.textBoxLog.TabIndex = 22;
            this.textBoxLog.Visible = false;
            // 
            // tb_YawTrackValue
            // 
            this.tb_YawTrackValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_YawTrackValue.Location = new System.Drawing.Point(10, 334);
            this.tb_YawTrackValue.Name = "tb_YawTrackValue";
            this.tb_YawTrackValue.ReadOnly = true;
            this.tb_YawTrackValue.Size = new System.Drawing.Size(200, 20);
            this.tb_YawTrackValue.TabIndex = 23;
            // 
            // tb_PitchTrackValue
            // 
            this.tb_PitchTrackValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_PitchTrackValue.Location = new System.Drawing.Point(10, 334);
            this.tb_PitchTrackValue.Name = "tb_PitchTrackValue";
            this.tb_PitchTrackValue.ReadOnly = true;
            this.tb_PitchTrackValue.Size = new System.Drawing.Size(200, 20);
            this.tb_PitchTrackValue.TabIndex = 24;
            // 
            // labelRawRoll
            // 
            this.labelRawRoll.AutoSize = true;
            this.labelRawRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawRoll.Location = new System.Drawing.Point(26, 37);
            this.labelRawRoll.Name = "labelRawRoll";
            this.labelRawRoll.Size = new System.Drawing.Size(103, 25);
            this.labelRawRoll.TabIndex = 27;
            this.labelRawRoll.Text = "Raw Roll:";
            // 
            // labelMatchRoll
            // 
            this.labelMatchRoll.AutoSize = true;
            this.labelMatchRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatchRoll.Location = new System.Drawing.Point(14, 62);
            this.labelMatchRoll.Name = "labelMatchRoll";
            this.labelMatchRoll.Size = new System.Drawing.Size(115, 25);
            this.labelMatchRoll.TabIndex = 26;
            this.labelMatchRoll.Text = "Track Roll:";
            this.labelMatchRoll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::PhoenixHeadTracker.Properties.Resources.imageRoll;
            this.pictureBox3.Location = new System.Drawing.Point(10, 98);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 200);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::PhoenixHeadTracker.Properties.Resources.imageYaw;
            this.pictureBox2.Location = new System.Drawing.Point(10, 98);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::PhoenixHeadTracker.Properties.Resources.image;
            this.pictureBox1.Location = new System.Drawing.Point(10, 98);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarRollSpeed
            // 
            this.trackBarRollSpeed.Enabled = false;
            this.trackBarRollSpeed.LargeChange = 1;
            this.trackBarRollSpeed.Location = new System.Drawing.Point(10, 398);
            this.trackBarRollSpeed.Maximum = 50000;
            this.trackBarRollSpeed.Minimum = 500;
            this.trackBarRollSpeed.Name = "trackBarRollSpeed";
            this.trackBarRollSpeed.Size = new System.Drawing.Size(200, 45);
            this.trackBarRollSpeed.TabIndex = 28;
            this.trackBarRollSpeed.Value = 5760;
            // 
            // tb_RollTrackValue
            // 
            this.tb_RollTrackValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_RollTrackValue.Location = new System.Drawing.Point(10, 334);
            this.tb_RollTrackValue.Name = "tb_RollTrackValue";
            this.tb_RollTrackValue.ReadOnly = true;
            this.tb_RollTrackValue.Size = new System.Drawing.Size(200, 20);
            this.tb_RollTrackValue.TabIndex = 29;
            // 
            // buttonReset
            // 
            this.buttonReset.Enabled = false;
            this.buttonReset.Location = new System.Drawing.Point(686, 107);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(150, 55);
            this.buttonReset.TabIndex = 30;
            this.buttonReset.Text = "Reset Rotation";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelYawRotation
            // 
            this.labelYawRotation.AutoSize = true;
            this.labelYawRotation.Location = new System.Drawing.Point(16, 105);
            this.labelYawRotation.Name = "labelYawRotation";
            this.labelYawRotation.Size = new System.Drawing.Size(13, 13);
            this.labelYawRotation.TabIndex = 31;
            this.labelYawRotation.Text = "0";
            // 
            // labelPitchRotation
            // 
            this.labelPitchRotation.AutoSize = true;
            this.labelPitchRotation.Location = new System.Drawing.Point(16, 105);
            this.labelPitchRotation.Name = "labelPitchRotation";
            this.labelPitchRotation.Size = new System.Drawing.Size(13, 13);
            this.labelPitchRotation.TabIndex = 32;
            this.labelPitchRotation.Text = "0";
            // 
            // labelRollRotation
            // 
            this.labelRollRotation.AutoSize = true;
            this.labelRollRotation.Location = new System.Drawing.Point(16, 105);
            this.labelRollRotation.Name = "labelRollRotation";
            this.labelRollRotation.Size = new System.Drawing.Size(13, 13);
            this.labelRollRotation.TabIndex = 33;
            this.labelRollRotation.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelYawSpeed);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.trackBarYawSpeed);
            this.groupBox1.Controls.Add(this.labelMatchYaw);
            this.groupBox1.Controls.Add(this.labelYawRotation);
            this.groupBox1.Controls.Add(this.labelRawYaw);
            this.groupBox1.Controls.Add(this.tb_YawTrackValue);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(5, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 449);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yaw";
            // 
            // labelYawSpeed
            // 
            this.labelYawSpeed.AutoSize = true;
            this.labelYawSpeed.Location = new System.Drawing.Point(11, 370);
            this.labelYawSpeed.Name = "labelYawSpeed";
            this.labelYawSpeed.Size = new System.Drawing.Size(65, 13);
            this.labelYawSpeed.TabIndex = 33;
            this.labelYawSpeed.Text = "Yaw Speed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Screen Width";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelPitchSpeed);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.trackBarPitchSpeed);
            this.groupBox2.Controls.Add(this.labelMatchPitch);
            this.groupBox2.Controls.Add(this.labelPitchRotation);
            this.groupBox2.Controls.Add(this.labelRawPitch);
            this.groupBox2.Controls.Add(this.tb_PitchTrackValue);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(232, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 449);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pitch";
            // 
            // labelPitchSpeed
            // 
            this.labelPitchSpeed.AutoSize = true;
            this.labelPitchSpeed.Location = new System.Drawing.Point(11, 370);
            this.labelPitchSpeed.Name = "labelPitchSpeed";
            this.labelPitchSpeed.Size = new System.Drawing.Size(68, 13);
            this.labelPitchSpeed.TabIndex = 34;
            this.labelPitchSpeed.Text = "Pitch Speed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Screen Height";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelRollSpeed);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.labelMatchRoll);
            this.groupBox3.Controls.Add(this.labelRawRoll);
            this.groupBox3.Controls.Add(this.labelRollRotation);
            this.groupBox3.Controls.Add(this.trackBarRollSpeed);
            this.groupBox3.Controls.Add(this.tb_RollTrackValue);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Location = new System.Drawing.Point(459, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 449);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Roll";
            // 
            // labelRollSpeed
            // 
            this.labelRollSpeed.AutoSize = true;
            this.labelRollSpeed.Location = new System.Drawing.Point(11, 370);
            this.labelRollSpeed.Name = "labelRollSpeed";
            this.labelRollSpeed.Size = new System.Drawing.Size(62, 13);
            this.labelRollSpeed.TabIndex = 35;
            this.labelRollSpeed.Text = "Roll Speed:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Screen Width";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // trackBarDrift
            // 
            this.trackBarDrift.Enabled = false;
            this.trackBarDrift.Location = new System.Drawing.Point(687, 216);
            this.trackBarDrift.Maximum = 20;
            this.trackBarDrift.Minimum = 1;
            this.trackBarDrift.Name = "trackBarDrift";
            this.trackBarDrift.Size = new System.Drawing.Size(149, 45);
            this.trackBarDrift.TabIndex = 37;
            this.trackBarDrift.Value = 10;
            // 
            // labelDriftFilter
            // 
            this.labelDriftFilter.AutoSize = true;
            this.labelDriftFilter.Location = new System.Drawing.Point(687, 197);
            this.labelDriftFilter.Name = "labelDriftFilter";
            this.labelDriftFilter.Size = new System.Drawing.Size(57, 13);
            this.labelDriftFilter.TabIndex = 38;
            this.labelDriftFilter.Text = "Drift Filter :";
            // 
            // labelMouseSmoothFilter
            // 
            this.labelMouseSmoothFilter.AutoSize = true;
            this.labelMouseSmoothFilter.Location = new System.Drawing.Point(690, 268);
            this.labelMouseSmoothFilter.Name = "labelMouseSmoothFilter";
            this.labelMouseSmoothFilter.Size = new System.Drawing.Size(109, 13);
            this.labelMouseSmoothFilter.TabIndex = 40;
            this.labelMouseSmoothFilter.Text = "Mouse Smooth Filter :";
            // 
            // trackBarMouseSmooth
            // 
            this.trackBarMouseSmooth.Enabled = false;
            this.trackBarMouseSmooth.Location = new System.Drawing.Point(690, 287);
            this.trackBarMouseSmooth.Maximum = 20;
            this.trackBarMouseSmooth.Minimum = 1;
            this.trackBarMouseSmooth.Name = "trackBarMouseSmooth";
            this.trackBarMouseSmooth.Size = new System.Drawing.Size(149, 45);
            this.trackBarMouseSmooth.TabIndex = 39;
            this.trackBarMouseSmooth.Value = 6;
            // 
            // labelMouseDelayFilter
            // 
            this.labelMouseDelayFilter.AutoSize = true;
            this.labelMouseDelayFilter.Location = new System.Drawing.Point(690, 334);
            this.labelMouseDelayFilter.Name = "labelMouseDelayFilter";
            this.labelMouseDelayFilter.Size = new System.Drawing.Size(100, 13);
            this.labelMouseDelayFilter.TabIndex = 42;
            this.labelMouseDelayFilter.Text = "Mouse Delay Filter :";
            // 
            // trackBarMouseDelay
            // 
            this.trackBarMouseDelay.Enabled = false;
            this.trackBarMouseDelay.Location = new System.Drawing.Point(690, 353);
            this.trackBarMouseDelay.Maximum = 20;
            this.trackBarMouseDelay.Minimum = 1;
            this.trackBarMouseDelay.Name = "trackBarMouseDelay";
            this.trackBarMouseDelay.Size = new System.Drawing.Size(149, 45);
            this.trackBarMouseDelay.TabIndex = 41;
            this.trackBarMouseDelay.Value = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(570, 559);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(134, 13);
            this.linkLabel2.TabIndex = 43;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "iVideoGameBoss YouTube";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(16, 561);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(45, 13);
            this.linkLabel3.TabIndex = 44;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Donate!";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(848, 583);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.labelMouseDelayFilter);
            this.Controls.Add(this.trackBarMouseDelay);
            this.Controls.Add(this.labelMouseSmoothFilter);
            this.Controls.Add(this.trackBarMouseSmooth);
            this.Controls.Add(this.labelDriftFilter);
            this.Controls.Add(this.trackBarDrift);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonMouseTrackOff);
            this.Controls.Add(this.buttonMouseTrackOn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMouseLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "PhoenixHeadTracker 2.0.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYawSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitchSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRollSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDrift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMouseSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMouseDelay)).EndInit();
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
        private System.Windows.Forms.TrackBar trackBarYawSpeed;
        private System.Windows.Forms.TrackBar trackBarPitchSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMatchYaw;
        private System.Windows.Forms.Label labelMatchPitch;
        private System.Windows.Forms.Label labelRawYaw;
        private System.Windows.Forms.Label labelRawPitch;
        private System.Windows.Forms.Button buttonMouseTrackOn;
        private System.Windows.Forms.Button buttonMouseTrackOff;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox tb_YawTrackValue;
        private System.Windows.Forms.TextBox tb_PitchTrackValue;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelRawRoll;
        private System.Windows.Forms.Label labelMatchRoll;
        private System.Windows.Forms.TrackBar trackBarRollSpeed;
        private System.Windows.Forms.TextBox tb_RollTrackValue;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelYawRotation;
        private System.Windows.Forms.Label labelPitchRotation;
        private System.Windows.Forms.Label labelRollRotation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelYawSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPitchSpeed;
        private System.Windows.Forms.Label labelRollSpeed;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TrackBar trackBarDrift;
        private System.Windows.Forms.Label labelDriftFilter;
        private System.Windows.Forms.Label labelMouseSmoothFilter;
        private System.Windows.Forms.TrackBar trackBarMouseSmooth;
        private System.Windows.Forms.Label labelMouseDelayFilter;
        private System.Windows.Forms.TrackBar trackBarMouseDelay;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}

