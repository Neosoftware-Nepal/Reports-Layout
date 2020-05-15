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
    [FormAttribute("Sales_Addon_UDN.ProofOfDel", "ProofOfDelivery.b1f")]
    class ProofOfDelivery : UserFormBase
    {
        public ProofOfDelivery()
        {
            BasicSetup();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        /// 
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtInvNo = ((SAPbouiCOM.EditText)(this.GetItem("txtInvNo").Specific));
            this.txtInvNo.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.txtInvNo_ChooseFromListBefore);
            this.txtInvNo.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.txtInvNo_KeyDownAfter);
            this.txtInvNo.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtInvNo_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtInvDt = ((SAPbouiCOM.EditText)(this.GetItem("txtInvDt").Specific));
            this.txtCusCode = ((SAPbouiCOM.EditText)(this.GetItem("txtCusCode").Specific));
            this.txtCusCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtCusCode_ChooseFromListAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.txtCusName = ((SAPbouiCOM.EditText)(this.GetItem("txtCusName").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.txtRecBy = ((SAPbouiCOM.EditText)(this.GetItem("txtRecBy").Specific));
            this.txtRecBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtRecBy_ChooseFromListAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("InvLink").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("CusLink").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.txtDocNum = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNum").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.txtDate = ((SAPbouiCOM.EditText)(this.GetItem("txtDate").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.txtMiti = ((SAPbouiCOM.EditText)(this.GetItem("txtMiti").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_22").Specific));
            this.Matrix0.ValidateBefore += new SAPbouiCOM._IMatrixEvents_ValidateBeforeEventHandler(this.Matrix0_ValidateBefore);
            this.Matrix0.ClickBefore += new SAPbouiCOM._IMatrixEvents_ClickBeforeEventHandler(this.Matrix0_ClickBefore);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.txtAttc = ((SAPbouiCOM.EditText)(this.GetItem("txtAttc").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.txtPrepBy = ((SAPbouiCOM.EditText)(this.GetItem("txtPrepBy").Specific));
            this.txtPrepBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPrepBy_ChooseFromListAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.txtRemarks = ((SAPbouiCOM.EditText)(this.GetItem("txtRemarks").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
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
            Oform.EnableMenu("1287", true);
        }

        #region Declarations
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText txtInvNo;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtInvDt;
        private SAPbouiCOM.EditText txtCusCode;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText txtCusName;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText txtRecBy;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText txtDocNum;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText txtDate;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText txtMiti;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText txtAttc;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText txtPrepBy;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText txtRemarks;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Form Oform;
        #endregion

        #region Methods


        private void BasicSetup()
        {
            try
            {
                var date = DateTime.Now.ToString("yyyyMMdd");
                txtDate.Value = date;
                txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OPOD").ToString();

                DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateConverter convertedDate = DateConverter.ConvertToNepali(dt.Year, dt.Month, dt.Day);
                String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                txtMiti.Value = bsString;
                Matrix0.AutoResizeColumns();
            }
            catch { }
        }

        private void FillMatrix(string DocEntry)
        {
            try
            {
                Matrix0.Clear();
                string lineQuery = "SELECT \"ItemCode\", \"Dscription\",\"Quantity\" FROM INV1 WHERE \"DocEntry\" = '" + DocEntry + "'";

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rs.DoQuery(lineQuery);

                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < rs.RecordCount; i++)
                    {
                        Matrix0.AddRow();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(i + 1).Specific).Value = (i + 1).ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItemCode").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("ItemCode").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Desc").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Dscription").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("InvQty").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Quantity").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("DmgQty").Cells.Item(i + 1).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("shgeQty").Cells.Item(i + 1).Specific).Value = "0";
                        rs.MoveNext();
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Events

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Oform = Program.SBO_Application.Forms.ActiveForm;
                if (Oform.Title.Trim() == "Proof of Delivery")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            BasicSetup();
                        }
                        if (pVal.MenuUID == "1281")
                        {
                            txtDocNum.Item.Enabled = true;
                        }
                        if (pVal.MenuUID == "1287")
                        {
                            txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OPOD").ToString();
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
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Oform.Items.Item("Item_22").Specific;

                            for (int i = 1; i <= mtxBOM.RowCount; i++)
                            {
                                if (Matrix0.IsRowSelected(i))
                                {
                                    Matrix0.DeleteRow(i);
                                    //mtrxSFG.AutoResizeColumns(); 
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

        private void txtInvNo_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            string DocEntry = "";
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    DocEntry = oTable.GetValue("DocEntry", 0).ToString();
                    txtInvNo.Value = DocEntry;
                }
                catch { }
                try
                {
                    var DocDate = DateTime.Parse(oTable.GetValue("DocDate", 0).ToString());
                    var Date = DocDate.Year + DocDate.Month.ToString("00") + DocDate.Day.ToString("00");
                    txtInvDt.Value = Date;
                }
                catch { }
                try
                {
                    txtCusCode.Value = oTable.GetValue("CardCode", 0).ToString();
                }
                catch { }

                try
                {
                    txtCusName.Value = oTable.GetValue("CardName", 0).ToString();
                }
                catch { }
            }

            FillMatrix(DocEntry);

        }

        private void txtCusCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    txtCusCode.Value = oTable.GetValue("CardCode", 0).ToString();
                }
                catch { }
                try
                {
                    txtCusName.Value = oTable.GetValue("CardName", 0).ToString();

                }
                catch { }
            }

        }

        private void txtRecBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPOD").SetValue("U_RECIVEDBY", 0, oTable.GetValue("lastName", 0).ToString() + ", " + oTable.GetValue("firstName", 0).ToString());
                }
                catch { }
            }

        }

        private void txtPrepBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                try
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPOD").SetValue("U_PREPBY", 0, oTable.GetValue("lastName", 0).ToString() + ", " + oTable.GetValue("firstName", 0).ToString());

                }
                catch { }
            }

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (Button0.Caption == "Add")
            {
                txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OPOD").ToString();

            }
            if (!Validation(pVal))
            {
                BubbleEvent = false;
            }
        }

        private bool Validation(SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (string.IsNullOrEmpty(txtInvNo.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Invoice number cannot be empty", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }

            int invoiceQty = 0;
            int damageQty = 0;
            int shortageQty = 0;

            for (int i = 0; i < Matrix0.RowCount; i++)
            {
                SAPbouiCOM.EditText txtInvoiceQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("InvQty", i + 1);
                SAPbouiCOM.EditText txtDamageQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("DmgQty", i + 1);
                SAPbouiCOM.EditText txtShortageQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("shgeQty", i + 1);

                invoiceQty = Convert.ToInt32(txtInvoiceQty.Value);
                if (!string.IsNullOrEmpty(txtDamageQty.Value))
                {
                    damageQty = Convert.ToInt32(txtDamageQty.Value);
                }
                if (!string.IsNullOrEmpty(txtShortageQty.Value))
                {
                    shortageQty = Convert.ToInt32(txtShortageQty.Value);
                }
                if (invoiceQty < damageQty)
                {
                    Program.SBO_Application.StatusBar.SetText("Damage Quantity cannot be greater than Invoice Quantity", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (shortageQty > invoiceQty)
                {
                    Program.SBO_Application.StatusBar.SetText("Shortage quantity cannot be greater than invoice quantity", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if ((damageQty + shortageQty) > invoiceQty)
                {
                    Program.SBO_Application.StatusBar.SetText("Sum of damage quantity and shortage quantity cannot be greater than invoice quantity", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
            }
            return true;
        }

        private void txtInvNo_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.CharPressed == 8)
            {
                txtInvDt.Value = "";
                txtCusCode.Value = "";
                txtCusName.Value = "";
                Matrix0.Clear();
            }

        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            BasicSetup();
        }

        private void txtInvNo_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbobsCOM.Recordset rec = null;
            try
            {
                SAPbouiCOM.ChooseFromList oCFL = this.UIAPIRawForm.ChooseFromLists.Item("Invoice");
                SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable oTable = chList.SelectedObjects;

                oCFL.SetConditions(null);
                SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
                SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                oCons = oCFL.GetConditions();


                rec = ((SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset));
                string query = "SELECT DISTINCT \"DocEntry\" FROM OINV WHERE \"DocEntry\" NOT IN (SELECT DISTINCT \"U_INVOICENO\" FROM \"@ITN_OPOD\")";
                rec.DoQuery(query);
                int recordcount = rec.RecordCount - 1;
                if (rec.RecordCount > 0)
                {
                    while (!rec.EoF)
                    {
                        if (recordcount != 0)
                        {
                            oCon = oCons.Add();
                            oCon.Alias = "DocEntry";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = rec.Fields.Item("DocEntry").Value.ToString();
                            oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                        }
                        else
                        {
                            oCon = oCons.Add();
                            oCon.Alias = "DocEntry";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = rec.Fields.Item("DocEntry").Value.ToString();
                        }
                        recordcount = recordcount - 1;
                        rec.MoveNext();
                    }
                }
                else
                {
                    oCon = oCons.Add();
                    oCon.Alias = "DocEntry";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = "-1";
                }
                oCFL.SetConditions(oCons);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                GC.Collect();
                if (rec != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rec);
                rec = null;
            }
        }

        private void Matrix0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();

        }

        private void Matrix0_ValidateBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            int invoiceQty = 0;
            int damageQty = 0;
            int shortageQty = 0;

            SAPbouiCOM.EditText txtInvoiceQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("InvQty", pVal.Row);
            SAPbouiCOM.EditText txtDamageQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("DmgQty", pVal.Row);
            SAPbouiCOM.EditText txtShortageQty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("shgeQty", pVal.Row);

            if (pVal.ColUID == "DmgQty")
            {
                invoiceQty = Convert.ToInt32(txtInvoiceQty.Value);
                if (!string.IsNullOrEmpty(txtDamageQty.Value))
                {
                    damageQty = Convert.ToInt32(txtDamageQty.Value);
                }

                if (invoiceQty < damageQty)
                {
                    Program.SBO_Application.StatusBar.SetText("Damage Quantity cannot be greater than Invoice Quantity", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    txtDamageQty.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                    BubbleEvent = false;
                }
            }

            if (pVal.ColUID == "shgeQty")
            {
                invoiceQty = Convert.ToInt32(txtInvoiceQty.Value);
                if (!string.IsNullOrEmpty(txtDamageQty.Value))
                {
                    damageQty = Convert.ToInt32(txtDamageQty.Value);
                }
                if (!string.IsNullOrEmpty(txtShortageQty.Value))
                {
                    shortageQty = Convert.ToInt32(txtShortageQty.Value);
                }
                if (shortageQty > invoiceQty)
                {
                    Program.SBO_Application.StatusBar.SetText("Shortage quantity cannot be greater than invoice quantity", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                if ((damageQty + shortageQty) > invoiceQty)
                {
                    Program.SBO_Application.StatusBar.SetText("Sum of damage quantity and shortage quantity cannot be greater than invoice quantity", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
            }

        }
    }
        #endregion
}
