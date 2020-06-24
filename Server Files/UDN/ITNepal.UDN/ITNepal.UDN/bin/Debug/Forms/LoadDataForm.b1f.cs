using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.LoadDataForm", "Forms/LoadDataForm.b1f")]
    class LoadDataForm : UserFormBase
    {
        public LoadDataForm()
        {
        }

        private SAPbouiCOM.Grid griddata;
        private SAPbouiCOM.Button btnCancel;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.griddata = ((SAPbouiCOM.Grid)(this.GetItem("gd_data").Specific));
            //this.btnOk.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnOk_PressedAfter);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
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
            this.UIAPIRawForm.DataSources.DataTables.Add("MyDT");
        }

        public void LoadData(string query)
        {
            griddata.DataTable = this.UIAPIRawForm.DataSources.DataTables.Item("MyDT");
            this.UIAPIRawForm.DataSources.DataTables.Item("MyDT").ExecuteQuery(query);
            //for (int iloop = 0; iloop <= griddata.DataTable.Columns.Count - 1; iloop++)
            //{
            //    griddata.Columns.Item(iloop).Editable = false;
            //}
        }

        //private void btnOk_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        //{
        //    BubbleEvent = true;
        //    throw new System.NotImplementedException();

        //}

        //private void btnOk_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    this.UIAPIRawForm.Close();

        //}


    }
}
