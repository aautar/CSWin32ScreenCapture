using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ScreenCapture
{
    class GDI32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            byte BlendOp;
            byte BlendFlags;
            byte SourceConstantAlpha;
            byte AlphaFormat;

            public BLENDFUNCTION(byte alpha)
            {
                BlendOp = 0;
                BlendFlags = 0;
                SourceConstantAlpha = alpha;
                AlphaFormat = 1;
            }
        }

        //
        // currently defined blend operation
        //
        const int AC_SRC_OVER = 0x00;

        //
        // currently defined alpha format
        //
        const int AC_SRC_ALPHA = 0x01;

        [DllImport("GDI32.dll")]
        public static extern bool BitBlt(int hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, int hdcSrc, int nXSrc, int nYSrc, int dwRop);
        [DllImport("GDI32.dll", EntryPoint="GdiAlphaBlend")]
        public static extern int AlphaBlend(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION bf);
        [DllImport("GDI32.dll")]
        public static extern int CreateCompatibleBitmap(int hdc, int nWidth, int nHeight);
        [DllImport("GDI32.dll")]
        public static extern int CreateCompatibleDC(int hdc);
        [DllImport("GDI32.dll")]
        public static extern bool DeleteDC(int hdc);
        [DllImport("GDI32.dll")]
        public static extern bool DeleteObject(int hObject);
        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps(int hdc, int nIndex);
        [DllImport("GDI32.dll")]
        public static extern int SelectObject(int hdc, int hgdiobj);
    }

    class User32
    {
        [DllImport("User32.dll")]
        public static extern int GetDesktopWindow();
        [DllImport("User32.dll")]
        public static extern int GetWindowDC(int hWnd);
        [DllImport("User32.dll")]
        public static extern int ReleaseDC(int hWnd, int hDC);
    }

    class ScreenCapture
    {
        public Bitmap CaptureScreen(int x, int y, int width, int height)
        {
            int hdcSrc = User32.GetWindowDC(User32.GetDesktopWindow()),
            hdcDest = GDI32.CreateCompatibleDC(hdcSrc),
            hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc,width, height); 
            GDI32.SelectObject(hdcDest, hBitmap);
            GDI32.BitBlt(hdcDest, 0, 0, width/*GDI32.GetDeviceCaps(hdcSrc, 8)*/, height/*GDI32.GetDeviceCaps(hdcSrc, 10)*/, 
                         hdcSrc, x, y, 0x00CC0020);

            Bitmap image =
                new Bitmap(Image.FromHbitmap(new IntPtr(hBitmap)),
                Image.FromHbitmap(new IntPtr(hBitmap)).Width,
                Image.FromHbitmap(new IntPtr(hBitmap)).Height);
            
            Cleanup(hBitmap, hdcSrc, hdcDest);

            return image;
        }

        private void Cleanup(int hBitmap, int hdcSrc, int hdcDest)
        {
            User32.ReleaseDC(User32.GetDesktopWindow(), hdcSrc);
            GDI32.DeleteDC(hdcDest);
            GDI32.DeleteObject(hBitmap);
        }
        private void SaveImageAs(int hBitmap, string fileName, ImageFormat imageFormat)
        {
            Bitmap image =
            new Bitmap(Image.FromHbitmap(new IntPtr(hBitmap)),
            Image.FromHbitmap(new IntPtr(hBitmap)).Width,
            Image.FromHbitmap(new IntPtr(hBitmap)).Height);
            image.Save(fileName, imageFormat);
        }
    }
}
