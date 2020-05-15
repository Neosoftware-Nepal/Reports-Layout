using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using System.Globalization;
using NepaliDateConverter;

namespace Sales_Addon_UDN
{
    [FormAttribute("PROSTUP", "PromotionSetUp.b1f")]
    class PromotionSetUp : UserFormBase
    {
        public PromotionSetUp()
        {
            try
            {

            }
            catch
            {
            }
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtPcode = ((SAPbouiCOM.EditText)(this.GetItem("txtPcode").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.txtProNm = ((SAPbouiCOM.EditText)(this.GetItem("txtProNm").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.cmbPtyp = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbPtyp").Specific));
            this.cmbPtyp.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.cmbPtyp_ComboSelectAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.txtVpCd = ((SAPbouiCOM.EditText)(this.GetItem("txtVpCd").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.cmbCsubC = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbCsubC").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.txtCCode = ((SAPbouiCOM.EditText)(this.GetItem("txtCCode").Specific));
            this.txtCCode.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.txtCCode_ChooseFromListBefore);
            this.txtCCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtCCode_ChooseFromListAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.txtMitiDt = ((SAPbouiCOM.EditText)(this.GetItem("txtMitiDt").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.txtDt = ((SAPbouiCOM.EditText)(this.GetItem("txtDt").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.txtEFrmdt = ((SAPbouiCOM.EditText)(this.GetItem("txtEFrmdt").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.txtEffdt = ((SAPbouiCOM.EditText)(this.GetItem("txtEffdt").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.txtAllQty = ((SAPbouiCOM.EditText)(this.GetItem("txtAllQty").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_30").Specific));
            this.Matrix0.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.Matrix0_ComboSelectAfter);
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.Matrix0.KeyDownBefore += new SAPbouiCOM._IMatrixEvents_KeyDownBeforeEventHandler(this.Matrix0_KeyDownBefore);
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_31").Specific));
            this.txtPreby = ((SAPbouiCOM.EditText)(this.GetItem("txtPreby").Specific));
            this.txtPreby.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPreby_ChooseFromListAfter);
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_33").Specific));
            this.txtRmk1 = ((SAPbouiCOM.EditText)(this.GetItem("txtRmk1").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_40").Specific));
            this.txtChkby = ((SAPbouiCOM.EditText)(this.GetItem("txtChkby").Specific));
            this.txtChkby.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtChkby_ChooseFromListAfter);
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_42").Specific));
            this.txtRmk2 = ((SAPbouiCOM.EditText)(this.GetItem("txtRmk2").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Ofrm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_47").Specific));
            this.txtDocnum = ((SAPbouiCOM.EditText)(this.GetItem("txtDocnum").Specific));
            this.txtChnCd = ((SAPbouiCOM.EditText)(this.GetItem("txtChnCd").Specific));
            this.txtChnCd.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtChnCd_ChooseFromListAfter);
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_50").Specific));
            this.CheckBox0.ClickAfter += new SAPbouiCOM._ICheckBoxEvents_ClickAfterEventHandler(this.CheckBox0_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.DataLoadBefore += new DataLoadBeforeHandler(this.Form_DataLoadBefore);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            try
            {
                Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
                Ofrm.EnableMenu("1292", true);
                Ofrm.EnableMenu("1293", true);
                Ofrm.EnableMenu("1287", true);
                BasicBinding();
            }
            catch
            {
            }
        }

        #region Declaration

        private SAPbouiCOM.EditText txtPcode;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText txtProNm;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.ComboBox cmbPtyp;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText txtVpCd;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.ComboBox cmbCsubC;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText txtCCode;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText txtMitiDt;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText txtDt;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText txtEFrmdt;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText txtEffdt;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText txtAllQty;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText txtPreby;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText txtRmk1;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText txtChkby;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.EditText txtRmk2;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Form Ofrm;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.EditText txtDocnum;
        private SAPbobsCOM.Recordset rec;

        #endregion

        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                // Matrix0.AutoResizeColumns();

                //StaticText14.Item.Top = Matrix0.Item.Top + Matrix0.Item.Height + 10;
                //txtDocNu.Item.Top = txtPcode.Item.Top;
                //txtDocNu.Item.Left = this.UIAPIRawForm.Width - txtDocNu.Item.Width - 50;
                //StaticText1.Item.Top = txtDocNu.Item.Top; 
            }
            catch
            {

            }

        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Ofrm = Program.SBO_Application.Forms.ActiveForm;
                if (Ofrm.Title == "Promotion Setup")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1287")
                        {
                            BasicBinding();
                            Enable_Disable();

                        }
                        if (pVal.MenuUID == "1282")
                        {
                            BasicBinding();
                            foreach (SAPbouiCOM.Item item in Ofrm.Items)
                            {
                                item.Enabled = true;
                            }
                        }
                        if (pVal.MenuUID == "1281")
                        {
                            txtDocnum.Item.Enabled = true;
                            foreach (SAPbouiCOM.Item item in Ofrm.Items)
                            {
                                item.Enabled = true;
                            }
                        }
                        if (pVal.MenuUID == "1288" || pVal.MenuUID == "1289" || pVal.MenuUID == "1290" || pVal.MenuUID == "1291")
                        {
                            foreach (SAPbouiCOM.Item item in Ofrm.Items)
                            {
                                if (item.UniqueID != "2" && item.UniqueID != "Item_50")
                                {
                                    item.Enabled = false;
                                }
                            }
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
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Ofrm.Items.Item("Item_8").Specific;
                            for (int i = 1; i <= mtxBOM.RowCount; i++)
                            {
                                if (Matrix0.IsRowSelected(i))
                                {
                                    Matrix0.DeleteRow(i);
                                    //mtrxSFG.AutoResizeColumns(); 
                                    if (Ofrm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                    {
                                        Ofrm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
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

        private void txtCCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
            try
            {
                txtCCode.Value = oTable.GetValue("CardCode", 0).ToString();
            }
            catch { }
        }

        private void txtCCode_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {

                SAPbouiCOM.ChooseFromList oCFLEvento = default(SAPbouiCOM.ChooseFromList);
                SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
                oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("OCRD");
                oCFLEvento.SetConditions(null);
                oCons = oCFLEvento.GetConditions();

                oCon = oCons.Add();
                oCon.Alias = "CardType";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = "C";
                oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;


                oCon = oCons.Add();
                oCon.Alias = "GroupCode";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = CustomerCode;

                oCFLEvento.SetConditions(oCons);
            }
            catch
            {
            }

        }

        private string CustomerCode;

        private SAPbouiCOM.EditText txtChnCd;

        private SAPbouiCOM.CheckBox CheckBox0;

        private void Matrix0_KeyDownBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.ColUID == "AppVal")
            {
                try
                {
                    if (pVal.CharPressed == 9)
                    {
                        Program.SBO_Application.SendKeys("+{F2}");
                        BubbleEvent = false;

                    }
                    if (pVal.CharPressed != 9 && pVal.CharPressed != 8)
                    {
                        if (true)
                        {
                            Program.SBO_Application.SetStatusBarMessage("You can not edit this field", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            BubbleEvent = false;
                            return;
                        }
                    }
                }
                catch
                {

                }
            }

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (Button0.Caption == "Add")
                {
                    if (!validation())
                    {
                        BubbleEvent = false;
                    }
                }
            }
            catch
            {
            }
        }
        private bool validation()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPcode.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Promo Code can't be blank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (string.IsNullOrEmpty(txtProNm.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Promo Code can't be blank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (string.IsNullOrEmpty(cmbPtyp.Selected.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Promo type can't be blank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (string.IsNullOrEmpty(txtEFrmdt.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Effective From Date can't be blank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (string.IsNullOrEmpty(txtEffdt.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Effective To Date can't be blank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void txtChkby_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPRO").SetValue("U_CHECKBY", 0, pCFL.SelectedObjects.GetValue("lastName", 0).ToString() + ", " + pCFL.SelectedObjects.GetValue("firstName", 0).ToString());
                }
            }
            catch
            {
            }
        }

        private void txtPreby_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPRO").SetValue("U_PREPBY", 0, pCFL.SelectedObjects.GetValue("lastName", 0).ToString() + ", " + pCFL.SelectedObjects.GetValue("firstName", 0).ToString());
                }
            }
            catch
            {
            }

        }

        private void BindCustSubChann()
        {
            try
            {
                string query = "Select U_SUBCHCD ,  U_SUBCHNM from \"@CUSUBGP\"";
                B1Helper.SAPFillComboValues(this.cmbCsubC, query);
            }
            catch
            {
            }
        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Button0.Caption == "Add")
                {
                    BasicBinding();
                }

            }
            catch
            {
            }

        }

        private void BasicBinding()
        {
            try
            {
                //Program.SBO_Application.StatusBar.SetText("Basic Binding Called", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                txtDocnum.Value = B1Helper.GetNextDocNum("@ITN_OPRO").ToString();
                Extentions.AddLine(Matrix0);
                Extentions.SetLineId(Matrix0);
                Matrix0.AutoResizeColumns();
                var date = DateTime.Now.ToString("yyyyMMdd");
                txtDt.Value = date;

                //miti date
                DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateConverter convertedDate = DateConverter.ConvertToNepali(dt.Year, dt.Month, dt.Day);
                String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                txtMitiDt.Value = bsString;
                BindCustSubChann();
                Matrix0.AutoResizeColumns();

            }
            catch
            {

            }
        }

        private void txtChnCd_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPRO").SetValue("U_CUSTCHNL", 0, pCFL.SelectedObjects.GetValue("GroupName", 0).ToString());
                }
                SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
                try
                {
                    CustomerCode = oTable.GetValue("GroupCode", 0).ToString();
                }
                catch { }
            }
            catch
            {
            }
        }



        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.EditText freeitem = Matrix0.GetCellSpecific("freeitm", pVal.Row) as SAPbouiCOM.EditText;
                if (pVal.ColUID == "freeitm")
                {
                    SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                    SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
                    try
                    {
                        freeitem.Value = oTable.GetValue("ItemCode", 0).ToString();

                    }
                    catch { }
                }
            }
            catch
            {
            }
        }

        private void cmbPtyp_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Enable_Disable();
            Matrix0.Clear();
            Matrix0.AddRow();
        }

        private void Enable_Disable()
        {
            try
            {
                if (cmbPtyp.Selected.Value == "F")
                {
                    Matrix0.Columns.Item("PurFrmQ").Editable = false;
                    Matrix0.Columns.Item("PurToQty").Editable = false;
                    Matrix0.Columns.Item("InvDis").Editable = true;
                    Matrix0.Columns.Item("Disc").Editable = false;
                    Matrix0.Columns.Item("freeitm").Editable = false;
                    Matrix0.Columns.Item("freeqty").Editable = false;

                }
                else if (cmbPtyp.Selected.Value == "FB")
                {
                    Matrix0.Columns.Item("freeitm").Editable = true;
                    Matrix0.Columns.Item("freeqty").Editable = true;
                    Matrix0.Columns.Item("PurFrmQ").Editable = true;
                    Matrix0.Columns.Item("PurToQty").Editable = true;
                    Matrix0.Columns.Item("InvDis").Editable = false;
                    Matrix0.Columns.Item("Disc").Editable = false;

                }
                else if (cmbPtyp.Selected.Value == "O")
                {
                    Matrix0.Columns.Item("freeitm").Editable = true;
                    Matrix0.Columns.Item("freeqty").Editable = true;
                    Matrix0.Columns.Item("PurFrmQ").Editable = true;
                    Matrix0.Columns.Item("PurToQty").Editable = true;
                    Matrix0.Columns.Item("InvDis").Editable = false;
                    Matrix0.Columns.Item("Disc").Editable = true;

                }
                Matrix0.AutoResizeColumns();
            }
            catch
            {

            }
        }

        private void Matrix0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "AppTyp")
                {
                    SAPbouiCOM.ComboBox appliedcmb = Matrix0.GetCellSpecific("AppTyp", pVal.Row) as SAPbouiCOM.ComboBox;
                    resetmatrixrow(pVal.Row);
                    if (cmbPtyp.Selected.Value == "O")
                    {
                        if (appliedcmb.Selected.Value == "B")
                        {
                            Matrix0.Columns.Item("PurFrmQ").Editable = true;
                            Matrix0.Columns.Item("PurToQty").Editable = true;
                            Matrix0.Columns.Item("Disc").Editable = true;
                            Matrix0.Columns.Item("InvDis").Editable = false;
                            Matrix0.Columns.Item("freeitm").Editable = false;
                            Matrix0.Columns.Item("freeqty").Editable = false;
                        }
                        else if (appliedcmb.Selected.Value == "S")
                        {
                            Matrix0.Columns.Item("PurFrmQ").Editable = true;
                            Matrix0.Columns.Item("PurToQty").Editable = true;
                            Matrix0.Columns.Item("Disc").Editable = false;
                            Matrix0.Columns.Item("InvDis").Editable = false;
                            Matrix0.Columns.Item("freeitm").Editable = true;
                            Matrix0.Columns.Item("freeqty").Editable = true;
                        }
                    }
                    Matrix0.AutoResizeColumns();
                }
                //else if (cmbPtyp.Selected.Value == "FB")
                //{
                //    Matrix0.Columns.Item("freeitm").Editable = true;
                //    Matrix0.Columns.Item("freeqty").Editable = true;
                //    Matrix0.Columns.Item("PurFrmQ").Editable = false;
                //    Matrix0.Columns.Item("PurToQty").Editable = false;
                //    Matrix0.Columns.Item("InvDis").Editable = false;
                //    Matrix0.Columns.Item("Disc").Editable = false;
                //}
            }
            catch
            {


            }

        }

        private void resetmatrixrow(int rownum)
        {
            try
            {
                SAPbouiCOM.EditText AppliedValue = Matrix0.GetCellSpecific("AppVal", rownum) as SAPbouiCOM.EditText;
                AppliedValue.Value = "";
                SAPbouiCOM.EditText PurFrmQ = Matrix0.GetCellSpecific("PurFrmQ", rownum) as SAPbouiCOM.EditText;
                PurFrmQ.Value = "";
                SAPbouiCOM.EditText PurToQty = Matrix0.GetCellSpecific("PurToQty", rownum) as SAPbouiCOM.EditText;
                PurToQty.Value = "";
                SAPbouiCOM.EditText InvDis = Matrix0.GetCellSpecific("InvDis", rownum) as SAPbouiCOM.EditText;
                InvDis.Value = "";
                SAPbouiCOM.EditText Disc = Matrix0.GetCellSpecific("Disc", rownum) as SAPbouiCOM.EditText;
                Disc.Value = "";
                SAPbouiCOM.EditText freeitm = Matrix0.GetCellSpecific("freeitm", rownum) as SAPbouiCOM.EditText;
                freeitm.Value = "";
                SAPbouiCOM.EditText freeqty = Matrix0.GetCellSpecific("freeqty", rownum) as SAPbouiCOM.EditText;
                freeqty.Value = "";
                SAPbouiCOM.EditText rmks = Matrix0.GetCellSpecific("rmks", rownum) as SAPbouiCOM.EditText;
                rmks.Value = "";
                SAPbouiCOM.CheckBox Act = Matrix0.GetCellSpecific("AppVal", rownum) as SAPbouiCOM.CheckBox;
                if (Act.Checked)
                {
                    Act.Checked = false;
                }

            }
            catch
            {
            }
        }

        private void CheckBox0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                //bool check = CheckBox0.Checked; 
                //if(!txtPcode.Item.Enabled)
                //{
                //    foreach (SAPbouiCOM.Item item in Ofrm.Items)
                //    {
                //        if (item.UniqueID != "2" && item.UniqueID != "Item_50")
                //        {
                //            item.Enabled = false;
                //        }
                //    }
                //}
            }
            catch
            {
            }
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //throw new System.NotImplementedException();

            //txtPcode.Item.Enabled = false;
            //foreach (SAPbouiCOM.Item item in Ofrm.Items)
            //{
            //    if (item.UniqueID != "2" && item.UniqueID != "Item_50")
            //    {
            //        item.Enabled = false;
            //    }
            //}

        }

        private void Form_DataLoadBefore(ref SAPbouiCOM.BusinessObjectInfo pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();


        }

    }
}
