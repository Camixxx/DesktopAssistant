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
using System.Threading;
using System.Diagnostics;

namespace JTool_Frame
{
    /// <summary>
    /// InteractionInput.xaml 的交互逻辑
    /// </summary>
    public partial class InteractionInput : MetroWindow
    {
        public InteractionInput()
        {
            InitializeComponent();
            ((MainWindow)DataModel.Instance.MainWindow).FadeIn("你好 主人 我可以帮助你！！");
            ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            switch (txtSearch.Text)
            {
                case "设置":
                    new Setting().Show();
                    break;
                case "拼接截图":
                    Hide();
                    Thread.Sleep(300);
                    new ScreenShot2Lib.ScreenCaputre().StartCaputre(30, null);
                    break;
                case "屏幕取色":
                    new ColorPicker().Show();
                    break;
                case "吸色":
                    new ColorPicker().Show();
                    break;
                case "免打扰":
                    QPan_MiniMizedToTuoPan();
                    break;
                case "关于":
                    new About().Show();
                    break;
                case "退出":
                    System.Environment.Exit(0);
                    break;
                case "再见":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("主人  拜拜！！");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); System.Environment.Exit(0); }));
                    break;
                case "截图失败":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("sorry，主人，截图失败啦，再试一次吧");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
                case "无法保存图片":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("UFO带走了图片，重新截图再试试看");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
                case "无法点击按钮":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("按钮好像过期了，嗯，让我重启一下");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
                case "吸色失败":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("额，换个地方看看！！");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
                case "你好":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("Y0Hellow！这句话很流行。");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
                case "你是谁":
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("你猜我是谁？你猜我猜不猜你猜。");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
                case "icon": openIE(); break;
                default:
                    ((MainWindow)DataModel.Instance.MainWindow).FadeIn("sorry，没有找到该信息哦！！");
                    ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                    break;
            }
        }

        public void QPan_MiniMizedToTuoPan()
        {
            this.WindowState = WindowState.Minimized;
            DataModel.Instance.MainWindow.WindowState = WindowState.Minimized;
            DataModel.Instance.IDataModel.notifyIcon.Visible = true;
            DataModel.Instance.IDataModel.notifyIcon.ShowBalloonTip(500);
        }

        private void MetroWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnEnter_Click(this, e);
        }
        private void openIE()
        {
            Process process = new Process();
            process.StartInfo.FileName = "iexplore.exe";
            process.StartInfo.Verb = "open";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.StartInfo.Arguments = @"www.easyicon.net/";
            process.Start();
        }
    }
}
