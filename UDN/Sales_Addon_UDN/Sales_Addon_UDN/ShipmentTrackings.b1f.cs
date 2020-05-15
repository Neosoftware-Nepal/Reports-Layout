using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.ShipmentTrackings", "ShipmentTrackings.b1f")]
    class ShipmentTrackings : UserFormBase
    {
        public ShipmentTrackings()
        {
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
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.StaticText23 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.StaticText24 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.StaticText25 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.StaticText26 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.StaticText27 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.StaticText28 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_34").Specific));
            this.Folder2 = ((SAPbouiCOM.Folder)(this.GetItem("Item_35").Specific));
            this.Matrix2 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_36").Specific));
            this.Matrix3 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_37").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("PODNUM").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("DOCDATE").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("STATUS").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("LCDNUM").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("ETAHRPA").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("BLDT").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("LCDT").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("ETADTPA").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("SHDELNDT").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("SHNDT").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("TRANME").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("LRNO").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("COMINVNO").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("BLDNUM").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("GRPODT").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("COMDT").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("PERDT").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("PODT").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("DOCNUM").Specific));
            this.EditText19 = ((SAPbouiCOM.EditText)(this.GetItem("GRPODNUM").Specific));
            this.EditText20 = ((SAPbouiCOM.EditText)(this.GetItem("DOCRELDT").Specific));
            this.EditText21 = ((SAPbouiCOM.EditText)(this.GetItem("VCODE").Specific));
            this.EditText22 = ((SAPbouiCOM.EditText)(this.GetItem("PEOINVNO").Specific));
            this.EditText22.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText22_KeyDownAfter);
            this.EditText23 = ((SAPbouiCOM.EditText)(this.GetItem("GRPODENT").Specific));
            this.EditText24 = ((SAPbouiCOM.EditText)(this.GetItem("PODENT").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_65").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_66").Specific));
            this.EditText25 = ((SAPbouiCOM.EditText)(this.GetItem("ODOCRBB").Specific));
            this.EditText26 = ((SAPbouiCOM.EditText)(this.GetItem("BNKCLDT").Specific));
            this.EditText27 = ((SAPbouiCOM.EditText)(this.GetItem("DOCTOTAL").Specific));
            this.EditText28 = ((SAPbouiCOM.EditText)(this.GetItem("PREPBY").Specific));
            this.EditText29 = ((SAPbouiCOM.EditText)(this.GetItem("PAYDATE").Specific));
            this.EditText31 = ((SAPbouiCOM.EditText)(this.GetItem("REMARKS").Specific));
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

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.StaticText StaticText22;
        private SAPbouiCOM.StaticText StaticText23;
        private SAPbouiCOM.StaticText StaticText24;
        private SAPbouiCOM.StaticText StaticText25;
        private SAPbouiCOM.StaticText StaticText26;
        private SAPbouiCOM.StaticText StaticText27;
        private SAPbouiCOM.StaticText StaticText28;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Folder Folder2;
        private SAPbouiCOM.Matrix Matrix2;
        private SAPbouiCOM.Matrix Matrix3;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.EditText EditText17;
        private SAPbouiCOM.EditText EditText18;
        private SAPbouiCOM.EditText EditText19;
        private SAPbouiCOM.EditText EditText20;
        private SAPbouiCOM.EditText EditText21;
        private SAPbouiCOM.EditText EditText22;

        private void EditText22_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            throw new System.NotImplementedException();

        }

        private SAPbouiCOM.EditText EditText23;
        private SAPbouiCOM.EditText EditText24;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.EditText EditText25;
        private SAPbouiCOM.EditText EditText26;
        private SAPbouiCOM.EditText EditText27;
        private SAPbouiCOM.EditText EditText28;
        private SAPbouiCOM.EditText EditText29;
        private SAPbouiCOM.EditText EditText31;
    }
}
