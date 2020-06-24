using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("134", "bp.b1f")]
    class bp : SystemFormBase
    {
        public bp()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Btncr = ((SAPbouiCOM.Button)(this.GetItem("bslmt").Specific));
            this.Btncr.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Btncr_ClickBefore);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("txtdis").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("txtpro").Specific));
            this.txtCardCode = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.TxtName = ((SAPbouiCOM.EditText)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("40").Specific));
            //      this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("txtTwn").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("TxtSchnl").Specific));
            this.cmbRCu = ((SAPbouiCOM.ComboBox)(this.GetItem("cmbRCu").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("txtRcust").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_15").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Button Btncr;
        private SAPbouiCOM.EditText TxtName;
        private SAPbouiCOM.EditText txtCardCode;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText4;

        private void OnCustomInitialize()
        {
            try
            {
                Btncr.Item.Top = Button1.Item.Top;
                Btncr.Item.Left = Button1.Item.Left + 70;
            }
            catch
            {

            }
        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        
        private SAPbouiCOM.Button Button1;

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
        }

        private void Btncr_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (!string.IsNullOrEmpty(txtCardCode.Value) && ComboBox0.Selected.Value == "C")
                {
                    CreditLimit Cr = new CreditLimit(txtCardCode.Value + "," + TxtName.Value , true , ComboBox2.Selected.Value);
                    Cr.Show();
                }
                else
                {
                    Program.SBO_Application.StatusBar.SetText("Credit limit can only be set on customer's", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                    return;
                }
            }
            catch 
            {
            }
        }

        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.ComboBox cmbRCu;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.ComboBox ComboBox2;
    }
}
