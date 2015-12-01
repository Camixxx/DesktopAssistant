using System;
using System.Windows.Media.Imaging;

namespace ScreenShot2Lib
{
    public class ScreenCaputredEventArgs : EventArgs
    {
        public BitmapSource Bmp
        {
            get;
            private set;
        }

        public ScreenCaputredEventArgs(BitmapSource bmp)
        {
            Bmp = bmp;
        }
    }
}
