using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using System.Globalization;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.CreditLimitChild", "CreditLimitChild.b1f")]
    class CreditLimitChild : UserFormBase
    {
        public CreditLimitChild(string FormMode, int lineid, int DocNum)
        {
            try
            {
                txtid.Value = lineid.ToString();
                txtdocnum.Value = DocNum.ToString();
                txtdate.Value = System.DateTime.Now.ToString("yyyyMMdd");
                CheckBox0.Checked = true; 
                if (FormMode == "Add")
                {
                    Button0.Caption = "Add";

                    foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                    {
                        if (item.Title == "Credit Limit")
                        {
                            SAPbouiCOM.Form fmr2 = item;
                            fmr2 = Program.SBO_Application.Forms.ActiveForm;
                            txtprty.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("txtNme").Specific))).Value.ToString();
                            txtbusi.Value = ((SAPbouiCOM.ComboBox)((fmr2.Items.Item("CmbBus").Specific))).Selected.Description.ToString();
                            txtcat.Value = ((SAPbouiCOM.ComboBox)((fmr2.Items.Item("CmbCat").Specific))).Selected.Description.ToString();
                            settolerence();
                        }
                    }
                }
                else
                {
                    Button0.Caption = "Update";

                    foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                    {
                        if (item.Title == "Credit Limit")
                        {
                            SAPbouiCOM.Form fmr2 = item;
                            SAPbouiCOM.Matrix mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("Item_8").Specific));

                            cmbbnk.Select(((SAPbouiCOM.ComboBox)mtx.Columns.Item("bank").Cells.Item(lineid).Specific).Value.ToString(), SAPbouiCOM.BoSearchKey.psk_ByDescription);

                            txtdate.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("Date").Cells.Item(lineid).Specific).Value.ToString();
                            txtbnkbra.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("bnkbra").Cells.Item(lineid).Specific).Value.ToString();
                            txtadd.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("Addrs").Cells.Item(lineid).Specific).Value.ToString();
                            txtcon.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("contno").Cells.Item(lineid).Specific).Value.ToString();
                            txtemail.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("Email").Cells.Item(lineid).Specific).Value.ToString();
                            txtprty.Value = ((SAPbouiCOM.EditText)((fmr2.Items.Item("txtNme").Specific))).Value.ToString();
                            txtbusi.Value = ((SAPbouiCOM.ComboBox)((fmr2.Items.Item("CmbBus").Specific))).Selected.Value.ToString();
                            txtcat.Value = ((SAPbouiCOM.ComboBox)((fmr2.Items.Item("CmbCat").Specific))).Selected.Value.ToString();
                            txtguno.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("GarNo").Cells.Item(lineid).Specific).Value.ToString();
                            tgureffdt.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("Gureffdt").Cells.Item(lineid).Specific).Value.ToString();
                            txtgexdt.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("gurexdt").Cells.Item(lineid).Specific).Value.ToString();
                            tclmexdt.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("clmexdt").Cells.Item(lineid).Specific).Value.ToString();
                            txtbgamt.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("bgamt").Cells.Item(lineid).Specific).Value.ToString();
                            txtcrdys.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("crdys").Cells.Item(lineid).Specific).Value.ToString();
                            txttollev.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("tollvl").Cells.Item(lineid).Specific).Value.ToString();
                            clmlmtamt.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("Crlmtamt").Cells.Item(lineid).Specific).Value.ToString();
                            txtrmk.Value = ((SAPbouiCOM.EditText)mtx.Columns.Item("rmk").Cells.Item(lineid).Specific).Value.ToString();

                            CheckBox0.Checked = ((SAPbouiCOM.CheckBox)mtx.Columns.Item("isAct").Cells.Item(lineid).Specific).Checked;
                        }
                    }
                }
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
            this.txtid = ((SAPbouiCOM.EditText)(this.GetItem("txtid").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtdate = ((SAPbouiCOM.EditText)(this.GetItem("txtdate").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.txtbnkbra = ((SAPbouiCOM.EditText)(this.GetItem("txtbnkbra").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.txtadd = ((SAPbouiCOM.EditText)(this.GetItem("txtadd").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.txtcon = ((SAPbouiCOM.EditText)(this.GetItem("txtcon").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.txtemail = ((SAPbouiCOM.EditText)(this.GetItem("txtemail").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.txtprty = ((SAPbouiCOM.EditText)(this.GetItem("txtprty").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.txtbusi = ((SAPbouiCOM.EditText)(this.GetItem("txtbusi").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.txtcat = ((SAPbouiCOM.EditText)(this.GetItem("txtcat").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.txtguno = ((SAPbouiCOM.EditText)(this.GetItem("txtguno").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.tgureffdt = ((SAPbouiCOM.EditText)(this.GetItem("tgureffdt").Specific));
            this.tgureffdt.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.tgureffdt_LostFocusAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.tclmexdt = ((SAPbouiCOM.EditText)(this.GetItem("tclmexdt").Specific));
            this.tclmexdt.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.tclmexdt_LostFocusAfter);
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.txtbgamt = ((SAPbouiCOM.EditText)(this.GetItem("txtbgamt").Specific));
            this.txtbgamt.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.txtbgamt_LostFocusAfter);
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.txtcrdys = ((SAPbouiCOM.EditText)(this.GetItem("txtcrdys").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.txttollev = ((SAPbouiCOM.EditText)(this.GetItem("txttollev").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
            this.clmlmtamt = ((SAPbouiCOM.EditText)(this.GetItem("clmlmtamt").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.ofrm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.txtrmk = ((SAPbouiCOM.EditText)(this.GetItem("txtrmk").Specific));
            this.cmbbnk = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbbnk").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.txtgexdt = ((SAPbouiCOM.EditText)(this.GetItem("txtgexdt").Specific));
            this.txtgexdt.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.txtgexdt_LostFocusAfter);
            this.txtdocnum = ((SAPbouiCOM.EditText)(this.GetItem("txtdocnum").Specific));
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_5").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        #region declaration
        private SAPbouiCOM.EditText txtid;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtdate;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText txtbnkbra;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText txtadd;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText txtcon;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText txtemail;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText txtprty;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText txtbusi;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText txtcat;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText txtguno;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText tgureffdt;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText tclmexdt;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText txtbgamt;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText txtcrdys;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText txttollev;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText clmlmtamt;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Form ofrm;
        private SAPbouiCOM.EditText txtrmk;
        private SAPbouiCOM.ComboBox cmbbnk;
        private SAPbouiCOM.EditText txtdocnum;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText txtgexdt;
        #endregion

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (!CheckValidations())
                {
                    BubbleEvent = false;
                }
            }
            catch
            {
            }

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            try
            {
                LogChanges();
                SAPbouiCOM.Form fmr2;
                SAPbouiCOM.Matrix mtx;
                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Credit Limit")
                    {
                        fmr2 = item;
                        //fmr2 = Program.SBO_Application.Forms.ActiveForm;

                        mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("Item_8").Specific));
                        int lineid = Convert.ToInt32(txtid.Value);
                        ((SAPbouiCOM.ComboBox)((mtx.Columns.Item("bank").Cells.Item(lineid).Specific))).Select(cmbbnk.Selected.Value, SAPbouiCOM.BoSearchKey.psk_ByValue);
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("Date").Cells.Item(lineid).Specific).Value = txtdate.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("Vlidtill").Cells.Item(lineid).Specific).Value = tclmexdt.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("bnkbra").Cells.Item(lineid).Specific).Value = txtbnkbra.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("Addrs").Cells.Item(lineid).Specific).Value = txtadd.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("contno").Cells.Item(lineid).Specific).Value = txtcon.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("AMT").Cells.Item(lineid).Specific).Value = clmlmtamt.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("Email").Cells.Item(lineid).Specific).Value = txtemail.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("GarNo").Cells.Item(lineid).Specific).Value = txtguno.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("Gureffdt").Cells.Item(lineid).Specific).Value = tgureffdt.Value;


                        ((SAPbouiCOM.EditText)mtx.Columns.Item("gurexdt").Cells.Item(lineid).Specific).Value = txtgexdt.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("clmexdt").Cells.Item(lineid).Specific).Value = tclmexdt.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("bgamt").Cells.Item(lineid).Specific).Value = txtbgamt.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("crdys").Cells.Item(lineid).Specific).Value = txtcrdys.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("tollvl").Cells.Item(lineid).Specific).Value = txttollev.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("Crlmtamt").Cells.Item(lineid).Specific).Value = clmlmtamt.Value;
                        ((SAPbouiCOM.EditText)mtx.Columns.Item("rmk").Cells.Item(lineid).Specific).Value = txtrmk.Value;
                        ((SAPbouiCOM.CheckBox)mtx.Columns.Item("isAct").Cells.Item(lineid).Specific).Checked = CheckBox0.Checked;

                        // Do Calculations.
                        double GrTotal = 0;
                        for (int i = 1; i <= mtx.RowCount; i++)
                        {
                            SAPbouiCOM.EditText txtbank = mtx.GetCellSpecific("GarNo", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.CheckBox isActive = mtx.GetCellSpecific("isAct", i) as SAPbouiCOM.CheckBox;
                            if (!string.IsNullOrEmpty(txtbank.Value) && isActive.Checked == true)
                            {
                                // Convert.ToDouble(((SAPbouiCOM.EditText)((fmr2.Items.Item("txtgrtot").Specific))).Value);
                                //set gross total first
                                SAPbouiCOM.EditText Amount = mtx.GetCellSpecific("AMT", i) as SAPbouiCOM.EditText;
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
                        if (Button0.Caption != "Update")
                        {
                            mtx.AddRow();
                            ((SAPbouiCOM.EditText)mtx.Columns.Item("#").Cells.Item(mtx.VisualRowCount).Specific).Value = mtx.VisualRowCount.ToString();
                            mtx.AutoResizeColumns();
                        }
                    }
                }
                ofrm.Close();

            }
            catch
            {

            }
        }

        private void settolerence()
        {
            try
            {
                if (txtcat.Value == "A")
                {
                    txttollev.Value = "40";
                    return;
                }
                else if (txtcat.Value == "B")
                {
                    txttollev.Value = "20";
                    return;
                }
                else
                {
                    txttollev.Value = "0";
                    return;
                }
            }
            catch
            {
            }
        }

        private void setcrdays()
        {
            try
            {
                if (!string.IsNullOrEmpty(tgureffdt.Value) && !string.IsNullOrEmpty(txtgexdt.Value))
                {
                    DateTime dt1 = DateTime.ParseExact(txtgexdt.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    DateTime dt2 = DateTime.ParseExact(tgureffdt.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    txtcrdys.Value = (dt1 - dt2).TotalDays.ToString();
                }
            }
            catch
            {
            }
        }

        private void tclmexdt_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                setcrdays();
            }
            catch
            {
            }
        }

        private void txtbgamt_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtbgamt.Value) && Convert.ToDouble(txtbgamt.Value) > 0)
                {
                    clmlmtamt.Value = (Convert.ToDouble(txtbgamt.Value)).ToString();
                }
                else
                {
                    clmlmtamt.Value = "";
                }
            }
            catch
            {
            }

        }

        private bool CheckValidations()
        {
            if (string.IsNullOrEmpty(txtdate.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Date Can't be blank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbbnk.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Select atleast one Guarantor / Bank", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtguno.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Guarantee Number Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            else if (string.IsNullOrEmpty(tgureffdt.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Guarantee Effective Date Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            else if (string.IsNullOrEmpty(tclmexdt.Value))
            {

                Program.SBO_Application.StatusBar.SetText("Claim Expiry Date Date Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtbgamt.Value) || Convert.ToDouble(txtbgamt.Value) <= 0)
            {
                Program.SBO_Application.StatusBar.SetText("BGAmount Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                return false;
            }

            if (cmbbnk.Selected.Value == "NBLBNK")
            {
                if (string.IsNullOrEmpty(txtbnkbra.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Bank Branch Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                else if (string.IsNullOrEmpty(txtadd.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Address Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                else if (string.IsNullOrEmpty(txtcon.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Contact Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
            }
            else if (cmbbnk.Selected.Value == "CSHDPO")
            {
                if (string.IsNullOrEmpty(txtcon.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Contact Can't be null", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
            }


            return true;
        }

        private void tgureffdt_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                setcrdays();
            }
            catch
            {
            }

        }
       
        private void LogChanges()
        {
            try
            {
                string code = B1Helper.GetNextCodeId("@AITN_CRN").ToString();
                string query = "insert into \"" + Program.oCompany.CompanyDB + "\".\"@AITN_CRN\" values('" + code + "','" + code + "','" + txtdocnum.Value + "','" + txtid.Value + "'," +
                "'" + txtdate.Value + "','" + cmbbnk.Value + "','" + txtbnkbra.Value + "','" + txtadd.Value + "','" + txtbusi.Value + "','" + txtcat.Value + "'," + txtcon.Value + ",'" + txtemail.Value + "" +
                "','" + txtprty.Value + "','" + txtguno.Value + "','" + tgureffdt.Value + "','" + txtgexdt.Value + "','" + tclmexdt.Value + "'," + txtbgamt.Value + ", " + txtcrdys.Value +
                "," + txttollev.Value + "," + clmlmtamt.Value + " ,'" + txtrmk.Value + "','" + CheckBox0.Checked + "')";

                SAPbobsCOM.Recordset rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rec.DoQuery(query);
            }
            catch
            {
            }

        }    

        private void txtgexdt_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                setcrdays();
                tclmexdt.Value = txtgexdt.Value; 
            }
            catch
            {

            }
        }



    }
}
