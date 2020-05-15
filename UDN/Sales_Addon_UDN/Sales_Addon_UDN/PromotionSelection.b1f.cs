using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.PromotionSelection", "PromotionSelection.b1f")]
    class PromotionSelection : UserFormBase
    {
        public PromotionSelection(SAPbouiCOM.Matrix Mtx, string CardCode, string Date)
        {
            try
            {
                SODate = Date;
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
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_0").Specific));
            this.Matrix0.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix0_ClickAfter);
            this.Matrix0.ComboSelectBefore += new SAPbouiCOM._IMatrixEvents_ComboSelectBeforeEventHandler(this.Matrix0_ComboSelectBefore);
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_1").Specific));
            this.Matrix1.ClickBefore += new SAPbouiCOM._IMatrixEvents_ClickBeforeEventHandler(this.Matrix1_ClickBefore);
            this.Matrix1.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix1_ClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button1.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button1_PressedBefore);
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.CloseAfter += new CloseAfterHandler(this.Form_CloseAfter);

        }

        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        public static string CardCodeStatic;
        public static string SODate;
        public delegate void SelectionLoaded(bool item);
        public SelectionLoaded AddItemCallback;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Notification subscribers
            
        }

        private void OnCustomInitialize()
        {

        }

        private int HeaderLineId = 0;
        private int SORowno = 0;

        private SAPbouiCOM.Form Oform;

        private void LoadMatrixData(SAPbouiCOM.Matrix Mtx)
        {
            try
            {
                if (Mtx.VisualRowCount > 0)
                {

                    for (int i = 1; i <= Mtx.VisualRowCount; i++)
                    {

                        SAPbouiCOM.EditText U_PARENTITM = Mtx.GetCellSpecific("U_ITNPARENTITM", i) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText U_PROMOAPPLIED = Mtx.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText MtxItemCode = Mtx.GetCellSpecific("1", i) as SAPbouiCOM.EditText;

                        if (string.IsNullOrEmpty(U_PARENTITM.Value) && (string.IsNullOrEmpty(U_PROMOAPPLIED.Value) || U_PROMOAPPLIED.Value == "No") && !string.IsNullOrEmpty(MtxItemCode.Value))
                        {
                            Matrix0.AddRow();

                            SAPbouiCOM.EditText Line = Matrix0.GetCellSpecific("#", i) as SAPbouiCOM.EditText;
                            Line.Value = i.ToString();

                            SAPbouiCOM.EditText SOLine = Matrix0.GetCellSpecific("SOline", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText MtxLineId = Mtx.GetCellSpecific("0", i) as SAPbouiCOM.EditText;
                            SOLine.Value = MtxLineId.Value;

                            SAPbouiCOM.EditText SOITEM = Matrix0.GetCellSpecific("SoItms", i) as SAPbouiCOM.EditText;

                            SOITEM.Value = MtxItemCode.Value;

                            SAPbouiCOM.EditText SalQty = Matrix0.GetCellSpecific("SalQty", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText MtxQuantity = Mtx.GetCellSpecific("11", i) as SAPbouiCOM.EditText;
                            SalQty.Value = MtxQuantity.Value;

                            SAPbouiCOM.EditText PromoApplied = Matrix0.GetCellSpecific("PromApp", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText U_PROAPP = Mtx.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
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

        private void Matrix0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;


        }

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }

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
                        SAPbouiCOM.EditText SalQty = Matrix0.GetCellSpecific("SalQty", HeaderLineId) as SAPbouiCOM.EditText;

                        //string Query = "Select  ROW_NUMBER() OVER (PARTITION BY U_DISC ) AS \"RowNum\" , T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) " +
                        //                "as \"InvDisc\"  , ifnull(U_DISC, 0) as \"Disc\" , ifnull(U_FRITMSKU, '') as \"FreeItm\" " +
                        //                ", ifnull(U_FREEQTY , 0) as \"FreeQty\"  from \"@ITN_OPRO\" T0 " +
                        //                "inner Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG inner join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCodeStatic + "')" +
                        //                "or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" " +
                        //                "Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" and T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" =  '" + ItemCode.Value + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode.Value + "')or T2.\"U_APPVAL\" = 'ItemCode'" +
                        //                "where Ifnull(T0.U_ACTI , 'Y') = 'Y' and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '"+SODate+"' between U_EFFFRMDT and U_EFFTODT and 1=(case when  U_PURFRMQTY <= " + SalQty.Value + " and U_PURTOQTY >= " + SalQty.Value + " then 1   else 0 end) " +
                        //                "and  T1.\"CardCode\" = '" + CardCodeStatic + "' and ifnull(U_PURFRMQTY, 0)<> 0 and ifnull(U_PURTOQTY ,  0) <>0 ";

                        //SalesOrder so = new SalesOrder();
                        string Query = AllPromotionCode(CardCodeStatic, ItemCode.Value, SODate, SalQty.Value);
                        Oform.DataSources.DataTables.Item("dtLoad").ExecuteQuery(Query);
                        if (!Oform.DataSources.DataTables.Item("dtLoad").IsEmpty)
                        {
                            Matrix1.Columns.Item("#").DataBind.Bind("dtLoad", "RowNum");
                            Matrix1.Columns.Item("ProCode").DataBind.Bind("dtLoad", "U_PCODE");
                            Matrix1.Columns.Item("PromLn").DataBind.Bind("dtLoad", "U_PNAME");
                            Matrix1.Columns.Item("Discount").DataBind.Bind("dtLoad", "Disc");
                            Matrix1.Columns.Item("InvDisc").DataBind.Bind("dtLoad", "InvDisc");
                            Matrix1.Columns.Item("FreeItm").DataBind.Bind("dtLoad", "FreeItm");
                            Matrix1.Columns.Item("FreeQty").DataBind.Bind("dtLoad", "FreeQty");

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
                if (pVal.ColUID == "AppPromo")
                {
                    SAPbouiCOM.CheckBox AppPromo = Matrix1.GetCellSpecific("AppPromo", pVal.Row) as SAPbouiCOM.CheckBox;
                    SAPbouiCOM.EditText PromoApplied = Matrix0.GetCellSpecific("PromApp", HeaderLineId) as SAPbouiCOM.EditText;
                    if (AppPromo.Checked)
                    {
                        if (PromoApplied.Value == "No" || string.IsNullOrEmpty(PromoApplied.Value))
                        {
                            SAPbouiCOM.EditText disc = Matrix1.GetCellSpecific("Discount", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText InvDisc = Matrix1.GetCellSpecific("InvDisc", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText FreeItem = Matrix1.GetCellSpecific("FreeItm", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.Matrix mtx = null;
                            SAPbouiCOM.DataSource DBS = null; 
                            foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                            {
                                if (item.Title == "Sales Order")
                                {
                                    SAPbouiCOM.Form fmr2 = item;
                                    mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("38").Specific));
                                    
                                }
                            }
                            if (!string.IsNullOrEmpty(disc.Value) && Convert.ToDouble(disc.Value) > 0)
                            {
                                ((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value = (((Convert.ToDouble(((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value))) + Convert.ToDouble(disc.Value)).ToString();
                                SAPbouiCOM.EditText U_PROMOApplied = mtx.GetCellSpecific("U_ITNPROMOCD", SORowno) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText ProCode = Matrix1.GetCellSpecific("ProCode", pVal.Row) as SAPbouiCOM.EditText;
                                U_PROMOApplied.Value = ProCode.Value;

                                
                                //fillthe promo discount percentage 
                                SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNPRODISPR", SORowno) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText Discount = Matrix1.GetCellSpecific("Discount", pVal.Row) as SAPbouiCOM.EditText;
                                U_DiscApplied.Value = Discount.Value;

                                //calculate promotion amount after discount
                                string UnitPrice = (((SAPbouiCOM.EditText)mtx.Columns.Item("14").Cells.Item(HeaderLineId).Specific).Value).ToString();
                                string QTY = (((SAPbouiCOM.EditText)mtx.Columns.Item("11").Cells.Item(HeaderLineId).Specific).Value).ToString();
                                SAPbouiCOM.EditText U_ITNPRODISAM = mtx.GetCellSpecific("U_ITNPRODISAM", SORowno) as SAPbouiCOM.EditText;
                                U_ITNPRODISAM.Value = ((Convert.ToDouble(UnitPrice.Split(' ')[1]) * Convert.ToDouble(QTY)) * Convert.ToDouble(Discount.Value) / 100).ToString();

                               
                            }
                            else if (!string.IsNullOrEmpty(InvDisc.Value) && Convert.ToDouble(InvDisc.Value) > 0)
                            {
                                ((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value = (((Convert.ToDouble(((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value))) + Convert.ToDouble(InvDisc.Value)).ToString();
                                SAPbouiCOM.EditText U_PROMOApplied = mtx.GetCellSpecific("U_ITNPROMOCD", SORowno) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText ProCode = Matrix1.GetCellSpecific("ProCode", pVal.Row) as SAPbouiCOM.EditText;
                                U_PROMOApplied.Value = ProCode.Value;
                                
                                //fill the promo invoice discount percentage 
                                SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNPRODISPR", SORowno) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText Discount = Matrix1.GetCellSpecific("InvDisc", pVal.Row) as SAPbouiCOM.EditText;
                                U_DiscApplied.Value = Discount.Value;

                                //calculate promotion amount after discount
                                string UnitPrice = (((SAPbouiCOM.EditText)mtx.Columns.Item("14").Cells.Item(HeaderLineId).Specific).Value).ToString();
                                string QTY = (((SAPbouiCOM.EditText)mtx.Columns.Item("11").Cells.Item(HeaderLineId).Specific).Value).ToString();
                                SAPbouiCOM.EditText U_ITNPRODISAM = mtx.GetCellSpecific("U_ITNPRODISAM", SORowno) as SAPbouiCOM.EditText;
                                U_ITNPRODISAM.Value = ((Convert.ToDouble(UnitPrice.Split(' ')[1]) * Convert.ToDouble(QTY)) * Convert.ToDouble(Discount.Value) / 100).ToString();

                                
                            }
                            else if (!string.IsNullOrEmpty(FreeItem.Value))
                            {
                                mtx.AddRow(1, SORowno);
                                ((SAPbouiCOM.EditText)mtx.Columns.Item("1").Cells.Item(SORowno + 1).Specific).Value = FreeItem.Value;
                                SAPbouiCOM.EditText U_ParentCd = mtx.GetCellSpecific("U_ITNPARENTITM", SORowno + 1) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText U_PROMOApplied = mtx.GetCellSpecific("U_ITNPROMOCD", SORowno) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText ProCode = Matrix1.GetCellSpecific("ProCode", pVal.Row) as SAPbouiCOM.EditText;
                                U_PROMOApplied.Value = ProCode.Value;
                                SAPbouiCOM.EditText MtxItemCode = mtx.GetCellSpecific("1", SORowno) as SAPbouiCOM.EditText;
                                U_ParentCd.Value = MtxItemCode.Value;
                                reloadmatrixSOLine();

                            }
                            SAPbouiCOM.EditText U_PROAPP = mtx.GetCellSpecific("U_ITNPROMOAPP", SORowno) as SAPbouiCOM.EditText;
                            U_PROAPP.Value = "Yes";
                            PromoApplied.Value = "Yes";
                        }

                    }
                    else
                    {
                        SAPbouiCOM.EditText disc = Matrix1.GetCellSpecific("Discount", pVal.Row) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText FreeItem = Matrix1.GetCellSpecific("FreeItm", pVal.Row) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText InvDisc = Matrix1.GetCellSpecific("InvDisc", pVal.Row) as SAPbouiCOM.EditText;
                        SAPbouiCOM.Matrix mtx = null;
                        foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                        {
                            if (item.Title == "Sales Order")
                            {
                                SAPbouiCOM.Form fmr2 = item;
                                mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("38").Specific));
                            }
                        }
                        if (!string.IsNullOrEmpty(disc.Value) && Convert.ToDouble(disc.Value) > 0)
                        {
                            ((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value = (((Convert.ToDouble(((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value))) - Convert.ToDouble(InvDisc.Value)).ToString(); ;
                            SAPbouiCOM.EditText U_PROAPP = mtx.GetCellSpecific("U_ITNPROMOAPP", HeaderLineId) as SAPbouiCOM.EditText;
                            U_PROAPP.Value = "No";
                            PromoApplied.Value = "No";
                            SAPbouiCOM.EditText U_PROMOApplied = mtx.GetCellSpecific("U_ITNPROMOCD", SORowno) as SAPbouiCOM.EditText;
                            U_PROMOApplied.Value = "";

                            //fillthe promo discount percentage 
                            SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNPRODISPR", SORowno) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText Discount = Matrix1.GetCellSpecific("Discount", pVal.Row) as SAPbouiCOM.EditText;
                            U_DiscApplied.Value = "0";

                            //calculate promotion amount after discount
                            string UnitPrice = (((SAPbouiCOM.EditText)mtx.Columns.Item("14").Cells.Item(HeaderLineId).Specific).Value).ToString();
                            string QTY = (((SAPbouiCOM.EditText)mtx.Columns.Item("11").Cells.Item(HeaderLineId).Specific).Value).ToString();
                            SAPbouiCOM.EditText U_ITNPRODISAM = mtx.GetCellSpecific("U_ITNPRODISAM", SORowno) as SAPbouiCOM.EditText;
                            U_DiscApplied.Value = "0";
                        }

                        else if (!string.IsNullOrEmpty(InvDisc.Value) && Convert.ToDouble(InvDisc.Value) > 0)
                        {
                            ((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value = (((Convert.ToDouble(((SAPbouiCOM.EditText)mtx.Columns.Item("15").Cells.Item(HeaderLineId).Specific).Value))) - Convert.ToDouble(InvDisc.Value)).ToString();
                            SAPbouiCOM.EditText U_PROAPP = mtx.GetCellSpecific("U_ITNPROMOAPP", HeaderLineId) as SAPbouiCOM.EditText;
                            U_PROAPP.Value = "No";
                            PromoApplied.Value = "No";
                            SAPbouiCOM.EditText U_PROMOApplied = mtx.GetCellSpecific("U_ITNPROMOCD", SORowno) as SAPbouiCOM.EditText;
                            U_PROMOApplied.Value = "";

                            //fill the promo invoice discount percentage 
                            SAPbouiCOM.EditText U_DiscApplied = mtx.GetCellSpecific("U_ITNPRODISPR", SORowno) as SAPbouiCOM.EditText;
                            U_DiscApplied.Value = "0";

                            //calculate promotion amount after discount
                            SAPbouiCOM.EditText U_ITNPRODISAM = mtx.GetCellSpecific("U_ITNPRODISAM", SORowno) as SAPbouiCOM.EditText;
                            U_DiscApplied.Value = "0";

                        }
                        else if (!string.IsNullOrEmpty(FreeItem.Value))
                        {
                            mtx.DeleteRow(SORowno + 1);

                            SAPbouiCOM.EditText U_PROAPP = mtx.GetCellSpecific("U_ITNPROMOAPP", SORowno) as SAPbouiCOM.EditText;
                            U_PROAPP.Value = "No";
                            PromoApplied.Value = "No";
                            SAPbouiCOM.EditText U_PROMOApplied = mtx.GetCellSpecific("U_ITNPROMOCD", SORowno) as SAPbouiCOM.EditText;

                            U_PROMOApplied.Value = "";
                            reloadmatrixSOLine();
                            //SAPbouiCOM.EditText SOline = Matrix0.GetCellSpecific("SOline", HeaderLineId ) as SAPbouiCOM.EditText;
                            //SOline.Value = (Convert.ToInt16(SOline.Value) - 1).ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public string AllPromotionCode(string CardCode, string ItemCode, string DocDate, string SalQty)
        {
            try
            {
                string Query = "Select *  ,ROW_NUMBER() OVER () AS \"RowNum\" from ( Select    T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) as \"InvDisc\"  , ifnull(U_DISC, 0) as \"Disc\" , ifnull(U_FRITMSKU, '') as \"FreeItm\" " +
                                   ", ifnull(U_FREEQTY , 0) as \"FreeQty\"  from \"@ITN_OPRO\" T0 Left Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG Left Join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCode + "')" +
                                   "or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" or T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "')or T2.\"U_APPVAL\" = 'ItemCode'" +
                                   "where  Ifnull(T0.U_ACTI , 'Y') = 'Y' and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '" + DocDate + "' between U_EFFFRMDT and U_EFFTODT  and 1=(case when  U_PURFRMQTY <= " + SalQty + " and U_PURTOQTY >= " + SalQty + " then 1   else 0 end) or  T1.\"CardCode\" = '" + CardCode + "' and ifnull(U_PURFRMQTY, 0)<> 0 and ifnull(U_PURTOQTY ,  0) <>0 union Select   T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) " +
                                   "as \"InvDisc\"  ,  0 as \"Disc\" , ifnull(U_FRITMSKU, '') as \"FreeItm\" , ifnull(U_FREEQTY , 0) as \"FreeQty\"  from \"@ITN_OPRO\" T0 Left Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG Left Join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCode + "') or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" " +
                                   "Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" or T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "')or T2.\"U_APPVAL\" = 'ItemCode' where Ifnull(T0.U_ACTI , 'Y') = 'Y' and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '" + DocDate + "' between U_EFFFRMDT and U_EFFTODT " +
                                   "or  T1.\"CardCode\" = '" + CardCode + "' union Select    T0.\"U_PCODE\" , T0.\"U_PNAME\" , ifnull(T2.U_INVDISC , 0) as \"InvDisc\"  , ifnull(U_DISC, 0) as \"Disc\" , '' as \"FreeItm\" , 0 as \"FreeQty\"  from \"@ITN_OPRO\" T0 Left Join OCRD T1 on T0.U_CUSTCHNL = (Select \"GroupName\" from OCRG Left Join OCRD on OCRD.\"GroupCode\" = OCRG.\"GroupCode\" where OCRD.\"CardCode\" = '" + CardCode + "')" +
                                   "or T0.\"U_CSUBCHNL\" = T1.\"U_SCHANCD\" or T0.\"U_CUSTOMER\" = \"CardCode\" Inner JOIN \"@ITN_PRO1\" T2 on T0.\"DocEntry\" = T2.\"DocEntry\" or T2.\"U_APPVAL\" = (Select \"U_BRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "') or   T2.\"U_APPVAL\" =  (Select \"U_SUBBRND\" from OITM Where \"ItemCode\" = '" + ItemCode + "')or T2.\"U_APPVAL\" = 'ItemCode' where Ifnull(T0.U_ACTI , 'Y') = 'Y' " +
                                   "and Ifnull(T2.U_ACTI , 'Y') = 'Y' and '" + DocDate + "' between U_EFFFRMDT and U_EFFTODT  and 1=(case when  U_PURFRMQTY <= " + SalQty + " and U_PURTOQTY >= " + SalQty + " then 1   else 0 end) or  T1.\"CardCode\" = '" + CardCode + "' and ifnull(U_PURFRMQTY, 0)<> 0 and ifnull(U_PURTOQTY ,  0) <>0) where ifnull(\"FreeItm\" , '') <> '' or \"Disc\"   <> 0 or \"InvDisc\" <> 0";

                return Query;
            }
            catch
            {
                return "";
            }
        }

        private void Matrix1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.ColUID == "AppPromo")
            {

            }

        }

        private void reloadmatrixSOLine()
        {
            SAPbouiCOM.Matrix Mtx = null;
            try
            {
                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Sales Order")
                    {
                        SAPbouiCOM.Form fmr2 = item;
                        Mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("38").Specific));
                    }
                }
                for (int i = 1; i <= Mtx.VisualRowCount; i++)
                {

                    SAPbouiCOM.EditText U_PARENTITM = Mtx.GetCellSpecific("U_ITNPARENTITM", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText U_PROMOAPPLIED = Mtx.GetCellSpecific("U_ITNPROMOAPP", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText MtxItemCode = Mtx.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                    for (int j = 1; j <= Matrix0.RowCount; j++)
                    {
                        SAPbouiCOM.EditText PromAll = Matrix0.GetCellSpecific("PromApp", j) as SAPbouiCOM.EditText;
                        if (PromAll.Value != "Y" && string.IsNullOrEmpty(U_PARENTITM.Value) && (string.IsNullOrEmpty(U_PROMOAPPLIED.Value) || U_PROMOAPPLIED.Value == "No") && !string.IsNullOrEmpty(MtxItemCode.Value))
                        {
                            SAPbouiCOM.EditText SOItemCode = Matrix0.GetCellSpecific("SoItms", j) as SAPbouiCOM.EditText;
                            if (MtxItemCode.Value == SOItemCode.Value)
                            {
                                SAPbouiCOM.EditText SOLine = Matrix0.GetCellSpecific("SOline", j) as SAPbouiCOM.EditText;
                                SAPbouiCOM.EditText MtxLineId = Mtx.GetCellSpecific("0", i) as SAPbouiCOM.EditText;
                                SOLine.Value = MtxLineId.Value;
                            }

                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void Button1_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText PromApp = Matrix0.GetCellSpecific("PromApp", i) as SAPbouiCOM.EditText;
                    if (string.IsNullOrEmpty(PromApp.Value) || PromApp.Value == "No")
                    {
                        Program.SBO_Application.StatusBar.SetText("Not all the items have promocode applied", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        BubbleEvent = false;
                        return; 
                    }
                }
            }
            catch 
            {
            }
        }

        public static bool promotionclosed  = false ; 
        private void Form_CloseAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                promotionclosed = true;

            }
            catch 
            {
                
            }
        }
    }
}
