using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using System.Globalization;
using NepaliDateConverter;
using ITNepal.MainLibrary.SAPB1;
using SAPbobsCOM;
using System.Data;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.Transaction", "Transaction.b1f")]
    class Transaction : UserFormBase
    {
        private static double? allocatedQty;
        private static double? damagedQty;
        private static double? pickedQty;
        public Transaction(string docEntry, string docNum, string businessUnit, string Customer)
        {
            BasicSetup(docEntry, docNum, businessUnit, Customer);
        }

        private void BasicSetup(string docEntry, string docNum, string businessUnit, string Customer)
        {
            try
            {
                var date = DateTime.Now.ToString("yyyyMMdd");
                string[] sSplitBatch;
                string[] sSplitBin;
                string[] sSplitQty;
                int row = 0;
                DateTime dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateConverter convertedDate = DateConverter.ConvertToNepali(dt.Year, dt.Month, dt.Day);
                String bsString = convertedDate.Year + "" + convertedDate.Month.ToString("00") + "" + convertedDate.Day.ToString("00");
                txtMiti.Value = bsString;
                txtDate.Value = date;
                txtSoDocE.Value = docEntry;
                txtSoDocN.Value = docNum;
                txtBusUnit.Value = businessUnit;
                txtCus.Value = Customer;
                txtPDoc.Value = B1Helper.GetNextDocNum("@ITN_OPCL").ToString();
                string query = "SELECT T0.\"LineNum\", T0.\"ItemCode\",T0.\"Dscription\",T0.\"Quantity\", T0.\"WhsCode\", T0.\"U_ITNBATCH\", T0.\"U_ITNBINLOC\",T0.\"U_ITNQTY\" FROM RDR1 T0 where T0.\"DocEntry\"=" + docEntry;
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rs.DoQuery(query);
                if (rs.RecordCount > 0)
                {


                    int i = 0;
                    for (int j = 0; j < rs.RecordCount; j++)
                    {
                        sSplitBatch = rs.Fields.Item("U_ITNBATCH").Value.ToString().Split('/');
                        sSplitBin = rs.Fields.Item("U_ITNBINLOC").Value.ToString().Split('/');
                        sSplitQty = rs.Fields.Item("U_ITNQTY").Value.ToString().Split('/');
                        foreach (string value in sSplitBatch)
                        {
                            Matrix0.AddRow();
                            //((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(i + 1).Specific).Value = (i + 1).ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("LinNum").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("LineNum").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmCod").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("ItemCode").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmName").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Dscription").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("OrdQty").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("Quantity").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("WhCode").Cells.Item(i + 1).Specific).Value = rs.Fields.Item("WhsCode").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Flag").Cells.Item(i + 1).Specific).Value = "N";

                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Btch").Cells.Item(i + 1).Specific).Value = value;// rs.Fields.Item("U_ITNBATCHNO").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Bin").Cells.Item(i + 1).Specific).Value = sSplitBin[row]; // rs.Fields.Item("U_ITNBINLOC").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("AllocQty").Cells.Item(i + 1).Specific).Value = sSplitQty[row].ToString(); // rs.Fields.Item("U_ITNBINLOC").Value.ToString();
                            i++;
                            row++;

                        }
                        row = 0;
                        rs.MoveNext();

                    }

                }
                Extentions.SetLineId(Matrix0);

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
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.txtSoDocE = ((SAPbouiCOM.EditText)(this.GetItem("txtSoDocE").Specific));
            this.txtCus = ((SAPbouiCOM.EditText)(this.GetItem("txtCus").Specific));
            this.txtBusUnit = ((SAPbouiCOM.EditText)(this.GetItem("txtBusUnit").Specific));
            this.txtPDoc = ((SAPbouiCOM.EditText)(this.GetItem("txtPDoc").Specific));
            this.txtDate = ((SAPbouiCOM.EditText)(this.GetItem("txtDate").Specific));
            this.txtMiti = ((SAPbouiCOM.EditText)(this.GetItem("txtMiti").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("linkTSo").Specific));
            this.txtSoDocN = ((SAPbouiCOM.EditText)(this.GetItem("txtSoDocN").Specific));
            this.chkAutDO = ((SAPbouiCOM.CheckBox)(this.GetItem("chkAutDO").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_15").Specific));
            this.Matrix0.ValidateAfter += new SAPbouiCOM._IMatrixEvents_ValidateAfterEventHandler(this.Matrix0_ValidateAfter);
            this.Matrix0.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.Matrix0_LostFocusAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.txtAtcmnt = ((SAPbouiCOM.EditText)(this.GetItem("txtAtcmnt").Specific));
            this.txtPrepBy = ((SAPbouiCOM.EditText)(this.GetItem("txtPrepBy").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.Oform.EnableMenu("1292", true);
            this.Oform.EnableMenu("1293", true);
            this.OnCustomInitialize();

        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                Oform = Program.SBO_Application.Forms.ActiveForm;
                if (Oform.Title.Trim() == "Transaction")
                {
                    //if (!pVal.BeforeAction)
                    //{
                    //    if (pVal.MenuUID == "1282")
                    //    {
                    //        BasicSetup();
                    //    }
                    //    if (pVal.MenuUID == "1281")
                    //    {
                    //        txtDocNum.Item.Enabled = true;
                    //    }
                    //}
                    if (pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1292")
                        {


                            //Extentions.AddLine(Matrix0);
                            //Extentions.SetLineId(Matrix0);
                            BubbleEvent = false;
                        }
                        if (pVal.MenuUID == "1293")
                        {
                            SAPbouiCOM.Matrix mtxBOM = (SAPbouiCOM.Matrix)Oform.Items.Item("Item_15").Specific;
                            for (int i = 1; i <= mtxBOM.RowCount; i++)
                            {
                                if (Matrix0.IsRowSelected(i))
                                {
                                    Matrix0.DeleteRow(i);
                                    //mtrxSFG.AutoResizeColumns();
                                    if (Oform.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                    {
                                        Oform.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
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

        private void Matrix0_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (!Validated())
            {
                BubbleEvent = false;
            }
            else
            {
                if (!AutoDelivery())
                    BubbleEvent = false;

            }


        }

        public Boolean AutoDelivery()
        {
            try
            {
                if (chkAutDO.Checked)
                {

                    SAPbobsCOM.Documents oDelivery = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts);
                    SAPbobsCOM.Documents oSalesOrder = (SAPbobsCOM.Documents)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
                    DataTable oDtBatch = new DataTable();
                    DataTable oDtDistinct = new DataTable();
                    DataView oDVBatch;
                    oDtBatch.Columns.Add("LineNo", typeof(string));
                    oDtBatch.Columns.Add("Batch", typeof(string));
                    oDtBatch.Columns.Add("Bin", typeof(string));
                    oDtBatch.Columns.Add("Qty", typeof(Double));
                    oDtBatch.Columns.Add("AbsEntry", typeof(int));
                    Int32 lRetCode, line, Bin;
                    Int32 SODocentry = Convert.ToInt32(txtSoDocE.Value);
                    string query = "SELECT T0.\"AbsEntry\" FROM OBIN T0 WHERE T0.\"BinCode\" = '{0}'";
                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);

                    oDelivery.DocObjectCode = BoObjectTypes.oDeliveryNotes;
                    for (int row = 1; row <= Matrix0.RowCount; row++)
                    {
                        rs.DoQuery(string.Format(query, ((dynamic)Matrix0.Columns.Item("PicBin").Cells.Item(row).Specific).Value));

                        oDtBatch.Rows.Add(((dynamic)Matrix0.Columns.Item("LinNum").Cells.Item(row).Specific).Value, ((dynamic)Matrix0.Columns.Item("PicBtch").Cells.Item(row).Specific).Value,
                            ((dynamic)Matrix0.Columns.Item("PicBin").Cells.Item(row).Specific).Value, ((dynamic)Matrix0.Columns.Item("PicQty").Cells.Item(row).Specific).Value, rs.Fields.Item("AbsEntry").Value);
                    }
                    oDVBatch = new DataView(oDtBatch);
                    SAPbobsCOM.SBObob oBob;

                    if (oSalesOrder.GetByKey(SODocentry))
                    {
                        oDelivery.CardCode = oSalesOrder.CardCode;
                        oDelivery.DocDueDate = DateTime.Now;
                        oDelivery.NumAtCard = oSalesOrder.NumAtCard;

                        for (int i = 1; i <= oSalesOrder.Lines.Count; i++)
                        {
                            line = 0;
                            Bin = 0;
                            oSalesOrder.Lines.SetCurrentLine(i - 1);
                            oDelivery.Lines.BaseEntry = oSalesOrder.DocEntry;
                            oDelivery.Lines.BaseLine = i - 1;
                            oDelivery.Lines.BaseType = 17;
                            oDelivery.Lines.Quantity = oSalesOrder.Lines.Quantity;
                            oDVBatch.RowFilter = "LineNo='" + Convert.ToString(i - 1) + "'";
                            oDtDistinct = oDVBatch.ToTable(true, "LineNo", "Batch");

                            foreach (DataRow oDTR in oDtDistinct.Rows)
                            {
                                oDVBatch.RowFilter = "LineNo='" + Convert.ToString(i - 1) + "' and Batch = '" + oDTR["Batch"].ToString() + "'";
                                oDelivery.Lines.BatchNumbers.SetCurrentLine(line);
                                oDelivery.Lines.BatchNumbers.BatchNumber = oDTR["Batch"].ToString();
                                object sumObject;
                                sumObject = oDVBatch.Table.Compute("SUM(Qty)", oDVBatch.RowFilter);
                                oDelivery.Lines.BatchNumbers.Quantity = Convert.ToDouble(sumObject.ToString());
                                oDelivery.Lines.BatchNumbers.Add();
                                foreach (DataRowView oDr in oDVBatch)
                                {
                                    oDelivery.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = line;
                                    oDelivery.Lines.BinAllocations.BinAbsEntry = Convert.ToInt16(oDr["AbsEntry"].ToString());
                                    oDelivery.Lines.BinAllocations.Quantity = Convert.ToDouble(oDr["Qty"].ToString());
                                    oDelivery.Lines.BinAllocations.Add();
                                    Bin++;
                                }
                                line++;
                            }
                            oDelivery.Lines.Add();
                        }

                        lRetCode = oDelivery.Add(); // Try to add the orer to the database
                        if (lRetCode != 0)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Exception while Adding AutoDelivery Order " + B1Helper.DiCompany.GetLastErrorDescription(), SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return false;

                        }
                        else { Application.SBO_Application.SetStatusBarMessage("Delivery Order Posted Successfully ..! " + B1Helper.DiCompany.GetNewObjectKey(), SAPbouiCOM.BoMessageTime.bmt_Short, false); }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Exception while Adding AutoDelivery Order " + ex.ToString(), SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return false;
            }
        }

        public bool Validated()
        {
            try
            {
                for (int i = 0; i < Matrix0.RowCount; i++)
                {
                    pickedQty = Convert.ToDouble(((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicQty").Cells.Item(i + 1).Specific).Value.ToString());
                    allocatedQty = Convert.ToDouble(((SAPbouiCOM.EditText)Matrix0.Columns.Item("AllocQty").Cells.Item(i + 1).Specific).Value.ToString());
                    damagedQty = Convert.ToDouble(((SAPbouiCOM.EditText)Matrix0.Columns.Item("Dmg").Cells.Item(i + 1).Specific).Value.ToString());


                    if (((SAPbouiCOM.EditText)Matrix0.Columns.Item("Sts").Cells.Item(i + 1).Specific).Value.ToString() != "Success" || (pickedQty + damagedQty) != allocatedQty)
                    {
                        Program.SBO_Application.SetStatusBarMessage("Failed to Add to Pick List", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        return false;
                    }
                }
                return true;
            }

            catch
            {
                return false;
            }
        }

        public void AddMatrixRow(SAPbouiCOM.SBOItemEventArg pVal)
        {


            Matrix0.AddRow(1, pVal.Row);

            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("LinNum").Cells.Item(pVal.Row + 1).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("LinNum").Cells.Item(pVal.Row).Specific).Value.ToString();
            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmCod").Cells.Item(pVal.Row + 1).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmCod").Cells.Item(pVal.Row).Specific).Value.ToString();
            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmName").Cells.Item(pVal.Row + 1).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmName").Cells.Item(pVal.Row).Specific).Value.ToString();
            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("OrdQty").Cells.Item(pVal.Row + 1).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("OrdQty").Cells.Item(pVal.Row).Specific).Value.ToString();
            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("WhCode").Cells.Item(pVal.Row + 1).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("WhCode").Cells.Item(pVal.Row).Specific).Value.ToString();
            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("AllocQty").Cells.Item(pVal.Row + 1).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Dmg").Cells.Item(pVal.Row).Specific).Value.ToString();
            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Flag").Cells.Item(pVal.Row + 1).Specific).Value = "Y";



        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataAddAfter += new SAPbouiCOM.Framework.FormBase.DataAddAfterHandler(this.Form_DataAddAfter);
          //  this.ClickAfter += new ClickAfterHandler(this.Form_ClickAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
            UIAPIRawForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
        }

        #region Declarations

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText txtSoDocE;
        private SAPbouiCOM.EditText txtCus;
        private SAPbouiCOM.EditText txtBusUnit;
        private SAPbouiCOM.EditText txtPDoc;
        private SAPbouiCOM.EditText txtDate;
        private SAPbouiCOM.EditText txtMiti;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText txtSoDocN;
        private SAPbouiCOM.CheckBox chkAutDO;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText txtAtcmnt;
        private SAPbouiCOM.EditText txtPrepBy;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Form Oform;
        #endregion

        private void Matrix0_ValidateAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "Scan" && pVal.InnerEvent == false)
                {
                    string itemCode = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("ItmCod").Cells.Item(pVal.Row).Specific).Value.ToString();
                    string batch = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Btch").Cells.Item(pVal.Row).Specific).Value.ToString();
                    string bin = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Bin").Cells.Item(pVal.Row).Specific).Value.ToString();

                    string[] scanData = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Scan").Cells.Item(pVal.Row).Specific).Value.ToString().Split('/');


                    if (((SAPbouiCOM.EditText)Matrix0.Columns.Item("Flag").Cells.Item(pVal.Row).Specific).Value.ToString().Equals("N"))
                    {
                        if (scanData[0].Equals(itemCode) && scanData[1].Equals(batch) && scanData[2].Equals(bin))
                        {

                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicQty").Cells.Item(pVal.Row).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("AllocQty").Cells.Item(pVal.Row).Specific).Value.ToString();
                            Matrix0.CommonSetting.SetCellBackColor(pVal.Row, 15, 000255000);
                            Matrix0.CommonSetting.SetCellFontColor(pVal.Row, 15, 128);
                            Matrix0.CommonSetting.SetCellFontStyle(pVal.Row, 15, SAPbouiCOM.BoFontStyle.fs_Bold);
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Sts").Cells.Item(pVal.Row).Specific).Value = "Success";
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicWhCod").Cells.Item(pVal.Row).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("WhCode").Cells.Item(pVal.Row).Specific).Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBtch").Cells.Item(pVal.Row).Specific).Value = scanData[1];
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBin").Cells.Item(pVal.Row).Specific).Value = scanData[2];

                        }
                        else
                        {
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Sts").Cells.Item(pVal.Row).Specific).Value = "Invalid Location";
                            Matrix0.CommonSetting.SetCellBackColor(pVal.Row, 15, 876);
                            Matrix0.CommonSetting.SetCellFontColor(pVal.Row, 15, 000255000);
                            Matrix0.CommonSetting.SetCellFontStyle(pVal.Row, 15, SAPbouiCOM.BoFontStyle.fs_Bold);
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Scan").Cells.Item(pVal.Row).Specific).Value = "";
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBtch").Cells.Item(pVal.Row).Specific).Value = "";
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBin").Cells.Item(pVal.Row).Specific).Value = "";
                            //((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicQty").Cells.Item(pVal.Row).Specific).Value = "0";
                        }

                    }
                    else
                    {
                        string data = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Scan").Cells.Item(pVal.Row).Specific).Value.ToString();
                        if (string.IsNullOrEmpty(data))
                        {
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Sts").Cells.Item(pVal.Row).Specific).Value = "Invalid Location";
                            Matrix0.CommonSetting.SetCellBackColor(pVal.Row, 15, 876);
                            Matrix0.CommonSetting.SetCellFontColor(pVal.Row, 15, 000255000);
                            Matrix0.CommonSetting.SetCellFontStyle(pVal.Row, 15, SAPbouiCOM.BoFontStyle.fs_Bold);
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Scan").Cells.Item(pVal.Row).Specific).Value = "";
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBtch").Cells.Item(pVal.Row).Specific).Value = "";
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBin").Cells.Item(pVal.Row).Specific).Value = "";
                        }
                        else
                        {
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicQty").Cells.Item(pVal.Row).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("AllocQty").Cells.Item(pVal.Row).Specific).Value.ToString();
                            Matrix0.CommonSetting.SetCellBackColor(pVal.Row, 15, 000255000);
                            Matrix0.CommonSetting.SetCellFontColor(pVal.Row, 15, 128);
                            Matrix0.CommonSetting.SetCellFontStyle(pVal.Row, 15, SAPbouiCOM.BoFontStyle.fs_Bold);
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Sts").Cells.Item(pVal.Row).Specific).Value = "Success";
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicWhCod").Cells.Item(pVal.Row).Specific).Value = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("WhCode").Cells.Item(pVal.Row).Specific).Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBtch").Cells.Item(pVal.Row).Specific).Value = scanData[1];
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicBin").Cells.Item(pVal.Row).Specific).Value = scanData[2];
                        }
                    }
                }

                if (pVal.ColUID == "Dmg" && pVal.InnerEvent == false)
                {
                    allocatedQty = Convert.ToDouble(((SAPbouiCOM.EditText)Matrix0.Columns.Item("AllocQty").Cells.Item(pVal.Row).Specific).Value.ToString());
                    damagedQty = Convert.ToDouble(((SAPbouiCOM.EditText)Matrix0.Columns.Item("Dmg").Cells.Item(pVal.Row).Specific).Value.ToString());
                    string status = ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Sts").Cells.Item(pVal.Row).Specific).Value.ToString();
                    if (damagedQty <= allocatedQty && damagedQty >= 0)
                    {
                        if (damagedQty != 0)
                        {
                            pickedQty = allocatedQty - damagedQty;
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("PicQty").Cells.Item(pVal.Row).Specific).Value = pickedQty.ToString();
                            AddMatrixRow(pVal);
                            Extentions.SetLineId(Matrix0);
                        }
                    }
                    else
                    {
                        Program.SBO_Application.SetStatusBarMessage("Invalid Quantity", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Dmg").Cells.Item(pVal.Row).Specific).Value = "0.00";
                    }
                }

            }
            catch
            {

            }

        }

        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                if (pVal.ActionSuccess)
                {
                    string docEntry = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("DocEntry", 0);
                    string soDocEntry = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("U_SODOCEN", 0);
                    string query = "Update ORDR  SET \"U_PICKLIST\"= " + docEntry + " where \"DocEntry\" = " + soDocEntry;
                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                    rs.DoQuery(query);
                }
            }
            catch(Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage( ex.ToString() );

            }

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ActionSuccess)
                {
                    UIAPIRawForm.Close();
                    var oPicklisk = Application.SBO_Application.Forms.Item("PICKREP");
                    oPicklisk.Items.Item("Refresh").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                }
            }
            catch { }   

        }
    }
}
