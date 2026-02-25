using Sunny.UI;
using System.Globalization;

namespace Group1project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Sunny.UI.UIStyles.CultureInfo = Sunny.UI.CultureInfos.en_US;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Frmlogin());
        }
    }
}