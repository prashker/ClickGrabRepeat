namespace ClickGrabRepeat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGrabRegion = new System.Windows.Forms.Button();
            this.regionBox = new System.Windows.Forms.GroupBox();
            this.grabVerbose = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.clickBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudWaitTime = new System.Windows.Forms.NumericUpDown();
            this.clickVerbose = new System.Windows.Forms.Label();
            this.btnClick = new System.Windows.Forms.Button();
            this.repeatBox = new System.Windows.Forms.GroupBox();
            this.lblTimes = new System.Windows.Forms.Label();
            this.nudRepeatTimes = new System.Windows.Forms.NumericUpDown();
            this.rdbSetNumber = new System.Windows.Forms.RadioButton();
            this.rdbIndefinite = new System.Windows.Forms.RadioButton();
            this.lblHome = new System.Windows.Forms.LinkLabel();
            this.saveBox = new System.Windows.Forms.GroupBox();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.btnSaveFolder = new System.Windows.Forms.Button();
            this.chkMinimize = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.regionBox.SuspendLayout();
            this.clickBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaitTime)).BeginInit();
            this.repeatBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatTimes)).BeginInit();
            this.saveBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabRegion
            // 
            this.btnGrabRegion.Location = new System.Drawing.Point(6, 19);
            this.btnGrabRegion.Name = "btnGrabRegion";
            this.btnGrabRegion.Size = new System.Drawing.Size(121, 23);
            this.btnGrabRegion.TabIndex = 0;
            this.btnGrabRegion.Text = "Select &Region";
            this.btnGrabRegion.UseVisualStyleBackColor = true;
            this.btnGrabRegion.Click += new System.EventHandler(this.btnGrabRegion_Click);
            // 
            // regionBox
            // 
            this.regionBox.Controls.Add(this.grabVerbose);
            this.regionBox.Controls.Add(this.btnGrabRegion);
            this.regionBox.Location = new System.Drawing.Point(12, 81);
            this.regionBox.Name = "regionBox";
            this.regionBox.Size = new System.Drawing.Size(358, 50);
            this.regionBox.TabIndex = 7;
            this.regionBox.TabStop = false;
            this.regionBox.Text = "Grab";
            // 
            // grabVerbose
            // 
            this.grabVerbose.Location = new System.Drawing.Point(133, 24);
            this.grabVerbose.Name = "grabVerbose";
            this.grabVerbose.Size = new System.Drawing.Size(219, 13);
            this.grabVerbose.TabIndex = 0;
            this.grabVerbose.Text = "Awaiting region snip";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(148, 297);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // clickBox
            // 
            this.clickBox.Controls.Add(this.label1);
            this.clickBox.Controls.Add(this.label2);
            this.clickBox.Controls.Add(this.nudWaitTime);
            this.clickBox.Controls.Add(this.clickVerbose);
            this.clickBox.Controls.Add(this.btnClick);
            this.clickBox.Location = new System.Drawing.Point(12, 12);
            this.clickBox.Name = "clickBox";
            this.clickBox.Size = new System.Drawing.Size(358, 63);
            this.clickBox.TabIndex = 9;
            this.clickBox.TabStop = false;
            this.clickBox.Text = "Click";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "seconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Then wait";
            // 
            // nudWaitTime
            // 
            this.nudWaitTime.DecimalPlaces = 2;
            this.nudWaitTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudWaitTime.Location = new System.Drawing.Point(133, 40);
            this.nudWaitTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudWaitTime.Name = "nudWaitTime";
            this.nudWaitTime.Size = new System.Drawing.Size(64, 20);
            this.nudWaitTime.TabIndex = 16;
            this.nudWaitTime.ValueChanged += new System.EventHandler(this.nudWaitTime_ValueChanged);
            // 
            // clickVerbose
            // 
            this.clickVerbose.Location = new System.Drawing.Point(133, 21);
            this.clickVerbose.Name = "clickVerbose";
            this.clickVerbose.Size = new System.Drawing.Size(219, 13);
            this.clickVerbose.TabIndex = 1;
            this.clickVerbose.Text = "Awaiting coordinates";
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(6, 16);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(121, 23);
            this.btnClick.TabIndex = 2;
            this.btnClick.Text = "Select &Coordinates";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // repeatBox
            // 
            this.repeatBox.Controls.Add(this.lblTimes);
            this.repeatBox.Controls.Add(this.nudRepeatTimes);
            this.repeatBox.Controls.Add(this.rdbSetNumber);
            this.repeatBox.Controls.Add(this.rdbIndefinite);
            this.repeatBox.Location = new System.Drawing.Point(12, 137);
            this.repeatBox.Name = "repeatBox";
            this.repeatBox.Size = new System.Drawing.Size(358, 68);
            this.repeatBox.TabIndex = 10;
            this.repeatBox.TabStop = false;
            this.repeatBox.Text = "Repeat";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(128, 46);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(31, 13);
            this.lblTimes.TabIndex = 3;
            this.lblTimes.Text = "times";
            // 
            // nudRepeatTimes
            // 
            this.nudRepeatTimes.Location = new System.Drawing.Point(58, 42);
            this.nudRepeatTimes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRepeatTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeatTimes.Name = "nudRepeatTimes";
            this.nudRepeatTimes.Size = new System.Drawing.Size(64, 20);
            this.nudRepeatTimes.TabIndex = 2;
            this.nudRepeatTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeatTimes.ValueChanged += new System.EventHandler(this.nudRepeatTimes_ValueChanged);
            // 
            // rdbSetNumber
            // 
            this.rdbSetNumber.AutoSize = true;
            this.rdbSetNumber.Location = new System.Drawing.Point(7, 42);
            this.rdbSetNumber.Name = "rdbSetNumber";
            this.rdbSetNumber.Size = new System.Drawing.Size(50, 17);
            this.rdbSetNumber.TabIndex = 1;
            this.rdbSetNumber.Text = "&Fixed";
            this.rdbSetNumber.UseVisualStyleBackColor = true;
            this.rdbSetNumber.CheckedChanged += new System.EventHandler(this.rdbSetNumber_CheckedChanged);
            // 
            // rdbIndefinite
            // 
            this.rdbIndefinite.AutoSize = true;
            this.rdbIndefinite.Location = new System.Drawing.Point(7, 19);
            this.rdbIndefinite.Name = "rdbIndefinite";
            this.rdbIndefinite.Size = new System.Drawing.Size(75, 17);
            this.rdbIndefinite.TabIndex = 0;
            this.rdbIndefinite.Text = "&Indefinitely";
            this.rdbIndefinite.UseVisualStyleBackColor = true;
            this.rdbIndefinite.CheckedChanged += new System.EventHandler(this.rdbIndefinite_CheckedChanged);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblHome.LinkColor = System.Drawing.Color.DarkBlue;
            this.lblHome.Location = new System.Drawing.Point(9, 301);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(87, 13);
            this.lblHome.TabIndex = 11;
            this.lblHome.TabStop = true;
            this.lblHome.Text = "Samuel &Prashker";
            this.lblHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHome_LinkClicked);
            // 
            // saveBox
            // 
            this.saveBox.Controls.Add(this.txtSaveFolder);
            this.saveBox.Controls.Add(this.btnSaveFolder);
            this.saveBox.Location = new System.Drawing.Point(12, 211);
            this.saveBox.Name = "saveBox";
            this.saveBox.Size = new System.Drawing.Size(358, 51);
            this.saveBox.TabIndex = 11;
            this.saveBox.TabStop = false;
            this.saveBox.Text = "Save";
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Enabled = false;
            this.txtSaveFolder.Location = new System.Drawing.Point(88, 22);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(264, 20);
            this.txtSaveFolder.TabIndex = 1;
            // 
            // btnSaveFolder
            // 
            this.btnSaveFolder.Location = new System.Drawing.Point(7, 20);
            this.btnSaveFolder.Name = "btnSaveFolder";
            this.btnSaveFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFolder.TabIndex = 0;
            this.btnSaveFolder.Text = "Save &Folder";
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            this.btnSaveFolder.Click += new System.EventHandler(this.btnSaveFolder_Click);
            // 
            // chkMinimize
            // 
            this.chkMinimize.AutoSize = true;
            this.chkMinimize.Location = new System.Drawing.Point(12, 268);
            this.chkMinimize.Name = "chkMinimize";
            this.chkMinimize.Size = new System.Drawing.Size(122, 17);
            this.chkMinimize.TabIndex = 12;
            this.chkMinimize.Text = "Auto minimize to tray";
            this.chkMinimize.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgress.Location = new System.Drawing.Point(322, 281);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "Progress";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Huh?";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // barProgress
            // 
            this.barProgress.Location = new System.Drawing.Point(229, 297);
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(141, 23);
            this.barProgress.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 329);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.barProgress);
            this.Controls.Add(this.chkMinimize);
            this.Controls.Add(this.saveBox);
            this.Controls.Add(this.lblHome);
            this.Controls.Add(this.repeatBox);
            this.Controls.Add(this.clickBox);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.regionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Click Grab Repeat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.regionBox.ResumeLayout(false);
            this.clickBox.ResumeLayout(false);
            this.clickBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaitTime)).EndInit();
            this.repeatBox.ResumeLayout(false);
            this.repeatBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatTimes)).EndInit();
            this.saveBox.ResumeLayout(false);
            this.saveBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGrabRegion;
        private System.Windows.Forms.GroupBox regionBox;
        private System.Windows.Forms.Label grabVerbose;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox clickBox;
        private System.Windows.Forms.GroupBox repeatBox;
        private System.Windows.Forms.LinkLabel lblHome;
        private System.Windows.Forms.Label clickVerbose;
        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.GroupBox saveBox;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.Button btnSaveFolder;
        private System.Windows.Forms.CheckBox chkMinimize;
        private System.Windows.Forms.RadioButton rdbSetNumber;
        private System.Windows.Forms.RadioButton rdbIndefinite;
        private System.Windows.Forms.NumericUpDown nudRepeatTimes;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudWaitTime;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ProgressBar barProgress;
    }
}

