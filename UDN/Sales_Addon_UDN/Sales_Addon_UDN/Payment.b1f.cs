using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using NepaliDateConverter;
using System.Globalization;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.Payment", "Payment.b1f")]
    class PaymentUDO : UserFormBase
    {
        private SAPbouiCOM.DBDataSource oDBs_Head;

        public PaymentUDO()
        {
            BasicSetup();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("lblDocNo").Specific));
            this.txtDocNo = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNo").Specific));
            this.txtDocDate = ((SAPbouiCOM.EditText)(this.GetItem("txDocDate").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("lblDocDate").Specific));
            this.txtPreBy = ((SAPbouiCOM.EditText)(this.GetItem("txtPreBy").Specific));
            this.txtPreBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPreBy_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("lblBusUnit").Specific));
            this.comBusUnit = ((SAPbouiCOM.ComboBox)(this.GetItem("comBusUnit").Specific));
            this.comBusUnit.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.comBusUnit_ClickAfter);
            this.txtCheckBy = ((SAPbouiCOM.EditText)(this.GetItem("txtCheckBy").Specific));
            this.txtCheckBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtCheckBy_ChooseFromListAfter);
            this.txtRemarks = ((SAPbouiCOM.EditText)(this.GetItem("txtRemarks").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("mtx").Specific));
            this.Matrix0.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.Matrix0_ComboSelectAfter);
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.Matrix0.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.Matrix0_ChooseFromListBefore);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.txtMiti = ((SAPbouiCOM.EditText)(this.GetItem("txtMiti").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button1_PressedAfter);
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
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
            Oform.EnableMenu("1292", true);
            Oform.EnableMenu("1293", true);
            Oform.EnableMenu("1287", true);
            oDBs_Head = this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPAY");

            string Query = "SELECT T0.\"GroupCode\", T0.\"GroupName\" FROM OCQG T0 WHERE T0.\"GroupName\" NOT LIKE 'Business%'";
            B1Helper.SAPFillComboValues(this.comBusUnit, Query);

            SAPbouiCOM.ComboBox comboPayTerms = Matrix0.GetCellSpecific("colPayTerm", 1) as SAPbouiCOM.ComboBox;
            string Query1 = "SELECT T0.\"GroupNum\", T0.\"PymntGroup\" FROM OCTG T0";

            B1Helper.SAPFillComboValues(comboPayTerms, Query1);

            Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
        }

        #region Declarations

        private SAPbouiCOM.EditText txtDocNo;
        private SAPbouiCOM.EditText txtDocDate;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText txtPreBy;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox comBusUnit;
        private SAPbouiCOM.EditText txtCheckBy;
        private SAPbouiCOM.EditText txtRemarks;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText txtMiti;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Form Oform;
        private SAPbouiCOM.StaticText StaticText0;

        #endregion

        #region Events

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Oform = Program.SBO_Application.Forms.ActiveForm;
                if (Oform.Title == "Payment Term Setup")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            BasicSetup();
                        }
                        if (pVal.MenuUID == "1287")
                        {
                            txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OPAY").ToString();
                        }
                        if (pVal.MenuUID == "1281")
                        {
                            txtDocNo.Item.Enabled = true;
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
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Oform.Items.Item("mtx").Specific;

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

        private void comBusUnit_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Matrix0.Clear(); 
                Extentions.AddLine(Matrix0);
                Extentions.SetLineId(Matrix0);
            }
            catch
            {

            }

        }

        private void Matrix0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.ColUID == "colCusCode")
            {

                SAPbouiCOM.ChooseFromList oCFLEvento = default(SAPbouiCOM.ChooseFromList);
                SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
                oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("Cust");
                oCFLEvento.SetConditions(null);
                oCons = oCFLEvento.GetConditions();

                oCon = oCons.Add();
                oCon.Alias = "QryGroup" + comBusUnit.Selected.Value;
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = "Y";

                oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                oCon = oCons.Add();
                oCon.Alias = "CardType";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = "C";


                oCFLEvento.SetConditions(oCons);
            }

        }

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "colCusCode")
            {
                SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
                try
                {
                    SAPbouiCOM.EditText CardCode = Matrix0.GetCellSpecific("colCusCode", pVal.Row) as SAPbouiCOM.EditText;
                    CardCode.Value = oTable.GetValue("CardCode", 0).ToString();
                }
                catch { }
                try
                {
                    SAPbouiCOM.EditText CardName = Matrix0.GetCellSpecific("ColCusName", pVal.Row) as SAPbouiCOM.EditText;
                    CardName.Value = oTable.GetValue("CardName", 0).ToString();
                }
                catch { }

                Matrix0.AddRow();
                Extentions.SetLineId(Matrix0);
            }

        }

        private void txtPreBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                try
                {
                    oDBs_Head.SetValue("U_Prepby", 0, pCFL.SelectedObjects.GetValue("lastName", 0).ToString() + ", " + pCFL.SelectedObjects.GetValue("firstName", 0).ToString());
                }
                catch
                {

                }

            }
        }

        private void txtCheckBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_CheckBy", 0, pCFL.SelectedObjects.GetValue("lastName", 0).ToString() + ", " + pCFL.SelectedObjects.GetValue("firstName", 0).ToString());
            }
        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (!Validation())
            {
                BubbleEvent = false;
                return;
            }
            if (Button1.Caption == "Add")
            {
                txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OPAY").ToString();

            }
            DeleteBlankRow();

        }

        private void Matrix0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ComboBox combo = Matrix0.GetCellSpecific("colPayTerm", pVal.Row) as SAPbouiCOM.ComboBox;
            try
            {
                SAPbouiCOM.EditText txtPayCode = Matrix0.GetCellSpecific("paytrmname", pVal.Row) as SAPbouiCOM.EditText;
                txtPayCode.Value = combo.Selected.Description;
            }
            catch
            {
            }
        }

        #endregion

        private void DeleteBlankRow()
        {
            try
            {

                int i = 0;
                int Row = Matrix0.RowCount;
                for (i = 1; i <= Matrix0.RowCount; i++)
                {
                    if (string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix0.Columns.Item("colCusCode").Cells.Item(i).Specific).Value.ToString().Trim()))
                    {
                        Matrix0.DeleteRow(i);
                        i = 0;
                        Row = Row - 1;
                    }
                }
            }
            catch
            {
                //ExceptionLog.SendErrorToText(ex, "QCInspection");
            }
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(comBusUnit.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please select Business unit", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            int rowCount = Matrix0.RowCount;
            for (int rownum = 1; rownum <= rowCount; rownum++)
            {
                SAPbouiCOM.EditText cust = Matrix0.GetCellSpecific("colCusCode", rownum) as SAPbouiCOM.EditText;
                SAPbouiCOM.ComboBox payment = Matrix0.GetCellSpecific("colPayTerm", rownum) as SAPbouiCOM.ComboBox;

                if (rownum == 1 && string.IsNullOrEmpty(cust.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Please select customer", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (!string.IsNullOrEmpty(cust.Value))
                {
                    if (string.IsNullOrEmpty(payment.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Please select payment terms", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        return false;
                    }
                }

            }
            return true;

        }

        private void Button1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Button1.Caption == "Add")
                {
                    BasicSetup();
                }
            }
            catch
            {
            }

        }

        private void BasicSetup()
        {
            try
            {
                Oform.Freeze(true);
                var date = DateTime.Now.ToString("yyyyMMdd");
                txtDocDate.Value = date;
                txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OPAY").ToString();

                DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateConverter convertedDate = DateConverter.ConvertToNepali(dt.Year, dt.Month, dt.Day);
                String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                txtMiti.Value = bsString;
                Matrix0.AutoResizeColumns();
                Oform.Freeze(false);
            }
            catch
            {
                Oform.Freeze(false);
            }
        }

    }
}
