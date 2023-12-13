using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Loginform loginform = new Loginform();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                Form1 form1 = new Form1();
                form1.Role = loginform.Role;
                if (form1.Role == 2 || form1.Role == -1)
                {
                    form1.btnManage.Visible = false;
                    form1.btnReport.Visible = false;
                }
                Application.Run(form1);
            }
        }
    }
}
