using Model;
using System;
using System.Windows.Forms;

namespace BattleGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new FrmField());
            }
            catch (Exception ex)
            {
                Logger logger = Logger.GetInstance();
                logger.Write(ex.ToString());
                MessageBox.Show(ex.Message, "ÉGÉâÅ[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
