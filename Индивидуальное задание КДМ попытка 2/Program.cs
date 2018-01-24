using System;
using System.Windows.Forms;

namespace Индивидуальное_задание_КДМ_попытка_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ( )
        {
            Application.EnableVisualStyles ( );
            Application.SetCompatibleTextRenderingDefault ( defaultValue: false );
            Application.Run ( mainForm: new Form1 ( ) );
        }
    }
}
