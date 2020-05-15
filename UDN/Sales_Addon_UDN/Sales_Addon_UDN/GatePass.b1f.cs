using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using NepaliDateConverter;
using System.Globalization;
using SAPbobsCOM;

namespace Sales_Addon_UDN
{
    [FormAttribute("GatePass", "GatePass.b1f")]
    class GatePass : UserFormBase
    {
        public GatePass()
        {
            txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OGTP").ToString();
            txtPrepBy.Value = Program.SBO_Application.Company.UserName;
            Matrix0.AutoResizeColumns();

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("comboTras").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("comboRefDc").Specific));
            this.ComboBox1.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox1_ComboSelectAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.txtPOInv = ((SAPbouiCOM.EditText)(this.GetItem("txtPOInv").Specific));
            this.txtPOInv.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.txtPOInv_KeyDownAfter);
            this.txtPOInv.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPOInv_ChooseFromListAfter);
            this.txtPOInv.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.txtPOInv_ChooseFromListBefore);
            this.txtParCode = ((SAPbouiCOM.EditText)(this.GetItem("txtParCode").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_11").Specific));
            this.txtParName = ((SAPbouiCOM.EditText)(this.GetItem("txtParName").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.txtWhsCode = ((SAPbouiCOM.EditText)(this.GetItem("txtWhsCode").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.txtWhName = ((SAPbouiCOM.EditText)(this.GetItem("txtWhName").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.txtDocNum = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNum").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.txtExitDt = ((SAPbouiCOM.EditText)(this.GetItem("txtExitDt").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.txtExitTim = ((SAPbouiCOM.EditText)(this.GetItem("txtExitTim").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.txtInTime = ((SAPbouiCOM.EditText)(this.GetItem("txtInTime").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.txtGatEnNo = ((SAPbouiCOM.EditText)(this.GetItem("txtGatEnNo").Specific));
            this.txtTransDe = ((SAPbouiCOM.EditText)(this.GetItem("txtTransDe").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
            this.txtVehNum = ((SAPbouiCOM.EditText)(this.GetItem("txtVehNum").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.txtDriName = ((SAPbouiCOM.EditText)(this.GetItem("txtDriName").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_36").Specific));
            this.Matrix0.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix0_ClickAfter);
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_37").Specific));
            this.txtPrepBy = ((SAPbouiCOM.EditText)(this.GetItem("txtPrepBy").Specific));
            this.txtPrepBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtDocOwn_ChooseFromListAfter);
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_39").Specific));
            this.txtRemarks = ((SAPbouiCOM.EditText)(this.GetItem("txtRemarks").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.txtBsDocEn = ((SAPbouiCOM.EditText)(this.GetItem("txtBsDocEn").Specific));
            this.txtExtNpDt = ((SAPbouiCOM.EditText)(this.GetItem("txtExtNpDt").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.txtInDate = ((SAPbouiCOM.EditText)(this.GetItem("txtInDate").Specific));
            this.txtInNpDt = ((SAPbouiCOM.EditText)(this.GetItem("txtInNpDat").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.txtConNum = ((SAPbouiCOM.EditText)(this.GetItem("txtConNum").Specific));
            this.LinkedButton4 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_1").Specific));
            this.LinkedButton7 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_8").Specific));
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_2").Specific));
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
            Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
            Oform.EnableMenu("1292", true);
            Oform.EnableMenu("1293", true);
        }

        #region Declarations

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText txtPOInv;
        private SAPbouiCOM.EditText txtParCode;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.EditText txtParName;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText txtWhsCode;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText txtWhName;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText txtDocNum;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText txtExitDt;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText txtExitTim;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText txtInTime;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText txtGatEnNo;
        private SAPbouiCOM.EditText txtTransDe;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText txtVehNum;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText txtDriName;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText txtPrepBy;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText txtRemarks;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText txtBsDocEn;
        private SAPbouiCOM.EditText txtExtNpDt;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText txtInDate;
        private SAPbouiCOM.EditText txtInNpDt;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.EditText txtConNum;
        private SAPbouiCOM.LinkedButton LinkedButton4;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.LinkedButton LinkedButton7;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.Form Oform;

        #endregion

        #region Events

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Oform = Program.SBO_Application.Forms.ActiveForm;
                if (Oform.Title.Trim() == "Gate Pass")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OGTP").ToString();
                            Matrix0.AutoResizeColumns();
                        }
                        if (pVal.MenuUID == "1281")
                        {
                            txtDocNum.Item.Enabled = true;
                        }
                    }
                    if (pVal.BeforeAction)
                    {

                        if (pVal.MenuUID == "1292")
                        {
                            Extentions.AddLine(Matrix0);
                            Extentions.SetLineId(Matrix0);
                            BubbleEvent = false;
                        }
                        if (pVal.MenuUID == "1293")
                        {
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Oform.Items.Item("Item_36").Specific;

                            for (int i = 1; i <= mtxBOM.RowCount; i++)
                            {
                                if (Matrix0.IsRowSelected(i))
                                {
                                    Matrix0.DeleteRow(i);
                                    if (Oform.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                    {
                                        Oform.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                                        if (Matrix0.VisualRowCount == 0)
                                        {
                                            Matrix0.AddRow();
                                        }
                                    }
                                    break;
                                }
                            }
                            Extentions.SetLineId(Matrix0);
                        }
                    }
                }
            }
            catch { }
        }

        private void txtDocOwn_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OGTP").SetValue("U_PREPBY", 0, oTable.GetValue("lastName", 0).ToString() + ", " + oTable.GetValue("firstName", 0).ToString());

                }
                catch { }
            }
        }

        private void txtPOInv_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (ComboBox1.Selected.Value == "PO")
            {
                try
                {
                    LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_PurchaseOrder;
                    SAPbouiCOM.ChooseFromList oCFL = this.UIAPIRawForm.ChooseFromLists.Item("PurchaseOrder");
                    txtPOInv.ChooseFromListUID = oCFL.UniqueID;
                    txtPOInv.ChooseFromListAlias = "DocEntry";
                }
                catch { }
            }

            if (ComboBox1.Selected.Value == "Invoice")
            {
                try
                {
                    SAPbouiCOM.ChooseFromList oCFL = this.UIAPIRawForm.ChooseFromLists.Item("Invoice");
                    txtPOInv.ChooseFromListUID = oCFL.UniqueID;
                    txtPOInv.ChooseFromListAlias = "DocEntry";

                    LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                }
                catch { }
            }

            if (ComboBox1.Selected.Value == "Empty Vehicle")
            {
                BubbleEvent = false;
            }

        }

        private void txtPOInv_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            var docEntry = "";

            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    docEntry = oTable.GetValue("DocEntry", 0).ToString();
                    txtPOInv.Value = docEntry;
                }
                catch { }
                try
                {
                    txtBsDocEn.Value = oTable.GetValue("DocNum", 0).ToString();
                }
                catch { }
                try
                {
                    txtParCode.Value = oTable.GetValue("CardCode", 0).ToString();
                }
                catch { }
                try
                {
                    txtParName.Value = oTable.GetValue("CardName", 0).ToString();
                }
                catch { }

                string whsQuery = "SELECT T0.\"WhsCode\", T1.\"WhsName\"  FROM INV1 T0 " +
                                    "INNER JOIN OWHS T1 ON T0.\"WhsCode\" = T1.\"WhsCode\" " +
                                    "WHERE T0.\"DocEntry\" = '" + docEntry + "'";
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rs.DoQuery(whsQuery);

                if (rs.RecordCount > 0)
                {
                    try
                    {
                        txtWhsCode.Value = rs.Fields.Item("WhsCode").Value.ToString();
                    }
                    catch { }

                    try
                    {
                        txtWhName.Value = rs.Fields.Item("WhsName").Value.ToString();
                    }
                    catch { }

                }

                if (ComboBox1.Selected.Value == "PO")
                {
                    FillMatrix("PO", docEntry);

                }
                if (ComboBox1.Selected.Value == "Invoice")
                {
                    FillMatrix("Invoice", docEntry);
                }
            }
        }

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (ComboBox0.Selected.Value == "IN")
                {
                    DateTime date = DateTime.Now;
                    txtInDate.Value = date.ToString("yyyyMMdd");

                    DateConverter convertedDate = DateConverter.ConvertToNepali(date.Year, date.Month, date.Day);
                    String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                    txtInNpDt.Value = bsString;

                    txtInTime.Value = date.Hour.ToString("00") + date.Minute.ToString("00");

                    txtInDate.Item.Enabled = true;
                    txtInNpDt.Item.Enabled = true;
                    txtInTime.Item.Enabled = true;
                    txtExitDt.Item.Enabled = false;
                    txtExtNpDt.Item.Enabled = false;
                    txtExitTim.Item.Enabled = false;
                    txtExitDt.Value = "";
                    txtExtNpDt.Value = "";
                    txtExitTim.Value = "";

                }
                if (ComboBox0.Selected.Value == "OUT")
                {
                    txtExitDt.Item.Enabled = true;
                    txtExtNpDt.Item.Enabled = true;
                    txtExitTim.Item.Enabled = true;

                    txtInDate.Item.Enabled = false;
                    txtInNpDt.Item.Enabled = false;
                    txtInTime.Item.Enabled = false;
                    txtInDate.Value = "";
                    txtInNpDt.Value = "";
                    txtInTime.Value = "";

                    DateTime date = DateTime.Now;
                    txtExitDt.Value = date.ToString("yyyyMMdd");

                    DateConverter convertedDate = DateConverter.ConvertToNepali(date.Year, date.Month, date.Day);
                    String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                    txtExtNpDt.Value = bsString;

                    txtExitTim.Value = date.Hour.ToString("00") + date.Minute.ToString("00");
                }
            }
            catch { }
        }

        private void txtPOInv_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.CharPressed == 8)
            {
                txtPOInv.Value = "";
                txtBsDocEn.Value = "";
                txtParCode.Value = "";
                txtParName.Value = "";
                txtWhsCode.Value = "";
                txtWhName.Value = "";
                Matrix0.Clear();
            }
        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (Button0.Caption == "Add")
            {
                txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OGTP").ToString();

            }

        }
        #endregion


        #region Methods
        private void FillMatrix(string refDoc, string DocEntry)
        {
            try
            {
                Matrix0.Clear();
                string lineQuery = "";
                if (refDoc == "Invoice")
                {
                    lineQuery = "SELECT \"ItemCode\", \"Dscription\",\"Quantity\",\"UomCode\",  \"PriceBefDi\" * \"Quantity\" as Total FROM INV1 WHERE \"DocEntry\" = '" + DocEntry + "'";
                }
                if (refDoc == "PO")
                {
                    lineQuery = "SELECT \"ItemCode\", \"Dscription\",\"Quantity\",\"UomCode\" ,  \"PriceBefDi\" * \"Quantity\" as Total FROM POR1 WHERE \"DocEntry\" = '" + DocEntry + "'";

                }
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rs.DoQuery(lineQuery);

                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < rs.RecordCount; i++)
                    {
                        Matrix0.AddRow();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(i + 1).Specific).Value = (i + 1).ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItemCode").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("ItemCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItemDes").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Dscription").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("UOM").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("UomCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Qty").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Quantity").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Value").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Total").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("InExitQty").Cells.Item(i + 1).Specific).Value = "0";
                        rs.MoveNext();

                    }
                }
            }
            catch { }
        }

        #endregion

        private void ComboBox1_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            txtPOInv.Value = "";
            txtBsDocEn.Value = "";
            txtParCode.Value = "";
            txtParName.Value = "";
            txtWhsCode.Value = "";
            txtWhName.Value = "";
            Matrix0.Clear();

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (!Validation())
            {
                BubbleEvent = false;
                return;
            }

            if (Button0.Caption == "Add")
            {
                txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OGTP").ToString();

            }

        }

        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Select")
            {
                SAPbouiCOM.CheckBox select = Matrix0.GetCellSpecific("Select", pVal.Row) as SAPbouiCOM.CheckBox;
                SAPbouiCOM.EditText inExitQty = Matrix0.GetCellSpecific("InExitQty", pVal.Row) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText qty = Matrix0.GetCellSpecific("Qty", pVal.Row) as SAPbouiCOM.EditText;
                if (select.Caption == "Y")
                {
                    inExitQty.Value = qty.Value;
                }

                if (select.Caption == "N")
                {
                    inExitQty.Value = "0";
                }
            }
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(ComboBox0.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please select Transaction Type", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }

            if (string.IsNullOrEmpty(ComboBox1.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please select Ref DocType", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPOInv.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please select PO/Invoice", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtGatEnNo.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please enter Gateentry number", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtVehNum.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please enter Vehicle number", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;

            }
            
            return true;
        }
    }
}
