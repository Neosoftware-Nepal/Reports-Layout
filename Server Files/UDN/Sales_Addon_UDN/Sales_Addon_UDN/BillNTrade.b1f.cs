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
    [FormAttribute("BILLNTRD", "BillNTrade.b1f")]
    class BillNTrade : UserFormBase
    {
        public BillNTrade()
        {
            BasicBinding();
        }

        private void BasicBinding()
        {
            try
            {
                txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OBTD").ToString();
                var date = System.DateTime.Now;
                txtDate.Value = date.ToString("yyyyMMdd");

                DateConverter convertedDate = DateConverter.ConvertToNepali(date.Year, date.Month, date.Day);
                string bsString = convertedDate.Year + convertedDate.Month.ToString("00") + convertedDate.Day.ToString("00");
                txtMiti.Value = bsString;
                Matrix0.AddRow();
                Extentions.SetLineId(Matrix0);
            }
            catch { }
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtDocNum = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNum").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtDate = ((SAPbouiCOM.EditText)(this.GetItem("txtDate").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_6").Specific));
            this.Matrix0.KeyDownBefore += new SAPbouiCOM._IMatrixEvents_KeyDownBeforeEventHandler(this.Matrix0_KeyDownBefore);
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.Matrix0.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.Matrix0_ChooseFromListBefore);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.txtRemarks = ((SAPbouiCOM.EditText)(this.GetItem("txtRemarks").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.txtMiti = ((SAPbouiCOM.EditText)(this.GetItem("txtMiti").Specific));
            this.txtPrepBy = ((SAPbouiCOM.EditText)(this.GetItem("txtPrepBy").Specific));
            this.txtPrepBy.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtPrepBy_ChooseFromListAfter);
            this.Ofrm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
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
            Ofrm.EnableMenu("1292", true);
            Ofrm.EnableMenu("1293", true);
            Matrix0.AutoResizeColumns();



            string businessUnitQuery = "SELECT T0.\"GroupCode\", T0.\"GroupName\" FROM OCQG T0 WHERE T0.\"GroupName\" NOT LIKE 'Business%'";

            SAPbouiCOM.ComboBox comboBusunit = Matrix0.GetCellSpecific("BusUnit", 1) as SAPbouiCOM.ComboBox;
            B1Helper.SAPFillComboValues(comboBusunit, businessUnitQuery);

            //Program.CreateFMS();

            string Query1 = "SELECT DISTINCT T0.\"U_BRND\", T0.\"U_BRND\" FROM OITM T0 WHERE T0.\"U_BRND\" != '?'";
            SAPbouiCOM.ComboBox comboBrand = Matrix0.GetCellSpecific("Brand", 1) as SAPbouiCOM.ComboBox;
            B1Helper.ClearCombo(comboBrand);
            B1Helper.SAPFillComboValues(comboBrand, Query1);

        }

        #region Declarations

        private SAPbouiCOM.EditText txtDocNum;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtDate;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText txtMiti;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Form Ofrm;
        private SAPbobsCOM.Recordset rec;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText txtRemarks;
        private SAPbouiCOM.EditText txtPrepBy;
        private SAPbouiCOM.Button Button2;
        public string groupCode = "";
        public string groupName = "";
        #endregion

        #region Events

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Ofrm = Program.SBO_Application.Forms.ActiveForm;
                if (Ofrm.Title.Trim() == "Bill and Trade Discount Setup")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            BasicBinding();
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
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Ofrm.Items.Item("Item_6").Specific;
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

        private void Matrix0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.ColUID == "Cust")
                {
                    SAPbouiCOM.ChooseFromList oCFLEvento = default(SAPbouiCOM.ChooseFromList);
                    SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                    SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
                    oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("Customer");
                    oCFLEvento.SetConditions(null);
                    oCons = oCFLEvento.GetConditions();

                    oCon = oCons.Add();
                    oCon.Alias = "CardType";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = "C";


                    SAPbouiCOM.EditText channelname = Matrix0.GetCellSpecific("CustChn", pVal.Row) as SAPbouiCOM.EditText;
                    if (!string.IsNullOrEmpty(channelname.Value))
                    {
                        oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;
                        oCon = oCons.Add();
                        oCon.Alias = "GroupCode";
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCon.CondVal = groupCode;
                    }

                    oCFLEvento.SetConditions(oCons);
                }

            }
            catch { }
        }

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "CustChn")
                {
                    SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                    SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
                    groupCode = oTable.GetValue("GroupCode", 0).ToString();
                    groupName = oTable.GetValue("GroupName", 0).ToString();

                    try
                    {
                        SAPbouiCOM.EditText txtCustomerChannel = Matrix0.GetCellSpecific("CustChn", pVal.Row) as SAPbouiCOM.EditText;
                        txtCustomerChannel.Value = groupCode;
                    }
                    catch { }

                    try
                    {
                        SAPbouiCOM.EditText txtChannelCode = Matrix0.GetCellSpecific("CustCode", pVal.Row) as SAPbouiCOM.EditText;
                        txtChannelCode.Value = groupName;
                    }
                    catch { }

                    int rowcount = Matrix0.RowCount;
                    SAPbouiCOM.EditText customer = Matrix0.GetCellSpecific("CustChn", rowcount) as SAPbouiCOM.EditText;

                    if (!string.IsNullOrEmpty(customer.Value))
                    {
                        Matrix0.AddRow();
                        Extentions.SetLineId(Matrix0);
                    }

                    string Query = "SELECT T0.\"U_SUBCHCD\", T0.\"U_SUBCHNM\" FROM \"@CUSUBGP\" T0 ";
                    SAPbouiCOM.ComboBox comboCustomerChannel = Matrix0.GetCellSpecific("CustSubCHN", pVal.Row) as SAPbouiCOM.ComboBox;
                    Query = string.Format(Query, groupName);
                    B1Helper.SAPFillComboValues(comboCustomerChannel, Query);

                }
                else if (pVal.ColUID == "Cust")
                {

                    SAPbouiCOM.ISBOChooseFromListEventArg pCFL = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;

                    SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                    SAPbouiCOM.EditText txtCustomer;
                    try
                    {
                        txtCustomer = Matrix0.GetCellSpecific("Cust", pVal.Row) as SAPbouiCOM.EditText;
                        txtCustomer.Value = oTable.GetValue("CardCode", 0).ToString();
                    }
                    catch { }

                    try
                    {
                        txtCustomer = Matrix0.GetCellSpecific("CustName", pVal.Row) as SAPbouiCOM.EditText;
                        txtCustomer.Value = oTable.GetValue("CardName", 0).ToString();
                    }
                    catch { }

                    try
                    {
                        SAPbouiCOM.ComboBox comboCustomerChannel = Matrix0.GetCellSpecific("BusUnit", pVal.Row) as SAPbouiCOM.ComboBox;
                        SAPbouiCOM.EditText custCode = Matrix0.GetCellSpecific("Cust", pVal.Row) as SAPbouiCOM.EditText;
                        if (!string.IsNullOrEmpty(custCode.Value))
                        {
                            //B1Helper.SAPFillComboValues(comboCustomerChannel, Query);
                            GlobalVariable.Globals.setgroupcode(oTable.GetValue("CardCode", 0).ToString(), comboCustomerChannel);
                        }
                    }
                    catch { }

                }
                else if (pVal.ColUID == "SKU")
                {
                    SAPbouiCOM.ISBOChooseFromListEventArg CFL = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;
                    SAPbouiCOM.DataTable otable = CFL.SelectedObjects;
                    try
                    {
                        SAPbouiCOM.EditText txtSKU = Matrix0.GetCellSpecific("SKU", pVal.Row) as SAPbouiCOM.EditText;
                        txtSKU.Value = otable.GetValue("ItemCode", 0).ToString();
                    }
                    catch { }

                    try
                    {
                        SAPbouiCOM.EditText txtSKU = Matrix0.GetCellSpecific("SKUName", pVal.Row) as SAPbouiCOM.EditText;
                        txtSKU.Value = otable.GetValue("ItemName", 0).ToString();
                    }
                    catch { }

                }
            }
            catch { }
        }

        private void ChooseFromListCondition(SAPbouiCOM.ISBOChooseFromListEventArg pVal, string aliasName, string condVal)
        {
            try
            {
                var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;

                SAPbouiCOM.Conditions oConditions;
                SAPbouiCOM.Condition oCondition;
                SAPbouiCOM.ChooseFromList oChooseFromList;
                SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
                oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID);
                oChooseFromList.SetConditions(emptyCon);
                oConditions = oChooseFromList.GetConditions();



                oCondition = oConditions.Add();
                oCondition.Alias = aliasName;
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = condVal;
                oChooseFromList.SetConditions(oConditions);
            }
            catch { }

        }

        private void cflPrepBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                if (pCFL.SelectedObjects != null)
                {
                    SAPbouiCOM.DataTable oTable = pCFL.SelectedObjects;
                    try
                    {
                        txtPrepBy.Value = oTable.GetValue("lastName", 0).ToString() + ", " + oTable.GetValue("firstName", 0).ToString();
                    }
                    catch
                    {

                    }
                }
            }
            catch { }
        }

        private void txtPrepBy_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.DBDataSources.Item("@ITN_OBTD").SetValue("U_PrepBy", 0, pCFL.SelectedObjects.GetValue("lastName", 0).ToString() + ", " + pCFL.SelectedObjects.GetValue("firstName", 0).ToString());
                }
            }
            catch { }
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (!Validation())
                {
                    BubbleEvent = false;
                    return;
                }
                if (Button0.Caption == "Add")
                {
                    txtDocNum.Value = B1Helper.GetNextDocNum("@ITN_OBTD").ToString();

                }
                this.DeleteBlankRow();
            }
            catch { }

        }

        private void Matrix0_KeyDownBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.ColUID == "Brand")
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
                    catch { }
                }
            }
            catch { }

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
            catch { }
        }

        #endregion

        #region Methods

        private bool checkSubChan(string SubchanelCode, string Custgroup)
        {
            try
            {
                string query = "Select * from \"CUSUBGP\" Where SUBCHCD = '" + SubchanelCode + "' and CGRP = '" + Custgroup + "' ";
                rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rec.DoQuery(query);
                if (rec.RecordCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        private void DeleteBlankRow()
        {
            try
            {

                int i = 0;
                int Row = Matrix0.RowCount;
                for (i = 1; i <= Matrix0.RowCount; i++)
                {
                    if (string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix0.Columns.Item("CustChn").Cells.Item(i).Specific).Value.ToString().Trim()))
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
            int rowCount = Matrix0.RowCount;
            try
            {
                for (int rownum = 1; rownum <= rowCount; rownum++)
                {
                    SAPbouiCOM.EditText group = Matrix0.GetCellSpecific("CustChn", rownum) as SAPbouiCOM.EditText;
                    SAPbouiCOM.ComboBox subChannel = Matrix0.GetCellSpecific("CustSubCHN", rownum) as SAPbouiCOM.ComboBox;
                    SAPbouiCOM.EditText customer = Matrix0.GetCellSpecific("Cust", rownum) as SAPbouiCOM.EditText;
                    SAPbouiCOM.ComboBox busUnit = Matrix0.GetCellSpecific("BusUnit", rownum) as SAPbouiCOM.ComboBox;
                    SAPbouiCOM.ComboBox category = Matrix0.GetCellSpecific("Category", rownum) as SAPbouiCOM.ComboBox;
                    SAPbouiCOM.ComboBox brand = Matrix0.GetCellSpecific("Brand", rownum) as SAPbouiCOM.ComboBox;
                    SAPbouiCOM.EditText sku = Matrix0.GetCellSpecific("SKU", rownum) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText billDiscnt = Matrix0.GetCellSpecific("BillDiscnt", rownum) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText tradDis = Matrix0.GetCellSpecific("tradDis", rownum) as SAPbouiCOM.EditText;


                    if (rownum == 1 && string.IsNullOrEmpty(group.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Please enter Customer Channel", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        return false;

                    }

                    if (!string.IsNullOrEmpty(group.Value))
                    {
                        if (string.IsNullOrEmpty(subChannel.Value) && string.IsNullOrEmpty(customer.Value) && string.IsNullOrEmpty(busUnit.Value) && string.IsNullOrEmpty(category.Value) && string.IsNullOrEmpty(brand.Value) && string.IsNullOrEmpty(sku.Value))
                        {
                            Program.SBO_Application.StatusBar.SetText("Please enter Group or SubChannel or Customer or BusUnit or Category or Brand or SKU", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            return false;
                        }

                        if (billDiscnt.Value == "0.0")
                        {
                            Program.SBO_Application.StatusBar.SetText("Please enter Bill Discount", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            return false;
                        }

                        if (tradDis.Value == "0.0")
                        {
                            Program.SBO_Application.StatusBar.SetText("Please enter Trade Discount", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            return false;
                        }

                    }
                }

                if (string.IsNullOrEmpty(txtPrepBy.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("PreparedBy cannot be empty", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }

            }
            catch
            {
                return false;
            }


            return true;
        }
        #endregion

    }
}
