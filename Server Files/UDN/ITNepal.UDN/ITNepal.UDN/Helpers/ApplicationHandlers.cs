using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using System.Threading.Tasks;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.Addon.Forms;
using ITNepal.MainLibrary.Utilities;
//using ITNepal.Addon.SystemForms;
using GlobalVariable;
using System.Net.Mail;
using System.Threading;


namespace ITNepal.Addon.Helpers
{
    public class ApplicationHandlers
    {
        #region Members
        public static List<B1FormBase> FrmInstances = new List<B1FormBase>();
        private List<string> UDForms = new List<string> { "frm_FILL", "frm_FILL" };
        private static string sCredentials, sSenderEmail, Body, sSubject, sdocentry, squeryS, squeryE, CC;

        #endregion

        #region Constructor
        public ApplicationHandlers()
        {
            try
            {
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                Application.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_Application_MenuEvent);
                Application.SBO_Application.RightClickEvent += new SAPbouiCOM._IApplicationEvents_RightClickEventEventHandler(SBO_Application_RightClickEvent);
                Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(SBO_Application_FormDataEvent);
                Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                //Log.LogException(LogLevel.Error, ex);
            }
        }
        #endregion

        #region Events
        private void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    break;
                default:
                    break;
            }
        }
        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.BeforeAction)
                {
                    SBO_Application_MenuEventBefore(ref pVal, out BubbleEvent);
                }
                else
                {
                    switch (pVal.MenuUID)
                    {

                        //case "1282":
                        //    var activeForm1 = Application.SBO_Application.Forms.ActiveForm;
                        //    B1FormBase activeForm = null;
                        //    if (activeForm1.UniqueID == "PDIIns")
                        //    {
                        //        activeForm1.Close();
                        //        activeForm = new PDIInspection();
                        //        activeForm.Show();
                        //        activeForm1.ActiveItem = "Item_1";
                        //    }
                        //    else if (activeForm1.UniqueID == "model")
                        //    {
                        //        activeForm1.Close();
                        //        activeForm = new Model();
                        //        activeForm.Show();
                        //        activeForm1.ActiveItem = "Item_1";
                        //    }
                        //    else if (activeForm1.TypeEx == "60126")
                        //    {
                        //        SAPbouiCOM.ComboBox cmbPriceType;
                        //        SAPbouiCOM.ComboBox cmbStatus;

                        //        cmbStatus = ((SAPbouiCOM.ComboBox)(activeForm1.Items.Item("36").Specific));
                        //        cmbPriceType = ((SAPbouiCOM.ComboBox)(activeForm1.Items.Item("cmbPrcType").Specific));

                        //        if (cmbPriceType.Value.Trim() == "S")
                        //        {
                        //            cmbStatus.Select("A");
                        //        }
                        //    }

                        //    break;
                        //case "1281":
                        //    activeForm1 = Application.SBO_Application.Forms.ActiveForm;
                        //    if (activeForm1.TypeEx == "60110")
                        //    {
                        //        activeForm1.Items.Item("f_Install").Visible = false;
                        //        activeForm1.PaneLevel = 1;
                        //    }
                        //    else if (activeForm1.UniqueID == "model")
                        //    {
                        //        activeForm1.Items.Item("Item_1").Enabled = true;

                        //    }

                        //    break;
                    }


                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }
        private void SBO_Application_MenuEventBefore(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //UserFormBase activeForm = null;
            B1FormBase activeForm = null;
           
            switch (pVal.MenuUID)
            {
                case MenuID_UD.StockAgeingMID:
                    activeForm = new AgingReport();
                    break;
                case MenuID_UD.ServiceEarningDataMID:
                    activeForm = new TechnicalSkillMasterForm();
                    break;
                case MenuID_UD.ServiceEarningDataDistributorsMID:
                    activeForm = new MeterSetupForm();
                    break;
                case MenuID_UD.ServiceCallPendingForInvociesMID:
                    // case "1282":
                    activeForm = new CoverageMaster();
                    break;
                case MenuID_UD.AdministrativeDataFieldServiceCallMID:
                    // case "1282":
                    activeForm = new LeaseContractForm();
                    break;
            }
            if (activeForm != null)
            {
                activeForm.Show();
            }
        }
        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Matrix oMatrix;
            SAPbouiCOM.Application oApp = Application.SBO_Application;
            //1250000940
            //if (pVal.FormTypeEx == "1250000940" && pVal.ItemUID == "1" && pVal.BeforeAction == true)
            //{
            //    var UDFForm = oApp.Forms.Item(FormUID);

            //}

            //if (pVal.FormTypeEx == "198" && pVal.ItemUID == "6" && pVal.BeforeAction == true && pVal.ColUID == "V_0" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_MATRIX_LINK_PRESSED)
            //{
            //    BubbleEvent = false;

            //}



            if (pVal.FormTypeEx == "198" && pVal.ItemUID == "6" && pVal.BeforeAction == true && pVal.ColUID == "V_0" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_MATRIX_LINK_PRESSED)
            {

                BubbleEvent = false;
                try
                {
                    string[] split;
                    var UDFForm = oApp.Forms.Item(FormUID);
                    var docentry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("13").Specific).Value;
                    var stage = string.Empty;
                    SAPbouiCOM.Matrix mtxItemGroup;
                    mtxItemGroup = ((SAPbouiCOM.Matrix)(UDFForm.Items.Item("6").Specific));
                    stage = ((SAPbouiCOM.EditText)mtxItemGroup.Columns.Item("V_6").Cells.Item(pVal.Row).Specific).Value;
                    split = stage.Split('-');
                    //   var orginator = ((SAPbouiCOM.EditText)mtxItemGroup.Columns.Item("V_7").Cells.Item(pVal.Row).Specific).Value;

                    var auth = "U_Auth" + split[0];
                    docentry = docentry.Replace("Request For Service Contract Approval", "").Trim();
                    string query = string.Empty;

                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    query = "SELECT ifnull( \"{0}\", \"Status\") \"Status\", \"Remarks2\"  FROM OCTR T0 WHERE T0.\"ContractID\" = '" + docentry + "'";
                    query = string.Format(query, auth);
                    rs.DoQuery(query);
                    SAPbouiCOM.ComboBox status;

                    string dd = rs.Fields.Item("Status").Value.ToString();
                    if (rs.Fields.Item("Status").Value.ToString() == "D")
                    {
                        B1FormBase activeForm = null;
                        activeForm = new AgingReport();
                        var AD = oApp.Forms.Item("AD");
                        status = ((SAPbouiCOM.ComboBox)(AD.Items.Item("Item_3").Specific));
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_1").Specific).Value = docentry;
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_6").Specific).Value = split[0];
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_8").Specific).Value = split[1];
                        status.Select("Draft");
                        AD.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
                        AD.Visible = true;
                    }
                    else
                    {
                        B1FormBase activeForm = null;
                        activeForm = new AgingReport();
                        var AD = oApp.Forms.Item("AD");
                        status = ((SAPbouiCOM.ComboBox)(AD.Items.Item("Item_3").Specific));
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_1").Specific).Value = docentry;
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_6").Specific).Value = split[0];
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_8").Specific).Value = split[1];

                        if (rs.Fields.Item("Status").Value.ToString() == "A")
                        {
                            status.Select("Approved");
                        }
                        else { status.Select("Rejected"); }
                        // ((SAPbouiCOM.ComboBox )AD.Items.Item("Item_3").Specific).Value = "Approved";
                        ((SAPbouiCOM.EditText)AD.Items.Item("Item_5").Specific).Value = rs.Fields.Item("Remarks2").Value.ToString();
                        AD.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
                        AD.Visible = true;
                    }


                }
                catch (Exception ex) { }
            }

            if (pVal.FormTypeEx == "940" && pVal.ItemUID == "1" && pVal.BeforeAction == true && pVal.FormMode != Convert.ToInt32(SAPbouiCOM.BoFormMode.fm_FIND_MODE))
            {
                var UDFForm = oApp.Forms.Item(FormUID);
                string[] split;
                oMatrix = (SAPbouiCOM.Matrix)UDFForm.Items.Item("23").Specific;
                if (oMatrix.RowCount > 0)
                {
                    string FWH = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1470001039").Cells.Item(1).Specific).Value;
                    string TWH = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("5").Cells.Item(1).Specific).Value;
                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string query = "SELECT T0.\"U_UserName\" || ',' || ifnull(T0.\"email\",'')  \"Name\" FROM OHEM T0 WHERE T0.\"U_EWHS\"  =  '{0}'";
                    rs.DoQuery(string.Format(query, FWH));
                    if (rs.RecordCount > 0)
                    { Globals.SetsFromwarehouse(rs.Fields.Item("Name").Value.ToString()); }
                    else { Globals.SetsFromwarehouse(B1Helper.DiCompany.UserName.ToString() + "," + ""); }
                    rs.DoQuery(string.Format(query, TWH));
                    if (rs.RecordCount > 0)
                    { Globals.SetsTowarehouse(rs.Fields.Item("Name").Value.ToString()); }
                    //else
                    //{
                    //    Utility.LogException("Warehouse not mapped with Employees ....!");
                    //    BubbleEvent = false;
                    //    return;
                    //}

                    //if (Globals.NEmail == "Y")
                    //{
                    //    split = Globals.Towarehouse.Split(',');
                    //    if (string.IsNullOrEmpty(split[1]))
                    //    {
                    //        Utility.LogException("Define Email ID with respective employee - " + split[0]);
                    //        BubbleEvent = false;
                    //        return;
                    //    }
                    //}

                }
            }

            if (pVal.FormTypeEx == "149" && pVal.ItemUID == "38" && pVal.BeforeAction == false)
            {
                var UDFForm = oApp.Forms.Item(FormUID);
                oMatrix = (SAPbouiCOM.Matrix)UDFForm.Items.Item("38").Specific;
                if (pVal.ColUID == "1" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_LOST_FOCUS)
                {
                    string value = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(pVal.Row).Specific).Value;
                    if (value != string.Empty)
                    {
                        //  var MainForm = oApp.Forms.GetForm("60110", oApp.Forms.ActiveForm.TypeCount);
                        try
                        {
                            var MainForm = oApp.Forms.GetForm("60110", Globals.serviceformtype);
                            string ContractID = ((SAPbouiCOM.EditText)MainForm.Items.Item("20").Specific).Value;
                            string ServiceCallNo = ((SAPbouiCOM.EditText)MainForm.Items.Item("540000180").Specific).Value;

                            if (B1Helper.CheckItemGroupofItemUnderCoverage(ContractID, value))
                            {
                                oMatrix.SetCellValue("U_ServiceFlag", pVal.Row, "Y");
                                oMatrix.SetCellValue("U_ServiceCallNo", pVal.Row, ServiceCallNo);
                            }
                            oMatrix.Columns.Item("2").Cells.Item(pVal.Row).Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                        }
                        catch (Exception)
                        { }

                    }
                }
                //if (pVal.ColUID == "14" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_LOST_FOCUS)
                //{
                //    string value = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("14").Cells.Item(pVal.Row).Specific).Value;
                //    if (value != string.Empty)
                //    {
                //        double docTotal = 0;
                //        string mtxCellValue = oMatrix.GetCellValue("U_ServiceFlag", pVal.Row).ToString();
                //        if (mtxCellValue != "Y")
                //        {
                //           // docTotal += docTotal;
                //          //  docTotal = Convert.ToDouble(oMatrix.GetCellValue("21", pVal.Row).ToString());
                //            //docTotal += Convert.ToDouble(oMatrix.GetCellValue("21", pVal.Row).ToString());
                //          //  UDFForm.Items.Item("22").Enabled = true;
                //            ((SAPbouiCOM.EditText)UDFForm.Items.Item("22").Specific).Value = docTotal.ToString();
                //           // UDFForm.Items.Item("29").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                //           // UDFForm.Items.Item("22").Enabled = false;
                //        }
                //    }
                //}

            }
        }
        private void SBO_Application_RightClickEvent(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (eventInfo.BeforeAction)
            {
                SAPbouiCOM.Application oApp = Application.SBO_Application;
                var oform = oApp.Forms.Item(eventInfo.FormUID);
                if (oform.TypeEx == "60150")
                {
                    Globals.SetsDeleteForm("60150");
                    //  B1Helper.addMenuItem("1280", "AR", "Add Row");
                    B1Helper.addMenuItem("1280", "DL", "Delete Row");
                }
                if (oform.TypeEx == "60126")
                {
                    Globals.SetsDeleteForm("60126");
                    B1Helper.addMenuItem("1280", "DL", "Delete Row");

                }
                if (oform.TypeEx == "60110")
                {
                    Globals.SetsDeleteForm("60110");
                    B1Helper.addMenuItem("1280", "DL", "Delete Row");
                }
                if (oform.UniqueID == "model")
                {
                    Globals.SetsDeleteForm("model");
                    B1Helper.addMenuItem("1280", "DL", "Delete Row");
                }

            }

        }
        private void SBO_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            switch (BusinessObjectInfo.FormTypeEx)
            {
                //Sales Quotation
                case "149":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        string docEntry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("8").Specific).Value;
                    }
                    break;
                //Sales order
                case "139":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        string docEntry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("8").Specific).Value;
                    }
                    break;
                //A/R Invoice
                case "133":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        string docEntry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("8").Specific).Value;
                    }
                    break;
                //Delivery
                case "140":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        string docEntry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("8").Specific).Value;
                        // int jvNo = B1Helper.CreateJournalEntryforDelivery(oApp, docEntry, "15");
                    }
                    break;
                //A/R Credit Memo
                case "179":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        string docEntry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("8").Specific).Value;
                        //        int jvNo = B1Helper.CreateJournalEntryforARCreditMemo(oApp, docEntry, "14");
                    }
                    break;
                //Inventory Transfer
                #region Inventory Transfer

                case "940":
                    if ((BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD || BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_UPDATE) && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)UDFForm.Items.Item("23").Specific;
                        var baseref = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("27").Cells.Item(1).Specific).Value;
                        string docEntry = UDFForm.DataSources.DBDataSources.Item(0).GetValue("DocEntry", 0).Trim();
                        string docnum = UDFForm.DataSources.DBDataSources.Item(0).GetValue("DocNum", 0).Trim();
                        string Notystatus = UDFForm.DataSources.DBDataSources.Item(0).GetValue("U_Notification", 0).Trim();
                        string Emailstatus = UDFForm.DataSources.DBDataSources.Item(0).GetValue("U_Email", 0).Trim();
                        string sBody = "<div align=left style='font-size:10.0pt;font-family:Arial'>";
                        string FWH_ = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1470001039").Cells.Item(1).Specific).Value;
                        string TWH_ = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("5").Cells.Item(1).Specific).Value;
                        SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string Equery = "SELECT T0.\"Code\", T0.\"Name\", T0.\"U_Subject\", T0.\"U_Content\", T0.\"U_CC\"   FROM \"@EMAILTEMPLATE\"  T0 where T0.\"Code\" = '{0}'";
                        string query = "SELECT T0.\"U_UserName\" || ',' || ifnull(T0.\"email\",'')  \"Name\" FROM OHEM T0 WHERE T0.\"U_EWHS\"  =  '{0}'";
                        rs.DoQuery(string.Format(query, FWH_));
                        if (rs.RecordCount > 0)
                        { Globals.SetsFromwarehouse(rs.Fields.Item("Name").Value.ToString()); }
                        else { Globals.SetsFromwarehouse(B1Helper.DiCompany.UserName.ToString() + "," + ""); }
                        rs.DoQuery(string.Format(query, TWH_));
                        if (rs.RecordCount > 0)
                        { Globals.SetsTowarehouse(rs.Fields.Item("Name").Value.ToString()); }

                        if (string.IsNullOrEmpty(Globals.Towarehouse))
                        { return; }
                        string[] TWH = Globals.Towarehouse.Split(',');
                        string[] FWH = Globals.Fromwarehouse.Split(',');

                        string subject = string.Empty;
                        if (!string.IsNullOrEmpty(baseref))
                        {
                            rs.DoQuery(string.Format(Equery, "A3"));
                            subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                            subject = subject.Replace("@DocumentNumber", baseref);
                            sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                            sBody = sBody.Replace("@DocumentNumber", baseref);
                            sBody = sBody.Replace("@URL", "/stock-transfer?display=" + baseref + "");
                            CC = rs.Fields.Item("U_CC").Value.ToString();

                            //subject = "[" + FWH[0] + "] Transferred materials for your stock request [" + baseref + "]";
                            //sBody = sBody + " Dear Sir/Madam,<br /><br /> ";
                            //sBody = sBody + "[" + FWH[0] + "] is the SAP login user who performed Stock Transfer document creation. <br />";
                            //sBody = sBody + "[ " + baseref + "] will be Stock Transfer Request number based on which the stock transfer document is created.<br />";
                        }
                        else
                        {
                            rs.DoQuery(string.Format(Equery, "A3-1"));
                            subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                            // subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@DocumentNumber", baseref);
                            sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                            // sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@DocumentNumber", baseref);
                            // sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@URL", "/stock-transfer?display=" + baseref + "");
                            CC = rs.Fields.Item("U_CC").Value.ToString();

                            //subject = "[" + FWH[0] + "] Transferred materials for your stock request [" + baseref + "]";
                            //sBody = sBody + " Dear Sir/Madam,<br /><br /> ";
                            //sBody = sBody + "[" + docnum + "] Transferred materials to your van kit stock. Check your van kit stock for the updated stock. <br />";
                            //sBody = sBody + "[ " + FWH[0] + "] is the SAP login user who performed Stock Transfer document creation. <br />";
                        }
                        // private static string sCredentials, sSenderEmail, sBody, sSubject;
                        sCredentials = System.Configuration.ConfigurationManager.AppSettings["Email"];
                        sSenderEmail = TWH[1];
                        Body = sBody;
                        sSubject = subject;
                        sdocentry = docEntry;
                        squeryS = "update OWTR set \"U_Email\" = 'Success' where \"DocEntry\" = '{0}'";
                        squeryE = "update OWTR set \"U_Email\" = 'Fail : ' || '{1}'  where \"DocEntry\" = '{0}'";
                        // string sErrDesc = string.Empty;
                        //  string query;
                        Notification_IVT(docEntry, baseref, Notystatus, Emailstatus);
                        if (Globals.NEmail == "Y")
                        {
                            if (!string.IsNullOrEmpty(sSenderEmail))
                            {
                                if (!string.IsNullOrEmpty(Emailstatus))
                                {
                                    if (Utility.Left(Emailstatus, 7) != "Success")
                                    {
                                        ThreadStart childref = new ThreadStart(SendEmailNotification);
                                        Thread childThread = new Thread(childref);
                                        childThread.Start();
                                    }
                                }
                                else
                                {
                                    ThreadStart childref = new ThreadStart(SendEmailNotification);
                                    Thread childThread = new Thread(childref);
                                    childThread.Start();
                                }//T0."U_Email"
                            }

                        }

                        // string docEntry = ((SAPbouiCOM.EditText)UDFForm.Items.Item("8").Specific).Value;
                        //        int jvNo = B1Helper.CreateJournalEntryforARCreditMemo(oApp, docEntry, "14");
                    }
                    break;

                #endregion

                //Inventory Transfer Request
                #region Inventory Transfer Request
                case "1250000940":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_UPDATE && BusinessObjectInfo.BeforeAction == false)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        string docEntry = UDFForm.DataSources.DBDataSources.Item(0).GetValue("DocEntry", 0).Trim();
                        string docnum = UDFForm.DataSources.DBDataSources.Item(0).GetValue("DocNum", 0).Trim();
                        string Notystatus = UDFForm.DataSources.DBDataSources.Item(0).GetValue("U_Notification", 0).Trim();
                        string Emailstatus = UDFForm.DataSources.DBDataSources.Item(0).GetValue("U_Email", 0).Trim();
                        string Cancel = UDFForm.DataSources.DBDataSources.Item(0).GetValue("DocStatus", 0).Trim();
                        //SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        //string query = "SELECT \"DocStatus\" FROM \"OWTQ\"  where \"DocEntry\"='" + docEntry  + "'";
                        //rs.DoQuery(query);
                        SAPbouiCOM.Matrix oMatrix;
                        // string Cancel = rs.Fields.Item("DocStatus").Value.ToString();
                        if (Cancel == "C")
                        {
                            string[] split;
                            oMatrix = (SAPbouiCOM.Matrix)UDFForm.Items.Item("23").Specific;
                            if (oMatrix.RowCount > 0)
                            {
                                string FWH = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1470001039").Cells.Item(1).Specific).Value;
                                string TWH = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("5").Cells.Item(1).Specific).Value;
                                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                // string query = "SELECT T0.\"U_UserName\" || ',' || ifnull(T0.\"email\",'')  \"Name\" FROM OHEM T0 WHERE T0.\"U_EWHS\"  in ('" + FWH + "','" + TWH + "') ";
                                string query = "SELECT T0.\"U_UserName\" || ',' || ifnull(T0.\"email\",'')  \"Name\" FROM OHEM T0 WHERE T0.\"U_EWHS\"  = '{0}' ";
                                string Equery = "SELECT T0.\"Code\", T0.\"Name\", T0.\"U_Subject\", T0.\"U_Content\", T0.\"U_CC\"   FROM \"@EMAILTEMPLATE\"  T0 where T0.\"Code\" = '{0}'";
                                rs.DoQuery(string.Format(query, FWH));
                                if (rs.RecordCount > 0)
                                {
                                    Globals.SetsFromwarehouse(rs.Fields.Item("Name").Value.ToString());
                                }
                                else { Globals.SetsFromwarehouse(B1Helper.DiCompany.UserName.ToString() + "," + ""); }
                                rs.DoQuery(string.Format(query, TWH));
                                if (rs.RecordCount > 0)
                                {
                                    Globals.SetsTowarehouse(rs.Fields.Item("Name").Value.ToString());
                                    if (string.IsNullOrEmpty(Globals.Towarehouse))
                                    { return; }
                                    if (Globals.NEmail == "Y")
                                    {
                                        string[] TWH_ = Globals.Towarehouse.Split(',');
                                        string[] FWH_ = Globals.Fromwarehouse.Split(',');
                                        rs.DoQuery(string.Format(Equery, "A2"));
                                        string subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                                        subject = subject.Replace("@DocumentNumber", docnum);
                                        string sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                                        sBody = sBody.Replace("@DocumentNumber", docnum);
                                        sBody = sBody.Replace("@URL", "/stock-transfer?display=" + docnum + "");
                                        CC = rs.Fields.Item("U_CC").Value.ToString();

                                        //string sBody = "<div align=left style='font-size:10.0pt;font-family:Arial'>";
                                        //sBody = sBody + " Dear Sir/Madam,<br /><br /> ";
                                        //sBody = sBody + "[" + FWH_[0] + "] is the SAP login user who performed Stock Transfer document creation. <br />";
                                        //sBody = sBody + "[ " + docnum + "] will be Stock Transfer Request number based on which the stock transfer document is created.<br />";
                                        ////[SAPUser] cancelled your stock transfer request [Request number]
                                        //string subject = "[" + FWH_[0] + "] cancelled your stock transfer request [" + docnum + "]";
                                        sCredentials = System.Configuration.ConfigurationManager.AppSettings["Email"];
                                        sSenderEmail = TWH_[1];
                                        Body = sBody;
                                        sSubject = subject;
                                        sdocentry = docEntry;
                                        squeryS = "update OWTQ set \"U_Email\" = 'Success' where \"DocEntry\" = '{0}'";
                                        squeryE = "update OWTQ set \"U_Email\" = 'Fail : ' || '{1}'  where \"DocEntry\" = '{0}'";

                                        split = Globals.Towarehouse.Split(',');
                                        if (!string.IsNullOrEmpty(split[1]))
                                        {
                                            if (!string.IsNullOrEmpty(Emailstatus))
                                            {
                                                if (Utility.Left(Emailstatus, 7) != "Success")
                                                {
                                                    ThreadStart childref = new ThreadStart(SendEmailNotification);
                                                    Thread childThread = new Thread(childref);
                                                    childThread.Start();
                                                }

                                            }
                                            else
                                            {
                                                ThreadStart childref = new ThreadStart(SendEmailNotification);
                                                Thread childThread = new Thread(childref);
                                                childThread.Start();
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    Utility.LogException("Warehouse not mapped with Employees ....!");
                                    BubbleEvent = false;
                                    return;
                                } Notification_IVTR(docEntry, docnum, Notystatus, Emailstatus, Cancel);
                            }
                        }
                    }
                    break;


                #endregion

                //Activity
                #region New Activity
                case "651":
                    if ((BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD || BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_UPDATE) && BusinessObjectInfo.ActionSuccess == true)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        // var UDFForm = oApp.Forms.Item("651");
                        string docEntry = UDFForm.DataSources.DBDataSources.Item(1).GetValue("ClgCode", 0).Trim();
                        SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string query = "SELECT T0.\"U_callID\", T0.\"U_Notification\", T0.\"U_Email\" , T0.\"AttendEmpl\" FROM OCLG T0 WHERE T0.\"ClgCode\"  = " + docEntry + "";
                        rs.DoQuery(query);

                        string docnum = rs.Fields.Item("U_callID").Value.ToString();
                        string Notystatus = rs.Fields.Item("U_Notification").Value.ToString();
                        string Emailstatus = rs.Fields.Item("U_Email").Value.ToString();
                        string employee = rs.Fields.Item("AttendEmpl").Value.ToString();
                        string cat = ((SAPbouiCOM.ComboBox)UDFForm.Items.Item("1320000198").Specific).Value;
                        //  UDFForm.DataSources.DBDataSources.Item(0).GetValue("1320000198", 0).Trim();
                        //SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        //string query = "SELECT \"DocStatus\" FROM \"OWTQ\"  where \"DocEntry\"='" + docEntry  + "'";
                        //rs.DoQuery(query);
                        if (cat == "U")
                        { return; }
                        query = "SELECT T0.\"U_UserName\" || ',' || ifnull(T0.\"email\",'')  \"Name\" FROM OHEM T0 WHERE T0.\"empID\" = " + employee + " ";
                        rs.DoQuery(query);
                        if (rs.RecordCount > 0)
                        {
                            Globals.SetsFromwarehouse("");
                            Globals.SetsTowarehouse(rs.Fields.Item("Name").Value.ToString());
                        }
                        else
                        {
                            Utility.LogException("Warehouse not mapped with Employees ....!");
                            //  BubbleEvent = false;
                            //return;
                        }
                        if (string.IsNullOrEmpty(Globals.Towarehouse))
                        { return; }
                        if (!string.IsNullOrEmpty(Notystatus))
                        {
                            if (Utility.Left(Notystatus, 7) != "Success")
                            { Notification_IVTA(docEntry, docnum, Notystatus, Emailstatus); }
                        }
                        else { Notification_IVTA(docEntry, docnum, Notystatus, Emailstatus); }
                        string[] split;
                        string Equery = "SELECT T0.\"Code\", T0.\"Name\", T0.\"U_Subject\", T0.\"U_Content\", T0.\"U_CC\"   FROM \"@EMAILTEMPLATE\"  T0 where T0.\"Code\" = '{0}'";
                        rs.DoQuery(string.Format(Equery, "A4"));
                        // string subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                        string subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@DocumentNumber", docnum);
                        // string sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                        string sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@DocumentNumber", docnum);
                        sBody = sBody.Replace("@URL", "/call/details/" + docnum + "");
                        CC = rs.Fields.Item("U_CC").Value.ToString();

                        //string sBody = "<div align=left style='font-size:10.0pt;font-family:Arial'>";
                        //sBody = sBody + " Dear Sir/Madam,<br /><br /> ";
                        //sBody = sBody + "[ " + docnum + "] is the Service Call ID based on which the activity is created.<br />";
                        ////[SAPUser] cancelled your stock transfer request [Request number]
                        //string subject = " New activity is created for Service call [" + docnum + "].";
                        sCredentials = System.Configuration.ConfigurationManager.AppSettings["Email"];

                        Body = sBody;
                        sSubject = subject;
                        sdocentry = docEntry;
                        squeryS = "update OCLG set \"U_Email\" = 'Success' where \"ClgCode\" = '{0}'";
                        squeryE = "update OCLG set \"U_Email\" = 'Fail : ' || '{1}'  where \"ClgCode\" = '{0}'";
                        // SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                        if (Globals.NEmail == "Y")
                        {
                            split = Globals.Towarehouse.Split(',');
                            if (!string.IsNullOrEmpty(split[1]))
                            {
                                sSenderEmail = split[1];
                                if (!string.IsNullOrEmpty(Emailstatus))
                                {
                                    if (Utility.Left(Emailstatus, 7) != "Success")
                                    {
                                        ThreadStart childref = new ThreadStart(SendEmailNotification);
                                        Thread childThread = new Thread(childref);
                                        childThread.Start();
                                    }
                                }
                                else
                                {
                                    ThreadStart childref = new ThreadStart(SendEmailNotification);
                                    Thread childThread = new Thread(childref);
                                    childThread.Start();
                                }
                            }
                        }
                    }
                    break;

                #endregion

                #region Service Call Assigned

                //Service Call
                case "60110":
                    if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_UPDATE && BusinessObjectInfo.BeforeAction == false)
                    {
                        SAPbouiCOM.Application oApp = Application.SBO_Application;
                        var UDFForm = oApp.Forms.Item(BusinessObjectInfo.FormUID);
                        // var UDFForm = oApp.Forms.Item("651");
                        string docnum = string.Empty;
                        string docEntry = UDFForm.DataSources.DBDataSources.Item(0).GetValue("callID", 0).Trim();
                        // docnum = UDFForm.DataSources.DBDataSources.Item(0).GetValue("DocNum", 0).Trim();
                        string status = UDFForm.DataSources.DBDataSources.Item(0).GetValue("status", 0).Trim();
                        SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        SAPbobsCOM.Recordset rsclg = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string exception = string.Empty;
                        // string docnum = rs.Fields.Item("U_callID").Value.ToString();
                        string Notystatus = UDFForm.DataSources.DBDataSources.Item(0).GetValue("U_Notification", 0).Trim();
                        string Emailstatus = UDFForm.DataSources.DBDataSources.Item(0).GetValue("U_Email", 0).Trim();

                        if (status != "1")
                        {
                            return;
                        }
                        string Equery = "SELECT T0.\"Code\", T0.\"Name\", T0.\"U_Subject\", T0.\"U_Content\", T0.\"U_CC\"   FROM \"@EMAILTEMPLATE\"  T0 where T0.\"Code\" = '{0}'";

                        rs.DoQuery(string.Format(Equery, "A5"));
                        // string subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                        string subject = rs.Fields.Item("U_Subject").Value.ToString().Replace("@DocumentNumber", docEntry);
                        //string sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@SenderName", B1Helper.DiCompany.UserName.ToString());
                        string sBody = rs.Fields.Item("U_Content").Value.ToString().Replace("@DocumentNumber", docEntry);
                        sBody = sBody.Replace("@URL", "/call/details/" + docEntry + "");
                        CC = rs.Fields.Item("U_CC").Value.ToString();


                        //string sBody = "<div align=left style='font-size:10.0pt;font-family:Arial'>";
                        //sBody = sBody + " Dear Sir/Madam,<br /><br /> ";
                        ////"[" + docnum + "] is the Service Call ID based on which the activity is created.";
                        //sBody = sBody + "[ " + docnum + "] is the Service Call ID based on which the activity is created. <br />";
                        ////[SAPUser] cancelled your stock transfer request [Request number]

                        //string subject = " Activity is assigned for Service call [" + docnum + "]. ";
                        sCredentials = System.Configuration.ConfigurationManager.AppSettings["Email"];

                        Body = sBody;
                        sSubject = subject;
                        sdocentry = docEntry;
                        squeryS = "update OSCL  set \"U_Email\" = 'Success' where \"callID\" = '{0}'";
                        squeryE = "update OSCL  set \"U_Email\" = 'Fail : ' || '{1}'  where \"callID\" = '{0}'";

                        string query = "SELECT T0.\"ClgCode\", T0.\"AttendEmpl\" FROM OCLG T0 WHERE T0.\"Closed\" = 'N' and  T0.\"U_callID\"  = '" + docEntry + "'";
                        rsclg.DoQuery(query);
                        string[] split;
                        if (rsclg.RecordCount > 0)
                        {
                            while (rsclg.EoF == false)
                            {
                                docnum = rsclg.Fields.Item("ClgCode").Value.ToString();
                                string employee = rsclg.Fields.Item("AttendEmpl").Value.ToString();

                                query = "SELECT T0.\"U_UserName\" || ',' || ifnull(T0.\"email\",'')  \"Name\" FROM OHEM T0 WHERE T0.\"empID\" = " + employee + " ";
                                rs.DoQuery(query);
                                if (rs.RecordCount > 0)
                                {
                                    Globals.SetsFromwarehouse("");
                                    Globals.SetsTowarehouse(rs.Fields.Item("Name").Value.ToString());
                                }
                                else
                                {
                                    Utility.LogException("Warehouse not mapped with Employees ....!");
                                    BubbleEvent = false;
                                    return;
                                }
                                if (string.IsNullOrEmpty(Globals.Towarehouse))
                                { return; }
                                Notification_IVTS(docEntry, docnum, Notystatus, Emailstatus, ref exception);
                                //if (!string.IsNullOrEmpty(Notystatus))
                                //{
                                //    if (Utility.Left(Notystatus, 7) != "Success")
                                //    { Notification_IVTS(docEntry, docnum, Notystatus, Emailstatus, ref exception); }
                                //}
                                //else { Notification_IVTS(docEntry, docnum, Notystatus, Emailstatus, ref exception); }

                                // SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                if (Globals.NEmail == "Y")
                                {
                                    split = Globals.Towarehouse.Split(',');
                                    sSenderEmail = split[1];
                                    if (!string.IsNullOrEmpty(split[1]))
                                    {
                                        ThreadStart childref = new ThreadStart(SendEmailNotification);
                                        Thread childThread = new Thread(childref);
                                        childThread.Start();
                                        //if (!string.IsNullOrEmpty(Emailstatus))
                                        //{
                                        //    if (Utility.Left(Emailstatus, 7) != "Success")
                                        //    {
                                        //        ThreadStart childref = new ThreadStart(SendEmailNotification);
                                        //        Thread childThread = new Thread(childref);
                                        //        childThread.Start();
                                        //    }

                                        //}
                                        //else
                                        //{
                                        //    ThreadStart childref = new ThreadStart(SendEmailNotification);
                                        //    Thread childThread = new Thread(childref);
                                        //    childThread.Start();
                                        //}
                                    }
                                }

                                rsclg.MoveNext();
                            }
                            //if (exception.Length > 0)
                            //{ query = "update OSCL set \"U_Notification\" = 'Fail : ' || '" + exception + "' where \"callID\" = '" + docEntry + "'"; }
                            //else { query = "update OSCL set \"U_Notification\" = 'Success' where \"callID\" = '" + docEntry + "'"; }
                            //rs.DoQuery(query);
                        }


                    }
                    break;


                #endregion


                default:
                    break;

            }
        }
        #endregion

        #region Methods
        private void Notification_IVT(string docEntry, string docnum, string Notystatus, string Emailstatus)
        {
            string[] FWH;
            string[] TWH;
            string exception = string.Empty;

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string query = "\"max(to_int(ifnull(T0.\"Code\",0))) \"Code\" FROM \"@Z_NOTIF\"  T0";
            rs.DoQuery(query);
            FWH = Globals.Fromwarehouse.Split(',');
            TWH = Globals.Towarehouse.Split(',');
            var code = Convert.ToInt32(rs.Fields.Item("Code").Value.ToString()) + 1;
            query = "insert into \"@Z_NOTIF\" values(" + Convert.ToInt32(code) + " ,'" + code + "','3','940','Inventory Transfer', " +
            " '[ ' || '" + FWH[0].Trim() + "' || '] Transferred materials for your stock request [' || '" + docnum + "' || '] to ' || '" + TWH[0].Trim() + "' ,'/stock-transfer?display=' || '" + docnum + "' ,'" + FWH[0].Trim() + "','" + TWH[0].Trim() + "','N','N','N', now(),'')";

            if (!string.IsNullOrEmpty(Notystatus))
            {
                if (Utility.Left(Notystatus, 7) != "Success")
                {
                    try
                    {
                        rs.DoQuery(query);
                        exception = String.Empty;
                    }
                    catch (Exception ex)
                    {
                        exception = ex.Message;
                    }
                }
                else { exception = String.Empty; }
            }
            else
            {
                try
                {
                    rs.DoQuery(query);
                    exception = String.Empty;
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
            }//T0."U_Email"
            if (exception.Length > 0)
            { query = "update OWTR set \"U_Notification\" = 'Fail : ' || '" + exception + "' where \"DocEntry\" = '" + docEntry + "'"; }
            else { query = "update OWTR set \"U_Notification\" = 'Success' where \"DocEntry\" = '" + docEntry + "'"; }
            rs.DoQuery(query);

        }
        private void Notification_IVTR(string docEntry, string docnum, string Notystatus, string Emailstatus, string Cancel)
        {
            string[] FWH;
            string[] TWH;
            string exception = string.Empty;

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string query = "SELECT max(to_int(ifnull(T0.\"Code\",0))) \"Code\" FROM \"@Z_NOTIF\"  T0";
            rs.DoQuery(query);

            FWH = Globals.Fromwarehouse.Split(',');
            TWH = Globals.Towarehouse.Split(',');
            var code = Convert.ToInt32(rs.Fields.Item("Code").Value.ToString()) + 1;
            query = "insert into \"@Z_NOTIF\" values(" + Convert.ToInt32(code) + " ,'" + code + "','2','1250000940','Inventory Transfer Request', " +
            "  '" + FWH[0].Trim() + "' || ' Cancelled Inventory Transfer Request [' || '" + docnum + "' || '] to ' || '" + TWH[0].Trim() + "' ,'/stock-transfer?display=' || '" + docnum + "' ,'" + FWH[0].Trim() + "','" + TWH[0].Trim() + "','N','N','N',  now(),'')";

            if (!string.IsNullOrEmpty(Notystatus))
            {
                if (Utility.Left(Notystatus, 7) != "Success")
                {
                    try
                    {
                        rs.DoQuery(query);
                        exception = String.Empty;
                    }
                    catch (Exception ex)
                    {
                        exception = ex.Message;
                    }
                }
                else { exception = String.Empty; }
            }
            else
            {
                try
                {
                    rs.DoQuery(query);
                    exception = String.Empty;
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
            }//T0."U_Email"
            if (exception.Length > 0)
            { query = "update OWTQ set \"U_Notification\" = 'Fail : ' || '" + exception + "' where \"DocEntry\" = '" + docEntry + "'"; }
            else { query = "update OWTQ set \"U_Notification\" = 'Success' where \"DocEntry\" = '" + docEntry + "'"; }
            rs.DoQuery(query);

        }
        private void Notification_IVTA(string docEntry, string docnum, string Notystatus, string Emailstatus)
        {
            string FWH;
            string[] TWH;
            string exception = string.Empty;

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string query = "SELECT max(to_int(ifnull(T0.\"Code\",0))) \"Code\" FROM \"@Z_NOTIF\"  T0";
            rs.DoQuery(query);

            FWH = Globals.Fromwarehouse;
            TWH = Globals.Towarehouse.Split(',');
            var code = Convert.ToInt32(rs.Fields.Item("Code").Value.ToString()) + 1;
            query = "insert into \"@Z_NOTIF\" values(" + Convert.ToInt32(code) + " ,'" + code + "','4','651','New Activity Creation', " +
            "  '" + FWH + "' || ' New Activity is Created for Service Call [' || '" + docnum + "' || ']' ,'/call/details/' || '" + docnum + "','" + FWH + "','" + TWH[0].Trim() + "','N','N','N',  now(),'')";

            if (!string.IsNullOrEmpty(Notystatus))
            {
                if (Utility.Left(Notystatus, 7) != "Success")
                {
                    try
                    {
                        rs.DoQuery(query);
                        exception = String.Empty;
                    }
                    catch (Exception ex)
                    {
                        exception = ex.Message;
                    }
                }
                else { exception = String.Empty; }
            }
            else
            {
                try
                {
                    rs.DoQuery(query);
                    exception = String.Empty;
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
            }//T0."U_Email"
            if (exception.Length > 0)
            { query = "update OCLG set \"U_Notification\" = 'Fail : ' || '" + exception + "' where \"ClgCode\" = '" + docEntry + "'"; }
            else { query = "update OCLG set \"U_Notification\" = 'Success' where \"ClgCode\" = '" + docEntry + "'"; }
            rs.DoQuery(query);

        }
        private void Notification_IVTS(string docEntry, string docnum, string Notystatus, string Emailstatus, ref string exception)
        {
            string FWH;
            string[] TWH;


            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string query = "SELECT max(to_int(ifnull(T0.\"Code\",0))) \"Code\" FROM \"@Z_NOTIF\"  T0";
            rs.DoQuery(query);

            FWH = Globals.Fromwarehouse;
            TWH = Globals.Towarehouse.Split(',');
            var code = Convert.ToInt32(rs.Fields.Item("Code").Value.ToString()) + 1;
            query = "insert into \"@Z_NOTIF\" values(" + Convert.ToInt32(code) + " ,'" + code + "','5','60110','Service Call ', " +
            "  '" + FWH + "' || ' Activity is Assigned for Service Call [' || '" + docnum + "' || ']' ,'/call/details/' || '" + docnum + "','" + FWH + "','" + TWH[0].Trim() + "','N','N','N',  now(),'')";

            if (!string.IsNullOrEmpty(Notystatus))
            {
                if (Utility.Left(Notystatus, 7) != "Success")
                {
                    try
                    {
                        rs.DoQuery(query);
                        exception = String.Empty;
                    }
                    catch (Exception ex)
                    {
                        exception = ex.Message;
                    }
                }
                else { exception = String.Empty; }
            }
            else
            {
                try
                {
                    rs.DoQuery(query);
                    exception = String.Empty;
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
            }//T0."U_Email"


        }

        // public long SendEmailNotification(string sCredentials, string sSenderEmail, string sBody, string sSubject, ref string sErrDesc)
        public static void SendEmailNotification()
        {
            string sFuncName = String.Empty;
            SmtpClient oSmtpServer = new SmtpClient();
            MailMessage oMail = new MailMessage();
            string[] split;
            string[] Email;
            string p_SyncDateTime = string.Empty;
            Email = CC.Split(',');
            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            split = sCredentials.Split(';');  // 0-port 1-server 2-username 3-password 4-emailform 5- ssl
            try
            {

                oSmtpServer.Credentials = new System.Net.NetworkCredential(split[2], split[3]);
                oSmtpServer.Port = Convert.ToInt32(split[0]);
                oSmtpServer.Host = split[1];

                if (split[5] == "Y")
                { oSmtpServer.EnableSsl = true; }
                else { oSmtpServer.EnableSsl = false; }

                oMail.From = new MailAddress(split[4]);
                if (Email.Length > 0)
                { sSenderEmail += "," + CC; }

                oMail.To.Add(sSenderEmail);

                oMail.Subject = sSubject;
                // oMail.Body = Mail_Body(sBody)
                oMail.Body = Body;
                oMail.IsBodyHtml = true;

                oSmtpServer.Send(oMail);
                oMail.Dispose();
                rs.DoQuery(string.Format(squeryS, sdocentry));

                // return 1;
            }
            catch (Exception ex)
            {
                rs.DoQuery(string.Format(squeryE, sdocentry, ex.Message));
                //sErrDesc = ("Please check the email Address." + ("Fail to send email : "
                //            + (sSenderEmail + (":: " + ex.Message))));

                // return 0;
            }

        }


        public static void CallToChildThread(string sCredentials, string sSenderEmail, string sBody, string sSubject, ref string sErrDesc)
        {
            Console.WriteLine("Child thread starts");

            // the thread is paused for 5000 milliseconds
            int sleepfor = 5000;

            Console.WriteLine("Child Thread Paused for {0} seconds", sleepfor / 1000);
            Thread.Sleep(sleepfor);
            Console.WriteLine("Child thread resumes");
        }

        #endregion

    }
}
