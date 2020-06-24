using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.MainLibrary.Utilities;


namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.MachinePricingMasterForm", "Forms/MachinePricingMasterForm.b1f")]
    public class MachinePricingMasterForm : B1FormBase
    {
        public MachinePricingMasterForm()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText tbMacCode;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText tbMacName;
        private SAPbouiCOM.Matrix MtxMPL;
        private SAPbouiCOM.Button btnOk;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.Button btnDelRow;
        private SAPbouiCOM.EditText tbCode;
        SAPbouiCOM.DBDataSource oDBs_Head;
        SAPbouiCOM.DBDataSource oDBs_Details;
        private int selectedRow;
        private string itemGroup;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.tbMacCode = ((SAPbouiCOM.EditText)(this.GetItem("MacCode").Specific));
            //   this.tbMacCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbMacCode_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.tbMacName = ((SAPbouiCOM.EditText)(this.GetItem("MacNam").Specific));
            this.MtxMPL = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_MPL").Specific));
            //       this.MtxMPL.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MtxMPL_ChooseFromListBefore);
            this.MtxMPL.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MtxMPL_ChooseFromListAfter);
            this.MtxMPL.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MtxMPL_LostFocusAfter);
            this.MtxMPL.PressedAfter += new SAPbouiCOM._IMatrixEvents_PressedAfterEventHandler(this.MtxMPL_PressedAfter);
            this.btnOk = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnOk.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnOk_PressedAfter);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.btnDelRow = ((SAPbouiCOM.Button)(this.GetItem("btnDelR").Specific));
            this.btnDelRow.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnDelRow_PressedAfter);
            this.tbCode = ((SAPbouiCOM.EditText)(this.GetItem("tb_Code").Specific));

            this.oDBs_Head = ((SAPbouiCOM.DBDataSource)(this.UIAPIRawForm.DataSources.DBDataSources.Item(("@Z_MPRM"))));
            this.oDBs_Details = ((SAPbouiCOM.DBDataSource)(this.UIAPIRawForm.DataSources.DBDataSources.Item(("@Z_MPM1"))));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
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
            try
            {
                var form = Application.SBO_Application.Forms.GetForm("150", Application.SBO_Application.Forms.ActiveForm.TypeCount);
                string itemCode = ((SAPbouiCOM.EditText)form.Items.Item("5").Specific).Value;
                this.UIAPIRawForm.Items.Item("MacCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
                //  this.UIAPIRawForm.Items.Item("MacCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 4, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
                this.UIAPIRawForm.Items.Item("MacNam").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
                // this.UIAPIRawForm.Items.Item("MacNam").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 4, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
                oDBs_Details = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_MPM1");
                this.UIAPIRawForm.Freeze(true);
                string code = checkItemExists(itemCode);
                if (code == string.Empty)
                {
                    this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_ADD_MODE;
                    int Code = B1Helper.GetNextCodeId("@" + TableNames.Z_MPRM);
                    this.tbCode.Value = Code.ToString();
                    this.EditText0.Value = code.ToString();
                    LoadItemMasterDataValues(form);
                }
                else
                {
                    this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                    this.UIAPIRawForm.Items.Item("tb_Code").Enabled = true;
                    this.tbCode.Value = code;
                    this.EditText0.Value = code;
                    this.UIAPIRawForm.DataBrowser.BrowseBy = "tb_Code";
                    this.UIAPIRawForm.Items.Item("1").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                    this.UIAPIRawForm.Items.Item("tb_Code").Enabled = false;
                    //   AddMatrixLine("");
                }
                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetSystemMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                this.UIAPIRawForm.Freeze(false);
            }

        }

        private string checkItemExists(string itemCode)
        {
            string query = "SELECT T0.\"Code\"  FROM \"@Z_MPRM\"  T0 WHERE T0.\"U_ModelNo\" = '" + itemCode + "'";
            SAPbobsCOM.Recordset rcSet = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rcSet.DoQuery(query);
            if (rcSet.RecordCount > 0)
            {
                string code = rcSet.Fields.Item(0).Value.ToString();
                return code;
            }
            return string.Empty;
        }

        private void LoadItemMasterDataValues(SAPbouiCOM.Form form)
        {
            oDBs_Head.SetValue("U_ModelNo", 0, ((SAPbouiCOM.EditText)form.Items.Item("5").Specific).Value);
            oDBs_Head.SetValue("U_ModelName", 0, ((SAPbouiCOM.EditText)form.Items.Item("7").Specific).Value);
            itemGroup = ((SAPbouiCOM.ComboBox)form.Items.Item("39").Specific).Value;
            AddMatrixLine(itemGroup);
        }


        private void tbMacCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_ModelNo", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue(0, 0).ToString());
                oDBs_Head.SetValue("U_ModelName", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue(1, 0).ToString());
            }

        }

        #region Methods
        private void AddMatrixLine(string itemGroup)
        {
            oDBs_Details = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_MPM1");
            MtxMPL.AddRow();
            oDBs_Details.SetValue("LineId", oDBs_Details.Offset, MtxMPL.VisualRowCount.ToString());
            oDBs_Details.SetValue("U_PaperSize", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_ProductCategory", oDBs_Details.Offset, itemGroup);
            oDBs_Details.SetValue("U_MeterCode", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_Color", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_StartRange", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_ToRange", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_BasePrice", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_ExcessPrice", oDBs_Details.Offset, "");
            MtxMPL.SetLineData(MtxMPL.VisualRowCount);
        }
        #endregion

        private void MtxMPL_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (MtxMPL.VisualRowCount > 1 && pVal.Row != 0 && pVal.Row <= MtxMPL.VisualRowCount && pVal.ColUID == "#")
            {
                MtxMPL.SelectRow(pVal.Row, true, false);
                selectedRow = pVal.Row;
            }

        }

        private void btnDelRow_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (selectedRow > 0)
            {
                if (MtxMPL.RowCount > 0 && MtxMPL.IsRowSelected(selectedRow))
                {
                    MtxMPL.DeleteRow(selectedRow);
                    UIAPIRawForm.Freeze(true);
                    for (int i = 1; i <= MtxMPL.VisualRowCount; i++)
                    {
                        MtxMPL.SetCellValue("#", i, i);
                    }
                    UIAPIRawForm.Freeze(false);
                    if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
                else
                {
                    Application.SBO_Application.SetStatusBarMessage("Please select row", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                }
            }
            else
            {
                Application.SBO_Application.SetStatusBarMessage("No rows to delete", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private void MtxMPL_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Col_5")
            {
                if (pVal.Row == MtxMPL.VisualRowCount)
                {
                    this.UIAPIRawForm.Freeze(true);
                    AddMatrixLine(itemGroup);
                    MtxMPL.Columns.Item("Col_7").Cells.Item(MtxMPL.VisualRowCount).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                    if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    {
                        this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
                        this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                    }
                    this.UIAPIRawForm.Freeze(false);
                }
            }
        }

        private void btnOk_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
        }

        private void MtxMPL_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {


                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                oDBs_Details = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_MPM1");
                var omatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_MPL").Specific;
                if (pCFL.SelectedObjects != null)
                {
                    itemGroup = ((SAPbouiCOM.EditText)omatrix.Columns.Item("Col_6").Cells.Item(pVal.Row).Specific).Value;
                    oDBs_Details.Offset = oDBs_Details.Size - 1;

                    oDBs_Details.SetValue("LineId", oDBs_Details.Offset, pVal.Row.ToString());
                    oDBs_Details.SetValue("U_PaperSize", oDBs_Details.Offset, ((SAPbouiCOM.ComboBox)omatrix.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value);
                    oDBs_Details.SetValue("U_ProductCategory", oDBs_Details.Offset, itemGroup);
                    oDBs_Details.SetValue("U_MeterCode", oDBs_Details.Offset, pCFL.SelectedObjects.GetValue("Code", 0).ToString());
                    oDBs_Details.SetValue("U_Color", oDBs_Details.Offset, ((SAPbouiCOM.ComboBox)omatrix.Columns.Item("Col_1").Cells.Item(pVal.Row).Specific).Value);
                    oDBs_Details.SetValue("U_StartRange", oDBs_Details.Offset, ((SAPbouiCOM.EditText)omatrix.Columns.Item("Col_2").Cells.Item(pVal.Row).Specific).Value);
                    oDBs_Details.SetValue("U_ToRange", oDBs_Details.Offset, ((SAPbouiCOM.EditText)omatrix.Columns.Item("Col_3").Cells.Item(pVal.Row).Specific).Value);
                    oDBs_Details.SetValue("U_BasePrice", oDBs_Details.Offset, ((SAPbouiCOM.EditText)omatrix.Columns.Item("Col_4").Cells.Item(pVal.Row).Specific).Value);
                    oDBs_Details.SetValue("U_ExcessPrice", oDBs_Details.Offset, ((SAPbouiCOM.EditText)omatrix.Columns.Item("Col_5").Cells.Item(pVal.Row).Specific).Value);

                    omatrix.SetLineData(pVal.Row);
                    omatrix.FlushToDataSource();

                    //  AddMatrixLine(itemGroup);
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }

        private void MtxMPL_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.ActionSuccess == true)
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
                oCondition.Alias = "U_ItemCode";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = this.tbMacCode.Value;
                oChooseFromList.SetConditions(oConditions);
            }
        }

        private SAPbouiCOM.EditText EditText0;

    }
}
