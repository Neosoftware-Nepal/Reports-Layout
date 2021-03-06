
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{

    [FormAttribute("41", "Batches - Setup.b1f")]
    class Batches___Setup : SystemFormBase
    {
        public Batches___Setup()
        {

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("35").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("3").Specific));
            this.Matrix1.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.Matrix1_LinkPressedBefore);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbobsCOM.Recordset Rec;


        private void OnCustomInitialize()
        {
            try
            {
                Button0.Item.Top = Button2.Item.Top;
                Button0.Item.Left = Button2.Item.Left + 70;
                //Button1.Item.Enabled = false; 
            }
            catch
            {
            }
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                int j = 1;
                for (int i = 1; i <= Matrix0.RowCount; i++)
                {
                    if (Matrix0.IsRowSelected(i))
                    {
                        j = i;
                        break;
                    }
                }
                SAPbouiCOM.EditText ItemCode = Matrix0.GetCellSpecific("5", j) as SAPbouiCOM.EditText;
                SAPbouiCOM.EditText WhseCode = Matrix0.GetCellSpecific("40", j) as SAPbouiCOM.EditText;
                Bin_BatchAssig binAssign = new Bin_BatchAssig(Matrix1, ItemCode.Value, WhseCode.Value);
                binAssign.Show();
            }
            catch
            {
            }
        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {

                for (int i = 1; i <= Matrix1.RowCount; i++)
                {
                    SAPbouiCOM.EditText BatchNme = Matrix1.GetCellSpecific("2", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BinlocAllo = Matrix1.GetCellSpecific("234000025", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText BinAll = Matrix1.GetCellSpecific("U_ITNABINCODE", i) as SAPbouiCOM.EditText;
                    SAPbouiCOM.EditText ExpDate = Matrix1.GetCellSpecific("10", i) as SAPbouiCOM.EditText;
                    if (!string.IsNullOrEmpty(BatchNme.Value) && !string.IsNullOrEmpty(BinlocAllo.Value) && Convert.ToDouble(BinlocAllo.Value) == 0 || string.IsNullOrEmpty(BinAll.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Bin Allocation can't be zero, Allocate the bin from Bin Suggestion", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        BubbleEvent = false;
                        return;
                    }
                    if (string.IsNullOrEmpty(ExpDate.Value))
                    {
                        Program.SBO_Application.StatusBar.SetText("Expiry date is not inserted in the row no :" + i, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        BubbleEvent = false;
                        return;
                    }

                }
            }
            catch
            {
            }

        }

        private void Matrix1_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //if (pVal.ColUID == "234000025")
            //{
            //    SAPbouiCOM.EditText AllocardBinCD = Matrix1.GetCellSpecific("U_ITNABINCODE", pVal.Row) as SAPbouiCOM.EditText;
            //    if (string.IsNullOrEmpty(AllocardBinCD.Value))
            //    {
            //        Program.SBO_Application.StatusBar.SetText("Bin can't be allocated if allocated bin code is blank.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            //        BubbleEvent = false;
            //        return;
            //    }
            //}
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            DeAssignQty(true); 

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
                                AvailableQty = AvailableQty + Convert.ToDouble(BinQty.Value.Split(',')[p]);
                                OccupiedQty = OccupiedQty - Convert.ToDouble(BinQty.Value.Split(',')[p]);
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
    }
}
