
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;

namespace Sales_Addon_UDN
{

    [FormAttribute("142", "Purchase Order.b1f")]
    class Purchase_Order : SystemFormBase
    {
        public Purchase_Order()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.fldProv = ((SAPbouiCOM.Folder)(this.GetItem("fldProv").Specific));
            this.fldProv.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.fldProv_ClickAfter);
            this.fldProv.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.fldProv_PressedAfter);
            this.oForm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.fldProv.GroupWith("1320002137");
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_2").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("38").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
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
            //oForm = Program.SBO_Application.Forms.ActiveForm;
            //if (Button0.Caption != "Add")
            //{
            this.oForm.Menu.Add("Proforma Invoice", "Proforma Invoice", SAPbouiCOM.BoMenuType.mt_STRING, 5);
            //}
            Sales_Addon_UDN.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                oForm = Program.SBO_Application.Forms.ActiveForm;
                if (oForm.Title == "Purchase Order")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "Proforma Invoice")
                        {
                            PerfomaInvoice pi = new PerfomaInvoice("Purchase Order");
                            pi.Show();
                        }
                    }
                }
            }
            catch { }

        }

        #region Declarations

        private SAPbouiCOM.Folder fldProv;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.Matrix Matrix0;

        #endregion

        #region Events

        private void fldProv_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.PaneLevel = 90;
        }

        private void fldProv_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string[] itemCode = new string[0];
            Array.Resize(ref itemCode, Matrix0.RowCount - 1);
            for (int row = 1; row < Matrix0.RowCount; row++)
            {
                SAPbouiCOM.EditText txtItemCode = (SAPbouiCOM.EditText)Matrix0.GetCellSpecific("1", row);
                if (!string.IsNullOrEmpty(txtItemCode.Value))
                {
                    itemCode[row - 1] = txtItemCode.Value;
                }
            }
            FillGrid(itemCode);
        }

        #endregion

        #region Methods

        public void FillGrid(string[] itemcode)
        {
            try
            {

                string itemCodes = String.Join(",", itemcode.Select(s => "'" + s + "'"));
                SAPbouiCOM.DataTable dt ;
                dt = oForm.DataSources.DataTables.Add(DateTime.Now.ToString());
                string query = "SELECT T0.U_ITEMCODE \"ItemCode\", T0.U_ITEMNAME \"Description\", T0.U_LCCHRGE \"LC Charges\", T0.U_INSCHRGE \"Insurance Charges\", T0.U_CUSTDUTY \"Custom Duty\", T0.U_CLRCSTKOL \"Clearing Cost Kolkata\", T0.U_UNLDEXP \"Unloading Expenses \", T0.U_DOCHNCHRGE \"Document Handling Charges \", T0.U_ACPTCOST \"Acceptance Cost\", T0.U_RTMTCOST \"Retirement\\Settlement Cost\", T0.U_CUSTRCOST \"India\\Kolkata-Nepal Custom Transport Cost\", T0.U_NPCLRCOST \"Nepal Clearning Cost\", T0.U_NPCUSTRCST \"Nepal Custom-UDN Transport Cost\", T0.U_DTNSNCST \"Detension Cost\", T0.U_DMRGECST \"Demurrage Cost\", T0.U_ADDCOST \"Other Additional Cost\", (IFNULL(T0.U_LCCHRGE,0) + IFNULL(T0.U_INSCHRGE,0) + IFNULL(T0.U_CUSTDUTY,0) + IFNULL(T0.U_CLRCSTKOL,0) + IFNULL(T0.U_UNLDEXP,0) + IFNULL(T0.U_DOCHNCHRGE,0) + IFNULL(T0.U_ACPTCOST,0) + IFNULL(T0.U_RTMTCOST,0) + IFNULL(T0.U_CUSTRCOST,0) + IFNULL(T0.U_NPCLRCOST,0) + IFNULL(T0.U_NPCUSTRCST,0) + IFNULL(T0.U_DTNSNCST,0) + IFNULL(T0.U_DMRGECST,0) + IFNULL(T0.U_ADDCOST,0))  AS \"Total Cost\"FROM \"@ITN_PRC1\"  T0 WHERE \"U_ITEMCODE\" IN (" + itemCodes + ")";
                dt.ExecuteQuery(query);
                this.Grid1.DataTable = dt;
                Extentions.SetGridHeaderIndex(this.Grid1);


            }
            catch { }
        }

        #endregion

        private SAPbouiCOM.Button Button0;
    }
}
