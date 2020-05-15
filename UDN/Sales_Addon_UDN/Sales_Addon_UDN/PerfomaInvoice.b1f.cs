using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using NepaliDateConverter;
using SAPbobsCOM;

namespace Sales_Addon_UDN
{
    [FormAttribute("PerfomaInvoice", "PerfomaInvoice.b1f")]
    class PerfomaInvoice : UserFormBase
    {
        public PerfomaInvoice()
        {
        }

        public PerfomaInvoice(string source)
        {
            try
            {
                BasicBinding();
                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Purchase Order")
                    {
                        SAPbouiCOM.Form fmr2 = item;
                        fmr2 = Program.SBO_Application.Forms.ActiveForm;
                        var docNum = ((SAPbouiCOM.EditText)((fmr2.Items.Item("8").Specific))).Value.ToString();
                        var series = ((SAPbouiCOM.ComboBox)((fmr2.Items.Item("88").Specific))).Value.ToString();
                        string lineQuery = "SELECT \"DocEntry\" FROM OPOR WHERE \"DocNum\" = '" + docNum + "'  AND \"Series\" = '" + series.Trim() + "'";

                        SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                        rs.DoQuery(lineQuery);

                        string docEntry =rs.Fields.Item("DocEntry").Value.ToString();
                        txtPON.Value = docEntry;
                        txtVC.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("4").Specific))).Value.ToString();
                        txtVN.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("54").Specific))).Value.ToString();
                        txtPD.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("46").Specific))).Value.ToString();
                        //txtCU.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("63").Specific))).Value.ToString();

                        string Query = "SELECT \"DocCur\" FROM OPOR WHERE \"DocEntry\" = '" + docEntry +"'";
                        rs.DoQuery(Query);
                        string currency = rs.Fields.Item("DocCur").Value.ToString();

                        SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)fmr2.Items.Item("38").Specific;

                        string taxCode = "";
                        for (int row = 1; row < mtx.RowCount; row++)
                        {
                            Matrix0.AddLine();
                            Extentions.SetLineId(Matrix0);

                            SAPbouiCOM.EditText ItemCode = (SAPbouiCOM.EditText)mtx.GetCellSpecific("1", row);
                            SAPbouiCOM.EditText txtIC = (SAPbouiCOM.EditText)this.Matrix0.GetCellSpecific("1", row);
                            txtIC.Value = ItemCode.Value;

                            SAPbouiCOM.EditText Des = (SAPbouiCOM.EditText)mtx.GetCellSpecific("3", row);
                            SAPbouiCOM.EditText txtDes = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("2", row);
                            txtDes.Value = Des.Value;

                            SAPbouiCOM.EditText UOMCode = (SAPbouiCOM.EditText)mtx.GetCellSpecific("1470002145", row);
                            SAPbouiCOM.EditText txtUC = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("3", row);
                            txtUC.Value = UOMCode.Value;

                            SAPbouiCOM.EditText UOMQty = (SAPbouiCOM.EditText)mtx.GetCellSpecific("10002117", row);
                            SAPbouiCOM.EditText txtUOMQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("4", row);
                            txtUOMQty.Value = UOMQty.Value;

                            SAPbouiCOM.EditText Qty = (SAPbouiCOM.EditText)mtx.GetCellSpecific("11", row);
                            SAPbouiCOM.EditText txtQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("5", row);
                            txtQty.Value = Qty.Value;

                            SAPbouiCOM.EditText UnitPrice = (SAPbouiCOM.EditText)mtx.GetCellSpecific("14", row);
                            SAPbouiCOM.EditText txtUP = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("6", row);
                            txtUP.Value = UnitPrice.Value;

                            SAPbouiCOM.EditText TaxCode = (SAPbouiCOM.EditText)mtx.GetCellSpecific("160", row);
                            SAPbouiCOM.EditText txtTC = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("7", row);
                            txtTC.Value = TaxCode.Value;
                            taxCode = TaxCode.Value;

                            SAPbouiCOM.EditText TaxAmount = (SAPbouiCOM.EditText)mtx.GetCellSpecific("82", row);
                            SAPbouiCOM.EditText txtTAmount = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("8", row);
                            txtTAmount.Value = TaxAmount.Value;

                            SAPbouiCOM.EditText LineTotal = (SAPbouiCOM.EditText)mtx.GetCellSpecific("21", row);
                            SAPbouiCOM.EditText txtLT = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("9", row);
                            txtLT.Value = LineTotal.Value;
                        }

                        txtRMK.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("16").Specific))).Value.ToString();
                        txtPBO.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("22").Specific))).Value.ToString();
                        txtDisc.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("42").Specific))).Value.ToString();
                        txtTA.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("27").Specific))).Value.ToString();
                        txtTotal.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("29").Specific))).Value.ToString();
                        this.txtTC.Value = taxCode;
                        txtCU.Value = currency;
                    }
                }
                ButtonCombo0.Item.Enabled = false;
            }
            catch { }
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.txtPON = ((SAPbouiCOM.EditText)(this.GetItem("txtPON").Specific));
            this.txtPD = ((SAPbouiCOM.EditText)(this.GetItem("txtPD").Specific));
            this.txtVC = ((SAPbouiCOM.EditText)(this.GetItem("txtVC").Specific));
            this.txtVN = ((SAPbouiCOM.EditText)(this.GetItem("txtVN").Specific));
            this.txtRN = ((SAPbouiCOM.EditText)(this.GetItem("txtRN").Specific));
            this.txtDN = ((SAPbouiCOM.EditText)(this.GetItem("txtDN").Specific));
            this.txtDD = ((SAPbouiCOM.EditText)(this.GetItem("txtDD").Specific));
            this.txtND = ((SAPbouiCOM.EditText)(this.GetItem("txtND").Specific));
            this.txtCU = ((SAPbouiCOM.EditText)(this.GetItem("txtCU").Specific));
            this.txtIRN = ((SAPbouiCOM.EditText)(this.GetItem("txtIRN").Specific));
            this.txtPB = ((SAPbouiCOM.EditText)(this.GetItem("txtPB").Specific));
            this.txtPB.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPB_ChooseFromListAfter);
            this.txtPBO = ((SAPbouiCOM.EditText)(this.GetItem("txtPBO").Specific));
            this.txtDisc = ((SAPbouiCOM.EditText)(this.GetItem("txtDisc").Specific));
            this.txtTC = ((SAPbouiCOM.EditText)(this.GetItem("txtTC").Specific));
            this.txtTA = ((SAPbouiCOM.EditText)(this.GetItem("txtTA").Specific));
            this.txtTotal = ((SAPbouiCOM.EditText)(this.GetItem("txtTotal").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.txtRMK = ((SAPbouiCOM.EditText)(this.GetItem("txtRMK").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_22").Specific));
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_2").Specific));
            this.ButtonCombo0 = ((SAPbouiCOM.ButtonCombo)(this.GetItem("Item_13").Specific));
            this.ButtonCombo0.ComboSelectBefore += new SAPbouiCOM._IButtonComboEvents_ComboSelectBeforeEventHandler(this.ButtonCombo0_ComboSelectBefore);
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_14").Specific));
            this.txtPO = ((SAPbouiCOM.EditText)(this.GetItem("txtPO").Specific));
            this.txtPO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPO_ChooseFromListAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private void OnCustomInitialize()
        {
            BasicBinding();
            
            //Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
            //Oform.EnableMenu("1292", true);
            //Oform.EnableMenu("1293", true);
            //Oform.EnableMenu("1287", true);

            SAPbouiCOM.ButtonCombo btnPL = (SAPbouiCOM.ButtonCombo)this.UIAPIRawForm.Items.Item("Item_13").Specific;

            btnPL.ValidValues.Add("Purchase Order", "Purchase Order");
        }

        #region Declarations

        private SAPbouiCOM.EditText txtPO;
        private SAPbouiCOM.EditText txtPON;
        private SAPbouiCOM.EditText txtPD;
        private SAPbouiCOM.EditText txtVC;
        private SAPbouiCOM.EditText txtVN;
        private SAPbouiCOM.EditText txtRN;
        private SAPbouiCOM.EditText txtDN;
        private SAPbouiCOM.EditText txtDD;
        private SAPbouiCOM.EditText txtND;
        private SAPbouiCOM.EditText txtCU;
        private SAPbouiCOM.EditText txtIRN;
        private SAPbouiCOM.EditText txtPB;
        private SAPbouiCOM.EditText txtPBO;
        private SAPbouiCOM.EditText txtDisc;
        private SAPbouiCOM.EditText txtTC;
        private SAPbouiCOM.EditText txtTA;
        private SAPbouiCOM.EditText txtTotal;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText txtRMK;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.ButtonCombo ButtonCombo0;
        private SAPbouiCOM.LinkedButton LinkedButton2;
        private SAPbouiCOM.Form Oform;

        #endregion

        #region Events

        private void txtPB_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPIN").SetValue("U_PREPBY", 0, oTable.GetValue("lastName", 0).ToString() + ", " + oTable.GetValue("firstName", 0).ToString());
                }
                catch { }
            }
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (!Validation())
            {
                BubbleEvent = false;
                return;
            }
        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            BasicBinding();
        }

        private void ButtonCombo0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
                txtPO.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                Program.SBO_Application.SendKeys("{TAB}");
                ButtonCombo0.Caption = "Copy From";
        }

        private void txtPO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            string DocEntry = "";
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    txtPON.Value = oTable.GetValue("DocEntry", 0).ToString();
                }
                catch { }
                try
                {
                    var DocDate = DateTime.Parse(oTable.GetValue("DocDate", 0).ToString());
                    var Date = DocDate.Year + DocDate.Month.ToString("00") + DocDate.Day.ToString("00");
                    txtPD.Value = Date;
                }
                catch { }
                try
                {
                    txtVC.Value = oTable.GetValue("CardCode", 0).ToString();
                }
                catch { }
                try
                {
                    txtVN.Value = oTable.GetValue("CardName", 0).ToString();
                }
                catch { }
                try
                {
                    txtRMK.Value = oTable.GetValue("Comments", 0).ToString();
                }
                catch { }
                try
                {
                    txtPBO.Value = oTable.GetValue("Max1099", 0).ToString();
                }
                catch { }
                try
                {
                    txtTA.Value = oTable.GetValue("VatSum", 0).ToString();
                }
                catch { }
                try
                {
                    txtDisc.Value = oTable.GetValue("DiscSum", 0).ToString();
                }
                catch { }
                try
                {
                    txtTotal.Value = oTable.GetValue("DocTotalSy", 0).ToString();
                }
                catch { }
                try
                {
                    DocEntry = oTable.GetValue("DocEntry", 0).ToString();
                }
                catch { }

                try
                {
                    txtCU.Value = oTable.GetValue("DocCur", 0).ToString();
                }
                catch { }

                FillMatrix(DocEntry);
            }
        }

        #endregion

        #region Methods

        private bool Validation()
        {
            string lineQuery = "SELECT Count(\"DocEntry\") as \"Count\" FROM \"@ITN_OPIN\" WHERE \"U_PONUM\" = '" + txtPON.Value + "'";
            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            rs.DoQuery(lineQuery);
            for (int row = 1; row <= Matrix0.RowCount; row++)
            {
                SAPbouiCOM.EditText PIQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("10", row);
                if (PIQty.Value == "0.0")
                {
                    Program.SBO_Application.StatusBar.SetText("Please enter Proforma Invoice Qty", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
            }
            if (rs.Fields.Item("Count").Value.ToString() != "0")
            {
                Program.SBO_Application.StatusBar.SetText("Proforma Invoice for given Purchase Order already been created", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            return true;
        }


        private void BasicBinding()
        {
            try
            {
                txtDN.Value = B1Helper.GetNextDocNum("@ITN_OPIN").ToString();
                var date = System.DateTime.Now;
                txtDD.Value = date.ToString("yyyyMMdd");

                DateConverter convertedDate = DateConverter.ConvertToNepali(date.Year, date.Month, date.Day);
                string bsString = convertedDate.Year + convertedDate.Month.ToString("00") + convertedDate.Day.ToString("00");
                txtND.Value = bsString;
                Matrix0.AutoResizeColumns();
            }
            catch { }
        }



        private void FillMatrix(string DocEntry)
        {
            try
            {
                Matrix0.Clear();
                string lineQuery = "";
                lineQuery = "SELECT \"ItemCode\", \"Dscription\",\"Quantity\",\"UomCode\",\"LineTotal\",\"TaxCode\",\"Price\",\"InvQty\",\"VatSum\" FROM POR1 WHERE \"DocEntry\" = '" + DocEntry + "'";
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rs.DoQuery(lineQuery);

                string taxCode = "";
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < rs.RecordCount; i++)
                    {
                        Matrix0.AddRow();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(i + 1).Specific).Value = (i + 1).ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("1").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("ItemCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("2").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Dscription").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("3").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("UomCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("4").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("InvQty").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("5").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Quantity").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("6").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Price").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("7").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("TaxCode").Value.ToString();
                        taxCode = rs.Fields.Item("TaxCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("8").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("VatSum").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("9").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("LineTotal").Value.ToString();
                        rs.MoveNext();
                    }
                }

                txtTC.Value = taxCode;
            }
            catch { }
        }


        #endregion



    }
}
