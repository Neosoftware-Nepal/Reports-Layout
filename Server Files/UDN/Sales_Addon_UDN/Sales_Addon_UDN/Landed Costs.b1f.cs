
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using System.Configuration;

namespace Sales_Addon_UDN
{

    [FormAttribute("992", "Landed Costs.b1f")]
    class Landed_Costs : SystemFormBase
    {
        public Landed_Costs()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("10000104").Specific));
            this.ComboBox0.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox0_ClickAfter);
            this.TxtVenCode = ((SAPbouiCOM.EditText)(this.GetItem("3").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("51").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("54").Specific));
            this.Fld2 = ((SAPbouiCOM.Folder)(this.GetItem("53").Specific));
            this.FldItems = ((SAPbouiCOM.Folder)(this.GetItem("52").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.DataAddAfter += new DataAddAfterHandler(this.Form_DataAddAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            LoadData();
        }

        private void OnCustomInitialize()
        {

        }

        SAPbouiCOM.Form Grpo;
        SAPbouiCOM.Matrix GRPOMatrix;
        SAPbouiCOM.Folder Fld2;
        private SAPbouiCOM.Folder FldItems;
        string GRPOVendor = "";
        string GRPODate = "";
        string GRPODocDate = "";
        string GRPODocNum = "";
        double TotalOfLandedCost = 0;
        string GRPOWhseCode = "";
        private void LoadData()
        {
            try
            {
                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Goods Receipt PO")
                    {
                        Grpo = item;
                        GRPOVendor = ((SAPbouiCOM.EditText)((Grpo.Items.Item("4").Specific))).Value.ToString();
                        GRPODate = ((SAPbouiCOM.EditText)((Grpo.Items.Item("10").Specific))).Value.ToString();
                        GRPODocNum = ((SAPbouiCOM.EditText)((Grpo.Items.Item("8").Specific))).Value.ToString();
                        GRPODocDate = ((SAPbouiCOM.EditText)((Grpo.Items.Item("10").Specific))).Value.ToString();

                        //GRPOMatrix = ((SAPbouiCOM.Matrix)(Grpo.Items.Item("38").Specific));
                        TxtVenCode.Value = GRPOVendor;
                        //ComboBox0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                        ComboBox0.Select("Goods Receipt PO", SAPbouiCOM.BoSearchKey.psk_ByValue);
                        SAPbouiCOM.Form Ofm;
                        foreach (SAPbouiCOM.Form item2 in Program.SBO_Application.Forms)
                        {
                            if (item2.Title == "List of Goods Receipt PO")
                            {
                                Ofm = item2;
                                SAPbouiCOM.EditText listmtx = ((SAPbouiCOM.EditText)((Ofm.Items.Item("6").Specific)));
                                listmtx.Value = GRPODocNum;
                                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(Ofm.Items.Item("1").Specific));
                                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                                loadLandedCost();
                            }
                        }
                        SAPbouiCOM.EditText WhseCode = Matrix0.GetCellSpecific("52", 1) as SAPbouiCOM.EditText;
                        GRPOWhseCode = WhseCode.Value;
                    }
                }
            }
            catch
            {
            }
        }

        private void loadLandedCost()
        {
            try
            {
                Fld2.Select();
                string query = "Select sum(U_LCCHRGE)as \"U_LCCHRGE\",sum(U_INSCHRGE) as \"U_INSCHRGE\" " +
                                ",sum(U_CUSTDUTY)  as \"U_CUSTDUTY\",sum(U_ACPTCOST)as  \"U_ACPTCOST\"," +
                                "sum(U_DOCHNCHRGE) as \"U_DOCHNCHRGE\",sum(U_DMRGECST) as \"U_DMRGECST\",sum(U_DTNSNCST) as \"U_DTNSNCST\" " +
                                ",sum(U_INSCHRGE) as \"U_INSCHRGE\",sum(U_CUSTRCOST) as \"U_CUSTRCOST\"," +
                                "sum(U_LCCHRGE) as \"U_LCCHRGE\",sum(U_NPCLRCOST) as \"U_NPCLRCOST\", " +
                                "sum(U_NPCUSTRCST) as \"U_NPCUSTRCST\",sum(U_ADDCOST) as \"U_ADDCOST\",sum(U_CLRCSTKOL) as \"U_CLRCSTKOL\",sum(U_CLRCSTKOL) as \"U_CLRCSTKOL\" " +
                                ",sum(U_RTMTCOST) as \"U_RTMTCOST\",sum(U_UNLDEXP) as \"U_UNLDEXP\" " +
                                "from  \"@ITN_PRC1\" Where U_ITEMCODE  in ('";
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                    if (!string.IsNullOrEmpty(ItemCode.Value))
                    {
                        if (i == 1)
                        {
                            query += ItemCode.Value + "'";
                        }
                        else
                        {
                            query += ",'" + ItemCode.Value + "'";
                        }
                    }
                }
                query += ")";
                resetRec();
                Rec.DoQuery(query);
                if (Rec.RecordCount > 0)
                {
                    //while (!Rec.EoF)
                    {
                        for (int j = 1; j <= Matrix1.RowCount; j++)
                        {
                            SAPbouiCOM.EditText LandedCost = Matrix1.GetCellSpecific("1", j) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText Amount = Matrix1.GetCellSpecific("3", j) as SAPbouiCOM.EditText;
                            if (LandedCost.Value == "Acceptance Cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_ACPTCOST").Value.ToString();
                            }

                            else if (LandedCost.Value == "Custom Duty")
                            {
                                Amount.Value = Rec.Fields.Item("U_CUSTDUTY").Value.ToString();
                            }
                            else if (LandedCost.Value == "Document Handling Charges")
                            {
                                Amount.Value = Rec.Fields.Item("U_DOCHNCHRGE").Value.ToString();
                            }
                            else if (LandedCost.Value == "Demurrage Cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_DMRGECST").Value.ToString();
                            }
                            else if (LandedCost.Value == "Detention Cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_DTNSNCST").Value.ToString();
                            }
                            else if (LandedCost.Value == "Insurance Charges")
                            {
                                Amount.Value = Rec.Fields.Item("U_INSCHRGE").Value.ToString();
                            }
                            else if (LandedCost.Value == "India to Custom Transport Cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_CUSTRCOST").Value.ToString();
                            }
                            else if (LandedCost.Value == "LC Charges")
                            {
                                Amount.Value = Rec.Fields.Item("U_LCCHRGE").Value.ToString();
                            }
                            else if (LandedCost.Value == "Nepal Clearing cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_NPCLRCOST").Value.ToString();
                            }
                            else if (LandedCost.Value == "Custom  to UDN Transport cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_NPCUSTRCST").Value.ToString();
                            }
                            else if (LandedCost.Value == "Other Additional Costs")
                            {
                                Amount.Value = Rec.Fields.Item("U_ADDCOST").Value.ToString();
                            }
                            else if (LandedCost.Value == "Clearing cost Kolkata")
                            {
                                Amount.Value = Rec.Fields.Item("U_CLRCSTKOL").Value.ToString();
                            }
                            else if (LandedCost.Value == "Clearing cost Kolkata")
                            {
                                Amount.Value = Rec.Fields.Item("U_CLRCSTKOL").Value.ToString();
                            }
                            else if (LandedCost.Value == "Retirement/Settlement cost")
                            {
                                Amount.Value = Rec.Fields.Item("U_RTMTCOST").Value.ToString();
                            }
                            else if (LandedCost.Value == "Unloading Expenses")
                            {
                                Amount.Value = Rec.Fields.Item("U_UNLDEXP").Value.ToString();
                            }
                        }
                    }
                }
                FldItems.Select();
            }
            catch
            {
            }
        }

        private void resetRec()
        {
            if (Rec != null)
                Rec = null;

            if (Rec == null)
                Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        }

        private void ComboBox0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string i = "";
        }

        private SAPbouiCOM.Matrix Matrix1;
        private SAPbobsCOM.Recordset Rec;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.EditText TxtVenCode;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbobsCOM.Documents oInvoice;


        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //Generate AP Invoice Service. 
            try
            {

            }
            catch
            {
            }
        }

        private void GenerateAPInvoice(string LandedCostDocEntry)
        {
            int DocEntry = 0;
            int GPRPODocEntry = 0;
            try
            {
                GPRPODocEntry = Convert.ToInt32(GrpoDocEntry(GRPODocNum, GRPODocDate));
                oInvoice = (SAPbobsCOM.Documents)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseInvoices);
                oInvoice.DocType = SAPbobsCOM.BoDocumentTypes.dDocument_Service;
                oInvoice.CardCode = GRPOVendor;

                oInvoice.Lines.SetCurrentLine(0);
                oInvoice.Lines.SACEntry = Convert.ToInt32(ConfigurationSettings.AppSettings["APSAC"].ToString());
                oInvoice.Lines.ItemDescription = "GRPO DocEntry :: " + GPRPODocEntry + " Landed Cost DocEntry ::" + LandedCostDocEntry;

                TotalOfLandedCost = 0;
                for (int i = 1; i <= Matrix1.RowCount; i++)
                {
                    SAPbouiCOM.EditText Amount = Matrix1.GetCellSpecific("3", i) as SAPbouiCOM.EditText;
                    if (!string.IsNullOrEmpty(Amount.Value))
                    {
                        if (Convert.ToDouble(Amount.Value.Split(' ')[1]) > 0)
                        {
                            TotalOfLandedCost = TotalOfLandedCost + Convert.ToDouble(Amount.Value.Split(' ')[1]);
                        }
                    }
                }
                oInvoice.Lines.LineTotal = TotalOfLandedCost;
                oInvoice.Lines.TaxCode = "VAT@13";
                oInvoice.Lines.LocationCode = Convert.ToInt32(Location(GRPOWhseCode));
                oInvoice.Lines.AccountCode = ConfigurationSettings.AppSettings["APGLAccount"].ToString();
                oInvoice.Lines.Add();
                int p = oInvoice.Add();


                if (p == 0)
                {
                    string k = Program.oCompany.GetNewObjectKey();
                    Program.SBO_Application.StatusBar.SetText("AP Invoice is generated with docentry :" + k, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                    SAPbobsCOM.Documents GRPO = (SAPbobsCOM.Documents)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);
                    GRPO.GetByKey(GPRPODocEntry);
                    GRPO.UserFields.Fields.Item("U_ITNAPINV").Value = k;
                    GRPO.UserFields.Fields.Item("U_ITNLANDEDCOST").Value = LandedCostDocEntry;
                    int l = GRPO.Update();
                    if (l == 0)
                    {
                        Program.SBO_Application.StatusBar.SetText("GRPO is updated", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                    }
                    else
                    {
                        Program.SBO_Application.StatusBar.SetText("unable to update GRPO Error Code :" + Program.oCompany.GetLastErrorCode() + "Error descpirtion :" + Program.oCompany.GetLastErrorDescription(), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    }
                }
                else
                {
                    Program.SBO_Application.StatusBar.SetText("unable to generate APInvoice Error Code :" + Program.oCompany.GetLastErrorCode() + "Error descpirtion :" + Program.oCompany.GetLastErrorDescription(), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
            }
            catch
            {
            }
        }

        private string GrpoDocEntry(string GrpoDOcNum, string PostingDate)
        {
            try
            {
                string Query = "Select \"DocEntry\" from OPDN Where \"DocNum\" = '" + GrpoDOcNum + "' and \"DocDate\" = '" + PostingDate + "'; ";
                resetRec();
                Rec.DoQuery(Query);
                if (Rec.RecordCount > 0)
                {
                    return Rec.Fields.Item("DocEntry").Value.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }

        }

        private string Location(string whseCode)
        {
            try
            {
                string Query = "Select T0.\"Location\" from OWHS T0 Where \"WhsCode\" = '" + whseCode + "'";
                resetRec();
                Rec.DoQuery(Query);
                if (Rec.RecordCount > 0)
                {
                    return Rec.Fields.Item("Location").Value.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }

        }

        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                if (!pVal.ActionSuccess)
                    return;
                string DocEntry = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("DocEntry", 0);
                GenerateAPInvoice(DocEntry);
            }
            catch
            {
            }

        }
    }
}
