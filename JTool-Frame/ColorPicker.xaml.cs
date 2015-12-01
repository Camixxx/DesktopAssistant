using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using JTool_Frame.ColorLib;
using MahApps.Metro.Controls;
namespace JTool_Frame
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker :MetroWindow
    {
        DispatcherTimer timer;
        MainViewModel viewModel;

        public ColorPicker()
        {
            InitializeComponent();

            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);

            viewModel = this.Resources["vm"] as MainViewModel;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            System.Drawing.Point point = System.Windows.Forms.Cursor.Position;
            System.Drawing.Color color = ColorPickerManager.GetColor(point.X, point.Y);

            System.Windows.Media.Color colorWPF = new Color();
            colorWPF.A = 255;
            colorWPF.R = color.R;
            colorWPF.G = color.G;
            colorWPF.B = color.B;

            viewModel.R = color.R.ToString();
            viewModel.B = color.B.ToString();
            viewModel.G = color.G.ToString();

            viewModel.HexColor = "0x" + color.ToArgb().ToString("X");
            viewModel.BackSampleColor = new SolidColorBrush(colorWPF);
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

        private void grdHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
