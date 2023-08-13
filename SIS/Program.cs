using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SIS.UI;
namespace SIS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Login fLogin = new Login();

            Application.Run(fLogin);

            if (fLogin.loginSuccessfully)
            {
                MainPage Mpage = new MainPage(fLogin.loginUser);
                Application.Run(Mpage);
                
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
