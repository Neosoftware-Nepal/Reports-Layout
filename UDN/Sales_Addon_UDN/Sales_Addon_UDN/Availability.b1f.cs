using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.Availability", "Availability.b1f")]
    class Availability : UserFormBase
    {
        public Availability(SAPbouiCOM.Matrix Mtx)
        {
            try
            {

                loadDatafrmMtx(Mtx);

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
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_2").Specific));
            this.Matrix1.ClickBefore += new SAPbouiCOM._IMatrixEvents_ClickBeforeEventHandler(this.Matrix1_ClickBefore);
            this.Matrix1.KeyDownAfter += new SAPbouiCOM._IMatrixEvents_KeyDownAfterEventHandler(this.Matrix1_KeyDownAfter);
            this.Matrix1.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix1_ClickAfter);
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }

        private SAPbouiCOM.Matrix Matrix0;

        private void OnCustomInitialize()
        {
            try
            {

            }
            catch
            {

            }
        }

        private void loadDatafrmMtx(SAPbouiCOM.Matrix Mtx)
        {
            try
            {
                if (Mtx.RowCount > 0)
                {
                    for (int i = 1; i <= Mtx.RowCount; i++)
                    {

                        SAPbouiCOM.EditText ItemCode = Mtx.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                        if (!string.IsNullOrEmpty(ItemCode.Value))
                        {
                            Matrix0.AddRow();

                            //So line to matrix0 line
                            SAPbouiCOM.EditText Mtxline = Mtx.GetCellSpecific("0", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText SoLine = Matrix0.GetCellSpecific("SoLine", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText Matrix0line = Matrix0.GetCellSpecific("#", i) as SAPbouiCOM.EditText;
                            SoLine.Value = Mtxline.Value.ToString();
                            Matrix0line.Value = Mtxline.Value.ToString();

                            //get and sets itemCode
                            SAPbouiCOM.EditText SOItemmtx = Mtx.GetCellSpecific("1", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText SOItemCodeMt0 = Matrix0.GetCellSpecific("ItmCode", i) as SAPbouiCOM.EditText;
                            SOItemCodeMt0.Value = SOItemmtx.Value.ToString();

                            //gets and sets Quantity
                            SAPbouiCOM.EditText SOQtymtx = Mtx.GetCellSpecific("11", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText SOQtyMO = Matrix0.GetCellSpecific("SoQty", i) as SAPbouiCOM.EditText;
                            SOQtyMO.Value = SOQtymtx.Value.ToString();

                            //get and sets Warehouse
                            SAPbouiCOM.EditText Whsmtx = Mtx.GetCellSpecific("24", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText Whse = Matrix0.GetCellSpecific("Whse", i) as SAPbouiCOM.EditText;
                            Whse.Value = Whsmtx.Value.ToString();
                            processingline = i;
                            updaterequiredQty();
                            Matrix0.AutoResizeColumns();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Form Oform;

        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "Chose")
                {
                    SAPbouiCOM.CheckBox processline = Matrix0.GetCellSpecific("Chose", pVal.Row) as SAPbouiCOM.CheckBox;
                    SAPbouiCOM.EditText Btch = Matrix0.GetCellSpecific("SelBatch", pVal.Row) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText Whse = Matrix0.GetCellSpecific("Whse", pVal.Row) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText ItmCode = Matrix0.GetCellSpecific("ItmCode", pVal.Row) as SAPbouiCOM.EditText;
                    processingline = pVal.Row;
                    if (processline.Checked)
                    {
                        if (string.IsNullOrEmpty(Btch.Value))
                        {
                            ResetMatrix1();
                        }
                        loadBatch_BinforSelection(ItmCode.Value, Whse.Value);
                    }
                    updaterequiredQty();
                }
            }
            catch
            {
            }
        }

        private void loadBatch_BinforSelection(string ItemCode, string warehouseCode)
        {
            try
            {
                string Query = "select Distinct   T2.\"BinCode\" as \"BIN\", T3.\"DistNumber\" as \"BATCH\" , " +
                                 "ifnull(T0.\"Quantity\",0) as \"AvailQty\", T3.\"ExpDate\" as \"ExpiryDate\" , ROW_NUMBER() OVER (PARTITION BY T0.\"ItemCode\" ORDER BY T3.\"ExpDate\" Asc) AS \"RowNum\" from OBTQ T0  join OBTL T1 on T0.\"MdAbsEntry\"=T1.\"SnBMDAbs\"" +
                                "join OBIN T2 on T1.\"BinAbs\"=T2.\"AbsEntry\" join OBTN T3 on T0.\"MdAbsEntry\" = T3.\"AbsEntry\"" +
                                "where T0.\"ItemCode\" in ('" + ItemCode + "') and T3.\"ExpDate\" is not null and T0.\"WhsCode\" = '" + warehouseCode + "' Order by  T3.\"ExpDate\" Asc ";

                Oform.DataSources.DataTables.Item("Data").ExecuteQuery(Query);

                if (!Oform.DataSources.DataTables.Item("Data").IsEmpty)
                {
                    Matrix1.Columns.Item("#").DataBind.Bind("Data", "RowNum");
                    Matrix1.Columns.Item("AvailBtch").DataBind.Bind("Data", "BATCH");
                    Matrix1.Columns.Item("Bin").DataBind.Bind("Data", "BIN");
                    Matrix1.Columns.Item("AvailQty").DataBind.Bind("Data", "AvailQty");
                    Matrix1.Columns.Item("ExpDate").DataBind.Bind("Data", "ExpiryDate");
                    Matrix1.LoadFromDataSource();
                    Matrix1.AutoResizeColumns();
                }
                else
                {
                    Program.SBO_Application.StatusBar.SetText("No batchs were found in given warehouse", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch
            {
            }
        }

        private void ResetMatrix1()
        {
            try
            {
                Matrix1.Clear();
            }
            catch
            {
            }
        }

        private int processingline = 1;

        private void Matrix1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Select")
            {
                SAPbouiCOM.CheckBox processline = Matrix1.GetCellSpecific("Select", pVal.Row) as SAPbouiCOM.CheckBox;

                if (processline.Checked)
                {
                    SAPbouiCOM.EditText ReqQty = Matrix0.GetCellSpecific("ReqQty", processingline) as SAPbouiCOM.EditText;

                    if (Convert.ToDouble(ReqQty.Value) > 0)
                    {
                        //Matrix1.CommonSetting.SetCellEditable(processingline, 6, true);
                        
                        updaterequiredQty();
                        SAPbouiCOM.EditText AssignQty = Matrix1.GetCellSpecific("SelQty", pVal.Row) as SAPbouiCOM.EditText;

                        SAPbouiCOM.EditText AssiQty = Matrix0.GetCellSpecific("AssiQty", processingline) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText SoQty = Matrix0.GetCellSpecific("SoQty", processingline) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText AvailInBin = Matrix1.GetCellSpecific("AvailQty", pVal.Row) as SAPbouiCOM.EditText;

                        if (Convert.ToDouble(AvailInBin.Value) < Convert.ToDouble(ReqQty.Value))
                        {
                            AssignQty.Value = AvailInBin.Value;

                        }
                        else
                        {
                            AssignQty.Value = ReqQty.Value;

                        }
                        
                        AssiQty.Value = (Convert.ToDouble(AssiQty.Value) + Convert.ToDouble(AssignQty.Value)).ToString();
                        combinebatches();
                        updaterequiredQty();
                    }
                    else
                    {
                        Program.SBO_Application.StatusBar.SetText("Required Quantity is selected", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        processline.Checked = false;
                    }
                }
                else
                {
                    //subtract the assigned Qty
                    SAPbouiCOM.EditText AssignQty = Matrix1.GetCellSpecific("SelQty", pVal.Row) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText AssiQty = Matrix0.GetCellSpecific("AssiQty", processingline) as SAPbouiCOM.EditText;

                    SAPbouiCOM.EditText BtchCom = Matrix0.GetCellSpecific("SelBatch", processingline) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BinCom = Matrix0.GetCellSpecific("SelBin", processingline) as SAPbouiCOM.EditText;

                    BtchCom.Value = "";
                    BinCom.Value = "";

                    if (Convert.ToDouble(AssiQty.Value) > 0)
                        AssiQty.Value = (Convert.ToDouble(AssiQty.Value) - Convert.ToDouble(AssignQty.Value)).ToString();

                    combinebatches();
                    updaterequiredQty();

                    //Matrix1.CommonSetting.SetCellEditable(processingline, 6, false);
                    AssignQty.Value = "0";
                }
                Matrix0.AutoResizeColumns();
                Matrix1.AutoResizeColumns();
            }
        }

        private void Matrix1_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


        }

        private void Matrix1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

        }

        private void updaterequiredQty()
        {
            try
            {

                SAPbouiCOM.EditText SoQty = Matrix0.GetCellSpecific("SoQty", processingline) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText AssiQty = Matrix0.GetCellSpecific("AssiQty", processingline) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText ReqQty = Matrix0.GetCellSpecific("ReqQty", processingline) as SAPbouiCOM.EditText;
                if (!string.IsNullOrEmpty(SoQty.Value) && !string.IsNullOrEmpty(AssiQty.Value))
                {
                    ReqQty.Value = (Convert.ToDouble(SoQty.Value) - Convert.ToDouble(AssiQty.Value)).ToString();
                }
            }
            catch
            {

            }
        }

        private void combinebatches()
        {
            try
            {
                SAPbouiCOM.EditText BtchCom = Matrix0.GetCellSpecific("SelBatch", processingline) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText BinCom = Matrix0.GetCellSpecific("SelBin", processingline) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText QtyCom = Matrix0.GetCellSpecific("SelQty", processingline) as SAPbouiCOM.EditText;
                BtchCom.Value = "";
                BinCom.Value = "";
                QtyCom.Value = "";
                for (int i = 1; i <= Matrix1.RowCount; i++)
                {

                    SAPbouiCOM.CheckBox processline = Matrix1.GetCellSpecific("Select", i) as SAPbouiCOM.CheckBox;
                    if (processline.Checked)
                    {
                        SAPbouiCOM.EditText Batch = Matrix1.GetCellSpecific("AvailBtch", i) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText Qty = Matrix1.GetCellSpecific("SelQty", i) as SAPbouiCOM.EditText;
                        SAPbouiCOM.EditText Bin = Matrix1.GetCellSpecific("Bin", i) as SAPbouiCOM.EditText;

                        if (string.IsNullOrEmpty(BtchCom.Value))
                        {
                            BtchCom.Value = Batch.Value;
                            BinCom.Value = Bin.Value;
                            QtyCom.Value = Convert.ToDouble(Qty.Value).ToString();
                        }
                        else
                        {
                            BtchCom.Value = BtchCom.Value + "/" + Batch.Value;
                            BinCom.Value = BinCom.Value + "/" + Bin.Value;
                            QtyCom.Value = QtyCom.Value + "/" + Convert.ToDouble(Qty.Value).ToString();
                        }
                    }
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
                foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
                {
                    if (item.Title == "Sales Order")
                    {
                        SAPbouiCOM.Form fmr2 = item;
                        SAPbouiCOM.Matrix mtx = ((SAPbouiCOM.Matrix)(fmr2.Items.Item("38").Specific));
                        for (int i = 1; i <= Matrix0.RowCount; i++)
                        {
                            SAPbouiCOM.CheckBox processline = Matrix0.GetCellSpecific("Chose", i) as SAPbouiCOM.CheckBox;
                            SAPbouiCOM.EditText SoLine = Matrix0.GetCellSpecific("SoLine", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText SelBatch = Matrix0.GetCellSpecific("SelBatch", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText SelBin = Matrix0.GetCellSpecific("SelBin", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText AssiQty = Matrix0.GetCellSpecific("AssiQty", i) as SAPbouiCOM.EditText;
                            SAPbouiCOM.EditText QtyCom = Matrix0.GetCellSpecific("SelQty", i) as SAPbouiCOM.EditText;

                            int SOline = Convert.ToInt32(SoLine.Value);
                            if (processline.Checked)
                            {
                                if (!string.IsNullOrEmpty(SelBatch.Value))
                                {
                                    ((SAPbouiCOM.EditText)mtx.Columns.Item("U_ITNBATCH").Cells.Item(SOline).Specific).Value = SelBatch.Value;
                                    ((SAPbouiCOM.EditText)mtx.Columns.Item("U_ITNBINLOC").Cells.Item(SOline).Specific).Value = SelBin.Value;
                                    ((SAPbouiCOM.EditText)mtx.Columns.Item("U_ITNQTY").Cells.Item(SOline).Specific).Value = QtyCom.Value;
                                }
                            }
                        }
                        SAPbouiCOM.Button btn = ((SAPbouiCOM.Button)(fmr2.Items.Item("1").Specific));
                        btn.Item.Enabled = true;
                    }
                }
                Oform.Close();
            }
            catch
            {

            }
        }

        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Matrix0.AutoResizeColumns();
                Matrix1.AutoResizeColumns();
            }
            catch
            {

            }

        }
    }
}
