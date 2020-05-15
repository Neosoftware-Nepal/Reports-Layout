using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;

using ITNepal.MainLibrary.Utilities;
using System.IO;
using System.Data;
using GlobalVariable;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.BillingWizardForm", "Forms/BillingWizardForm.b1f")]
    class BillingWizardForm : B1FormBase
    {
        //  private static DataTable oDTInvoice;
        private static string sQuery = string.Empty;
        public BillingWizardForm()
        {

        }

        #region Properties

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText tbBillDate;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText tbFrmCustomer;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText tbToCustomer;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.ComboBox cmbBillOption;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText tbCustSegment;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.ComboBox cmbBillingType;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText tbFromServiceContract;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText tbToServiceContract;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText tbFrmLeaseCntrct;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText tbToLeaseCntrct;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.ComboBox cmbBilOptions;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.ComboBox cmbTargetDoc;
        private SAPbouiCOM.Button btnGenerate;
        private SAPbouiCOM.Button btnCancel;


        #endregion

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.tbBillDate = ((SAPbouiCOM.EditText)(this.GetItem("tbBillDt").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.tbFrmCustomer = ((SAPbouiCOM.EditText)(this.GetItem("tbFrmCust").Specific));
            this.tbFrmCustomer.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbFrmCustomer_ChooseFromListBefore);
            this.tbFrmCustomer.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbFrmCustomer_ChooseFromListAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.tbToCustomer = ((SAPbouiCOM.EditText)(this.GetItem("tbToCust").Specific));
            this.tbToCustomer.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbToCustomer_ChooseFromListBefore);
            this.tbToCustomer.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbToCustomer_ChooseFromListAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.cmbBillOption = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbBillOpt").Specific));
            this.cmbBillOption.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.cmbBillOption_ComboSelectAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.tbCustSegment = ((SAPbouiCOM.EditText)(this.GetItem("tbCustSeg").Specific));
            this.tbCustSegment.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbCustSegment_ChooseFromListAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.cmbBillingType = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbBillTyp").Specific));
            this.cmbBillingType.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.cmbBillingType_ComboSelectAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.tbFromServiceContract = ((SAPbouiCOM.EditText)(this.GetItem("tbFrmSrv").Specific));
            this.tbFromServiceContract.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbFromServiceContract_ChooseFromListBefore);
            this.tbFromServiceContract.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbFromServiceContract_ChooseFromListAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.tbToServiceContract = ((SAPbouiCOM.EditText)(this.GetItem("tbToSrv").Specific));
            this.tbToServiceContract.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbToServiceContract_ChooseFromListBefore);
            this.tbToServiceContract.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbToServiceContract_ChooseFromListAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.tbFrmLeaseCntrct = ((SAPbouiCOM.EditText)(this.GetItem("tbFrmLes").Specific));
            this.tbFrmLeaseCntrct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbFrmLeaseCntrct_ChooseFromListBefore);
            this.tbFrmLeaseCntrct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbFrmLeaseCntrct_ChooseFromListAfter);
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.tbToLeaseCntrct = ((SAPbouiCOM.EditText)(this.GetItem("tbToLeas").Specific));
            this.tbToLeaseCntrct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbToLeaseCntrct_ChooseFromListBefore);
            this.tbToLeaseCntrct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbToLeaseCntrct_ChooseFromListAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.cmbBilOptions = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbBilOpts").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.cmbTargetDoc = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbTgtDoc").Specific));
            this.btnGenerate = ((SAPbouiCOM.Button)(this.GetItem("btnGenrte").Specific));
            this.btnGenerate.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnGenerate_PressedAfter);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("gd_Sumry").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
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
            this.UIAPIRawForm.DataSources.DataTables.Add("MyDT");
        }

        private void tbFrmCustomer_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_FrmCust").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                }
            }

            catch (Exception ex)
            {
                Utility.LogException("Error at BillingWizardForm.tbFrmCustomer_ChooseFromListAfter Method: " + ex.Message);
            }


        }

        private void tbToCustomer_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_ToCust").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                }
            }

            catch (Exception ex)
            {
                Utility.LogException("Error at ApplyCoverage.AddContractCoverageInfo Method: " + ex.Message);
            }

        }

        private void tbFromServiceContract_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_FrmServ").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();

                }
            }


            catch (Exception ex)
            {
                Utility.LogException("Error at BillinWizardForm.tbFromServiceContract_ChooseFromListAfter Method: " + ex.Message);
            }

        }

        private void tbToServiceContract_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_ToServ").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }

        private void tbFrmLeaseCntrct_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_FrmLese").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.LogException("Error at BillinWizardForm.tbFrmLeaseCntrct_ChooseFromListAfter Method: " + ex.Message);
            }
        }

        private void tbToLeaseCntrct_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_ToLese").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }


        private void ChooseFromListCondition(SAPbouiCOM.ISBOChooseFromListEventArg pVal, string aliasName, string condVal, string CondType = "", string query = "")
        {
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;

            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
            oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID);
            oChooseFromList.SetConditions(emptyCon);
            oConditions = oChooseFromList.GetConditions();


            if (CondType == "")
            {
                oCondition = oConditions.Add();
                oCondition.Alias = aliasName;
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = condVal;
                oChooseFromList.SetConditions(oConditions);
            }
            else
            {
                SAPbobsCOM.Recordset rsConds = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsConds.DoQuery(query);
                if (rsConds.RecordCount > 0)
                {
                    condVal = rsConds.Fields.Item(0).Value.ToString();
                    while (rsConds.EoF == false)
                    {
                        oCondition = oConditions.Add();
                        oCondition.Alias = aliasName;
                        oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCondition.CondVal = condVal;
                        oChooseFromList.SetConditions(oConditions);

                        rsConds.MoveNext();
                    }

                }

                if (aliasName == "CstmrCode")
                {
                    oCondition.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;
                    oCondition = oConditions.Add();
                    oCondition.Alias = "Status";
                    oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCondition.CondVal = "A";
                    oChooseFromList.SetConditions(oConditions);

                }

            }
        }

        private void tbFrmCustomer_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "CardType", "C");

        }

        private void tbToCustomer_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "CardType", "C");

        }

        private void tbFromServiceContract_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (tbFrmCustomer.Value != string.Empty && tbToCustomer.Value != string.Empty)
            {
                string query = "Select T0.\"CardCode\" From \"OCRD\" T0 Where ((T0.\"CardCode\" >='" + tbFrmCustomer.Value + "' and T0.\"CardCode\" <='" + tbToCustomer.Value + "') " +
                                "or (T0.\"CardCode\" <='" + tbToCustomer.Value + "' and T0.\"CardCode\" >='" + tbFrmCustomer.Value + "')) and T0.\"CardType\"='C' ";
                ChooseFromListCondition(pCFL, "CstmrCode", "", "Q", query);
            }
            else if (tbFrmCustomer.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select From Customer", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }
            else if (tbToCustomer.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select To Customer", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }

        }

        private void tbToServiceContract_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (tbFrmCustomer.Value != string.Empty && tbToCustomer.Value != string.Empty)
            {
                string query = "Select T0.\"CardCode\" From \"OCRD\" T0 Where ((T0.\"CardCode\" >='" + tbFrmCustomer.Value + "' and T0.\"CardCode\" <='" + tbToCustomer.Value + "') " +
                                "or (T0.\"CardCode\" <='" + tbToCustomer.Value + "' and T0.\"CardCode\" >='" + tbFrmCustomer.Value + "')) and T0.\"CardType\"='C' ";
                ChooseFromListCondition(pCFL, "CstmrCode", "", "Q", query);
            }
            else if (tbFrmCustomer.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select From Customer", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }
            else if (tbToCustomer.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select To Customer", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }
        }

        private void tbFrmLeaseCntrct_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            //BubbleEvent = true;
            //SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            BubbleEvent = true;
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

                oCondition.Alias = "U_Status";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "A";
                oChooseFromList.SetConditions(oConditions);


            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

            //if (tbFromServiceContract.Value != string.Empty && tbToServiceContract.Value != string.Empty)
            //{
            //    string query = "Select T0.\"U_ContractNo\" From \"@Z_OLCM\" T0 Where ((T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "' and T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "') " +
            //                    "or (T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "' and T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "')) and (T0.\"U_ContractNo\" >= " + tbFromServiceContract.Value + " and T0.\"U_ContractNo\" <= " + tbToServiceContract.Value + " ) ";
            //    ChooseFromListCondition(pCFL, "U_ContractNo", "", "Q", query);
            //}
            //else if (tbFromServiceContract.Value == string.Empty)
            //{
            //    BubbleEvent = false;
            //    Application.SBO_Application.SetStatusBarMessage("Please Select From Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            //    return;
            //}
            //else if (tbToServiceContract.Value == string.Empty)
            //{
            //    BubbleEvent = false;
            //    Application.SBO_Application.SetStatusBarMessage("Please Select To Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            //    return;
            //}

        }

        private void tbToLeaseCntrct_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
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

                oCondition.Alias = "U_Status";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "A";
                oChooseFromList.SetConditions(oConditions);


            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

            //if (tbFromServiceContract.Value != string.Empty && tbToServiceContract.Value != string.Empty)
            //{
            //    string query = "Select T0.\"U_ContractNo\" From \"@Z_OLCM\" T0 Where ((T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "' and T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "') " +
            //                    "or (T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "' and T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "')) and (T0.\"U_ContractNo\" >= " + tbFromServiceContract.Value + " and T0.\"U_ContractNo\" <= " + tbToServiceContract.Value + " ) ";
            //    ChooseFromListCondition(pCFL, "U_ContractNo", "", "Q", query);
            //}
            //else if (tbFromServiceContract.Value == string.Empty)
            //{
            //    BubbleEvent = false;
            //    Application.SBO_Application.SetStatusBarMessage("Please Select From Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            //    return;
            //}
            //else if (tbToServiceContract.Value == string.Empty)
            //{
            //    BubbleEvent = false;
            //    Application.SBO_Application.SetStatusBarMessage("Please Select To Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            //    return;
            //}

        }


        private void LoadGridValues()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                string tbFromServiceContractValue = string.Empty;
                string sCustomer = string.Empty;
                string sbilltype = string.Empty;
                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                sbilltype = cmbBillingType.Value;
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                    { tbFromServiceContractValue = "  and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "')  "; }
                    else
                    {
                        Application.SBO_Application.SetStatusBarMessage("Service Contract should not be blank ...!", SAPbouiCOM.BoMessageTime.bmt_Medium, true);
                        this.UIAPIRawForm.Freeze(false);
                        return;
                    }
                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                    query = "CALL USP_BillingCallsV ('" + tbBillDate.Value + "' , " + tbFromServiceContract.Value + " , " + tbToServiceContract.Value + " , '" + B1Helper.DiCompany.CompanyDB + "') ";
                    rsObj.DoQuery(query);
                    if (sbilltype == "B")
                    {
                        //Commented - 05 Apr 2016 (For Sql)
                        //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                        //      " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" ," +
                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //      "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' ";



                        //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                        //      " T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )) \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else (T0.\"U_EligQuantity\" * ( (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )))) * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" ,  (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )) \"Skip\" " +
                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //      "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" ";

                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                            " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",  T0.\"U_LastMeterReading\"  \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")  \"Used\", " +
                            " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
" then T0.\"U_EligQuantity\" * 3 " +
" when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
" when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
"end ) \"Free Copied\", " +
                             "  0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                            " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                      " case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +
                     "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
" then T0.\"U_EligQuantity\" * 3 " +
" when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
" when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
"end ) " +
                      " )  " +
                      " * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                             " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" ,  (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)  \"Skip\" , " +
                             "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
" then  3 " +
" when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
" when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
"end  \"Cycle\" ,   " +
"  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
 " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\" , 0 \"U_LastReading\" " +
                            " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                            "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                            " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                            "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null and T1.\"EndDate\" > T4.\"U_NextBilledDate\" and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" ";

                    }
                    else if (sbilltype == "E")
                    {
                        //(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")  \"Used\",
                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                 " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\", " +
                        " T0.\"U_LastMeterReading\"  \"Last Billed Meter Reading\",  (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , " +
                                 " ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) ) \"Used\", " +
                                 "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                                 " \"Free Copied\", " +
" case when  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end))  -  " +
                                 " ( " +
                         "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                        " ))  <= 0 then 0 else  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end))  -  " +
                        " (   CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) )    ) end  " +
                        " \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , " +
                        " case when  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end))  -  " +
                                 " ( " +
                         "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                        " ))  <= 0 then 0 else  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
                        " (   CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) )    ) * T0.\"U_ExcessPrice\" end \"Total\", " +
                                 " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" , '1' \"Skip\" , " +
                                  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then  3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
   " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
   "  , (select sum(\"U_LastMeterReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) \"U_LastReading\"  " +
   " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" >= T4.\"U_NextBilledDate\" and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ,T4.\"U_BillingProcessType\",T4.\"U_LastBilledDate\",T1.\"StartDate\"   ";

                    }
                    else if (sbilltype == "C")
                    {

                        //                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        // " T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Free Copied\", 0 \"Excess\",   " +
                        //" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
                        //" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else (T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)) * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
                        // " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" FROM \"@Z_ECMD\"  T0 ,  " +
                        // " \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
                        // "  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
                        // " WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        // "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        // "       union all  " +
                        //" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
                        //"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) \"Free Copied\",     " +
                        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) )) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\",   " +
                        //"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +
                        //"   case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\")  " +
                        //"    * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-  " +
                        //"    T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Excess Total\",    " +
                        //"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\"  " +
                        //"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
                        //"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
                        //"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
                        //"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
                        //"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
                        //"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  ";





                        //                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Free Copied\", 0 \"Excess\",   " +
                        //" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
                        //" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else (T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)) * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
                        //" T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" FROM \"@Z_ECMD\"  T0 ,  " +
                        //" \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
                        //"  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
                        //" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //"       union all  " +
                        //" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
                        //"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) "+
                        //"  * ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0)" +
                        //" \"Free Copied\",     " +
                        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) * "+
                        //"   ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0) "+
                        //                        ")) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) *" +
                        //"ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0)"+
                        //                        ") end \"Excess\",   " +
                        //"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +

                        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) * " +
                        //"   ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0) " +
                        //                        ")) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) *" +
                        //"ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0)" +
                        //                        ") end " +
                        //"* T0.\"U_ExcessPrice\" "+
                        //                        " \"Excess Total\",    " +
                        //"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\"  " +
                        //"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
                        //"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
                        //"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
                        //"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
                        //"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
                        //"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  ";


                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
"   T0.\"U_LastMeterReading\"  \"Last Billed Meter Reading\",  " +
"  (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )   \"Currenct Meter Reading\"  ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\", " +

 " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) \"Free Copied\",   " +
                         "0 \"Excess\",   " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
" , 0 \"U_ExcessPrice\",    " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end  ) * T0.\"U_Price\" ) end \"Fixed Total\" , 0 \"Excess Total\",  " +
" T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" , " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
  " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
  "  , 0 \"U_LastReading\"  " +
"FROM \"@Z_ECMD\"  T0 ,  " +
" \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
"  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" > T4.\"U_NextBilledDate\" and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +


"       union all  " +
" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , case when T4.\"U_NextBilledDate\" is null then T1.\"StartDate\" else T4.\"U_NextBilledDate\" end  \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
"   T0.\"U_LastMeterReading\"  \"Last Billed Meter Reading\",  " +
" (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )   \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , " +
" ( (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  \"Used\",  " +
   " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * (" +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
  " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
     "when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) \"Free Copied\", " +

"      case when  (((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )    -   " +
" ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end " +
                        " ))) <= 0 then 0 else  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
" ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ))) end \"Excess\",   " +

  "   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +

"      case when  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  - " +
"    ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ))) <= 0 then 0 else  (  ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
" ( " +
     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ))) end " +
   "* T0.\"U_ExcessPrice\" " +
                     " \"Excess Total\",    " +

"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\" ,  " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
  " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
  "  , (select sum(\"U_LastMeterReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) \"U_LastReading\"  " +
"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" >= T4.\"U_NextBilledDate\" and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\",T1.\"StartDate\" ,T4.\"U_LastBilledDate\"  ";
                    }
                    else if (sbilltype == "S")
                    {
                        tbFromServiceContractValue = string.Empty;
                        sCustomer = string.Empty;

                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        {
                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        }

                        query = " SELECT max(T1.\"ContractID\") \"Contract No.\" , max(T4.\"U_NextBilledDate\") \"Bill Date\" ,  " +
     "  max(T4.\"U_FixedItem\")  \"MeterCode\", max(T1.\"CstmrCode\") \"Customer Code\", max(T1.\"CstmrName\") \"Customer Name\", " +
     "  sum(TT.\"U_ServiceAmount\") \"Fixed Price\",  " +
      "      max( to_integer( T4.\"U_BillingCycle\")) \"Intervals\",   " +
       "  sum((CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) *   " +
          " (Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   (TT.\"U_ServiceAmount\") * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   (TT.\"U_ServiceAmount\") * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   (TT.\"U_ServiceAmount\") * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then   (TT.\"U_ServiceAmount\") * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  (TT.\"U_ServiceAmount\") * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then   (TT.\"U_ServiceAmount\") * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then   (TT.\"U_ServiceAmount\") * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   (TT.\"U_ServiceAmount\") * 1 " +
  "end ))) \"SMA Price\"  , " +
               "      max( T1.\"ContractID\" ) \"ContractID\", max(T4.\"U_BillingCycle\") \"BillingCycle\"  , max(T4.\"U_BillingProcessType\" )\"BillingProcessType\"  , " +
      " max( Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end ) \"Cycle\" ,   " +
  " max( CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" )))) \"Ceil\" , " +
   " to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when max(T4.\"U_LastBilledDate\") is null then max(T1.\"StartDate\") else max( T4.\"U_LastBilledDate\") end  \"U_LastBilledDate\"  " +
      "           FROM \"OCTR\" T1  join CTR1 TT ON TT.\"ContractID\" = T1.\"ContractID\"                   " +
      "                  JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
      "          WHERE        " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
      "                and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null and TT.\"TermDate\" is null  and T1.\"EndDate\" > T4.\"U_NextBilledDate\"       and T1.\"U_PriceType\" = 'F' ";

                        //                    query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",  " +
                        //" T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"    " +
                        //" \"ItemCode\",T0.\"U_MeterName\" \"MeterName\", T0.\"U_SerialNum\" \"Serial No\",(T4.\"U_FixedPrice\") \"Fixed Price\",  " +
                        //" (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"Intervals\",  " +
                        //" (T4.\"U_FixedPrice\") / (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"SMA Price\",  " +
                        //" T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\"   " +
                        //"  FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"  " +
                        //"   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  " +
                        //"        and T1.\"U_PriceType\" = 'F' ";


                    }
                    else if (sbilltype == "M")
                    {
                        tbFromServiceContractValue = string.Empty;
                        sCustomer = string.Empty;

                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        {
                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        }


                        query = " SELECT distinct  T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T5.\"U_PoolCode\" \"PoolCode\",    " +
   "  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",   " +
    "  T7.\"internalSN\", to_nvarchar('PM') \"Preventive Maintance\"  ,\"U_ServiceAmount\" \"Service Amount\" , \"U_Source\" \"Source\"  , \"callID\" \"Service Call\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , '1' \"Skip\" " +
    "     FROM \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
     "   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"     " +
     "   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     " +
     "   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"    " +
     "   join \"CTR1\" T6 on T6.\"ContractID\" = T1.\"ContractID\"   " +
     "   join \"OSCL\" T7 on T6.\"ContractID\" = T7.\"contractID\" and T6.\"InternalSN\" =  T7.\"internalSN\"   " +
      "  join \"OSCP\" T8 on T8.\"prblmTypID\" = T7.\"problemTyp\"    " +
      "  and T6.\"U_Source\" = T8.\"Name\"   " +
     "   WHERE     " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
         "      and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'M' ";

                    }

                }
                else if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3") //***********************Both
                {
                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" ,T0.\"U_CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

                    //query = "Select T0.\"Code\" \"ContractID\",T0.\"U_ContractNo\" \"ServiceNo\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\",T2.\"U_ItemCode\" \"ServiceLineItem\",T2.\"U_ItemDescp\" \"ServiceLineDesc\",T2.\"U_Quantity\" \"Quantity\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" " +
                    //       "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
                    //query = "Select T0.\"Code\" \"ContractID\",T0.\"U_ContractNo\" \"ServiceNo\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"ItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\",T2.\"U_ItemCode\" \"ServiceLineItem\",T2.\"U_ItemDescp\" \"ServiceLineDesc\",T2.\"U_Quantity\" \"Quantity\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" " +
                    //     "where  (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

                    String ContractId = "";
                    String ContractNo = "";
                    String ContractNoF = "";
                    SAPbobsCOM.Recordset rsContractNo = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string cQuery = "Select T0.\"U_ContractNo\" \"ServiceNo\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" where  (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "' order by T0.\"U_ContractNo\" ";
                    rsContractNo.DoQuery(cQuery);

                    if (rsContractNo.RecordCount > 0)
                    {
                        rsContractNo.MoveFirst();
                        ContractNo = rsContractNo.Fields.Item("ServiceNo").Value.ToString().Trim();
                        rsContractNo.MoveLast();
                        ContractNoF = rsContractNo.Fields.Item("ServiceNo").Value.ToString().Trim();
                    }
                    ContractId = "  and (T0.\"U_DocNum\" >= '" + ContractNo + "' and T0.\"U_DocNum\" <='" + ContractNoF + "')  ";
                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }


                    query = "CALL USP_BillingCallsV ('" + tbBillDate.Value + "' , " + ContractNo + " , " + ContractNoF + " , '" + B1Helper.DiCompany.CompanyDB + "') ";
                    rsObj.DoQuery(query);

                    if (sbilltype == "B")
                    {


                        //                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\", 'Fixed Billing' \"Billing Type\"  , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //                             " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\"  end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")  \"Used\", " +
                        //                             " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
                        // "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
                        // " then T0.\"U_EligQuantity\" * 3 " +
                        // " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
                        // " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
                        //  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
                        // "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
                        //" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
                        //" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
                        //"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
                        // "end ) \"Free Copied\", " +
                        //                              "  0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                        //                             " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                        //                       " case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +
                        //                      "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
                        // "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
                        // " then T0.\"U_EligQuantity\" * 3 " +
                        // " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
                        // " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
                        //  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
                        // "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
                        //" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
                        //" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
                        //"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
                        // "end ) " +
                        //                       " )  " +
                        //                       " * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                        //                              " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" ,  (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)  \"Skip\" , " +
                        //                              "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
                        // " then  3 " +
                        // " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
                        // " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
                        //  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
                        // "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
                        //" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
                        //" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
                        //"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
                        // "end  \"Cycle\" ,   " +
                        // "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
                        //  " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" " +
                        //                                   "  ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                        //                                   "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
                        //                             " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //                             "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //                             " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //                             "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" ";


                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\", 'Fixed Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                              " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\"  end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")  \"Used\", " +
                              " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) \"Free Copied\", " +
                               "  0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                              " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                        " case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +
                       "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                        " )  " +
                        " * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                               " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" ,  (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)  \"Skip\" , " +
                               "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then  3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
   " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
   "  , 0 \"U_LastReading\"  " +
    "  ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                                   "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\",null \"LBillingCycle\" " +
                              " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                              "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                              " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                              "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" > T4.\"U_NextBilledDate\"    and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +

                        " union all   " +
                        "  Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\" " +
 ",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\",null \"MeterName\", null \"Serial No\" " +
 ",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",   null \"Reset\" ,0 \"Used\", " +
