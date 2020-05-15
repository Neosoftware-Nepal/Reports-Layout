using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using SAPbobsCOM;
using System.Globalization;
using System.Data;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.PicklListReport", "PickListReport.b1f")]
    class PicklListReport : UserFormBase
    {
        public PicklListReport()
        {
            Matrix0.AutoResizeColumns();
        }

        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtFromdt = ((SAPbouiCOM.EditText)(this.GetItem("txtFromdt").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtTodt = ((SAPbouiCOM.EditText)(this.GetItem("txtTodt").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Refresh").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Matrix0").Specific));
            this.Matrix0.DoubleClickAfter += new SAPbouiCOM._IMatrixEvents_DoubleClickAfterEventHandler(this.Matrix0_DoubleClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.chkGnPkls = ((SAPbouiCOM.CheckBox)(this.GetItem("chkGnPkls").Specific));
            this.OnCustomInitialize();
        }

        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void OnCustomInitialize()
        {
            UIAPIRawForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (!validate())
            {
                BubbleEvent = false;
            }

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string query = "";
                Matrix0.Clear();
                String fromDate = txtFromdt.Value;
                String toDate = txtTodt.Value;
                if (chkGnPkls.Checked)
                {
                    query = "SELECT T0.\"DocNum\", T0.\"DocEntry\" ,TO_VARCHAR (TO_DATE(T0.\"DocDate\"), 'YYYYMMDD') \"DocDate\", T0.\"CardName\",T0.\"U_BUSUNIT\",T0.\"U_PICKLIST\" FROM ORDR T0 where T0.\"DocDate\" between \'" +
                          fromDate + "\' and \'" + toDate + "\' and T0.\"U_PICKLIST\" IS NOT NULL ";
                }
                else
                {

                    query = "SELECT T0.\"DocNum\", T0.\"DocEntry\" ,TO_VARCHAR (TO_DATE(T0.\"DocDate\"), 'YYYYMMDD') \"DocDate\", T0.\"CardName\",T0.\"U_BUSUNIT\",T0.\"U_PICKLIST\" FROM ORDR T0 where T0.\"DocDate\" between \'" +
                                  fromDate + "\' and \'" + toDate + "\' and T0.\"U_PICKLIST\" IS NULL";
                }

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rs.DoQuery(query);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < rs.RecordCount; i++)
                    {
                        Matrix0.AddRow();
                        //  ((SAPbouiCOM.PictureBox)Matrix0.Columns.Item("GenPckLst").Cells.Item(i + 1).Specific).Picture = @"C:\UDN\Framework\Sales Addon\Sales_Addon_UDN\Sales_Addon_UDN\bin\Debug\Images\generate_Picklist.PNG";
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(i + 1).Specific).Value = (i + 1).ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("SoDate").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("DocDate").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("SoNo").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("DocNum").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("IntNo").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("DocEntry").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("CusName").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("CardName").Value.ToString();
                        Matrix0.CommonSetting.SetCellBackColor(i + 1, 8, 876);
                        Matrix0.CommonSetting.SetCellFontColor(i + 1, 8, 255);
                        Matrix0.CommonSetting.SetCellFontStyle(i + 1, 8, SAPbouiCOM.BoFontStyle.fs_Bold);
                        Matrix0.CommonSetting.SetCellBackColor(i + 1, 9, 876);
                        Matrix0.CommonSetting.SetCellFontColor(i + 1, 9, 255);
                        Matrix0.CommonSetting.SetCellFontStyle(i + 1, 9, SAPbouiCOM.BoFontStyle.fs_Bold);
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PN").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("U_PICKLIST").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("GenPckLst").Cells.Item(i + 1).Specific).Value = "Generate PickList";
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Genpktrpt").Cells.Item(i + 1).Specific).Value = "Generate PickList Report";
                        rs.MoveNext();
                    }

                }

            }
            catch (Exception e)
            {
                Program.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private bool validate()
        {
            try
            {
                if (String.IsNullOrEmpty(txtFromdt.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("From Date Can't be Empty", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                else if (String.IsNullOrEmpty(txtTodt.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("To Date Can't be Empty", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                Program.SBO_Application.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }


        }

        public static void CrystalReportToPrint(string rptPath, string strDocEntry)
        {

            string dbusername = string.Empty, dbpass = string.Empty, dbservername = string.Empty, dbName = string.Empty;
            dbusername = ConfigurationSettings.AppSettings["dbuser"].ToString();// GetDBUserName(ClsGlobal.strServerXMLPath);
            dbpass = ConfigurationSettings.AppSettings["dbPassword"].ToString();// GetDBDPassword(ClsGlobal.strServerXMLPath);
            dbservername = B1Helper.DiCompany.Server;// GetDBServerDB(ClsGlobal.strServerXMLPath);
            dbName = B1Helper.DiCompany.CompanyDB;// GetDDBName(ClsGlobal.strServerXMLPath);

            try
            {
                ReportDocument objReport = new ReportDocument();

                objReport.Load(rptPath);
                objReport.Refresh();
                Tables CrTables;
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                crConnectionInfo.ServerName = dbservername.Trim();
                crConnectionInfo.DatabaseName = dbName.Trim();

                crConnectionInfo.UserID = dbusername;// ConfigurationSettings.AppSettings["dbuser"].ToString();            //dbusername.Trim();
                crConnectionInfo.Password = dbpass;// ConfigurationSettings.AppSettings["dbPassword"].ToString();
                CrTables = objReport.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }
                objReport.SetParameterValue("DOCKEY@", strDocEntry);
                // objReport.SetParameterValue("docentry", strBranch);
                // objReport.SetParameterValue("tempype", strTempType);s
                objReport.SetDatabaseLogon(dbusername,dbpass, dbservername, dbName);
                //Viewer viewer = new Viewer();
                //  crviewer.ReportSource = objReport;
                //  crviewer.PrintReport();
                 objReport.PrintToPrinter(1,false,0,0);
                //objReport.ExportToDisk(ExportFormatType.PortableDocFormat, savePath);
                objReport.Close();
                objReport.Dispose();
            }

            catch (Exception ex)
            {
                //ClsGFun.WriteLog("Report Exception : " + " " + ex.ToString());
            }
            finally
            {

            }
        }

        private void Matrix0_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "GenPckLst" && ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PN").Cells.Item(pVal.Row).Specific).Value.ToString().Equals(""))
                {
                    if (((SAPbouiCOM.CheckBox)Matrix0.Columns.Item("Choose").Cells.Item(pVal.Row).Specific).Checked)
                    {
                        string CustName = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("CusName").Cells.Item(pVal.Row).Specific).Value.ToString();
                        string BusUnit = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("BusUnit").Cells.Item(pVal.Row).Specific).Value.ToString();
                        string IntNo = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("IntNo").Cells.Item(pVal.Row).Specific).Value.ToString();
                        string docNum = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("SoNo").Cells.Item(pVal.Row).Specific).Value.ToString();
                        Transaction trans = new Transaction(IntNo, docNum, BusUnit, CustName);
                        trans.Show();
                    }
                    else
                    {
                        Program.SBO_Application.SetStatusBarMessage("please check the choose box", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    }
                }
                else if (pVal.ColUID == "Genpktrpt" && ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PN").Cells.Item(pVal.Row).Specific).Value.ToString().Equals(""))
                {
                    if (((SAPbouiCOM.CheckBox)Matrix0.Columns.Item("Choose").Cells.Item(pVal.Row).Specific).Checked)
                    {
                        string path = @"\Reports\PickList.rpt";
                        //var directory = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                        string GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        string rptPath = GetDirectory + path;
                        CrystalReportToPrint(rptPath, ((SAPbouiCOM.EditText)Matrix0.Columns.Item("IntNo").Cells.Item(pVal.Row).Specific).Value.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //   throw new System.NotImplementedException();
            // UIAPIRawForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;

        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText txtFromdt;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtTodt;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.CheckBox chkGnPkls;


    }
}

