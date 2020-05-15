using ITNepal.MainLibrary.SAPB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNepal.Addon.Helpers
{
    public class Menu
    {
        public void AddMenuItems()
        {
            B1Helper.AddSubMenu(MenuID_UD.MODULE, MenuID_UD.ReportMID, MenuID_UD.Report, -1, string.Concat(System.Windows.Forms.Application.StartupPath, @"\Images\Icon.png"));

            B1Helper.addSubMenu(MenuID_UD.ReportMID, MenuID_UD.StockAgeingMID, MenuID_UD.StockAgeing, 1);
            B1Helper.addMenuItem(MenuID_UD.ReportMID, MenuID_UD.ServiceEarningDataMID, MenuID_UD.ServiceEarningData);
            B1Helper.addMenuItem(MenuID_UD.ReportMID, MenuID_UD.ServiceEarningDataDistributorsMID, MenuID_UD.ServiceEarningDataDistributors);
            B1Helper.addMenuItem(MenuID_UD.ReportMID, MenuID_UD.ServiceCallPendingForInvociesMID, MenuID_UD.ServiceCallPendingForInvocies);
            //B1Helper.addMenuItem(MenuID_UD.SERVICEMODULEMASTERS, MenuID_UD.MACHINEPRICINGMASTER, MenuID_UD.MACHINEPRICINGMASTER);
            B1Helper.addMenuItem(MenuID_UD.ReportMID, MenuID_UD.AdministrativeDataFieldServiceCallMID, MenuID_UD.AdministrativeDataFieldServiceCall);
            
        }
    }
}
