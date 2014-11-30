using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShellForPlink
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "background")
                {

                }
                else
                {
                    StartForm();
                }

            }
            else
            {
                StartForm();
            }
            
        }
        static void StartForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
