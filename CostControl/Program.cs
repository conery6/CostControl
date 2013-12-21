using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CostControl
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Login());
            //Application.Run(new RawMaterial.RMData("a"));
            //Application.Run(new RawMaterial.RMTable("a"));
            //Application.Run(new BaseManage .EmployeeManage() );
            //Application.Run(new Maintain.MData());
            //Application.Run(new Frm_main("a"));
            Application.Run(new Electric.Frm_EData());
        }
    }
}
