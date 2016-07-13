using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class CaptureWindow : Form
    {
        private PreviewWindow previewWindow = null;
        private ScreenCapture sc = new ScreenCapture();

        public CaptureWindow()
        {
            InitializeComponent();

            previewWindow = new PreviewWindow();
            previewWindow.Width = this.Width;
            previewWindow.Height = this.Height;
            previewWindow.Show();
        }

        private void capTimer_Tick(object sender, EventArgs e)
        {
            Point screenPt = captureFrame.PointToScreen(new Point(0, 0));

            Bitmap back = sc.CaptureScreen(screenPt.X, screenPt.Y, captureFrame.Width, captureFrame.Height);
            
            previewWindow.BackgroundImage = back;

            //GDI32.DeleteDC((int)hdcDest);
        }

    }
}