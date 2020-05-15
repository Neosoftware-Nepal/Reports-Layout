using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.BillAndTradeDiscount", "BillAndTradeDiscount.b1f")]
    class BillAndTradeDiscount : UserFormBase
    {
        public BillAndTradeDiscount(SAPbouiCOM.Matrix Mtx, string CardCode)
        {
            try
            {
                CardCodeStatic = CardCode;
                LoadMatrixData(Mtx);
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
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_4").Specific));
            this.Matrix0.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix0_ClickAfter);
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_5").Specific));
            this.Matrix1.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix1_ClickAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
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
        }

        private void LoadMatrixData(SAPbouiCOM.Matrix Mtx)
        {
            try
            {
                if (Mtx.VisualRowCount > 0)
                {

                    for (int i = 1; i <= Mtx.VisualRowCount; i++)
                    {

                        SAPbouiCOM.EditText U_ITNBTDISCAPP = Mtx.GetCellSpecific("U_ITNBTDISCAPP", i) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText MtxItemCode = Mtx.GetCellSpecific("1", i) as SAPbouiCOM.EditText;

                        if (string.IsNullOrEmpty(U_ITNBTDISCAPP.Value) && !string.IsNullOrEmpty(MtxItemCode.Value))
                        {
                            Matrix0.AddRow();

                            SAPbouiCOM.EditText Line = Matrix0.GetCellSpecific("#", i) as SAPbouiCOM.EditText;
                            Line.Value = i.ToString();

                            SAPbouiCOM.EditText SOLine = Matrix0.GetCellSpecific("SOline", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText MtxLineId = Mtx.GetCellSpecific("0", i) as SAPbouiCOM.EditText;
                            SOLine.Value = MtxLineId.Value;

                            SAPbouiCOM.EditText SOITEM = Matrix0.GetCellSpecific("SoItms", i) as SAPbouiCOM.EditText;
                            SOITEM.Value = MtxItemCode.Value;

                            SAPbouiCOM.EditText PromoApplied = Matrix0.GetCellSpecific("DiscApp", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText U_PROAPP = Mtx.GetCellSpecific("U_ITNBTDISCAPP", i) as SAPbouiCOM.EditText;
                            PromoApplied.Value = U_PROAPP.Value;


                            Matrix0.AutoResizeColumns();
                            Matrix1.AutoResizeColumns();
                        }
                        //SAPbouiCOM.EditText PromotionCode = Matrix0.GetCellSpecific("PromoCd", i) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText PromotionName = Matrix0.GetCellSpecific("PromNme", i) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText PromoLine = Matrix0.GetCellSpecific("PromoLn", i) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText Discount = Matrix0.GetCellSpecific("Disc", i) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText FreeItem = Matrix0.GetCellSpecific("FreeItm", i) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText EffectiveFrom = Matrix0.GetCellSpecific("EffFDt", i) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText EffectiveTo = Matrix0.GetCellSpecific("EffToDt", i) as SAPbouiCOM.EditText;
                    }
                }
            }
            catch
            {
            }
        }

        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Button Button3;
        private static string CardCodeStatic;
        private int HeaderLineId = 0;
        private int SORowno = 0;
        private SAPbouiCOM.Form Oform;

        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "ChkChoose")
                {
                    SAPbouiCOM.CheckBox AppPromo = Matrix0.GetCellSpecific("ChkChoose", pVal.Row) as SAPbouiCOM.CheckBox;
                    if (AppPromo.Checked)
                    {
                        Matrix1.Clear();
                        SAPbouiCOM.EditText SoLine = Matrix0.GetCellSpecific("SOline", pVal.Row) as SAPbouiCOM.EditText;
                        HeaderLineId = pVal.Row;
                        SORowno = Convert.ToInt32(SoLine.Value);
                        SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("SoItms", HeaderLineId) as SAPbouiCOM.EditText;

                        string Query = AllBillAndTDisc(CardCodeStatic, ItemCode.Value);
                        Oform.DataSources.DataTables.Item("dtLoad").ExecuteQuery(Query);
                        if (!Oform.DataSources.DataTables.Item("dtLoad").IsEmpty)
                        {
                            Matrix1.Columns.Item("#").DataBind.Bind("dtLoad", "RowNum");
                            Matrix1.Columns.Item("BillDisc").DataBind.Bind("dtLoad", "BillDisc");
                            Matrix1.Columns.Item("TrdDisc").DataBind.Bind("dtLoad", "TradeDisc");

                            Matrix1.LoadFromDataSource();
                            Matrix1.AutoResizeColumns();
                        }
                    }
                    else
                    {
                        Matrix1.Clear();
                    }
                }
            }
            catch
            {
            }
        }

        private void Matrix1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)  
        {
            try
            {
                if (pVal.ColUID == "AppDisc")
                {
                    
                    SAPbouiCOM.CheckBox AppPromo = Matrix1.GetCellSpecific("AppDisc", pVal.Row) as SAPbouiCOM.CheckBox;
                    SAPbouiCOM.EditText PromoApplied = Matrix0.GetCellSpecific("DiscApp", HeaderLineId) as SAPbouiCOM.EditText;
                    if (AppPromo.Checked)
                    {
                        for (int i = 1; i <= Matrix1.RowCount; i++)
                        {
                            SAPbouiCOM.CheckBox AppPromo1 = Matrix1.GetCellSpecific("AppDisc", i) as SAPbouiCOM.CheckBox;
                            if (i != pVal.Row)
                            {
                                if (AppPromo1.Checked)
                                {
                                    Program.SBO_Application.StatusBar.SetText("One Bill and trade discount is already applied", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    AppPromo.Checked = false;
                                    return;
                                }    
                            }
                            
                        }
                        if (PromoApplied.Value == "No" || string.IsNullOrEmpty(PromoApplied.Value))
                        {
                            SAPbouiCOM.EditText Billdisc = Matrix1.GetCellSpecific("BillDisc", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText TraDisc = Matrix1.GetCellSpecific("TrdDisc", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText DiscApp = Matrix0.GetCellSpecific("DiscApp", HeaderLineId) as SAPbouiCOM.EditText;
                            
                            SAPbouiCOM.Matrix mtx = null;
                            SAPbouiCOM.Form fmr2 = null ;
                            foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                            {
                                if (item.Title == "Sales Order")
                                {
                                    fmr2 = item;
                                    mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("38").Specific));
                                }
                            }
                            if (!string.IsNullOrEmpty(Billdisc.Value) && Convert.ToDouble(Billdisc.Value) > 0)
                            {
                                ((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(SORowno).Specific).Value = (Convert.ToDouble(((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(SORowno).Specific).Value) + Convert.ToDouble(Billdisc.Value)).ToString();
                                ((SAPbouiCOM.EditText)mtx.Columns.Item("U_ITNBILLDISC").Cells.Item(SORowno).Specific).Value = Billdisc.Value.ToString(); 
                                SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNBTDISCAPP", SORowno) as SAPbouiCOM.EditText;

                                U_DiscApplied.Value = "Yes";
                                DiscApp.Value = "Yes"; 

                            }
                            if (!string.IsNullOrEmpty(TraDisc.Value) && Convert.ToDouble(TraDisc.Value) > 0)
                            {
                                SAPbouiCOM.EditText disc = ((SAPbouiCOM.EditText)(fmr2.Items.Item("txtdisper").Specific));
                                SAPbouiCOM.EditText tradeDisAmt = ((SAPbouiCOM.EditText)(fmr2.Items.Item("txttdAmt").Specific));
                                SAPbouiCOM.EditText totbefDis = ((SAPbouiCOM.EditText)(fmr2.Items.Item("22").Specific));
                                SAPbouiCOM.EditText SOdis = ((SAPbouiCOM.EditText)(fmr2.Items.Item("24").Specific));
                                
                                disc.Value = ( Convert.ToDouble(disc.Value) + Convert.ToDouble(TraDisc.Value)).ToString();
                                tradeDisAmt.Value = ((Convert.ToDouble(totbefDis.Value.Split(' ')[1]) * Convert.ToDouble(disc.Value) / 100) ).ToString(); 
                                SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNBTDISCAPP", SORowno) as SAPbouiCOM.EditText;
                                SOdis.Value = disc.Value; 
                                U_DiscApplied.Value = "Yes";
                                DiscApp.Value = "Yes"; 
                            }                            
                        }
                    }
                    else
                    {
                        SAPbouiCOM.EditText Billdisc = Matrix1.GetCellSpecific("BillDisc", pVal.Row) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText TraDisc = Matrix1.GetCellSpecific("TrdDisc", pVal.Row) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText DiscApp = Matrix0.GetCellSpecific("DiscApp", HeaderLineId) as SAPbouiCOM.EditText;                    
                        SAPbouiCOM.Matrix mtx = null;
                        SAPbouiCOM.Form fmr2 = null;;
                        foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                        {
                            if (item.Title == "Sales Order")
                            {
                                fmr2 = item;
                                mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("38").Specific));
                            }
                        }
                        if (!string.IsNullOrEmpty(Billdisc.Value) && Convert.ToDouble(Billdisc.Value) > 0)
                        {
                            ((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(SORowno).Specific).Value = (Convert.ToDouble(((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(SORowno).Specific).Value) - Convert.ToDouble(Billdisc.Value)).ToString();
                            SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNBTDISCAPP", SORowno) as SAPbouiCOM.EditText;
                            U_DiscApplied.Value = "No";
                            DiscApp.Value = "No"; 
                        }
                         if (!string.IsNullOrEmpty(TraDisc.Value) && Convert.ToDouble(TraDisc.Value) > 0)
                        {
                            SAPbouiCOM.EditText disc = ((SAPbouiCOM.EditText)(fmr2.Items.Item("txtdisper").Specific));
                            SAPbouiCOM.EditText tradeDisAmt = ((SAPbouiCOM.EditText)(fmr2.Items.Item("txttdAmt").Specific));
                            SAPbouiCOM.EditText totbefDis = ((SAPbouiCOM.EditText)(fmr2.Items.Item("22").Specific));
                            SAPbouiCOM.EditText SOdis = ((SAPbouiCOM.EditText)(fmr2.Items.Item("24").Specific));

                            disc.Value = (Convert.ToDouble(disc.Value) - Convert.ToDouble(TraDisc.Value)).ToString();
                            tradeDisAmt.Value = ((Convert.ToDouble(totbefDis.Value.Split(' ')[1]) * Convert.ToDouble(disc.Value) / 100)).ToString();
                            SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNBTDISCAPP", SORowno) as SAPbouiCOM.EditText;
                            SOdis.Value = disc.Value;
                            U_DiscApplied.Value = "No";
                            DiscApp.Value = "No"; 
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public string AllBillAndTDisc(string CardCode, string ItemCode)
        {
            try
            {
                string Query = "Select  U_BILLDISC as \"BillDisc\" , U_TRDDISC as \"TradeDisc\" , ROW_NUMBER() OVER () AS \"RowNum\" from \"@ITN_BTD1\" T0  inner Join OCRD T1 on  T1.\"CardCode\" = '" + CardCode + "' where " +
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
    }
}
