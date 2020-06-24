using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.MainLibrary.Utilities;
using System.Globalization;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.RecurringScheduleForm", "Forms/RecurringScheduleForm.b1f")]
    class RecurringScheduleForm : UserFormBase
    {
        public RecurringScheduleForm()
        {
        }
        private SAPbouiCOM.DBDataSource oDBs_Head, oDBs_Row;
        private int code;
        private SAPbouiCOM.Matrix oMatrix;
        private SAPbouiCOM.EditText tblDbAcc;
        private SAPbouiCOM.EditText tblCrAcc;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("tblCode").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("tblCtrNo").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("tblSrtdt").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("tblenddt").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("tblBillVl").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("tblBillTrs").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("tblDayVal").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("tblMonVl").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.tblCrAcc = ((SAPbouiCOM.EditText)(this.GetItem("tblCrAcc").Specific));
            this.tblCrAcc.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tblCrAcc_ChooseFromListAfter);
            this.tblCrAcc.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tblCrAcc_ChooseFromBeforeAfter);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.tblDbAcc = ((SAPbouiCOM.EditText)(this.GetItem("tblDbAcc").Specific));
            this.tblDbAcc.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tblDbAcc_ChooseFromListAfter);
            this.tblDbAcc.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tblDbAcc_ChooseFromBeforeAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_Rec").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
            
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            //this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {
            //this.UIAPIRawForm.Items.Item("tblCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE, SAPbouiCOM.BoModeVisualBehavior.mvb_True );
            this.UIAPIRawForm.Items.Item("tblCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoFormMode.fm_FIND_MODE, SAPbouiCOM.BoModeVisualBehavior.mvb_True);

            oDBs_Head = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_ORSS");
            oDBs_Row = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_RSS1");


            code = B1Helper.GetNextCodeId("@Z_ORSS");

            oDBs_Head.SetValue("Code", 0, code.ToString());
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Rec").Specific;
            AddMatrixNewLine("mtx_Rec", oMatrix);

            this.UIAPIRawForm.EnableMenu("1281", true);
            this.UIAPIRawForm.EnableMenu("1282", true);

            this.UIAPIRawForm.EnableMenu("1288", true);
            this.UIAPIRawForm.EnableMenu("1289", true);
            this.UIAPIRawForm.EnableMenu("1290", true);
            this.UIAPIRawForm.EnableMenu("1291", true);
            //this.GetItem("tblCtrNo").Enabled = true;
            this.UIAPIRawForm.DataBrowser.BrowseBy = "tblCode";
        }
        private void AddMatrixNewLine(string mtxUID, SAPbouiCOM.Matrix matrxControl)
        {
            if (mtxUID == "mtx_Rec")
            {
                matrxControl.AddRow();
                oDBs_Row.SetValue("LineId", oDBs_Row.Offset, matrxControl.VisualRowCount.ToString());
                oDBs_Row.SetValue("U_RMonth", oDBs_Row.Offset, "");
                oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, "");
                oDBs_Row.SetValue("U_RPosted", oDBs_Row.Offset, "");
                oDBs_Row.SetValue("U_RStatus", oDBs_Row.Offset, "");
                matrxControl.SetLineData(matrxControl.VisualRowCount);
            }
        }

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                
            }
            BubbleEvent = true;
        }
        private void tblCrAcc_ChooseFromBeforeAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;
            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
            oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID);
            oChooseFromList.SetConditions(emptyCon);
            oConditions = oChooseFromList.GetConditions();
            oCondition = oConditions.Add();

            if (ppVal.ChooseFromListUID == "CFL_Crd")
            {
                oCondition.Alias = "Postable";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";
                oChooseFromList.SetConditions(oConditions);
            }
        }
        private void tblCrAcc_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                //oDBs_Head.SetValue("U_RCreditAccount", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
                oDBs_Head.SetValue("U_RCreditAcc", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
                

            }

        }

        private void tblDbAcc_ChooseFromBeforeAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;
            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
            oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID);
            oChooseFromList.SetConditions(emptyCon);
            oConditions = oChooseFromList.GetConditions();
            oCondition = oConditions.Add();

            if (ppVal.ChooseFromListUID == "CFL_Deb")
            {
                oCondition.Alias = "Postable";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";
                oChooseFromList.SetConditions(oConditions);
            }
        }
        private void tblDbAcc_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

              string Acc = pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString();

                if (pCFL.SelectedObjects != null)
                {
                    
                    oDBs_Head.SetValue("U_RDebitAcc", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
                   
                }
            
        }
        public bool Validation(string Query)
        {
            SAPbobsCOM.Recordset rsContract = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsContract.DoQuery(Query);
            if (rsContract.RecordCount > 0)
            {
                String ContractNo = rsContract.Fields.Item("ContractID").Value.ToString();
                SAPbobsCOM.Recordset rsContractCount = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string cQuery = "select \"U_RContractNo\" from \"@Z_ORSS\" where \"U_RContractNo\" = '" + ContractNo + "'";
                rsContractCount.DoQuery(cQuery);
                if (rsContractCount.RecordCount > 0)
                {
                    Application.SBO_Application.SetStatusBarMessage("Record Alerady Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    return true;
                }
               
            }

           
            return false;
        }
        public void LoadData(string query)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Rec").Specific;
            int iBillTerms = 0;
            Double dDayValue = 0.0;
            Double dMonthValue = 0.0;
            Double dRecurValue = 0.0;
            int istdy = 0;
            int dyMonth = 0;
            //int rowNo = pVal.Row;

           
            SAPbobsCOM.Recordset rsService = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsService.DoQuery(query);
            try
            {
                if (rsService.RecordCount > 0)
                {
                    String ContractId = rsService.Fields.Item("ContractID").Value.ToString();
                    String Customer = rsService.Fields.Item("CstmrName").Value.ToString();

                    DateTime StartDate = Convert.ToDateTime(rsService.Fields.Item("StartDate").Value.ToString());
                    String StartDates = StartDate.ToString("yyyyMMdd");

                    DateTime EndDate = Convert.ToDateTime(rsService.Fields.Item("EndDate").Value.ToString());
                    String EndDates = EndDate.ToString("yyyyMMdd");

                    String BillProcess = rsService.Fields.Item("U_BillingProcessType").Value.ToString();
                    String BillTerms = rsService.Fields.Item("U_BillingCycle").Value.ToString();
                    iBillTerms = Convert.ToInt32(BillTerms);

                    oDBs_Head.SetValue("U_RContractNo", oDBs_Head.Offset, ContractId.ToString());
                    oDBs_Head.SetValue("U_RCustomer", oDBs_Head.Offset, Customer.ToString());
                    oDBs_Head.SetValue("U_RStartDate", oDBs_Head.Offset, StartDates.ToString());
                    oDBs_Head.SetValue("U_REndDate", oDBs_Head.Offset, EndDates.ToString());

                    if (BillProcess == "A")
                    {
                        oDBs_Head.SetValue("U_RBillProcess", oDBs_Head.Offset, "Advance");
                    }
                    else
                    {
                        oDBs_Head.SetValue("U_RBillProcess", oDBs_Head.Offset, "Credit");
                    }
                    //if (BillTerms == "4")
                    //{
                    //    oDBs_Head.SetValue("U_RBillTerms", oDBs_Head.Offset, "Quartely");
                    //}
                    //else
                    //{
                    //    oDBs_Head.SetValue("U_RBillTerms", oDBs_Head.Offset, "Monthly");
                    //}
                    oDBs_Head.SetValue("U_RBillTerms", oDBs_Head.Offset, "Monthly");

                    oDBs_Head.SetValue("U_RBillValue", oDBs_Head.Offset, rsService.Fields.Item("TotalPrice").Value.ToString());
                    Double dBillvalue = Convert.ToDouble(rsService.Fields.Item("TotalPrice").Value.ToString());

                    //if (iBillTerms == 4)
                    //{

                    //    dDayValue = dBillvalue / 120;
                    //    dMonthValue = dBillvalue / 4;
                    //}
                    //else if (iBillTerms == 12)
                    //{
                    //    dDayValue = dBillvalue / 30;
                    //    dMonthValue = dBillvalue / 12;
                    //}

                    dDayValue = dBillvalue / 30;
                    dMonthValue = dBillvalue / 12;

                    oDBs_Head.SetValue("U_RDayValue", oDBs_Head.Offset, dDayValue.ToString());
                    oDBs_Head.SetValue("U_RMonthValue", oDBs_Head.Offset, dMonthValue.ToString());

                    var datespan = ((EndDate.Year - StartDate.Year) * 12) + EndDate.Month - StartDate.Month;

                    if (oMatrix.RowCount > 0)
                    {
                        oMatrix.Clear();
                        oMatrix.AddRow();
                    }                  

                    String dy = StartDate.Day.ToString();
                    istdy = Convert.ToInt32(dy);
                    for (int iDay = 0; iDay <= datespan; iDay++)
                    {
                        int rowNo1 = oMatrix.RowCount;

                        //SQL
                        //string Query = "SELECT DATENAME(month,CONVERT(VARCHAR(10), DATEADD(month," + iDay + ", '" + StartDates + "' ), 112)) \"Date\" , DATENAME(year,CONVERT(VARCHAR(10), DATEADD(month," + iDay + ", '" + StartDates + "' ), 112)) \"Years\"";
                        //HANA
                        string Query = "SELECT MONTHNAME(ADD_MONTHS (TO_DATE ('" + StartDates + "', 'YYYYMMDD')," + iDay + ")) \"Date\",YEAR (ADD_MONTHS (TO_DATE ('" + StartDates + "', 'YYYYMMDD')," + iDay + ")) \"Years\" FROM DUMMY";

                        SAPbobsCOM.Recordset rsRecurringls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        rsRecurringls.DoQuery(Query);

                        if (rsRecurringls.RecordCount > 0)
                        {
                            while (rsRecurringls.EoF == false)
                            {
                         

                                oDBs_Row.SetValue("LineId", oDBs_Row.Offset, rowNo1.ToString());
                                oDBs_Row.SetValue("U_RYear", oDBs_Row.Offset, rsRecurringls.Fields.Item("Years").Value.ToString());
                                oDBs_Row.SetValue("U_RMonth", oDBs_Row.Offset, rsRecurringls.Fields.Item("Date").Value.ToString());

                                if (rowNo1 == 1 || rowNo1 == datespan + 1)
                                {
                                    dyMonth = 30 - istdy;
                                    if (dyMonth == 0 || dyMonth == 29 || dyMonth < 0)
                                    {
                                        dRecurValue = dDayValue * 30;
                                        //oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, dMonthValue.ToString());
                                        oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, dRecurValue.ToString());
                                    }
                                    else
                                    {
                                        dRecurValue = dDayValue * dyMonth;
                                        //oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, dMonthValue.ToString());
                                        oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, dRecurValue.ToString());

                                    }
                                }
                                else
                                {
                                    dRecurValue = dDayValue * 30;
                                    //oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, dMonthValue.ToString());
                                    oDBs_Row.SetValue("U_RAmount", oDBs_Row.Offset, dRecurValue.ToString());

                                }

                                oDBs_Row.SetValue("U_RStatus", oDBs_Row.Offset, "Pending");
                                oDBs_Row.SetValue("U_RPosted", oDBs_Row.Offset, "No");
                                oMatrix.SetLineData(oMatrix.VisualRowCount);

                                rsRecurringls.MoveNext();
                            }

                        }
                        oMatrix.AddRow();
                    }
                    oMatrix.DeleteRow(oMatrix.RowCount);




                }
            }
            catch (Exception ex) { }
        }
        public void LoadFindData(string sContractId)
        {
            
            this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            this.GetItem("tblCtrNo").Enabled = true;
            this.UIAPIRawForm.Items.Item("tblCtrNo").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            oDBs_Head.SetValue("U_RContractNo", oDBs_Head.Offset, sContractId.Trim());

            this.UIAPIRawForm.Items.Item("1").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            //this.GetItem("Item_0").Enabled = false;
            //this.UIAPIRawForm.Items.Item("Item_0").Enabled = false;
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.EditText EditText12;
    }
}
