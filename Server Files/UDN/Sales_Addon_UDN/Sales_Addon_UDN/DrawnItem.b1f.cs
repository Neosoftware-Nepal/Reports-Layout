using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("425", "DrawnItem.b1f")]
    class DrawnItem : SystemFormBase
    {
        public DrawnItem()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("49").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //foreach (SAPbouiCOM.Form item in Program.SBO_Application.Forms)
            //{
            //    if (item.Title == "Credit Limit")
            //    {
            //        fmr2 = item;
            //    }
            //}
            //so.salesRquDrawn = true; 

        }

        private void OnCustomInitialize()
        {

        }
    }
}