"  0 \"Free Copied\", 0 \"Excess\", 0 \"Price\",0 \"Excess Price\",0 \"Total Amount\",null \"BillingProcessType\",null \"FixedPrice\",null \"IsFixedPrice\"" +
 ",T0.\"U_ContractNo\" \"ContractID\" , null \"BillingCycle\" ,null \"Code\" , '1' \"Skip\", 0 \"Cycle\",0 " +
 ",to_date('" + tbBillDate.Value + "') \"BillWizDate\",null \"U_LastBilledDate\" ,0 \"U_LastReading\"" +
                        ",T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' " +
                        "then T0.\"U_ItemCodeLR\" when T0.\"U_ItemCode\" is null then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\"  when T0.\"U_ItemDesc\"  is null then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\", " +
                         "T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" ,T0.\"U_BillingCycle\" \"LBillingCycle\" from \"@Z_OLCM\" T0 " +
                          "inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"  " +
                         "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";



                        //query = "SELECT distinct T0.\"U_DocNum\" \"ContractNo\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                        //      " T0.\"U_EligQuantity\"  \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                        //       "  ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                        //       "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //      "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                        //      " union all   " +
                        //      "  Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\", null \"Bill Date\",null \"PoolCode\",null \"MeterCode\", null \"Customer Code\", " +
                        //      "null \"Customer Name\",null  \"ItemCode\",null \"MeterName\",null \"Serial No\",null \"Start Meter Reading\",0 \"Last Billed Meter Reading\",  " +
                        //      "null \"Reset\" , 0 \"Used\",0 \"Free Copied\", 0 \"Excess\", 0 \"Price\", 0 \"Excess Price\",  0 \"FixedPrice\", 0 \"Total Amount\" ,null \"BillingProcessType\" ,  null \"IsFixedPrice\", " +
                        //      "null \"ContractID\" , null \"BillingCycle\" , null \"Code\" ,T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = ''  " +
                        //      "then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\", " +
                        //       "T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" from \"@Z_OLCM\" T0 " +
                        //        "inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"  " +
                        //       "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";
                        //;

                    }
                    else if (sbilltype == "E")
                    {


                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" ,'Excess Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else   T0.\"U_LastMeterReading\"  end \"Last Billed Meter Reading\",  (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , " +
                                " ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) ) \"Used\", " +
                                "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) " +
                                " \"Free Copied\", " +
" case when  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
                                " ( " +
                        "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) " +
                       " ))  <= 0 then 0 else  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
                       " (   CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) )    ) end  " +
                       " \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , " +
                       " case when  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
                                " ( " +
                        "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) " +
                       " ))  <= 0 then 0 else  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
                       " (   CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) )    ) * T0.\"U_ExcessPrice\" end \"Total\", " +
                                " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
                                 " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" , '1' \"Skip\" , " +
                                 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then  3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
 "end  \"Cycle\" ,   " +
 "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
  " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
  "  , (select sum(\"U_LastMeterReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) \"U_LastReading\"  " +
    " ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
 "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\",null \"LBillingCycle\"   " +
                                " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" >= T4.\"U_NextBilledDate\"   and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                                "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ,T4.\"U_BillingProcessType\",T4.\"U_LastBilledDate\",T1.\"StartDate\"  " +

                                 "Union all  " +

    "Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\" " +
 ",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\",null \"MeterName\", null \"Serial No\" " +
 ",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",  0 \"Currenct Meter Reading\" , null \"Reset\" ,0 \"Used\", " +
  "0 \"Free Copied\", 0 \"Excess\", 0 \"Price\",0 \"Excess Price\",0 \"Total\",null \"FixedPrice\",null \"IsFixedPrice\" " +
 ",T0.\"U_ContractNo\" \"ContractID\" , null \"BillingCycle\" ,null \"BillingProcessType\",null \"Code\" , '1' \"Skip\", 0 \"Cycle\",0 \"Ceil\",to_date('" + tbBillDate.Value + "') \"BillWizDate\" ,null \"U_LastBilledDate\" ,0 \"U_LastReading\"" +
 ",T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" when T0.\"U_ItemCode\" is null then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\" = '' " +
 "then T0.\"U_ItemDescLR\" when T0.\"U_ItemDesc\"  is null then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\",T0.\"U_BillingCycle\" \"LBillingCycle\" " +
 "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
 "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";


                        //                       query = "SELECT distinct T0.\"U_DocNum\" \"ContractNo\" , 'Excess Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //                                " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",T0.\"U_CurrentMeterReading\" \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\", " +
                        //                                " (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) \"Free Copied\", case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") - (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" end \"Total\", " +
                        //                                " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
                        //                                 " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" " +
                        //                                 " ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                        //                                   "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\"   " +
                        //                                " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //                                "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //                                " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //                                "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                        //                                "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ,T4.\"U_BillingProcessType\" " +
                        //                                "        Union all  " +
                        //   "Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\"," +
                        // "null \"MeterName\", null \"Serial No\",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",  0 \"Currenct Meter Reading\" , null \"Reset\" ,0 \"Used\",  0 \"Free Copied\", 0 \"Excess\", 0 \"U_Price\"," +
                        //  "0 \"U_ExcessPrice\",0 \"Fixed Total\" , 0 \"Excess Total\",null \"IsFixedPrice\", null \"ContractID\" , null \"BillingCycle\" ,null \"BillingProcessType\" , null \"Code\" ," +
                        //"T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' " +
                        //"then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" " +
                        //"from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
                        //"where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";


                        ;


                    }
                    else if (sbilltype == "C")
                    {

                        ////                        query = " SELECT distinct T0.\"U_DocNum\" \"ContractNo\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        ////" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        ////" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        ////" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //// " T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\",   " +
                        ////" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
                        ////" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
                        //// " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" " +
                        //// ",null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                        //// "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
                        ////                        "FROM \"@Z_ECMD\"  T0 ,  " +
                        //// " \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
                        //// "  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
                        //// " WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //// "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //// "       union all  " +
                        ////" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        ////" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        ////" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        ////" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        ////" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
                        ////"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) \"Free Copied\",     " +
                        ////"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        ////"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) )) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        ////"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\",   " +
                        ////"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +
                        ////"   case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\")  " +
                        ////"    * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-  " +
                        ////"    T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Excess Total\",    " +
                        ////"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\"   " +
                        //// ",null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                        //// "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
                        ////"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        ////"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
                        ////"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        ////"     " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        ////"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
                        ////"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
                        ////"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
                        ////"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
                        ////"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  " +
                        ////"        Union all  " +
                        ////    "Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\"," +
                        ////  "null \"MeterName\", null \"Serial No\",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",  0 \"Currenct Meter Reading\" , null \"Reset\" ,0 \"Used\",  0 \"Free Copied\", 0 \"Excess\", 0 \"U_Price\"," +
                        ////   "0 \"U_ExcessPrice\",0 \"Fixed Total\" , 0 \"Excess Total\",null \"IsFixedPrice\", null \"ContractID\" , null \"BillingCycle\" ,null \"BillingProcessType\" , null \"Code\" ," +
                        //// "T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' " +
                        //// "then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" " +
                        //// "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
                        //// "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";
                        //"where (T0.\"Code\" >= '6' and T0.\"Code\" <= '6')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '20180523'";


                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
"  T0.\"U_LastMeterReading\"   \"Last Billed Meter Reading\",  " +
"  (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )   \"Currenct Meter Reading\"  ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\", " +

" CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) \"Free Copied\",   " +
                        "0 \"Excess\",   " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
" , 0 \"U_ExcessPrice\",    " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +

    " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end  ) * T0.\"U_Price\" ) end \"Fixed Total\" , 0 \"Excess Total\",  " +
" T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" , " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then   3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
 "end  \"Cycle\" ,   " +
 "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
 " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
 "  , 0 \"U_LastReading\"  " +
  " ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
 "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\",null \"LBillingCycle\"" +
"FROM \"@Z_ECMD\"  T0 ,  " +
" \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
"  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" > T4.\"U_NextBilledDate\"    and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +


"       union all  " +
" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , case when T4.\"U_NextBilledDate\" is null then T1.\"StartDate\" else T4.\"U_NextBilledDate\" end  \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" T0.\"U_LastMeterReading\"  \"Last Billed Meter Reading\",  " +
" (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )   \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , " +
" ( (select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  \"Used\",  " +
  " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * (" +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
    "when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ) \"Free Copied\", " +

"      case when  (((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )    -   " +
" ( " +

    " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end " +
                       " ))) <= 0 then 0 else  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
" ( " +

    " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ))) end \"Excess\",   " +

 "   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +

"      case when  ( ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  - " +
"    ( " +

    " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ))) <= 0 then 0 else  (  ((select sum(\"U_CurrentReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" )  " +
" - (case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end) )  -  " +
" ( " +
    " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
 "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then T0.\"U_EligQuantity\" * 3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
 "end ))) end " +
  "* T0.\"U_ExcessPrice\" " +
                    " \"Excess Total\",    " +

"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\" ,  " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
 " then   3 " +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
 " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
  "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
" when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
"    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
 "end  \"Cycle\" ,   " +
 "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
 " ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" , case when T4.\"U_LastBilledDate\" is null then T1.\"StartDate\" else T4.\"U_LastBilledDate\" end  \"U_LastBilledDate\"  " +
 "  , (select sum(\"U_LastMeterReading\") from USEDDURATION TT where TT.\"U_ItemCode\" = T0.\"U_MeterCode\"   and TT.\"contractID\" = T0.\"U_DocNum\" and TT.\"U_PoolCode\" = T0.\"U_PoolCode\" ) \"U_LastReading\"  " +
  " ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
 "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\",null \"LBillingCycle\"   " +
"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"     " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"EndDate\" >= T4.\"U_NextBilledDate\"    and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\",T1.\"StartDate\" ,T4.\"U_LastBilledDate\"  " +

"        Union all  " +
"Select  T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\" " +
 " ,null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\",null \"MeterName\", null \"Serial No\" " +
 ",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",  0 \"Currenct Meter Reading\" , null \"Reset\" ,0 \"Used\", " +
  "0 \"Free Copied\", 0 \"Excess\", 0 \"U_Price\",0 \"U_ExcessPrice\",0 \"Fixed Total\"    " +
  ", 0 \"Excess Total\",null \"IsFixedPrice\",T0.\"U_ContractNo\" \"ContractID\" , null \"LBillingCycle\" ," +
"null \"BillingProcessType\",null \"Code\" , '1' \"Skip\", 0 \"Cycle\",0 \"Ceil\",to_date('" + tbBillDate.Value + "') \"BillWizDate\" ,null \"U_LastBilledDate\",0 \"U_LastReading\"  " +

                             ",T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" when T0.\"U_ItemCode\" is null then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' " +
                             "then T0.\"U_ItemDescLR\" when T0.\"U_ItemDesc\"  is null then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\",T0.\"U_BillingCycle\" \"BillingCycle\" " +

                             "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
                             "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' "


