using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.Addon.Helpers;
using System.Data;
using ITNepal.MainLibrary.Utilities;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.AgingReport", "Forms/AgingReport.b1f")]
    class AgingReport : B1FormBase
    {
        public AgingReport()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            //   this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var AgingDate = ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_1").Specific).Value;
            if (String.IsNullOrEmpty(AgingDate))
            {
                Application.SBO_Application.MessageBox("As on Date should not be empty ...! ");
                BubbleEvent = false;
                return;
            }
            else
            {
                string sSQL = " select * from ( " +
    "SELECT Distinct T0.\"ItemCode\" as \"Particulars\",sum(T0.\"InQty\" - T0.\"OutQty\") as \"Total Qty\", " +
    "--sum(T0.\"Price\") as \"Rate\", " +
    "(sum(T0.\"TransValue\") / sum(T0.\"InQty\" - T0.\"OutQty\")) as \"Rate\", " +
    "sum(T0.\"TransValue\") as \"Total Value\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=180 THEN sum(T0.\"InQty\"-T0.\"OutQty\") END \"O-6M(Qty)\",  " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=180 THEN sum(T0.\"TransValue\") END  \"0-6M(Value)\" , " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>180 AND DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=365 THEN sum(T0.\"InQty\"-T0.\"OutQty\") END \"6-12M(Qty)\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>180 AND DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=365 THEN sum(T0.\"TransValue\") END \"6-12M (Value)\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>365 AND DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=730 THEN sum(T0.\"InQty\"-T0.\"OutQty\") END \"12-24M (Qty)\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>365 AND DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=730 THEN sum(T0.\"TransValue\") END \"12-24M (Value)\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>730 AND DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=1095 THEN sum(T0.\"InQty\"-T0.\"OutQty\") END \"24-36M (Qty)\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>730 AND DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) <=1095 THEN sum(T0.\"TransValue\") END \"24-36M (Value)\",	" +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE) >1095 THEN sum(T0.\"InQty\"-T0.\"OutQty\") END \"ABOVE 36M(Qty)\", " +
    "CASE WHEN DAYS_BETWEEN (T1.\"LastPurDat\", CURRENT_DATE)>1095 THEN sum(T0.\"TransValue\") END  \"ABOVE 36M(Value)\", " +
    "T1.\"SWW\" as \"Product GP\",T1.\"CardCode\" as \"Prefered Vendor\", " +
    "(Select x.\"CompnyName\" From OADM x) as \"CompName\", " +
    "(Select \"StreetNo\" from ADM1) as \"StreetNo\", " +
    "(Select \"Street\" from ADM1) as \"Street\", " +
    "(Select \"Block\" from ADM1) as \"Block\", " +
    "(Select \"Building\" from ADM1) as \"Building\", " +
    "(Select \"City\" from ADM1) as \"City\", " +
    "(Select \"ZipCode\" from ADM1) as \"ZipCode\", " +
    "(Select a.\"Name\"  from OCST a Inner Join ADM1 b On a.\"Code\"=b.\"State\" where a.\"Country\"='IN' ) as \"State\", " +
    "(select a.\"Name\" from OCRY a Inner Join ADM1 b On a.\"Code\" = b.\"Country\") as \"Country\", " +
    "(Select X.\"Fax\" from OADM X) as \"Fax\", " +
    "(Select X.\"E_Mail\" from OADM X) as \"E_Mail\", " +
    "(Select X.\"IntrntAdrs\" from ADM1 X) as \"Website\", " +
    "(Select \"Phone1\" from OADM) as \"Phone1\", " +
    "(Select \"Phone2\" from OADM) as \"Phone2\" " +
    "FROM OINM T0 INNER JOIN OITM T1 ON T0.\"ItemCode\"  = T1.\"ItemCode\" " +
    "INNER JOIN OITB T2 ON T1.\"ItmsGrpCod\"=T2.\"ItmsGrpCod\" " +
    "inner join OWHS W On W.\"WhsCode\" = T0.\"Warehouse\" " +
    "Where 	T0.\"TransValue\" <> 0 " +
    "	--and T0.\"ItemCode\"='0127865000' " +
    "	--and     (T0.\"InQty\"-T0.\"OutQty\")<> 0 " +
    "	--and     T0.\"OutQty\"<>0 " +
    "	--and     T0.\"Price\"<>0 " +
    "--and     W.\"WhsCode\"<>'Demo_MNR' " +
    "group by T0.\"ItemCode\",T1.\"ItmsGrpCod\",T1.\"SWW\",T1.\"LastPurDat\",T1.\"CardCode\" " +
    "Order by T0.\"ItemCode\" ) as tmp where tmp.\"Total Qty\" >0 ";

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(sSQL);
                DataTable oDt = new DataTable();
                oDt = Utility.ConvertRecordset(rs);
                //
                //Utility.WriteDataTableToExcel(oDt, "Inventory Aging Report", ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_3").Specific).Value, "Inventory Aging Report");
                // MessageBox.Show("Excel created D:\testPersonExceldata.xlsx");
            }
        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            var folderPath = System.Configuration.ConfigurationManager.AppSettings["ReportPath"];

            ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_1").Specific).Value = DateTime.Now.ToString("yyyyMMdd");
            ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_3").Specific).Value = folderPath.ToString();
            //throw new System.NotImplementedException();

        }


    }
}
