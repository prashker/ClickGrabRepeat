using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClickGrabRepeat
{
    public partial class Form1 : Form
    {
        CGRWorker cgr;


        // Is this how we do this in C#?
        private Thread cgrThread;
        public delegate void updateUIDelegate(CGRWorker e);
        public updateUIDelegate ui;

        public Form1()
        {
            InitializeComponent();

            cgr = new CGRWorker();
            ui = new updateUIDelegate(updateUI);

            cgr.repeat = CGRWorker.RepeatType.Indefinite;
            rdbIndefinite.Checked = true;
            rdbSetNumber_CheckedChanged(null, null);

            startCheck();
        }

        public void updateUI(CGRWorker e)
        {
            // We have finished gracefully
            if (e.running)
            {
                // Update Progress Indicator
                lblProgress.Text = "" + e.getProgress();

                // Show maximum if Fixed
                if (e.repeat == CGRWorker.RepeatType.Fixed)
                {
                    lblProgress.Text = lblProgress.Text + "/" + e.repeatTimes;

                    // Get a percentage value
                    // http://stackoverflow.com/questions/2124283/whats-the-best-way-to-create-a-percentage-value-from-two-integers-in-c
                    barProgress.Value = (100 * e.getProgress()) / e.repeatTimes;
                }

            }
            else
            {
                lblProgress.Text = "Finished!";
                barProgress.Value = 100;
            }

            startCheck();
        }

        private void startCheck()
        {
            // Check if Start is ready to be pressed
            btnStart.Enabled = (cgr.click != null &&
                                cgr.grab != null &&
                                cgr.saveFolder != null &&
                                cgr.saveFolder.Length != 0 &&
                                !cgr.running);
        }


        // Click
        private void btnClick_Click(object sender, EventArgs e)
        {
            cgr.click = SnippingTool.Point();
            clickVerbose.Text = String.Format("X: {0}, Y: {1}",
                                              cgr.click.X,
                                              cgr.click.Y);

            startCheck();
        }

        // Grab
        private void btnGrabRegion_Click(object sender, EventArgs e)
        {
            cgr.grab = SnippingTool.Snip();
            grabVerbose.Text = String.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}",
                                        cgr.grab.X,
                                        cgr.grab.Y,
                                        cgr.grab.Width,
                                        cgr.grab.Height);

            startCheck();
        }

        // Repeat

        // Save
        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            FolderSelect.FolderSelectDialog dlgSaveFolder = new FolderSelect.FolderSelectDialog();
            dlgSaveFolder.ShowDialog();

            // Model + UI Update
            cgr.saveFolder = dlgSaveFolder.FileName;
            txtSaveFolder.Text = dlgSaveFolder.FileName;

            startCheck();
        }

        // Start & Stop Button Handling
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!cgr.running) {
                startWorker();
            }
        }

        // Start the worker
        public void startWorker()
        {
            cgr.progressUpdate += W_progressUpdate;
            cgrThread = new Thread(cgr.clickGrabRepeat);
            cgrThread.Start();

            if (chkMinimize.Checked)
                minimizeToTray();

            startCheck();
        }

        // Abrupt Stop / Indefinite Stop of Worker
        // Should this stop gracefully?
        public void stopWorker()
        {
            cgr.progressUpdate -= W_progressUpdate;

            // Stop if needed
            if (cgrThread != null && cgrThread.IsAlive)
                cgrThread.Abort();

            startCheck();
        }

        public void toggleConfigControls()
        {
            clickBox.Enabled = !clickBox.Enabled;
            regionBox.Enabled = !regionBox.Enabled;
            repeatBox.Enabled = !repeatBox.Enabled;
            chkMinimize.Enabled = !chkMinimize.Enabled;
        }

        // Handle events posted from Thread to UI Thread
        private void W_progressUpdate(object sender, EventArgs e)
        {
            this.Invoke(ui, (CGRWorker)sender);
        }

        // Website
        private void lblHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://prashker.net");
        }

        private void rdbIndefinite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIndefinite.Checked == true)
                cgr.repeat = CGRWorker.RepeatType.Indefinite;
        }

        private void rdbSetNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSetNumber.Checked == true)
            {
                cgr.repeat = CGRWorker.RepeatType.Fixed;
                nudRepeatTimes.Enabled = true;
                lblTimes.Enabled = true;
            }
            else
            {
                nudRepeatTimes.Enabled = false;
                lblTimes.Enabled = false;
            }
        }

        private void nudRepeatTimes_ValueChanged(object sender, EventArgs e)
        {
            cgr.repeatTimes = (int) nudRepeatTimes.Value;
        }

        private void nudWaitTime_ValueChanged(object sender, EventArgs e)
        {
            // Convert to milliseconds
            // Multiply by 1000
            cgr.waitMS = (int)(nudWaitTime.Value * 1000);
        }

        // Ensure thread is closed
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Is this right?
            // If I don't do this then InvalidOperationException 
            // when thread is running and Form1 is cloded
            if (cgrThread != null && cgrThread.IsAlive)
                cgrThread.Abort();
        }

        private void minimizeToTray()
        {
            this.Hide();
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000, "Click Grab Repeat", "Running in systray", ToolTipIcon.Info);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false;
            this.Show();
        }
    }
}
