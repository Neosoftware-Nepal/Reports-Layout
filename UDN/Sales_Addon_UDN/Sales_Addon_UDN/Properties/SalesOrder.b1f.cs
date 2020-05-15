using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using SAPbouiCOM;
namespace Sales_Addon_UDN
{
    [FormAttribute("139", "SalesOrder.b1f")]
    class SalesOrder : SystemFormBase
    {
        public SalesOrder()
        {

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        /// 
        public override void OnInitializeComponent()
        {
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("10000330").Specific));
            this.ComboBox0.ComboSelectBefore += new SAPbouiCOM._IComboBoxEvents_ComboSelectBeforeEventHandler(this.ComboBox0_ComboSelectBefore);
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("38").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.CmbBU = ((SAPbouiCOM.ComboBox)(this.GetItem("CmbBU").Specific));
            this.CmbBU.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CmbBU_ComboSelectAfter);
            this.txtCCode = ((SAPbouiCOM.EditText)(this.GetItem("4").Specific));
            this.txtCCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtCCode_ChooseFromListAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.txtCRlmt = ((SAPbouiCOM.EditText)(this.GetItem("txtCRlmt").Specific));
            this.cmbPayterms = ((SAPbouiCOM.ComboBox)(this.GetItem("47").Specific));
            this.FlderAccounting = ((SAPbouiCOM.Folder)(this.GetItem("138").Specific));
            this.FlderContent = ((SAPbouiCOM.Folder)(this.GetItem("112").Specific));
            this.OForm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.PostingDate = ((SAPbouiCOM.EditText)(this.GetItem("10").Specific));
            this.txtdisper = ((SAPbouiCOM.EditText)(this.GetItem("txtdisper").Specific));            
            this.txtTDisA = ((SAPbouiCOM.EditText)(this.GetItem("txtTDisA").Specific));
            this.txtTotal = ((SAPbouiCOM.EditText)(this.GetItem("29").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ActivateAfter += new ActivateAfterHandler(this.Form_ActivateAfter);

        }

        private void OnCustomInitialize()
        {
            try
            {
                Button0.Item.Enabled = false;
                //Align the button with add button
                Button1.Item.Top = Button2.Item.Top;
                Button1.Item.Left = Button2.Item.Left + 70;
            }
            catch
            {
            }
        }

        #region declaration

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.ComboBox CmbBU;
        private SAPbouiCOM.EditText txtCCode;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbobsCOM.Recordset rec;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Folder FlderAccounting;
        private SAPbouiCOM.Folder FlderContent;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText txtCRlmt;
        private SAPbouiCOM.ComboBox cmbPayterms;
        private double CRLimit = 0;
        private string SelectedBU = "";
        private SAPbouiCOM.Form OForm;

        #endregion

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (ComboBox0.Selected.Description == "23")
            {

            }

        }

