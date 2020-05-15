using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;
using SAPbobsCOM;
using ITNepal.MainLibrary.Utilities;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.ApplyCoverage", "Forms/ApplyCoverage.b1f")]
    class ApplyCoverage : B1FormBase
    {
        public ApplyCoverage()
        {

        }

        #region Proerties

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText tbContrctNo;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText tbItemCode;
        private SAPbouiCOM.Button btnAdd;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText tbContractCode;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText tbContractName;
        private SAPbouiCOM.DBDataSource oDBS_Head, oDBS_Details;
        private SAPbouiCOM.EditText tbCode;
        private SAPbouiCOM.Matrix mtxItemGrp;

        #endregion

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.tbContrctNo = ((SAPbouiCOM.EditText)(this.GetItem("tbCntctNo").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.tbItemCode = ((SAPbouiCOM.EditText)(this.GetItem("tbItmCd").Specific));
            this.btnAdd = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnAdd.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnAdd_PressedBefore);
            this.btnAdd.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnAdd_PressedAfter);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.btnCancel.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnCancel_PressedAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.tbContractCode = ((SAPbouiCOM.EditText)(this.GetItem("tbCvgCd").Specific));
            this.tbContractCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbContractCode_ChooseFromListAfter);
            this.tbContractCode.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbContractCode_ChooseFromListBefore);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.tbContractName = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.tbCode = ((SAPbouiCOM.EditText)(this.GetItem("tbCode").Specific));
            this.mtxItemGrp = ((SAPbouiCOM.Matrix)(this.GetItem("mtxItmGrp").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.CloseAfter += new SAPbouiCOM.Framework.FormBase.CloseAfterHandler(this.Form_CloseAfter);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {
            this.UIAPIRawForm.Items.Item("tbCntctNo").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.Items.Item("tbItmCd").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.DataSources.DBDataSources.Add("@Z_OCCV");
            this.oDBS_Head = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_OCCV");
            this.oDBS_Details = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_CCV1");
            //int Code = B1Helper.GetNextCodeId("@Z_OCCV");
            //oDBS_Head.SetValue("Code", 0, Code.ToString());
            //  LoadActiveItemGroupCodes();
            // LoadServiceContractFormValues();
        }

        #region Methods
        public void LoadServiceContractFormValues(string contractNo, string itemCode, string serial)
        {
            //  var activeForm1 = Application.SBO_Application.Forms.GetForm("60126", Application.SBO_Application.Forms.ActiveForm.TypeCount);
            oDBS_Head.SetValue("U_ContractNo", 0, contractNo);
            oDBS_Head.SetValue("U_ItemCode", 0, itemCode);
            //oDBS_Head.SetValue("U_Serial", 0, serial);
            //this.tbItemCode.Value = itemCode;
            LoadExistingCoverageInfo();
        }
        //private void LoadActiveItemGroupCodes()
        //{
        //    //gd_ItemGroup.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
        //    string query = "SELECT T1.\"U_ItemGrpCode\",'' as \"Active\" FROM \"@Z_OCVD\"  T0 , \"@Z_CVD1\"  T1 WHERE T0.\"DocEntry\" = T1.\"DocEntry\" and  T0.\"U_Active\" ='Y'";
        //    this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);
        //    SAPbouiCOM.GridColumn oCheckBoxColumn = gd_ItemGroup.Columns.Item(1);
        //    oCheckBoxColumn.Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
        //    gd_ItemGroup.Columns.Item(0).Editable = false;

        //}

        private void LoadSelectedCoverageItemGroupCodes(string coverageCode)
        {
            // gd_ItemGroup.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
            string query = "SELECT T1.\"U_ItemGrpCode\" as \"ItemGroupCode\",(SELECT T2.\"ItmsGrpNam\" FROM OITB T2 where T2.\"ItmsGrpCod\" = CAST(T1.\"U_ItemGrpCode\" AS INTEGER)) as \"ItemGroupName\",'' as \"Active\" FROM \"@Z_OCVM\"  T0 , \"@Z_CVM1\"  T1 " +
                            "WHERE T0.\"Code\" = T1.\"Code\" and  T0.\"Code\" = '" + coverageCode + "' and T1.\"U_ItemGrpCode\" <> ''";
            SAPbobsCOM.Recordset rsobj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            rsobj.DoQuery(query);
            if (rsobj.RecordCount > 0)
            {
                mtxItemGrp.Clear();
                while (rsobj.EoF == false)
                {
                    this.mtxItemGrp.AddRow();
                    oDBS_Details.SetValue("LineId", oDBS_Details.Offset, mtxItemGrp.VisualRowCount.ToString());
                    oDBS_Details.SetValue("U_ItemGroupCode", oDBS_Details.Offset, rsobj.Fields.Item("ItemGroupCode").Value.ToString());
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_ItmNm").Value = rsobj.Fields.Item("ItemGroupName").Value.ToString();
                    if (coverageCode == "SLA") { oDBS_Details.SetValue("U_Active", oDBS_Details.Offset, "N"); }
                    else { oDBS_Details.SetValue("U_Active", oDBS_Details.Offset, "Y"); }

                    mtxItemGrp.SetLineData(mtxItemGrp.VisualRowCount);

                    rsobj.MoveNext();
                }
            }

            //this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);
            //SAPbouiCOM.GridColumn oCheckBoxColumn = gd_ItemGroup.Columns.Item(2);
            //oCheckBoxColumn.Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            //gd_ItemGroup.Columns.Item(0).Editable = false;
            //gd_ItemGroup.Columns.Item(1).Editable = false;

        }

        private bool validation()
        {
            bool isChecked = false;
            //for (int iLopp = 0; iLopp <= gd_ItemGroup.Rows.Count - 1; iLopp++)
            //{
            //    if (gd_ItemGroup.DataTable.Columns.Item("Active").Cells.Item(iLopp).Value.ToString() == "Y")
            //    {
            //        isChecked = true;
            //        break;
            //    }

            //}

            for (int iLopp = 1; iLopp <= mtxItemGrp.RowCount; iLopp++)
            {
                if (((SAPbouiCOM.CheckBox)mtxItemGrp.Columns.Item(3).Cells.Item(iLopp).Specific).Checked)
                {
                    isChecked = true;
                    break;
                }
            }
            if (!isChecked)
            {
                Application.SBO_Application.SetStatusBarMessage("Please select any of the Coverage", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            return false;
        }


        private void AddContractCoverageInfo()
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_OCCV");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralDataParams);
                string ContractNo = this.tbContrctNo.Value;
                string itemCode = this.tbItemCode.Value;
                string Serial = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_7").Specific).Value;
                bool blnExist = false;
                int code = 0;

                SAPbobsCOM.Recordset rsRec = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                //string query = "SELECT T0.\"Code\", T1.\"LineId\", T1.\"U_ItemGroupCode\" FROM \"@Z_OCCV\"  T0 , \"@Z_CCV1\"  T1 WHERE T0.\"Code\" = T1.\"Code\" " +
                //                " and  T0.\"U_ContractNo\" ='" + ContractNo + "' and  T0.\"U_ItemCode\" ='" + itemCode + "' and  T0.\"U_Serial\" ='" + Serial + "'";

                string query = "SELECT T0.\"Code\", T1.\"LineId\", T1.\"U_ItemGroupCode\" FROM \"@Z_OCCV\"  T0 , \"@Z_CCV1\"  T1 WHERE T0.\"Code\" = T1.\"Code\" " +
                              " and  T0.\"U_ContractNo\" ='" + ContractNo + "' and  T0.\"U_ItemCode\" ='" + itemCode + "' ";


                rsRec.DoQuery(query);
                if (rsRec.RecordCount > 0)
                {
                    code = int.Parse(rsRec.Fields.Item("Code").Value.ToString());
                    blnExist = true;
                }
                else
                {
                    code = B1Helper.GetNextCodeId("@Z_OCCV");
                    blnExist = false;
                }

                if (blnExist)
                {
                    oGeneralParams.SetProperty("Code", code.ToString());
                    oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                    //  oGeneralData.SetProperty("DocEntry", code.ToString());
                    oGeneralData.SetProperty("U_ContractNo", ContractNo);
                    oGeneralData.SetProperty("U_ItemCode", itemCode);
                    oGeneralData.SetProperty("U_CoverageCode", oDBS_Head.GetValue("U_CoverageCode", 0).ToString());
                    oGeneralData.SetProperty("U_CoverageName", oDBS_Head.GetValue("U_CoverageName", 0).ToString());
                    //  oGeneralData.SetProperty("U_Serial", oDBS_Head.GetValue("U_Serial", 0).ToString());

                    SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                    string lineIdQry = query;
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_CCV1");

                    for (int iRow = 1; iRow <= mtxItemGrp.RowCount; iRow++)
                    {
                        //if (gd_ItemGroup.DataTable.Columns.Item("Active").Cells.Item(iRow).Value.ToString() == "Y")
                        //{
                        lineIdQry = query;
                        lineIdQry = lineIdQry + " and " + "T1.\"LineId\" ='" + (iRow) + "'";
                        rsLineId.DoQuery(lineIdQry);

                        if (rsLineId.RecordCount > 0)
                        {
                            int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                            oChild = oChildren.Item(lineId - 1);
                        }
                        else
                        {
                            oChild = oChildren.Add();
                        }
                        oChild.SetProperty("U_ItemGroupCode", ((SAPbouiCOM.EditText)mtxItemGrp.Columns.Item(1).Cells.Item(iRow).Specific).Value);
                        oChild.SetProperty("U_Active", ((SAPbouiCOM.CheckBox)mtxItemGrp.Columns.Item(3).Cells.Item(iRow).Specific).Checked ? "Y" : "N");
                        //}
                    }
                    oGeneralService.Update(oGeneralData);

                }
                else
                {
                    oGeneralData.SetProperty("Code", code.ToString());
                    oGeneralData.SetProperty("U_ContractNo", ContractNo);
                    oGeneralData.SetProperty("U_ItemCode", itemCode);
                    oGeneralData.SetProperty("U_CoverageCode", oDBS_Head.GetValue("U_CoverageCode", 0).ToString());
                    oGeneralData.SetProperty("U_CoverageName", oDBS_Head.GetValue("U_CoverageName", 0).ToString());
                    // oGeneralData.SetProperty("U_Serial", oDBS_Head.GetValue("U_Serial", 0).ToString());
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_CCV1");

                    for (int iRow = 1; iRow <= mtxItemGrp.RowCount; iRow++)
                    {
                        //if (gd_ItemGroup.DataTable.Columns.Item("Active").Cells.Item(iRow).Value.ToString() == "Y")
                        //{
                        oChild = oChildren.Add();
                        oChild.SetProperty("U_ItemGroupCode", ((SAPbouiCOM.EditText)mtxItemGrp.Columns.Item(1).Cells.Item(iRow).Specific).Value);
                        oChild.SetProperty("U_Active", ((SAPbouiCOM.CheckBox)mtxItemGrp.Columns.Item(3).Cells.Item(iRow).Specific).Checked ? "Y" : "N");
                        // }
                    }
                    oGeneralService.Add(oGeneralData);
                }

            }
            catch (Exception ex)
            {
                Utility.LogException("Error at ApplyCoverage.AddContractCoverageInfo Method: " + ex.Message);
            }
        }

        private void LoadExistingCoverageInfo()
        {
            string ContractNo = this.tbContrctNo.Value;
            string itemCode = this.tbItemCode.Value;
            // string serial = oDBS_Head.GetValue ("U_Serial", 0).Trim();
            SAPbobsCOM.Recordset rsRec = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            //string query = "SELECT T0.\"Code\",T0.\"DocEntry\", T1.\"LineId\",T0.\"U_CoverageCode\",T0.\"U_CoverageName\", T1.\"U_ItemGroupCode\" as \"ItemGroupCode\", T1.\"U_Active\", T0.\"U_Serial\" FROM \"@Z_OCCV\"  T0 , \"@Z_CCV1\"  T1 WHERE T0.\"Code\" = T1.\"Code\" " +
            //                " and  T0.\"U_ContractNo\" ='" + ContractNo + "' and  T0.\"U_ItemCode\" ='" + itemCode + "' and T0.\"U_Serial\" = '" + serial  + "'";
            string query = "SELECT T0.\"Code\",T0.\"DocEntry\", T1.\"LineId\",T0.\"U_CoverageCode\",T0.\"U_CoverageName\", T1.\"U_ItemGroupCode\" as \"ItemGroupCode\", T1.\"U_Active\" FROM \"@Z_OCCV\"  T0 , \"@Z_CCV1\"  T1 WHERE T0.\"Code\" = T1.\"Code\" " +
                           " and  T0.\"U_ContractNo\" ='" + ContractNo + "' and  T0.\"U_ItemCode\" ='" + itemCode + "' ";

            string lineqry = string.Empty;
            string value = string.Empty;
            string codeac = string.Empty;
            rsRec.DoQuery(query);
            if (rsRec.RecordCount > 0)
            {
                oDBS_Head.SetValue("Code", 0, rsRec.Fields.Item(0).Value.ToString());
                oDBS_Head.SetValue("DocEntry", 0, rsRec.Fields.Item(1).Value.ToString());
                oDBS_Head.SetValue("U_CoverageCode", 0, rsRec.Fields.Item(3).Value.ToString());
                oDBS_Head.SetValue("U_CoverageName", 0, rsRec.Fields.Item(4).Value.ToString());
                // oDBS_Head.SetValue("U_Serial", 0, rsRec.Fields.Item("U_Serial").Value.ToString());
                LoadSelectedCoverageItemGroupCodes(rsRec.Fields.Item(3).Value.ToString());
                codeac = rsRec.Fields.Item(0).Value.ToString();

                for (int iRow = 1; iRow <= mtxItemGrp.RowCount; iRow++)
                {
                    string itemGrpCode = ((SAPbouiCOM.EditText)mtxItemGrp.Columns.Item(1).Cells.Item(iRow).Specific).Value;
                    lineqry = query + "and T1.\"U_ItemGroupCode\" = '" + itemGrpCode + "' and T0.\"Code\" = '" + codeac + "'";
                    rsRec.DoQuery(lineqry);
                    if (rsRec.RecordCount > 0)
                    {
                        value = rsRec.Fields.Item(6).Value.ToString().Trim();
                        ((SAPbouiCOM.CheckBox)mtxItemGrp.Columns.Item(3).Cells.Item(iRow).Specific).Checked = value == "Y" ? true : false;
                    }
                    else {
                        value = "N";
                        ((SAPbouiCOM.CheckBox)mtxItemGrp.Columns.Item(3).Cells.Item(iRow).Specific).Checked = value == "Y" ? true : false;
                    }

                } this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
            }
            else
            {
                int code = B1Helper.GetNextCodeId("@Z_OCCV");
                oDBS_Head.SetValue("Code", 0, code.ToString());
                oDBS_Head.SetValue("DocEntry", 0, code.ToString());
            }
        }

        #endregion

        #region Events

        private void Form_CloseAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ActionSuccess)
            {
                try
                {
                    var activeForm1 = Application.SBO_Application.Forms.GetForm("60126", Application.SBO_Application.Forms.ActiveForm.TypeCount);
                    activeForm1.Freeze(false);
                }
                catch (Exception ex)
                {
                    Utility.LogException("Error at ApplyCoverage.Form_CloseAfter Method: " + ex.Message);
                }

            }
        }

        private void btnCancel_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            var activeForm1 = Application.SBO_Application.Forms.GetForm("60126", Application.SBO_Application.Forms.ActiveForm.TypeCount);
            activeForm1.Freeze(false);
        }

        private void btnAdd_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
        }

        private void btnAdd_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE || pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                if (validation())
                {
                    BubbleEvent = false;
                    return;
                }
                else
                {
                    AddContractCoverageInfo();
                }
            }
            BubbleEvent = true;
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            LoadExistingCoverageInfo();
        }

        #endregion

        private void tbContractCode_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "U_Active", "Y");

        }

        private void tbContractCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                oDBS_Head.SetValue("U_CoverageCode", 0, pCFL.SelectedObjects.GetValue("Code", 0).ToString());
                oDBS_Head.SetValue("U_CoverageName", 0, pCFL.SelectedObjects.GetValue("Name", 0).ToString());
                LoadSelectedCoverageItemGroupCodes(pCFL.SelectedObjects.GetValue("Code", 0).ToString());
            }

        }

        private void ChooseFromListCondition(SAPbouiCOM.ISBOChooseFromListEventArg pVal, string aliasName, string condVal)
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

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText1;


    }
}
