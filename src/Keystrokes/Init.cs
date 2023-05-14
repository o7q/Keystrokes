using System;
using System.Windows.Forms;

namespace Keystrokes
{
    internal static class Init
    {
        [STAThread]
        static void Main()
        {
            // start main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}