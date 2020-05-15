using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using NepaliDateConverter;
using System.Globalization;
using ITNepal.MainLibrary.SAPB1;
using SAPbobsCOM;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.Provisional_Cost", "Provisional Cost.b1f")]
    class Provisional_Cost : UserFormBase
    {
        public Provisional_Cost()
        {
            BasicSetup();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtDocNo = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNo").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtDocDt = ((SAPbouiCOM.EditText)(this.GetItem("txtDocDt").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.txtMiti = ((SAPbouiCOM.EditText)(this.GetItem("txtMiti").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_6").Specific));
            this.Matrix0.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.Matrix0_ChooseFromListBefore);
            this.Matrix0.KeyDownAfter += new SAPbouiCOM._IMatrixEvents_KeyDownAfterEventHandler(this.Matrix0_KeyDownAfter);
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.txtPrepBy = ((SAPbouiCOM.EditText)(this.GetItem("txtPrepBy").Specific));
            this.txtPrepBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPrepBy_ChooseFromListAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.txtRmrk = ((SAPbouiCOM.EditText)(this.GetItem("txtRmrk").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.oForm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
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
            oForm.EnableMenu("1292", true);
            oForm.EnableMenu("1293", true);
            oForm.EnableMenu("1287", true);
        }

        #region Declarations

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText txtDocNo;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtDocDt;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText txtMiti;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.EditText txtPrepBy;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText txtRmrk;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Form oForm;

        #endregion

        #region Events

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                oForm = Program.SBO_Application.Forms.ActiveForm;
                if (oForm.Title.Trim() == "Provisional Cost")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            BasicSetup();
                        }
                        if (pVal.MenuUID == "1281")
                        {
                            txtDocNo.Item.Enabled = true;
                        }
                        if (pVal.MenuUID == "1287")
                        {
                            txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OPRC").ToString();
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
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)oForm.Items.Item("Item_6").Specific;

                            for (int i = 1; i <= mtxBOM.RowCount; i++)
                            {
                                if (Matrix0.IsRowSelected(i))
                                {
                                    Matrix0.DeleteRow(i);
                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                    {
                                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
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

        private void txtPrepBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                try
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OPRC").SetValue("U_PREPBY", 0, pCFL.SelectedObjects.GetValue("lastName", 0).ToString() + ", " + pCFL.SelectedObjects.GetValue("firstName", 0).ToString());
                }
                catch { }
            }
        }

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "ItemCode")
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
                try
                {
                    SAPbouiCOM.EditText itemCode = Matrix0.GetCellSpecific("ItemCode", pVal.Row) as SAPbouiCOM.EditText;
                    itemCode.Value = oTable.GetValue("ItemCode", 0).ToString();
                }
                catch { }
                try
                {
                    SAPbouiCOM.EditText itemName = Matrix0.GetCellSpecific("ItemName", pVal.Row) as SAPbouiCOM.EditText;
                    itemName.Value = oTable.GetValue("ItemName", 0).ToString();
                }
                catch { }
            }

            Matrix0.AddLine();
            Extentions.SetLineId(Matrix0);
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
                txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OPRC").ToString();
            }
            this.DeleteBlankRow();

        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            BasicSetup();
        }

        private void Matrix0_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "ItemCode")
            {
                if (pVal.CharPressed == 8)
                {
                    SAPbouiCOM.EditText itemName = Matrix0.GetCellSpecific("ItemName", pVal.Row) as SAPbouiCOM.EditText;
                    itemName.Value = "";
                }
            }
        }

        private void Matrix0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbobsCOM.Recordset rec = null;
            try
            {
                SAPbouiCOM.ChooseFromList oCFL = this.UIAPIRawForm.ChooseFromLists.Item("ItemCode");
                SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable oTable = chList.SelectedObjects;

                oCFL.SetConditions(null);
                SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
                SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                oCons = oCFL.GetConditions();


                rec = ((SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset));
                string query = "select \"DocEntry\" FROM \"OITM\"  WHERE \"ItemCode\" NOT IN (SELECT DISTINCT \"U_ITEMCODE\" FROM \"@ITN_PRC1\")";
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

        #endregion

        #region Methods

        private void BasicSetup()
        {
            try
            {
                var date = DateTime.Now.ToString("yyyyMMdd");
                txtDocDt.Value = date;
                txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OPRC").ToString();

                DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateConverter convertedDate = DateConverter.ConvertToNepali(dt.Year, dt.Month, dt.Day);
                String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                txtMiti.Value = bsString;
                Matrix0.AddLine();
                Extentions.SetLineId(Matrix0);
                Matrix0.AutoResizeColumns();
            }
            catch { }
        }

        private void DeleteBlankRow()
        {
            try
            {

                int i = 0;
                int Row = Matrix0.RowCount;
                for (i = 1; i <= Matrix0.RowCount; i++)
                {
                    if (string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItemCode").Cells.Item(i).Specific).Value.ToString().Trim()))
                    {
                        Matrix0.DeleteRow(i);
                        i = 0;
                        Row = Row - 1;
                    }
                }
            }
            catch { }
        }

        private bool Validation()
        {
            for (int row = 1; row <= Matrix0.RowCount - 1; row++)
            {
                SAPbouiCOM.EditText txtLCCharge = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("LcCharge", row);
                SAPbouiCOM.EditText txtInsChrge = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("InsChrge", row);
                SAPbouiCOM.EditText txtCusDuty = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("CusDuty", row);
                SAPbouiCOM.EditText txtClrCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("ClrCost", row);
                SAPbouiCOM.EditText txtUnExp = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("UnExp", row);
                SAPbouiCOM.EditText txtDocHnChr = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("DocHnChr", row);
                SAPbouiCOM.EditText txtAccCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("AccCost", row);
                SAPbouiCOM.EditText txtRqrCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("RqrCost", row);
                SAPbouiCOM.EditText txtCusTrCst = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("CusTrCst", row);
                SAPbouiCOM.EditText txtNpClrCst = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("NpClrCst", row);
                SAPbouiCOM.EditText txtTrnsCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("TrnsCost", row);
                SAPbouiCOM.EditText txtDentCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("DentCost", row);
                SAPbouiCOM.EditText txtDemCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("DemCost", row);
                SAPbouiCOM.EditText txtAddCost = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("AddCost", row);

                if (txtLCCharge.Value == "0.0" && txtInsChrge.Value == "0.0" && txtCusDuty.Value == "0.0" && txtClrCost.Value == "0.0" && txtUnExp.Value == "0.0" && txtDocHnChr.Value == "0.0" &&
                    txtAccCost.Value == "0.0" && txtRqrCost.Value == "0.0" && txtCusTrCst.Value == "0.0" && txtNpClrCst.Value == "0.0" && txtTrnsCost.Value == "0.0" && txtDentCost.Value == "0.0" &&
                    txtDemCost.Value == "0.0" && txtAddCost.Value == "0.0")
                {
                    Program.SBO_Application.StatusBar.SetText("Please enter value either in LC Charges/Insurance Charges/Custom Duty/Clearing Cost Kolkata/Unloading Expenses/Document Handling Charges/Acceptance Cost/Retirement/Settlement cost / 11	India/Kolkata-Nepal custom  transport cost/Nepal clearing cost /Nepal custom -UDN Transport cost  /Detention Cost /Demurrage Cost /Other Additional Costs", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }

            }

            if (string.IsNullOrEmpty(txtPrepBy.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please Enter Prepared By", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }

            return true;
        }

        #endregion


    }
}
