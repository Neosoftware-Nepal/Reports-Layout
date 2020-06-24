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

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.InterestWizardForm", "Forms/InterestWizardForm .b1f")]
    class InterestWizardForm : B1FormBase
    {
        //  private static DataTable oDTInvoice;
        private static string sQuery = string.Empty;
        public InterestWizardForm()
        {

        }

        #region Properties

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText tbBillDate;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText tbFrmCustomer;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText tbToCustomer;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText tbFrmLeaseCntrct;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText tbToLeaseCntrct;
        private SAPbouiCOM.Button btnGenerate;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.EditText tbFromServiceContract;
        private SAPbouiCOM.ComboBox cmbBillOption;
        private SAPbouiCOM.EditText tbToServiceContract;

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
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.tbFrmLeaseCntrct = ((SAPbouiCOM.EditText)(this.GetItem("tbFrmLes").Specific));
            this.tbFrmLeaseCntrct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbFrmLeaseCntrct_ChooseFromListBefore);
            this.tbFrmLeaseCntrct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbFrmLeaseCntrct_ChooseFromListAfter);
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.tbToLeaseCntrct = ((SAPbouiCOM.EditText)(this.GetItem("tbToLeas").Specific));
            this.tbToLeaseCntrct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbToLeaseCntrct_ChooseFromListBefore);
            this.tbToLeaseCntrct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbToLeaseCntrct_ChooseFromListAfter);
            this.btnGenerate = ((SAPbouiCOM.Button)(this.GetItem("btnGenrte").Specific));
            this.btnGenerate.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnGenerate_PressedAfter);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("gd_Sumry").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.tbFromServiceContract = ((SAPbouiCOM.EditText)(this.GetItem("tbFrmSrv").Specific));
            this.tbFromServiceContract.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbFromServiceContract_ChooseFromListBefore);
            this.tbFromServiceContract.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbFromServiceContract_ChooseFromListAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));

            this.tbToServiceContract = ((SAPbouiCOM.EditText)(this.GetItem("tbToSrv").Specific));
            this.tbToServiceContract.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbToServiceContract_ChooseFromListBefore);
            this.tbToServiceContract.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbToServiceContract_ChooseFromListAfter);

            this.cmbBillOption = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbBilOpts").Specific));
            this.cmbBillOption.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.cmbBillOption_ComboSelectAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
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
            this.GetItem("tbFrmSrv").Enabled = false;
            this.GetItem("tbToSrv").Enabled = false;


            this.GetItem("tbFrmLes").Enabled = false;
            this.GetItem("tbToLeas").Enabled = false;
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
                Utility.LogException("Error at InterestWizardForm.tbFrmCustomer_ChooseFromListAfter Method: " + ex.Message);
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
                Utility.LogException("Error at InterestWizardForm.tbFrmCustomer_ChooseFromListAfter Method: " + ex.Message);
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


        private void cmbBillOption_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (cmbBillOption.Value != string.Empty)
            {
                if (cmbBillOption.Value == "R")
                {
                    this.GetItem("tbFrmSrv").Enabled = true;
                    this.GetItem("tbToSrv").Enabled = true;


                    this.GetItem("tbFrmLes").Enabled = false;
                    this.GetItem("tbToLeas").Enabled = false;
                    this.tbFrmLeaseCntrct.Value = "";
                    this.tbToLeaseCntrct.Value = "";
                }
                else if (cmbBillOption.Value == "I")
                {
                    this.GetItem("tbFrmSrv").Enabled = false;
                    this.GetItem("tbToSrv").Enabled = false;
                    this.tbFromServiceContract.Value = "";
                    this.tbToServiceContract.Value = "";

                    this.GetItem("tbFrmLes").Enabled = true;
                    this.GetItem("tbToLeas").Enabled = true;
                }

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
                string sBillDate = tbBillDate.Value;
                SAPbobsCOM.Recordset rsObj = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "I")
                {
                    //query = "Select T0.\"Code\" \"ContractID\",T4.\"LineId\",T0.\"U_ItemCode\" \"ItemCode\",T0.\"U_ItemDesc\" \"Item Description\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\" ,T0.\"U_CustomerCode\" \"CustomerCode\",T0.\"U_CustomerName\" \"CustomerName\"from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                    //        "where   T0.\"U_ItemCode\" <>'' and (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_Status\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";

                    //*******************************Change Query - 17Apr2018 - Start 
                    query = "Select T0.\"Code\" \"ContractID  \",T4.\"LineId\",T4.\"U_LBDate\" \"Bill Date\",T4.\"U_LeaseBilling\" \"Monthly Bill\",T4.\"U_Interest\" \"Interest\" ,T0.\"U_InterestAcct\" \"InterestAcct\",T0.\"U_DiffInterestAcct\" \"DiffInterestAcct\",T0.\"U_CustomerCode\" \"CustomerCode\" from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                            "where (T0.\"Code\" >= '" + tbFrmLeaseCntrct.Value + "' and T0.\"Code\" <= '" + tbToLeaseCntrct.Value + "')  and T4.\"U_IStatus\" = 'Pending' and \"U_LBDate\" <= '" + tbBillDate.Value + "'";
                    //*******************************Change Query - 17Apr2018 - End 

                }
                else
                {
                    //SQL
                    //query = "select T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RAmount\" \"Amount\",T0.\"U_RCreditAcc\" \"CreditAccount\",T0.\"U_RDebitAcc\" \"DebitAccount\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\" from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  where  (T0.\"U_RContractNo\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_RContractNo\" <= '" + tbToServiceContract.Value + "')  and T1.\"U_RMonth\" <= DATENAME(month,'" + tbBillDate.Value + "') and T1.\"U_RYear\" <= DATENAME(year,'" + tbBillDate.Value + "') and T1.\"U_RStatus\" = 'Pending'";
                    //HANA
                    //query = "select T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RAmount\" \"Amount\",T0.\"U_RCreditAcc\" \"CreditAccount\",T0.\"U_RDebitAcc\" \"DebitAccount\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\" from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  where  (T0.\"U_RContractNo\" >= '" + tbFromServiceContract.Value + "' and T0.\"U_RContractNo\" <= '" + tbToServiceContract.Value + "')  and T1.\"U_RMonth\" <= MONTHNAME('" + tbBillDate.Value + "') and T1.\"U_RYear\" <= YEAR('" + tbBillDate.Value + "') and T1.\"U_RStatus\" = 'Pending'";

                    if ((tbFromServiceContract.Value.ToString() != "") && (tbToServiceContract.Value.ToString() != ""))
                    {
                        query = " Select VW.\"ContractID\",VW.\"Customer\",VW.\"Amount\",VW.\"CreditAccount\",VW.\"DebitAccount\",VW.\"Month\",VW.\"Year\",VW.\"Status\" from " +
                                "(Select T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RAmount\" \"Amount\",T0.\"U_RCreditAcc\" \"CreditAccount\",T0.\"U_RDebitAcc\" \"DebitAccount\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\" ,T1.\"U_RStatus\" \"Status\",T0.\"U_RCustomer\" \"Customer\"," +
                                "case when T1.\"U_RMonth\" = 'JANUARY' then 1 when T1.\"U_RMonth\" = 'FEBRUARY' then 2 when T1.\"U_RMonth\" = 'MARCH' then 3  " +
                                "when T1.\"U_RMonth\" = 'APRIL' then 4	when T1.\"U_RMonth\" = 'MAY' then 5 when T1.\"U_RMonth\" = 'JUNE' then 6 when T1.\"U_RMonth\" = 'JULY' then 7 " +
                                "when T1.\"U_RMonth\" = 'AUGUST' then 8 when T1.\"U_RMonth\" = 'SEPTEMBER' then 9 when T1.\"U_RMonth\" = 'OCTOBER' then 10 " +
                                "when T1.\"U_RMonth\" = 'NOVEMBER' then 11 when T1.\"U_RMonth\" = 'DECEMBER' then 12 end \"MonthNumber\" " +
                                "from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  ) as VW " +
                                "where  (VW.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and VW.\"ContractID\" <= '" + tbToServiceContract.Value + "') and VW.\"MonthNumber\" <=   MONTH('" + tbBillDate.Value + "') and VW.\"Year\" <= YEAR('" + tbBillDate.Value + "') " +
                                "and VW.\"Status\" = 'Pending' order by VW.\"MonthNumber\"";
                    }
                    else
                    {
                        query = " Select VW.\"ContractID\",VW.\"Customer\",VW.\"Amount\",VW.\"CreditAccount\",VW.\"DebitAccount\",VW.\"Month\",VW.\"Year\",VW.\"Status\" from " +
                                "(Select T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RAmount\" \"Amount\",T0.\"U_RCreditAcc\" \"CreditAccount\",T0.\"U_RDebitAcc\" \"DebitAccount\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\" ,T1.\"U_RStatus\" \"Status\",T0.\"U_RCustomer\" \"Customer\"," +
                                "case when T1.\"U_RMonth\" = 'JANUARY' then 1 when T1.\"U_RMonth\" = 'FEBRUARY' then 2 when T1.\"U_RMonth\" = 'MARCH' then 3  " +
                                "when T1.\"U_RMonth\" = 'APRIL' then 4	when T1.\"U_RMonth\" = 'MAY' then 5 when T1.\"U_RMonth\" = 'JUNE' then 6 when T1.\"U_RMonth\" = 'JULY' then 7 " +
                                "when T1.\"U_RMonth\" = 'AUGUST' then 8 when T1.\"U_RMonth\" = 'SEPTEMBER' then 9 when T1.\"U_RMonth\" = 'OCTOBER' then 10 " +
                                "when T1.\"U_RMonth\" = 'NOVEMBER' then 11 when T1.\"U_RMonth\" = 'DECEMBER' then 12 end \"MonthNumber\" " +
                                "from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  ) as VW " +
                                "where   VW.\"MonthNumber\" <=   MONTH('" + tbBillDate.Value + "') and VW.\"Year\" <= YEAR('" + tbBillDate.Value + "') " +
                                "and VW.\"Status\" = 'Pending' order by VW.\"MonthNumber\"";
                    }



                }
                Grid0.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
                this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);

                // convert record to datatable
                sQuery = query;


                //for (int iloop = 0; iloop <= Grid0.DataTable.Columns.Count - 1; iloop++)
                //{
                //    Grid0.Columns.Item(iloop).Editable = false;
                //}


                Grid0.AutoResizeColumns();

                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at InterstWizardForm.LoadGridValues Method: " + ex.Message);
            }
        }

        private void btnGenerate_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


            Application.SBO_Application.SetStatusBarMessage("Pls.. wait Journal Entry generation in process ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
            //PostArRDocument(cmbBillOption.Value);
            PostJEDocument();
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





        private void PostJEDocument()
        {
            bool isposted = false;
            string ContractID = "";
            string Month = "";
            string year = "";
            //string Billmeterreading = "";
            //string SerialNum = "";
            //string Billdate = "";
            //string itemCode = "";
            var lstdt = new List<DataTable>();
            SAPbobsCOM.BusinessPartners ocrd = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            SAPbobsCOM.Items oItem = (SAPbobsCOM.Items)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
            SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset); string BillType = "";
            SAPbobsCOM.Recordset rsCardCode = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            rsBill.DoQuery(sQuery);
            DataTable oDT = new DataTable();
            DataTable oDTDistinct = new DataTable();


            if (cmbBillOption.Value != string.Empty && cmbBillOption.Value == "I")
            {

                oDT = ConvertRecordset(rsBill);
                DataView oDVJEHeader = new DataView(oDT);
                oDTDistinct = oDVJEHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVJEHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    //SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    SAPbobsCOM.JournalEntries oJE = (SAPbobsCOM.JournalEntries)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oJournalEntries);


                    oJE.DueDate = Convert.ToDateTime(oDVJEHeader[0]["Bill Date"].ToString().Trim());
                    oJE.TaxDate = Convert.ToDateTime(oDVJEHeader[0]["Bill Date"].ToString().Trim());
                    oJE.ReferenceDate = Convert.ToDateTime(oDVJEHeader[0]["Bill Date"].ToString().Trim());
                    oJE.Memo = "";

                    string BillDate = Convert.ToDateTime(oDVJEHeader[0]["Bill Date"].ToString().Trim()).ToShortDateString();
                    DateTime BillDates = DateTime.Parse(BillDate);
                    BillDate = BillDates.ToString("yyyyMMdd");

                    Application.SBO_Application.SetStatusBarMessage("Generating JE for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVJEHeader)
                    {
                        // first line  
                        oJE.Lines.ShortName = Convert.ToString(odrv["DiffInterestAcct"].ToString().Trim());
                        oJE.Lines.Credit = 0;
                        oJE.Lines.Debit = Convert.ToDouble(odrv["Interest"].ToString().Trim());
                        oJE.Lines.DueDate = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        oJE.Lines.TaxDate = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        oJE.Lines.ReferenceDate1 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());

                        //second line 
                        oJE.Lines.Add();
                        oJE.Lines.ShortName = Convert.ToString(odrv["InterestAcct"].ToString().Trim());
                        oJE.Lines.Credit = Convert.ToDouble(odrv["Interest"].ToString().Trim());
                        oJE.Lines.Debit = 0;
                        oJE.Lines.DueDate = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        oJE.Lines.TaxDate = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());
                        oJE.Lines.ReferenceDate1 = Convert.ToDateTime(odrv["Bill Date"].ToString().Trim());

                        oJE.Lines.Add();
                    }

                    if (oJE.Add() == 0)
                    {

                        isposted = true;

                        UpdateLineStatusLeaseContracts(ContractID, BillDate);
                        isposted = true;
                        Application.SBO_Application.SetStatusBarMessage("Journal Entry generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
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

                    Application.SBO_Application.MessageBox("Journal Entry Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();
                    rsBill = null;

                }
            }
            else
            {
                oDT = ConvertRecordset(rsBill);
                DataView oDVJEHeader = new DataView(oDT);
                oDTDistinct = oDVJEHeader.ToTable(true, "ContractID");
                foreach (DataRow Dr in oDTDistinct.Rows)
                {
                    oDVJEHeader.RowFilter = "ContractID='" + Dr[0].ToString() + "'";
                    ContractID = oDTDistinct.Rows[0][0].ToString();

                    //SAPbobsCOM.Documents oInv = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                    SAPbobsCOM.JournalEntries oJE = (SAPbobsCOM.JournalEntries)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oJournalEntries);

                    oJE.DueDate = DateTime.Now;
                    oJE.TaxDate = DateTime.Now;
                    oJE.ReferenceDate = DateTime.Now;
                    oJE.Memo = "";
                    //Month = Convert.ToString(oDVJEHeader[0]["Month"].ToString().Trim());
                    //year = Convert.ToString(oDVJEHeader[0]["Year"].ToString().Trim());

                    Application.SBO_Application.SetStatusBarMessage("Generating JE for the Contract ID " + ContractID, SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    foreach (DataRowView odrv in oDVJEHeader)
                    {
                        string sCode = "";
                        string sCardCode = odrv["Customer"].ToString().Trim();
                        string query = "select \"CardCode\" from \"OCRD\" where \"CardName\" = '" + sCardCode + "' ";
                        rsCardCode.DoQuery(query);

                        if (rsCardCode.RecordCount > 0)
                        {
                            sCode = rsCardCode.Fields.Item(0).Value.ToString();
                        }

                        Month = Convert.ToString(odrv["Month"].ToString().Trim());
                        year = Convert.ToString(odrv["Year"].ToString().Trim());
                        // first line  
                        oJE.Lines.ShortName = Convert.ToString(odrv["DebitAccount"].ToString().Trim());
                        oJE.Lines.Credit = 0;
                        oJE.Lines.Debit = Convert.ToDouble(odrv["Amount"].ToString().Trim());
                        oJE.Lines.DueDate = DateTime.Now;
                        oJE.Lines.TaxDate = DateTime.Now;
                        oJE.Lines.ReferenceDate1 = DateTime.Now;
                        oJE.Lines.Reference2 = odrv["ContractID"].ToString().Trim();
                        oJE.Lines.AdditionalReference = sCode;
                        oJE.Lines.LineMemo = Month + "  " + year + " - " + "Recurring Schedule";
                        oJE.Lines.Add();
                        //second line                         
                        oJE.Lines.ShortName = Convert.ToString(odrv["CreditAccount"].ToString().Trim());
                        oJE.Lines.Credit = Convert.ToDouble(odrv["Amount"].ToString().Trim());
                        oJE.Lines.Debit = 0;
                        oJE.Lines.DueDate = DateTime.Now;
                        oJE.Lines.TaxDate = DateTime.Now;
                        oJE.Lines.ReferenceDate1 = DateTime.Now;
                        oJE.Lines.Reference2 = odrv["ContractID"].ToString().Trim();
                        oJE.Lines.AdditionalReference = sCode;
                        oJE.Lines.LineMemo = Month + "  " + year + " - " + "Recurring Schedule";
                        oJE.Lines.Add();
                    }

                    if (oJE.Add() == 0)
                    {

                        isposted = true;

                        UpdateLineStatusRecContracts(ContractID, Month, year);
                        isposted = true;
                        Application.SBO_Application.SetStatusBarMessage("Journal Entry generated successfully ...!", SAPbouiCOM.BoMessageTime.bmt_Short, false);
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

                    Application.SBO_Application.MessageBox("Journal Entry Posted Successfully", 1, "Ok");
                    Grid0.DataTable.Clear();
                    rsBill = null;

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

                string query = "select T0.\"Code\",T4.\"LineId\",T4.\"U_LBDate\",T4.\"U_IStatus\",T4.\"U_Posted\"  " +
                               "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                               "where T0.\"Code\" = '" + ContractID + "' and T4.\"U_LBDate\" = '" + BillDate + "' ";
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
                            //String Posted = "Yes";
                            oChild.SetProperty("U_IStatus", status);
                            //oChild.SetProperty("U_Posted", Posted);
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

        private void UpdateLineStatusRecContracts(string ContractID, string Month, string year)
        {
            try
            {
                SAPbobsCOM.GeneralData oChild, oGeneralData;
                SAPbobsCOM.GeneralDataCollection oChildren;
                SAPbobsCOM.GeneralService oGeneralService;
                SAPbobsCOM.GeneralDataParams oGeneralParams;
                SAPbobsCOM.CompanyService oCompanyService;
                oCompanyService = B1Helper.DiCompany.GetCompanyService();
                oGeneralService = oCompanyService.GetGeneralService("UDO_ORSS");
                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
                bool blnExist = false;
                int code = 0;
                //DateTime BillDates = DateTime.ParseExact(BillDate.ToShortDateString(), "yyyyMMdd", null);
                SAPbobsCOM.Recordset rsBill = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = "";
                //string query = " select T1.\"Code\",T1.\"LineId\",T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\"," +
                //              "T1.\"U_RStatus\" from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  where  (T0.\"U_RContractNo\" >= '" + ContractID + "' and T0.\"U_RContractNo\" <= '" + ContractID + "')  and T1.\"U_RMonth\" <= '" + Month + "' and T1.\"U_RYear\" <= '" + year + "'";
                if ((tbFromServiceContract.Value.ToString() != "") && (tbToServiceContract.Value.ToString() != ""))
                {
                    query = " Select VW.\"Code\",VW.\"LineId\",VW.\"ContractID\",VW.\"Amount\",VW.\"CreditAccount\",VW.\"DebitAccount\",VW.\"Month\",VW.\"Year\",VW.\"Status\" from " +
                              "(Select T1.\"Code\",T1.\"LineId\",T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RAmount\" \"Amount\",T0.\"U_RCreditAcc\" \"CreditAccount\",T0.\"U_RDebitAcc\" \"DebitAccount\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\" ,T1.\"U_RStatus\" \"Status\"," +
                              "case when T1.\"U_RMonth\" = 'JANUARY' then 1 when T1.\"U_RMonth\" = 'FEBRUARY' then 2 when T1.\"U_RMonth\" = 'MARCH' then 3  " +
                              "when T1.\"U_RMonth\" = 'APRIL' then 4	when T1.\"U_RMonth\" = 'MAY' then 5 when T1.\"U_RMonth\" = 'JUNE' then 6 when T1.\"U_RMonth\" = 'JULY' then 7 " +
                              "when T1.\"U_RMonth\" = 'AUGUST' then 8 when T1.\"U_RMonth\" = 'SEPTEMBER' then 9 when T1.\"U_RMonth\" = 'OCTOBER' then 10 " +
                              "when T1.\"U_RMonth\" = 'NOVEMBER' then 11 when T1.\"U_RMonth\" = 'DECEMBER' then 12 end \"MonthNumber\" " +
                              "from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  ) as VW " +
                              "where  (VW.\"ContractID\" >= '" + tbFromServiceContract.Value + "' and VW.\"ContractID\" <= '" + tbToServiceContract.Value + "') and VW.\"MonthNumber\" <=   MONTH('" + tbBillDate.Value + "') and VW.\"Year\" <= YEAR('" + tbBillDate.Value + "') " +
                              "and VW.\"Status\" = 'Pending' order by VW.\"MonthNumber\"";
                }
                else
                {
                    query = " Select VW.\"Code\",VW.\"LineId\",VW.\"ContractID\",VW.\"Amount\",VW.\"CreditAccount\",VW.\"DebitAccount\",VW.\"Month\",VW.\"Year\",VW.\"Status\" from " +
                             "(Select T1.\"Code\",T1.\"LineId\",T0.\"U_RContractNo\" \"ContractID\",T1.\"U_RAmount\" \"Amount\",T0.\"U_RCreditAcc\" \"CreditAccount\",T0.\"U_RDebitAcc\" \"DebitAccount\",T1.\"U_RMonth\" \"Month\", T1.\"U_RYear\" \"Year\" ,T1.\"U_RStatus\" \"Status\"," +
                             "case when T1.\"U_RMonth\" = 'JANUARY' then 1 when T1.\"U_RMonth\" = 'FEBRUARY' then 2 when T1.\"U_RMonth\" = 'MARCH' then 3  " +
                             "when T1.\"U_RMonth\" = 'APRIL' then 4	when T1.\"U_RMonth\" = 'MAY' then 5 when T1.\"U_RMonth\" = 'JUNE' then 6 when T1.\"U_RMonth\" = 'JULY' then 7 " +
                             "when T1.\"U_RMonth\" = 'AUGUST' then 8 when T1.\"U_RMonth\" = 'SEPTEMBER' then 9 when T1.\"U_RMonth\" = 'OCTOBER' then 10 " +
                             "when T1.\"U_RMonth\" = 'NOVEMBER' then 11 when T1.\"U_RMonth\" = 'DECEMBER' then 12 end \"MonthNumber\" " +
                             "from \"@Z_ORSS\" T0 left join \"@Z_RSS1\" T1 on T1.\"Code\" = T0.\"Code\"  ) as VW " +
                             "where   VW.\"MonthNumber\" <=   MONTH('" + tbBillDate.Value + "') and VW.\"Year\" <= YEAR('" + tbBillDate.Value + "') " +
                             "and VW.\"Status\" = 'Pending' order by VW.\"MonthNumber\"";
                }
                //string query = "select T0.\"Code\",T4.\"LineId\",T4.\"U_LBDate\",T4.\"U_IStatus\",T4.\"U_Posted\"  " +
                //               "from \"@Z_OLCM\" T0 inner join \"@Z_LCLB\" T4 on T4.\"Code\" = T0.\"Code\"" +
                //               "where T0.\"Code\" = '" + ContractID + "' and T4.\"U_LBDate\" = '" + BillDate + "' ";

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
                        oChildren = oGeneralData.Child("Z_RSS1");
                        rsLineId.DoQuery(lineIdQry);

                        if (rsLineId.RecordCount > 0)
                        {
                            int lineId = int.Parse(rsLineId.Fields.Item(1).Value.ToString());
                            oChild = oChildren.Item(lineId - 1);
                            String status = "Generated";
                            String Posted = "Yes";
                            oChild.SetProperty("U_RStatus", status);
                            oChild.SetProperty("U_RPosted", Posted);
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

        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText5;

    }
}
