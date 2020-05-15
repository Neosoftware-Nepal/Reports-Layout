using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.Addon.Helpers;


namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.Approval_Stage", "Forms/Approval_Stage.b1f")]
    class Approval_Stage : B1FormBase
    {
        public Approval_Stage()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_5").Specific));
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_4").Specific).Value = B1Helper.DiCompany.UserName;
            if (Matrix0.RowCount == 0)
            {
                Matrix0.AddLine();
                Matrix0.SetCellValue("#", Matrix0.VisualRowCount, Matrix0.VisualRowCount.ToString());
            }
            this.UIAPIRawForm.EnableMenu("1282", true);
            this.UIAPIRawForm.EnableMenu("1281", true);

            this.UIAPIRawForm.EnableMenu("1288", true);
            this.UIAPIRawForm.EnableMenu("1289", true);
            this.UIAPIRawForm.EnableMenu("1290", true);
            this.UIAPIRawForm.EnableMenu("1291", true);
            this.UIAPIRawForm.EnableMenu("1283", false);
            this.UIAPIRawForm.EnableMenu("1284", false);
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText3;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            // throw new System.NotImplementedException();

        }

        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                try
                {
                    ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_2").Specific).Value = pCFL.SelectedObjects.GetValue("U_NAME", 0).ToString();
                    ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_1").Specific).Value = pCFL.SelectedObjects.GetValue("USER_CODE", 0).ToString();
                }
                catch (Exception ex) { }
            }
        }

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                try
                {
                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value = pCFL.SelectedObjects.GetValue("USER_CODE", 0).ToString();

                }
                catch (Exception ex) { }
                ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Col_1").Cells.Item(pVal.Row).Specific).Value = pCFL.SelectedObjects.GetValue("U_NAME", 0).ToString();
                // ((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(pVal.Row).Specific).Value = Convert.ToString(Matrix0.VisualRowCount);

                if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                if (pVal.Row == Matrix0.VisualRowCount)
                {
                    UIAPIRawForm.DataSources.DBDataSources.Item(1).Clear();
                   // Matrix0.FlushToDataSource();
                    Matrix0.AddRow();
                    // Matrix0.CommonSetting.SetCellEditable(Matrix0.VisualRowCount, 1, true);
                    Matrix0.SetCellValue("#", Matrix0.VisualRowCount, Matrix0.VisualRowCount.ToString());
                }

                Matrix0.AutoResizeColumns();
                UIAPIRawForm.Refresh();
            }

        }

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            for (int iLopp = 1; iLopp <= Matrix0.RowCount - 1; iLopp++)
            {
                if (string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix0.Columns.Item("Col_0").Cells.Item(iLopp).Specific).Value))
                {
                    Application.SBO_Application.SetStatusBarMessage("Authorizer should not be empty ... !", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    BubbleEvent = false;
                    return;
                }
            }

            if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string qry = "SELECT 'True' FROM OCTR T0 where T0.\"Owner\" = (SELECT \"USERID\" FROM OUSR T0 WHERE T0.\"USER_CODE\" = '" + ((SAPbouiCOM.EditText)UIAPIRawForm.Items.Item("Item_4").Specific).Value + "') and  T0.\"Status\" = 'D' ";
                oRS.DoQuery(qry);
                if (oRS.RecordCount > 0)
                {
                    Application.SBO_Application.SetStatusBarMessage("Not Permits to modify... !", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    BubbleEvent = false;
                    return;
                }
            }
        }
    }
}
