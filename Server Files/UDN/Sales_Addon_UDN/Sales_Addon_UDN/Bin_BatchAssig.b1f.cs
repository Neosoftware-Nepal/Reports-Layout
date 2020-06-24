using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.Bin_BatchAssig", "Bin_BatchAssig.b1f")]
    class Bin_BatchAssig : UserFormBase
    {
        public Bin_BatchAssig(SAPbouiCOM.Matrix mtx, string ItemCode, string warehouse)
        {
            try
            {
                ItemCd = ItemCode;
                WhseCode = warehouse;
                LoadData(mtx);

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
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_1").Specific));
            this.Matrix1.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix1_ClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
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

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Form Oform;
        private SAPbobsCOM.Recordset Rec;
        private int HeaderRow = 0;
        private string ItemCd = "";
        private string WhseCode = "";


        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "Sel")
                {
                    HeaderRow = pVal.Row;
                    SAPbouiCOM.CheckBox Selected = Matrix0.GetCellSpecific("Sel", pVal.Row) as SAPbouiCOM.CheckBox;
                    if (Selected.Checked)
                    {
                        SAPbouiCOM.EditText Mtx0ItemCode = Matrix0.GetCellSpecific("ItmCode", pVal.Row) as SAPbouiCOM.EditText;
                        //SAPbouiCOM.EditText Mtx0Whs = Matrix0.GetCellSpecific("WhseCd", pVal.Row) as SAPbouiCOM.EditText;
                        string Query = getbins(Mtx0ItemCode.Value, WhseCode);
                        Oform.DataSources.DataTables.Item("dtLoad").ExecuteQuery(Query);
                        if (!Oform.DataSources.DataTables.Item("dtLoad").IsEmpty)
                        {
                            Matrix1.Columns.Item("LnIDM1").DataBind.Bind("dtLoad", "row_num");
                            Matrix1.Columns.Item("BinCd").DataBind.Bind("dtLoad", "BinCode");
                            Matrix1.Columns.Item("TotCap").DataBind.Bind("dtLoad", "U_ITNTOTCAP");
                            Matrix1.Columns.Item("Occup").DataBind.Bind("dtLoad", "U_ITNOCCU");
                            Matrix1.Columns.Item("Avail").DataBind.Bind("dtLoad", "U_ITNAVAIL");
                            Matrix1.Columns.Item("AvailQty").DataBind.Bind("dtLoad", "U_ITNAVAILQTY");
                            Matrix1.LoadFromDataSource();
                            Matrix1.AutoResizeColumns();
                        }
                    }
                    else
                    {
                        Matrix1.Clear();
                        Matrix1.AutoResizeColumns();
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
                if (pVal.ColUID == "SelectBin")
                {
                    SAPbouiCOM.CheckBox BinSelected = Matrix1.GetCellSpecific("SelectBin", pVal.Row) as SAPbouiCOM.CheckBox;
                    SAPbouiCOM.EditText AvailQty = Matrix1.GetCellSpecific("Avail", pVal.Row) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText Occupied = Matrix1.GetCellSpecific("Occup", pVal.Row) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText RemaingQty = Matrix0.GetCellSpecific("Rem", HeaderRow) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText Quantity = Matrix0.GetCellSpecific("Qty", HeaderRow) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BinCd = Matrix1.GetCellSpecific("BinCd", pVal.Row) as SAPbouiCOM.EditText;

                    if (BinSelected.Checked)
                    {
                        if (Convert.ToDouble(RemaingQty.Value) > 0)
                        {
                            ////release Allocated Field
                            SAPbouiCOM.EditText Allocated = Matrix1.GetCellSpecific("Allocated", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText AllocatedQTY = Matrix1.GetCellSpecific("AlloQty", pVal.Row) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText AvailQuantity = Matrix1.GetCellSpecific("AvailQty", pVal.Row) as SAPbouiCOM.EditText;
                            //Matrix1.CommonSetting.SetCellEditable(pVal.Row, 6, true);

                            if (Convert.ToDouble(RemaingQty.Value) >= Convert.ToDouble(AvailQty.Value))
                            {
                                ////Allocate full Qty from Avail Area from Reming AREA and Allocate remining Area
                                RemaingQty.Value = (Convert.ToDouble(RemaingQty.Value) - Convert.ToDouble(AvailQty.Value)).ToString();
                                Allocated.Value = AvailQty.Value;

                                ////Update Avail Area
                                AvailQty.Value = "0";

                                ////Update the Allocate Quantity
                                AllocatedQTY.Value = AvailQuantity.Value;

                            }
                            else if (Convert.ToDouble(RemaingQty.Value) < Convert.ToDouble(AvailQty.Value))
                            {
                                ////allocate Remaining Quanity and make remining Qty 0
                                Allocated.Value = RemaingQty.Value;
                                RemaingQty.Value = "0";

                                ////Update Avail Area
                                AvailQty.Value = (Convert.ToDouble(AvailQty.Value) - Convert.ToDouble(Allocated.Value)).ToString();

                                ////Update the Allocate Quantity
                                double AllocaedQty = 0;
                                for (int j = 1; j < Matrix1.RowCount; j++)
                                {
                                    SAPbouiCOM.EditText AllocatedQty = Matrix1.GetCellSpecific("AlloQty", j) as SAPbouiCOM.EditText;
                                    if (!string.IsNullOrEmpty(AllocatedQty.Value))
                                    {
                                        AllocaedQty = AllocaedQty + Convert.ToDouble(AllocatedQty.Value);
                                    }
                                }
                                AllocatedQTY.Value = (Convert.ToDouble(Quantity.Value) - AllocaedQty).ToString();
                            }

                            ////Common Fields Update. 
                            ////Update Occupied Qty and avail Qty.
                            Occupied.Value = (Convert.ToDouble(Occupied.Value) + Convert.ToDouble(Allocated.Value)).ToString();

                            //Update BinSelected and BinQty.
                            UpdateSelectedBins();

                            ////Update Avil and Occupied Qty in OBIN.
                            UpdateAllocated_AvailQty_IN_OBIN(Occupied.Value, AvailQty.Value, BinCd.Value);
                            Matrix1.Columns.Item("Area").Width = 50;
                            Matrix1.Columns.Item("Occup").Width = 50;
                            //Matrix1.AutoResizeColumns();
                            UIAPIRawForm.Refresh();
                        }
                        else
                        {
                            //Matrix0.CommonSetting.SetCellEditable(6, pVal.Row, false);

                            Program.SBO_Application.StatusBar.SetText("Remaing Quantity for the seleted item is 0", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BinSelected.Checked = false;
                        }
                    }
                    else
                    {
                        ////release Allocated Field
                        SAPbouiCOM.EditText Allocated = Matrix1.GetCellSpecific("Allocated", pVal.Row) as SAPbouiCOM.EditText;

                        //// remaing Quantity 
                        RemaingQty.Value = (Convert.ToDouble(RemaingQty.Value) + Convert.ToDouble(Allocated.Value)).ToString();

                        ////releasing the alocated Qty 
                        AvailQty.Value = (Convert.ToDouble(AvailQty.Value) + Convert.ToDouble(Allocated.Value)).ToString();
                        Occupied.Value = (Convert.ToDouble(Occupied.Value) - Convert.ToDouble(Allocated.Value)).ToString();
                        Allocated.Value = "0";

                        //Update BinSelected and BinQty.
                        UpdateSelectedBins();

                        ////Update Avil and Occupied Qty in OBIN.
                        UpdateAllocated_AvailQty_IN_OBIN(Occupied.Value, AvailQty.Value, BinCd.Value);
                        Matrix1.Columns.Item("Area").Width = 50;
                        Matrix1.Columns.Item("Rem").Width = 50;
                        //Matrix1.AutoResizeColumns();
                        UIAPIRawForm.Refresh();
                    }
                }
            }
            catch
            {
            }
        }

        private void UpdateAllocated_AvailQty_IN_OBIN(string Occupied, string AvailQty, string bincode)
        {
            try
            {
                ResetRec();
                string Query = "Update OBIN Set \"U_ITNOCCU\" = '" + Occupied + "' , \"U_ITNAVAIL\" = '" + AvailQty + "' Where \"BinCode\" = '" + bincode + "' ";
                Rec.DoQuery(Query);
            }
            catch
            {
            }
        }

        private void DeAssignQty(bool IsCancle)
        {
            try
            {

                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox Selected = Matrix0.GetCellSpecific("Sel", i) as SAPbouiCOM.CheckBox;
                    SAPbouiCOM.EditText BinCode = Matrix0.GetCellSpecific("SelBin", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BinQty = Matrix0.GetCellSpecific("Area", i) as SAPbouiCOM.EditText;
                    if (IsCancle)
                    {
                        if (!string.IsNullOrEmpty(BinCode.Value))
                        {
                            int p = 0;
                            foreach (var item in BinCode.Value.Split(','))
                            {
                                string Query = "Select * from OBIN where  \"BinCode\" = '" + item + "'";
                                ResetRec();
                                Rec.DoQuery(Query);
                                Double OccupiedQty = Convert.ToDouble(Rec.Fields.Item("U_ITNOCCU").Value.ToString());
                                Double AvailableQty = Convert.ToDouble(Rec.Fields.Item("U_ITNAVAIL").Value.ToString());
                                AvailableQty =  AvailableQty + Convert.ToDouble(BinQty.Value.Split(',')[p]) ;
                                OccupiedQty = OccupiedQty - Convert.ToDouble(BinQty.Value.Split(',')[p]) ;
                                UpdateAllocated_AvailQty_IN_OBIN(OccupiedQty.ToString(), AvailableQty.ToString(), item);
                                //Program.SBO_Application.StatusBar.SetText("Calliing 1 ", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                p++;
                            }
                        }
                    }
                    else
                    {
                        if (!Selected.Checked && !string.IsNullOrEmpty(BinCode.Value))
                        {
                            int p = 0;
                            foreach (var item in BinCode.Value.Split(','))
                            {
                                string Query = "Select * from OBIN where  \"BinCode\" = '" + BinCode.Value + "'";
                                ResetRec();
                                Rec.DoQuery(Query);
                                Double OccupiedQty = Convert.ToDouble(Rec.Fields.Item("U_ITNOCCU").Value);
                                Double AvailableQty = Convert.ToDouble(Rec.Fields.Item("U_ITNAVAIL").Value);
                                UpdateAllocated_AvailQty_IN_OBIN((OccupiedQty - Convert.ToDouble(BinQty.Value.Split(',')[p])).ToString(), (AvailableQty + Convert.ToDouble(BinQty.Value.Split(',')[p])).ToString(), item);
                                p++;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void UpdateSelectedBins()
        {
            try
            {
                string binName = "";
                string binQty = "";
                string AlloQty = "";
                SAPbouiCOM.EditText BinName = Matrix0.GetCellSpecific("SelBin", HeaderRow) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText BinQty = Matrix0.GetCellSpecific("Area", HeaderRow) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText AlloQIB = Matrix0.GetCellSpecific("AlloQIB", HeaderRow) as SAPbouiCOM.EditText;

                int p = 1;
                for (int i = 1; i <= Matrix1.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox BinSelected = Matrix1.GetCellSpecific("SelectBin", i) as SAPbouiCOM.CheckBox;
                    SAPbouiCOM.EditText BinNameM1 = Matrix1.GetCellSpecific("BinCd", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText AllocatedM1 = Matrix1.GetCellSpecific("Allocated", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText AlloQty1 = Matrix1.GetCellSpecific("AlloQty", i) as SAPbouiCOM.EditText;

                    if (BinSelected.Checked)
                    {

                        if (p == 1)
                        {
                            binName = BinNameM1.Value;
                            binQty = Math.Round(Convert.ToDouble(AllocatedM1.Value), 2).ToString();
                            AlloQty = AlloQty1.Value;
                            p++;
                        }
                        else
                        {
                            binName = binName + "," + BinNameM1.Value;
                            binQty = binQty + "," + Math.Round(Convert.ToDouble(AllocatedM1.Value), 2).ToString();
                            AlloQty = AlloQty + "," + AlloQty1.Value;
                        }
                    }
                }
                BinName.Value = binName;
                BinQty.Value = binQty;
                AlloQIB.Value = AlloQty;
            }
            catch
            {
            }
        }

        private string getbins(string itemcode, string WhseCode)
        {
            try
            {
                string query = "Select * from ( Select  ROW_NUMBER() OVER (Order by U_ITNAVAIL) AS \"row_num\",\"BinCode\" , \"U_ITNTOTCAP\" , \"U_ITNOCCU\" , Cast(\"U_ITNAVAIL\" as Numeric)as U_ITNAVAIL , TO_INTEGER(Cast(\"U_ITNAVAIL\" as Numeric) / T2.\"BVolume\")   as \"U_ITNAVAILQTY\"  from OBIN T0 Inner join OWHS T1 on  T0.\"WhsCode\" = T1.\"WhsCode\"" +
                                    "Inner Join OITM T2 on T0.\"U_ITNDEFIGRP\" = T2.\"ItmsGrpCod\" and T2.\"ItemCode\" = '" + itemcode + "' " +
                                    "where T1.\"WhsCode\" = '" + WhseCode + "' and Cast(\"U_ITNAVAIL\" as Numeric)  > 0  Union Select ROW_NUMBER() OVER (Order by U_ITNAVAIL) AS \"row_num\",\"BinCode\" , \"U_ITNTOTCAP\" , \"U_ITNOCCU\"  , Cast(\"U_ITNAVAIL\" as Numeric)as U_ITNAVAIL  , TO_INTEGER(Cast(\"U_ITNAVAIL\" as Numeric) / T2.\"BVolume\")   as \"U_ITNAVAILQTY\" from OBIN T0 " +
                                    "Inner join OWHS T1 on  T0.\"WhsCode\" = T1.\"WhsCode\" Inner Join OITM T2 on  T0.\"U_ITNALIGRP\" =  T2.\"ItmsGrpCod\" and T2.\"ItemCode\" = '" + itemcode + "' " +
                                    "where T1.\"WhsCode\" = '" + WhseCode + "' and Cast(\"U_ITNAVAIL\" as Numeric) > 0 ) Order By U_ITNAVAIL Asc";
                return query;
            }
            catch
            {
                return "";
            }
        }

        private void LoadData(SAPbouiCOM.Matrix Mtx)
        {
            try
            {
                for (int i = 1; i <= Mtx.RowCount; i++)
                {
                    SAPbouiCOM.EditText GRPOBatch = Mtx.GetCellSpecific("2", i) as SAPbouiCOM.EditText;
                    if (!string.IsNullOrEmpty(GRPOBatch.Value))
                    {
                        Matrix0.AddRow();

                        SAPbouiCOM.EditText Mtx0LineId = Matrix0.GetCellSpecific("LineId", i) as SAPbouiCOM.EditText;
                        Mtx0LineId.Value = i.ToString();

                        SAPbouiCOM.EditText Mtx0ItemCode = Matrix0.GetCellSpecific("ItmCode", i) as SAPbouiCOM.EditText;
                        Mtx0ItemCode.Value = ItemCd;

                        //filling Batch
                        SAPbouiCOM.EditText Mtx0batch = Matrix0.GetCellSpecific("Btchs", i) as SAPbouiCOM.EditText;
                        Mtx0batch.Value = GRPOBatch.Value;

                        //filling Required Qty
                        SAPbouiCOM.EditText GRPOQty = Mtx.GetCellSpecific("234000024", i) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText Mtx0RequiredQty = Matrix0.GetCellSpecific("Qty", i) as SAPbouiCOM.EditText;
                        Mtx0RequiredQty.Value = GRPOQty.Value;

                        //getItemsArea.
                        SAPbouiCOM.EditText Area = Matrix0.GetCellSpecific("ArQty", i) as SAPbouiCOM.EditText;
                        Area.Value = (ItemArea(ItemCd, Convert.ToDouble(Mtx0RequiredQty.Value))).ToString();

                        //filling Remaining Qty                        
                        SAPbouiCOM.EditText RequiredQty = Matrix0.GetCellSpecific("Rem", i) as SAPbouiCOM.EditText;
                        RequiredQty.Value = Area.Value;

                        Matrix0.AutoResizeColumns();
                        Matrix1.AutoResizeColumns();
                    }
                }
            }
            catch
            {
            }
        }

        private void ResetRec()
        {
            try
            {
                if (Rec != null)
                    Rec = null;

                if (Rec == null)
                    Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            }
            catch
            {
            }
        }

        private Boolean Validation()
        {
            try
            {
                for (int i = 1; i < Matrix0.RowCount; i++)
                {
                    SAPbouiCOM.EditText RemainQt = Matrix0.GetCellSpecific("", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BatchName = Matrix0.GetCellSpecific("", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BatchQty = Matrix0.GetCellSpecific("", i) as SAPbouiCOM.EditText;
                    if (string.IsNullOrEmpty(BatchName.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Batch Name has not been Assigned at row no." + i, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        return true;
                    }
                    if (!string.IsNullOrEmpty(RemainQt.Value) && Convert.ToDouble(RemainQt.Value) > 0)
                    {
                        Program.SBO_Application.StatusBar.SetText("Not all the Items have been assigned a bin", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private double ItemArea(string itemCode, Double Quantity)
        {
            try
            {
                string query = "Select (ifnull(\"BVolume\", 0 ) * " + Quantity + ") as Area from OITM where \"ItemCode\"  = '" + itemCode + "'";
                ResetRec();
                Rec.DoQuery(query);
                return Convert.ToDouble(Rec.Fields.Item("AREA").Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                DeAssignQty(false);
                if (Validation())
                {
                    BubbleEvent = false;
                    return;
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
                SAPbouiCOM.Matrix Mtx = null;
                SAPbouiCOM.Form Btchsetup = null;
                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Batches - Setup")
                    {
                        Btchsetup = item;
                        Mtx = ((SAPbouiCOM.Matrix)(item.Items.Item("3").Specific));

                    }
                }
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {

                    SAPbouiCOM.EditText AllocardBinCD = Mtx.GetCellSpecific("U_ITNABINCODE", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText SelecedBin = Matrix0.GetCellSpecific("SelBin", i) as SAPbouiCOM.EditText;
                    AllocardBinCD.Value = SelecedBin.Value;

                    SAPbouiCOM.EditText AllocardBinQTY = Mtx.GetCellSpecific("U_ITNABINQTY", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText SelecedBinQTY = Matrix0.GetCellSpecific("AlloQIB", i) as SAPbouiCOM.EditText;
                    AllocardBinQTY.Value = SelecedBinQTY.Value;

                }

                for (int i = 1; i <= Mtx.RowCount; i++)
                {
                    SAPbouiCOM.EditText AllocardBinCD = Mtx.GetCellSpecific("U_ITNABINCODE", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText AllocardBinQTY = Mtx.GetCellSpecific("U_ITNABINQTY", i) as SAPbouiCOM.EditText;
                    if (!string.IsNullOrEmpty(AllocardBinCD.Value))
                    {
                        Mtx.Columns.Item("234000025").Cells.Item(i).Click(SAPbouiCOM.BoCellClickType.ct_Linked, 1);
                    }
                }
                IsAdd = true;
                Oform.Close();
            }
            catch
            {
            }
        }

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;


        }
        bool IsAdd = false;
        private void Form_CloseAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (!IsAdd)
                {
                    DeAssignQty(true);
                    IsAdd = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            IsAdd = true;
            DeAssignQty(true);
        }
    }
}

