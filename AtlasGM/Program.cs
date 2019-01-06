using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms; 


namespace AtlasGM
{
   public static class Program
    {
        public static IntPtr handle; 
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // get the name of our process
            // string p = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

          




                string p = "AtlasGame";
            // get the list of all processes by that name
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(p);
            // if there is more than one process
            if (processes.Length > 0)
            {
                handle = processes[0].MainWindowHandle;
                //SwitchToThisWindow(handle, true);    // 激活，显示在最
                Application.Run(new Form1()); 
            }
            else
            {
                MessageBox.Show("请先运行程序", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                
            }
          
        }
    }
}