;


                    }
                    else if (sbilltype == "S")
                    {
                        // tbFromServiceContractValue = string.Empty;
                        // sCustomer = string.Empty;

                        // if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        // {
                        //     tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + ContractId + "' and T1.\"ContractID\" <='" + ContractId + "')  ";
                        //  if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                        //  { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        //}
                        // else
                        // {
                        //    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                        //    { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        // }

                        String ContractIdS = "";
                        String ContractNoS = "";
                        String ContractNoFS = "";
                        SAPbobsCOM.Recordset rsContractNoS = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string cQueryS = "Select T0.\"U_ContractNo\" \"ServiceNo\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" where  (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "' order by T0.\"U_ContractNo\" ";
                        rsContractNoS.DoQuery(cQueryS);

                        if (rsContractNoS.RecordCount > 0)
                        {
                            rsContractNoS.MoveFirst();
                            ContractNoS = rsContractNoS.Fields.Item("ServiceNo").Value.ToString().Trim();
                            rsContractNoS.MoveLast();
                            ContractNoFS = rsContractNoS.Fields.Item("ServiceNo").Value.ToString().Trim();
                        }
                        ContractIdS = "   (T1.\"ContractID\" >= '" + ContractNoS + "' and T1.\"ContractID\" <='" + ContractNoFS + "')  ";
                        if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                        { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }




                        query = " SELECT distinct T1.\"ContractID\" \"Contract No.\" ,'SMA Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\" ,  " +
     "  T4.\"U_FixedItem\"  \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\", " +
     "  (TT.\"U_ServiceAmount\") \"Fixed Price\",  " +
      "       to_integer( T4.\"U_BillingCycle\") \"Intervals\",   " +
       "  (CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) *   " +
          " (Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   (TT.\"U_ServiceAmount\") * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   (TT.\"U_ServiceAmount\") * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   (TT.\"U_ServiceAmount\") * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then   (TT.\"U_ServiceAmount\") * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  (TT.\"U_ServiceAmount\") * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then   (TT.\"U_ServiceAmount\") * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then   (TT.\"U_ServiceAmount\") * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   (TT.\"U_ServiceAmount\") * 1 " +
  "end )) \"SMA Price\"  , " +
               "       T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\"  , T4.\"U_BillingProcessType\" \"BillingProcessType\"  , " +
      "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end  \"Cycle\" ,   " +
   "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
   " ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
 "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\",null \"LBillingCycle\" ,to_date('" + tbBillDate.Value + "') \"BillWizDate\"  " +

      "           FROM \"OCTR\" T1  join CTR1 TT ON TT.\"ContractID\" = T1.\"ContractID\"                   " +
      "                  JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"   " +
      "          WHERE     " + ContractIdS + "  " + sCustomer + "  and T4.\"U_BillingType\" = 'B'  " +
      "                and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null and TT.\"TermDate\" is null  and T1.\"EndDate\" > T4.\"U_NextBilledDate\"       and T1.\"U_PriceType\" = 'F' " +
                        "        Union all  " +

                  "Select   T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\" " +
  ",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\"," +
"null   \"Fixed Price\",null \"Intervals\",null \"SMA Price\", T0.\"U_ContractNo\" \"ContractID\",null \"BillingCycle\",null \"BillingProcessType\" " +
",null \"Cycle\",null \"Ceil\" " +

                                               ",T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" when T0.\"U_ItemCode\" is null then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' " +
                                               "then T0.\"U_ItemDescLR\" when T0.\"U_ItemDesc\"  is null then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\",T0.\"U_BillingCycle\" \"LBillingCycle\" ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" " +

                                               "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
                                               "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";






                    }

                }
                else
                {
                    //query = "SELECT T1.\"U_ItemCode\" \"ItemCode\", T1.\"U_ItemDescp\" \"Descp\",T0.\"U_CustomerCode\", T0.\"U_CustomerName\", T1.\"U_Quantity\" \"Quantity\",T0.\"U_ContractValue\" \"Price\" FROM \"@Z_OLCM\"  T0 ," +
                    //       " \"@Z_LCIT\"  T1 WHERE T0.\"Code\" = T1.\"Code\" and  T1.\"U_ItemCode\" <>'' and " +
                    //        " (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\"<='" + tbToLeaseCntrct.Value + "')";

                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\"from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
                    query = "Select T0.\"Code\" \"ContractID  \",T4.\"LineId\",case when T0.\"U_ItemCode\"= '' then T0.\"U_ItemCodeLR\" when T0.\"U_ItemCode\" is null then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"ItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" when T0.\"U_ItemDesc\"  is null then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\" ,null \"BillingProcessType\" " +
                        ",null \"IsFixedPrice\",null \"BillingCycle\",null \"Code\" ,null \"Skip\" ,to_date('" + tbBillDate.Value + "') \"BillWizDate\",T0.\"U_BillingCycle\" \"LBillingCycle\" " +
                    "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                          "where (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";


                }

                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

                // convert record to datatable
                sQuery = query;


                //for (int iloop = 0; iloop <= Grid0.DataTable.Columns.Count - 1; iloop++)
                //{
                //    Grid0.Columns.Item(iloop).Editable = false;
                //}
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    if (sbilltype != "M")
                    {
                        if (sbilltype == "E")
                        {
                            Grid0.Columns.Item("Price").Visible = false;
                            Grid0.Columns.Item("FixedPrice").Visible = false;
                            Grid0.Columns.Item("BillWizDate").Visible = false;
                            Grid0.Columns.Item("U_LastBilledDate").Visible = false;
                            Grid0.Columns.Item("U_LastReading").Visible = false;
                        }
                        else if (sbilltype == "B")
                        {
                            Grid0.Columns.Item("Used").Visible = false;
                            Grid0.Columns.Item("Excess").Visible = false;
                            Grid0.Columns.Item("Excess Price").Visible = false;
                            Grid0.Columns.Item("BillWizDate").Visible = false;
                            Grid0.Columns.Item("U_LastBilledDate").Visible = false;
                            Grid0.Columns.Item("U_LastReading").Visible = false;
                        }
                        else if (sbilltype == "C")
                        {
                            Grid0.CollapseLevel = 2;
                            Grid0.Columns.Item("BillWizDate").Visible = false;
                            Grid0.Columns.Item("U_LastBilledDate").Visible = false;
                            Grid0.Columns.Item("U_Price").TitleObject.Caption = "Fixed Price";
                            Grid0.Columns.Item("U_ExcessPrice").TitleObject.Caption = "Excess Price";
                            Grid0.Columns.Item("U_LastReading").Visible = false;
                            //U_ExcessPrice
                        }
                        else if (sbilltype == "S")
                        {
                            //Grid0.Columns.Item("IsFixedPrice").Visible = false;
                            // Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("BillingProcessType").Visible = false;

                        }
                        else if (sbilltype != "F")
                        {
                            //Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("Code").Visible = false;
                            Grid0.Columns.Item("ItemCode").Visible = false;
                            Grid0.Columns.Item("MeterName").Visible = false;
                            Grid0.Columns.Item("Serial No").Visible = false;
                        }

                    }
                }

                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
                {
                    if (sbilltype != "M")
                    {
                        if (sbilltype == "E")
                        {
                            Grid0.Columns.Item("Price").Visible = false;
                            Grid0.Columns.Item("FixedPrice").Visible = false;
                            Grid0.Columns.Item("BillWizDate").Visible = false;
                            Grid0.Columns.Item("U_LastBilledDate").Visible = false;
                            Grid0.Columns.Item("U_LastReading").Visible = false;
                        }
                        else if (sbilltype == "B")
                        {
                            Grid0.Columns.Item("Used").Visible = false;
                            Grid0.Columns.Item("Excess").Visible = false;
                            Grid0.Columns.Item("Excess Price").Visible = false;
                            Grid0.Columns.Item("BillWizDate").Visible = false;
                            Grid0.Columns.Item("U_LastBilledDate").Visible = false;
                            Grid0.Columns.Item("U_LastReading").Visible = false;
                        }
                        else if (sbilltype == "C")
                        {
                            Grid0.CollapseLevel = 2;
                            Grid0.Columns.Item("BillWizDate").Visible = false;
                            Grid0.Columns.Item("U_LastBilledDate").Visible = false;
                            Grid0.Columns.Item("U_Price").TitleObject.Caption = "Fixed Price";
                            Grid0.Columns.Item("U_ExcessPrice").TitleObject.Caption = "Excess Price";
                            Grid0.Columns.Item("U_LastReading").Visible = false;
                            //U_ExcessPrice
                        }
                        else if (sbilltype == "S")
                        {
                            Grid0.CollapseLevel = 2;
                            //Grid0.Columns.Item("IsFixedPrice").Visible = false;
                            //Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("BillingProcessType").Visible = false;

                        }
                        else if (sbilltype != "F")
                        {
                            //Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("Code").Visible = false;

                        }
                    }
                }

                if (sbilltype != "S" && sbilltype != "M")
                {
                    //Grid0.Columns.Item("ContractID").Visible = false;
                    Grid0.Columns.Item("BillingProcessType").Visible = false;
                    Grid0.Columns.Item("IsFixedPrice").Visible = false;
                    Grid0.Columns.Item("BillingCycle").Visible = false;
                    Grid0.Columns.Item("Code").Visible = false;
                    try
                    {
                        Grid0.Columns.Item("Skip").Visible = false;
                    }

                    catch (Exception ex) { }
                    Grid0.Columns.Item("ItemCode").Visible = false;
                    Grid0.Columns.Item("MeterName").Visible = false;
                    Grid0.Columns.Item("Serial No").Visible = false;
                }
                //* (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') ))

                Grid0.AutoResizeColumns();

                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at BillinWizardForm.LoadGridValues Method: " + ex.Message);
            }
        }

        private void LoadGridValues_RecentBackup()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                string tbFromServiceContractValue = string.Empty;
                string sCustomer = string.Empty;
                string sbilltype = string.Empty;
                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                sbilltype = cmbBillingType.Value;
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                    { tbFromServiceContractValue = "  and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "')  "; }
                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                    if (sbilltype == "B")
                    {
                        //Commented - 05 Apr 2016 (For Sql)
                        //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                        //      " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" ," +
                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //      "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' ";



                        //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                        //      " T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )) \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else (T0.\"U_EligQuantity\" * ( (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )))) * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" ,  (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )) \"Skip\" " +
                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //      "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" ";



                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                              " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\"  end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")  \"Used\", " +
                              " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) \"Free Copied\", " +
                               "  0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                              " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                        " case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +
                       "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                        " )  " +
                        " * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                               " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" ,  (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)  \"Skip\" , " +
                               "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then  3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
                              " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                              "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                              " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                              "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" ";

                    }
                    else if (sbilltype == "E")
                    {
                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                 " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else   T0.\"U_LastMeterReading\"  end \"Last Billed Meter Reading\",  \"U_CurrentMeterReading\" \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")  \"Used\", " +
                                 "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                                 " \"Free Copied\", case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") -  " +
                                 " ( " +
                         "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) " +
                        " ))  <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-  " +
                        " (   CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) )    ) end  " +
                        " \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" end \"Total\", " +
                                 " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" , '1' \"Skip\" , " +
                                  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then  3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then  6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then  12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
                                 " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ,T4.\"U_BillingProcessType\" ";

                    }
                    else if (sbilltype == "C")
                    {

                        //                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        // " T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Free Copied\", 0 \"Excess\",   " +
                        //" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
                        //" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else (T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)) * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
                        // " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" FROM \"@Z_ECMD\"  T0 ,  " +
                        // " \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
                        // "  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
                        // " WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        // "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        // "       union all  " +
                        //" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
                        //"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) \"Free Copied\",     " +
                        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) )) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\",   " +
                        //"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +
                        //"   case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\")  " +
                        //"    * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-  " +
                        //"    T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Excess Total\",    " +
                        //"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\"  " +
                        //"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
                        //"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
                        //"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
                        //"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
                        //"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
                        //"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  ";





                        //                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Free Copied\", 0 \"Excess\",   " +
                        //" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
                        //" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else (T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)) * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
                        //" T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" FROM \"@Z_ECMD\"  T0 ,  " +
                        //" \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
                        //"  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
                        //" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //"       union all  " +
                        //" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
                        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
                        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
                        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
                        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
                        //"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) "+
                        //"  * ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0)" +
                        //" \"Free Copied\",     " +
                        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) * "+
                        //"   ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0) "+
                        //                        ")) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) *" +
                        //"ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0)"+
                        //                        ") end \"Excess\",   " +
                        //"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +

                        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
                        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) * " +
                        //"   ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0) " +
                        //                        ")) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
                        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) *" +
                        //"ROUND((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) /((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ),0)" +
                        //                        ") end " +
                        //"* T0.\"U_ExcessPrice\" "+
                        //                        " \"Excess Total\",    " +
                        //"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\"  " +
                        //"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
                        //"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
                        //"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
                        //"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
                        //"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
                        //"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
                        //"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  ";


                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\"  end \"Last Billed Meter Reading\",  " +
"  T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\", " +

 " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) \"Free Copied\",   " +
                         "0 \"Excess\",   " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
" , 0 \"U_ExcessPrice\",    " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end  ) * T0.\"U_Price\" ) end \"Fixed Total\" , 0 \"Excess Total\",  " +
" T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  , (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1) \"Skip\" , " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
"FROM \"@Z_ECMD\"  T0 ,  " +
" \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
"  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
"       union all  " +
" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
"  T0.\"U_CurrentMeterReading\"  \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
   " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * (" +
  "Case when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
  " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
     "when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ) \"Free Copied\", " +

"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")  -   " +
" ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end " +
                        " ))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") -  " +
" ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ))) end \"Excess\",   " +

  "   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +

"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")  - " +
"    ( " +

     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") -  " +
" ( " +
     " CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) * ( " +
  "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then T0.\"U_EligQuantity\" * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then T0.\"U_EligQuantity\" * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then T0.\"U_EligQuantity\" * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then T0.\"U_EligQuantity\" * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then T0.\"U_EligQuantity\" * 1 " +
  "end ))) end " +
   "* T0.\"U_ExcessPrice\" " +
                     " \"Excess Total\",    " +

