using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;

namespace ITNepal.Addon
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //Application.SBO_Application.StatusBar.SetSystemMessage("Connecting to the Add-on", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                Application oApp = null;
                if (args.Length < 1)
                    oApp = new Application();
                else
                    oApp = new Application(args[0]);

                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();
               //AddonInfoInfo.InstallUDOs();
                AddonInfoInfo.GetCommonSettings();
                var applicationHandler = new ApplicationHandlers();
                Application.SBO_Application.StatusBar.SetSystemMessage("ITNepal.Addon Add-on installed successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                oApp.Run();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
