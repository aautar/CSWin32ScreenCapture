namespace ScreenCapture
{
    partial class CaptureWindow
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
            this.capTimer = new System.Windows.Forms.Timer(this.components);
            this.captureFrame = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // capTimer
            // 
            this.capTimer.Enabled = true;
            this.capTimer.Interval = 150;
            this.capTimer.Tick += new System.EventHandler(this.capTimer_Tick);
            // 
            // captureFrame
            // 
            this.captureFrame.BackColor = System.Drawing.Color.Transparent;
            this.captureFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captureFrame.Location = new System.Drawing.Point(0, 0);
            this.captureFrame.Name = "captureFrame";
            this.captureFrame.Size = new System.Drawing.Size(745, 452);
            this.captureFrame.TabIndex = 0;
            // 
            // CaptureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(745, 452);
            this.Controls.Add(this.captureFrame);
            this.DoubleBuffered = true;
            this.Name = "CaptureWindow";
            this.Text = "Capture Window";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer capTimer;
        private System.Windows.Forms.Panel captureFrame;
    }
}