"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\" , '1' \"Skip\" ,  " +
"Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  ";
                    }
                    else if (sbilltype == "S")
                    {
                        tbFromServiceContractValue = string.Empty;
                        sCustomer = string.Empty;

                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        {
                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        }



                        query = " SELECT distinct T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\" ,  " +
     "  T4.\"U_FixedItem\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\", " +
     "  (T4.\"U_FixedPrice\") \"Fixed Price\",  " +
      "       to_integer( T4.\"U_BillingCycle\") \"Intervals\",   " +
       "  (CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) *   " +
          " (Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   (T4.\"U_FixedPrice\") * 3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   (T4.\"U_FixedPrice\") * 6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   (T4.\"U_FixedPrice\") * 12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then   (T4.\"U_FixedPrice\") * 1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  (T4.\"U_FixedPrice\") * 3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then   (T4.\"U_FixedPrice\") * 6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then   (T4.\"U_FixedPrice\") * 12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   (T4.\"U_FixedPrice\") * 1 " +
  "end )) \"SMA Price\"  , " +
               "       T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\"  , T4.\"U_BillingProcessType\" \"BillingProcessType\"  , " +
      "Case when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '4'    " +
  " then   3 " +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '2' then   6" +
  " when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '1' then   12 " +
   "  when T4.\"U_BillingProcessType\" = 'A' AND T4.\"U_BillingCycle\" = '12' then  1 " +
  "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '4' then  3  " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '2' then  6 " +
 " when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '1' then  12 " +
 "    when T4.\"U_BillingProcessType\" = 'C' AND T4.\"U_BillingCycle\" = '12' then   1 " +
  "end  \"Cycle\" ,   " +
  "  CEILING(((MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') )+ 1)/ (12/T4.\"U_BillingCycle\" ))) \"Ceil\" " +
      "           FROM \"OCTR\" T1  " +
      "                  JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
      "          WHERE        " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
      "                and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'F' ";

                        //                    query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",  " +
                        //" T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"    " +
                        //" \"ItemCode\",T0.\"U_MeterName\" \"MeterName\", T0.\"U_SerialNum\" \"Serial No\",(T4.\"U_FixedPrice\") \"Fixed Price\",  " +
                        //" (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"Intervals\",  " +
                        //" (T4.\"U_FixedPrice\") / (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"SMA Price\",  " +
                        //" T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\"   " +
                        //"  FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"  " +
                        //"   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  " +
                        //"        and T1.\"U_PriceType\" = 'F' ";


                    }
                    else if (sbilltype == "M")
                    {
                        tbFromServiceContractValue = string.Empty;
                        sCustomer = string.Empty;

                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        {
                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        }


                        query = " SELECT distinct  T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T5.\"U_PoolCode\" \"PoolCode\",    " +
   "  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",   " +
    "  T7.\"internalSN\", to_nvarchar('PM') \"Preventive Maintance\"  ,\"U_ServiceAmount\" \"Service Amount\" , \"U_Source\" \"Source\"  , \"callID\" \"Service Call\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , '1' \"Skip\" " +
    "     FROM \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
     "   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"     " +
     "   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     " +
     "   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"    " +
     "   join \"CTR1\" T6 on T6.\"ContractID\" = T1.\"ContractID\"   " +
     "   join \"OSCL\" T7 on T6.\"ContractID\" = T7.\"contractID\" and T6.\"InternalSN\" =  T7.\"internalSN\"   " +
      "  join \"OSCP\" T8 on T8.\"prblmTypID\" = T7.\"problemTyp\"    " +
      "  and T6.\"U_Source\" = T8.\"Name\"   " +
     "   WHERE     " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
         "      and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'M' ";

                    }

                }
                else if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3") //Both
                {
                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" ,T0.\"U_CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

                    //query = "Select T0.\"Code\" \"ContractID\",T0.\"U_ContractNo\" \"ServiceNo\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\",T2.\"U_ItemCode\" \"ServiceLineItem\",T2.\"U_ItemDescp\" \"ServiceLineDesc\",T2.\"U_Quantity\" \"Quantity\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" " +
                    //       "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
                    //query = "Select T0.\"Code\" \"ContractID\",T0.\"U_ContractNo\" \"ServiceNo\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"ItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\",T2.\"U_ItemCode\" \"ServiceLineItem\",T2.\"U_ItemDescp\" \"ServiceLineDesc\",T2.\"U_Quantity\" \"Quantity\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" " +
                    //     "where  (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

                    String ContractId = "";
                    String ContractNo = "";
                    SAPbobsCOM.Recordset rsContractNo = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string cQuery = "Select T0.\"U_ContractNo\" \"ServiceNo\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" where  (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
                    rsContractNo.DoQuery(cQuery);
                    if (rsContractNo.RecordCount > 0)
                    {

                        ContractNo = rsContractNo.Fields.Item("ServiceNo").Value.ToString().Trim();
                    }
                    ContractId = "  and (T0.\"U_DocNum\" >= '" + ContractNo + "' and T0.\"U_DocNum\" <='" + ContractNo + "')  ";
                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                    if (sbilltype == "B")
                    {



                        query = "SELECT distinct T0.\"U_DocNum\" \"ContractNo\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                              " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                              " T0.\"U_EligQuantity\"  \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                              " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
                               " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                               "  ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                               "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
                              " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                              "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                              " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                              "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                              " union all   " +
                              "  Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\", null \"Bill Date\",null \"PoolCode\",null \"MeterCode\", null \"Customer Code\", " +
                              "null \"Customer Name\",null  \"ItemCode\",null \"MeterName\",null \"Serial No\",null \"Start Meter Reading\",0 \"Last Billed Meter Reading\",  " +
                              "null \"Reset\" , 0 \"Used\",0 \"Free Copied\", 0 \"Excess\", 0 \"Price\", 0 \"Excess Price\",  0 \"FixedPrice\", 0 \"Total Amount\" ,null \"BillingProcessType\" ,  null \"IsFixedPrice\", " +
                              "null \"ContractID\" , null \"BillingCycle\" , null \"Code\" ,T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = ''  " +
                              "then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\", " +
                               "T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" from \"@Z_OLCM\" T0 " +
                                "inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"  " +
                               "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";
                        ;

                    }
                    else if (sbilltype == "E")
                    {
                        query = "SELECT distinct T0.\"U_DocNum\" \"ContractNo\" , 'Excess Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                 " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",T0.\"U_CurrentMeterReading\" \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\", " +
                                 " (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) \"Free Copied\", case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") - (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" end \"Total\", " +
                                 " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" " +
                                  " ,null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
                                    "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\"   " +
                                 " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                 "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" " +
                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ,T4.\"U_BillingProcessType\" " +
                                 "        Union all  " +
    "Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\"," +
  "null \"MeterName\", null \"Serial No\",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",  0 \"Currenct Meter Reading\" , null \"Reset\" ,0 \"Used\",  0 \"Free Copied\", 0 \"Excess\", 0 \"U_Price\"," +
   "0 \"U_ExcessPrice\",0 \"Fixed Total\" , 0 \"Excess Total\",null \"IsFixedPrice\", null \"ContractID\" , null \"BillingCycle\" ,null \"BillingProcessType\" , null \"Code\" ," +
 "T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' " +
 "then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" " +
 "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
 "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";


                        ;


                    }
                    else if (sbilltype == "C")
                    {

                        query = " SELECT distinct T0.\"U_DocNum\" \"ContractNo\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
 " T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\",   " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
 " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" " +
 ",null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
 "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
                        "FROM \"@Z_ECMD\"  T0 ,  " +
 " \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
 "  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
 " WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
 "  " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
 "       union all  " +
" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) \"Free Copied\",     " +
"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) )) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\",   " +
"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +
"   case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\")  " +
"    * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-  " +
"    T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Excess Total\",    " +
"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\"   " +
 ",null \"LContractID\",null \"LLineId\",null \"LItemCode\" ,null \"LItem Description\",null \"LBill Date\"," +
 "null \"Monthly Bill\" ,null \"LCustomerCode\",null \"LCustomerName\" " +
"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"     " + ContractId + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\"" +
"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  " +
"        Union all  " +
    "Select T0.\"U_ContractNo\" \"Contract No.\" , 'Lease Billing' \"Billing Type\",null \"Bill Date\",null \"PoolCode\",null \"MeterCode\",null \"Customer Code\", null \"Customer Name\",''  \"ItemCode\"," +
  "null \"MeterName\", null \"Serial No\",0 \"Start Meter Reading\",null  \"Last Billed Meter Reading\",  0 \"Currenct Meter Reading\" , null \"Reset\" ,0 \"Used\",  0 \"Free Copied\", 0 \"Excess\", 0 \"U_Price\"," +
   "0 \"U_ExcessPrice\",0 \"Fixed Total\" , 0 \"Excess Total\",null \"IsFixedPrice\", null \"ContractID\" , null \"BillingCycle\" ,null \"BillingProcessType\" , null \"Code\" ," +
 "T0.\"Code\" \"LContractID\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"LItemCode\" ,case when T0.\"U_ItemDesc\"  = '' " +
 "then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"LItem Description\",T4.\"U_LBDate\" \"LBill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"LCustomerCode\",T0.\"U_CustomerName\" \"LCustomerName\" " +
 "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\" " +
 "where T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "'  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <='" + tbBillDate.Value + "' ";
                        //"where (T0.\"Code\" >= '6' and T0.\"Code\" <= '6')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '20180523'";

                    }

                }
                else
                {
                    //query = "SELECT T1.\"U_ItemCode\" \"ItemCode\", T1.\"U_ItemDescp\" \"Descp\",T0.\"U_CustomerCode\", T0.\"U_CustomerName\", T1.\"U_Quantity\" \"Quantity\",T0.\"U_ContractValue\" \"Price\" FROM \"@Z_OLCM\"  T0 ," +
                    //       " \"@Z_LCIT\"  T1 WHERE T0.\"Code\" = T1.\"Code\" and  T1.\"U_ItemCode\" <>'' and " +
                    //        " (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\"<='" + tbToLeaseCntrct.Value + "')";

                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\"from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
                    query = "Select T0.\"Code\" \"ContractID  \",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"ItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\" ,to_date('" + tbBillDate.Value + "') \"BillWizDate\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                          "where (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

                }

                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

                // convert record to datatable
                sQuery = query;


                //for (int iloop = 0; iloop <= Grid0.DataTable.Columns.Count - 1; iloop++)
                //{
                //    Grid0.Columns.Item(iloop).Editable = false;
                //}
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    if (sbilltype != "M")
                    {
                        if (sbilltype == "E")
                        {
                            Grid0.Columns.Item("Price").Visible = false;
                            Grid0.Columns.Item("FixedPrice").Visible = false;
                        }
                        else if (sbilltype == "B")
                        {
                            Grid0.Columns.Item("Used").Visible = false;
                            Grid0.Columns.Item("Excess").Visible = false;
                            Grid0.Columns.Item("Excess Price").Visible = false;

                        }
                        else if (sbilltype == "C")
                        {
                            Grid0.CollapseLevel = 2;
                            Grid0.Columns.Item("U_Price").TitleObject.Caption = "Fixed Price";
                            Grid0.Columns.Item("U_ExcessPrice").TitleObject.Caption = "Excess Price";
                            //U_ExcessPrice
                        }
                        else if (sbilltype == "S")
                        {
                            //Grid0.Columns.Item("IsFixedPrice").Visible = false;
                            Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("BillingProcessType").Visible = false;

                        }
                        else if (sbilltype != "F")
                        {
                            Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("Code").Visible = false;
                            Grid0.Columns.Item("ItemCode").Visible = false;
                            Grid0.Columns.Item("MeterName").Visible = false;
                            Grid0.Columns.Item("Serial No").Visible = false;
                        }

                    }
                }

                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
                {
                    if (sbilltype != "M")
                    {
                        if (sbilltype == "E")
                        {
                            Grid0.CollapseLevel = 2;
                            Grid0.Columns.Item("Price").Visible = false;
                            Grid0.Columns.Item("FixedPrice").Visible = false;
                        }
                        else if (sbilltype == "B")
                        {
                            Grid0.CollapseLevel = 2;
                            Grid0.Columns.Item("Used").Visible = false;
                            Grid0.Columns.Item("Excess").Visible = false;
                            Grid0.Columns.Item("Excess Price").Visible = false;

                        }
                        else if (sbilltype == "C")
                        {
                            Grid0.CollapseLevel = 3;
                            Grid0.Columns.Item("U_Price").TitleObject.Caption = "Fixed Price";
                            Grid0.Columns.Item("U_ExcessPrice").TitleObject.Caption = "Excess Price";
                            //U_ExcessPrice
                        }
                        else if (sbilltype == "S")
                        {
                            //Grid0.Columns.Item("IsFixedPrice").Visible = false;
                            Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("BillingProcessType").Visible = false;

                        }
                        else if (sbilltype != "F")
                        {
                            Grid0.Columns.Item("ContractID").Visible = false;
                            Grid0.Columns.Item("BillingCycle").Visible = false;
                            Grid0.Columns.Item("Code").Visible = false;
                            Grid0.Columns.Item("ItemCode").Visible = false;
                            Grid0.Columns.Item("MeterName").Visible = false;
                            Grid0.Columns.Item("Serial No").Visible = false;
                        }
                    }
                }

                if (sbilltype != "S")
                {
                    Grid0.Columns.Item("ContractID").Visible = false;
                    Grid0.Columns.Item("BillingProcessType").Visible = false;
                    Grid0.Columns.Item("IsFixedPrice").Visible = false;
                    Grid0.Columns.Item("BillingCycle").Visible = false;
                    Grid0.Columns.Item("Code").Visible = false;
                    try { Grid0.Columns.Item("Skip").Visible = false; }
                    catch (Exception ex) { }



                }
                //* (MONTHS_BETWEEN(T4.\"U_NextBilledDate\" , to_date('" + tbBillDate.Value + "') ))

                Grid0.AutoResizeColumns();

                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at BillinWizardForm.LoadGridValues Method: " + ex.Message);
            }
        }


        //        private void LoadGridValues()
        //        {
        //            try
        //            {
        //                this.UIAPIRawForm.Freeze(true);
        //                string tbFromServiceContractValue = string.Empty;
        //                string sCustomer = string.Empty;
        //                string sbilltype = string.Empty;
        //                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //                string query = "";
        //                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
        //                {
        //                    if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
        //                    { tbFromServiceContractValue = "  and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "')  "; }
        //                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
        //                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
        //                    sbilltype = cmbBillingType.Value;
        //                    if (sbilltype == "B")
        //                    {
        //                        //Commented - 05 Apr 2016 (For Sql)
        //                        //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
        //                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
        //                        //      " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
        //                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" ," +
        //                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
        //                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
        //                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
        //                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        //                        //      "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' ";


        //                        //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
        //                        //      " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
        //                        //      " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
        //                        //      " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
        //                        //       " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
        //                        //      " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
        //                        //      "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
        //                        //      " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        //                        //      "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' ";


        //                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
        //                              " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
        //                              " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
        //                              " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , " +
        //                               " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
        //                              " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
        //                              "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
        //                              " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        //                              "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' and T0.\"U_MeterCode\" = T5.\"U_MeterItemCode\" ";

        //                    }
        //                    else if (sbilltype == "E")
        //                    {
        //                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
        //                                 " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",T0.\"U_CurrentMeterReading\" \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\", " +
        //                                 " (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) \"Free Copied\", case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") - (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" end \"Total\", " +
        //                                 " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
        //                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\" " +
        //                                 " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
        //                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
        //                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        //                                 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F'  " +
        //                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ,T4.\"U_BillingProcessType\" ";

        //                    }
        //                    else if (sbilltype == "C")
        //                    {

        //                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
        // " T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\",   " +
        //" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
        //" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
        // " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\" , T0.\"Code\"  FROM \"@Z_ECMD\"  T0 ,  " +
        // " \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
        // "  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
        // " WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        // "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  " +
        // "       union all  " +
        //" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
        //" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
        //" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
        //" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
        //" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
        //"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) \"Free Copied\",     " +
        //"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
        //"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) )) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
        //"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\",   " +
        //"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +
        //"   case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\")  " +
        //"    * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-  " +
        //"    T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Excess Total\",    " +
        //"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T4.\"U_BillingProcessType\" \"BillingProcessType\", T0.\"Code\"   " +
        //"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
        //"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
        //"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        //"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  " +
        //"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
        //"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
        //"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
        //"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
        //"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" , T4.\"U_BillingProcessType\"  ";
        //                    }
        //                    else if (sbilltype == "S")
        //                    {
        //                        tbFromServiceContractValue = string.Empty;
        //                        sCustomer = string.Empty;

        //                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
        //                        {
        //                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
        //                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
        //                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
        //                        }
        //                        else
        //                        {
        //                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
        //                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

        //                        }

        //                        query = " SELECT distinct T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T5.\"U_PoolCode\" \"PoolCode\",  " +
        //     "  T4.\"U_FixedItem\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",(T4.\"U_FixedPrice\") \"Fixed Price\",  " +
        //      "       to_integer( T4.\"U_BillingCycle\") \"Intervals\",   " +
        //      "      (T4.\"U_FixedPrice\") / to_integer( T4.\"U_BillingCycle\") \"SMA Price\",    " +
        //      "       T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\"  , T4.\"U_BillingProcessType\" \"BillingProcessType\"   " +
        //      "           FROM \"OCTR\" T1  " +
        //      "        join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"      join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"    " +
        //       "                  JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
        //      "          WHERE        " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
        //      "                and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'F' ";

        //                        //                    query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",  " +
        //                        //" T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"    " +
        //                        //" \"ItemCode\",T0.\"U_MeterName\" \"MeterName\", T0.\"U_SerialNum\" \"Serial No\",(T4.\"U_FixedPrice\") \"Fixed Price\",  " +
        //                        //" (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"Intervals\",  " +
        //                        //" (T4.\"U_FixedPrice\") / (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"SMA Price\",  " +
        //                        //" T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\"   " +
        //                        //"  FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
        //                        //"  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"  " +
        //                        //"   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
        //                        //"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  " +
        //                        //"        and T1.\"U_PriceType\" = 'F' ";


        //                    }
        //                    else if (sbilltype == "M")
        //                    {
        //                        tbFromServiceContractValue = string.Empty;
        //                        sCustomer = string.Empty;

        //                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
        //                        {
        //                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
        //                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
        //                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
        //                        }
        //                        else
        //                        {
        //                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
        //                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

        //                        }


        //                        query = " SELECT distinct  T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T5.\"U_PoolCode\" \"PoolCode\",    " +
        //   "  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",   " +
        //    "  T7.\"internalSN\", to_nvarchar('PM') \"Preventive Maintance\"  ,\"U_ServiceAmount\" \"Service Amount\" , \"U_Source\" \"Source\"  , \"callID\" \"Service Call\" , T4.\"U_BillingProcessType\" \"BillingProcessType\"  " +
        //    "     FROM \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
        //     "   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"     " +
        //     "   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     " +
        //     "   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"    " +
        //     "   join \"CTR1\" T6 on T6.\"ContractID\" = T1.\"ContractID\"   " +
        //     "   join \"OSCL\" T7 on T6.\"ContractID\" = T7.\"contractID\" and T6.\"InternalSN\" =  T7.\"internalSN\"   " +
        //      "  join \"OSCP\" T8 on T8.\"prblmTypID\" = T7.\"problemTyp\"    " +
        //      "  and T6.\"U_Source\" = T8.\"Name\"   " +
        //     "   WHERE     " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
        //         "      and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'M' ";

        //                    }

        //                }
        //                else if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
        //                {
        //                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" ,T0.\"U_CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
        //                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

        //                    //query = "Select T0.\"Code\" \"ContractID\",T0.\"U_ContractNo\" \"ServiceNo\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\",T2.\"U_ItemCode\" \"ServiceLineItem\",T2.\"U_ItemDescp\" \"ServiceLineDesc\",T2.\"U_Quantity\" \"Quantity\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" " +
        //                    //       "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
        //                    query = "Select T0.\"Code\" \"ContractID\",T0.\"U_ContractNo\" \"ServiceNo\",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"ItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\",T0.\"U_ServiceTotal\" \"ServiceTotal\",T2.\"U_ItemCode\" \"ServiceLineItem\",T2.\"U_ItemDescp\" \"ServiceLineDesc\",T2.\"U_Quantity\" \"Quantity\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"   left join \"@Z_LCIT\" T2 on T2.\"Code\" = T0.\"Code\" " +
        //                         "where  (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

        //                }
        //                else
        //                {
        //                    //query = "SELECT T1.\"U_ItemCode\" \"ItemCode\", T1.\"U_ItemDescp\" \"Descp\",T0.\"U_CustomerCode\", T0.\"U_CustomerName\", T1.\"U_Quantity\" \"Quantity\",T0.\"U_ContractValue\" \"Price\" FROM \"@Z_OLCM\"  T0 ," +
        //                    //       " \"@Z_LCIT\"  T1 WHERE T0.\"Code\" = T1.\"Code\" and  T1.\"U_ItemCode\" <>'' and " +
        //                    //        " (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\"<='" + tbToLeaseCntrct.Value + "')";

        //                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\"from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
        //                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
        //                    query = "Select T0.\"Code\" \"ContractID  \",T4.\"LineId\",case when T0.\"U_ItemCode\" = '' then T0.\"U_ItemCodeLR\" else T0.\"U_ItemCode\" end \"ItemCode\" ,case when T0.\"U_ItemDesc\"  = '' then T0.\"U_ItemDescLR\" else T0.\"U_ItemDesc\" end \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\"from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
        //                          "where (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

        //                }

        //                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
        //                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

        //                // convert record to datatable
        //                sQuery = query;


        //                //for (int iloop = 0; iloop <= Grid0.DataTable.Columns.Count - 1; iloop++)
        //                //{
        //                //    Grid0.Columns.Item(iloop).Editable = false;
        //                //}
        //                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
        //                {
        //                    if (sbilltype != "M")
        //                    {
        //                        if (sbilltype == "E")
        //                        {
        //                            Grid0.Columns.Item("Price").Visible = false;
        //                            Grid0.Columns.Item("FixedPrice").Visible = false;
        //                        }
        //                        else if (sbilltype == "B")
        //                        {
        //                            Grid0.Columns.Item("Used").Visible = false;
        //                            Grid0.Columns.Item("Excess").Visible = false;
        //                            Grid0.Columns.Item("Excess Price").Visible = false;

        //                        }
        //                        else if (sbilltype == "C")
        //                        {
        //                            Grid0.CollapseLevel = 2;
        //                            Grid0.Columns.Item("U_Price").TitleObject.Caption = "Fixed Price";
        //                            Grid0.Columns.Item("U_ExcessPrice").TitleObject.Caption = "Excess Price";
        //                            //U_ExcessPrice
        //                        }
        //                        else if (sbilltype != "S")
        //                        {
        //                            //Grid0.Columns.Item("IsFixedPrice").Visible = false;

        //                        }
        //                        else if (sbilltype != "F")
        //                        {
        //                            Grid0.Columns.Item("ContractID").Visible = false;
        //                            Grid0.Columns.Item("BillingCycle").Visible = false;
        //                            Grid0.Columns.Item("Code").Visible = false;
        //                            Grid0.Columns.Item("ItemCode").Visible = false;
        //                            Grid0.Columns.Item("MeterName").Visible = false;
        //                            Grid0.Columns.Item("Serial No").Visible = false;
        //                        }

        //                    }
        //                }


        //                Grid0.AutoResizeColumns();

        //                this.UIAPIRawForm.Freeze(false);
        //            }
        //            catch (Exception ex)
        //            {
        //                this.UIAPIRawForm.Freeze(false);
        //                Utility.LogException("Error at BillinWizardForm.LoadGridValues Method: " + ex.Message);
        //            }
        //        }



        private void LoadGridValuesOLDNew()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                string tbFromServiceContractValue = string.Empty;
                string sCustomer = string.Empty;
                string sbilltype = string.Empty;
                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                    { tbFromServiceContractValue = "  and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "')  "; }
                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                    sbilltype = cmbBillingType.Value;
                    if (sbilltype == "B")
                    {
                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                              " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                              " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                              " T5.\"U_FixedPrice\" \"FixedPrice\" , case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Total Amount\" ," +
                               " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                              " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                              "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                              " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                              "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F' ";

                    }
                    else if (sbilltype == "E")
                    {
                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                 " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",T0.\"U_CurrentMeterReading\" \" Currenct Meter Reading\" , T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\", " +
                                 " T0.\"U_EligQuantity\" \"Free Copied\", case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") -T0.\"U_EligQuantity\") <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Total\", " +
                                 " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                                 " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F'  " +
                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\" ";

                    }
                    else if (sbilltype == "C")
                    {

                        query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Fixed Billing' \"Billing Type\", T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
 " T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , 0 \"Used\",  T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\",   " +
" case when  T2.\"U_IsFixedPrice\" = 'Y' then to_number(T5.\"U_FixedPrice\",10,4) else   to_number(T0.\"U_Price\" ,10,4) end \"U_Price\"    " +
" , 0 \"U_ExcessPrice\",      case when  T2.\"U_IsFixedPrice\" = 'Y' then T5.\"U_FixedPrice\" else T0.\"U_EligQuantity\" * T0.\"U_Price\" end \"Fixed Total\" , 0 \"Excess Total\",  " +
 " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\"  FROM \"@Z_ECMD\"  T0 ,  " +
 " \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN   " +
 "  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
 " WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  " +
 "       union all  " +
" SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , 'Excess Billing' \"Billing Type\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\",  " +
" T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\",   " +
" T0.\"U_SerialNum\" \"Serial No\", T0.\"U_StartMeterReading\" \"Start Meter Reading\",  " +
" case when T0.\"U_Reset\" = 'Y' then T0.\"U_RLastMeterReading\"  else  T0.\"U_LastMeterReading\" end \"Last Billed Meter Reading\",  " +
" T0.\"U_CurrentMeterReading\" \"Currenct Meter Reading\" ,  T0.\"U_Reset\" \"Reset\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") \"Used\",  " +
"   T0.\"U_EligQuantity\" \"Free Copied\",     " +
"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
"   -(T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(TO_DATE (T4.\"U_NextBilledDate\"), TO_DATE('" + tbBillDate.Value + "')) + 1))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * (MONTHS_BETWEEN(TO_DATE (T4.\"U_NextBilledDate\"), TO_DATE('" + tbBillDate.Value + "')) + 1))) end \"Excess\",   " +
"   0 \"U_Price\",T0.\"U_ExcessPrice\" \"U_ExcessPrice\" , 0 \"Fixed Total\" ,  " +
"   case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\")  " +
"    * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-  " +
"    T0.\"U_RLastMeterReading\")-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Excess Total\",    " +
"     T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" ,  T4.\"U_BillingCycle\"  \"BillingCycle\" , T0.\"Code\"   " +
"      FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
"       join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"   " +
"       JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
"     " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'E'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null   and T1.\"U_PriceType\" <> 'F'  " +
"             GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",  " +
"             T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,  " +
"             T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,   " +
"             T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",    " +
"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\" ";

                    }
                    else if (sbilltype == "S")
                    {
                        tbFromServiceContractValue = string.Empty;
                        sCustomer = string.Empty;

                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        {
                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        }

                        query = " SELECT distinct T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T5.\"U_PoolCode\" \"PoolCode\",  " +
     "  T4.\"U_FixedItem\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",(T4.\"U_FixedPrice\") \"Fixed Price\",  " +
      "       to_integer( T4.\"U_BillingCycle\") \"Intervals\",   " +
      "      (T4.\"U_FixedPrice\") / to_integer( T4.\"U_BillingCycle\") \"SMA Price\",    " +
      "       T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\"     " +
      "           FROM \"OCTR\" T1  " +
      "        join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"      join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"    " +
       "                  JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"  " +
      "          WHERE        " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
      "                and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'F' ";

                        //                    query = " SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",  " +
                        //" T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",T0.\"U_ItemCode\"    " +
                        //" \"ItemCode\",T0.\"U_MeterName\" \"MeterName\", T0.\"U_SerialNum\" \"Serial No\",(T4.\"U_FixedPrice\") \"Fixed Price\",  " +
                        //" (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"Intervals\",  " +
                        //" (T4.\"U_FixedPrice\") / (MONTHS_BETWEEN(TO_DATE (T1.\"StartDate\"), TO_DATE(T1.\"EndDate\")) + 1) \"SMA Price\",  " +
                        //" T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\"   " +
                        //"  FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
                        //"  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"  " +
                        //"   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                        //"  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = 'B' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  " +
                        //"        and T1.\"U_PriceType\" = 'F' ";


                    }
                    else if (sbilltype == "M")
                    {
                        tbFromServiceContractValue = string.Empty;
                        sCustomer = string.Empty;

                        if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                        {
                            tbFromServiceContractValue = "    (T1.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and T1.\"ContractID\" <='" + tbToServiceContract.Value + "')  ";
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "  and  ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                            { sCustomer = "   ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }

                        }


                        query = " SELECT distinct  T1.\"ContractID\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T5.\"U_PoolCode\" \"PoolCode\",    " +
   "  T1.\"CstmrCode\" \"Customer Code\", T1.\"CstmrName\" \"Customer Name\",   " +
    "  T7.\"internalSN\", to_nvarchar('PM') \"Preventive Maintance\"  ,\"U_ServiceAmount\" \"Service Amount\" , \"U_Source\" \"Source\"  , \"callID\" \"Service Call\"  " +
    "     FROM \"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\"    " +
     "   join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"     " +
     "   JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\"     " +
     "   JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\"    " +
     "   join \"CTR1\" T6 on T6.\"ContractID\" = T1.\"ContractID\"   " +
     "   join \"OSCL\" T7 on T6.\"ContractID\" = T7.\"contractID\" and T6.\"InternalSN\" =  T7.\"internalSN\"   " +
      "  join \"OSCP\" T8 on T8.\"prblmTypID\" = T7.\"problemTyp\"    " +
      "  and T6.\"U_Source\" = T8.\"Name\"   " +
     "   WHERE     " + tbFromServiceContractValue + "  " + sCustomer + "   and T4.\"U_BillingType\" = 'B'  " +
         "      and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null          and T1.\"U_PriceType\" = 'M' ";

                    }

                }
                else
                {
                    query = "SELECT T1.\"U_ItemCode\" \"ItemCode\", T1.\"U_ItemDescp\" \"Descp\",T0.\"U_CustomerCode\", T0.\"U_CustomerName\", T1.\"U_Quantity\" \"Quantity\",T0.\"U_ContractValue\" \"Price\" FROM \"@Z_OLCM\"  T0 ," +
                           " \"@Z_LCIT\"  T1 WHERE T0.\"Code\" = T1.\"Code\" and  T1.\"U_ItemCode\" <>'' and " +
                            " (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\"<='" + tbToLeaseCntrct.Value + "')";
                }

                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

                // convert record to datatable
                sQuery = query;


                //for (int iloop = 0; iloop <= Grid0.DataTable.Columns.Count - 1; iloop++)
                //{
                //    Grid0.Columns.Item(iloop).Editable = false;
                //}
                if (sbilltype != "M")
                {
                    if (sbilltype == "E")
                    {
                        Grid0.Columns.Item("Price").Visible = false;
                        Grid0.Columns.Item("FixedPrice").Visible = false;
                    }
                    else if (sbilltype == "B")
                    {
                        Grid0.Columns.Item("Used").Visible = false;
                        Grid0.Columns.Item("Excess").Visible = false;
                        Grid0.Columns.Item("Excess Price").Visible = false;

                    }
                    else if (sbilltype == "C")
                    {
                        Grid0.CollapseLevel = 2;
                        Grid0.Columns.Item("U_Price").TitleObject.Caption = "Fixed Price";
                        Grid0.Columns.Item("U_ExcessPrice").TitleObject.Caption = "Excess Price";
                        //U_ExcessPrice
                    }
                    else if (sbilltype != "S")
                    {
                        Grid0.Columns.Item("IsFixedPrice").Visible = false;

                    }
                    else if (sbilltype != "F")
                    {
                        Grid0.Columns.Item("ContractID").Visible = false;
                        Grid0.Columns.Item("BillingCycle").Visible = false;
                        Grid0.Columns.Item("Code").Visible = false;
                        Grid0.Columns.Item("ItemCode").Visible = false;
                        Grid0.Columns.Item("MeterName").Visible = false;
                        Grid0.Columns.Item("Serial No").Visible = false;
                    }

                }


                Grid0.AutoResizeColumns();

                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at BillinWizardForm.LoadGridValuesOLDNew Method: " + ex.Message);
            }
        }


        private void LoadGridValuesBackup()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                string tbFromServiceContractValue = string.Empty;
                string sCustomer = string.Empty;
                string sbilltype = string.Empty;
                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                    { tbFromServiceContractValue = "  and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "')  "; }
                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }
                    sbilltype = cmbBillingType.Value;
                    if (sbilltype == "B")
                    {
                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\", T1.\"CstmrName\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                              " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",T0.\"U_LastMeterReading\" \"Billed Meter Reading\",(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                              " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                              " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                               " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                              " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                              "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                              " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                              "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null";

                    }
                    else if (sbilltype == "E")
                    {
                        query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\", T1.\"CstmrName\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                 " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",T0.\"U_LastMeterReading\" \"Billed Meter Reading\",(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                                 " T0.\"U_EligQuantity\" \"Free Copied\", case when  (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") <= 0 then 0 else  (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" <= 0 then 0 else (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Total\", " +
                                 " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                                 " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null " +
                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\"   ,    T0.\"Code\" ";

                    }

                }
                else
                {
                    query = "SELECT T1.\"U_ItemCode\" \"ItemCode\", T1.\"U_ItemDescp\" \"Descp\",T0.\"U_CustomerCode\", T0.\"U_CustomerName\", T1.\"U_Quantity\" \"Quantity\",T0.\"U_ContractValue\" \"Price\" FROM \"@Z_OLCM\"  T0 ," +
                           " \"@Z_LCIT\"  T1 WHERE T0.\"Code\" = T1.\"Code\" and  T1.\"U_ItemCode\" <>'' and " +
                            " (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\"<='" + tbToLeaseCntrct.Value + "')";
                }

                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

                // convert record to datatable
                sQuery = query;


                //for (int iloop = 0; iloop <= Grid0.DataTable.Columns.Count - 1; iloop++)
                //{
                //    Grid0.Columns.Item(iloop).Editable = false;
                //}
                Grid0.Columns.Item("IsFixedPrice").Visible = false;
                Grid0.Columns.Item("ContractID").Visible = false;
                Grid0.Columns.Item("BillingCycle").Visible = false;
                Grid0.Columns.Item("Code").Visible = false;
                Grid0.Columns.Item("ItemCode").Visible = false;
                Grid0.Columns.Item("MeterName").Visible = false;
                Grid0.Columns.Item("Serial No").Visible = false;
                if (sbilltype == "E")
                {
                    Grid0.Columns.Item("Price").Visible = false;
                    Grid0.Columns.Item("FixedPrice").Visible = false;
                }
                else
                {
                    Grid0.Columns.Item("Used").Visible = false;
                    Grid0.Columns.Item("Excess").Visible = false;
                    Grid0.Columns.Item("Excess Price").Visible = false;

                }

                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at BillinWizardForm.LoadGridValuesBackup Method: " + ex.Message);
            }
        }


        private void LoadGridValuesOLD()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                string tbFromServiceContractValue = string.Empty;
                string sCustomer = string.Empty;
                string sbilltype = string.Empty;
                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                {
                    string billOptions = "";

                    if (!string.IsNullOrEmpty(tbFromServiceContract.Value) && !string.IsNullOrEmpty(tbToServiceContract.Value))
                    { tbFromServiceContractValue = "  and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "')  "; }

                    if (!string.IsNullOrEmpty(tbFrmCustomer.Value) && !string.IsNullOrEmpty(tbToCustomer.Value))
                    { sCustomer = "  and ( T1.\"CstmrCode\"  between '" + tbFrmCustomer.Value + "' and '" + tbToCustomer.Value + "')  "; }


                    sbilltype = cmbBillingType.Value;

                    // T1.\"CstmrCode\"
                    if (cmbBilOptions.Value != string.Empty)
                    {
                        //combine the Meter based on Pool Code
                        billOptions = cmbBilOptions.Value;
                    }

                    if (billOptions == "1")
                    {
                        string strContrcts = string.Empty;
                        //get approved contracts based on Bill date and Next bill date of Billing Information in Service Contract
                        query = "SELECT T0.\"ContractID\"  FROM OCTR T0 , \"@Z_OSRB\"  T1, \"@Z_SRB1\"  T2 WHERE " +
                                " T0.\"ContractID\" = T1.\"U_ContractNo\" and  T1.\"Code\" = T2.\"Code\" and  " +
                                " T2.\"U_BillingType\" ='" + cmbBillingType.Value + "' and  T0.\"Status\" ='A' and  " +
                                " T2.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "'";

                        rsObj.DoQuery(query);
                        if (rsObj.RecordCount > 0)
                        {
                            while (rsObj.EoF == false)
                            {
                                strContrcts += "," + rsObj.Fields.Item(0).Value.ToString();

                                rsObj.MoveNext();
                            }

                        }
                        else
                        {
                            SAPbouiCOM.Framework.Application.SBO_Application.StatusBar.SetSystemMessage("No active contracts", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                            return;
                        }
                        if (strContrcts.Length > 0)
                        {
                            strContrcts = strContrcts.Substring(1);
                        }

                        query = "SELECT T0.\"ContractID\",T0.\"CstmrCode\", T0.\"CstmrName\",T1.\"U_IsFixedPrice\" \"IsFixedPrice\", T2.\"U_PoolCode\" \"PoolCode\", T2.\"U_MeterCode\" \"MeterCode\"," +
                                " T2.\"U_MeterItemCode\" \"MeterItemCode\",T2.\"U_EligibleQuantity\" \"Quantity\", T2.\"U_Price\" \"UnitPrice\", T2.\"U_TotalPrice\" \"TotalPrice\" , T2.\"U_FixedPrice\" \"FixedPrice\", T2.\"U_ExcessPrice\" \"ExcessPrice\"," +
                                " T2.\"U_ItemCode\" \"ItemCode\" FROM OCTR T0 , \"@Z_OSRP\"  T1, \"@Z_SRP1\"  T2 WHERE " +
                                    "T0.\"ContractID\" = T1.\"U_ContractNo\" and  T1.\"Code\" = T2.\"Code\" and T2.\"U_PoolCode\" <>'' and  T0.\"ContractID\" in (" + strContrcts + ")";
                        //query = "SELECT T0.\"U_BillDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_ItemCode\" \"ItemCode\",T1.\"CstmrCode\", T1.\"CstmrName\"," +
                        //         " T0.\"U_SerialNum\" \"Serial No\", sum(T0.\"U_EligQuantity\") as \"Free Copied\",Sum(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                        //         " Sum(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") \"ExcessQty\", " +
                        //         " (Sum(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") * Sum(T0.\"U_Price\")) \"Fixed\", ( Sum(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * Sum(T0.\"U_ExcessPrice\")) \"Excess\" " +
                        //         " FROM \"@Z_ECMD\"  T0,\"OCTR\" T1 WHERE  " +
                        //         " T0.\"U_DocNum\" = T1.\"ContractID\" " +
                        //         " and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "') and  T0.\"U_Billed\" ='N' and T0.\"U_BillDate\" <= '" + tbBillDate.Value + "' " +
                        //         " Group BY T0.\"U_BillDate\",T0.\"U_PoolCode\"," +
                        //         " T0.\"U_SerialNum\" ,T0.\"U_ItemCode\" ,T1.\"CstmrCode\", T1.\"CstmrName\"";
                    }
                    else
                    {

                        if (sbilltype == "B")
                        {
                            query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\", T1.\"CstmrName\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                  " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",T0.\"U_LastMeterReading\" \"Billed Meter Reading\",(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                                  " T0.\"U_EligQuantity\" \"Free Copied\", 0 \"Excess\", T0.\"U_Price\" \"Price\", 0 \"Excess Price\", " +
                                  " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                                   " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                                  " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                  "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                  " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                  "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "' and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null";
                        }
                        else if (sbilltype == "E")
                        {
                            query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\", T1.\"CstmrName\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                                     " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",T0.\"U_LastMeterReading\" \"Billed Meter Reading\",(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                                     " T0.\"U_EligQuantity\" \"Free Copied\", case when (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") <= 0 then 0 else (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" <= 0 then 0 else (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" end \"Total\", " +
                                     " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                                      " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                                     " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                     "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                     " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                     "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null " +
                                     "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\"   ,    T0.\"Code\" ";


                            //query = "SELECT distinct T0.\"U_DocNum\" \"Contract No.\" , T4.\"U_NextBilledDate\" \"Bill Date\",T0.\"U_PoolCode\" \"PoolCode\",T0.\"U_MeterCode\" \"MeterCode\", T1.\"CstmrCode\", T1.\"CstmrName\",T0.\"U_ItemCode\"  \"ItemCode\",T0.\"U_MeterName\" \"MeterName\"," +
                            //        " T0.\"U_SerialNum\" \"Serial No\",T0.\"U_StartMeterReading\" \"Start Meter Reading\",T0.\"U_LastMeterReading\" \"Billed Meter Reading\",(T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") \"Used\", " +
                            //        " T0.\"U_EligQuantity\" \"Free Copied\", (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , (T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\" \"Total\", " +
                            //        " T5.\"U_FixedPrice\" \"FixedPrice\" , " +
                            //         " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                            //        " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                            //        "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                            //        " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                            //        "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null " +
                            //        "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\"   ,    T0.\"Code\" " +
                            //              "HAVING ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\"-T0.\"U_EligQuantity\") * T0.\"U_ExcessPrice\") > 0";
                        }

                    }
                }
                else
                {
                    query = "SELECT T1.\"U_ItemCode\" \"ItemCode\", T1.\"U_ItemDescp\" \"Descp\",T0.\"U_CustomerCode\", T0.\"U_CustomerName\", T1.\"U_Quantity\" \"Quantity\",T0.\"U_ContractValue\" \"Price\" FROM \"@Z_OLCM\"  T0 ," +
                           " \"@Z_LCIT\"  T1 WHERE T0.\"Code\" = T1.\"Code\" and  T1.\"U_ItemCode\" <>'' and " +
                            " (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\"<='" + tbToLeaseCntrct.Value + "')";
                }

                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

                sQuery = query;

                Grid0.Columns.Item("IsFixedPrice").Visible = false;
                Grid0.Columns.Item("ContractID").Visible = false;
                Grid0.Columns.Item("BillingCycle").Visible = false;
                Grid0.Columns.Item("Code").Visible = false;
                Grid0.Columns.Item("ItemCode").Visible = false;
                Grid0.Columns.Item("MeterName").Visible = false;
                Grid0.Columns.Item("Serial No").Visible = false;
                if (sbilltype == "E")
                {
                    Grid0.Columns.Item("Price").Visible = false;
                    Grid0.Columns.Item("FixedPrice").Visible = false;

                }
                else
                {
                    Grid0.Columns.Item("Used").Visible = false;
                    Grid0.Columns.Item("Excess").Visible = false;
                    Grid0.Columns.Item("Excess Price").Visible = false;


                }

                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at BillinWizardForm.LoadGridValuesOLD Method: " + ex.Message);
            }
        }
        private void btnGenerate_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            switch (cmbBillingType.Value)
            {
                case "":
                    if (cmbBilOptions.Value == "2")
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "2")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            //PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }


                    break;
                case "B":
                    if (cmbBilOptions.Value == "3")//Both
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            //PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }

                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")//Service
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    break;
                case "E":
                    if (cmbBilOptions.Value == "2")
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    else if (cmbBillOption.Value == "2")
                    {
                        //Finance Billing

                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }

                    if (cmbBilOptions.Value == "3")//Both
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            //PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    break;
                case "C":
                    if (cmbBilOptions.Value == "2")
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocumentBoth(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }

                    if (cmbBilOptions.Value == "3")//Both
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocumentAll(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            //PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    else if (cmbBillOption.Value == "2")
                    {
                        //Finance Billing

                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            PostArRDocument(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    break;
                case "S":
                    if (cmbBilOptions.Value == "2")
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocumentSMA(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }

                    if (cmbBilOptions.Value == "3")//Both
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "3")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocumentSMABoth(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            //PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    break;
                case "M":
                    if (cmbBilOptions.Value == "2")
                    {
                        if (tbFrmCustomer.Value == "" && tbToCustomer.Value == "")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Customer can not be blank .....!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }

                    }
                    if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "1")
                    {
                        if (cmbTargetDoc.Value != string.Empty && cmbTargetDoc.Value == "1")
                        {
                            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Invoice generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            PostArRDocumentM(cmbBillOption.Value);
                        }
                        else if (cmbTargetDoc.Value == "2")
                        {
                            PostDeliveryNotes(cmbBillOption.Value);
                        }
                    }
                    break;
                default:

                    break;
            }




        }


        public DataTable ConvertRecordset(SAPbobsCOM.Recordset SAPRecordset)
        {

            //\ This function will take an SAP recordset from the SAPbobsCOM library and convert it to a more
            //\ easily used ADO.NET datatable which can be used for data binding much easier.

            DataTable dtTable = new DataTable();
            DataColumn NewCol = null;
            DataRow NewRow = null;
            int ColCount = 0;
            String sFuncName = String.Empty;

            try
            {
                sFuncName = "HANAtoDatatable()";

                for (ColCount = 0; ColCount <= SAPRecordset.Fields.Count - 1; ColCount++)
                {
                    NewCol = new DataColumn(SAPRecordset.Fields.Item(ColCount).Name);
                    dtTable.Columns.Add(NewCol);
                }


                while (!(SAPRecordset.EoF))
                {
                    NewRow = dtTable.NewRow();
                    //populate each column in the row we're creating

                    for (ColCount = 0; ColCount <= SAPRecordset.Fields.Count - 1; ColCount++)
                    {
                        NewRow[SAPRecordset.Fields.Item(ColCount).Name] = SAPRecordset.Fields.Item(ColCount).Value;

                    }

                    //Add the row to the datatable
                    dtTable.Rows.Add(NewRow);


                    SAPRecordset.MoveNext();
                }

                return dtTable;

            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.ToString() + Strings.Chr(10) + "Error converting SAP Recordset to DataTable", MsgBoxStyle.Exclamation);

                Utility.LogException(ex);
                return null;
            }
            // return functionReturnValue;


        }
        private void PostArRDocumentM(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billdate = "";
            string itemCode = "";
            int interval = 0;
            var lstdt = new List<DataTable>();

            string BillType = "";
            if (cmbBillingType.Value != string.Empty)
            {
                //Fixed Billing Calculation
                BillType = cmbBillingType.Value;
            }
            if (billgenType == "1")
            {
                // rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTSC = new DataTable();
                oDT.Columns.Add("ContractID", typeof(String)); //2
                oDT.Columns.Add("Bill Date", typeof(String));
                oDT.Columns.Add("Customer Code", typeof(String)); //2
                oDT.Columns.Add("MeterCode", typeof(String));
                oDT.Columns.Add("Amount", typeof(Decimal)); //2
                oDT.Columns.Add("ServiceCall", typeof(String));
                oDTSC.Columns.Add("ServiceCall", typeof(String));
                oDT.Columns.Add("PoolCode", typeof(String));
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    oDTSC.Rows.Add(Grid0.DataTable.GetValue("Service Call", iloop));

                    if (Grid0.Rows.IsSelected(iloop))
                        oDT.Rows.Add(Grid0.DataTable.GetValue("Contract No.", iloop), Grid0.DataTable.GetValue("Bill Date", iloop), Grid0.DataTable.GetValue("Customer Code", iloop),
                            Grid0.DataTable.GetValue("Preventive Maintance", iloop), Grid0.DataTable.GetValue("Service Amount", iloop), Grid0.DataTable.GetValue("Service Call", iloop), Grid0.DataTable.GetValue("PoolCode", iloop));
                }

                if (oDT.Rows.Count > 0)
                {
                    DataTable oDTDistinct = new DataTable();
                    DataView oDVInvoiceHeader = new DataView(oDT);
                    string servicecall = string.Empty;
                    oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                    foreach (DataRow Dr in oDTDistinct.Rows)
                    {
                        oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                        ContractID = oDTDistinct.Rows[0][0].ToString();

                        SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                        oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                        oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;

                        oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                        // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();
                        Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                        interval = oDVInvoiceHeader.Count;
                        foreach (DataRowView odrv in oDVInvoiceHeader)
                        {
                            itemCode = odrv["MeterCode"].ToString().Trim();
                            DateTime dt = new DateTime();
                            dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                            Billdate = dt.ToString("yyyyMMdd");
                            oInv.Lines.ItemCode = itemCode;
                            oInv.Lines.Quantity = 1;
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Amount"].ToString().Trim());
                            oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                            servicecall += odrv["ServiceCall"].ToString() + ", ";
                            oInv.Lines.UserFields.Fields.Item("U_PoolCode").Value = odrv["PoolCode"].ToString().Trim();
                            oInv.Lines.Add();

                        }

                        oInv.NumAtCard = servicecall.Substring(0, servicecall.Length - 2);
                        if (oInv.Add() == 0)
                        {
                            //update status to billling ='Y'
                            isposted = true;
                            UpdateNextBillDateforContracts(ContractID, "B");
                            isposted = true;
                            Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                        }
                        else
                        {
                            isposted = false;
                            var message = B1Helper.DiCompany.GetLastErrorDescription();
                            Utility.LogErrors(message);
                        }

                    }

                    if (isposted)
                    {
                        //updatemachineDetails();
                        //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                        oDVInvoiceHeader = new DataView(oDTSC);
                        oDTDistinct = oDVInvoiceHeader.ToTable(true, "ServiceCall");
                        foreach (DataRow Dr in oDTDistinct.Rows)
                        {
                            ServiceCall(Dr[0].ToString());
                            // oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                        }

                        Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                        Grid0.DataTable.Clear();

                        // update Billed Meter reading


                        //rsBill = null;
                    }

                }
                else
                {
                    Application.SBO_Application.MessageBox("Select the Service Call to post Invoice ", 1, "Ok");

                }

            }
            else
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    //Post Invoice Lease
                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = Grid0.DataTable.GetValue("U_CustomerCode", iloop).ToString();
                    itemCode = Grid0.DataTable.GetValue("ItemCode", iloop).ToString();
                    oInv.CardName = Grid0.DataTable.GetValue("U_CustomerName", iloop).ToString();

                    oInv.Lines.SetCurrentLine(0);
                    oInv.Lines.ItemCode = itemCode;
                    /// oInv.Lines.ItemDescription = Grid0.DataTable.GetValue("Descp", iloop).ToString();
                    oInv.Lines.UnitPrice = Convert.ToDouble(Grid0.DataTable.GetValue("Price", iloop).ToString());
                    oInv.Lines.Quantity = Convert.ToDouble(Grid0.DataTable.GetValue("Used", iloop).ToString());
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    oInv.Lines.Add();

                    if (oInv.Add() == 0)
                    {
                        isposted = true;
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }
                if (isposted)
                {
                    Grid0.DataTable.Clear();
                }
            }

        }


        private void ServiceCall(string callID)
        {
            String CardCode = string.Empty;

            SAPbobsCOM.ServiceCalls servicecalls = null;
            servicecalls = (SAPbobsCOM.ServiceCalls)(B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oServiceCalls));

            if (servicecalls.GetByKey(Convert.ToInt32(callID)))
            {
                servicecalls.Resolution = "Invoice Done";
                servicecalls.Status = -1;
                servicecalls.Update();

            }


        }
        private void PostArRDocumentSMA(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billdate = "";
            string itemCode = "";
            int interval = 0;
            string BillWizdate = "";
            string sBillingType = string.Empty;
            var lstdt = new List<DataTable>();
            SAPbobsCOM.BusinessPartners ocrd = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            SAPbobsCOM.Items oItem = (SAPbobsCOM.Items)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

            SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); string BillType = "";
            if (cmbBillingType.Value != string.Empty)
            {
                //Fixed Billing Calculation
                BillType = cmbBillingType.Value;
            }
            if (billgenType == "1")
            {
                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();

                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();
                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    interval = oDVInvoiceHeader.Count;
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        //DateTime dt = new DateTime();
                        //DateTime dt1 = new DateTime();
                        //dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        //dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString()))));
                        //Billdate = dt.ToString("yyyyMMdd");
                        //string nextdate = dt1.ToString("yyyyMMdd");
                        oInv.Lines.ItemCode = itemCode;
                        DateTime dt = new DateTime();
                        DateTime dt1 = new DateTime();
                        DateTime dt2 = new DateTime();
                        DateTime dt3 = new DateTime();
                        //  dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                        dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate
                        dt3 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        sBillingType = "Fixed Billing";
                        if (sBillingType == "Fixed Billing" && odrv["BillingProcessType"].ToString().Trim() == "A")
                        {
                            if (dt == dt3)
                            {
                                dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                                dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                                dt1 = dt3.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                        }

                        else
                        {
                            dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                            dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        }
                        Billdate = dt.ToString("yyyyMMdd");
                        BillWizdate = dt2.ToString("yyyyMMdd");
                        string nextdate = dt1.ToString("yyyyMMdd");
                        string nextdateF = dt1.AddDays(-1).ToString("yyyyMMdd");//Fixed Todate
                        //if (cmbBillingType.Value == "B")
                        //{
                        //    oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //    oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdateF, "yyyyMMdd", null);
                        //}
                        //else
                        //{
                        //    oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //    //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);
                        //    oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillWizdate, "yyyyMMdd", null);
                        //}

                          oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                           oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdateF, "yyyyMMdd", null);
                        

                        oInv.Lines.Quantity = 1;
                        oInv.Lines.UnitPrice = Convert.ToDouble(odrv["SMA Price"].ToString().Trim()) / interval;
                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                        if (odrv["BillingProcessType"].ToString().Trim() == "A")
                        { oInv.Lines.AccountCode = Globals.Advance; }
                        else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                        { oInv.Lines.AccountCode = Globals.Credit; }
                        oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = "S";
                        //oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);

                        oInv.Lines.Add();

                    }


                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        isposted = true;
                        UpdateNextBillDateforContracts(ContractID, "B");
                        isposted = true;
                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }
            }
            else
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    //Post Invoice Lease
                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = Grid0.DataTable.GetValue("U_CustomerCode", iloop).ToString();
                    itemCode = Grid0.DataTable.GetValue("ItemCode", iloop).ToString();
                    oInv.CardName = Grid0.DataTable.GetValue("U_CustomerName", iloop).ToString();

                    oInv.Lines.SetCurrentLine(0);
                    oInv.Lines.ItemCode = itemCode;
                    /// oInv.Lines.ItemDescription = Grid0.DataTable.GetValue("Descp", iloop).ToString();
                    oInv.Lines.UnitPrice = Convert.ToDouble(Grid0.DataTable.GetValue("Price", iloop).ToString());
                    oInv.Lines.Quantity = Convert.ToDouble(Grid0.DataTable.GetValue("Used", iloop).ToString());
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    oInv.Lines.Add();

                    if (oInv.Add() == 0)
                    {
                        isposted = true;
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }
                if (isposted)
                {
                    Grid0.DataTable.Clear();
                }
            }


        }

        private void PostArRDocumentSMABoth(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billdate = "";
            string itemCode = "";
            int interval = 0;
            string LBillDate = "";
            string LContractId = "";
            string BillTodate = "";

            string BillWizdate = "";
            var lstdt = new List<DataTable>();
            SAPbobsCOM.BusinessPartners ocrd = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            SAPbobsCOM.Items oItem = (SAPbobsCOM.Items)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

            SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); string BillType = "";
            if (cmbBillingType.Value != string.Empty)
            {
                //Fixed Billing Calculation
                BillType = cmbBillingType.Value;
            }
            if (billgenType == "3")
            {
                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();
                DataTable oDTDistinct1 = new DataTable();

                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                DataView oDVInvoiceHeader1 = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                oDTDistinct1 = oDVInvoiceHeader1.ToTable(true, "LContractID");

                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();
                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    interval = oDVInvoiceHeader.Count;
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        DateTime dt = new DateTime();
                        DateTime dt1 = new DateTime();
                        DateTime dt5 = new DateTime();
                        DateTime dt2 = new DateTime();
                        dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim());

                        dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString()))));
                        Billdate = dt.ToString("yyyyMMdd");
                        string nextdate = dt1.ToString("yyyyMMdd");
                        oInv.Lines.ItemCode = itemCode;
                        oInv.Lines.Quantity = 1;
                        oInv.Lines.UnitPrice = Convert.ToDouble(odrv["SMA Price"].ToString().Trim()) / interval;
                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                        if (odrv["BillingProcessType"].ToString().Trim() == "A")
                        { oInv.Lines.AccountCode = Globals.Advance; }
                        else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                        { oInv.Lines.AccountCode = Globals.Credit; }
                        oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = "S";
                        oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);

                        dt5 = Convert.ToDateTime(odrv["LBill Date"].ToString().Trim());
                        String Cycle = odrv["LBillingCycle"].ToString().Trim();
                        BillWizdate = dt2.ToString("yyyyMMdd");

                        if (odrv["Billing Type"].ToString().Trim() == "Lease Billing")
                        {
                            string LItemCode = Convert.ToString(odrv["LItemCode"].ToString().Trim());
                            oInv.Lines.ItemCode = LItemCode;
                            //oInv.Lines.Price = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                            oInv.Lines.Quantity = 1;
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                            LContractId = Convert.ToString(odrv["LContractID"].ToString().Trim());

                            LBillDate = dt5.ToString("yyyyMMdd");
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(LBillDate, "yyyyMMdd", null);
                            if (Cycle == "M")
                            {
                                BillTodate = dt5.AddMonths(1).ToString("yyyyMMdd");
                                oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                            }
                            else
                            {
                                BillTodate = dt5.AddMonths(3).ToString("yyyyMMdd");
                                oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                            }


                            oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = "B";
                        }


                        oInv.Lines.Add();

                    }


                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        isposted = true;
                        UpdateNextBillDateforContracts(ContractID, "B");
                        UpdateLineStatusLeaseContracts(LContractId, BillWizdate);
                        isposted = true;
                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }
            }
            else
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    //Post Invoice Lease
                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = Grid0.DataTable.GetValue("U_CustomerCode", iloop).ToString();
                    itemCode = Grid0.DataTable.GetValue("ItemCode", iloop).ToString();
                    oInv.CardName = Grid0.DataTable.GetValue("U_CustomerName", iloop).ToString();

                    oInv.Lines.SetCurrentLine(0);
                    oInv.Lines.ItemCode = itemCode;
                    /// oInv.Lines.ItemDescription = Grid0.DataTable.GetValue("Descp", iloop).ToString();
                    oInv.Lines.UnitPrice = Convert.ToDouble(Grid0.DataTable.GetValue("Price", iloop).ToString());
                    oInv.Lines.Quantity = Convert.ToDouble(Grid0.DataTable.GetValue("Used", iloop).ToString());
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    oInv.Lines.Add();

                    if (oInv.Add() == 0)
                    {
                        isposted = true;
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }
                if (isposted)
                {
                    Grid0.DataTable.Clear();
                }
            }


        }
        private void PostArRDocument(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billmeterreading = "";
            string lastReadingMeter = "";
            string SerialNum = "";
            string Billdate = "";
            string BillWizdate = "";
            string BillTodate = "";
            string LBillDate = "";
            string itemCode = "";
            double ceil = 0;
            string sBillingType = string.Empty;
            var lstdt = new List<DataTable>();
            SAPbobsCOM.BusinessPartners ocrd = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            SAPbobsCOM.Items oItem = (SAPbobsCOM.Items)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
            SAPbobsCOM.Recordset rsAcc = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); string BillType = "";

            string HeaderDate = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("tbBillDt").Specific).Value;

            if (cmbBillingType.Value != string.Empty)
            {
                //Fixed Billing Calculation
                BillType = cmbBillingType.Value;
            }
            if (billgenType == "1")
            {
                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();
                string query = "";
                //double ceil1 = 0;
                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();
                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        //Billmeterreading = odrv["Currenct Meter Reading"].ToString().Trim();
                        if (cmbBillingType.Value == "E")
                        {
                            Billmeterreading = odrv["U_LastReading"].ToString().Trim();
                            lastReadingMeter = odrv["Currenct Meter Reading"].ToString().Trim();
                        }
                        if (cmbBillingType.Value == "C")
                        {
                            Billmeterreading = odrv["U_LastReading"].ToString().Trim();
                            lastReadingMeter = odrv["Currenct Meter Reading"].ToString().Trim();
                        }

                        ceil = Convert.ToDouble(odrv["Cycle"].ToString().Trim()) * Convert.ToDouble(odrv["Ceil"].ToString().Trim());
                        SerialNum = odrv["Serial No"].ToString().Trim();
                        // sBillingType = sBillingType = odrv["Billing Type"].ToString().Trim();
                        DateTime dt = new DateTime();
                        DateTime dt1 = new DateTime();
                        DateTime dt2 = new DateTime();
                        DateTime dt3 = new DateTime();
                        //  dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                        dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate

                        dt3 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        if (sBillingType == "Fixed Billing" && odrv["BillingProcessType"].ToString().Trim() == "A")
                        {
                            if (dt == dt3)
                            {
                                dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                                dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                                dt1 = dt3.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                        }

                        else
                        {
                            dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                            dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        }
                        Billdate = dt.ToString("yyyyMMdd");
                        BillWizdate = dt2.ToString("yyyyMMdd");
                        string nextdate = dt1.ToString("yyyyMMdd");
                        string nextdateF = dt1.AddDays(-1).ToString("yyyyMMdd");//Fixed Todate
                        oInv.Lines.ItemCode = itemCode;
                        if (cmbBillingType.Value == "B")
                        {
                            if (odrv["IsFixedPrice"].ToString().Trim() == "Y")
                            {
                                oInv.Lines.Price = Convert.ToDouble(odrv["FixedPrice"].ToString().Trim());
                            }
                            else
                            {
                                oInv.Lines.Quantity = Convert.ToDouble(odrv["Free Copied"].ToString().Trim());
                                oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Price"].ToString().Trim());
                                //   oInv.Lines.LineTotal = Convert.ToDouble(Grid0.DataTable.GetValue("TotalPrice", iloop).ToString());
                            }
                            if (odrv["BillingProcessType"].ToString().Trim() == "A")
                            { oInv.Lines.AccountCode = Globals.Advance; }
                            else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                            { oInv.Lines.AccountCode = Globals.Credit; }
                        }
                        else
                        {
                            oInv.Lines.Quantity = Convert.ToDouble(odrv["Excess"].ToString().Trim());
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Excess Price"].ToString().Trim());
                            if (odrv["BillingProcessType"].ToString().Trim() == "A")
                            { oInv.Lines.AccountCode = Globals.Advance; }
                            else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                            { oInv.Lines.AccountCode = Globals.Credit; }
                            oInv.Lines.UserFields.Fields.Item("U_CurrentMeter").Value = odrv["Currenct Meter Reading"].ToString().Trim();
                            oInv.Lines.UserFields.Fields.Item("U_LastCallMeter").Value = odrv["Last Billed Meter Reading"].ToString().Trim();

                            oInv.Lines.UserFields.Fields.Item("U_UsedMeter").Value = odrv["Used"].ToString().Trim();
                        }
                        // DateTime.ParseExact(stDate, "yyyyMMdd", null);


                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                        oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = BillType;
                        //oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);

                        if (cmbBillingType.Value == "B")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdateF, "yyyyMMdd", null);
                        }
                        else
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillWizdate, "yyyyMMdd", null);
                        }

                        oInv.Lines.UserFields.Fields.Item("U_PoolCode").Value = odrv["PoolCode"].ToString().Trim();


                        if (cmbBillingType.Value == "E")
                        {
                            // string query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('"+ lastReadingMeter  +"') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                            //string query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                            query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                            //rsBill.DoQuery(query);

                        }
                        oInv.Lines.Add();
                    }

                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        isposted = true;
                        if (cmbBillOption.Value == "1")
                            UpdateNextBillDateforContracts(ContractID, BillType, ceil);
                        isposted = true;
                        string[] words = query.Split(';');
                        foreach (string word in words)
                        {
                            if (word.Trim().Length > 0)
                                rsBill.DoQuery(word);
                        }
                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }
            }
            else if (billgenType == "2")//Lease
            {

                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();


                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["CustomerCode"].ToString();
                    //oInv.DocDate = Convert.ToDateTime(oDVInvoiceHeader[0]["Bill Date"].ToString().Trim());
                    //oInv.DocDueDate = Convert.ToDateTime(oDVInvoiceHeader[0]["Bill Date"].ToString().Trim()); ;
                    //oInv.TaxDate = Convert.ToDateTime(oDVInvoiceHeader[0]["Bill Date"].ToString().Trim()); ;

                    string BillDate = Convert.ToDateTime(oDVInvoiceHeader[0]["Bill Date"].ToString().Trim()).ToShortDateString();
                    DateTime BillDates = DateTime.Parse(BillDate);
                    BillDate = BillDates.ToString("yyyyMMdd");

                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {

                        DateTime dt = new DateTime();
                        DateTime dt2 = new DateTime();
                        dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate
                        BillWizdate = dt2.ToString("yyyyMMdd");

                        String Cycle = odrv["LBillingCycle"].ToString().Trim();
                        //Convert.ToDouble(odrv["ItemCode"].ToString().Trim());
                        itemCode = Convert.ToString(odrv["ItemCode"].ToString().Trim());

                        oInv.Lines.ItemCode = itemCode;
                        //oInv.Lines.Price = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                        oInv.Lines.Quantity = 1;
                        oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                        //oInv.UserFields.Fields.Item("U_InvoiceType").Value = "Lease Billing";

                        oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(BillDate, "yyyyMMdd", null);
                        if (Cycle == "M")
                        {
                            BillTodate = dt.AddMonths(1).ToString("yyyyMMdd");
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                        }
                        else
                        {
                            BillTodate = dt.AddMonths(3).ToString("yyyyMMdd");
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                        }

                        oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = "B";

                        oInv.Lines.Add();
                    }

                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        isposted = true;
                        if (cmbBillOption.Value == "2")
                            UpdateLineStatusLeaseContracts(ContractID, BillWizdate);
                        isposted = true;
                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }

            }

            else if (billgenType == "3")//Both
            {


                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();
                DataTable oDTDistinct1 = new DataTable();
                string LContractId = "";
                string query = "";
                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    string BillDate1 = Convert.ToDateTime(oDVInvoiceHeader[0]["LBill Date"].ToString().Trim()).ToShortDateString();
                    DateTime BillDates = DateTime.Parse(BillDate1);
                    BillDate1 = BillDates.ToString("yyyyMMdd");
                    //foreach (DataRow Dr1 in oDTDistinct1.Rows)
                    //{
                    //    oDVInvoiceHeader.RowFilter = "LContractID='" + Dr1[0].ToString() + "'";
                    //    LContractId = oDTDistinct1.Rows[0][0].ToString();
                    //}
                    // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();
                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        //Billmeterreading = odrv["Currenct Meter Reading"].ToString().Trim();
                        if (cmbBillingType.Value == "E")
                        {
                            Billmeterreading = odrv["U_LastReading"].ToString().Trim();
                            lastReadingMeter = odrv["Currenct Meter Reading"].ToString().Trim();
                        }
                        if (cmbBillingType.Value == "C")
                        {
                            Billmeterreading = odrv["U_LastReading"].ToString().Trim();
                            lastReadingMeter = odrv["Currenct Meter Reading"].ToString().Trim();
                        }

                        ceil = Convert.ToDouble(odrv["Cycle"].ToString().Trim()) * Convert.ToDouble(odrv["Ceil"].ToString().Trim());
                        SerialNum = odrv["Serial No"].ToString().Trim();
                        // sBillingType = sBillingType = odrv["Billing Type"].ToString().Trim();
                        DateTime dt = new DateTime();
                        DateTime dt1 = new DateTime();
                        DateTime dt2 = new DateTime();
                        DateTime dt3 = new DateTime();
                        DateTime dt4 = new DateTime();

                        //  dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                        dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate

                        dt3 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        if (sBillingType == "Fixed Billing" && odrv["BillingProcessType"].ToString().Trim() == "A")
                        {
                            if (dt == dt3)
                            {
                                dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                                dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                                dt1 = dt3.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                        }

                        else
                        {
                            dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                            dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        }


                        dt4 = Convert.ToDateTime(odrv["LBill Date"].ToString().Trim());
                        String Cycle = odrv["LBillingCycle"].ToString().Trim();

                        Billdate = dt.ToString("yyyyMMdd");
                        BillWizdate = dt2.ToString("yyyyMMdd");
                        string nextdate = dt1.ToString("yyyyMMdd");
                        string nextdateF = dt1.AddDays(-1).ToString("yyyyMMdd");//Fixed Todate

                        oInv.Lines.ItemCode = itemCode;

                        if (cmbBillingType.Value == "B")
                        {
                            if (odrv["IsFixedPrice"].ToString().Trim() == "Y")
                            {
                                oInv.Lines.Price = Convert.ToDouble(odrv["FixedPrice"].ToString().Trim());
                            }
                            else
                            {
                                oInv.Lines.Quantity = Convert.ToDouble(odrv["Free Copied"].ToString().Trim());
                                oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Price"].ToString().Trim());
                                //   oInv.Lines.LineTotal = Convert.ToDouble(Grid0.DataTable.GetValue("TotalPrice", iloop).ToString());
                            }
                            if (odrv["BillingProcessType"].ToString().Trim() == "A")
                            { oInv.Lines.AccountCode = Globals.Advance; }
                            else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                            { oInv.Lines.AccountCode = Globals.Credit; }
                        }
                        else
                        {
                            oInv.Lines.Quantity = Convert.ToDouble(odrv["Excess"].ToString().Trim());
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Excess Price"].ToString().Trim());
                            if (odrv["BillingProcessType"].ToString().Trim() == "A")
                            { oInv.Lines.AccountCode = Globals.Advance; }
                            else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                            { oInv.Lines.AccountCode = Globals.Credit; }
                            oInv.Lines.UserFields.Fields.Item("U_CurrentMeter").Value = odrv["Currenct Meter Reading"].ToString().Trim();
                            oInv.Lines.UserFields.Fields.Item("U_LastCallMeter").Value = odrv["Last Billed Meter Reading"].ToString().Trim();

                            oInv.Lines.UserFields.Fields.Item("U_UsedMeter").Value = odrv["Used"].ToString().Trim();
                        }
                        // DateTime.ParseExact(stDate, "yyyyMMdd", null);


                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                        if (sBillingType == "Fixed Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = BillType;
                        }
                        else if (sBillingType == "Excess Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = BillType;
                        }

                        //oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);

                        if (cmbBillingType.Value == "B")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdateF, "yyyyMMdd", null);
                        }
                        else
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillWizdate, "yyyyMMdd", null);
                        }

                        oInv.Lines.UserFields.Fields.Item("U_PoolCode").Value = odrv["PoolCode"].ToString().Trim();
                        oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = BillType;
                        if (cmbBillingType.Value == "B")
                        {

                            if (odrv["Billing Type"].ToString().Trim() == "Lease Billing")
                            {
                                string LItemCode = Convert.ToString(odrv["LItemCode"].ToString().Trim());
                                oInv.Lines.ItemCode = LItemCode;
                                //oInv.Lines.Price = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                                oInv.Lines.Quantity = 1;
                                oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                                LContractId = Convert.ToString(odrv["LContractID"].ToString().Trim());
                                //oInv.UserFields.Fields.Item("U_InvoiceType").Value = "Lease Billing";

                                LBillDate = dt4.ToString("yyyyMMdd");
                                oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(LBillDate, "yyyyMMdd", null);
                                if (Cycle == "M")
                                {
                                    BillTodate = dt4.AddMonths(1).ToString("yyyyMMdd");
                                    oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                                }
                                else
                                {
                                    BillTodate = dt4.AddMonths(3).ToString("yyyyMMdd");
                                    oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                                }

                                oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = BillType;

                            }
                        }

                        if (cmbBillingType.Value == "E")
                        {
                            // string query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                            //string query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                            query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                            // rsBill.DoQuery(query);

                        }
                        oInv.Lines.Add();
                    }

                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        isposted = true;
                        //if (cmbBillOption.Value == "3")

                        UpdateNextBillDateforContracts(ContractID);
                        UpdateLineStatusLeaseContracts(LContractId, BillWizdate);
                        //UpdateLineStatusLeaseContracts(LContractId, BillWizdate);

                        string[] words = query.Split(';');
                        foreach (string word in words)
                        {
                            if (word.Trim().Length > 0)
                                rsBill.DoQuery(word);
                        }

                        isposted = true;
                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }



            }

        }

        private void PostArRDocumentBoth(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billmeterreading = "";
            string lastReadingMeter = "";
            string SerialNum = "";
            string Billdate = "";
            string BillWizdate = "";
            string itemCode = "";
            string sBillingType = string.Empty;

            int billingcycle = 0;
            var lstdt = new List<DataTable>();
            SAPbobsCOM.BusinessPartners ocrd = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            SAPbobsCOM.Items oItem = (SAPbobsCOM.Items)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

            SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); string BillType = "";
            string HeaderDate = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("tbBillDt").Specific).Value;
            if (cmbBillingType.Value != string.Empty)
            {
                //Fixed Billing Calculation
                BillType = cmbBillingType.Value;
            }
            if (billgenType == "1")
            {
                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();

                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    string query = "";
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();
                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        Billmeterreading = odrv["U_LastReading"].ToString().Trim();
                        lastReadingMeter = odrv["Currenct Meter Reading"].ToString().Trim();
                        SerialNum = odrv["Serial No"].ToString().Trim();
                        sBillingType = sBillingType = odrv["Billing Type"].ToString().Trim();
                        billingcycle = Convert.ToInt32(odrv["BillingCycle"].ToString().Trim());
                        DateTime dt = new DateTime();
                        DateTime dt1 = new DateTime();
                        DateTime dt2 = new DateTime();
                        DateTime dt3 = new DateTime();
                        //dt3 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                        //dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        //dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate
                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate
                        dt3 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        if (sBillingType == "Fixed Billing" && odrv["BillingProcessType"].ToString().Trim() == "A")
                        {
                            if (dt == dt3)
                            {
                                dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                                dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                                dt1 = dt3.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                        }

                        else
                        {
                            dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                            dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        }

                        Billdate = dt.ToString("yyyyMMdd");
                        BillWizdate = dt2.ToString("yyyyMMdd");
                        string nextdate = dt1.ToString("yyyyMMdd");
                        string nextdateF = dt1.AddDays(-1).ToString("yyyyMMdd");//Fixed Todate

                        oInv.Lines.ItemCode = itemCode;

                        if (sBillingType == "Fixed Billing")
                        {
                            if (odrv["IsFixedPrice"].ToString().Trim() == "Y")
                            {
                                oInv.Lines.Price = Convert.ToDouble(odrv["U_Price"].ToString().Trim());
                            }
                            else
                            {
                                oInv.Lines.Quantity = Convert.ToDouble(odrv["Free Copied"].ToString().Trim());
                                oInv.Lines.UnitPrice = Convert.ToDouble(odrv["U_Price"].ToString().Trim());
                            }
                            // query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                        }
                        else
                        {
                            oInv.Lines.Quantity = Convert.ToDouble(odrv["Excess"].ToString().Trim());
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["U_ExcessPrice"].ToString().Trim());
                            //query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "')  where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                            query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                        }

                        if (odrv["BillingProcessType"].ToString().Trim() == "A")
                        { oInv.Lines.AccountCode = Globals.Advance; }
                        else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                        { oInv.Lines.AccountCode = Globals.Credit; }
                        sBillingType = odrv["Billing Type"].ToString();
                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                        oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = sBillingType == "Fixed Billing" ? "B" : "E";

                        //oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);

                        if (sBillingType == "Fixed Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdateF, "yyyyMMdd", null);
                        }
                        else
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillWizdate, "yyyyMMdd", null);
                        }

                        if (sBillingType != "Fixed Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_CurrentMeter").Value = odrv["Currenct Meter Reading"].ToString().Trim();
                            oInv.Lines.UserFields.Fields.Item("U_LastCallMeter").Value = odrv["Last Billed Meter Reading"].ToString().Trim();
                        }
                        oInv.Lines.UserFields.Fields.Item("U_PoolCode").Value = odrv["PoolCode"].ToString().Trim();
                        oInv.Lines.UserFields.Fields.Item("U_UsedMeter").Value = odrv["Used"].ToString().Trim();

                        oInv.Lines.Add();
                    }


                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        oDTDistinct = oDVInvoiceHeader.ToTable(true, "Billing Type", "Cycle", "Ceil");
                        foreach (DataRow odrv in oDTDistinct.Rows)
                        {
                            sBillingType = sBillingType = odrv["Billing Type"].ToString();
                            double nextdate = Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString());
                            UpdateNextBillDateforContracts(ContractID, sBillingType == "Fixed Billing" ? "B" : "E", nextdate);
                        }

                        //  UpdateNextBillDateforContracts(ContractID, sBillingType == "Fixed Billing" ? "B" : "E", billingcycle);
                        isposted = true;
                        string[] words = query.Split(';');
                        foreach (string word in words)
                        {
                            if (word.Trim().Length > 0)
                                rsBill.DoQuery(word);
                        }

                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }
            }
            else
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    //Post Invoice Lease
                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = Grid0.DataTable.GetValue("U_CustomerCode", iloop).ToString();
                    itemCode = Grid0.DataTable.GetValue("ItemCode", iloop).ToString();
                    oInv.CardName = Grid0.DataTable.GetValue("U_CustomerName", iloop).ToString();

                    oInv.Lines.SetCurrentLine(0);
                    oInv.Lines.ItemCode = itemCode;
                    /// oInv.Lines.ItemDescription = Grid0.DataTable.GetValue("Descp", iloop).ToString();
                    oInv.Lines.UnitPrice = Convert.ToDouble(Grid0.DataTable.GetValue("Price", iloop).ToString());
                    oInv.Lines.Quantity = Convert.ToDouble(Grid0.DataTable.GetValue("Used", iloop).ToString());
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    oInv.Lines.Add();

                    if (oInv.Add() == 0)
                    {
                        isposted = true;
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }
                if (isposted)
                {
                    Grid0.DataTable.Clear();
                }
            }


        }



        private void PostArRDocumentAll(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billmeterreading = "";
            string lastReadingMeter = "";
            string SerialNum = "";
            string Billdate = "";
            string BillWizdate = "";
            string BillTodate = "";
            string LBillDate = "";

            string itemCode = "";
            string sBillingType = string.Empty;
            string BillDate1 = "";
            int billingcycle = 0;
            var lstdt = new List<DataTable>();
            SAPbobsCOM.BusinessPartners ocrd = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            SAPbobsCOM.Items oItem = (SAPbobsCOM.Items)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

            SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); string BillType = "";
            string HeaderDate = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("tbBillDt").Specific).Value;
            if (cmbBillingType.Value != string.Empty)
            {
                //Fixed Billing Calculation
                BillType = cmbBillingType.Value;
            }
            if (billgenType == "3")//Both
            {
                rsBill.DoQuery(sQuery);
                DataTable oDT = new DataTable();
                DataTable oDTDistinct = new DataTable();
                DataTable oDTDistinct1 = new DataTable();
                string LContractId = "";
                oDT = ConvertRecordset(rsBill);
                DataView oDVInvoiceHeader = new DataView(oDT);
                DataView oDVInvoiceHeader1 = new DataView(oDT);
                oDTDistinct = oDVInvoiceHeader.ToTable(true, "ContractID");
                oDTDistinct1 = oDVInvoiceHeader1.ToTable(true, "LContractID");

                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    string query = "";
                    oDVInvoiceHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    BillDate1 = Convert.ToDateTime(oDVInvoiceHeader[0]["LBill Date"].ToString().Trim()).ToShortDateString();
                    DateTime BillDates = DateTime.Parse(BillDate1);
                    BillDate1 = BillDates.ToString("yyyyMMdd");

                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = oDVInvoiceHeader[0]["Customer Code"].ToString(); //Grid0.DataTable.GetValue("CstmrCode", iloop).ToString();
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    // oInv.CardName = Grid0.DataTable.GetValue("CstmrName", iloop).ToString();

                    //foreach (DataRow Dr1 in oDTDistinct1.Rows)
                    //{
                    //    oDVInvoiceHeader1.RowFilter = "LContractID='" + Dr1[0].ToString() + "'";
                    //    LContractId = oDTDistinct1.Rows[0][0].ToString();
                    //}
                    Application.SBO_Application.SetStatusBarMessage("Generating Invoice for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        Billmeterreading = odrv["U_LastReading"].ToString().Trim();
                        lastReadingMeter = odrv["Currenct Meter Reading"].ToString().Trim();
                        SerialNum = odrv["Serial No"].ToString().Trim();
                        sBillingType = sBillingType = odrv["Billing Type"].ToString().Trim();
                        if (sBillingType == "Lease Billing")
                        { }
                        else
                        {
                            billingcycle = Convert.ToInt32(odrv["BillingCycle"].ToString().Trim());
                        }
                        DateTime dt = new DateTime();
                        DateTime dt1 = new DateTime();
                        DateTime dt2 = new DateTime();
                        DateTime dt3 = new DateTime();
                        DateTime dt4 = new DateTime();
                        DateTime dt5 = new DateTime();

                        // dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());

                        dt2 = Convert.ToDateTime(odrv["BillWizDate"].ToString().Trim()); //Excess ToDate
                        dt3 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());

                        if (sBillingType == "Fixed Billing" && odrv["BillingProcessType"].ToString().Trim() == "A")
                        {
                            if (dt == dt3)
                            {
                                dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                                dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                                dt1 = dt3.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                        }

                        else
                        {
                            dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                            dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        }


                        dt4 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        if (sBillingType == "Fixed Billing" && odrv["BillingProcessType"].ToString().Trim() == "A")
                        {
                            if (dt == dt2)
                            {
                                dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                                dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                                dt1 = dt4.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                            }
                        }

                        else
                        {
                            dt = Convert.ToDateTime(odrv["U_LastBilledDate"].ToString().Trim());
                            dt1 = dt.AddMonths(Convert.ToInt32(Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString())));
                        }


                        String Cycle = odrv["LBillingCycle"].ToString().Trim();
                        dt5 = Convert.ToDateTime(odrv["LBill Date"].ToString().Trim());

                        Billdate = dt.ToString("yyyyMMdd");
                        BillWizdate = dt2.ToString("yyyyMMdd");
                        string nextdate = dt1.ToString("yyyyMMdd");
                        string nextdateF = dt1.AddDays(-1).ToString("yyyyMMdd");//Fixed Todate

                        oInv.Lines.ItemCode = itemCode;

                        if (sBillingType == "Fixed Billing")
                        {
                            if (odrv["IsFixedPrice"].ToString().Trim() == "Y")
                            {
                                oInv.Lines.Price = Convert.ToDouble(odrv["U_Price"].ToString().Trim());
                            }
                            else
                            {
                                oInv.Lines.Quantity = Convert.ToDouble(odrv["Free Copied"].ToString().Trim());
                                oInv.Lines.UnitPrice = Convert.ToDouble(odrv["U_Price"].ToString().Trim());
                            }
                        }
                        else if (sBillingType == "Excess Billing")
                        {
                            oInv.Lines.Quantity = Convert.ToDouble(odrv["Excess"].ToString().Trim());
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["U_ExcessPrice"].ToString().Trim());
                            // query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "')  where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                            //query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                            query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "') , \"U_LastReading\" = to_integer('" + lastReadingMeter + "') where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                        }

                        if (odrv["BillingProcessType"].ToString().Trim() == "A")
                        { oInv.Lines.AccountCode = Globals.Advance; }
                        else if (odrv["BillingProcessType"].ToString().Trim() == "C")
                        { oInv.Lines.AccountCode = Globals.Credit; }
                        sBillingType = odrv["Billing Type"].ToString();
                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                        if (sBillingType == "Fixed Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = sBillingType == "Fixed Billing" ? "B" : "E";
                        }
                        else if (sBillingType == "Excess Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = sBillingType == "Fixed Billing" ? "B" : "E";
                        }
                        //oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                        //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);

                        if (sBillingType == "Fixed Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdateF, "yyyyMMdd", null);
                        }
                        else if (sBillingType == "Excess Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(Billdate, "yyyyMMdd", null);
                            //oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(nextdate, "yyyyMMdd", null);
                            oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillWizdate, "yyyyMMdd", null);
                        }

                        if (sBillingType != "Fixed Billing")
                        {
                            oInv.Lines.UserFields.Fields.Item("U_CurrentMeter").Value = odrv["Currenct Meter Reading"].ToString().Trim();
                            oInv.Lines.UserFields.Fields.Item("U_LastCallMeter").Value = odrv["Last Billed Meter Reading"].ToString().Trim();
                        }
                        oInv.Lines.UserFields.Fields.Item("U_PoolCode").Value = odrv["PoolCode"].ToString().Trim();
                        oInv.Lines.UserFields.Fields.Item("U_UsedMeter").Value = odrv["Used"].ToString().Trim();

                        if (odrv["Billing Type"].ToString().Trim() == "Lease Billing")
                        {
                            string LItemCode = Convert.ToString(odrv["LItemCode"].ToString().Trim());
                            oInv.Lines.ItemCode = LItemCode;
                            //oInv.Lines.Price = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                            oInv.Lines.Quantity = 1;
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Monthly Bill"].ToString().Trim());
                            LContractId = Convert.ToString(odrv["LContractID"].ToString().Trim());

                            LBillDate = dt4.ToString("yyyyMMdd");
                            oInv.Lines.UserFields.Fields.Item("U_FromDate").Value = DateTime.ParseExact(LBillDate, "yyyyMMdd", null);
                            if (Cycle == "M")
                            {
                                BillTodate = dt5.AddMonths(1).ToString("yyyyMMdd");
                                oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                            }
                            else
                            {
                                BillTodate = dt4.AddMonths(3).ToString("yyyyMMdd");
                                oInv.Lines.UserFields.Fields.Item("U_ToDate").Value = DateTime.ParseExact(BillTodate, "yyyyMMdd", null);
                            }


                            oInv.Lines.UserFields.Fields.Item("U_InvoiceType").Value = "B";
                        }



                        oInv.Lines.Add();
                    }


                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        oDTDistinct = oDVInvoiceHeader.ToTable(true, "Billing Type", "Cycle", "Ceil");
                        foreach (DataRow odrv in oDTDistinct.Rows)
                        {
                            sBillingType = sBillingType = odrv["Billing Type"].ToString();
                            double nextdate = Convert.ToDouble(odrv["Cycle"].ToString()) * Convert.ToDouble(odrv["Ceil"].ToString());
                            UpdateNextBillDateforContracts(ContractID, sBillingType == "Fixed Billing" ? "B" : "E", nextdate);
                        }
                        //UpdateLineStatusLeaseContracts(LContractId, BillDate1);
                        UpdateLineStatusLeaseContracts(LContractId, BillWizdate);

                        //  UpdateNextBillDateforContracts(ContractID, sBillingType == "Fixed Billing" ? "B" : "E", billingcycle);
                        isposted = true;
                        string[] words = query.Split(';');
                        foreach (string word in words)
                        {
                            if (word.Trim().Length > 0)
                                rsBill.DoQuery(word);
                        }

                        Application.SBO_Application.SetStatusBarMessage("Invoice generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }

                if (isposted)
                {
                    //updatemachineDetails();
                    //  Application.SBO_Application.SetStatusBarMessage("Invoices Posted Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    Application.SBO_Application.MessageBox("Invoices Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();

                    // update Billed Meter reading


                    rsBill = null;
                }
            }
            else
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    //Post Invoice Lease
                    SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    oInv.CardCode = Grid0.DataTable.GetValue("U_CustomerCode", iloop).ToString();
                    itemCode = Grid0.DataTable.GetValue("ItemCode", iloop).ToString();
                    oInv.CardName = Grid0.DataTable.GetValue("U_CustomerName", iloop).ToString();

                    oInv.Lines.SetCurrentLine(0);
                    oInv.Lines.ItemCode = itemCode;
                    /// oInv.Lines.ItemDescription = Grid0.DataTable.GetValue("Descp", iloop).ToString();
                    oInv.Lines.UnitPrice = Convert.ToDouble(Grid0.DataTable.GetValue("Price", iloop).ToString());
                    oInv.Lines.Quantity = Convert.ToDouble(Grid0.DataTable.GetValue("Used", iloop).ToString());
                    oInv.UserFields.Fields.Item("U_ContractID").Value = ContractID;
                    oInv.UserFields.Fields.Item("U_InvoiceType").Value = cmbBillingType.Value;
                    oInv.Lines.Add();

                    if (oInv.Add() == 0)
                    {
                        isposted = true;
                    }
                    else
                    {
                        isposted = false;
                        var message = B1Helper.DiCompany.GetLastErrorDescription();
                        Utility.LogErrors(message);
                    }

                }
                if (isposted)
                {
                    Grid0.DataTable.Clear();
                }
            }


        }
        private void PostDeliveryNotes(string billGenType)
        {
            if (billGenType == "S")
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {

                }
            }
            else
            {
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {

                }
            }
        }

        private void updatemachineDetails()
        {
            string code = "";
            string machineQry = "SELECT T0.\"Code\" FROM \"@Z_ECMD\"  T0,\"OCTR\" T1 WHERE  " +
                                             " T0.\"U_DocNum\" = T1.\"ContractID\"  and  T0.\"U_DocType\" ='Service Contract'" +
                                             " and (T0.\"U_DocNum\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_DocNum\" <='" + tbToServiceContract.Value + "') and  T0.\"U_Billed\" ='N' and T0.\"U_BillDate\" <= '" + tbBillDate.Value + "' ";


            SAPbobsCOM.UserTable oUserTable = (SAPbobsCOM.UserTable)B1Helper.DiCompany.UserTables.Item("Z_ECMD");
            SAPbobsCOM.Recordset rsEqMachine = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsEqMachine.DoQuery(machineQry);
            if (rsEqMachine.RecordCount > 0)
            {
                while (rsEqMachine.EoF == false)
                {
                    code = rsEqMachine.Fields.Item(0).Value.ToString();

                    if (oUserTable.GetByKey(code))
                    {
                        oUserTable.UserFields.Fields.Item("U_Billed").Value = "Y";
                    }

                    if (oUserTable.Update() == 0)
                    {

                    }
                }
            }

        }

        private void UpdateLineStatusLeaseContracts(string ContractID, string BillDate)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_OLCM");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;
                //DateTime BillDates = DateTime.ParseExact(BillDate.ToShortDateString(), "yyyyMMdd", null);
                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                //string query = "SELECT T0.\"Code\",T1.\"LineId\",T1.\"U_NextBilledDate\",T1.\"U_BillingCycle\" , \"EndDate\" FROM \"@Z_OSRB\"  T0 , \"@Z_SRB1\"  T1, \"OCTR\" T2    WHERE T0.\"Code\" = T1.\"Code\" and " +
                //     " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType.Value + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";

                string query = "select T0.\"Code\",T4.\"LineId\",T4.\"U_LBDate\",T4.\"U_Status\",T4.\"U_Posted\"  " +
                               "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                               "where T0.\"Code\" = '" + ContractID + "' and T4.\"U_LBDate\" <= '" + BillDate + "' and  T4.\"U_Status\" = 'Pending' ";
                rsBill.DoQuery(query);
                while (rsBill.EoF == false)
                {

                    if (rsBill.RecordCount > 0)
                    {
                        code = int.Parse(rsBill.Fields.Item(0).Value.ToString());
                        blnExist = true;
                    }

                    if (blnExist)
                    {
                        oGeneralParams.SetProperty("Code", code.ToString());
                        oGeneralData = oGeneralService.GetByParams(oGeneralParams);



                        SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string lineIdQry = query;
                        //'Child rows
                        oChildren = oGeneralData.Child("Z_LCLB");
                        rsLineId.DoQuery(lineIdQry);

                        if (rsLineId.RecordCount > 0)
                        {
                            int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                            oChild = oChildren.Item(lineId - 1);
                            String status = "Generated";
                            String Posted = "Yes";
                            oChild.SetProperty("U_Status", status);
                            oChild.SetProperty("U_Posted", Posted);
                            //oChild.SetProperty("U_IStatus", status);
                            oGeneralService.Update(oGeneralData);
                        }
                    }


                    rsBill.MoveNext();
                }
                rsBill = null;
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }


        private void UpdateNextBillDateforLContractsBoth(string ContractID)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_SRBI");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;

                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "SELECT T0.\"Code\",T1.\"LineId\",T1.\"U_NextBilledDate\",T1.\"U_BillingCycle\" , \"EndDate\" FROM \"@Z_OSRB\"  T0 , \"@Z_SRB1\"  T1, \"OCTR\" T2    WHERE T0.\"Code\" = T1.\"Code\" and " +
                     " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType.Value + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";

                rsBill.DoQuery(query);
                if (rsBill.RecordCount > 0)
                {
                    code = int.Parse(rsBill.Fields.Item(0).Value.ToString());
                    blnExist = true;
                }

                if (blnExist)
                {
                    oGeneralParams.SetProperty("Code", code.ToString());
                    oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                    oGeneralData.SetProperty("U_ContractNo", ContractID);

                    SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string lineIdQry = query;
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_SRB1");
                    rsLineId.DoQuery(lineIdQry);

                    if (rsLineId.RecordCount > 0)
                    {
                        int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                        oChild = oChildren.Item(lineId - 1);


                        int yyyy = 0, mm = 0, dd = 0;

                        string etDate = tbBillDate.Value;
                        if (etDate != string.Empty)
                        {
                            //yyyy = int.Parse(etDate.Substring(0, 4));
                            //mm = int.Parse(etDate.Substring(4, 2));
                            //dd = int.Parse(etDate.Substring(6, 2));
                            //DateTime dt_end = new DateTime(yyyy, mm, dd);
                            DateTime dt_end = DateTime.ParseExact(etDate, "yyyyMMdd", null);
                            oChild.SetProperty("U_LastBilledDate", dt_end);
                        }

                        string billCyType = string.Empty;

                        switch (rsLineId.Fields.Item("U_BillingCycle").Value.ToString())
                        {
                            case "12": // Monthly
                                billCyType = "1";
                                break;
                            case "4": //Quaterly
                                billCyType = "3";
                                break;
                            case "2"://Semi Annual
                                billCyType = "6";
                                break;
                            case "1": // Annual
                                billCyType = "12";
                                break;
                            default:
                                break;
                        }

                        string stDate = Convert.ToDateTime(rsLineId.Fields.Item("U_NextBilledDate").Value.ToString()).ToShortDateString();
                        DateTime st_Date = DateTime.Parse(stDate);
                        stDate = st_Date.ToString("yyyyMMdd");
                        //yyyy = int.Parse(stDate.Substring(0, 4));
                        //mm = int.Parse(stDate.Substring(4, 2));
                        //dd = int.Parse(stDate.Substring(6, 2));
                        //st_Date = new DateTime(yyyy, mm, dd);
                        st_Date = DateTime.ParseExact(stDate, "yyyyMMdd", null);


                        string CEDate = Convert.ToDateTime(rsLineId.Fields.Item("EndDate").Value.ToString()).ToShortDateString();
                        DateTime CE_Date = DateTime.Parse(CEDate);
                        CEDate = CE_Date.ToString("yyyyMMdd");
                        //yyyy = int.Parse(CEDate.Substring(0, 4));
                        //mm = int.Parse(CEDate.Substring(4, 2));
                        //dd = int.Parse(CEDate.Substring(6, 2));
                        //CE_Date = new DateTime(yyyy, mm, dd);
                        CE_Date = DateTime.ParseExact(CEDate, "yyyyMMdd", null);

                        DateTime nextBillDate = st_Date;
                        int addMonths = int.Parse(billCyType);
                        nextBillDate = nextBillDate.AddMonths(addMonths);
                        //ntDate = nextBillDate.AddMonths(addMonths + 1);
                        if (cmbBillingType.Value.Trim() == "E")
                        {
                            if (nextBillDate < CE_Date)
                            { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                            else { oChild.SetProperty("U_NextBilledDate", nextBillDate.AddDays(-1)); }
                        }
                        else { oChild.SetProperty("U_NextBilledDate", nextBillDate); }

                    }
                    oGeneralService.Update(oGeneralData);


                    rsBill = null;
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }


        private void UpdateNextBillDateforContracts(string ContractID)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_SRBI");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;

                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "SELECT T0.\"Code\",T1.\"LineId\",T1.\"U_NextBilledDate\",T1.\"U_BillingCycle\" , \"EndDate\" FROM \"@Z_OSRB\"  T0 , \"@Z_SRB1\"  T1, \"OCTR\" T2    WHERE T0.\"Code\" = T1.\"Code\" and " +
                     " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType.Value + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";

                rsBill.DoQuery(query);
                if (rsBill.RecordCount > 0)
                {
                    code = int.Parse(rsBill.Fields.Item(0).Value.ToString());
                    blnExist = true;
                }

                if (blnExist)
                {
                    oGeneralParams.SetProperty("Code", code.ToString());
                    oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                    oGeneralData.SetProperty("U_ContractNo", ContractID);

                    SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string lineIdQry = query;
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_SRB1");
                    rsLineId.DoQuery(lineIdQry);

                    if (rsLineId.RecordCount > 0)
                    {
                        int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                        oChild = oChildren.Item(lineId - 1);


                        int yyyy = 0, mm = 0, dd = 0;

                        string etDate = tbBillDate.Value;
                        if (etDate != string.Empty)
                        {
                            //yyyy = int.Parse(etDate.Substring(0, 4));
                            //mm = int.Parse(etDate.Substring(4, 2));
                            //dd = int.Parse(etDate.Substring(6, 2));
                            //DateTime dt_end = new DateTime(yyyy, mm, dd);
                            DateTime dt_end = DateTime.ParseExact(etDate, "yyyyMMdd", null);
                            oChild.SetProperty("U_LastBilledDate", dt_end);
                        }

                        string billCyType = string.Empty;

                        switch (rsLineId.Fields.Item("U_BillingCycle").Value.ToString())
                        {
                            case "12": // Monthly
                                billCyType = "1";
                                break;
                            case "4": //Quaterly
                                billCyType = "3";
                                break;
                            case "2"://Semi Annual
                                billCyType = "6";
                                break;
                            case "1": // Annual
                                billCyType = "12";
                                break;
                            default:
                                break;
                        }

                        string stDate = Convert.ToDateTime(rsLineId.Fields.Item("U_NextBilledDate").Value.ToString()).ToShortDateString();
                        DateTime st_Date = DateTime.Parse(stDate);
                        stDate = st_Date.ToString("yyyyMMdd");
                        //yyyy = int.Parse(stDate.Substring(0, 4));
                        //mm = int.Parse(stDate.Substring(4, 2));
                        //dd = int.Parse(stDate.Substring(6, 2));
                        //st_Date = new DateTime(yyyy, mm, dd);
                        st_Date = DateTime.ParseExact(stDate, "yyyyMMdd", null);


                        string CEDate = Convert.ToDateTime(rsLineId.Fields.Item("EndDate").Value.ToString()).ToShortDateString();
                        DateTime CE_Date = DateTime.Parse(CEDate);
                        CEDate = CE_Date.ToString("yyyyMMdd");
                        //yyyy = int.Parse(CEDate.Substring(0, 4));
                        //mm = int.Parse(CEDate.Substring(4, 2));
                        //dd = int.Parse(CEDate.Substring(6, 2));
                        //CE_Date = new DateTime(yyyy, mm, dd);
                        CE_Date = DateTime.ParseExact(CEDate, "yyyyMMdd", null);

                        DateTime nextBillDate = st_Date;
                        int addMonths = int.Parse(billCyType);
                        nextBillDate = nextBillDate.AddMonths(addMonths);
                        //ntDate = nextBillDate.AddMonths(addMonths + 1);
                        if (cmbBillingType.Value.Trim() == "E")
                        {
                            if (nextBillDate < CE_Date)
                            { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                            else { oChild.SetProperty("U_NextBilledDate", nextBillDate.AddDays(-1)); }
                        }
                        else { oChild.SetProperty("U_NextBilledDate", nextBillDate); }

                    }
                    oGeneralService.Update(oGeneralData);


                    rsBill = null;
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }

        private void UpdateNextBillDateforContracts(string ContractID, string cmbBillingType)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_SRBI");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;

                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "SELECT T0.\"Code\",T1.\"LineId\",T1.\"U_NextBilledDate\",T1.\"U_BillingCycle\" , \"EndDate\" FROM \"@Z_OSRB\"  T0 , \"@Z_SRB1\"  T1, \"OCTR\" T2    WHERE T0.\"Code\" = T1.\"Code\" and " +
                    " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";
                rsBill.DoQuery(query);
                if (rsBill.RecordCount > 0)
                {
                    code = int.Parse(rsBill.Fields.Item(0).Value.ToString());
                    blnExist = true;
                }

                if (blnExist)
                {
                    oGeneralParams.SetProperty("Code", code.ToString());
                    oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                    oGeneralData.SetProperty("U_ContractNo", ContractID);

                    SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string lineIdQry = query;
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_SRB1");
                    rsLineId.DoQuery(lineIdQry);

                    if (rsLineId.RecordCount > 0)
                    {
                        int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                        oChild = oChildren.Item(lineId - 1);


                        int yyyy = 0, mm = 0, dd = 0;

                        string etDate = tbBillDate.Value;
                        if (etDate != string.Empty)
                        {
                            yyyy = int.Parse(etDate.Substring(0, 4));
                            mm = int.Parse(etDate.Substring(4, 2));
                            dd = int.Parse(etDate.Substring(6, 2));
                            DateTime dt_end = new DateTime(yyyy, mm, dd);
                            oChild.SetProperty("U_LastBilledDate", dt_end);
                        }

                        string billCyType = string.Empty;

                        switch (rsLineId.Fields.Item("U_BillingCycle").Value.ToString())
                        {
                            case "12": // Monthly
                                billCyType = "1";
                                break;
                            case "4": //Quaterly
                                billCyType = "3";
                                break;
                            case "2"://Semi Annual
                                billCyType = "6";
                                break;
                            case "1": // Annual
                                billCyType = "12";
                                break;
                            default:
                                break;
                        }

                        string stDate = Convert.ToDateTime(rsLineId.Fields.Item("U_NextBilledDate").Value.ToString()).ToShortDateString();
                        DateTime st_Date = DateTime.Parse(stDate);
                        stDate = st_Date.ToString("yyyyMMdd");
                        yyyy = int.Parse(stDate.Substring(0, 4));
                        mm = int.Parse(stDate.Substring(4, 2));
                        dd = int.Parse(stDate.Substring(6, 2));
                        st_Date = new DateTime(yyyy, mm, dd);

                        string CEDate = Convert.ToDateTime(rsLineId.Fields.Item("EndDate").Value.ToString()).ToShortDateString();
                        DateTime CE_Date = DateTime.Parse(CEDate);
                        CEDate = CE_Date.ToString("yyyyMMdd");
                        yyyy = int.Parse(CEDate.Substring(0, 4));
                        mm = int.Parse(CEDate.Substring(4, 2));
                        dd = int.Parse(CEDate.Substring(6, 2));
                        CE_Date = new DateTime(yyyy, mm, dd);


                        DateTime nextBillDate = st_Date;
                        int addMonths = int.Parse(billCyType);
                        nextBillDate = nextBillDate.AddMonths(addMonths);
                        //ntDate = nextBillDate.AddMonths(addMonths + 1);
                        if (cmbBillingType == "E")
                        {
                            if (nextBillDate < CE_Date)
                            { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                            else { oChild.SetProperty("U_NextBilledDate", nextBillDate.AddDays(-1)); }
                        }
                        else { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                    }
                    oGeneralService.Update(oGeneralData);


                    rsBill = null;
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }

        private void UpdateNextBillDateforContracts(string ContractID, string cmbBillingType, int billcycle)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_SRBI");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;

                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "SELECT T0.\"Code\",T1.\"LineId\",T1.\"U_NextBilledDate\",T1.\"U_BillingCycle\" , \"EndDate\" FROM \"@Z_OSRB\"  T0 , \"@Z_SRB1\"  T1, \"OCTR\" T2    WHERE T0.\"Code\" = T1.\"Code\" and " +
                     " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";

                rsBill.DoQuery(query);
                if (rsBill.RecordCount > 0)
                {
                    code = int.Parse(rsBill.Fields.Item(0).Value.ToString());
                    blnExist = true;
                }

                if (blnExist)
                {
                    oGeneralParams.SetProperty("Code", code.ToString());
                    oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                    oGeneralData.SetProperty("U_ContractNo", ContractID);

                    SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string lineIdQry = query;
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_SRB1");
                    rsLineId.DoQuery(lineIdQry);

                    if (rsLineId.RecordCount > 0)
                    {
                        int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                        oChild = oChildren.Item(lineId - 1);
                        int yyyy = 0, mm = 0, dd = 0;
                        string etDate = tbBillDate.Value;
                        if (etDate != string.Empty)
                        {
                            yyyy = int.Parse(etDate.Substring(0, 4));
                            mm = int.Parse(etDate.Substring(4, 2));
                            dd = int.Parse(etDate.Substring(6, 2));
                            DateTime dt_end = new DateTime(yyyy, mm, dd);
                            oChild.SetProperty("U_LastBilledDate", dt_end);
                        }

                        string billCyType = string.Empty;

                        switch (rsLineId.Fields.Item("U_BillingCycle").Value.ToString())
                        {
                            case "12": // Monthly
                                billCyType = "1";
                                break;
                            case "4": //Quaterly
                                billCyType = "3";
                                break;
                            case "2"://Semi Annual
                                billCyType = "6";
                                break;
                            case "1": // Annual
                                billCyType = "12";
                                break;
                            default:
                                break;
                        }

                        string stDate = Convert.ToDateTime(rsLineId.Fields.Item("U_NextBilledDate").Value.ToString()).ToShortDateString();
                        DateTime st_Date = DateTime.Parse(stDate);
                        stDate = st_Date.ToString("yyyyMMdd");
                        yyyy = int.Parse(stDate.Substring(0, 4));
                        mm = int.Parse(stDate.Substring(4, 2));
                        dd = int.Parse(stDate.Substring(6, 2));
                        st_Date = new DateTime(yyyy, mm, dd);

                        string CEDate = Convert.ToDateTime(rsLineId.Fields.Item("EndDate").Value.ToString()).ToShortDateString();
                        DateTime CE_Date = DateTime.Parse(CEDate);
                        CEDate = CE_Date.ToString("yyyyMMdd");
                        yyyy = int.Parse(CEDate.Substring(0, 4));
                        mm = int.Parse(CEDate.Substring(4, 2));
                        dd = int.Parse(CEDate.Substring(6, 2));
                        CE_Date = new DateTime(yyyy, mm, dd);

                        DateTime nextBillDate = st_Date;
                        int addMonths = 0;
                        if (cmbBillingType == "E")
                        { addMonths = billcycle; }
                        else { addMonths = int.Parse(billCyType); }

                        nextBillDate = nextBillDate.AddMonths(addMonths);
                        //ntDate = nextBillDate.AddMonths(addMonths + 1);
                        // oChild.SetProperty("U_NextBilledDate", nextBillDate);
                        if (cmbBillingType == "E")
                        {
                            if (nextBillDate < CE_Date)
                            { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                            else { oChild.SetProperty("U_NextBilledDate", nextBillDate.AddDays(-1)); }
                        }
                        else { oChild.SetProperty("U_NextBilledDate", nextBillDate); }

                    }
                    oGeneralService.Update(oGeneralData);


                    rsBill = null;
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }

        private void UpdateNextBillDateforContracts(string ContractID, string cmbBillingType, Double billcycle)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_SRBI");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;

                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "SELECT T0.\"Code\",T1.\"LineId\",T1.\"U_NextBilledDate\",T1.\"U_BillingCycle\" , \"EndDate\" FROM \"@Z_OSRB\"  T0 , \"@Z_SRB1\"  T1, \"OCTR\" T2    WHERE T0.\"Code\" = T1.\"Code\" and " +
                     " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";

                rsBill.DoQuery(query);
                if (rsBill.RecordCount > 0)
                {
                    code = int.Parse(rsBill.Fields.Item(0).Value.ToString());
                    blnExist = true;
                }

                if (blnExist)
                {
                    oGeneralParams.SetProperty("Code", code.ToString());
                    oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                    oGeneralData.SetProperty("U_ContractNo", ContractID);

                    SAPbobsCOM.Recordset rsLineId = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string lineIdQry = query;
                    //'Child rows
                    oChildren = oGeneralData.Child("Z_SRB1");
                    rsLineId.DoQuery(lineIdQry);

                    if (rsLineId.RecordCount > 0)
                    {
                        int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                        oChild = oChildren.Item(lineId - 1);
                        int yyyy = 0, mm = 0, dd = 0;
                        string etDate = tbBillDate.Value;
                        if (etDate != string.Empty)
                        {
                            yyyy = int.Parse(etDate.Substring(0, 4));
                            mm = int.Parse(etDate.Substring(4, 2));
                            dd = int.Parse(etDate.Substring(6, 2));
                            DateTime dt_end = new DateTime(yyyy, mm, dd);
                            oChild.SetProperty("U_LastBilledDate", dt_end);
                        }


                        string stDate = Convert.ToDateTime(rsLineId.Fields.Item("U_NextBilledDate").Value.ToString()).ToShortDateString();
                        DateTime st_Date = DateTime.Parse(stDate);
                        stDate = st_Date.ToString("yyyyMMdd");
                        //yyyy = int.Parse(stDate.Substring(0, 4));
                        //mm = int.Parse(stDate.Substring(4, 2));
                        //dd = int.Parse(stDate.Substring(6, 2));
                        //  st_Date = new DateTime(yyyy, mm, dd);
                        st_Date = DateTime.ParseExact(stDate, "yyyyMMdd", null);

                        string CEDate = Convert.ToDateTime(rsLineId.Fields.Item("EndDate").Value.ToString()).ToShortDateString();
                        DateTime CE_Date = DateTime.Parse(CEDate);
                        CEDate = CE_Date.ToString("yyyyMMdd");
                        //yyyy = int.Parse(CEDate.Substring(0, 4));
                        //mm = int.Parse(CEDate.Substring(4, 2));
                        //dd = int.Parse(CEDate.Substring(6, 2));
                        //CE_Date = new DateTime(yyyy, mm, dd);
                        CE_Date = DateTime.ParseExact(CEDate, "yyyyMMdd", null);

                        DateTime nextBillDate = st_Date;
                        int addMonths = 0;

                        addMonths = Convert.ToInt32(billcycle);
                        nextBillDate = nextBillDate.AddMonths(addMonths);
                        //ntDate = nextBillDate.AddMonths(addMonths + 1);
                        // oChild.SetProperty("U_NextBilledDate", nextBillDate);

                        if (cmbBillingType == "E")
                        {
                            if (nextBillDate < CE_Date)
                            { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                            else { oChild.SetProperty("U_NextBilledDate", nextBillDate.AddDays(-1)); }
                        }
                        else { oChild.SetProperty("U_NextBilledDate", nextBillDate); }

                    }
                    oGeneralService.Update(oGeneralData);


                    rsBill = null;
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }
        private void cmbBillOption_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (cmbBillOption.Value != string.Empty)
            {
                if (cmbBillOption.Value == "1")
                {
                    this.GetItem("tbFrmSrv").Enabled = true;
                    this.GetItem("tbToSrv").Enabled = true;
                    this.GetItem("cmbBillTyp").Enabled = true;

                    this.tbFrmLeaseCntrct.Value = "";
                    this.tbToLeaseCntrct.Value = "";
                    this.GetItem("tbFrmSrv").Click();

                    this.GetItem("tbFrmLes").Enabled = false;
                    this.GetItem("tbToLeas").Enabled = false;
                }
                else if (cmbBillOption.Value == "2")
                {
                    this.GetItem("tbFrmSrv").Enabled = false;
                    this.GetItem("tbToSrv").Enabled = false;
                    this.GetItem("cmbBillTyp").Enabled = false;

                    this.tbFromServiceContract.Value = "";
                    this.tbToServiceContract.Value = "";

                    this.GetItem("tbFrmLes").Enabled = true;
                    this.GetItem("tbToLeas").Enabled = true;
                }
                else if (cmbBillOption.Value == "3")
                {
                    this.GetItem("tbFrmSrv").Enabled = false;
                    this.GetItem("tbToSrv").Enabled = false;
                    this.GetItem("cmbBillTyp").Enabled = true;

                    this.tbFromServiceContract.Value = "";
                    this.tbToServiceContract.Value = "";

                    this.GetItem("tbFrmLes").Enabled = true;
                    this.GetItem("tbToLeas").Enabled = true;


                }
            }
        }

        private void tbCustSegment_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("UD_CGrp").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }

        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button0;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            LoadGridValues();

        }

        private void cmbBillingType_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // throw new System.NotImplementedException();




        }

    }
}
