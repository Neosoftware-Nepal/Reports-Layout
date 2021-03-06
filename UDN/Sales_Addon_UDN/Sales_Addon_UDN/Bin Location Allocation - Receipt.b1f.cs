
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{

    [FormAttribute("1470000006", "Bin Location Allocation - Receipt.b1f")]
    class Bin_Location_Allocation___Receipt : SystemFormBase
    {
        public Bin_Location_Allocation___Receipt()
        {
            
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("1470000019").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("1980000024-1980000004").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("1470000014").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1470000001").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.DataAddAfter += new SAPbouiCOM.Framework.FormBase.DataAddAfterHandler(this.Form_DataAddAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //FillBinData();
        }

        private void FillBinData()
        {
            try
            {
                SAPbouiCOM.Form BachSetup = null;
                SAPbouiCOM.Matrix Mtx = null;

                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Batches - Setup")
                    {
                        BachSetup = item;
                        Mtx = ((SAPbouiCOM.Matrix)(item.Items.Item("3").Specific));

                    }
                }

                SAPbouiCOM.EditText AllocardBinCode = Mtx.GetCellSpecific("U_ITNABINCODE", Convert.ToInt32(EditText0.Value)) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText AllocardBinQTY = Mtx.GetCellSpecific("U_ITNABINQTY", Convert.ToInt32(EditText0.Value)) as SAPbouiCOM.EditText;
                int i = 1;
                foreach (string item in AllocardBinCode.Value.Split(','))
                {
                    SAPbouiCOM.EditText Binlocation = Matrix0.GetCellSpecific("1470000001", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText binQty = Matrix0.GetCellSpecific("1470000003", i) as SAPbouiCOM.EditText; 

                    Binlocation.Value = item;
                    binQty.Value =  (AllocardBinQTY.Value.Split(',')[i-1]).ToString() ;
                    i++; 
                }
                Button0.Item.Click();
                Button0.Item.Click(); 
            }
            catch
            {
            }
        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbobsCOM.Recordset Rec;

        private double ItemArea(string itemCode)
        {
            try
            {
                string query = "Select ifnull(\"BVolume\", 0 ) as Area from OITM where \"ItemCode\"  = '" + itemCode + "'";
                ResetRec();
                Rec.DoQuery(query);
                return Convert.ToDouble(Rec.Fields.Item("AREA").Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        private void ResetRec()
        {
            try
            {
                if (Rec != null)
                    Rec = null;

                if (Rec == null)
                    Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            }
            catch
            {
            }
        }

        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {

            //FillBinData(); 
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //FillBinData(); 

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            
            FillBinData(); 

        }

        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button0;
    }
}
