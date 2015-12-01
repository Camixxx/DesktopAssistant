using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ScreenShot2Lib;
namespace JTool_Frame
{
    /// <summary>
    /// NormalFeedBack.xaml 的交互逻辑
    /// </summary>
    public partial class NormalFeedBack : Window
    {
        private readonly ScreenShot2Lib.ScreenCaputre screenCaputre = new ScreenShot2Lib.ScreenCaputre();
        private Size? lastSize;

        public NormalFeedBack()
        {
            InitializeComponent();

            screenCaputre.ScreenCaputred += OnScreenCaputred;
            screenCaputre.ScreenCaputreCancelled += OnScreenCaputreCancelled;
        }

        private void OnScreenCaputreCancelled(object sender, System.EventArgs e)
        {
            Show();
            Focus();
        }

        private void OnScreenCaputred(object sender, ScreenShot2Lib.ScreenCaputredEventArgs e)
        {
            //set last size
            lastSize = new Size(e.Bmp.Width, e.Bmp.Height);


            Show();

            //test
            var bmp = e.Bmp;
            var win = new Window {SizeToContent = SizeToContent.WidthAndHeight, ResizeMode= ResizeMode.NoResize};

            var canvas = new Canvas {Width = bmp.Width, Height = bmp.Height, Background = new ImageBrush(bmp)};

            win.Content = canvas;
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Thread.Sleep(300);
            screenCaputre.StartCaputre(30, lastSize);
        }
    }
}
