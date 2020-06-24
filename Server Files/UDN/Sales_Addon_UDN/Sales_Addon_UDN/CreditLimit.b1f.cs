using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.CreditLimit", "CreditLimit.b1f")]
    class CreditLimit : UserFormBase
    {
        public CreditLimit(string cardCode = null , bool isfmbp = false  , string Category = null)
        {
            try
            {
                isFrmBP = isfmbp;
                txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OCRN").ToString();
                //tdocno.Value = B1Helper.GetNextDocNum("@ITN_OCRN").ToString();
                Extentions.AddLine(Matrix0);
                Extentions.SetLineId(Matrix0);
                Matrix0.AutoResizeColumns();


                if (cardCode != null)
                {
                    BpCardCode = cardCode; 
                    BpCat = Category; 
                    CmbCat.Select(Category, SAPbouiCOM.BoSearchKey.psk_ByValue); 
                    txtCCode.Value = cardCode.Split(',')[0];
                    txtNme.Value = cardCode.Split(',')[1];
                    setgroupcode();
                    setCategory();
                }
                txtadd.Value = getaddress();
                //hide colums
                Matrix0.Columns.Item("bnkbra").Width = 0;
                Matrix0.Columns.Item("Addrs").Width = 0;
                Matrix0.Columns.Item("contno").Width = 0;
                Matrix0.Columns.Item("Email").Width = 0;
                Matrix0.Columns.Item("Gureffdt").Width = 0;
                Matrix0.Columns.Item("gurexdt").Width = 0;
                Matrix0.Columns.Item("clmexdt").Width = 0;
                Matrix0.Columns.Item("bgamt").Width = 0;
                Matrix0.Columns.Item("crdys").Width = 0;
                Matrix0.Columns.Item("tollvl").Width = 0;
                Matrix0.Columns.Item("Crlmtamt").Width = 0;
                Matrix0.Columns.Item("rmk").Width = 0;
                //Matrix0.Columns.Item("AttchDoc").Width = 0;
                //Matrix0.Columns.Item("isAct").Width = 0;
                //Matrix0.AutoResizeColumns();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtCCode = ((SAPbouiCOM.EditText)(this.GetItem("txtCCode").Specific));
            this.txtCCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtCCode_ChooseFromListAfter);
            this.txtCCode.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.txtCCode_ChooseFromListBefore);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtNme = ((SAPbouiCOM.EditText)(this.GetItem("txtNme").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.txtadd = ((SAPbouiCOM.EditText)(this.GetItem("txtadd").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_8").Specific));
            this.Matrix0.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.Matrix0_LinkPressedBefore);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.txtgrtot = ((SAPbouiCOM.EditText)(this.GetItem("txtgrtot").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.txttol = ((SAPbouiCOM.EditText)(this.GetItem("txttol").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.txttup = ((SAPbouiCOM.EditText)(this.GetItem("txttup").Specific));
            this.txttup.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.txttup_LostFocusAfter);
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.txttcr = ((SAPbouiCOM.EditText)(this.GetItem("txttcr").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.txtdb = ((SAPbouiCOM.EditText)(this.GetItem("txtdb").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.txtacr = ((SAPbouiCOM.EditText)(this.GetItem("txtacr").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.txttvat = ((SAPbouiCOM.EditText)(this.GetItem("txttvat").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.txtDocNo = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNo").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.CmbBus = ((SAPbouiCOM.ComboBox)(this.GetItem("CmbBus").Specific));
            this.CmbBus.ComboSelectBefore += new SAPbouiCOM._IComboBoxEvents_ComboSelectBeforeEventHandler(this.CmbBus_ComboSelectBefore);
            this.CmbBus.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CmbBus_ComboSelectAfter);
            this.CmbCat = ((SAPbouiCOM.ComboBox)(this.GetItem("CmbCat").Specific));
            this.CmbCat.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CmbCat_ComboSelectAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.Ofrm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ClickBefore += new ClickBeforeHandler(this.Form_ClickBefore);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            try
            {
                Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
                Ofrm.EnableMenu("1292", true);
                Ofrm.EnableMenu("1293", true);
                Ofrm.EnableMenu("1287", true);
                Matrix0.CommonSetting.EnableArrowKey = true;
                Matrix0.AutoResizeColumns(); 
            }
            catch
            {
            }
        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Ofrm = Program.SBO_Application.Forms.ActiveForm;
                if (Ofrm.Title == "Credit Limit")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            txtDocNo.Item.Enabled = false;
                            txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OCRN").ToString();

                            Extentions.AddLine(Matrix0);
                            Extentions.SetLineId(Matrix0);

                        }
                        if (pVal.MenuUID == "1281")
                        {
                            txtDocNo.Item.Enabled = true;
                        }
                        if (pVal.MenuUID == "1287")
                        {
                            txtDocNo.Item.Enabled = false;
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
                            //SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Ofrm.Items.Item("Item_8").Specific;
                            for (int i = 1; i <= Matrix0.RowCount; i++)
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

        #region declaration
        private SAPbouiCOM.EditText txtCCode;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtNme;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText txtadd;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText txtgrtot;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText txttol;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText txttup;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText txttcr;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText txtdb;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText txtacr;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText txttvat;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText txtDocNo;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.ComboBox CmbBus;
        private SAPbouiCOM.ComboBox CmbCat;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.Form Ofrm;
        private bool isFrmBP = false;
        private string BpCat = "";
        private string BpCardCode = "";
        #endregion


        private void Matrix0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (Validation())
                {
                    string formMode = "";
                    int dd = pVal.Row;
                    SAPbouiCOM.EditText bank = Matrix0.GetCellSpecific("GarNo", pVal.Row) as SAPbouiCOM.EditText;
                    if (string.IsNullOrEmpty(bank.Value))
                    {
                        formMode = "Add";
                    }
                    else
                    {
                        formMode = "Update";
                    }
                    CreditLimitChild crc = new CreditLimitChild(formMode, pVal.Row, Convert.ToInt32(txtDocNo.Value));
                    crc.Show();
                }
            }
            catch
            {
            }

        }

        private void txtCCode_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {

                SAPbouiCOM.ChooseFromList oCFLEvento = default(SAPbouiCOM.ChooseFromList);
                SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
                oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("OCRD");
                oCFLEvento.SetConditions(null);
                oCons = oCFLEvento.GetConditions();

                oCon = oCons.Add();
                oCon.Alias = "CardType";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = "C";

                oCFLEvento.SetConditions(oCons);
            }
            catch
            {
            }

        }

        private void txtCCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
            try
            {
                txtCCode.Value = oTable.GetValue("CardCode", 0).ToString();
            }
            catch { }
            try
            {
                txtNme.Value = oTable.GetValue("CardName", 0).ToString();

            }
            catch
            {
            }
            try
            {
                txtadd.Value = getaddress();
                setgroupcode();
            }
            catch
            {
            }
            try
            {
                setCategory();
            }
            catch
            {

            }
        }

        private bool Validation()
        {

            if (txtCCode.Value == null)
            {
                Program.SBO_Application.StatusBar.SetText("Select CardCode first to proced.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            if (CmbBus.Value == null || CmbBus.Value.ToString() == "")
            {
                Program.SBO_Application.StatusBar.SetText("Select Business Unit first to proced.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            if (CmbCat.Value == null || CmbCat.Value.ToString() == "")
            {
                Program.SBO_Application.StatusBar.SetText("Select Category first to proced.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }

            return true;

        }

        public void AutoCalculations()
        {
            try
            {
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText txtbank = Matrix0.GetCellSpecific("GarNo", i) as SAPbouiCOM.EditText;
                    if (string.IsNullOrEmpty(txtbank.Value))
                    {
                        SAPbouiCOM.EditText crlmtamt = Matrix0.GetCellSpecific("Crlmtamt", i) as SAPbouiCOM.EditText;
                        double GrTotal = 0;
                        //set gross total first
                        SAPbouiCOM.EditText Amount = Matrix0.GetCellSpecific("AMT", i) as SAPbouiCOM.EditText;
                        if (string.IsNullOrEmpty(Amount.Value) && Convert.ToDouble(Amount.Value) > 0)
                        {
                            GrTotal = Convert.ToDouble(Amount.Value) + GrTotal;
                            txtgrtot.Value = GrTotal.ToString();
                        }
                    }
                }
                //total credit limit
                txttcr.Value = ((Convert.ToDouble(txtgrtot.Value) * Convert.ToInt32(txttol.Value)) / 100) + (Convert.ToDouble(txtgrtot.Value) + Convert.ToDouble(string.IsNullOrEmpty(txttup.Value) ? 0 : Convert.ToDouble(txttup.Value))).ToString();
                txtacr.Value = (Convert.ToDouble(txttcr.Value) - Convert.ToDouble(txtdb.Value)).ToString();
            }
            catch
            {
            }
        }

        private void CmbCat_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (CmbCat.Value == "A")
                {
                    txttol.Value = "40";
                    return;
                }
                else if (CmbCat.Value == "B")
                {
                    txttol.Value = "20";
                    return;
                }
                else
                {
                    txttol.Value = "0";
                    return;
                }
            }
            catch
            {
            }

        }

        private void Form_ClickBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
            {
                if (item.Title == "Additional Information")
                {
                    BubbleEvent = false;
                    item.Select();
                }
            }
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (Button0.Caption == "Add")
                {
                    txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OCRN").ToString();

                    if (checkdataalreadyexists())
                    {
                        Program.SBO_Application.StatusBar.SetText("Same Business partner with same Business unit can't be used", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        BubbleEvent = false;
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        private void txttup_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form fmr2 = Ofrm;
                double GrTotal = 0;
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText txtbank = Matrix0.GetCellSpecific("GarNo", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.CheckBox isActive = Matrix0.GetCellSpecific("isAct", i) as SAPbouiCOM.CheckBox;
                    if (!string.IsNullOrEmpty(txtbank.Value) && isActive.Checked == true)
                    {
                        // Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txtgrtot").Specific))).Value);
                        //set gross total first
                        SAPbouiCOM.EditText Amount = Matrix0.GetCellSpecific("AMT", i) as SAPbouiCOM.EditText;
                        if (!string.IsNullOrEmpty(Amount.Value) && Convert.ToDouble(Amount.Value) > 0)
                        {
                            GrTotal = Convert.ToDouble(Amount.Value) + GrTotal;
                            ((SAPbouiCOM.EditText)((fmr2.Items.Item("txtgrtot").Specific))).Value = GrTotal.ToString();
                        }
                    }
                }
                //total credit limit
                double txtgrtot = Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txtgrtot").Specific))).Value.ToString());
                double txttol = Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txttol").Specific))).Value);
                double topup = Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txttup").Specific))).Value);
                ((SAPbouiCOM.EditText)((fmr2.Items.Item("txttcr").Specific))).Value = ((txtgrtot * txttol / 100) + txtgrtot + topup).ToString(); // (Convert.ToDouble((Convert.ToDouble(txtgrtot) * txttol) / 100)) + Convert.ToDouble((txtgrtot + Convert.ToDouble(topup))).ToString();
                ((SAPbouiCOM.EditText)((fmr2.Items.Item("txtacr").Specific))).Value = (Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txttcr").Specific))).Value) - Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txtdb").Specific))).Value)).ToString();
            }
            catch
            {
            }

        }

        private string getaddress()
        {
            try
            {

                string query = "Select  T1.\"Address\" ||' '|| ifnull(T1.\"Address2\",'') ||' '|| ifnull(T1.\"Address3\",'')||' '|| ifnull(T1.\"Street\",'')||' '|| ifnull(T1.\"Block\",'')||' '" +
                                "|| ifnull(T1.\"City\",'') ||' '|| ifnull(T1.\"ZipCode\",'') ||' '|| ifnull(T1.\"County\",'')||' '|| ifnull(T1.\"State\",'') ||' '|| ifnull(T1.\"Country\",'') ||' '||" +
                                "ifnull(T1.\"StreetNo\",'')||' '|| ifnull(T1.\"Building\",'')||' '|| ifnull(T1.\"TaxOffice\",'') as Address from  " + Program.oCompany.CompanyDB + ".OCRD T0  left join " + Program.oCompany.CompanyDB + ".CRD1 T1 on T0.\"BillToDef\" = T1.\"Address\" where T0.\"CardCode\" = '" + txtCCode.Value + "' and T1.\"AdresType\" = 'B' ";
                SAPbobsCOM.Recordset rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rec.DoQuery(query);
                if (rec.RecordCount > 0)
                {
                    return rec.Fields.Item("Address").Value.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        private void setgroupcode()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCCode.Value))
                {
                    string query = "select OCQG.\"GroupCode\" , OCQG.\"GroupName\"" +
                                    "from OCRD CROSS JOIN OCQG where OCRD.\"CardCode\" = '" + txtCCode.Value + "' and \"CardType\" = 'C' and";

                    for (int i = 1; i < 65; i++)
                    {
                        if (i == 1)
                        {
                            query += "((OCRD.\"QryGroup" + i + "\" = 'Y' and OCQG.\"GroupCode\" = " + i + " )";
                        }
                        else
                        {
                            query += "or (OCRD.\"QryGroup" + i + "\" = 'Y' and OCQG.\"GroupCode\" = " + i + ")";
                        }
                    }
                    query += ")";

                    //string Query = "SELECT T0.\"GroupCode\", T0.\"GroupName\" FROM OCQG T0 WHERE T0.\"GroupName\" NOT LIKE 'Business%' ";
                    B1Helper.SAPFillComboValues(this.CmbBus, query);
                }
            }
            catch
            {
            }
        }

        private void setCategory()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCCode.Value))
                {
                    string que = "Select U_CUSTCAT ,U_CUSTCAT from OCRD where \"CardCode\" = '" + txtCCode.Value + "'";
                    B1Helper.SAPFillComboValues(this.CmbCat, que);
                }
            }
            catch
            {
            }


        }

        private bool checkdataalreadyexists()
        {
            if (!string.IsNullOrEmpty(txtCCode.Value) && !string.IsNullOrEmpty(CmbBus.Selected.Value.ToString()))
            {
                string query = "Select \"U_CARDCODE\" , \"U_BUNIT\" from \"@ITN_OCRN\" where \"U_CARDCODE\" = '" + txtCCode.Value + "' and \"U_BUNIT\" = '" + CmbBus.Selected.Value + "' ";
                SAPbobsCOM.Recordset rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
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
            return false;
        }

        
        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Button0.Caption == "Add")
                {
                    txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OCRN").ToString();
                    Extentions.AddLine(Matrix0);
                    Extentions.SetLineId(Matrix0);
                    if (isFrmBP)
                    {
                        CmbCat.Select(BpCat, SAPbouiCOM.BoSearchKey.psk_ByValue);
                        txtCCode.Value = BpCardCode.Split(',')[0];
                        txtNme.Value = BpCardCode.Split(',')[1];
                        setgroupcode();
                        setCategory();

                        txtadd.Value = getaddress();
                    }
                   
                    
                }
            }
            catch
            {
            }
        }

        private void CmbBus_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Button0.Caption == "Add")
                {
                    txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OCRN").ToString();

                    if (checkdataalreadyexists())
                    {
                        Program.SBO_Application.StatusBar.SetText("Same Business partner with same Business unit can't be used", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        //BubbleEvent = false;
                        return;
                    }
                }
            }
            catch
            {
            }

        }

        private void CmbBus_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            

        }
    }
}
