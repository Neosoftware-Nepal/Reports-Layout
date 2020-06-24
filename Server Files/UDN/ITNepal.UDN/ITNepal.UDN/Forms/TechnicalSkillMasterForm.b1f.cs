using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.TechnicalSkillMasterForm", "Forms/TechnicalSkillMasterForm.b1f")]
    public class TechnicalSkillMasterForm : B1FormBase
    {
        public TechnicalSkillMasterForm()
        {
        }

        private SAPbouiCOM.Matrix mtxTech;
        SAPbouiCOM.DBDataSource oDBs_Head;
        SAPbouiCOM.DBDataSource oDBs_Details;
        private SAPbouiCOM.Button btnDelRow;
        private int selectedRow;
        private SAPbouiCOM.EditText tbCode;
        private SAPbouiCOM.EditText MchCode;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.btnDelRow = ((SAPbouiCOM.Button)(this.GetItem("btnDelRow").Specific));
            this.btnDelRow.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnDelRow_PressedAfter);
            this.tbCode = ((SAPbouiCOM.EditText)(this.GetItem("tbCode").Specific));
            this.mtxTech = ((SAPbouiCOM.Matrix)(this.GetItem("mtx_Tech").Specific));
            this.mtxTech.PressedAfter += new SAPbouiCOM._IMatrixEvents_PressedAfterEventHandler(this.mtxTech_PressedAfter);
            this.mtxTech.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.mtxTech_ChooseFromListAfter);
            this.MchCode = ((SAPbouiCOM.EditText)(this.GetItem("MchCode").Specific));
            this.MchCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.MchCode_ChooseFromListAfter);
            this.oDBs_Head = ((SAPbouiCOM.DBDataSource)(this.UIAPIRawForm.DataSources.DBDataSources.Item("@" + TableNames.Z_OTSM.ToString())));
            this.oDBs_Details = ((SAPbouiCOM.DBDataSource)(this.UIAPIRawForm.DataSources.DBDataSources.Item("@" + TableNames.Z_TSM1.ToString())));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button4.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button4_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataAddBefore += new DataAddBeforeHandler(this.Form_DataAddBefore);

        }



        private void OnCustomInitialize()
        {
            this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_ADD_MODE;
            int Code = B1Helper.GetNextCodeId("@" + TableNames.Z_OTSM);
            this.tbCode.Value = Code.ToString();
            AddMatrixLine();

            this.UIAPIRawForm.EnableMenu("1281", true);
            this.UIAPIRawForm.EnableMenu("1282", true);

            this.UIAPIRawForm.EnableMenu("1288", true);
            this.UIAPIRawForm.EnableMenu("1289", true);
            this.UIAPIRawForm.EnableMenu("1290", true);
            this.UIAPIRawForm.EnableMenu("1291", true);

            this.UIAPIRawForm.DataBrowser.BrowseBy = "tbCode";
        }

        private void AddMatrixLine()
        {
            mtxTech.AddRow();

            oDBs_Details.SetValue("LineId", oDBs_Details.Offset, mtxTech.VisualRowCount.ToString());
            oDBs_Details.SetValue("U_TechCode", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_TechName", oDBs_Details.Offset, "");
            mtxTech.SetLineData(mtxTech.VisualRowCount);
        }



        private void MchCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_ModelNo", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue(0, 0).ToString());
                oDBs_Head.SetValue("U_ModelName", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue(1, 0).ToString());
                if (mtxTech.VisualRowCount == 0)
                {
                    AddMatrixLine();
                }
            }
        }

        private void mtxTech_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

            if (pCFL.SelectedObjects != null)
            {
                string empID = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                string empName = pCFL.SelectedObjects.GetValue(1, 0).ToString() + " " + pCFL.SelectedObjects.GetValue(2, 0).ToString();
                oDBs_Details.SetValue("U_TechCode", oDBs_Details.Offset, empID);
                oDBs_Details.SetValue("U_TechName", oDBs_Details.Offset, empName);
                mtxTech.SetLineData(mtxTech.VisualRowCount);
                if (AreAllColumnsFilled(mtxTech, pVal.Row) && pVal.Row == mtxTech.VisualRowCount)
                {
                    AddMatrixLine();
                }
            }

        }

        private void mtxTech_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (mtxTech.VisualRowCount > 1 && pVal.Row != 0 && pVal.Row <= mtxTech.VisualRowCount && pVal.ColUID == "#")
            {
                mtxTech.SelectRow(pVal.Row, true, false);
                selectedRow = pVal.Row;
            }
        }


        private void btnDelRow_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (selectedRow > 0)
            {
                if (mtxTech.RowCount > 0 && mtxTech.IsRowSelected(selectedRow))
                {
                    mtxTech.DeleteRow(selectedRow);
                    UIAPIRawForm.Freeze(true);
                    for (int i = 1; i <= mtxTech.VisualRowCount; i++)
                    {
                        mtxTech.SetCellValue("#", i, i);
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

        private SAPbouiCOM.Button Button4;

        private void Button4_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            int code = B1Helper.GetNextCodeId("@" + TableNames.Z_OTSM);
            oDBs_Head.SetValue("Code", oDBs_Head.Offset, code.ToString());

            mtxTech.AddRow();
            oDBs_Details.InsertRecord(0);
            oDBs_Details.SetValue("LineId", oDBs_Details.Offset, mtxTech.VisualRowCount.ToString());
            oDBs_Details.SetValue("U_TechCode", oDBs_Details.Offset, "");
            oDBs_Details.SetValue("U_TechName", oDBs_Details.Offset, "");
            mtxTech.SetLineData(mtxTech.VisualRowCount);
        }


        private bool Validation(string itemCode)
        {
            //check item exists

            string query = "SELECT * FROM \"@Z_OTSM\"  T0  WHERE  T0.\"U_ModelNo\" ='" + itemCode + "'";
            SAPbobsCOM.Recordset orsCheck = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            orsCheck.DoQuery(query);
            if (orsCheck.RecordCount > 0)
            {
                Application.SBO_Application.SetStatusBarMessage("Entry Already exists with this ItemCode -" + itemCode, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            return false;
        }

        private void Form_DataAddBefore(ref SAPbouiCOM.BusinessObjectInfo pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (this.Validation(this.MchCode.Value))
            {
                BubbleEvent = false;
            }

        }

    }
}
