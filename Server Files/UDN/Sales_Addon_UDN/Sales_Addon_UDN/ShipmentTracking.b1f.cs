using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Sales_Addon_UDN
{
    [FormAttribute("Sales_Addon_UDN.ShipmentTracking", "ShipmentTracking.b1f")]
    class ShipmentTracking : UserFormBase
    {
        public ShipmentTracking()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("PODENT").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("PoDate").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("PODT").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("VCODE").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("PERINVNO").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("PERDT").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("COMINVNO").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("ComInvDate").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("GRPODENT").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("GRPODT").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("BLDNUM").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("BLDT").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("DOCTOTAL").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("PREPBY").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("PODNUM").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("GRPODNUM").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_37").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_38").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_41").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_42").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("txtDN").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_44").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("DocDate").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_46").Specific));
            this.EditText19 = ((SAPbouiCOM.EditText)(this.GetItem("SHNDT").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_48").Specific));
            this.EditText20 = ((SAPbouiCOM.EditText)(this.GetItem("SHDELNDT").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_50").Specific));
            this.EditText21 = ((SAPbouiCOM.EditText)(this.GetItem("TRANME").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_52").Specific));
            this.EditText22 = ((SAPbouiCOM.EditText)(this.GetItem("LRNO").Specific));
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_54").Specific));
            this.EditText23 = ((SAPbouiCOM.EditText)(this.GetItem("ODRBB").Specific));
            this.StaticText25 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_60").Specific));
            this.EditText26 = ((SAPbouiCOM.EditText)(this.GetItem("BNKCLDT").Specific));
            this.StaticText26 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_62").Specific));
            this.EditText27 = ((SAPbouiCOM.EditText)(this.GetItem("PAYDATE").Specific));
            this.StaticText27 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_68").Specific));
            this.EditText30 = ((SAPbouiCOM.EditText)(this.GetItem("REMARKS").Specific));
            this.StaticText28 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_70").Specific));
            this.EditText31 = ((SAPbouiCOM.EditText)(this.GetItem("ETADTPA").Specific));
            this.StaticText29 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_72").Specific));
            this.EditText32 = ((SAPbouiCOM.EditText)(this.GetItem("DOCRELDT").Specific));
            this.EditText33 = ((SAPbouiCOM.EditText)(this.GetItem("ETAHRPA").Specific));
            this.StaticText30 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_75").Specific));
            this.StaticText31 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_76").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("STATUS").Specific));
            this.StaticText32 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_79").Specific));
            this.EditText35 = ((SAPbouiCOM.EditText)(this.GetItem("LCDNUM").Specific));
            this.StaticText33 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_81").Specific));
            this.EditText36 = ((SAPbouiCOM.EditText)(this.GetItem("LCDT").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_1").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private SAPbouiCOM.Matrix Matrix0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText EditText17;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText EditText18;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText EditText19;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.EditText EditText20;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.EditText EditText21;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.EditText EditText22;
        private SAPbouiCOM.StaticText StaticText22;
        private SAPbouiCOM.EditText EditText23;
        private SAPbouiCOM.StaticText StaticText25;
        private SAPbouiCOM.EditText EditText26;
        private SAPbouiCOM.StaticText StaticText26;
        private SAPbouiCOM.EditText EditText27;
        private SAPbouiCOM.StaticText StaticText27;
        private SAPbouiCOM.EditText EditText30;
        private SAPbouiCOM.StaticText StaticText28;
        private SAPbouiCOM.EditText EditText31;
        private SAPbouiCOM.StaticText StaticText29;
        private SAPbouiCOM.EditText EditText32;
        private SAPbouiCOM.EditText EditText33;
        private SAPbouiCOM.StaticText StaticText30;
        private SAPbouiCOM.StaticText StaticText31;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText32;
        private SAPbouiCOM.EditText EditText35;
        private SAPbouiCOM.StaticText StaticText33;
        private SAPbouiCOM.EditText EditText36;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
    }
}
