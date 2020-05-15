using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.CoverageMaster", "Forms/CoverageMaster.b1f")]
    class CoverageMaster : B1FormBase
    {
        public CoverageMaster()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText tbCode;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText tbDocDt;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText tbRemarks;
        private SAPbouiCOM.Matrix mtxItemGroup;
        private SAPbouiCOM.Button btnAdd;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.Button btnDelRow;
        private SAPbouiCOM.CheckBox cbActive;
        private SAPbouiCOM.DBDataSource oDBs_Head, oDBs_Details;
        private int selectedRow;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.tbCode = ((SAPbouiCOM.EditText)(this.GetItem("tbCode").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.tbDocDt = ((SAPbouiCOM.EditText)(this.GetItem("tbDocDt").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.tbRemarks = ((SAPbouiCOM.EditText)(this.GetItem("tbRemks").Specific));
            this.mtxItemGroup = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_Grp").Specific));
            this.mtxItemGroup.PressedAfter += new SAPbouiCOM._IMatrixEvents_PressedAfterEventHandler(this.mtxItemGroup_PressedAfter);
            this.mtxItemGroup.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.mtxItemGroup_ComboSelectAfter);
            this.btnAdd = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnAdd.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnAdd_PressedAfter);
            this.btnAdd.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnAdd_PressedBefore);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.btnDelRow = ((SAPbouiCOM.Button)(this.GetItem("btnDelRow").Specific));
            this.btnDelRow.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnDelRow_PressedAfter);
            this.cbActive = ((SAPbouiCOM.CheckBox)(this.GetItem("cbActive").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.tbName = ((SAPbouiCOM.EditText)(this.GetItem("tbName").Specific));
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
            this.UIAPIRawForm.Items.Item("tbCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.Items.Item("tbDocDt").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.Items.Item("tbCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 4, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
            this.UIAPIRawForm.Items.Item("tbCode").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 2, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
            this.UIAPIRawForm.EnableMenu("1282", true);
            this.UIAPIRawForm.EnableMenu("1281", true);

            this.UIAPIRawForm.EnableMenu("1288", true);
            this.UIAPIRawForm.EnableMenu("1289", true);
            this.UIAPIRawForm.EnableMenu("1290", true);
            this.UIAPIRawForm.EnableMenu("1291", true);

            oDBs_Head = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_OCVM");
            oDBs_Details = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_CVM1");
            //   this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_ADD_MODE;
            //int docEntry = int.Parse(B1Helper.GetNextEntryIndex("@Z_OCVD"));
            // oDBs_Head.SetValue("DocEntry", 0, (docEntry + 1).ToString());
            oDBs_Head.SetValue("U_CoverageDate", 0, DateTime.Today.ToString("yyyyMMdd"));
            oDBs_Head.SetValue("U_Active", 0, "Y");
            LoadMatrixComboValues();

            this.UIAPIRawForm.DataBrowser.BrowseBy = "tbCode";
        }

        private void AddMatrixLine()
        {
            mtxItemGroup.AddRow();
            oDBs_Details.SetValue("LineId", oDBs_Details.Offset, mtxItemGroup.VisualRowCount.ToString());
            oDBs_Details.SetValue("U_ItemGrpCode", oDBs_Details.Offset, "");
            mtxItemGroup.SetLineData(mtxItemGroup.VisualRowCount);
        }

        private void LoadMatrixComboValues()
        {
            //Add Matrix New Line
            AddMatrixLine();
            SAPbouiCOM.Column oColumn = (SAPbouiCOM.Column)mtxItemGroup.Columns.Item("Col_0");
            if (oColumn.ValidValues.Count <= 0)
            {
                B1Helper.SAPFillMatrixComboValues(oColumn, "SELECT T0.\"ItmsGrpCod\", T0.\"ItmsGrpNam\" FROM OITB T0 ");
            }

        }

        private void mtxItemGroup_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Col_0")
            {
                SAPbouiCOM.Column oColumn = (SAPbouiCOM.Column)mtxItemGroup.Columns.Item("Col_0");
                SAPbouiCOM.ComboBox oComboBox = (SAPbouiCOM.ComboBox)oColumn.Cells.Item(pVal.Row).Specific;
                if (oComboBox.Value != string.Empty)
                {
                    AddMatrixLine();
                }
            }
        }

        private bool Validation()
        {
            if (this.tbCode.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Coverage Code", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }

            if (this.tbName.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Coverage Name", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }

            return false;
        }

        private void btnAdd_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                if (Validation())
                {
                    BubbleEvent = false;
                    return;
                }
                //if (checkIfAnyActiveDocuments())
                //{
                //    BubbleEvent = false;
                //    Application.SBO_Application.SetStatusBarMessage("Already we have Active Coverage Documents", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                //    return;
                //}
            }
            BubbleEvent = true;

        }

        public bool checkIfAnyActiveDocuments()
        {
            SAPbobsCOM.Recordset rsCheck = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string query = "SELECT *  FROM \"@Z_OCVD\"  T0 , \"@Z_CVD1\"  T1 WHERE T0.\"DocEntry\" = T1.\"DocEntry\" and  T0.\"U_Active\" ='Y'";
            rsCheck.DoQuery(query);
            if (rsCheck.RecordCount > 0)
            {
                return true;
            }
            return false;
        }

        private void mtxItemGroup_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (mtxItemGroup.VisualRowCount > 1 && pVal.Row != 0 && pVal.Row <= mtxItemGroup.VisualRowCount && pVal.ColUID == "#")
            {
                mtxItemGroup.SelectRow(pVal.Row, true, false);
                selectedRow = pVal.Row;
            }
        }

        private void btnDelRow_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (selectedRow > 0)
            {
                if (mtxItemGroup.RowCount > 0 && mtxItemGroup.IsRowSelected(selectedRow))
                {
                    mtxItemGroup.DeleteRow(selectedRow);
                    UIAPIRawForm.Freeze(true);
                    for (int i = 1; i <= mtxItemGroup.VisualRowCount; i++)
                    {
                        mtxItemGroup.SetCellValue("#", i, i);
                    }
                    UIAPIRawForm.Freeze(false);
                    if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
                else
                {
                    Application.SBO_Application.SetStatusBarMessage("Please select row", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                }
            }
            else
            {
                Application.SBO_Application.SetStatusBarMessage("No rows to delete", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                OnCustomInitialize();
            }
        }

        private void Form_LoadBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            return;

        }

        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText tbName;

        private void btnAdd_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // oDBs_Head.Clear();
            oDBs_Head.SetValue("U_CoverageDate", 0, DateTime.Today.ToString("yyyyMMdd"));
            oDBs_Head.SetValue("U_Active", 0, "Y");
            LoadMatrixComboValues();
        }

    }
}
