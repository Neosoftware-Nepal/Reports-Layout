using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("134", "BusinnessPartner.b1f")]
    class BusinnessPartner : SystemFormBase
    {
        public BusinnessPartner()
        {

            //Button0.Item.Top = Button1.Item.Top;
        }

        #region variable

        private SAPbouiCOM.EditText txtCardCode;
        private SAPbouiCOM.Button Button1;

        #endregion
            
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Btncr = ((SAPbouiCOM.Button)(this.GetItem("bslmt").Specific));
            this.Btncr.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.txtCardCode = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.TxtName = ((SAPbouiCOM.EditText)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("40").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        //private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Btncr; 
        private SAPbouiCOM.EditText TxtName;

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

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (!string.IsNullOrEmpty(txtCardCode.Value) && ComboBox0.Selected.Value == "C")
            {
                CreditLimit Cr = new CreditLimit(txtCardCode.Value + "," + TxtName.Value);
                Cr.Show();
            }
            else
            {
                Program.SBO_Application.StatusBar.SetText("Credit limit can only be set on customer's", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                BubbleEvent = false; 
                return; 

            }
        }

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText4;
    }
}
