using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Procons.AlGhanim.Xerox.Helpers;
using Procons.AlGhanim.MainLibrary.SAPB1;

using Procons.AlGhanim.MainLibrary.Utilities;
using System.IO;
using System.Data;

namespace Procons.AlGhanim.Xerox.Forms
{
    [FormAttribute("Procons.AlGhanim.Xerox.Forms.BillingWizardForm", "Forms/BillingWizardForm.b1f")]
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
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (tbFromServiceContract.Value != string.Empty && tbToServiceContract.Value != string.Empty)
            {
                string query = "Select T0.\"U_ContractNo\" From \"@Z_OLCM\" T0 Where ((T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "' and T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "') " +
                                "or (T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "' and T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "')) and (T0.\"U_ContractNo\" >= " + tbFromServiceContract.Value + " and T0.\"U_ContractNo\" <= " + tbToServiceContract.Value + " ) ";
                ChooseFromListCondition(pCFL, "U_ContractNo", "", "Q", query);
            }
            else if (tbFromServiceContract.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select From Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }
            else if (tbToServiceContract.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select To Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }

        }

        private void tbToLeaseCntrct_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (tbFromServiceContract.Value != string.Empty && tbToServiceContract.Value != string.Empty)
            {
                string query = "Select T0.\"U_ContractNo\" From \"@Z_OLCM\" T0 Where ((T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "' and T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "') " +
                                "or (T0.\"U_CustomerCode\" <='" + tbToCustomer.Value + "' and T0.\"U_CustomerCode\" >='" + tbFrmCustomer.Value + "')) and (T0.\"U_ContractNo\" >= " + tbFromServiceContract.Value + " and T0.\"U_ContractNo\" <= " + tbToServiceContract.Value + " ) ";
                ChooseFromListCondition(pCFL, "U_ContractNo", "", "Q", query);
            }
            else if (tbFromServiceContract.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select From Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }
            else if (tbToServiceContract.Value == string.Empty)
            {
                BubbleEvent = false;
                Application.SBO_Application.SetStatusBarMessage("Please Select To Lease Contract", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return;
            }

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
                                 " (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" )) \"Free Copied\", case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\") - (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\", T0.\"U_Price\" \"Price\",T0.\"U_ExcessPrice\" \"Excess Price\" , case when ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" <= 0 then 0 else ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+(T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")- (T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) * T0.\"U_ExcessPrice\" end \"Total\", " +
                                 " T5.\"U_FixedPrice\"  \"FixedPrice\" , " +
                                  " T2.\"U_IsFixedPrice\" \"IsFixedPrice\", T1.\"ContractID\" , T4.\"U_BillingCycle\" \"BillingCycle\" , T0.\"Code\" " +
                                 " FROM \"@Z_ECMD\"  T0 ,\"OCTR\" T1  join \"@Z_OSRP\" T2 on T1.\"ContractID\" = T2.\"U_ContractNo\" " +
                                 "  join \"@Z_SRP1\" T5 on T5.\"Code\" = T2.\"Code\"  " +
                                 " JOIN  \"@Z_OSRB\" T3 ON T3.\"U_ContractNo\" = T1.\"ContractID\" JOIN \"@Z_SRB1\" T4 ON T4.\"Code\" = T3.\"Code\" WHERE T0.\"U_DocNum\" = to_varchar( T1.\"ContractID\") " +
                                 "  " + tbFromServiceContractValue + "  " + sCustomer + " and  T0.\"U_Billed\" ='N' and T4.\"U_BillingType\" = '" + sbilltype + "'  and T4.\"U_NextBilledDate\" <= '" + tbBillDate.Value + "' and T1.\"TermDate\" is null  and T1.\"U_PriceType\" <> 'F'  " +
                                 "  GROUP BY T0.\"U_DocNum\", T0.\"U_CurrentMeterReading\" , T0.\"U_LastMeterReading\" , T0.\"U_EligQuantity\",T0.\"U_ExcessPrice\",T4.\"U_NextBilledDate\", T0.\"U_PoolCode\" ,T0.\"U_MeterCode\"  , T1.\"CstmrCode\",   T1.\"CstmrName\",T0.\"U_ItemCode\"  ,T0.\"U_MeterName\"  , T0.\"U_SerialNum\"  , T0.\"U_StartMeterReading\",T0.\"U_Price\",  T5.\"U_FixedPrice\"  ,  T2.\"U_IsFixedPrice\"  , T1.\"ContractID\" , T4.\"U_BillingCycle\" ,T0.\"Code\" ,T0.\"U_RCurrentMeterReading\",T0.\"U_RLastMeterReading\", T0.\"U_Reset\", T4.\"Code\" ";

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
"  ( T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) ) \"Free Copied\",     " +
"      case when  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\") + (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")   " +
"   -(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ) )) <= 0 then 0 else  ((T0.\"U_CurrentMeterReading\"-T0.\"U_LastMeterReading\")+  " +
"   (T0.\"U_RCurrentMeterReading\"-T0.\"U_RLastMeterReading\")-(T0.\"U_EligQuantity\" * ((SELECT TT0.\"U_BillingCycle\" FROM \"@Z_SRB1\"  TT0 WHERE TT0.\"U_BillingType\" = 'B' and  TT0.\"Code\" = T4.\"Code\") /  T4.\"U_BillingCycle\" ))) end \"Excess\",   " +
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
"             T0.\"U_RLastMeterReading\", T0.\"U_Reset\"  ,T4.\"Code\" ";

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
                Utility.LogException("Error at BillinWizardForm.LoadGridValues Method: " + ex.Message);
            }
        }


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
                case "B":
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
                for (int iloop = 0; iloop <= Grid0.Rows.Count - 1; iloop++)
                {
                    oDTSC.Rows.Add(Grid0.DataTable.GetValue("Service Call", iloop));

                    if (Grid0.Rows.IsSelected(iloop))
                        oDT.Rows.Add(Grid0.DataTable.GetValue("Contract No.", iloop), Grid0.DataTable.GetValue("Bill Date", iloop), Grid0.DataTable.GetValue("Customer Code", iloop),
                            Grid0.DataTable.GetValue("Preventive Maintance", iloop), Grid0.DataTable.GetValue("Service Amount", iloop), Grid0.DataTable.GetValue("Service Call", iloop));
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

            SAPbobsCOM.ServiceCalls  servicecalls = null;
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
                        DateTime dt = new DateTime();
                        dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        Billdate = dt.ToString("yyyyMMdd");
                        oInv.Lines.ItemCode = itemCode;
                        oInv.Lines.Quantity = 1;
                        oInv.Lines.UnitPrice = Convert.ToDouble(odrv["SMA Price"].ToString().Trim()) / interval;
                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;
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
        private void PostArRDocument(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billmeterreading = "";
            string SerialNum = "";
            string Billdate = "";
            string itemCode = "";
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
                    foreach (DataRowView odrv in oDVInvoiceHeader)
                    {
                        itemCode = odrv["MeterCode"].ToString().Trim();
                        Billmeterreading = odrv["Used"].ToString().Trim();
                        SerialNum = odrv["Serial No"].ToString().Trim();
                        DateTime dt = new DateTime();
                        dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        Billdate = dt.ToString("yyyyMMdd");
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
                        }
                        else
                        {
                            oInv.Lines.Quantity = Convert.ToDouble(odrv["Excess"].ToString().Trim());
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["Excess Price"].ToString().Trim());
                            // oInv.Lines.LineTotal = oInv.Lines.Quantity * oInv.Lines.UnitPrice;
                        }

                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;

                        if (cmbBillingType.Value == "E")
                        {
                            string query = "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "')  where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ";
                            rsBill.DoQuery(query);

                        }
                        oInv.Lines.Add();
                    }

                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        isposted = true;
                        if (cmbBillOption.Value == "1")
                            UpdateNextBillDateforContracts(ContractID);
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
        private void PostArRDocumentBoth(string billgenType)
        {
            bool isposted = false;
            string ContractID = "";
            string Billmeterreading = "";
            string SerialNum = "";
            string Billdate = "";
            string itemCode = "";
            string sBillingType = string.Empty;

            int billingcycle = 0;
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
                        Billmeterreading = odrv["Used"].ToString().Trim();
                        SerialNum = odrv["Serial No"].ToString().Trim();
                        sBillingType = sBillingType = odrv["Billing Type"].ToString().Trim();
                        billingcycle = Convert.ToInt32(odrv["BillingCycle"].ToString().Trim());
                        DateTime dt = new DateTime();
                        dt = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        Billdate = dt.ToString("yyyyMMdd");
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
                        else
                        {
                            oInv.Lines.Quantity = Convert.ToDouble(odrv["Excess"].ToString().Trim());
                            oInv.Lines.UnitPrice = Convert.ToDouble(odrv["U_ExcessPrice"].ToString().Trim());
                            query += "UPDATE \"@Z_ECMD\"  SET  \"U_LastMeterReading\" =  to_integer( '" + Billmeterreading + "')  where  \"U_DocNum\" = '" + ContractID + "' and \"U_PoolCode\" = '" + odrv["PoolCode"].ToString().Trim() + "' and \"U_MeterCode\" = '" + itemCode + "'  ; ";
                        }

                        oInv.Lines.UserFields.Fields.Item("U_ContractID").Value = ContractID;

                        oInv.Lines.Add();
                    }


                    if (oInv.Add() == 0)
                    {
                        //update status to billling ='Y'
                        oDTDistinct = oDVInvoiceHeader.ToTable(true, "Billing Type");
                        foreach (DataRow odrv in oDTDistinct.Rows)
                        {
                            sBillingType = sBillingType = odrv["Billing Type"].ToString();
                            UpdateNextBillDateforContracts(ContractID, sBillingType == "Fixed Billing" ? "B" : "E");
                        }

                        //  UpdateNextBillDateforContracts(ContractID, sBillingType == "Fixed Billing" ? "B" : "E", billingcycle);
                        isposted = true;
                        string[] words = query.Split(';');
                        foreach (string word in words)
                        {
                            if (word != " ")
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
                     " T0.\"U_ContractNo\" ='" + ContractID + "' and T1.\"U_BillingType\"='" + cmbBillingType.Value  + "' and  T2.\"ContractID\" = T0.\"U_ContractNo\" ";

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
                        if (nextBillDate < CE_Date)
                        { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                        else { oChild.SetProperty("U_NextBilledDate", ""); }

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
                        if (nextBillDate < CE_Date)
                        { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                        else { oChild.SetProperty("U_NextBilledDate", ""); }


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
                        if (nextBillDate < CE_Date)
                        { oChild.SetProperty("U_NextBilledDate", nextBillDate); }
                        else { oChild.SetProperty("U_NextBilledDate", ""); }

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

                    this.GetItem("tbFrmLes").Enabled = false;
                    this.GetItem("tbToLeas").Enabled = false;
                }
                else if (cmbBillOption.Value == "2")
                {
                    this.GetItem("tbFrmSrv").Enabled = false;
                    this.GetItem("tbToSrv").Enabled = false;

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
