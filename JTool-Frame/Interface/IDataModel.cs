using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace JTool_Frame
{
    public interface IDataModel
    {


        /// <summary>
        /// 托盘
        /// </summary>
        NotifyIcon notifyIcon { get; set; }
    }
}
