using System;
using System.Windows.Forms;

namespace DbApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var headerProxy = new DbHeaderProxy();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(headerProxy));
        }
    }
}
