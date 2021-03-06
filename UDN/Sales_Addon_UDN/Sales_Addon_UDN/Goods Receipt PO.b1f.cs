
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using System.Drawing.Printing;
using System.Drawing;

namespace Sales_Addon_UDN
{

    [FormAttribute("143", "Goods Receipt PO.b1f")]
    class Goods_Receipt_PO : SystemFormBase
    {
        public Goods_Receipt_PO()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.btnAdd = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CmbSeries = ((SAPbouiCOM.ComboBox)(this.GetItem("88").Specific));
            this.txtDocNum = ((SAPbouiCOM.EditText)(this.GetItem("8").Specific));
            this.OnCustomInitialize();

        }





        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataAddAfter += new DataAddAfterHandler(this.Form_DataAddAfter);

        }



        private void OnCustomInitialize()
        {
            this.Oform.Menu.Add("LandedCost", "Landed Cost", SAPbouiCOM.BoMenuType.mt_STRING, 5);
            SAPbouiCOM.Framework.Application.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(this.INS_SBO_Application_MenuEvent);
        }

        #region Declaration

        SAPbouiCOM.Form Oform;
        private SAPbouiCOM.Button btnAdd;
        private SAPbouiCOM.ComboBox CmbSeries;
        private SAPbouiCOM.EditText txtDocNum;
        private SAPbobsCOM.Recordset Rec;

        #endregion

        private void INS_SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (Oform.Title == "Goods Receipt PO")
                {
                    if (pVal.MenuUID == "LandedCost" && !pVal.BeforeAction)
                    {
                        if (IsGRPOAdded())
                        {
                            Program.SBO_Application.ActivateMenuItem("2310");
                        }
                        else
                        {
                            Program.SBO_Application.StatusBar.SetText("Add GRPO First To Add Landed Cost", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private bool IsGRPOAdded()
        {
            try
            {
                string Query = "Select * from OPDN where \"DocNum\" = '" + txtDocNum.Value + "' and \"Series\" = '" + CmbSeries.Selected.Value + "'";
                ResetRec();
                Rec.DoQuery(Query);
                if (Rec.RecordCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ResetRec()
        {
            if (Rec != null)
                Rec = null;

            if (Rec == null)
                Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        }

        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                if (!pVal.ActionSuccess)
                    return;
                string DocEntry = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("DocEntry", 0);
                string query = "call \"UDN_INTERNALTESTING28JAN2020\".\"BARCODE\" (" + DocEntry + ")";
                ResetRec();
                Rec.DoQuery(query);
                while (!Rec.EoF)
                {

                    StringBuilder Encoded = new StringBuilder();
                    Encoded.Append((char)204);
                    String toEncode = Rec.Fields.Item("Barcode").Value.ToString();
                    int sum = 104;
                    for (int i = 0; i < toEncode.Length; i++)
                    {
                        sum += ((char)toEncode[i] - 32) * (i + 1);
                        Encoded.Append(toEncode[i]);
                    }
                    sum = sum % 103;
                    sum += 32;
                    //Checksum between 94 and 103 are encoded in the 200 - 206 range
                    if (sum > 94 && sum < 103)
                        sum += 105;
                    //Checksum
                    Encoded.Append((char)sum);
                    //Stop code
                    Encoded.Append((char)206);

                    //string p = ;
                    btnPrint_Click(Encoded.ToString());
                    Rec.MoveNext();
                }

            }
            catch
            {
            }
        }
        private void btnPrint_Click(string Encode)
        {
            string s = Encode;
            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }
    }
}
