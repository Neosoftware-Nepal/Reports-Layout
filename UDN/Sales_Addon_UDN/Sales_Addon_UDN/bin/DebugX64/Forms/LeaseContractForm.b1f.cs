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
    [FormAttribute("ITNepal.Addon.Forms.LeaseContractForm", "Forms/LeaseContractForm.b1f")]
    class LeaseContractForm : B1FormBase
    {
        public LeaseContractForm()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText tbCustCd;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText tbLeaseContctNo;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText tbCustNm;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText tbStrtDt;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText tbEndDt;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText tbContctPerson;
        private SAPbouiCOM.Folder f_General;
        private SAPbouiCOM.Button btnOk;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.Folder f_Machine;
        private SAPbouiCOM.Folder f_Document;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.ComboBox cmbContractTyp;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.ComboBox cmbBillingCycle;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText tbSoDocNo;
        private SAPbouiCOM.EditText tbCnctVal;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText tbContractNo;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText tbInterestRate;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText tbRevenueRegAct;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText tbRevenueAct;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText tbInterestAct;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText tbDiffIntAct;
        private SAPbouiCOM.Matrix mtx_Item;
        private SAPbouiCOM.Matrix mtx_Doc;
        private SAPbouiCOM.LinkedButton lb_Cust;
        private SAPbouiCOM.LinkedButton lb_SoNo;
        private SAPbouiCOM.LinkedButton lb_ContNo;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.ComboBox cmbBillDay;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText txtBillStartDate;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.ComboBox ComboBox3;
        private SAPbouiCOM.EditText tbSerCnctVal;
        private SAPbouiCOM.EditText tbItmCode;
        private SAPbouiCOM.EditText tbItmDesc;
        private SAPbouiCOM.EditText tbItmLR;
        private SAPbouiCOM.EditText tbItmDsLR;
        private SAPbouiCOM.Folder f_Lease;
        private SAPbouiCOM.Matrix mtx_LB;


        private SAPbouiCOM.DBDataSource oDBs_Head, oDBs_LCIT, ODBs_LCDD, ODBS_LCLB;
        private SAPbouiCOM.ComboBox oComboBox;
        private SAPbouiCOM.Matrix oMatrix;
        private int code, tempinst;
        private Decimal temptotalValue = 0.0M;
        private Decimal tempmonthlyValue = 0.0M;
        private Decimal tempInterestValue = 0.0M;
        private Decimal tempBalance = 0.0M;
        private Double tempInterestAmt = 0.0;
        private Double tempLoanAmt = 0.0;
        private DateTime LBQDate;
        private DateTime tempLBQDate;
        private DateTime LBHDate;
        private DateTime tempLBHDate;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.tbCustCd = ((SAPbouiCOM.EditText)(this.GetItem("tbCustCd").Specific));
            this.tbCustCd.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbCustCd_ChooseFromListBefore);
            this.tbCustCd.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbCustCd_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.tbLeaseContctNo = ((SAPbouiCOM.EditText)(this.GetItem("tbLContNo").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.tbCustNm = ((SAPbouiCOM.EditText)(this.GetItem("tbCustNm").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.tbStrtDt = ((SAPbouiCOM.EditText)(this.GetItem("tbStrtDt").Specific));
            this.tbStrtDt.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.LoadBillStartDate);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.tbEndDt = ((SAPbouiCOM.EditText)(this.GetItem("tbEndDt").Specific));
            //                 this.tbEndDt.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.LoadSOetails);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.tbContctPerson = ((SAPbouiCOM.EditText)(this.GetItem("tbCnctNm").Specific));
            this.f_General = ((SAPbouiCOM.Folder)(this.GetItem("f_General").Specific));
            this.f_General.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.f_General_PressedAfter);
            this.btnOk = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnOk.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnOk_PressedAfter);
            this.btnOk.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnOk_PressedBefore);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.f_Machine = ((SAPbouiCOM.Folder)(this.GetItem("f_Machine").Specific));
            this.f_Machine.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.f_Machine_PressedAfter);
            this.f_Document = ((SAPbouiCOM.Folder)(this.GetItem("f_Docmnt").Specific));
            this.f_Document.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.f_Document_PressedAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.cmbContractTyp = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbConTyp").Specific));
            this.cmbContractTyp.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.cmbContractTyp_ComboSelectAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("cmbBilCyc").Specific));
            this.cmbBillingCycle = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbBilCy").Specific));
            this.cmbBillingCycle.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.cmbBillingCycle_ComboSelectAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.tbSoDocNo = ((SAPbouiCOM.EditText)(this.GetItem("tbSoDocNo").Specific));
            this.tbSoDocNo.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbSoDocNo_ChooseFromListBefore);
            this.tbSoDocNo.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbSoDocNo_ChooseFromListAfter);
            this.tbCnctVal = ((SAPbouiCOM.EditText)(this.GetItem("tbCnctVal").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.tbContractNo = ((SAPbouiCOM.EditText)(this.GetItem("tbContNo").Specific));
            this.tbContractNo.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbContractNo_ChooseFromListBefore);
            this.tbContractNo.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbContractNo_ChooseFromListAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.tbInterestRate = ((SAPbouiCOM.EditText)(this.GetItem("tbIntRt").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_31").Specific));
            this.tbRevenueRegAct = ((SAPbouiCOM.EditText)(this.GetItem("tbRegAct").Specific));
            this.tbRevenueRegAct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbRevenueRegAct_ChooseFromListAfter);
            this.tbRevenueRegAct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbRevenueRegAct_ChooseFromBeforeAfter);
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_33").Specific));
            this.tbRevenueAct = ((SAPbouiCOM.EditText)(this.GetItem("tbRevAct").Specific));
            this.tbRevenueAct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbRevenueAct_ChooseFromListAfter);
            this.tbRevenueAct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbRevenueAct_ChooseFromBeforeAfter);
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_35").Specific));
            this.tbInterestAct = ((SAPbouiCOM.EditText)(this.GetItem("tbIntAct").Specific));
            this.tbInterestAct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbInterestAct_ChooseFromListAfter);
            this.tbInterestAct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbInterestAct_ChooseFromBeforeAfter);
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_37").Specific));
            this.tbDiffIntAct = ((SAPbouiCOM.EditText)(this.GetItem("tbDifIAct").Specific));
            this.tbDiffIntAct.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbDiffIntAct_ChooseFromListAfter);
            this.tbDiffIntAct.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.tbDiffIntAct_ChooseFromBeforeAfter);
            this.mtx_Item = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_Item").Specific));
            this.mtx_Item.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.mtx_Item_ChooseFromListBefore);
            this.mtx_Item.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.mtx_Item_ChooseFromListAfter);
            this.mtx_Doc = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_Doc").Specific));
            this.mtx_Doc.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.mtx_Doc_ChooseFromListAfter);
            this.mtx_Doc.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.mtx_Doc_ComboSelectAfter);
            this.lb_Cust = ((SAPbouiCOM.LinkedButton)(this.GetItem("lb_Cust").Specific));
            this.lb_SoNo = ((SAPbouiCOM.LinkedButton)(this.GetItem("lb_SoNo").Specific));
            //   this.lb_SoNo.PressedAfter += new SAPbouiCOM._ILinkedButtonEvents_PressedAfterEventHandler(this.lb_SoNo_PressedAfter);
            this.lb_ContNo = ((SAPbouiCOM.LinkedButton)(this.GetItem("lb_ContNo").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.cmbBillDay = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbDay").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.txtBillStartDate = ((SAPbouiCOM.EditText)(this.GetItem("tbBillstDt").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_16").Specific));
            this.ComboBox3.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox3_ComboSelectAfter);
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.mtx_LB = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_LB").Specific));
            this.f_Lease = ((SAPbouiCOM.Folder)(this.GetItem("f_Lease").Specific));
            this.f_Lease.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.f_Lease_PressedAfter);
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.tbSerCnctVal = ((SAPbouiCOM.EditText)(this.GetItem("tbSerVal").Specific));
            this.StaticText23 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.tbItmCode = ((SAPbouiCOM.EditText)(this.GetItem("tbItmCode").Specific));
            this.tbItmCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbItemCode_ChooseFromListAfter);
            this.StaticText24 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.tbItmDesc = ((SAPbouiCOM.EditText)(this.GetItem("tbItmDesc").Specific));
            this.StaticText27 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.tbItmLR = ((SAPbouiCOM.EditText)(this.GetItem("tbItmLR").Specific));
            this.tbItmLR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.tbItemCodeLR_ChooseFromListAfter);
            this.StaticText28 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
            this.tbItmDsLR = ((SAPbouiCOM.EditText)(this.GetItem("tbItmDsLR").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("lblPymtTr").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("lblLease").Specific));
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("lblReve").Specific));
            this.LinkedButton3 = ((SAPbouiCOM.LinkedButton)(this.GetItem("lblInt").Specific));
            this.LinkedButton5 = ((SAPbouiCOM.LinkedButton)(this.GetItem("lblDfr").Specific));
            this.StaticText25 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.StaticText26 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_26").Specific));
            this.StaticText29 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_34").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_38").Specific));
            this.StaticText30 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_36").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_39").Specific));
            this.StaticText31 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_40").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_41").Specific));
            this.StaticText32 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_42").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_44").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_43").Specific));
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
            this.UIAPIRawForm.Items.Item("tbLContNo").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.Items.Item("tbLContNo").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoFormMode.fm_FIND_MODE, SAPbouiCOM.BoModeVisualBehavior.mvb_True);

            oDBs_Head = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_OLCM");
            oDBs_LCIT = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_LCIT");
            ODBs_LCDD = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_LCDD");
            ODBS_LCLB = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_LCLB");

            code = B1Helper.GetNextCodeId("@Z_OLCM");

            oDBs_Head.SetValue("Code", 0, code.ToString());
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Item").Specific;
            AddMatrixNewLine("mtx_Item", oMatrix);
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Doc").Specific;
            AddMatrixNewLine("mtx_Doc", oMatrix);
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_LB").Specific;
            AddMatrixNewLine("mtx_LB", oMatrix);

            this.UIAPIRawForm.EnableMenu("1281", true);
            this.UIAPIRawForm.EnableMenu("1282", true);

            this.UIAPIRawForm.EnableMenu("1288", true);
            this.UIAPIRawForm.EnableMenu("1289", true);
            this.UIAPIRawForm.EnableMenu("1290", true);
            this.UIAPIRawForm.EnableMenu("1291", true);

            this.ComboBox3.Select('A', SAPbouiCOM.BoSearchKey.psk_Index);
            this.cmbContractTyp.Select('F', SAPbouiCOM.BoSearchKey.psk_Index);

            this.GetItem("tbItmCode").Enabled = false;
            this.GetItem("tbItmDesc").Enabled = false;
            this.GetItem("Item_34").Enabled = false;

            //this.GetItem("tbItmLR").Enabled = false;
            //this.GetItem("tbItmDsLR").Enabled = false;
            //this.GetItem("tbRegAct").Enabled = false;
            //this.GetItem("tbRevAct").Enabled = false;
            //this.GetItem("tbIntAct").Enabled = false;
            //this.GetItem("tbDifIAct").Enabled = false;

            //this.UIAPIRawForm.DataBrowser.BrowseBy = "tbLContNo";
            this.UIAPIRawForm.DataBrowser.BrowseBy = "Item_43";


        }
        private void btnOk_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {

            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                if (Validation())
                {
                    BubbleEvent = false;
                    return;
                }

                //AddJournalEntry();
            }
            BubbleEvent = true;
        }
        private bool MonthlyValidation()
        {
            if (this.tbStrtDt.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Start Date", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            return false;
        }
        private bool Validation()
        {
            if (this.tbCustCd.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Select Customer Code", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            if (this.tbStrtDt.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Start Date", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            if (this.tbSoDocNo.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Select SO No", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            if (this.cmbContractTyp.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Select Contract Type", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            if (this.cmbBillingCycle.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Select Billing Cycle", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            if (this.cmbContractTyp.Value == "F")
            {
                if (this.tbItmLR.Value == string.Empty)
                {
                    Application.SBO_Application.SetStatusBarMessage("Please Select Item Code", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    return true;
                }
            }
            if (this.cmbContractTyp.Value == "O")
            {
                if (this.tbItmCode.Value == string.Empty)
                {
                    Application.SBO_Application.SetStatusBarMessage("Please Select Item Code", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    return true;
                }
            }

            return false;
        }

        private void AddJournalEntry()
        {
            bool isposted = false;
            string sContracttype = string.Empty;
            string sLeaseAcct = string.Empty;
            string sRevenueAcct = string.Empty;
            string sInterestAcc = string.Empty;
            string sDifferedIntAcc = string.Empty;

            sContracttype = cmbContractTyp.Value;
            sLeaseAcct = tbRevenueRegAct.Value;
            sRevenueAcct = tbRevenueAct.Value;
            sInterestAcc = tbInterestAct.Value;
            sDifferedIntAcc = tbDiffIntAct.Value;

            Decimal interset = tempInterestValue;
            Decimal Total = temptotalValue;
            Decimal MonthlyValue = tempmonthlyValue;
            var startDate = this.tbStrtDt.Value;

            //tbItmLR
            //tbItmDsLR
            SAPbobsCOM.JournalEntries oJE = (SAPbobsCOM.JournalEntries)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oJournalEntries);
            if (sContracttype == "F")
            {
                //Delivery Book
                oJE.DueDate = DateTime.Now;
                oJE.ReferenceDate = DateTime.Now;
                oJE.TaxDate = DateTime.Now;
                //oJE.Series = 1023;
                oJE.Memo = "";

                // first line  //Trsfr receivable
                oJE.Lines.ShortName = sLeaseAcct;
                oJE.Lines.Credit = 0;
                oJE.Lines.Debit = Convert.ToDouble(tbCnctVal.Value);
                oJE.Lines.DueDate = DateTime.Now;
                oJE.Lines.TaxDate = DateTime.Now;
                oJE.Lines.ReferenceDate1 = DateTime.Now;

                //second line //Trsfr receivable
                oJE.Lines.Add();
                oJE.Lines.ShortName = sRevenueAcct;
                oJE.Lines.Credit = Convert.ToDouble(tbCnctVal.Value);
                oJE.Lines.Debit = 0;
                oJE.Lines.DueDate = DateTime.Now;
                oJE.Lines.TaxDate = DateTime.Now;
                oJE.Lines.ReferenceDate1 = DateTime.Now;

                //************************  Commented on 17Apr2018 -Start
                //////Third Line //Trsfr receivable
                ////oJE.Lines.Add();
                ////oJE.Lines.ShortName = sLeaseAcct;
                ////oJE.Lines.Debit = Convert.ToDouble(Total);
                ////oJE.Lines.Credit = 0;
                ////oJE.Lines.DueDate = DateTime.Now;
                ////oJE.Lines.TaxDate = DateTime.Now;
                ////oJE.Lines.ReferenceDate1 = DateTime.Now;

                //////Fourth Line //Trsfr receivable
                ////oJE.Lines.Add();
                ////oJE.Lines.ShortName = sRevenueAcct;
                ////oJE.Lines.Debit = 0;
                ////oJE.Lines.Credit = Convert.ToDouble(Total);
                ////oJE.Lines.DueDate = DateTime.Now;
                ////oJE.Lines.TaxDate = DateTime.Now;
                ////oJE.Lines.ReferenceDate1 = DateTime.Now;
                //************************  Commented on 17Apr2018 -End

                //Fifth Line //Trsfr receivable
                oJE.Lines.Add();
                oJE.Lines.ShortName = sRevenueAcct;
                oJE.Lines.Debit = Convert.ToDouble(interset);
                oJE.Lines.Credit = 0;
                oJE.Lines.DueDate = DateTime.Now;
                oJE.Lines.TaxDate = DateTime.Now;
                oJE.Lines.ReferenceDate1 = DateTime.Now;

                //Sixth Line //Trsfr receivable
                oJE.Lines.Add();
                oJE.Lines.ShortName = sDifferedIntAcc;
                oJE.Lines.Debit = 0;
                oJE.Lines.Credit = Convert.ToDouble(interset);
                oJE.Lines.DueDate = DateTime.Now;
                oJE.Lines.TaxDate = DateTime.Now;
                oJE.Lines.ReferenceDate1 = DateTime.Now;

                // add journal entry

                if (oJE.Add() == 0)
                {

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

        }
        private void btnOk_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void tbCustCd_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    string cardCode = pCFL.SelectedObjects.GetValue("CardCode", 0).ToString();
                    oDBs_Head.SetValue("U_CustomerCode", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("CardCode", 0).ToString());
                    oDBs_Head.SetValue("U_CustomerName", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("CardName", 0).ToString());

                    SAPbobsCOM.BusinessPartners objCust = (SAPbobsCOM.BusinessPartners)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    if (objCust.GetByKey(cardCode))
                    {
                        oDBs_Head.SetValue("U_ContctCode", oDBs_Head.Offset, objCust.ContactPerson);
                    }

                }
            }
        }

        //******************************** Addedb by Shibin - 06 Apr 2018 - Start *************************
        private void LoadBillStartDate(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            var startDate = this.tbStrtDt.Value;
            oDBs_Head.SetValue("U_BillStartDate", oDBs_Head.Offset, startDate.ToString());
        }
        //******************************** Addedb by Shibin - 06 Apr 2018 - End *************************

        private void lb_SoNo_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //String iSONo = this.tbSoDocNo.Value;
            //string Query = "select T0.\"DocEntry\" from ORDR T0 inner join OCTG T1 on T1.\"GroupNum\" = T0.\"GroupNum\" inner Join RDR1 T2 on T0.\"DocEntry\" = T2.\"DocEntry\"  where T0.\"DocNum\" = '" + iSONo + "'  and T2.\"ItemCode\" = 'INTREB'";
            //SAPbobsCOM.Recordset rsPaydtls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            //rsPaydtls.DoQuery(Query);
            //if (rsPaydtls.RecordCount > 0)
            //{
            //    string docentry = rsPaydtls.Fields.Item("DocEntry").Value.ToString();
            //}
            //this.UIAPIRawForm.Items.Item("Item_38").Specific = 1;
        }
        private void tbSoDocNo_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                //******************************** Addedb by Shibin - 06 Apr 2018 - Start *************************
                string payTerms = null;
                Decimal interest = 0.0M;
                int instNum = 0;
                int year = 0;
                Decimal interstValue = 0.0M;
                Decimal monthlyValue = 0.0M;
                Decimal totalValue = 0.0M;
                Decimal docValue = 0.0M;
                Double interstAmt = 0.0;
                Double LoanAmt = 0.0;
                //******************************** Addedb by Shibin - 06 Apr 2018 - End *************************

                int docNo = int.Parse(pCFL.SelectedObjects.GetValue("DocEntry", 0).ToString());



                //******************************** Addedb by Shibin - 06 Apr 2018 - Start *************************

                //get Payment Terms and Interst Amt
                //string Query = "select T1.\"PymntGroup\",T1.\"LatePyChrg\",T1.\"InstNum\" from ORDR T0 inner join OCTG T1 on T1.\"GroupNum\" = T0.\"GroupNum\" where T0.\"DocEntry\" = '" + docNo + "' ";
                string Query = "select T1.\"PymntGroup\",T1.\"LatePyChrg\",T1.\"InstNum\",T2.\"LineTotal\"  from ORDR T0 inner join OCTG T1 on T1.\"GroupNum\" = T0.\"GroupNum\" inner Join RDR1 T2 on T0.\"DocEntry\" = T2.\"DocEntry\"  where T0.\"DocEntry\" = '" + docNo + "'  and T2.\"ItemCode\" = 'INTREB'";
                SAPbobsCOM.Recordset rsPaydtls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsPaydtls.DoQuery(Query);

                //get Sale order Value
                SAPbobsCOM.Documents objOrdr = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);

                if (objOrdr.GetByKey(docNo))
                {
                    //oDBs_Head.SetValue("U_ContractValue", oDBs_Head.Offset, objOrdr.DocTotal.ToString());

                    docValue = Convert.ToDecimal(objOrdr.DocTotal.ToString());
                    if (rsPaydtls.RecordCount > 0)
                    {
                        payTerms = rsPaydtls.Fields.Item("PymntGroup").Value.ToString();
                        interest = Convert.ToDecimal(rsPaydtls.Fields.Item("LatePyChrg").Value.ToString());
                        instNum = int.Parse(rsPaydtls.Fields.Item("InstNum").Value.ToString());
                        interstAmt = Convert.ToDouble(rsPaydtls.Fields.Item("LineTotal").Value.ToString());

                        tempinst = instNum;
                        year = instNum / 12;
                        interstValue = (docValue * interest / 100) * year;
                        totalValue = interstValue + docValue;
                        //monthlyValue = totalValue / instNum;
                        monthlyValue = docValue / instNum;
                        LoanAmt = Convert.ToDouble(docValue) - interstAmt;

                        tempInterestValue = interstValue;
                        temptotalValue = totalValue;
                        tempmonthlyValue = monthlyValue;
                        tempInterestAmt = interstAmt;
                        tempLoanAmt = LoanAmt;

                        oDBs_Head.SetValue("U_PaymentTerms", oDBs_Head.Offset, payTerms.ToString());
                        oDBs_Head.SetValue("U_InterestRate", oDBs_Head.Offset, interest.ToString());
                        //oDBs_Head.SetValue("U_ContractValue", oDBs_Head.Offset, totalValue.ToString());
                        oDBs_Head.SetValue("U_MonthlyValue", oDBs_Head.Offset, monthlyValue.ToString());
                        oDBs_Head.SetValue("U_InterestAmt", oDBs_Head.Offset, tempInterestAmt.ToString());
                        oDBs_Head.SetValue("U_LoanAmt", oDBs_Head.Offset, tempLoanAmt.ToString());
                    }
                    oDBs_Head.SetValue("U_SODocNo", oDBs_Head.Offset, objOrdr.DocNum.ToString());
                    oDBs_Head.SetValue("U_DocEntry", oDBs_Head.Offset, objOrdr.DocEntry.ToString());
                    oDBs_Head.SetValue("U_ContractValue", oDBs_Head.Offset, objOrdr.DocTotal.ToString());
                    tempBalance = Convert.ToDecimal(objOrdr.DocTotal);

                }
                //******************************** Addedb by Shibin - 06 Apr 2018 - End *************************

                //oDBs_Head.SetValue("U_ContractValue", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue(0, 0).ToString());
            }
        }

        private void tbContractNo_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                //Decimal ServiceTotal = 0.00M;
                oDBs_Head.SetValue("U_ContractNo", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue(0, 0).ToString());
                String ContractNo = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                string Query = "select sum(\"U_TotalPrice\") \"Price\" from \"@Z_OSRP\" T0 left  join \"@Z_SRP1\"  T1 on T1.\"Code\" = T0.\"Code\" where \"U_ContractNo\" ='" + ContractNo + "'";

                SAPbobsCOM.Recordset rsPricedtls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsPricedtls.DoQuery(Query);
                if (rsPricedtls.RecordCount > 0)
                {
                    oDBs_Head.SetValue("U_ServiceTotal", oDBs_Head.Offset, rsPricedtls.Fields.Item(0).Value.ToString());
                }

                //load Item Details From Service Contract based on Contract No
                LoadItemDetails(pCFL.SelectedObjects.GetValue(0, 0).ToString());

            }

        }


        private void LoadItemDetails(string ContractNo)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.GetItem("mtx_Item").Specific;
            string Query = "SELECT T1.\"Line\", T1.\"ItemCode\", T1.\"ItemName\", T1.\"ManufSN\" " +
                           " FROM OCTR T0  INNER JOIN CTR1 T1 ON T0.\"ContractID\" = T1.\"ContractID\" " +
                           " WHERE T1.\"ContractID\" ='" + ContractNo + "'";
            SAPbobsCOM.Recordset rsItemdtls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsItemdtls.DoQuery(Query);
            if (rsItemdtls.RecordCount > 0)
            {
                while (rsItemdtls.EoF == false)
                {
                    if (oMatrix.RowCount == 0) oMatrix.AddRow();
                    oDBs_LCIT.SetValue("LineId", oDBs_LCIT.Offset, rsItemdtls.Fields.Item(0).Value.ToString());
                    oDBs_LCIT.SetValue("U_ItemCode", oDBs_LCIT.Offset, rsItemdtls.Fields.Item(1).Value.ToString());
                    oDBs_LCIT.SetValue("U_ItemDescp", oDBs_LCIT.Offset, rsItemdtls.Fields.Item(2).Value.ToString());
                    oDBs_LCIT.SetValue("U_Quantity", oDBs_LCIT.Offset, "");
                    oDBs_LCIT.SetValue("U_SerialNo", oDBs_LCIT.Offset, rsItemdtls.Fields.Item(3).Value.ToString());
                    oMatrix.SetLineData(oMatrix.VisualRowCount);

                    rsItemdtls.MoveNext();
                }

            }
        }


        private void tbItemCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {

                oDBs_Head.SetValue("U_ItemCode", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("ItemCode", 0).ToString());
                oDBs_Head.SetValue("U_ItemDesc", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("ItemName", 0).ToString());
            }

        }
        private void tbItemCodeLR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {

                oDBs_Head.SetValue("U_ItemCodeLR", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("ItemCode", 0).ToString());
                oDBs_Head.SetValue("U_ItemDescLR", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("ItemName", 0).ToString());
            }

        }

        private void tbRevenueRegAct_ChooseFromBeforeAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

            if (ppVal.ChooseFromListUID == "CFL_Reg")
            {
                oCondition.Alias = "Postable";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";
                oChooseFromList.SetConditions(oConditions);
            }
        }
        private void tbRevenueRegAct_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_RevRecogAcct", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
            }

        }


        private void tbRevenueAct_ChooseFromBeforeAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

            if (ppVal.ChooseFromListUID == "CFL_Rev")
            {
                oCondition.Alias = "Postable";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";
                oChooseFromList.SetConditions(oConditions);
            }
        }

        private void tbRevenueAct_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {



                oDBs_Head.SetValue("U_RevenueAcct", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
            }
        }


        private void tbInterestAct_ChooseFromBeforeAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

            if (ppVal.ChooseFromListUID == "CFL_Int")
            {
                oCondition.Alias = "Postable";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";
                oChooseFromList.SetConditions(oConditions);
            }
        }
        private void tbInterestAct_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_InterestAcct", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
            }
        }


        private void tbDiffIntAct_ChooseFromBeforeAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

            if (ppVal.ChooseFromListUID == "CFL_DifI")
            {
                oCondition.Alias = "Postable";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";
                oChooseFromList.SetConditions(oConditions);
            }
        }
        private void tbDiffIntAct_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_DiffInterestAcct", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("AcctCode", 0).ToString());
            }
        }

        private void mtx_Item_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Item").Specific;
            if (pVal.ColUID == "Col_0" || pVal.ColUID == "Col_3")
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.ChooseFromListUID == "CFL_Item")
                {

                    if (pCFL.SelectedObjects != null)
                    {
                        oDBs_LCIT.SetValue("LineId", oDBs_LCIT.Offset, pVal.Row.ToString());
                        oDBs_LCIT.SetValue("U_ItemCode", oDBs_LCIT.Offset, pCFL.SelectedObjects.GetValue("ItemCode", 0).ToString());
                        oDBs_LCIT.SetValue("U_ItemDescp", oDBs_LCIT.Offset, pCFL.SelectedObjects.GetValue("ItemName", 0).ToString());
                        oDBs_LCIT.SetValue("U_Quantity", oDBs_LCIT.Offset, "");
                        oDBs_LCIT.SetValue("U_SerialNo", oDBs_LCIT.Offset, "");
                        oMatrix.SetLineData(pVal.Row);
                    }
                }

                if (pCFL.ChooseFromListUID == "CFL_SrNo")
                {
                    if (pCFL.SelectedObjects != null)
                    {
                        oDBs_LCIT.SetValue("LineId", oDBs_LCIT.Offset, pVal.Row.ToString());
                        oDBs_LCIT.SetValue("U_ItemCode", oDBs_LCIT.Offset, ((SAPbouiCOM.EditText)oMatrix.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value);
                        oDBs_LCIT.SetValue("U_ItemDescp", oDBs_LCIT.Offset, ((SAPbouiCOM.EditText)oMatrix.Columns.Item("Col_1").Cells.Item(pVal.Row).Specific).Value);
                        oDBs_LCIT.SetValue("U_Quantity", oDBs_LCIT.Offset, ((SAPbouiCOM.EditText)oMatrix.Columns.Item("Col_2").Cells.Item(pVal.Row).Specific).Value);
                        oDBs_LCIT.SetValue("U_SerialNo", oDBs_LCIT.Offset, pCFL.SelectedObjects.GetValue("internalSN", 0).ToString());
                        oMatrix.SetLineData(pVal.Row);

                        if (pVal.Row == oMatrix.VisualRowCount && AreAllColumnsFilled(oMatrix, pVal.Row))
                        {
                            AddMatrixNewLine("mtx_Item", oMatrix);
                        }
                    }
                }
            }
        }

        private void AddMatrixNewLine(string mtxUID, SAPbouiCOM.Matrix matrxControl)
        {
            if (mtxUID == "mtx_Item")
            {
                matrxControl.AddRow();
                oDBs_LCIT.SetValue("LineId", oDBs_LCIT.Offset, matrxControl.VisualRowCount.ToString());
                oDBs_LCIT.SetValue("U_ItemCode", oDBs_LCIT.Offset, "");
                oDBs_LCIT.SetValue("U_ItemDescp", oDBs_LCIT.Offset, "");
                oDBs_LCIT.SetValue("U_Quantity", oDBs_LCIT.Offset, "");
                oDBs_LCIT.SetValue("U_SerialNo", oDBs_LCIT.Offset, "");
                matrxControl.SetLineData(matrxControl.VisualRowCount);
            }

            if (mtxUID == "mtx_Doc")
            {
                matrxControl.AddRow();
                ODBs_LCDD.SetValue("LineId", ODBs_LCDD.Offset, matrxControl.VisualRowCount.ToString());
                ODBs_LCDD.SetValue("U_DocType", ODBs_LCDD.Offset, "");
                ODBs_LCDD.SetValue("U_DocNo", ODBs_LCDD.Offset, "");
                ODBs_LCDD.SetValue("U_DocDate", ODBs_LCDD.Offset, "");
                ODBs_LCDD.SetValue("U_DocStatus", ODBs_LCDD.Offset, "");
                matrxControl.SetLineData(matrxControl.VisualRowCount);
            }
            if (mtxUID == "mtx_LB")
            {
                matrxControl.AddRow();
                ODBS_LCLB.SetValue("LineId", ODBS_LCLB.Offset, matrxControl.VisualRowCount.ToString());
                ODBS_LCLB.SetValue("U_Interval", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_LBDate", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_LeaseBilling", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_Status", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_InvoiceNo", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_Posted", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_Balance", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_Principal", ODBS_LCLB.Offset, "");
                ODBS_LCLB.SetValue("U_Interest", ODBS_LCLB.Offset, "");
                matrxControl.SetLineData(matrxControl.VisualRowCount);
            }
        }

        private void mtx_Doc_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Doc").Specific;
            oComboBox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific;
            int rowNo = pVal.Row;
            if (pVal.ColUID == "Col_0")
            {
                if (oComboBox.Value != string.Empty)
                {

                    ODBs_LCDD.SetValue("LineId", ODBs_LCDD.Offset, pVal.Row.ToString());
                    ODBs_LCDD.SetValue("U_DocType", ODBs_LCDD.Offset, oComboBox.Value);
                    ODBs_LCDD.SetValue("U_DocNo", ODBs_LCDD.Offset, "");
                    ODBs_LCDD.SetValue("U_DocDate", ODBs_LCDD.Offset, "");
                    ODBs_LCDD.SetValue("U_DocStatus", ODBs_LCDD.Offset, "");
                    oMatrix.SetLineData(pVal.Row);

                    if (oComboBox.Value == "13")
                    {
                        AddChooseFromList("13", "CFL_IN", oMatrix, rowNo);
                    }

                    if (oComboBox.Value == "14")
                    {
                        AddChooseFromList("14", "CFL_CM", oMatrix, rowNo);
                    }
                    if (oComboBox.Value == "17")
                    {
                        AddChooseFromList("17", "CFL_SO", oMatrix, rowNo);
                    }

                    if (oComboBox.Value == "203")
                    {
                        AddChooseFromList("203", "CFL_DP", oMatrix, rowNo);
                    }


                }
            }
        }

        private void AddChooseFromList(string objectType, string CFLUID, SAPbouiCOM.Matrix omtxContrl, int rowNo)
        {
            try
            {
                SAPbouiCOM.ChooseFromListCollection oCFLs;
                oCFLs = this.UIAPIRawForm.ChooseFromLists;
                SAPbouiCOM.ChooseFromList oCFL;
                SAPbouiCOM.ChooseFromListCreationParams oCFLCreationParams;
                oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
                oCFLCreationParams.MultiSelection = false;
                oCFLCreationParams.ObjectType = objectType;
                oCFLCreationParams.UniqueID = CFLUID;
                oCFL = oCFLs.Add(oCFLCreationParams);

                var ocolumn = (SAPbouiCOM.Column)omtxContrl.Columns.Item("Col_1");
                ocolumn.ChooseFromListUID = CFLUID;
                ocolumn.ChooseFromListAlias = "DocNum";

            }
            catch
            {
                //   MsgBox(Err.Description);
            }
        }

        private void LoadMonthDayValues()
        {
            //load all 31 days in dropdown
            if (cmbBillDay.ValidValues.Count > 0)
            {
                for (int iDay = 31; iDay >= 1; iDay--)
                {
                    cmbBillDay.ValidValues.Remove(iDay.ToString(), SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
            }

            for (int iDay = 1; iDay <= 31; iDay++)
            {
                cmbBillDay.ValidValues.Add(iDay.ToString(), iDay.ToString());
            }



        }
        private void mtx_Doc_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Doc").Specific;
            oComboBox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific;
            if (pVal.ColUID == "Col_1")
            {
                if (oComboBox.Selected.Value != string.Empty)
                {

                }
            }
        }

        private void mtx_Item_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Item").Specific;
            BubbleEvent = true;

            if (pVal.ColUID == "Col_0" || pVal.ColUID == "Col_3")
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

                if (ppVal.ChooseFromListUID == "CFL_Item")
                {
                    oCondition.Alias = "ManSerNum";
                    oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCondition.CondVal = "Y";
                    oChooseFromList.SetConditions(oConditions);
                }
                else if (ppVal.ChooseFromListUID == "CFL_SrNo")
                {
                    oCondition.Alias = "itemCode";
                    oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCondition.CondVal = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value;
                    oChooseFromList.SetConditions(oConditions);
                }
            }


        }

        private void f_Machine_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.UIAPIRawForm.PaneLevel = 2;
            // oDBs_Head.SetValue("Code", 0, code.ToString());

        }

        private void f_Document_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.UIAPIRawForm.PaneLevel = 3;
            // oDBs_Head.SetValue("Code", 0, tbLeaseContctNo.Value);

        }

        private void tbSoDocNo_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

                oCondition.Alias = "CardCode";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = tbCustCd.Value;
                oChooseFromList.SetConditions(oConditions);

                //oCondition.Alias = "DocStatus";
                //oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                //oCondition.CondVal = "O";
                //oChooseFromList.SetConditions(oConditions);

            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }

        }

        private void tbContractNo_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

                oCondition.Alias = "CstmrCode";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = tbCustCd.Value;
                oChooseFromList.SetConditions(oConditions);
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
            }
        }

        private void f_General_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.UIAPIRawForm.PaneLevel = 1;
        }
        private void cmbContractTyp_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            if (cmbContractTyp.Value != string.Empty)
            {

                if (cmbContractTyp.Value == "F")
                {
                    this.GetItem("tbItmLR").Enabled = true;
                    this.GetItem("tbItmDsLR").Enabled = true;
                    this.GetItem("tbRegAct").Enabled = true;
                    this.GetItem("tbRevAct").Enabled = true;
                    this.GetItem("tbIntAct").Enabled = true;
                    this.GetItem("tbDifIAct").Enabled = true;

                    this.GetItem("tbItmCode").Enabled = false;
                    this.GetItem("tbItmDesc").Enabled = false;

                    this.tbItmCode.Value = "";
                    this.tbItmDesc.Value = "";


                }
                else
                {
                    this.GetItem("tbItmCode").Enabled = true;
                    this.GetItem("tbItmDesc").Enabled = true;

                    this.GetItem("tbItmLR").Enabled = false;
                    this.GetItem("tbItmDsLR").Enabled = false;
                    this.GetItem("tbRegAct").Enabled = false;
                    this.GetItem("tbRevAct").Enabled = false;
                    this.GetItem("tbIntAct").Enabled = false;
                    this.GetItem("tbDifIAct").Enabled = false;

                    this.tbItmLR.Value = "";
                    this.tbItmDsLR.Value = "";
                    this.tbRevenueRegAct.Value = "";
                    this.tbRevenueAct.Value = "";
                    this.tbInterestAct.Value = "";
                    this.tbDiffIntAct.Value = "";

                }
            }

        }

        private void ComboBox3_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (ComboBox3.Value == "T")
            {
                this.GetItem("Item_34").Enabled = true;

            }
            else
            {
                this.GetItem("Item_34").Enabled = false;
            }

        }

        private void cmbBillingCycle_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_LB").Specific;
            int rowNo = pVal.Row;
            var startDate = this.tbStrtDt.Value;
            var startDateBill = this.txtBillStartDate.Value;
            Decimal monthlyvalue = 0;
            Double Balance = 0.00;
            Decimal totalvalue = 0;
            int instNum = 0;
            //Decimal Balance = this.tbCnctVal.Value;
            if (tempmonthlyValue == 0)
            {
                monthlyvalue = Convert.ToDecimal(this.EditText3.Value);                 
            }
            else
            {
                monthlyvalue = tempmonthlyValue;
            }
            

            //Double Balance = Convert.ToDouble(tempBalance);
            if (tempLoanAmt == 0.00)
            {
                Balance = Convert.ToDouble(this.EditText4.Value); 
            }
            else
            {
                Balance = tempLoanAmt;                
            }


            if (temptotalValue == 0)
            {
                totalvalue = Convert.ToDecimal(this.tbCnctVal.Value) + Convert.ToDecimal(this.EditText0.Value);                
            }
            else
            {
                totalvalue = temptotalValue;
            }
            //Decimal 

            Double tempinnerBalance = 0.00;
            Double tempinnerInterest = 0.00;
            Double tempinnerPrincipal = 0.00;

            Double tempinnerBalanceQ = 0.00;
            Double tempinnerInterestQ = 0.00;
            Double tempinnerPrincipalQ = 0.00;

            String iSONo = this.tbSoDocNo.Value;
            if (tempinst == 0)
            {
                string Query = "select T1.\"PymntGroup\",T1.\"LatePyChrg\",T1.\"InstNum\",T2.\"LineTotal\"  from ORDR T0 inner join OCTG T1 on T1.\"GroupNum\" = T0.\"GroupNum\" inner Join RDR1 T2 on T0.\"DocEntry\" = T2.\"DocEntry\"  where T0.\"DocNum\" = '" + iSONo + "'  and T2.\"ItemCode\" = 'INTREB'";
                SAPbobsCOM.Recordset rsPaydtls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsPaydtls.DoQuery(Query);

                if (rsPaydtls.RecordCount > 0)
                {

                    instNum = int.Parse(rsPaydtls.Fields.Item("InstNum").Value.ToString());

                }

            }
            else
            {
                instNum = tempinst;
            }
            //BubbleEvent = true;
            //if (MonthlyValidation())
            //{
            //    //BubbleEvent = false;
            //    return;
            //}
            MonthlyValidation();

            if (cmbBillingCycle.Value != string.Empty)
            {
                this.GetItem("cmbDay").Enabled = false;
                if (cmbBillingCycle.Value == "M" && startDate != string.Empty)
                {
                    //int instNumEnd = instNum - 1;
                    int instNumEnd = instNum ;
                    ////SQL                    
                    //string endDateQuery = "SELECT CONVERT(VARCHAR(10), DATEADD(month," + instNumEnd + ", '" + startDate + "' ), 112)\"Date\"";

                    //HANA                    
                    string endDateQuery = "SELECT  ADD_DAYS(ADD_MONTHS (TO_DATE ('" + startDate + "', 'YYYYMMDD')," + instNumEnd + "),-1) \"Date\" FROM DUMMY";

                    SAPbobsCOM.Recordset rsEndDate = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rsEndDate.DoQuery(endDateQuery);
                    if (rsEndDate.RecordCount > 0)
                    {
                        ////SQL
                        //oDBs_Head.SetValue("U_EndDate", ODBS_LCLB.Offset, rsEndDate.Fields.Item("Date").Value.ToString());

                        //HANA
                        DateTime endDate = Convert.ToDateTime(rsEndDate.Fields.Item("Date").Value.ToString().Trim());
                        String dateend = endDate.ToString("yyyyMMdd");
                        oDBs_Head.SetValue("U_EndDate", oDBs_Head.Offset, dateend);
                    }

                    if (oMatrix.RowCount > 0)
                    {
                        oMatrix.Clear();
                        oMatrix.AddRow();
                    }

                    oDBs_Head.SetValue("U_BillInterval", oDBs_Head.Offset, instNum.ToString());
                    Double CalcRetRate = 0.0;
                    if (cmbContractTyp.Value == "F")
                    {
                        //IRR Calc
                        Double[] array = new Double[instNum + 1];
                        for (int i = 0; i <= instNum; i++)
                        {
                            if (array[i] == array[0])
                            {
                                array[i] = Balance;
                            }

                            else if (array[i] != array[0])
                            {

                                //array[i] = -516.67;//For Check
                                array[i] = Convert.ToDouble(-monthlyvalue);
                            }

                        }
                        CalcRetRate = Microsoft.VisualBasic.Financial.IRR(ref array, 0.01) * 100;
                    }

                    for (int iDay = 0; iDay <= instNum - 1; iDay++)
                    {
                        int rowNo1 = oMatrix.RowCount;

                        ////SQL
                        //string Query = "SELECT CONVERT(VARCHAR(10), DATEADD(month," + iDay + ", '" + startDate + "' ), 112)\"Date\"";

                        //HANA
                        string Query = "SELECT ADD_MONTHS (TO_DATE ('" + startDateBill + "', 'YYYYMMDD')," + iDay + ") \"Date\" FROM DUMMY";

                        SAPbobsCOM.Recordset rsLeasetls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        rsLeasetls.DoQuery(Query);
                        if (rsLeasetls.RecordCount > 0)
                        {
                            while (rsLeasetls.EoF == false)
                            {

                                //HANA
                                DateTime LBDate = Convert.ToDateTime(rsLeasetls.Fields.Item("Date").Value.ToString().Trim());
                                String dateLB = LBDate.ToString("yyyyMMdd");

                                ODBS_LCLB.SetValue("LineId", ODBS_LCLB.Offset, rowNo1.ToString());
                                ODBS_LCLB.SetValue("U_Interval", ODBS_LCLB.Offset, rowNo1.ToString());
                                ODBS_LCLB.SetValue("U_LeaseBilling", ODBS_LCLB.Offset, monthlyvalue.ToString());
                                try
                                {
                                    ////SQL
                                    //ODBS_LCLB.SetValue("U_LBDate", ODBS_LCLB.Offset, rsLeasetls.Fields.Item("Date").Value.ToString());
                                    //HANA
                                    ODBS_LCLB.SetValue("U_LBDate", ODBS_LCLB.Offset, dateLB);

                                }
                                catch (Exception ex) { }
                                ODBS_LCLB.SetValue("U_Status", ODBS_LCLB.Offset, "Pending");
                                ODBS_LCLB.SetValue("U_Posted", ODBS_LCLB.Offset, "No");

                                if (cmbContractTyp.Value == "F")
                                {

                                    if (tempinnerBalance == 0.00)
                                    {
                                        ODBS_LCLB.SetValue("U_Balance", ODBS_LCLB.Offset, Balance.ToString());
                                        tempinnerBalance = Balance;
                                    }
                                    else
                                    {
                                        tempinnerBalance = tempinnerBalance - tempinnerPrincipal;
                                        ODBS_LCLB.SetValue("U_Balance", ODBS_LCLB.Offset, tempinnerBalance.ToString());
                                    }
                                    Double calcRate = Math.Round(CalcRetRate,5 );
                                    if (calcRate < 0.00)
                                    {
                                        tempinnerInterest = 0;
                                    }
                                    else
                                    {
                                        tempinnerInterest = calcRate * tempinnerBalance / 100;
                                    }

                                    // tempinnerInterest = CalcRetRate * tempinnerBalance / 100;
                                    ODBS_LCLB.SetValue("U_Interest", ODBS_LCLB.Offset, tempinnerInterest.ToString());
                                    tempinnerPrincipal = Convert.ToDouble(monthlyvalue) - tempinnerInterest;
                                    //tempinnerPrincipal = 516.67 - tempinnerInterest;//For Check
                                    ODBS_LCLB.SetValue("U_Principal", ODBS_LCLB.Offset, tempinnerPrincipal.ToString());
                                    //tempinnerBalance = Balance;
                                    ODBS_LCLB.SetValue("U_IStatus", ODBS_LCLB.Offset, "Pending");
                                }

                                oMatrix.SetLineData(oMatrix.VisualRowCount);
                                rsLeasetls.MoveNext();
                            }

                        }
                        oMatrix.AddRow();
                    }
                    oMatrix.DeleteRow(oMatrix.RowCount);
                }
                else if (cmbBillingCycle.Value == "Q" && startDate != string.Empty)
                {
                    int interval = (instNum - 1) / 3 + 1;
                    //int instNumEnd = instNum - 1;
                    int instNumEnd = instNum ;
                    int Qinterval = 1;
                    string Query = "";
                    ////SQL
                    //string endDateQuery = "SELECT CONVERT(VARCHAR(10), DATEADD(month," + interval + ", '" + startDate + "' ), 112)\"Date\"";

                    //HANA
                    //string endDateQuery = "SELECT ADD_MONTHS (TO_DATE ('" + startDate + "', 'YYYYMMDD')," + interval + ") \"Date\" FROM DUMMY";
                    string endDateQuery = "SELECT  ADD_DAYS(ADD_MONTHS (TO_DATE ('" + startDate + "', 'YYYYMMDD')," + instNumEnd + "),-1) \"Date\" FROM DUMMY";
                    SAPbobsCOM.Recordset rsEndDate = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rsEndDate.DoQuery(endDateQuery);
                    if (rsEndDate.RecordCount > 0)
                    {
                        DateTime endDate = Convert.ToDateTime(rsEndDate.Fields.Item("Date").Value.ToString().Trim());
                        String dateend = endDate.ToString("yyyyMMdd");
                        oDBs_Head.SetValue("U_EndDate", oDBs_Head.Offset, dateend);
                        //oDBs_Head.SetValue("U_EndDate", oDBs_Head.Offset, rsEndDate.Fields.Item("Date").Value.ToString());
                    }

                    oDBs_Head.SetValue("U_BillInterval", oDBs_Head.Offset, interval.ToString());
                    if (oMatrix.RowCount > 0)
                    {
                        oMatrix.Clear();
                        oMatrix.AddRow();
                    }
                    //Decimal QlyValue = totalvalue / interval;
                    Decimal QlyValue = (monthlyvalue * 3);
                    Double CalcRetRate = 0.0;
                    if (cmbContractTyp.Value == "F")
                    {
                        //IRR Calc
                        Double[] array = new Double[interval + 1];


                        for (int i = 0; i <= interval; i++)
                        {
                            if (array[i] == array[0])
                            {
                                array[i] = Balance;
                            }

                            else if (array[i] != array[0])
                            {

                                //array[i] = -516.67;//For Check
                                array[i] = Convert.ToDouble(-QlyValue);
                            }

                        }

                        CalcRetRate = Microsoft.VisualBasic.Financial.IRR(ref array, 0.01) * 100;
                    }


                    for (int iDay = 0; iDay <= interval - 1; iDay++)
                    {
                        int rowNo1 = oMatrix.RowCount;
                        Qinterval = iDay * 3;
                        DateTime dateLBQtemp;

                        //string Query = "SELECT '" + iDay + "' + 1 \"Line\",DATEADD(MONTH, DATEDIFF(MONTH, 0,'" + startDate + "') + '" + iDay + "' , 0)  \"Date\" ";
                        ////SQL
                        //string Query = "SELECT CONVERT(VARCHAR(10), DATEADD(month," + iDay + ", '" + startDate + "' ), 112)\"Date\"";

                        //HANA
                        //string Query = "SELECT ADD_MONTHS (TO_DATE ('" + startDate + "', 'YYYYMMDD')," + iDay + ") \"Date\" FROM DUMMY";
                        if (iDay == 0)
                        {
                            Query = "SELECT ADD_MONTHS (TO_DATE ('" + startDateBill + "', 'YYYYMMDD')," + iDay + ") \"Date\" FROM DUMMY";
                        }

                        else
                        {
                            Query = "SELECT ADD_MONTHS (TO_DATE ('" + tempLBQDate.ToString("yyyyMMdd") + "', 'YYYYMMDD')," + (3) + ") \"Date\" FROM DUMMY";
                        }
                        SAPbobsCOM.Recordset rsLeasetls = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        rsLeasetls.DoQuery(Query);
                        if (rsLeasetls.RecordCount > 0)
                        {
                            while (rsLeasetls.EoF == false)
                            {
                                //if (oMatrix.RowCount == 0) oMatrix.AddRow();
                                //var Date = rsLeasetls.Fields.Item("Date").Value.ToString();
                                //DateTime LBQDate = DateTime.Parse(rsLeasetls.Fields.Item("Date").Value.ToString());
                                LBQDate = Convert.ToDateTime(rsLeasetls.Fields.Item("Date").Value.ToString().Trim());
                                String dateLBQ = LBQDate.ToString("yyyyMMdd");
                                tempLBQDate = LBQDate;

                                ODBS_LCLB.SetValue("LineId", ODBS_LCLB.Offset, rowNo1.ToString());
                                ODBS_LCLB.SetValue("U_Interval", ODBS_LCLB.Offset, rowNo1.ToString());
                                ODBS_LCLB.SetValue("U_LeaseBilling", ODBS_LCLB.Offset, QlyValue.ToString());
                                ODBS_LCLB.SetValue("U_LBDate", ODBS_LCLB.Offset, dateLBQ);
                                ODBS_LCLB.SetValue("U_Status", ODBS_LCLB.Offset, "Pending");
                                ODBS_LCLB.SetValue("U_Posted", ODBS_LCLB.Offset, "No");
                                if (cmbContractTyp.Value == "F")
                                {
                                    if (tempinnerBalanceQ == 0.00)
                                    {
                                        ODBS_LCLB.SetValue("U_Balance", ODBS_LCLB.Offset, Balance.ToString());
                                        tempinnerBalanceQ = Balance;
                                    }
                                    else
                                    {
                                        tempinnerBalanceQ = tempinnerBalanceQ - tempinnerPrincipalQ;
                                        ODBS_LCLB.SetValue("U_Balance", ODBS_LCLB.Offset, tempinnerBalanceQ.ToString());
                                    }
                                    Double calcRate = Math.Round(CalcRetRate, 4);
                                    if (calcRate < 0.00)
                                    {
                                        tempinnerInterestQ = 0;
                                    }
                                    else
                                    {
                                        tempinnerInterestQ = calcRate * tempinnerBalanceQ / 100;
                                    }

                                    ODBS_LCLB.SetValue("U_Interest", ODBS_LCLB.Offset, tempinnerInterestQ.ToString());
                                    tempinnerPrincipalQ = Convert.ToDouble(QlyValue) - tempinnerInterestQ;
                                    //tempinnerPrincipal = 516.67- tempinnerInterest;//For Check
                                    ODBS_LCLB.SetValue("U_Principal", ODBS_LCLB.Offset, tempinnerPrincipalQ.ToString());
                                    //tempinnerBalance = Balance;
                                    ODBS_LCLB.SetValue("U_IStatus", ODBS_LCLB.Offset, "Pending");
                                }
                                oMatrix.SetLineData(oMatrix.VisualRowCount);

                                rsLeasetls.MoveNext();
                            }

                        }
                        oMatrix.AddRow();
                    }
                    oMatrix.DeleteRow(oMatrix.RowCount);

                    //oDBs_Head.SetValue("U_EndDate", oDBs_Head.Offset, tempLBQDate.ToString("yyyyMMdd"));
                }

                else if (cmbBillingCycle.Value == "H" && startDate != string.Empty)
                {


                }
                else if (cmbBillingCycle.Value == "A" && startDate != string.Empty)
                {


                }


            }
        }

        private void f_Lease_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.UIAPIRawForm.PaneLevel = 4;
        }

        private void tbCustCd_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "CardType", "C");
        }

        private void ChooseFromListCondition(SAPbouiCOM.ISBOChooseFromListEventArg pVal, string aliasName, string condVal, string CondType = "", string query = "")
        {
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;

            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition;
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

            }
        }

        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.StaticText StaticText22;
        //private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText23;
        //private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText24;
        private SAPbouiCOM.StaticText StaticText27;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText28;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.LinkedButton LinkedButton2;
        private SAPbouiCOM.LinkedButton LinkedButton3;
        private SAPbouiCOM.LinkedButton LinkedButton5;
        private SAPbouiCOM.StaticText StaticText25;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText26;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText29;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText30;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.StaticText StaticText31;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText32;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.EditText EditText11;
        //private SAPbouiCOM.EditText EditText5;

    }
}
