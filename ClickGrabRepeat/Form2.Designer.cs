﻿namespace ClickGrabRepeat
{
    partial class SnippingTool
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
            this.SuspendLayout();
            // 
            // SnippingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "SnippingTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SnippingTool_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SnippingTool_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SnippingTool_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SnippingTool_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}