        private void txtCCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
                try
                {
                    setBU_in_CMB(oTable.GetValue("CardCode", 0).ToString(), CmbBU);
                }
                catch { }
            }
            catch
            {
            }
        }

        private void setBU_in_CMB(string cardCode, SAPbouiCOM.ComboBox CMB)
        {
            try
            {
                if (!string.IsNullOrEmpty(cardCode))
                {
                    string query = "select OCQG.\"GroupCode\" , OCQG.\"GroupName\"" +
                                    "from OCRD CROSS JOIN OCQG where OCRD.\"CardCode\" = '" + cardCode + "' and \"CardType\" = 'C' and";

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

                    B1Helper.SAPFillComboValues(CMB, query);
                }
            }
            catch
            {
            }
        }

        private void CmbBU_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SET_CreditLimit(txtCCode.Value);
                //Button0.Item.Enabled = true;
                SET_PaymentTerm(txtCCode.Value);
                Select_PromoCode();
                if (!promoclosed )
                {
                    Select_BillAndtradingDisc(); 
                }
                if (PromotionSelection.promotionclosed && promoclosed)
                {
                    Select_BillAndtradingDisc();
                    promoclosed = false;
                    PromotionSelection.promotionclosed = false; 
                }
                

            }
            catch
            {
            }
        }

        private static bool promoclosed = false;
        private void ComboBox0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                CRLimit = Convert.ToDouble(txtCRlmt.Value.ToString());
                SelectedBU = CmbBU.Selected.Value.ToString();
            }
            catch
            {
            }
        }

        private void SET_PaymentTerm(String CardCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(CardCode))
                {

                    string Query = "Select * From \"@ITN_OPAY\" T0 inner join \"@ITN_PAY1\" T1 on T0.\"DocEntry\" = T1.\"DocEntry\" Where T0.\"U_BUNIT\"  = '" + CmbBU.Selected.Value + "' and T1.\"U_CUSTCODE\" = '" + txtCCode.Value + "'";
                    rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rec.DoQuery(Query);
                    if (rec.RecordCount > 0)
                    {
                        OForm.Freeze(true);
                        FlderAccounting.Item.Click();
                        cmbPayterms.Item.Enabled = true;
                        cmbPayterms.Select(rec.Fields.Item("U_PAYNAME").Value, SAPbouiCOM.BoSearchKey.psk_ByDescription);
                        FlderContent.Item.Click();
                        OForm.Freeze(false);
                    }
                }
            }
            catch
            {
                OForm.Freeze(false);
            }
        }

        private bool SET_CreditLimit(string CardCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(CardCode))
                {
                    string query = "Select * from \"@ITN_OCRN\" where U_CARDCODE = '" + CardCode + "' and U_BUNIT = '" + CmbBU.Selected.Value + "' ";
                    rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rec.DoQuery(query);
                    if (rec.RecordCount > 0)
                    {

                        txtCRlmt.Value = rec.Fields.Item("U_AVACRLTM").Value.ToString();
                        //double AllowedCrlmt = Convert.ToDouble(rec.Fields.Item("U_AVACRLTM").Value.ToString());
                        //if (AllowedCrlmt < AllowedCrlmt)
                        //{
                        //    return true;
                        //}
                        //else
                        //{
                        //    return false;
                        //}
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void Select_PromoCode()
        {
            //for loop for each item 
            try
            {
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText Qty = Matrix0.GetCellSpecific("11", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText U_PARENTITM = Matrix0.GetCellSpecific("U_ITNPARENTITM", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText U_PROMOAPPLIED = Matrix0.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                    if (string.IsNullOrEmpty(U_PARENTITM.Value) && (string.IsNullOrEmpty(U_PROMOAPPLIED.Value) || U_PROMOAPPLIED.Value == "No") && !string.IsNullOrEmpty(ItemCode.Value))
                    {
                        string Query = AllPromotionCode(txtCCode.Value, ItemCode.Value, PostingDate.Value, Qty.Value);
                        resetRec();
                        rec.DoQuery(Query);
                        if (rec.RecordCount > 0)
                        {
                            if (rec.RecordCount == 1)
                            {
                                string disc = rec.Fields.Item("Disc").Value.ToString();
                                string InvDisc = rec.Fields.Item("InvDisc").Value.ToString();
                                string FreeItem = rec.Fields.Item("FreeItm").Value.ToString();
                                if (!string.IsNullOrEmpty(disc) && Convert.ToDouble(disc) > 0)
                                {
                                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("15").Cells.Item(i).Specific).Value = disc;
                                    SAPbouiCOM.EditText U_PROAPP = Matrix0.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                                    U_PROAPP.Value = "Yes";
                                }
                                else if (!string.IsNullOrEmpty(InvDisc) && Convert.ToDouble(InvDisc) > 0)
                                {
                                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("15").Cells.Item(i).Specific).Value = InvDisc;
                                    SAPbouiCOM.EditText U_PROAPP = Matrix0.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                                    U_PROAPP.Value = "Yes";
                                }
                                else if (!string.IsNullOrEmpty(FreeItem))
                                {
                                    Matrix0.AddRow(1, i);
                                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("1").Cells.Item(i + 1).Specific).Value = FreeItem;
                                    SAPbouiCOM.EditText U_ParentCd = Matrix0.GetCellSpecific("U_ITNPARENTITM", i + 1) as SAPbouiCOM.EditText;
                                    SAPbouiCOM.EditText MtxItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;

                                    U_ParentCd.Value = MtxItemCode.Value;
                                    SAPbouiCOM.EditText U_PROAPP = Matrix0.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                                    U_PROAPP.Value = "Yes";
                                }
                                else
                                {
                                    SAPbouiCOM.EditText U_PROAPP = Matrix0.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                                    U_PROAPP.Value = "No";
                                }
                            }
                        }
                    }
                }
                for (int i = 1; i < Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText U_PARENTITM = Matrix0.GetCellSpecific("U_ITNPARENTITM", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText U_PROMOAPPLIED = Matrix0.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;

                    if (string.IsNullOrEmpty(U_PARENTITM.Value) && (string.IsNullOrEmpty(U_PROMOAPPLIED.Value) || U_PROMOAPPLIED.Value == "No") && !string.IsNullOrEmpty(ItemCode.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Multiple promo code found Select to proceed further", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        PromotionSelection promosel = new PromotionSelection(Matrix0, txtCCode.Value, PostingDate.Value);
                        
                        promosel.Show();
                        promoclosed = true; 
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        public void Select_BillAndtradingDisc()
        {
            //for loop for each item 
            try
            {
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText Qty = Matrix0.GetCellSpecific("11", i) as SAPbouiCOM.EditText;

                    SAPbouiCOM.EditText U_ITNBTDAPP = Matrix0.GetCellSpecific("U_ITNBTDAPP", i) as SAPbouiCOM.EditText;
                    if (string.IsNullOrEmpty(U_ITNBTDAPP.Value) && !string.IsNullOrEmpty(ItemCode.Value))
                    {
                        string Query = AllBillAndTDisc(txtCCode.Value, ItemCode.Value);
                        resetRec();
                        rec.DoQuery(Query);
                        if (rec.RecordCount > 0)
                        {
                            if (rec.RecordCount == 1)
                            {
                                string Billdisc = rec.Fields.Item("U_ITNBILLDISC").Value.ToString();
                                string TRADisc = rec.Fields.Item("U_TRADEDISC").Value.ToString();

                                if (!string.IsNullOrEmpty(Billdisc) && Convert.ToDouble(Billdisc) > 0)
                                {
                                    string EXbilldisc = (((SAPbouiCOM.EditText)Matrix0.Columns.Item("15").Cells.Item(i).Specific).Value).ToString();
                                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("15").Cells.Item(i).Specific).Value = (Convert.ToDouble(EXbilldisc) + Convert.ToDouble(Billdisc)).ToString();
                                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("U_ITNBILLDISC").Cells.Item(i).Specific).Value = Billdisc;
                                    SAPbouiCOM.EditText U_DiscApplied = Matrix0.GetCellSpecific("U_ITNBTDISCAPP", i) as SAPbouiCOM.EditText;
                                    SAPbouiCOM.EditText DiscApp = Matrix0.GetCellSpecific("DiscApp", i) as SAPbouiCOM.EditText;
                                    U_DiscApplied.Value = "Yes";
                                    DiscApp.Value = "Yes"; 
                                }
                                else if (!string.IsNullOrEmpty(TRADisc) && Convert.ToDouble(TRADisc) > 0)
                                {
                                    SAPbouiCOM.EditText DiscApp = Matrix0.GetCellSpecific("DiscApp", i) as SAPbouiCOM.EditText;
                                    txtdisper.Value = (Convert.ToDouble(txtdisper.Value) + Convert.ToDouble(TRADisc)).ToString();
                                    SAPbouiCOM.EditText U_DiscApplied = Matrix0.GetCellSpecific("U_ITNBTDISCAPP", i) as SAPbouiCOM.EditText;
                                    U_DiscApplied.Value = "Yes";
                                    DiscApp.Value = "Yes"; 
                                }
                            }
                        }
                    }
                }
                for (int i = 1; i < Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;

                    SAPbouiCOM.EditText U_PROMOAPPLIED = Matrix0.GetCellSpecific("U_ITNBTDAPP", i) as SAPbouiCOM.EditText;

                    if (string.IsNullOrEmpty(U_PROMOAPPLIED.Value) && !string.IsNullOrEmpty(ItemCode.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Multiple Bill and Trade discount found Select to proceed further", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        BillAndTradeDiscount BillAndTradeDis = new BillAndTradeDiscount(Matrix0, txtCCode.Value);
                        BillAndTradeDis.Show();
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        private void resetRec()
        {
            try
            {
                if (rec != null)
                {
                    rec = null;
                }
                if (rec == null)
                {
                    rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                }
            }
            catch
            {
            }
        }

        private SAPbouiCOM.EditText PostingDate;
        private EditText txtdisper;
        private EditText txtTDisA;
        private EditText txtTotal;

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                //SAPbouiCOM.DataTable Datatobepassed = new SAPbouiCOM.DataTable();

                //string Query = "warehouse item Selection warehouse wise and passing the data.";
                //resetRec();
                //rec.DoQuery(Query);


                //    SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                //    if (!string.IsNullOrEmpty(ItemCode.Value))
                //    {
                Availability Avail = new Availability(Matrix0);
                Avail.Show();
                //    }


            }
            catch
            {
            }
        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //Will check if bill and trade and discount window in open if open will block it.
            //foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
            //{
            //    if (item.Title == "Bill And Trade Discount")
            //    {
            //        BubbleEvent = false;
            //        item.Select();
            //        Program.SBO_Application.StatusBar.SetText("Bill And Tade discount screen is open close it to assign batches.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            //    }
            //}
            //BubbleEvent = true;

        }

        public string AllPromotionCode(string CardCode, string ItemCode, string DocDate, string SalQty)
        {
            try
            {
                string Query = "Select *  ,ROW_NUMBER() OVER () AS \"RowNum\" from ( Select    T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) as \"InvDisc\"  , ifnull(U_DISC, 0) as \"Disc\" , ifnull(U_FRITMSKU, '') as \"FreeItm\" " +
                                   ", ifnull(U_FREEQTY , 0) as \"FreeQty\"  from \"@ITN_OPRO\" T0 inner Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG inner join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCode + "')" +
                                   "or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" and T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "')or T2.\"U_APPVAL\" = 'ItemCode'" +
                                   "where  Ifnull(T0.U_ACTI , 'Y') = 'Y' and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '" + DocDate + "' between U_EFFFRMDT and U_EFFTODT  and 1=(case when  U_PURFRMQTY <= " + SalQty + " and U_PURTOQTY >= " + SalQty + " then 1   else 0 end) and  T1.\"CardCode\" = '" + CardCode + "' and ifnull(U_PURFRMQTY, 0)<> 0 and ifnull(U_PURTOQTY ,  0) <>0 union Select   T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) " +
                                   "as \"InvDisc\"  ,  0 as \"Disc\" , ifnull(U_FRITMSKU, '') as \"FreeItm\" , ifnull(U_FREEQTY , 0) as \"FreeQty\"  from \"@ITN_OPRO\" T0 inner Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG inner join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCode + "') or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" " +
                                   "Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" and T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "')or T2.\"U_APPVAL\" = 'ItemCode' where Ifnull(T0.U_ACTI , 'Y') = 'Y' and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '" + DocDate + "' between U_EFFFRMDT and U_EFFTODT " +
                                   "and  T1.\"CardCode\" = '" + CardCode + "' union Select    T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) as \"InvDisc\"  , ifnull(U_DISC, 0) as \"Disc\" , '' as \"FreeItm\" , 0 as \"FreeQty\"  from \"@ITN_OPRO\" T0 inner Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG inner join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCode + "')" +
                                   "or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" and T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "')or T2.\"U_APPVAL\" = 'ItemCode' where Ifnull(T0.U_ACTI , 'Y') = 'Y' " +
                                   "and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '" + DocDate + "' between U_EFFFRMDT and U_EFFTODT  and 1=(case when  U_PURFRMQTY <= " + SalQty + " and U_PURTOQTY >= " + SalQty + " then 1   else 0 end) and  T1.\"CardCode\" = '" + CardCode + "' and ifnull(U_PURFRMQTY, 0)<> 0 and ifnull(U_PURTOQTY ,  0) <>0) where ifnull(\"FreeItm\" , '') <> '' or \"Disc\"   <> 0 or \"InvDisc\" <> 0";

                return Query;
            }
            catch
            {
                return "";
            }
        }

        public string AllBillAndTDisc(string CardCode, string ItemCode)
        {
            try
            {
                string Query = "Select  T1.* from \"@ITN_BTD1\" T0  inner Join OCRD T1 on  T1.\"CardCode\" = '" + CardCode + "' where " +
                                   " T0.U_CUSTCHN = T1.\"GroupCode\" or T0.\"U_CUSTSUBCHN\" = T1.\"U_SCHANCD\" or T0.\"U_CUST\" = T1.\"CardCode\" or" +
                                   " T0.\"U_BRAND\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') " +
                                   " or T0.\"U_SKU\" =  '" + ItemCode + "'";

                return Query;
            }
            catch
            {
                return "";
            }
        }

       

        private void Button0_ClickBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //check credit limit of customer
            if (!string.IsNullOrEmpty(txtCRlmt.Value) && !string.IsNullOrEmpty(txtTotal.Value))
            {
                if (Convert.ToDouble(txtCRlmt.Value) < Convert.ToDouble(txtTotal.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Total sales order value can't increase the business partner credit limit", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                    return;
                }
            }

        }

        private void Form_ActivateAfter(SBOItemEventArg pVal)
        {
            try
            {
                if (PromotionSelection.promotionclosed && promoclosed)
                {
                    Select_BillAndtradingDisc();
                    promoclosed = false;
                    PromotionSelection.promotionclosed = false;
                }
            }
            catch 
            {
            }

        }

        
    }
}
