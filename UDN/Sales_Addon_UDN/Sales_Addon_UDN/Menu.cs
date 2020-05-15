using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    class Menu
    {
        public void AddMenuItems()
        {
            SAPbouiCOM.Menus oMenus = null;
            SAPbouiCOM.MenuItem oMenuItem = null;

            oMenus = Application.SBO_Application.Menus;

            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
            //oMenuItem = Application.SBO_Application.Menus.Item("43535"); // moudles'

            //oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
            //oCreationPackage.UniqueID = "Sales_Addon_UDN";
            //oCreationPackage.String = "Sales_Addon_UDN";
            //oCreationPackage.Enabled = true;
            //oCreationPackage.Position = -1;


            //oMenus = oMenuItem.SubMenus;

            //try
            //{
            //    //  If the manu already exists this code will fail
            //    oMenus.AddEx(oCreationPackage);
            //}
            //catch (Exception e)
            //{

            //}
            try
            {
                oMenuItem = Application.SBO_Application.Menus.Item("43535");
                oMenus = oMenuItem.SubMenus;

                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.Payment";
                oCreationPackage.String = "Payment Setup";
                oCreationPackage.Position = 6;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch 
                {
                }
            
                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.CreditLimit.b1f";
                oCreationPackage.String = "Credit Limit Setup";
                oCreationPackage.Position = 7;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch 
                {
                }
            }
            catch
            {
            }
            try
            {
                oMenuItem = Application.SBO_Application.Menus.Item("3072");
                oMenus = oMenuItem.SubMenus;
                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.BillNTrade.b1f";
                oCreationPackage.String = "Bill and Trade Discount Setup";
                oCreationPackage.Position = 9;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch
                {
                }
            
                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.PromotionSetUp.b1f";
                oCreationPackage.String = "Promotion Setup";
                oCreationPackage.Position = 10;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch
                {
                }
                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.PickListReport.b1f";
                oCreationPackage.String = "Picklist Report";
                oCreationPackage.Position = 11;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch
                {
                }
            }
            catch
            {
            }

            try
            {

                oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
                oCreationPackage.UniqueID = "Gatepass";
                oCreationPackage.String = "Gatepass";
                oCreationPackage.Enabled = true;
                oCreationPackage.Position = -1;
                oMenus = oMenuItem.SubMenus;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch (Exception e)
                {
                }
                try
                {


                    oMenus = oMenuItem.SubMenus;

                    // Get the menu collection of the newly added pop-up item
                    oMenuItem = Application.SBO_Application.Menus.Item("Gatepass");
                    oMenus = oMenuItem.SubMenus;
                    // Get the menu collection of the newly added pop-up item
                   
                    // Create s sub menu
                    oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                    oCreationPackage.UniqueID = "Shipmnenttracking";
                    oCreationPackage.String = "Shipment Tracking";
                    oMenus.AddEx(oCreationPackage);
                }
                catch
                {

                }


                try
                {
                    oMenus = oMenuItem.SubMenus;

                    // Get the menu collection of the newly added pop-up item
                    oMenuItem = Application.SBO_Application.Menus.Item("Gatepass");
                    oMenus = oMenuItem.SubMenus;
                    // Create s sub menu
                    oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                    oCreationPackage.UniqueID = "GatePass";
                    oCreationPackage.String = "GatePass";
                    oMenus.AddEx(oCreationPackage);

                    oMenus = oMenuItem.SubMenus;
                }
                catch 
                {
                    
                   
                }

                
            }
            catch (Exception er)
            { //  Menu already exists
                Application.SBO_Application.SetStatusBarMessage("Menu Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

            try
            {
                #region Provisional Cost

                oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
                oCreationPackage.UniqueID = "ProvCost";
                oCreationPackage.String = "Provisional Cost";
                oCreationPackage.Enabled = true;
                oCreationPackage.Position = -1;
                oMenus = oMenuItem.SubMenus;
                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch (Exception e) { }

                oMenus = oMenuItem.SubMenus;

                // Get the menu collection of the newly added pop-up item
                oMenuItem = Application.SBO_Application.Menus.Item("ProvCost");
                oMenus = oMenuItem.SubMenus;
                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.Provisional_Cost";
                oCreationPackage.String = "Provisional Cost";
                oMenus.AddEx(oCreationPackage);

                #endregion
            }
            catch { }

            try
            {
                oMenuItem = Application.SBO_Application.Menus.Item("2048");
                oMenus = oMenuItem.SubMenus;
                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "Sales_Addon_UDN.ProofOfDel";
                oCreationPackage.String = "Proof of Delivery";
                oMenus.AddEx(oCreationPackage);
            }
            catch
            {
            }
        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.Payment.b1f")
                {
                    PaymentUDO activeForm = new PaymentUDO();
                    activeForm.Show();
                    //    CreditLimit cr = new CreditLimit();
                    //    cr.Show();
                }
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.PromotionSetUp.b1f")
                {
                    PromotionSetUp Prsetup = new PromotionSetUp();
                    Prsetup.Show();
                }
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.CreditLimit.b1f")
                {
                    CreditLimit crlimit = new CreditLimit();
                    crlimit.Show();
                }
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.Payment")
                {
                    PaymentUDO crlimit = new PaymentUDO();
                    crlimit.Show();
                }
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.BillNTrade.b1f")
                {
                    BillNTrade crlimit = new BillNTrade();
                    crlimit.Show();
                }

                if (pVal.BeforeAction && pVal.MenuUID == "GatePass")
                {
                    GatePass gp = new GatePass();
                    gp.Show();
                }

                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.ProofOfDel")
                {
                    ProofOfDelivery pof = new ProofOfDelivery();
                    pof.Show();

                }
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.PickListReport.b1f")
                {
                    PicklListReport Prsetup = new PicklListReport();
                    Prsetup.Show();
                }
                if (pVal.BeforeAction && pVal.MenuUID == "Sales_Addon_UDN.Provisional_Cost")
                {
                    Provisional_Cost ps = new Provisional_Cost();
                    ps.Show();
                }
                try
                {
                    if (pVal.BeforeAction && pVal.MenuUID == "Shipmnenttracking")
                    {
                        ShipmentTrackings sh = new ShipmentTrackings();
                        sh.Show();
                    }
                }
                catch { }
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }
    }
}
