using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace JTool_Frame
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    //定义委托
    public delegate void ChangeSkinHandler();

    public partial class Setting : MetroWindow
    {
        static bool NoDisturbing = false;
        bool IsComboxChanged = false;
        public event ChangeSkinHandler ChangeSkinEvent;
        static public int skinNumber;

        public Setting()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NoDisturbing = true;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            NoDisturbing = false;
        }

         void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (NoDisturbing == true)
            {
                MainWindow.IsSpeaking = false;
            }
            else
            {
                MainWindow.IsSpeaking = true;
            }

            if (IsComboxChanged)
            {
                StrikeEvent();
                //MainWindow.changeSkin(skinNumber);
            }

            this.Close();
        }
        
        private void StrikeEvent()
        {
            try
            {
                if (ChangeSkinEvent != null)
                {
                    ChangeSkinEvent();
                    MainWindow.num = skinNumber;
                }
            }
            catch { }
        }
       
        private void SettingQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lanse_Selected(object sender, RoutedEventArgs e)
        {
            skinNumber = 2;
        }

        private void xiaohei_Selected(object sender, RoutedEventArgs e)
        {
            skinNumber = 3;
        }

        private void Skin_Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsComboxChanged = true;
        }
    }
}
