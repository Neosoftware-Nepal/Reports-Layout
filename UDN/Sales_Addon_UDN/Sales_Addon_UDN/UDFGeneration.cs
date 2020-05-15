using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

using System.Diagnostics;
using System.Threading;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Management;
using Microsoft.CSharp;
using System.Security.Cryptography;

using System.Reflection;
using System.IO;
using SAPbobsCOM;
using SAPbouiCOM;
using System.Resources;
using Sales_Addon_UDN;
using ITNepal;


namespace Sales_Addon_UDN
{
    public class UDClass
    {
        #region Variable
        public static SAPbobsCOM.Company oCompany;
        public SAPbouiCOM.Application oApplication;
        public static ITNepal.MainLibrary.SAPB1.B1Helper B1Hepler;
        string FileName, defFileName;
        public string showReportCode = "";
        public static bool busy = false;

        private static System.Timers.Timer aTimer;
        private SAPbobsCOM.Recordset rec;
        private string ErrMsg = null;
        private int RetCode = 0;

        private string[] ChildTable = new string[0];
        private string[] FindColoum = new string[0];
        private string[] FormCoumns = new string[0];
        public List<string> FindColumns = new List<string>();
        public Dictionary<string, string> defaultvalue = new Dictionary<string, string>();
        string[,] srt = new string[,] { { "N", "No" }, { "Y", "Yes" } };
        #endregion

