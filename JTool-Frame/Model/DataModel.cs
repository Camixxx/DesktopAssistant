using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTool_Frame
{
    public class DataModel
    {
        private static DataModel instance = new DataModel();
        public static DataModel Instance { get { return instance; } set { instance = value; } }

        public Window MainWindow { get; set; }

        public IDataModel IDataModel { get; set; }
    }
}
