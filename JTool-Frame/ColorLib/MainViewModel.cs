using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace JTool_Frame.ColorLib
{
    public class MainViewModel : BaseModel
    {
        private string r;

        public string R
        {
            get { return r; }
            set
            {
                if (value != r)
                {
                    r = value;
                    NotifyPropertyChanged("R");
                }
            }
        }

        private string g;

        public string G
        {
            get { return g; }
            set
            {
                if (value != g)
                {
                    g = value;
                    NotifyPropertyChanged("G");
                }
            }
        }

        private string b;

        public string B
        {
            get { return b; }
            set
            {
                if (value != b)
                {
                    b = value;
                    NotifyPropertyChanged("B");
                }
            }
        }

        private string hexColor;

        public string HexColor
        {
            get { return hexColor; }
            set
            {
                if (value != hexColor)
                {
                    hexColor = value;
                    NotifyPropertyChanged("HexColor");
                }
            }
        }

        private SolidColorBrush backSampleColor;

        public SolidColorBrush BackSampleColor
        {
            get { return backSampleColor; }
            set
            {
                if (value != backSampleColor)
                {
                    backSampleColor = value;
                    NotifyPropertyChanged("BackSampleColor");
                }
            }
        }
    }
}