        public UDClass(SAPbobsCOM.Company oCompany1)
        {
            try
            {
                oCompany = oCompany1;
                int ret2 = 0;
                if (ret2 == 0)
                {
                    Program.SBO_Application.StatusBar.SetText("Database structure is modifying..", SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                    CreateConfigurationTables();
                }
                else
                {
                    MessageBox.Show(oCompany.GetLastErrorDescription());
                    MessageBox.Show("UI Not connected");
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect company!" + ex.Message);
                Environment.Exit(0);
            }
        }

        public void execTimer()
        {
            //aTimer = new System.Timers.Timer(1);
            //aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 1 * 60 * 1000;
            //aTimer.Enabled = true;
        }

        public enum _tableName
        {
            ORDR = 1,
            ORPC = 2,
        }



        public void CreateConfigurationTables()
        {




            #region Shipment Tracking
            //Shipment Tracking
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OSPT", "Shipment tracking", BoUTBTableType.bott_Document);

            //Shipment Tracking Table Header Fileds

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PODNUM", "Purchase Order Number", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PODENT", "Purchase Order DOCENTRY", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PODT", "PO Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VCODE", "Vendor Code", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PERINVNO", "Performa Invoice NO", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PERDT", "Performa Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("COMINVNO", "Commercial Invoice NO", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("COMDT", "Commercial Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRPODNUM", "GRPO Doc Number", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRPODENT", "GRPO DOCENTRY", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRPODT", "GRPO Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BLDNUM", "BL DOCNUMBER", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BLDT", "BL Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SHNDT", "Ship Tra NEP Dt", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SHDELNDT", "Ship Tra DEL NEP Dt", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRANME", "Transporter Name", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LRNO", "Lr No", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ETADTPA", "Est Dt Of Port Arr", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ETAHRPA", "Est Hour on Port Arr", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, BoFldSubTypes.st_Time, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCRELDT", "Doc Release Dt", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("STATUS", "Status", "ITN_OSPT", BoFieldTypes.db_Alpha, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LCDNUM", "LC DOCNUMBER", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LCDT", "LC Date", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ODOCRBB", "Original Doc Rec By Bnk", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BNKCLDT", "Bank Clear Date", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PAYDATE", "PAYM Date", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCTOTAL", "Document Total", "ITN_OSPT", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "Prepared By", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "Remarks", "ITN_OSPT", BoFieldTypes.db_Alpha, 250, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");


            //Perfoma Invoice Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_SPT1", "Shipment tracking CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITEMCODE", "Item Code", "ITN_SPT1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DSCRIPTION", "Description", "ITN_SPT1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("QTY", "Quantity", "ITN_SPT1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("RATE", "RATE", "ITN_SPT1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CURR", "Currency", "ITN_SPT1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("AMT", "Amount", "ITN_SPT1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);

            //Perfoma Invoice Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_SPT2", "Shipment tracking CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRACD", "Tra Code", "ITN_SPT2", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CLRNCEDT", "Clearence DT", "ITN_SPT2", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "Remarks", "ITN_SPT2", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            Array.Resize(ref ChildTable, 2);
            ChildTable[0] = "ITN_SPT1";
            ChildTable[1] = "ITN_SPT2";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("OSPT", "Shipment Tracking", "ITN_OSPT", "N", FormCoumns, ChildTable);

            #endregion
            //Program.SBO_Application.StatusBar.SetText("Please wait while Generating UDF's and Generating tables.", SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITNPROV", "Province", BoUTBTableType.bott_Document);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CODE", "Code", "ITNPROV", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NAME", "Name", "ITNPROV", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            //if i dont pass docentry it gives me diffrent error // When using the Default Form fields, the first field should be the key field (AbsEntry/Code).
            Array.Resize(ref FormCoumns, 3);
            FormCoumns[0] = "DocEntry";
            FormCoumns[1] = "U_CODE";
            FormCoumns[2] = "U_NAME";
            //is mai jata hai 
            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("PROVINCE", "Province", "ITNPROVINCE", "Y", FormCoumns);
            CreateUDO("PROVINCE", "Province", "ITNPROV", FormCoumns, BoUDOObjType.boud_Document, "F");

            //District
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITNDIST", "District", BoUTBTableType.bott_Document);
            //FindColumns = new List<string>{"PRVNCCODE" , "Code" , "Name"};
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CODE", "Code", "ITNDIST", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NAME", "Name", "ITNDIST", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PRVNCODE", "Province Code", "ITNDIST", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            Array.Resize(ref FormCoumns, 4);
            FormCoumns[0] = "DocEntry";
            FormCoumns[1] = "U_CODE";
            FormCoumns[2] = "U_NAME";
            FormCoumns[3] = "U_PRVNCODE";
            CreateUDO("DISTRICT", "District", "ITNDIST", FormCoumns, BoUDOObjType.boud_Document, "F");


            //Town
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITNTOWN", "Town", BoUTBTableType.bott_Document);
            //FindColumns = new List<string> { "DISTCODE", "Code", "Name" };
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CODE", "Code", "ITNTOWN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NAME", "Name", "ITNTOWN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DISTCODE", "District Code", "ITNTOWN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            Array.Resize(ref FormCoumns, 4);
            FormCoumns[0] = "DocEntry";
            FormCoumns[1] = "U_CODE";
            FormCoumns[2] = "U_NAME";
            FormCoumns[3] = "U_DISTCODE";
            CreateUDO("ITNTOWN", "Town", "ITNTOWN", FormCoumns, BoUDOObjType.boud_Document, "F");

            //CUST CHANNEL CODE
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("CUSUBGP", "Customer Sub Channel", BoUTBTableType.bott_Document);
            //FindColumns = new List<string> { "DISTCODE", "Code", "Name" };
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CGRP", "customer group", "CUSUBGP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SUBCHCD", "Sub chanel code", "CUSUBGP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SUBCHNM", "sun channel nme", "CUSUBGP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PLCODE", "Price List Code", "CUSUBGP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PLNAME", "Price List Name", "CUSUBGP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            Array.Resize(ref FormCoumns, 6);
            FormCoumns[0] = "DocEntry";
            FormCoumns[1] = "U_CGRP";
            FormCoumns[2] = "U_SUBCHCD";
            FormCoumns[3] = "U_SUBCHNM";
            FormCoumns[4] = "U_PLCODE";
            FormCoumns[5] = "U_PLNAME";
            CreateUDO("CUSUBGP", "Customer Sub Channel", "CUSUBGP", FormCoumns, BoUDOObjType.boud_Document, "F");

            //CustomerSubGroup/Channel 
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITNSCHNL", "SubChannel", BoUTBTableType.bott_Document);
            ////FindColumns = new List<string> { "CUSTGRPCD", "Code", "Name" };
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CODE", "Code", "ITN_SCHNL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NAME", "Name", "ITN_SCHNL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            //Array.Resize(ref FormCoumns, 0);

            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSGRPCD", "Customer Grp Code", "ITN_SCHNL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("ITN_SCHNL", "SubChannel", "ITN_SCHNL", "N", FormCoumns); 
            //CreateUDO("ITN_SCHNL", "Town", "ITNTOWN", FormCoumns, BoUDOObjType.boud_Document, "F");

            #region OCRD udf
            //OCRD UDF
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PROVCD", "ProvinceCode", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DISTCD", "District Code", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOWNCD", "Town Code", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SCHANCD", "Sub Channel Code", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTCATE", "Customer Category", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ROSICUST", "Rosia Customer", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "", srt, "Y");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ROSIID", "Rosia Customer", "OCRD", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            #endregion

            #region OITM

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BRND", "BRAND", "OITM", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SUBBRND", "SUB BRAND", "OITM", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            #endregion

            #region credit limit
            //CreditLimit

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OCRN", "Credit Limit", BoUTBTableType.bott_Document);

            //CreditLimit Table Header Fileds

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CARDCODE", "Card Code", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CARDNAME", "Card Name", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ADDRE", "Addess", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUNIT", "Business Unit", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTCAT", "Customer Category", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRTOT", "GROSS TOT", "ITN_OCRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOLE", "Tolerence", "ITN_OCRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOPUP", "Top up", "ITN_OCRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOTCRLTM", "Total CR Limit", "ITN_OCRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOPUPVAL", "Top up validity", "ITN_OCRN", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DBBAL", "Debit Bal", "ITN_OCRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("AVACRLTM", "Available CR Limit", "ITN_OCRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "Prepared By", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("Remarks", "Remarks", "ITN_OCRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");



            //Credit Limit Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_CRN1", "Credit Limit CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DATE", "SYS DT", "ITN_CRN1", BoFieldTypes.db_Date, BoYesNoEnum.tYES, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GURANT", "Guarantor", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BRNCH", "Branch", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ADDERS", "Address", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUSS", "Business", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CATE", "Category", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CONCTNO", "Contact No", "ITN_CRN1", BoFieldTypes.db_Numeric, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Phone, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EMAIL", "EMAIL", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PARTY", "PARTY", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GARNNO", "Guarntee No", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EFFDT", "EFFective DT", "ITN_CRN1", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EXPDT", "Expiry DT", "ITN_CRN1", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CLMEXPDT", "Claim Expiry DT", "ITN_CRN1", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BGAMT", "BGAMT", "ITN_CRN1", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CRDAYS", "Credit Days", "ITN_CRN1", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOLERANCE", "Tolerance", "ITN_CRN1", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CRLMTAMT", "Credit LMT Amt", "ITN_CRN1", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARS", "Remarks", "ITN_CRN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ACT", "Active", "ITN_CRN1", BoFieldTypes.db_Alpha, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ATTCH", "Attchement", "ITN_CRN1", BoFieldTypes.db_Memo, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Link, true);


            Array.Resize(ref FormCoumns, 0);
            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_CRN1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("ITN_OCRN", "Credit Limit", "ITN_OCRN", "N", FormCoumns, ChildTable);

            //Credit limit log file.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("AITN_CRN", "Credit Limit Log", BoUTBTableType.bott_NoObject);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCNUM", "DocNumber", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LNID", "Line Id", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DATE", "SYS DT", "AITN_CRN", BoFieldTypes.db_Date, BoYesNoEnum.tYES, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GURANT", "Guarantor", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BRNCH", "Branch", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ADDERS", "Address", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUSS", "Business", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CATE", "Category", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CONCTNO", "Contact No", "AITN_CRN", BoFieldTypes.db_Numeric, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Phone, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EMAIL", "EMAIL", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PARTY", "PARTY", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GARNNO", "Guarntee No", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EFFDT", "EFFective DT", "AITN_CRN", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EXPDT", "Expiry DT", "AITN_CRN", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CLMEXPDT", "Claim Expiry DT", "AITN_CRN", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BGAMT", "BGAMT", "AITN_CRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CRDAYS", "Credit Days", "AITN_CRN", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TOLERANCE", "Tolerance", "AITN_CRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CRLMTAMT", "Credit LMT Amt", "AITN_CRN", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARS", "Remarks", "AITN_CRN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("STATUS", "STATUS", "AITN_CRN", BoFieldTypes.db_Alpha, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "Y", srt, "Y");


            #endregion

            #region Bill and Trade Discount
            //Bill and Trade Discount

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OBTD", "Bill_Trade DiscountMST", BoUTBTableType.bott_Document);

            //Bill and Trade Discount Table Header Fileds
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MITIDT", "Nepali Date", "ITN_OBTD", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "Prepared By", "ITN_OBTD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "Remarks", "ITN_OBTD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            //Bill and Trade Discount Limit Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_BTD1", "Bill_Trade DiscountCH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTCHN", "Customer Channel", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CHNCODE", "Channel Code", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTSUBCHN", "Customer SUB Channel", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUST", "Customer", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTNAME", "Customer Name", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUUNIT", "Business Unit", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CATE", "Category", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BRAND", "BRAND", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SKU", "SKU", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SKUNAME", "SKU Name", "ITN_BTD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BILLDISC", "BIll Discount", "ITN_BTD1", BoFieldTypes.db_Float, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRDDISC", "Trade Discount", "ITN_BTD1", BoFieldTypes.db_Float, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, true);
            
            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_BTD1";
            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("BillTRADE", "Bill and trade discount setup", "ITN_OBTD", "N", FormCoumns, ChildTable);
            //table registration 
            #endregion

            #region promotion Set Up
            //Promotion Setup 

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OPRO", "Promotion MST", BoUTBTableType.bott_Document);

            //Bill and Trade Discount Table Header Fileds
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PCODE", "PROMO Code", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PNAME", "PROMO NAME", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MITIDT", "MITI Date", "ITN_OPRO", BoFieldTypes.db_Date, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EFFFRMDT", "EFF FROM DATE", "ITN_OPRO", BoFieldTypes.db_Date, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EFFTODT", "EFF TO DATE", "ITN_OPRO", BoFieldTypes.db_Date, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PROMOTYPE", "PROMO TYPE", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MAINITM", "MAIN ITEM", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ALLOQTY", "ALLOCATION QUANTITY", "ITN_OPRO", BoFieldTypes.db_Float, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VPROMCD", "VENDOR PROMO CODE", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTCHNL", "CUSTOMER CHANNEL", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CSUBCHNL", "CUSTOMER SUB CHANNEL", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTOMER", "CUSTOMER", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ACTI", "ACTIVE", "ITN_OPRO", BoFieldTypes.db_Alpha, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CHECKBY", "CHECKED BY", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMKS1", "REMARKS1", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMKS2", "REMARKS2", "ITN_OPRO", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            //Bill and Trade Discount Limit Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_PRO1", "PROMOTION CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("APPTYPE", "APPLIED TYPE", "ITN_PRO1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("APPVAL", "APPLIED VALUE", "ITN_PRO1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PURFRMQTY", "PURCHASE FRM QTY", "ITN_PRO1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PURTOQTY", "PURCHASE TO QTY", "ITN_PRO1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INVDISC", "INVOICE DISC", "ITN_PRO1", BoFieldTypes.db_Numeric, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DISC", "DISCOUNT", "ITN_PRO1", BoFieldTypes.db_Numeric, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("FRITMSKU", "FREEITMSKU", "ITN_PRO1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("FREEQTY", "FREE QTY", "ITN_PRO1", BoFieldTypes.db_Float, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMKS", "REMARKS", "ITN_PRO1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ACTI", "ACTIVE", "ITN_PRO1", BoFieldTypes.db_Alpha, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            Array.Resize(ref FormCoumns, 0);
            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_PRO1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("ITN_OPRO", "Promotion SetUp", "ITN_OPRO", "N", FormCoumns, ChildTable);

            #endregion

            #region payment term Set Up
            //Payment terms

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OPAY", "PAYTERM MST", BoUTBTableType.bott_Document);

            //Payment terms Table Header Fileds
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUNIT", "BUSINESS UNIT", "ITN_OPAY", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OPAY", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CHECKBY", "CHECKED BY", "ITN_OPAY", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMKS", "REMARKS", "ITN_OPAY", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MITIDT", "Nepali Date", "ITN_OPAY", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);

            //Payment terms Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_PAY1", "PAYTERM CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTCODE", "CUSTOMER CODE", "ITN_PAY1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTNAME", "CUST NAME", "ITN_PAY1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PAYMTERMS", "PAYMENT TERMS", "ITN_PAY1", BoFieldTypes.db_Alpha, 150, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ACT", "ACTIVE", "ITN_PAY1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "", srt, "Y");

            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_PAY1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("PAYMENT", "Payment setup", "ITN_OPAY", "N", FormCoumns, ChildTable);

            #endregion

            #region ANUAL BUSINESS PLAN Set Up
            //Promotion Setup 

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OABP", "ANUAL BUSINESS PLN", BoUTBTableType.bott_Document);

            //Bill and Trade Discount Table Header Fileds
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("FINYEAR", "FINANCIAL YEAR", "ITN_OABP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BROWSE", "BROWSE", "ITN_OABP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OABP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CHECKBY", "CHECKED BY", "ITN_OABP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMKS", "REMARKS", "ITN_OABP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");


            //Bill and Trade Discount Limit Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_ABP1", "ANUAL BUSI PLN CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUSUNIT", "BUSINESS UNIT", "ITN_ABP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BRAND", "BRAND", "ITN_ABP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CATEGORY", "CATEGORY", "ITN_ABP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SUBGRP", "SUB GROUP", "ITN_ABP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SKU", "SKU", "ITN_ABP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LSTYRPLN", "LAST YEAR PLN", "ITN_ABP1", BoFieldTypes.db_Float, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GROWTH", "GROWTH", "ITN_ABP1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TARGET", "TARGET", "ITN_ABP1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);

            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_ABP1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("ITN_OABP", "ANUAL BUSINESS PLN", "ITN_OABP", "N", FormCoumns, ChildTable);
            #endregion

            #region ORDR udf
            ////OCRD UDF
            ////for  trade discount and its ammount to be applied at header level

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNTRDDIS", "Trade Discount %", "ORDR", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNTRDDISAM", "Trade Discount Amount", "ORDR", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNSPDIS", "Special Discount %", "ORDR", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNSPDISAM", "Special Discount Amount", "ORDR", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, false, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CRLIM", "Credit Limit", "ORDR", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PICKLIST", "Pick List", "ORDR", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUSUNIT", "Business Unit", "ORDR", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");


            //for appl promocode
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNPRODISPR", "Promotion Discount Percentage", "RDR1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Percentage, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNPRODISAM", "Promotion Discount Amount", "RDR1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, false, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNPROMOCD", "Promo Code", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNPARENTITM", "Parent Item", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNPROMOAPP", "Promo Applied", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            //for applied bill and trade discount
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBILLDISC", "Bill Disc Amount", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBTDAPP", "Bill Trade Disc Applied", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");


            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BIN", "Bin", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BATCHNO", "Batch No", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("QUANTITY", "Qunatity", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBATCH", "Batch", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBINLOC", "Bin Location", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNQTY", "Qunatity", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            #region
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBTDISCAPP", "Bill and trade Disc Applied", "RDR1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            #endregion

            #endregion

            #region ODLN udf
            //OCRD UDF
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNPIKEDBARCODE", "PICKED BAR CODE", "ODLN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");

            #endregion

            #region Gatepass

            //GatePass Master 
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OGTP", "GATE PASS MST", BoUTBTableType.bott_Document);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRASTYPE", "TRANSACTION TYPE", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REFDOCTY", "REF DOCUMENT", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REFBASDO", "REF BASE DOCUMENT", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REFBDOEN", "REF BASE DOCENTRY", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PARCODE", "PARTY CODE", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PARNAME", "PARTY NAME", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("WHSCODE", "WAREHOUSE CODE", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("WHSNAME", "WAREHOUSE NAME", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EXITDATE", "EXIT DATE", "ITN_OGTP", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EXITNPDT", "EXIT NEPALI DATE", "ITN_OGTP", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("EXITTIME", "EXITTIME", "ITN_OGTP", BoFieldTypes.db_Date, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Time, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INDATE", "IN DATE", "ITN_OGTP", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INNPDATE", "IN NEPALI DATE", "ITN_OGTP", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INTIME", "IN TIME", "ITN_OGTP", BoFieldTypes.db_Date, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Time, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GATENNUM", "GATE ENTRY NUM", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRASDETL", "TRANSPORT DETAILS", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VEHNUM", "VEHICLE NUM", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DRINAME", "DRIVER NAME", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CONTNUM", "CONTACT NUM", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "REMARKS", "ITN_OGTP", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            //GatePass Child
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_GTP1", "GATE PASS CHL", BoUTBTableType.bott_DocumentLines);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SELECT", "SELECT", "ITN_GTP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITEMCODE", "ITEM CODE", "ITN_GTP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NAME", "NAME", "ITN_GTP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("UOM", "UOM", "ITN_GTP1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("QUANTITY", "QUANTITY", "ITN_GTP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VALUE", "VALUE", "ITN_GTP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INEXTQTY", "IN/EXIT QTY", "ITN_GTP1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_GTP1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("OGTP", "GATE PASS", "ITN_OGTP", "N", FormCoumns, ChildTable);

            #endregion

            #region PickList
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OPCL", "PICK LIST MST", BoUTBTableType.bott_Document);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SONUM", "SALES ORDER NUM", "ITN_OPCL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SODOCEN", "SALES ORDER DOCENTRY", "ITN_OPCL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MITI", "NEPALI DATE", "ITN_OPCL", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUST", "CUSTOMER", "ITN_OPCL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BUSUNIT", "BUSUNIT", "ITN_OPCL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("AUTODEL", "AUTO DELIVERY", "ITN_OPCL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ATCHMENT", "ATTACHMENT", "ITN_OPCL", BoFieldTypes.db_Memo, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Link, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OPCL", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");


            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_PCL1", "PICK LIST CHL", BoUTBTableType.bott_DocumentLines);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SELECT", "SELECT", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITEMCODE", "ITEM CODE", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NAME", "NAME", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ODRQTY", "OREDER QTY", "ITN_PCL1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("WHSCODE", "WAREHOUSE CODE", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BATCH", "BATCH", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BIN", "BIN", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ALLQTY", "ALLOCATED QTY", "ITN_PCL1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DAMQTY", "DAMAGE/SHORTAGE QTY", "ITN_PCL1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PICKQTY", "PICKED QTY", "ITN_PCL1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PIWHSCOD", "PICKED WHSCODE", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PICKBTCH", "PICKED BATCH", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PICKBIN", "PICKED BIN", "ITN_PCL1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SCAN", "SCAN", "ITN_PCL1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");


            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_PCL1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("PICKLIST", "PICK LIST", "ITN_OPCL", "N", FormCoumns, ChildTable);

            #endregion

            #region PROOF OF DEL.

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OPOD", "PROF OF DEL MST", BoUTBTableType.bott_Document);

            //Proof of Delivery Table Header Fileds
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MITI", "NEPALI DATE", "ITN_OPOD", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTCODE", "CUSTOMER CODE", "ITN_OPOD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTNME", "CUSTOMER NAME", "ITN_OPOD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INVOICENO", "INVOICE NO", "ITN_OPOD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INVDATE", "INVOICE DATE", "ITN_OPOD", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("RECIVEDBY", "RECEIVED BY", "ITN_OPOD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("RECIVEDDT", "RECEIVED DATE", "ITN_OPOD", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OPOD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMKS", "REMARKS", "ITN_OPOD", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ATCHMENT", "ATTACHMENTS", "ITN_OPOD", BoFieldTypes.db_Memo, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Link, true, "");

            //Proof of Delivery Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_POD1", "PROF OF DEL CHL", BoUTBTableType.bott_DocumentLines);

            //Child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SKU", "SKU", "ITN_POD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DISCRPTN", "DISCRIPTION", "ITN_POD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INVQTY", "INVOICE QUANTITY", "ITN_POD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DMGQTY", "DAMAGE QUANTITY", "ITN_POD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SHRTGQTY", "SHORTAGE QUANTITY", "ITN_POD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "REMARKS", "ITN_POD1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_POD1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("PRFOFDEL", "PROOF OF DELIVERY", "ITN_OPOD", "N", FormCoumns, ChildTable);

            #endregion

            #region Anish for Purchase

            #region Provisional Cost

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OPRC", "Provisional Cost MST", BoUTBTableType.bott_Document);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCNUM", "DOCUMENT NUMBER", "ITN_OPRC", BoFieldTypes.db_Alpha, 5, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("MITI", "NEPALI DATE", "ITN_OPRC", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "PREPARED BY", "ITN_OPRC", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "REMARKS", "ITN_OPRC", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_PRC1", "PROVISIONAL COST CHL", BoUTBTableType.bott_DocumentLines);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITEMCODE", "ITEM CODE", "ITN_PRC1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITEMNAME", "ITEM NAME", "ITN_PRC1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LCCHRGE", "LC CHARGES", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("INSCHRGE", "INSURANCE CHARGES", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTDUTY", "CUSTOME DUTY", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CLRCSTKOL", "CLEARING COST KOLKATTA", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("UNLDEXP", "UNLOADING EXPENSES", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCHNCHRGE", "DOCUMNET HANDLING CHARGES", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ACPTCOST", "ACCEPTANCE COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("RTMTCOST", "RETIREMENT/SETTLEMENT COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CUSTRCOST", "INDIA/KOLKATTA-NEPAL CUSTOM TRANSPORT COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NPCLRCOST", "NEPAL CLEARING COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NPCUSTRCST", "NEPAL CUSTOM-UDN TRANSPORT COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DTNSNCST", "DETENSION COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DMRGECST", "DEMURRAGE COST KOLKATTA", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ADDCOST", "OTHER ADDITIONAL COST", "ITN_PRC1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Rate, true, "");


            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_PRC1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("OPRC", "PROVISIONAL COST", "ITN_OPRC", "N", FormCoumns, ChildTable);


            #endregion

            #region Perfoma Invoice
            //Perfoma Invoice
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OPIN", "Perfoma Invoice MST", BoUTBTableType.bott_Document);

            //Performa Invoice Table Header Fileds

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PONUM", "Purchase Order Number", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PURDATE", "Purchase Date ", "ITN_OPIN", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("NPDate", "Nepali Date ", "ITN_OPIN", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VCODE", "Vendor Code", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VNAME", " Vendor Name", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REFNUM", "Reference Number", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CURR", "Currency", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("IRNUM", "Insurance Reference Number", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TBDIS", "Total Before Discount", "ITN_OPIN", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DISC", "Discount", "ITN_OPIN", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TXC", "Tax Code", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TXAMT", "Tax Amount", "ITN_OPIN", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCTOTAL", "Document Total", "ITN_OPIN", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true, "");

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "Prepared By", "ITN_OPIN", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "Remarks", "ITN_OPIN", BoFieldTypes.db_Alpha, 250, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

            //Perfoma Invoice Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_PIN1", "Perfoma Invoice CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SKU", "Item Code", "ITN_PIN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DSCRIPTION", "Description", "ITN_PIN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("UOM", "Unit Of Measurement", "ITN_PIN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("UOMQTY", "Unit of Measurement Quantity", "ITN_PIN1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("QTY", "Quantity", "ITN_PIN1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("UNP", "Unit Price", "ITN_PIN1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LTXC", "Tax Code", "ITN_PIN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Phone, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LTAMT", "Tax Amount", "ITN_PIN1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LAMT", "Line Amount", "ITN_PIN1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PIQTY", "PROFORMA", "ITN_PIN1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("RMRKS", "Line Amount", "ITN_PIN1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            Array.Resize(ref ChildTable, 1);
            ChildTable[0] = "ITN_PIN1";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("OPIN", "Perfoma Invoice", "ITN_OPIN", "N", FormCoumns, ChildTable);
            #endregion

            #endregion

            #region Rushabh for purchase

            #region OBIN
            //for  trade discount and its ammount to be applied at header level
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNLEN", "Bin Lengh", "OBIN", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNWITH", "Bin Width", "OBIN", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNHIGT", "Bin Height", "OBIN", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");

            //for Calculation
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNTOTCAP", "Total Capacity", "OBIN", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNOCCU", "Occupied", "OBIN", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNAVAIL", "Available Capacity", "OBIN", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");


            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNDEFIGRP", "Default Item Group", "OBIN", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNALIGRP", "Alternative Item Group", "OBIN", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            #endregion

            #region BTN
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNABINCODE", "Allocated Bin Code", "OBTN", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNABINQTY", "Allocated Bin Qty", "OBTN", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBINALLO", "Bin to be Used", "PDN1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            //ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNBINALLOQTY", "Bin Quantity", "PDN1", BoFieldTypes.db_Float, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, false, "");
            #endregion

            #region OPDN
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNAPINV", "A/P Invoice", "OPDN", BoFieldTypes.db_Numeric, 11, BoYesNoEnum.tNO, BoFldSubTypes.st_None , false , "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITNAPINV", "A/P Invoice", "OPDN", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            #endregion

            #region Shipment Tracking
            //Shipment Tracking
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_OSPT", "Shipment tracking", BoUTBTableType.bott_Document);

            //Shipment Tracking Table Header Fileds

            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PODNUM", "Purchase Order Number", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PODENT", "Purchase Order DOCENTRY", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PODT", "PO Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("VCODE", "Vendor Code", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PERINVNO", "Performa Invoice NO", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PERDT", "Performa Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("COMINVNO", "Commercial Invoice NO", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("COMDT", "Commercial Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRPODNUM", "GRPO Doc Number", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRPODENT", "GRPO DOCENTRY", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("GRPODT", "GRPO Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BLDNUM", "BL DOCNUMBER", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BLDT", "BL Date ", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);                        
            
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SHNDT", "Ship Tra NEP Dt", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("SHDELNDT", "Ship Tra DEL NEP Dt", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRANME", "Transporter Name", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LRNO", "Lr No", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ETADTPA", "Est Dt Of Port Arr", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ETAHRPA", "Est Hour on Port Arr", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO , BoFldSubTypes.st_Time, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCRELDT", "Doc Release Dt", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("STATUS", "Status", "ITN_OSPT", BoFieldTypes.db_Alpha, 1, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LCDNUM", "LC DOCNUMBER", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("LCDT", "LC Date", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ORDOCRECBYBNK", "Original Doc Rec By Bnk", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("BNKCLDT", "Bank Clear Date", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PAYDATE", "PAYM Date", "ITN_OSPT", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DOCTOTAL", "Document Total", "ITN_OSPT", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("PREPBY", "Prepared By", "ITN_OSPT", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "Remarks", "ITN_OSPT", BoFieldTypes.db_Alpha, 250, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
            

            //Perfoma Invoice Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_SPT1", "Shipment tracking CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("ITEMCODE", "Item Code", "ITN_SPT1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("DSCRIPTION", "Description", "ITN_SPT1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("QTY", "Quantity", "ITN_SPT1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("RATE", "RATE", "ITN_SPT1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Quantity, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CURR", "Currency", "ITN_SPT1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("AMT", "Amount", "ITN_SPT1", BoFieldTypes.db_Float, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Price, true);

            //Perfoma Invoice Child table and Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddTable("ITN_SPT2", "Shipment tracking CH", BoUTBTableType.bott_DocumentLines);

            //child Fields.
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("TRACD", "Tra Code", "ITN_SPT2", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("CLRNCEDT", "Clearence DT", "ITN_SPT2", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
            ITNepal.MainLibrary.SAPB1.B1Helper.AddField("REMARKS", "Remarks", "ITN_SPT2", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

            Array.Resize(ref ChildTable, 2);
            ChildTable[0] = "ITN_PTN1";
            ChildTable[1] = "ITN_PTN2";

            ITNepal.MainLibrary.SAPB1.B1Helper.CreateUdo("OSPT", "Shipment Tracking", "ITN_OSPT", "N", FormCoumns, ChildTable);

            #endregion

            #endregion


            #region old Code
            ////For Goods Receipt
            //CreateColumn("OIGN", "MOPNO", "MOP Number", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("OIGN", "PLANT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("OIGN", "MACHINE", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("OIGN", "FRMDATE", "From Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("OIGN", "TODATE", "To Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("OIGN", "SHIFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("OIGN", "GROUP", "Group", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("OIGN", "WONO", "WO Number", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("OIGN", "TOTALMLDDCS", "Total Mould DCS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("OIGN", "TOTALMLDRS", "Total Mould RS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);


            //CreateTable("V_GO", "Grouping Outlet", BoUTBTableType.bott_NoObject);

            //CreateTable("V_VN", "Variety Name", BoUTBTableType.bott_NoObject);

            //CreateTable("DBCONFIG", "Database Configuration", BoUTBTableType.bott_NoObject);
            //CreateColumn("@DBCONFIG", "DB", "Data Base", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 1, "NY", "N");

            //CreateColumn("OITM", "Qty_M3", "QtyM3 pallet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //CreateColumn("OITM", "ISSREJECTABLE", "Iss Rejectable", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);

            //CreateColumn("OWOR", "MOPNO", "Mop Number", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "ITEMOCODE", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "ITEMNAME", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "PRODDT", "Production Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None, 10);
            //CreateColumn("OWOR", "SHIFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("OWOR", "MOULD", "Mould", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("OWOR", "QTYM3", "QTY M3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("OWOR", "UKRAN7", "UKRAN 7", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "UKRAN10", "UKRAN 10", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "UKRAN12", "UKRAN 12", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "UKRANLAIN", "UKRANLAIN", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "NOTES", "NOTES", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("OWOR", "SS", "SS Qty", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("OWOR", "GYPSUM", "Gypsum", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("OWOR", "DENSITY", "Density", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("OWOR", "PARIS", "Paris", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);

            //CreateColumn("OWOR", "BOMCODE", "Bom Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "BOMNAME", "Bom Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("OWOR", "PALLET", "Pallet", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);

            //#region code by Arvind bhai

            ////**marketing document
            ////CreateColumn("OPOR", "VPROJECTCODE", "Project Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VBLANKEDAGREEMENT", "Blanked Agreement", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VPAYMENTTYPE", "Payment Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VOUTLETNAME", "Outlet Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);

            ////CreateColumn("OPOR", "VSPSINTERNALNAME", "SPS Internal Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VGROUPTRANSPORTNAME", "Group Transport Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "VONKIREKSPEDISI", "Onkir Ekspedisi", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VPROVINSITUJUAN", "Provinsi Tujuan", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);


            ////CreateColumn("OPOR", "VAREATUJUAN", "Area Tujuan", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VKARESIDENANTUJUAN", "Karesidenan Tujuan", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "VKABUPATENTUJUAN", "Kabupaten Tujuan", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VKECAMATANTUJUAN", "Kecamatan Tujuan", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);

            ////CreateColumn("OPOR", "VKELURAHANTUJUAN", "Kelurahan Tujuan", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            ////CreateColumn("OPOR", "VJADWALKIRIM", "Jadwal Kirim", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "VTANGGALKIRIM", "Tanggal Kirim", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            ////CreateColumn("OPOR", "VTIPETANGGUNGAN", "Tipe Tanggungan", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None);
            ////CreateColumn("OPOR", "VGROUPTRANSPORTCODE", "Group Transport Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);

            //////*marketing row level
            ////CreateColumn("POR1", "VARIANTITEM", "Variant Item", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("POR1", "UNITPRICE", "Unit Price", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "MARGIN", "Margin", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "UNITPRICEAFTERMARGIN", "Unit Price After Margin", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);

            ////CreateColumn("POR1", "GROSSPRICE", "Gross Price", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "AMOUNTAFTERDISC2", "Amount After Disc2", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "TIPEPERCENTAGE3", "Tipe Percentage 3", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "ONGKIRM3", "Ongkir/m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);


            ////CreateColumn("POR1", "LOCCONET", "Locco Net", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "NOTES", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None,254);
            ////CreateColumn("POR1", "BADDEBTAMOUNT", "Bad Debt Amount", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_VERIANTITEM", "Veriant Item", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            ////CreateColumn("POR1", "V_UNITPRICE", "Unit Pirce", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "V_MARGIN", "Margin", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "V_UNITPRCAFTMRGN", "Unit Price After Margin", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "V_GROSSPRICE", "Gross Price", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "V_DISCOUNT1", "Discount 1", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_AMTAFTDISC1BTX", "Amt After Disc1 BTax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_AMTAFTDISC1ATX", "Amt After Disc1 ATax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_DISCOUNT2", "Discount 2", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_AMTAFTDISC2BTX", "Amt After Disc2 BTax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_AMTAFTDISC2ATX", "Amt After Disc2 ATax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_DISCOUNT3", "Discount 3", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_AMTAFTDISC3BTX", "Amt After Disc3 BTax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_AMTAFTDISC3ATX", "Amt After Disc3 ATax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_ONGKIR", "Ongkir or M3", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_LOCOPRCBTAX", "Loco Price BTax", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_TOPINTRNL", "Top Internal", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None);
            ////CreateColumn("POR1", "V_PALLET", "Pallet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("POR1", "V_PLTPRICE", "Pallet Price", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "V_INTRSTPRCNT", "Interest Percent", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_INTRSTAMT", "Interest  Amount", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_BADDBTPRCNT", "Bad Debt Percent", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_BADDBTAMT", "Bad Debt Amount", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_GASEPRCNT", "GA & SE Percent", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);
            ////CreateColumn("POR1", "V_GASEAMNT", "GA & SE Amount", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_OTHRFEE", "Other Fee", BoFieldTypes.db_Float, BoFldSubTypes.st_Sum);
            ////CreateColumn("POR1", "V_LOCONETT", "Loco Nett", BoFieldTypes.db_Float, BoFldSubTypes.st_Price);
            ////CreateColumn("POR1", "V_NOTE", "Note", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 254);
            //#endregion

            //#region code by Shweta

            ////**marketing S
            ////CreateColumn("OPOR", "WoNo", "Wo No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "ReqSparepartNo", "Request Sparepart No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            ////CreateColumn("OPOR", "Branch", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //////CreateColumn("OPOR", "PLANT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "PlantName", "Plant Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "Area", "Area", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "AreaName", "Area Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "EquipmentNo", "Equipment No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "EquipmentName", "Equipment Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "PartCode", "Part Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "PartName", "Part Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "ActivityCode", "Activity Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "ActivityName", "Activity Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            ////CreateColumn("OPOR", "MaintenanceType", "Maintenance Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            ////CreateColumn("OPOR", "Priority", "Priority", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "SummaryIssue", "Summary Issue", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            ////CreateColumn("OPOR", "ScheduleMaintenance", "Schedule Maintenance", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            ////CreateColumn("OPOR", "RequestBy", "Request By", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "Requestdate", "Request date", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "QtyUsage", "Qty Usage", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            ////CreateColumn("OPOR", "QtyReturn", "Qty Return", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            ////CreateColumn("OPOR", "QtyRepair", "Qty Repair", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            ////CreateColumn("OPOR", "DowntimeType", "Downtime Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "DowntimePlanFrom", "Downtime Plan From", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "DowntimePlanTo", "Downtime Plan To", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            ////CreateColumn("OPOR", "MaintenanceBy", "Bad Debt Amount", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            ////CreateColumn("OPOR", "MaintenanceDateFrom", "Maintenance Date From", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            ////CreateColumn("OPOR", "MaintenanceDateTo", "Maintenance Date To", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            ////CreateColumn("OPOR", "ActualDowntimeFrom ", "Actual Downtime From ", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None,80);
            ////CreateColumn("OPOR", "ActualDowntimeTo", "Actual Downtime To", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 70);
            //////CreateColumn("OPOR", "GROUP", "Group", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);


            ////CreateColumn("OPOR", "RootCause", "Root Cause", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 254);
            ////CreateColumn("OPOR", "Solution", "Solution", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 254);
            ////CreateColumn("OPOR", "PreventiveSteps", "Preventive Steps", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 254);
            ////CreateColumn("OPOR", "DetailIssue", "Detail Issue", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 254);
            //#endregion

            //#region Config Table
            //CreateTable("V_CONFIG", "Configuration Table", BoUTBTableType.bott_NoObject);
            //CreateColumn("@V_CONFIG", "DESCRIPTION", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("@V_CONFIG", "VALUE", "Value", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //#endregion

            //#region Master Plant Capacity

            //CreateTable("V_OMPC", "Master Plant Capacity", BoUTBTableType.bott_Document);

            //CreateColumn("@V_OMPC", "V_PCC", "Plant Capacity Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_OMPC", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OMPC", "V_PLTC", "Plant Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OMPC", "V_PLTN", "Plant Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OMPC", "V_MCHC", "Machine Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OMPC", "V_MCHN", "Machine Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OMPC", "V_MPM", "M3/mold", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OMPC", "V_CDMO", "Capacity day(Mould)", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OMPC", "V_CDM3", "Capacity day(M3)", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OMPC", "V_WHSC", "Whs Reject", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OMPC", "V_WHSN", "Whs Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OMPC", "V_STAT", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OMPC", "V_GPSMLD", "Gypsum_Mould", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OMPC", "V_GPSM3", "Gypsum_M3", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);

            //Array.Resize(ref ChildTable, 0);
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";

            //CreateObject("V_OMPC", "Master Plant Capacity", "V_OMPC", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");

            //#endregion

            //#region Master BOM
            //CreateTable("V_OBOM", "Master BOM Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_BOM1", "Master BOM Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_OBOM", "V_STAT", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OBOM", "V_BOMC", "BOM Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OBOM", "V_BOMN", "BOM Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OBOM", "V_QTY", "Quantity", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OBOM", "V_WHSC", "Warehouse", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_OBOM", "V_WHSEN", "Warehouse Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OBOM", "V_PLTC", "Plant Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_OBOM", "V_PLNM", "Plant Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_OBOM", "V_MCHC", "Machine Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_OBOM", "V_MCNM", "Machine Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_OBOM", "V_SERIES", "Series Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);

            //CreateColumn("@V_OBOM", "V_ISERIES", "Issue Series Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_OBOM", "V_RSERIES", "Recipt Series Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);


            //CreateColumn("@V_OBOM", "V_ISSS", "Is SS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_OBOM", "V_ISBOM", "Is BOM", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);

            //CreateColumn("@V_BOM1", "V_TYPE", "Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_BOM1", "V_COPC", "Component Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_BOM1", "V_COPN", "Component Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_BOM1", "V_QTY", "Quantity", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_BOM1", "V_UOM", "UoM", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_BOM1", "V_WHSC", "Whse", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_BOM1", "V_PLTC", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_BOM1", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 8);
            //CreateColumn("@V_BOM1", "V_ISSM", "Issue Method", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_BOM1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_OBOM", "Master BOM", "V_OBOM", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Marketing Order Production
            //CreateTable("V_OMOPL", "Marketing Order Plan Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_MOPL1", "Marketing Order Plan Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_OMOPL", "V_SERI", "Series", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OMOPL", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OMOPL", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OMOPL", "V_PLTC", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OMOPL", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15);
            //CreateColumn("@V_OMOPL", "V_PRF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_OMOPL", "V_PRT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_OMOPL", "V_STAT", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OMOPL", "V_CRDT", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_OMOPL", "V_PLCP", "Plant Capacity", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OMOPL", "V_TYPE", "Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OMOPL", "V_ISUSE", "Is Ussed", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);


            //CreateColumn("@V_MOPL1", "V_ITMC", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_MOPL1", "V_ITMN", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_MOPL1", "V_QTYM", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_MOPL1", "V_QTYP", "Qty Pallet", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_MOPL1", "V_RED", "Request Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_MOPL1", "V_REMA", "Remark", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_MOPL1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_OMOPL", "Marketing Order Plan", "V_OMOPL", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "Y");
            //#endregion

            //#region Master Group

            //CreateTable("V_OMG", "Master Group Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_MG1", "Master Group Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_MG1", "V_CODE", "Code", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None);
            //CreateColumn("@V_MG1", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_MG1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";

            //CreateObject("V_OMG", "Master Group", "V_OMG", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");

            //#endregion

            //#region Approval Receive For Production
            //CreateTable("V_ARP", "ARP Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_RP1", "ARP Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_RP2", "ARP2 Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);


            //CreateColumn("@V_ARP", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_ARP", "V_PLNT", "Plant Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_ARP", "V_MCHC", "Machine Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_ARP", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_ARP", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_ARP", "V_TNGL", "Tanggal", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_ARP", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_ARP", "V_GRP", "Group", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_ARP", "V_ITMCD1", "Item Code(1)", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_ARP", "V_ITMN1", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_ARP", "V_QTYR1", "Qantity Receive(1)", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_ARP", "V_ITMCD2", "Item Code(2)", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_ARP", "V_ITMDSC", "Item Desc", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_ARP", "V_QTYR2", "Qantity Receive(2)", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_ARP", "V_CRDT", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);

            //CreateColumn("@V_ARP", "V_STTS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_ARP", "V_RPFN", "RPF No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_ARP", "V_GRN", "GR No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_ARP", "V_HNOTS", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 90);

            //CreateColumn("@V_RP1", "V_ITCD1", "Item Code(1)", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_RP1", "V_DSCR1", "Description(1)", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RP1", "V_QTYP", "Quantity Pellet", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_RP1", "V_QTYM1", "Quantity m3(1)", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_RP1", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RP1", "V_PDODT", "PDO Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_RP1", "V_PDOFG", "PDO FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_RP2", "V_ITCD2", "Item Code(2)", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_RP2", "V_DSCR2", "Description(2)", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RP2", "V_QTYRC", "Qantity Receive", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_RP2", "V_NOTS", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 90);

            //Array.Resize(ref ChildTable, 2);
            //ChildTable[0] = "V_RP1";
            //ChildTable[1] = "V_RP2";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_ARP", "Approval Receive For Production", "V_ARP", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Master Shift
            //CreateTable("V_OMS", "Master Shift Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_MS1", "Master Shift Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_OMS", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OMS", "V_PLCD", "Plant Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OMS", "V_PLTN", "Plant Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OMS", "V_MCHC", "Machine Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OMS", "V_MCHN", "Machine Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OMS", "V_STST", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, "ACTIVE");

            //CreateColumn("@V_MS1", "V_CODE", "Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_MS1", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_MS1", "V_FROM", "From", BoFieldTypes.db_Date, BoFldSubTypes.st_Time);
            //CreateColumn("@V_MS1", "V_TO", "To", BoFieldTypes.db_Date, BoFldSubTypes.st_Time);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_MS1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_OMS", "Master Shift Header", "V_OMS", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Close MOP
            //CreateTable("V_CMOP", "Close MOP Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_MOP1", "Close MOP Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_CMOP", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CMOP", "V_STATS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CMOP", "V_DATE", "Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);

            //CreateColumn("@V_CMOP", "V_PLTC", "Plant Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CMOP", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CMOP", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_MOP1", "V_CHCK", "Check", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_MOP1", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_MOP1", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_MOP1", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_MOP1", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_MOP1", "V_CRDT", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_MOP1", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_MOP1", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_MOP1", "V_TYPE", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_MOP1", "V_STATS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_MOP1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_CMOP", "Close MOP MOHeader", "V_CMOP", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Issue and Receive Production SFG
            //CreateTable("V_IRPS", "IRP SFG Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_RPS1", "IRP1 SFG Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_RPS2", "IRP2 SFG Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_IRPS", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_IRPS", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_IRPS", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_IRPS", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_IRPS", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_IRPS", "V_TNGL", "Tanggal", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_IRPS", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_IRPS", "V_GRP", "Group", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_IRPS", "V_TMDCS", "Total Mold DCS", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity, 50);
            //CreateColumn("@V_IRPS", "V_TMRS", "Total Mold RS", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity, 50);
            //CreateColumn("@V_IRPS", "V_CDATE", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_IRPS", "V_RFPN", "Receive Prod. No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_IRPS", "V_STATUS", "Add Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_IRPS", "V_ISSSNO", "Issue SS No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_RPS1", "V_PDNN", "PDN No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_RPS1", "V_ITMSFG", "Item SFG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS1", "V_IDSC", "Item Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPS1", "V_QTYM3", "Quantity m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);

            //CreateColumn("@V_RPS1", "V_PNSS", "Pro No of SS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPS1", "V_PNSFG", "Pro No of SFG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPS1", "V_RFPSS", "Rec frm po DEnt", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPS1", "V_SSDOC", "SS DocEnt", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPS1", "V_SFGDOC", "SFG DEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //CreateColumn("@V_RPS2", "V_SS", "SS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_GMPNG", "Gamping", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_RPS2", "V_ALU", "ALU", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_LS", "LS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_AIR", "Air", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_IFPN", "Issue Prod. No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_IFPDN", "Issue Prod. DocNo", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_RS", "RS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPS2", "V_PSIRDOCEN", "Pasir Doc Entry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);


            //Array.Resize(ref ChildTable, 2);
            //ChildTable[0] = "V_RPS1";
            //ChildTable[1] = "V_RPS2";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_IRPS", "IRP SFG", "V_IRPS", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region List Approval From Production FG
            //CreateTable("V_LAFG", "LAP FG Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_AFG1", "LAP FG Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_LAFG", "V_STATS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_LAFG", "V_DATE", "Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_LAFG", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_AFG1", "V_ItmCode", "ItmCode", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_AFG1", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_AFG1", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_AFG1", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_AFG1", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_AFG1", "V_PRFT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_AFG1", "V_STTS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_AFG1", "V_APP", "Approval", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);


            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_AFG1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_LAFG", "LAP from FG", "V_LAFG", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Master BOM Group
            //CreateTable("V_MBG", "Master BOM Group Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_BG1", "Master BOM Group Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_MBG", "V_STATS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_MBG", "V_ITMCD", "Item code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_MBG", "V_ITMN", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_BG1", "V_BOMCD", "BOM Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_BG1", "V_BOMN", "BOM Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_BG1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_MBG", "Master BOM Group", "V_MBG", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Master Density Air
            //CreateTable("V_MDAR", "MD Air Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_DAR1", "MD Air Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_DAR1", "V_DNST", "Density", BoFieldTypes.db_Float, BoFldSubTypes.st_Measurement, 50);
            //CreateColumn("@V_DAR1", "V_PRCNT", "Percent", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage, 50);
            //CreateColumn("@V_DAR1", "V_ARKG", "Air Kg", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_DAR1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_MDAR", "MD Air", "V_MDAR", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Upload DCS
            //CreateTable("V_UDCS", "Upload DCS Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_DCS1", "Upload DCS Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_UDCS", "V_FILE", "File", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);


            //CreateColumn("@V_DCS1", "V_SS", "SS", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_DCS1", "V_GMPNG", "Gamping", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_DCS1", "V_ALU", "ALU", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_DCS1", "V_LS", "LS", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_DCS1", "V_RS", "RS", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_DCS1", "V_AIR", "Air", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_DCS1", "V_IFPN", "Issue For Prod. No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);

            //CreateColumn("@V_DCS1", "V_TGLCRT", "Tgl Create", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_DCS1", "V_JAMCRT", "Jam Create", BoFieldTypes.db_Date, BoFldSubTypes.st_Time);
            //CreateColumn("@V_DCS1", "V_PLANT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150);

            //CreateColumn("@V_DCS1", "V_SYSTS", "Status Sync", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_DCS1", "V_SYNDT", "Sync Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_DCS1", "V_SHIFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_DCS1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_UDCS", "Upload DCS", "V_UDCS", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Prod. Order Sch. Approval
            //CreateTable("V_POSA", "POSA Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_OSA1", "POSA1 Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_OSA2", "POSA2 Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_POSA", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_POSA", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_POSA", "V_STTS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //CreateColumn("@V_OSA1", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OSA1", "V_ITMDSC", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_OSA1", "V_QTYPLT", "Qty Pellet", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OSA1", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OSA1", "V_REQDT", "Request Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_OSA1", "V_RMRK", "Remarks", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);


            //CreateColumn("@V_OSA2", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OSA2", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_OSA2", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_OSA2", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_OSA2", "V_PODT", "POD Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_OSA2", "V_RMRK", "Remark", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);

            //Array.Resize(ref ChildTable, 2);
            //ChildTable[0] = "V_OSA1";
            //ChildTable[1] = "V_OSA2";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_POSA", "POS Approval", "V_POSA", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Master Config
            //CreateTable("V_MCON", "MConfg Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_CON1", "MConfg Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_CON1", "V_CNCD", "Config Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CON1", "V_CNDS", "Config Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_CON1", "V_VAL", "Value", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_CON1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_MCON", "MConfg", "V_MCON", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Print Prod. Plan
            //CreateTable("V_PPLN", "Prod. Plan Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_PLN1", "Prod. Plan Detail1", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_PLN2", "Prod. Plan Detail2", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_PLN3", "Prod. Plan Detail3", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_PLN4", "Prod. Plan Detail4", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_PPLN", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PPLN", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PPLN", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PPLN", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PPLN", "V_STTS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_PPLN", "V_QMSFG", "Qty Mold SFG", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PPLN", "V_QM3SFG", "Qty m3 SFG", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PPLN", "V_TNGL1", "Tanggal 1", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PPLN", "V_TNGL2", "Tanggal 2", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PPLN", "V_TNGL3", "Tanggal 3", BoFieldTypes.db_Date, BoFldSubTypes.st_None);

            //CreateColumn("@V_PLN1", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_MOLD", "Mould", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PLN1", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_UK7_5", "Uk 7.5", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_UK10", "Uk 10", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_UK12", "Uk 12", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_UKLN", "Uk Lain", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_NOTS", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_DUEDT", "Due Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PLN1", "V_WOSS", "WO SS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN1", "V_WOSFG", "WO SFG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_PLN2", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN2", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("@V_PLN2", "V_PLLT", "Pellet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_PLN2", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PLN2", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_PLN2", "V_NOTS", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN2", "V_DUEDT", "Due Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PLN2", "V_WOFG", "WO FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_PLN3", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN3", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("@V_PLN3", "V_PLLT", "Pellet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_PLN3", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PLN3", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_PLN3", "V_NOTS", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN3", "V_DUEDT", "Due Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PLN3", "V_WOFG", "WO FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_PLN4", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN4", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("@V_PLN4", "V_PLLT", "Pellet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_PLN4", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PLN4", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_PLN4", "V_NOTS", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PLN4", "V_DUEDT", "Due Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PLN4", "V_WOFG", "WO FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);


            //Array.Resize(ref ChildTable, 4);
            //ChildTable[0] = "V_PLN1";
            //ChildTable[1] = "V_PLN2";
            //ChildTable[2] = "V_PLN3";
            //ChildTable[3] = "V_PLN4";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_PPLN", "Print Pro. Plan", "V_PPLN", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Pro. Ord. Sch. Plan SFG-FG
            //CreateTable("V_PSPSF", "POSPlan SFG-FG Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_SPSF1", "PSPlan SFG-FG Detail1", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_SPSF2", "PSPlan SFG-FG Detail2", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_SPSF3", "PSPlan SFG-FG Detail3", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_PSPSF", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_PSPSF", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_PSPSF", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_MCHN", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PSPSF", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PSPSF", "V_STATS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_CRTD", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PSPSF", "V_TYPE", "Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_TM3MDP", "Tot m3 MDP", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PSPSF", "V_TQTYM3", "Tot Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PSPSF", "V_TMSFG", "Tot Mold SFG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_PSPSF", "V_PLCP", "Plant Capacity", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);


            //CreateColumn("@V_PSPSF", "V_ITMSFG", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_INMSFG", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_PSPSF", "V_PDSFG", "Production Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PSPSF", "V_SHFTSFG", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20);
            //CreateColumn("@V_PSPSF", "V_MLDSFG", "Mould", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_QM3SFG", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PSPSF", "V_UK7_5SFG", "Ukuran 7_5", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_UK10SFG", "Ukuran 10", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_UK12_5SFG", "Ukuran 12_5", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_UKLNSFG", "Ukuran Lain", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_NTSFG", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_PSPSF", "V_SSBSFG", "SS BOM", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_SSQTYSFG", "SS QTY", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_GPSMSFG", "Gypsum", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_DNSTSFG", "Density", BoFieldTypes.db_Float, BoFldSubTypes.st_Measurement, 50);
            //CreateColumn("@V_PSPSF", "V_PSRSFG", "pasir", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PSPSF", "V_ITMFG", "item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_ITNMFG", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_PSPSF", "V_PLNTFG", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_MCHNFG", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_BOMFG", "BOM Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_BOMNMFG", "BOM Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_PRDFG", "Production Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PSPSF", "V_SHFTFG", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);
            //CreateColumn("@V_PSPSF", "V_PLLTFG", "Pellet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PSPSF", "V_QM3FG", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PSPSF", "V_NTFG", "Notes FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //CreateColumn("@V_PSPSF", "V_AIRKG", "Air Kg", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PSPSF", "V_PRCNT", "Air Percent", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);

            //CreateColumn("@V_SPSF1", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF1", "V_ITMNM", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_SPSF1", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_SPSF1", "V_QTYPLLT", "Qty Pellet", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_SPSF1", "V_RQDT", "Request Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_SPSF1", "V_RMRK", "Remark", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);

            //CreateColumn("@V_SPSF2", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_MLDSFG", "Mould", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_SPSF2", "V_QM3SFG", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_SPSF2", "V_SHFTSFG", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_UK7_5SFG", "Ukuran 7_5", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_UK10SFG", "Ukuran 10", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_UK12_5SFG", "Ukuran 12_5", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_UKLNSFG", "Ukuran Lain", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_NTSFG", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_SPSF2", "V_WOSFGDD", "WO SFG Due Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_SPSF2", "V_WOSSSFG", "WO SS SFG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_WOSFG", "WO SFG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_RLSFG", "Release", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_PODDOCENT", "ProDocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_WOSSDOCEN", "WO SS DocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_SFGDOCEN", "WO SFG DocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_PLLNQTY", "Planned Qty", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_SSBOMCD", "SS BOM Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);


            //CreateColumn("@V_SPSF2", "V_DENS", "Density", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_SPSF2", "V_AIR", "Air", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);

            //CreateColumn("@V_SPSF2", "V_PRCNT", "Air Percent", BoFieldTypes.db_Float, BoFldSubTypes.st_Percentage);

            //CreateColumn("@V_SPSF2", "V_GYPSM", "Gypsum", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF2", "V_PASIR", "Pasir", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);


            //CreateColumn("@V_SPSF3", "V_ITMFG", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_INMFG", "Item Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 80);
            //CreateColumn("@V_SPSF3", "V_PLNTFG", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_MCHNFG", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_PLLTFG", "Pellet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_QTYM3FG", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_SPSF3", "V_SHFTFG", "Sift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_DDFG", "Due Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_SPSF3", "V_WOFG", "WO FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_RLZFG", "Release", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_PODDOCENT", "ProDocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_FGDOCEN", "FG DocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_FGBOC", "FG BomCode", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_SPSF3", "V_FGNOT", "FG Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //Array.Resize(ref ChildTable, 3);
            //ChildTable[0] = "V_SPSF1";
            //ChildTable[1] = "V_SPSF2";
            //ChildTable[2] = "V_SPSF3";

            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";

            //CreateObject("V_PSPSF", "POSPlan SFG-FG", "V_PSPSF", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");

            //#endregion

            //#region Receive From Prod. FG
            //CreateTable("V_RPFG", "RFPFG Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_PFG1", "RFPFG Detail1", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            //CreateTable("V_PFG2", "RFPFG Detail2", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_RPFG", "V_MOPN", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_PLNT", "Plant", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_RPFG", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_RPFG", "V_TNGL", "Tanggal", BoFieldTypes.db_Date, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_SHFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_GRP", "Group", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_QTYRC", "Qty Receive", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_CRDT", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_RPFG", "V_ITCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_IDESC", "Item Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPFG", "V_QTRCV", "Qty Receive", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_MOPTY", "MOP Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_RPFG", "V_STTS", "Status", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_RPFN", "RPF No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_RPFG", "V_NOTS", "Nots", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150);
            //CreateColumn("@V_RPFG", "V_GRNO", "GR No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_RPFG", "V_FLG", "Flag", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("@V_RPFG", "V_IRPOSTDT", "IR Posting DT", BoFieldTypes.db_Date, BoFldSubTypes.st_None);

            //CreateColumn("@V_PFG1", "V_QTYPLT", "Qty Pellet", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PFG1", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PFG1", "V_PDODT", "PDO Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_PFG1", "V_PDOFG", "PDO FG", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PFG1", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PFG1", "V_IDESC", "Item Desc", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("@V_PFG1", "V_FGDOCEN", "FG DocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 30);


            //CreateColumn("@V_PFG2", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_PFG2", "V_DESC", "Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_PFG2", "V_QTYM3", "Qty m3", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_PFG2", "V_NOTES", "Notes", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150);

            //Array.Resize(ref ChildTable, 2);
            //ChildTable[0] = "V_PFG1";
            //ChildTable[1] = "V_PFG2";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";

            //CreateObject("V_RPFG", "Rec. Prod. FG", "V_RPFG", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region Close Production Order SFG & FG
            //CreateTable("V_CPOSFG", "CPO SFG Header", SAPbobsCOM.BoUTBTableType.bott_Document);
            //CreateTable("V_POSFG1", "CPO SFG  Detail", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

            //CreateColumn("@V_CPOSFG", "V_MOPNO", "MOP No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CPOSFG", "V_PLTC", "Plant Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CPOSFG", "V_BRAN", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CPOSFG", "V_MCHC", "Machine", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CPOSFG", "V_PRDF", "Period From", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_CPOSFG", "V_PRDT", "Period To", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_CPOSFG", "V_TYPE", "Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CPOSFG", "V_SHIFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_CPOSFG", "V_TANGL", "Tanggle", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_CPOSFG", "V_CRDT", "Create Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);

            //CreateColumn("@V_POSFG1", "V_CHCK", "Check", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_POSFG1", "V_PDNNO", "Production No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100);
            //CreateColumn("@V_POSFG1", "V_ITMCD", "Item Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_POSFG1", "V_ITMDESC", "Item Description", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 200);
            //CreateColumn("@V_POSFG1", "V_QTY", "Qauntity", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity);
            //CreateColumn("@V_POSFG1", "V_SHIFT", "Shift", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);
            //CreateColumn("@V_POSFG1", "V_PDODT", "PDO Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None);
            //CreateColumn("@V_POSFG1", "V_PDODOCEN", "PDO DocEntry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //Array.Resize(ref ChildTable, 1);
            //ChildTable[0] = "V_POSFG1";
            //Array.Resize(ref FindColoum, 1);
            //FindColoum[0] = "DocNum";
            //CreateObject("V_CPOSFG", "CPO SFG", "V_CPOSFG", ChildTable, FindColoum, SAPbobsCOM.BoUDOObjType.boud_Document, "N");
            //#endregion

            //#region System FLd

            //CreateColumn("OITM", "V_PALLETCONV", "Pallet Qty", BoFieldTypes.db_Float, BoFldSubTypes.st_Quantity, 10);


            //CreateColumn("OCRD", "V_GO", "Grouping Outlet", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50);

            //CreateColumn("OITM", "V_VN", "Variety Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150);

            //#endregion

            //# region Customer Mapping

            //CreateTable("T_MOH", "Customer Mapping", BoUTBTableType.bott_MasterData);
            //CreateColumn("@T_MOH", "PROJECT", "Project", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 3, "NY1", "NO");
            //CreateColumn("@T_MOH", "RETAIL", "Retail", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 3, "NY1", "NO");
            //CreateColumn("@T_MOH", "KHUSUS", "Khusus", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 3, "NY1", "NO");

            //string[] FormColoums = new string[5];
            //FormColoums[0] = "Code";
            //FormColoums[1] = "Name";
            //FormColoums[2] = "U_PROJECT";
            //FormColoums[3] = "U_RETAIL";
            //FormColoums[4] = "U_KHUSUS";

            //CreateUDO("T_MOH", "Customer Mapping", "T_MOH", FormColoums, SAPbobsCOM.BoUDOObjType.boud_MasterData, "N");
            //#endregion

            //CreateTable("NOTES", "Notes for FG", SAPbobsCOM.BoUTBTableType.bott_MasterData);
            //Array.Resize(ref ChildTable, 0);

            //Array.Resize(ref FindColoum, 0);
            //FormColoums = new string[0];
            //CreateUDO("NOTES", "Notes for FG", "NOTES", FormColoums, SAPbobsCOM.BoUDOObjType.boud_MasterData, "N", true); 
            #endregion


        }

        //public string FindFile()
        //{
        //    System.Threading.Thread ShowFolderBrowserThread = null;
        //    try
        //    {
        //        ShowFolderBrowserThread = new System.Threading.Thread(ShowFolderBrowser);
        //        if (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Unstarted)
        //        {
        //            ShowFolderBrowserThread.SetApartmentState(System.Threading.ApartmentState.STA);
        //            ShowFolderBrowserThread.Start();
        //            ShowFolderBrowserThread.Join();
        //        }
        //        else if (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Stopped)
        //        {
        //            ShowFolderBrowserThread.Start();
        //            ShowFolderBrowserThread.Join();

        //        }
        //        Thread.Sleep(5000);
        //        while (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Running)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //        }
        //        if (!string.IsNullOrEmpty(FileName))
        //        {
        //            return FileName;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oApplication.MessageBox("FileFile" + ex.Message);
        //    }
        //    return "";
        //}

        //public string SaveFile(string defName)
        //{

        //    defFileName = defName;
        //    System.Threading.Thread ShowFolderBrowserThread = null;
        //    try
        //    {
        //        ShowFolderBrowserThread = new System.Threading.Thread(SaveFileBrowser);

        //        if (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Unstarted)
        //        {
        //            ShowFolderBrowserThread.SetApartmentState(System.Threading.ApartmentState.STA);
        //            ShowFolderBrowserThread.Start();
        //        }
        //        else if (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Stopped)
        //        {
        //            ShowFolderBrowserThread.Start();
        //            ShowFolderBrowserThread.Join();
        //        }
        //        Thread.Sleep(5000);

        //        while (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Running)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //        }
        //        if (!string.IsNullOrEmpty(FileName))
        //        {
        //            return FileName;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oApplication.MessageBox("FileFile" + ex.Message);
        //    }
        //    return "";
        //}

        //public void ShowFolderBrowser()
        //{
        //    System.Diagnostics.Process[] MyProcs = null;
        //    dynamic UserName = Environment.UserName;

        //    FileName = "";
        //    OpenFileDialog OpenFile = new OpenFileDialog();

        //    try
        //    {
        //        OpenFile.Multiselect = false;
        //        OpenFile.Filter = "All files(*.)|*.*";
        //        int filterindex = 0;
        //        try
        //        {
        //            filterindex = 0;
        //        }
        //        catch
        //        {
        //        }

        //        OpenFile.FilterIndex = filterindex;

        //        OpenFile.RestoreDirectory = true;
        //        MyProcs = System.Diagnostics.Process.GetProcessesByName("SAP Business One");

        //        for (int i = 0; i <= MyProcs.GetLength(0); i++)
        //        {

        //            if (GetProcessUserName(MyProcs[i]) == UserName)
        //            {
        //                goto NEXT_STEP;
        //            }
        //        }
        //        oApplication.MessageBox("Unable to determine Running processes by UserName!");
        //        OpenFile.Dispose();
        //        GC.Collect();
        //        return;
        //    NEXT_STEP:
        //        if (MyProcs.Length == 1)
        //        {

        //            for (int i = 0; i <= MyProcs.Length - 1; i++)
        //            {
        //                WindowWrapper MyWindow = new WindowWrapper(MyProcs[i].MainWindowHandle);
        //                DialogResult ret = OpenFile.ShowDialog(MyWindow);

        //                if (ret == DialogResult.OK)
        //                {
        //                    FileName = OpenFile.FileName;
        //                    OpenFile.Dispose();
        //                }
        //                else
        //                {
        //                    System.Windows.Forms.Application.ExitThread();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            oApplication.MessageBox("More than 1 SAP B1 is started!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oApplication.StatusBar.SetText(ex.Message);
        //        FileName = "";
        //    }
        //    finally
        //    {
        //        OpenFile.Dispose();
        //        GC.Collect();
        //    }

        //}

        //public void SaveFileBrowser()
        //{
        //    System.Diagnostics.Process[] MyProcs = null;
        //    dynamic UserName = Environment.UserName;

        //    FileName = "";
        //    SaveFileDialog saveFile = new SaveFileDialog();
        //    saveFile.FileName = defFileName;
        //    try
        //    {
        //        MyProcs = System.Diagnostics.Process.GetProcessesByName("SAP Business One");

        //        for (int i = 0; i <= MyProcs.GetLength(1); i++)
        //        {
        //            if (GetProcessUserName(MyProcs[i]) == UserName)
        //            {
        //                goto NEXT_STEP;
        //            }
        //        }
        //        oApplication.MessageBox("Unable to determine Running processes by UserName!");
        //        saveFile.Dispose();
        //        GC.Collect();
        //        return;
        //    NEXT_STEP:
        //        if (MyProcs.Length == 1)
        //        {

        //            for (int i = 0; i <= MyProcs.Length - 1; i++)
        //            {
        //                WindowWrapper MyWindow = new WindowWrapper(MyProcs[i].MainWindowHandle);
        //                DialogResult ret = saveFile.ShowDialog(MyWindow);

        //                if (ret == DialogResult.OK)
        //                {
        //                    FileName = saveFile.FileName;
        //                    saveFile.Dispose();
        //                }
        //                else
        //                {
        //                    System.Windows.Forms.Application.ExitThread();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            oApplication.MessageBox("More than 1 SAP B1 is started!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oApplication.StatusBar.SetText(ex.Message);
        //        FileName = "";
        //    }
        //    finally
        //    {
        //        saveFile.Dispose();
        //        GC.Collect();
        //    }
        //}

        //private string GetProcessUserName(System.Diagnostics.Process Process)
        //{
        //    string strResult = "";
        //    return strResult;
        //}

        //# region Create DataBase

        //private bool CreateTable(string TableName, string TableDesc, SAPbobsCOM.BoUTBTableType TableType)
        //{
        //    SAPbobsCOM.UserTablesMD oUserTablesMD = default(SAPbobsCOM.UserTablesMD);
        //    try
        //    {
        //        oUserTablesMD = (SAPbobsCOM.UserTablesMD)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables);
        //        if (oUserTablesMD.GetByKey(TableName) == true)
        //        {
        //            return true;
        //        }
        //        oUserTablesMD.TableName = TableName;
        //        oUserTablesMD.TableDescription = TableDesc;
        //        oUserTablesMD.TableType = TableType;
        //        RetCode = oUserTablesMD.Add();
        //        if (RetCode != 0)
        //        {
        //            oCompany.GetLastError(out RetCode, out ErrMsg);
        //            Program.SBO_Application.StatusBar.SetText("Table Failed : " + ErrMsg + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //        }
        //        else
        //        {
        //            Program.SBO_Application.StatusBar.SetText("Table Created : " + TableDesc + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserTablesMD);
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //}

        //private bool CreateColumn(string TableName, string FieldName, string FieldDesc, SAPbobsCOM.BoFieldTypes FieldType, SAPbobsCOM.BoFldSubTypes FieldSubType, int FieldSize = 0, string ValidValues = null, string DefaultVal = null)
        //{
        //    SAPbobsCOM.UserFieldsMD oUserFieldsMD = default(SAPbobsCOM.UserFieldsMD);
        //    try
        //    {
        //        oUserFieldsMD = ((SAPbobsCOM.UserFieldsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields)));
        //        if (FieldExist(TableName, FieldName) == false)
        //        {
        //            oUserFieldsMD.TableName = TableName;
        //            oUserFieldsMD.Name = FieldName;
        //            oUserFieldsMD.Description = FieldDesc;

        //            oUserFieldsMD.Type = FieldType;
        //            oUserFieldsMD.SubType = FieldSubType;
        //            oUserFieldsMD.EditSize = FieldSize;

        //            if (FieldName == "V_GO")
        //            {
        //                oUserFieldsMD.LinkedTable = "V_GO";
        //            }
        //            if (FieldName == "V_VN")
        //            {
        //                oUserFieldsMD.LinkedTable = "V_VN";
        //            }



        //            if (ValidValues != "")
        //            {
        //                switch (ValidValues)
        //                {
        //                    case "NY":
        //                        oUserFieldsMD.ValidValues.Value = "Y";
        //                        oUserFieldsMD.ValidValues.Description = "Yes";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        oUserFieldsMD.ValidValues.Value = "N";
        //                        oUserFieldsMD.ValidValues.Description = "No";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        //oUserFieldsMD.DefaultValue = "N";
        //                        break;
        //                    case "NY1":
        //                        oUserFieldsMD.ValidValues.Value = "YES";
        //                        oUserFieldsMD.ValidValues.Description = "YES";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        oUserFieldsMD.ValidValues.Value = "NO";
        //                        oUserFieldsMD.ValidValues.Description = "NO";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        //oUserFieldsMD.DefaultValue = "N";
        //                        break;
        //                    case "PLAN":
        //                        oUserFieldsMD.ValidValues.Value = "Fixed";
        //                        oUserFieldsMD.ValidValues.Description = "Fixed";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        oUserFieldsMD.ValidValues.Value = "%";
        //                        oUserFieldsMD.ValidValues.Description = "%";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        //oUserFieldsMD.DefaultValue = "%";
        //                        break;
        //                    case "MB":
        //                        oUserFieldsMD.ValidValues.Value = "M";
        //                        oUserFieldsMD.ValidValues.Description = "Manual";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        oUserFieldsMD.ValidValues.Value = "B";
        //                        oUserFieldsMD.ValidValues.Description = "Backflush";
        //                        oUserFieldsMD.ValidValues.Add();

        //                        //oUserFieldsMD.DefaultValue = "%";
        //                        break;

        //                }
        //            }
        //            if (DefaultVal != "")
        //            {
        //                oUserFieldsMD.DefaultValue = DefaultVal;
        //            }
        //            RetCode = oUserFieldsMD.Add();
        //            if (RetCode != 0)
        //            {
        //                if (RetCode == -2035 || RetCode == -1120)
        //                {
        //                    return false;
        //                }
        //                else
        //                {
        //                    oCompany.GetLastError(out RetCode, out ErrMsg);
        //                    Program.SBO_Application.SetStatusBarMessage("Error : " + ErrMsg, SAPbouiCOM.BoMessageTime.bmt_Short, false);
        //                }
        //            }
        //            else
        //            {
        //                Program.SBO_Application.SetStatusBarMessage("Field Created in : " + TableName + " As : " + FieldDesc, SAPbouiCOM.BoMessageTime.bmt_Short, false);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //}

        //private bool CreateObject(string CodeID, string Name, string TableName, string[] ChildTableName, string[] FindColoums, SAPbobsCOM.BoUDOObjType ObjectType, string ManageSeries)
        //{
        //    SAPbobsCOM.UserObjectsMD oUserObjectMD = default(SAPbobsCOM.UserObjectsMD);
        //    try
        //    {
        //        oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));
        //        if (oUserObjectMD.GetByKey(CodeID) == true)
        //        {
        //            return true;
        //        }
        //        oUserObjectMD.Code = CodeID;
        //        oUserObjectMD.Name = Name;
        //        oUserObjectMD.TableName = TableName;

        //        oUserObjectMD.ObjectType = ObjectType;
        //        oUserObjectMD.CanCancel = SAPbobsCOM.BoYesNoEnum.tYES;
        //        oUserObjectMD.CanClose = SAPbobsCOM.BoYesNoEnum.tNO;
        //        oUserObjectMD.CanDelete = SAPbobsCOM.BoYesNoEnum.tNO;
        //        oUserObjectMD.CanLog = SAPbobsCOM.BoYesNoEnum.tNO;
        //        oUserObjectMD.CanFind = SAPbobsCOM.BoYesNoEnum.tYES;

        //        if (ManageSeries == "Y")
        //        {
        //            oUserObjectMD.ManageSeries = SAPbobsCOM.BoYesNoEnum.tYES;
        //        }
        //        else
        //        {
        //            oUserObjectMD.ManageSeries = SAPbobsCOM.BoYesNoEnum.tNO;
        //        }

        //        if (ChildTableName != null)
        //        {
        //            for (int i = 0; i <= ChildTableName.Length - 1; i++)
        //            {
        //                if (ChildTableName[i].Trim() != string.Empty)
        //                {
        //                    oUserObjectMD.ChildTables.TableName = ChildTableName[i];
        //                    oUserObjectMD.ChildTables.Add();
        //                }
        //            }
        //        }
        //        if (FindColoums != null)
        //        {
        //            //oUserObjectMD.CanFind = SAPbobsCOM.BoYesNoEnum.tYES;
        //            for (int i = 0; i <= FindColoums.Length - 1; i++)
        //            {
        //                if (FindColoums[i].Trim() != string.Empty)
        //                {
        //                    oUserObjectMD.FindColumns.ColumnAlias = FindColoums[i];
        //                    oUserObjectMD.FindColumns.Add();
        //                }
        //            }
        //        }
        //        RetCode = oUserObjectMD.Add();

        //        if (RetCode != 0)
        //        {
        //            if (RetCode != -1)
        //            {
        //                Program.oCompany.GetLastError(out RetCode, out ErrMsg);
        //                Program.SBO_Application.StatusBar.SetText("Object Failed : " + ErrMsg + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //            }
        //        }
        //        else
        //        {
        //            Program.SBO_Application.StatusBar.SetText("Object Registered : " + Name + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
        //        }
        //        catch
        //        { }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //}

        ////private bool CreateUDO(string CodeID, string Name, string TableName, string[] FormColoums, SAPbobsCOM.BoUDOObjType ObjectType, string ManageSeries, bool defaultForm = false)
        ////{
        ////    SAPbobsCOM.UserObjectsMD oUserObjectMD = default(SAPbobsCOM.UserObjectsMD);
        ////    try
        ////    {
        ////        oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));
        ////        if (oUserObjectMD.GetByKey(CodeID) == true)
        ////        {
        ////            return true;
        ////        }
        ////        oUserObjectMD.Code = CodeID;
        ////        oUserObjectMD.Name = Name;
        ////        oUserObjectMD.TableName = TableName;
        ////        oUserObjectMD.ObjectType = ObjectType;

        ////        oUserObjectMD.CanCreateDefaultForm = SAPbobsCOM.BoYesNoEnum.tYES;
        ////        oUserObjectMD.EnableEnhancedForm = SAPbobsCOM.BoYesNoEnum.tNO;
        ////        oUserObjectMD.MenuItem = SAPbobsCOM.BoYesNoEnum.tYES;
        ////        oUserObjectMD.MenuCaption = Name;
        ////        oUserObjectMD.FatherMenuID = 43523;
        ////        oUserObjectMD.Position = 3;
        ////        oUserObjectMD.MenuUID = CodeID;

        ////        if (FormColoums != null)
        ////        {
        ////            for (int i = 0; i <= FormColoums.Length - 1; i++)
        ////            {
        ////                if (FormColoums[i].Trim() != "U_RUNDB")
        ////                {
        ////                    oUserObjectMD.FormColumns.FormColumnAlias = FormColoums[i];
        ////                    oUserObjectMD.FormColumns.Editable = SAPbobsCOM.BoYesNoEnum.tNO;
        ////                    oUserObjectMD.FormColumns.Add();
        ////                }
        ////                else
        ////                {
        ////                    oUserObjectMD.FormColumns.FormColumnAlias = FormColoums[i];
        ////                    oUserObjectMD.FormColumns.Editable = SAPbobsCOM.BoYesNoEnum.tYES;
        ////                    oUserObjectMD.FormColumns.Add();
        ////                }
        ////            }
        ////        }
        ////        if (defaultForm)
        ////        {
        ////            oUserObjectMD.CanCreateDefaultForm = BoYesNoEnum.tYES;
        ////        }
        ////        // check for errors in the process
        ////        RetCode = oUserObjectMD.Add();

        ////        if (RetCode != 0)
        ////        {
        ////            if (RetCode != -1)
        ////            {
        ////                Program.oCompany.GetLastError(out RetCode, out ErrMsg);
        ////                Program.SBO_Application.StatusBar.SetText("Object Failed : " + ErrMsg + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        ////            }
        ////        }
        ////        else
        ////        {
        ////            Program.SBO_Application.StatusBar.SetText("Object Registered : " + Name + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        ////        }
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////    finally
        ////    {
        ////        try
        ////        {
        ////            System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
        ////        }
        ////        catch
        ////        { }
        ////        GC.Collect();
        ////        GC.WaitForPendingFinalizers();
        ////    }
        ////}

        //private bool FieldExist(string TableName, string ColumnName)
        //{
        //    rec = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //    try
        //    {
        //        rec.DoQuery("SELECT COUNT(*) FROM CUFD WHERE \"TableID\" = '" + TableName + "' AND \"AliasID\" = '" + ColumnName + "'");
        //        if ((Convert.ToInt32(rec.Fields.Item(0).Value) == 0))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(rec);
        //    }
        //}

        //#endregion

        #region FMS Code

        //*** return the query Id if new then otherwise  > 0
        public static int GetUserQueryID(string name)
        {
            // Creates a new User Query if the name specified does not exist
            // Returns the Internal Key ID of the Query

            int queryID = 0;

            #region Lookup Query Name and Get ID if exists

            Recordset oRecordset = (Recordset)Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            try
            {
                // string sql = "SELECT \"IntrnalKey\" FROM \"OUQR\" WHERE \"QName\" = '" + name + "'";

                string sql = @"Select  U_V_ARKG,U_V_DNST , U_V_PRCNT  from ""@V_MDAR"" T0 Inner Join ""@V_DAR1"" T1 on T0.""DocEntry"" = T1.""DocEntry""  Where T0.""DocEntry"" = '1'";

                oRecordset.DoQuery(sql);
                if (!oRecordset.EoF)
                {
                    // Return query ID as it already exists
                    return Convert.ToInt32(oRecordset.Fields.Item("intrnalkey").Value);
                }
            }
            catch (Exception ex)
            {
                Program.SBO_Application.SetStatusBarMessage("Error retrieving query from OUQR " + ex.Message);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
            }

            #endregion

            // Garbage Collection
            GC.Collect();

            return queryID;
        }
        ////
        public int CreateUserQuery(string name, string sql, int queryCategoryId)
        {
            // Check if query name exists first
            int queryId = GetUserQueryID(name);
            bool Exists;
            // Create if query doesn't exist
            if (queryId == 0)
            {
                SAPbobsCOM.UserQueries userQuery = (SAPbobsCOM.UserQueries)Program.oCompany.GetBusinessObject(BoObjectTypes.oUserQueries);
                try
                {
                    // Create new Query
                    userQuery.QueryType = UserQueryTypeEnum.uqtWizard;
                    userQuery.QueryCategory = queryCategoryId;
                    userQuery.QueryDescription = name;
                    userQuery.Query = sql;
                    int ret = userQuery.Add();

                    if (ret == 0)
                    {
                        queryId = GetUserQueryID(name);
                        //**** Not Exist Query
                        Exists = true;
                        return queryId;
                    }
                }
                catch (Exception ex)
                {
                    Program.SBO_Application.SetStatusBarMessage("Error in user defined query routine: " + ex.Message);
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userQuery);
                }
            }

            else
            {
                Exists = false;
            }
            return queryId;
        }

        public void AssignQuery(int queryId, string formId, string itemId, string column = "-1")
        {
            // This will assign a query to a form item & column 
            // This will reassign a query to an item that already has a query assigned
            // CSHS Table = User Defined Values Table

            SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            try
            {
                // Validate query exists
                oRecordSet.DoQuery("SELECT \"IntrnalKey\", \"QName\" FROM \"OUQR\" WHERE \"IntrnalKey\" = " + queryId);
                bool queryExists = false;
                if (!oRecordSet.EoF)
                {
                    queryExists = true;
                }
                else
                {
                    Program.SBO_Application.SetStatusBarMessage("Error query ID + " + queryId + " doesn't exist");
                }

                if (queryExists)
                {
                    // Values Example
                    //string form = "VoucherCodes.Form1";
                    //string item = "PMatrix";
                    //string column = "PName";  // Matrix Column Name 

                    // Get UDV For Form Item
                    oRecordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    oRecordSet.DoQuery("SELECT \"IndexID\" FROM \"CSHS\" WHERE \"FormID\" = '" + formId + "' AND \"ItemID\" = '" + itemId + "' AND \"ColID\" = '" + column + "'");
                    if (!oRecordSet.EoF)
                    {
                        #region Update Existing

                        SAPbobsCOM.FormattedSearches fms = (SAPbobsCOM.FormattedSearches)Program.oCompany.GetBusinessObject(BoObjectTypes.oFormattedSearches);
                        fms.GetByKey(Convert.ToInt32(oRecordSet.Fields.Item("IndexID").Value));
                        fms.Action = BoFormattedSearchActionEnum.bofsaQuery;
                        fms.FormID = formId;
                        fms.ItemID = itemId;
                        fms.ColumnID = column;
                        fms.QueryID = queryId;
                        fms.Update();
                        //  Program.ErrorHandler(fms.Update(), "updating a form items assigned user defined values(fms)"); 

                        #endregion
                    }
                    else
                    {
                        #region Add New

                        SAPbobsCOM.FormattedSearches fms = (SAPbobsCOM.FormattedSearches)Program.oCompany.GetBusinessObject(BoObjectTypes.oFormattedSearches);
                        fms.Action = BoFormattedSearchActionEnum.bofsaQuery;
                        fms.FormID = formId;
                        fms.ItemID = itemId;
                        fms.ColumnID = column;
                        fms.QueryID = queryId;
                        fms.Add();
                        //  Program.ErrorHandler(fms.Add(), "adding a user defined value to form item");

                        #endregion
                    }
                }
                else
                {
                    Program.SBO_Application.MessageBox("Could not find Query");
                }
            }
            catch (Exception ex)
            {
                Program.SBO_Application.SetStatusBarMessage("Error assigning query: " + ex.Message);
            }
            finally
            {
                // GC Release
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
            }
        }

        #endregion

        private bool CreateUDO(string CodeID, string Name, string TableName, string[] FormColoums, SAPbobsCOM.BoUDOObjType ObjectType, string ManageSeries)
        {
            SAPbobsCOM.UserObjectsMD oUserObjectMD = default(SAPbobsCOM.UserObjectsMD);
            try
            {
                oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));
                if (oUserObjectMD.GetByKey(CodeID) == true)
                {
                    return true;
                }
                oUserObjectMD.CanLog = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanFind = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanClose = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanCancel = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanDelete = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.ManageSeries = SAPbobsCOM.BoYesNoEnum.tNO;
                oUserObjectMD.CanYearTransfer = SAPbobsCOM.BoYesNoEnum.tNO;

                oUserObjectMD.Code = CodeID;
                oUserObjectMD.Name = Name;
                oUserObjectMD.TableName = TableName;
                oUserObjectMD.ObjectType = ObjectType;


                oUserObjectMD.CanCreateDefaultForm = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.EnableEnhancedForm = SAPbobsCOM.BoYesNoEnum.tNO;
                oUserObjectMD.MenuItem = SAPbobsCOM.BoYesNoEnum.tNO;
                oUserObjectMD.MenuCaption = Name;
                oUserObjectMD.FatherMenuID = 47616;
                oUserObjectMD.Position = 0;
                oUserObjectMD.MenuUID = CodeID;

                if (FormColoums != null)
                {
                    for (int i = 0; i <= FormColoums.Length - 1; i++)
                    {
                        if (FormColoums[i].Trim() != "U_RUNDB")
                        {
                            oUserObjectMD.FormColumns.FormColumnAlias = FormColoums[i];
                            oUserObjectMD.FormColumns.Editable = SAPbobsCOM.BoYesNoEnum.tNO;
                            oUserObjectMD.FormColumns.Add();
                        }
                        else
                        {
                            oUserObjectMD.FormColumns.FormColumnAlias = FormColoums[i];
                            oUserObjectMD.FormColumns.Editable = SAPbobsCOM.BoYesNoEnum.tYES;
                            oUserObjectMD.FormColumns.Add();
                        }
                    }
                }
                // check for errors in the process
                RetCode = oUserObjectMD.Add();

                if (RetCode != 0)
                {
                    if (RetCode != -1)
                    {
                        Program.oCompany.GetLastError(out RetCode, out ErrMsg);
                        Program.SBO_Application.StatusBar.SetText("Object Failed : " + ErrMsg + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    }
                }
                else
                {
                    Program.SBO_Application.StatusBar.SetText("Object Registered : " + Name + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }



    }
}

