using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Media.Animation;
using ScreenShot1Lib;
using ScreenShot2Lib;
using System.IO;

namespace JTool_Frame
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>

    public partial class MainWindow : Window, IDataModel
    {


        //托盘
        public NotifyIcon notifyIcon { get; set; }

        //截图参数
        private readonly ScreenShot2Lib.ScreenCaputre screenCaputre = new ScreenShot2Lib.ScreenCaputre();
        private System.Windows.Size? lastSize;
        
        //对话防打扰
        static public Boolean IsSpeaking;

        //皮肤编号
        static public int num;


        public MainWindow()
        {
            InitializeComponent();
            /////截图设置
            screenCaputre.ScreenCaputred += OnScreenCaputred;
            screenCaputre.ScreenCaputreCancelled += OnScreenCaputreCancelled;
            ////截图设置结束
            
            ////皮肤初始化
            Uri JT_Skin = new Uri("/img/B03.png", UriKind.Relative); 
           Skin.Source = new BitmapImage(JT_Skin);
            //////防打扰对话设置
            IsSpeaking = true;

            //////托盘化设置//////
            this.ShowInTaskbar = false;
            this.Visibility = Visibility.Visible;
            IconShow();

            DataModel.Instance.IDataModel = this;
            DataModel.Instance.MainWindow = this;
        }
        /// <summary>
        /// 皮肤更换
        /// </summary>
        private void JTchangeSkin()
        {
            
            try
            {
                switch (num)
                {
                    case 2: Skin.Source = new BitmapImage(new Uri("/img/B02.png", UriKind.Relative)); break;
                    case 3: Skin.Source = new BitmapImage(new Uri("/img/B03.png", UriKind.Relative)); break;
                    default: break;
                }

            }
            catch
            {

            }
           

        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            QPan_OpenFromTuoPan();
            if (this.WindowState == WindowState.Normal)
            {
                this.Visibility = Visibility.Visible;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Hidden;
            }
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                QPan_MiniMizedToTuoPan();
            }

        }
        public void QPan_MiniMizedToTuoPan()
        {
            this.WindowState = WindowState.Minimized;
            this.notifyIcon.Visible = true;
            this.notifyIcon.ShowBalloonTip(500);
        }
        public void QPan_OpenFromTuoPan()
        {
            this.WindowState = WindowState.Normal;
            this.notifyIcon.Visible = false;
        }
        public void IconShow()
        {
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.BalloonTipText = "Hello, I am the JTool!";
            this.notifyIcon.Text = "防打扰模式";
            this.notifyIcon.Icon = new System.Drawing.Icon("AIM54.ico");
            this.notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;
            this.notifyIcon.ShowBalloonTip(500);
        }
        /////托盘设置结束/////

        //左键拖动
        private void BackGround_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //this.DragMove();              
                this.DragMove();
            }
        }

        ///////菜单///////
        //菜单-退出
        private void JTExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //菜单-设置
        private void JTSetting_Click(object sender, RoutedEventArgs e)
        {
            Setting JTSet = new Setting();
            JTSet.ChangeSkinEvent += new ChangeSkinHandler(JTchangeSkin);
            JTSet.ShowDialog();
        }
        //菜单-截图1-连续多张截图
        private void JTScreen1_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Thread.Sleep(300);
            screenCaputre.StartCaputre(30, lastSize);
        }

        //菜单-截图2-网页截图
        private void JTScreen2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            // System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }
        //菜单-关于
        private void JTAbout_Click(object sender, RoutedEventArgs e)
        {
            About JTAbt = new About();
            JTAbt.Show();
        }
        //菜单-防打扰
        private void JTMini_Click(object sender, RoutedEventArgs e)
        {
            QPan_MiniMizedToTuoPan();
        }
        //菜单-互动
        private void JTInter_Click(object sender, RoutedEventArgs e)
        {
            InteractionInput JTInt = new InteractionInput();
            JTInt.Show();
        }
        //菜单-取色
        private void JTColorPicker_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker JTCol = new ColorPicker();
            JTCol.Show();
        }
        //菜单-关于
        ///////菜单结束///////

        ///////截图2-普通截图////////
        private void Button_JT1_Click(object sender, RoutedEventArgs e)
        {
           
            Hide();
          Thread.Sleep(300);
            screenCaputre.StartCaputre(30, lastSize);
        }
        private void OnScreenCaputreCancelled(object sender, System.EventArgs e)
        {
            Show();
            Focus();
        }

        private void OnScreenCaputred(object sender, ScreenShot2Lib.ScreenCaputredEventArgs e)
        {
            //set last size
            lastSize = new System.Windows.Size(e.Bmp.Width, e.Bmp.Height);


            Show();

            //test
            var bmp = e.Bmp;
            //var win = new Img { SizeToContent = SizeToContent.WidthAndHeight, ResizeMode = ResizeMode.NoResize };
            Img win = new Img { SizeToContent = SizeToContent.WidthAndHeight, ResizeMode = ResizeMode.NoResize };
            var canvas = new Canvas { Width = bmp.Width, Height = bmp.Height, Background = new ImageBrush(bmp) };

            win.Content = canvas;
   
            win.Show();
            //
            //string file="pic01";
            //ImageSave(canvas,file);

            var cdlg = new Microsoft.Win32.SaveFileDialog();
            cdlg.Filter = "*.jpg;*.bmp|*.jpg;*.bmp|*.png|*.png";
            
            cdlg.Title = "保存";
            cdlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (cdlg.ShowDialog(this) == true)
            {
                System.Windows.MessageBox.Show(cdlg.FileName);

            }
            SaveToImage(canvas,cdlg.FileName);
        }
        ///////图片保存////////
        private void ImageSave(Canvas Canvas, string _imageFile)
        {
            double width = Canvas.ActualWidth;
            double height = Canvas.ActualHeight;
            RenderTargetBitmap bmpCopied = new RenderTargetBitmap((int)Math.Round(width), (int)Math.Round(height), 96, 96, PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(Canvas);
                dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), new System.Windows.Size(width, height)));
            }
            bmpCopied.Render(dv);
            using (FileStream file = new FileStream(_imageFile, FileMode.Create, FileAccess.Write))
            {

                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmpCopied));
                encoder.Save(file);
            }
        }

        private void SaveToImage(FrameworkElement ui, string fileName)
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)ui.Width, (int)ui.Height, 96d, 96d,
                PixelFormats.Pbgra32);
                bmp.Render(ui);
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(fs);
                fs.Close();
            }
            catch {
                
            }

        }
 

        //////图片保存结束

        ///////截图1-网页截图////////
        private void Button_JT2_Click(object sender, RoutedEventArgs e) {

            System.Windows.Forms.Application.EnableVisualStyles();
         //   System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }


        ///////截图结束////////

        //取色

        private void Button_ColorPicker_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker JTCol = new ColorPicker();
            JTCol.Show();
        }

        //////////MouseMove事件

        /*
        private void Button_JT1_MouseMove(object sender, RoutedEventArgs e)
        {
            if (IsSpeaking == true) {
                ((MainWindow)DataModel.Instance.MainWindow).FadeIn("这里是还在施工中的普通截图");
                ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
            }

        }
        private void Button_JT2_MouseMove(object sender, RoutedEventArgs e)
        {
            if (IsSpeaking == true) {
                ((MainWindow)DataModel.Instance.MainWindow).FadeIn("这里是网页截图");
                ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
            }

        }

        private void Button_ColorPicker_MouseMove(object sender, RoutedEventArgs e)
        {
            if (IsSpeaking == true) { 
             ((MainWindow)DataModel.Instance.MainWindow).FadeIn("吸吸吸，吸走鱼尾纹");
            ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
            }
           
        }
         */
         

        private void Grid_MouseMove(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int feed = rand.Next(100);
            if (IsSpeaking == true) 
            {
                switch (feed)
                {
                    case (1): ((MainWindow)DataModel.Instance.MainWindow).FadeIn("今天是星期天，明天交作业");
                        ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(1500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                        break;
                    case (2): ((MainWindow)DataModel.Instance.MainWindow).FadeIn("Are you OK?");
                        ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(1500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                        break;
                    case (3): ((MainWindow)DataModel.Instance.MainWindow).FadeIn("左眼截图，右眼网页截图，并不是左眼跳财右眼跳灾");
                        ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(2500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                        break;
                    case (4): ((MainWindow)DataModel.Instance.MainWindow).FadeIn("我什么都不知道，是不是很蠢？");
                        ThreadPool.QueueUserWorkItem(new WaitCallback((p) => { Thread.Sleep(1500); ((MainWindow)DataModel.Instance.MainWindow).FadeOut(); }));
                        break;
                    case (5): break;
                    default: break;

                }
            
            }
           

        }

        ////////////特效////////////
        /// <summary>
        /// 淡入
        /// </summary>
        public void FadeIn(string txt)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                txtPoo.Text = txt;
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;    //起始值
                da.To = 1;      //结束值
                da.Duration = TimeSpan.FromSeconds(1);         //动画持续时间
                this.poo.BeginAnimation(System.Windows.Shapes.Path.OpacityProperty, da);//开始动画
            }));

        }

        /// <summary>
        /// 淡出
        /// </summary>
        public void FadeOut()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
              {
                  DoubleAnimation da = new DoubleAnimation();
                  da.From = 1;    //起始值
                  da.To = 0;      //结束值
                  da.Duration = TimeSpan.FromSeconds(1);         //动画持续时间
                  this.poo.BeginAnimation(System.Windows.Shapes.Path.OpacityProperty, da);//开始动画
              }));
        }






    }
}
