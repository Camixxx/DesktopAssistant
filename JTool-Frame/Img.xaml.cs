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
using System.Windows.Markup;
using System.IO;
namespace JTool_Frame
{
    /// <summary>
    /// Img.xaml 的交互逻辑
    /// </summary>

    public partial class Img : MetroWindow
    {

        public Img()
        {
            InitializeComponent();
           
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /// ExportToPng(path_u, a);
        }

        
           private void path_url_TextChanged(object sender, TextChangedEventArgs e)
           {

           }
   
    }
}
