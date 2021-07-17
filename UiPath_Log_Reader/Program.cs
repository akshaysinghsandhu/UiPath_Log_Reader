using System;
using System.Windows.Forms;

namespace LogReader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (arg.Length == 0) { Application.Run(new LogReader()); } else { Application.Run(new LogReader(arg[0])); }

        }
    }
}
