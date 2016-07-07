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
    public partial class Form1 : Form
    {
        private ScreenCapture sc = new ScreenCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void capTimer_Tick(object sender, EventArgs e)
        {
            Point screenPt = this.PointToScreen(pictureBox1.Location);
            Bitmap back = sc.CaptureScreen(0, 0, 800, 600);

            IntPtr hdcTarget = this.CreateGraphics().GetHdc();

            IntPtr bmpDest = back.GetHbitmap();
            IntPtr hdcDest = (IntPtr)GDI32.CreateCompatibleDC((int)hdcTarget);
            GDI32.SelectObject((int)hdcDest, (int)bmpDest);

            pictureBox1.Image = Bitmap.FromHbitmap(bmpDest);

            GDI32.DeleteDC((int)hdcDest);
        }

    }
}