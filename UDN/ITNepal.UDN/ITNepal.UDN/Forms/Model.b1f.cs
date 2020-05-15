using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.Addon.Helpers;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.Model", "Forms/Model.b1f")]
    class Model : B1FormBase
    {
        private SAPbouiCOM.DBDataSource oDBs_Row, oDBs_Row1, oDBs_Row2;
        public Model()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_23").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_25").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("Item_29").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("Item_31").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("Item_33").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("Item_35").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_37").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_40").Specific));
            this.Folder2 = ((SAPbouiCOM.Folder)(this.GetItem("Item_41").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_42").Specific));
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_43").Specific));
            this.Matrix1.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.Matrix1_ChooseFromListBefore);
            this.Matrix1.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix1_ChooseFromListAfter);
            this.Matrix2 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_44").Specific));
            this.Matrix2.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.Matrix2_ChooseFromListBefore);
            this.Matrix2.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix2_ChooseFromListAfter);
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_38").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("Item_39").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_45").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_47").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_49").Specific));
            this.EditText20 = ((SAPbouiCOM.EditText)(this.GetItem("Item_50").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_51").Specific));
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_52").Specific));
            this.EditText21 = ((SAPbouiCOM.EditText)(this.GetItem("Item_53").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oDBs_Row = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_RITEM");
            oDBs_Row1 = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_METERSETUP");
            oDBs_Row2 = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_PRICESETUP");
            Load_Model();
        }

        private void Load_Model()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                this.UIAPIRawForm.EnableMenu("1282", true);
                this.UIAPIRawForm.EnableMenu("1281", true);

                this.UIAPIRawForm.EnableMenu("1288", true);
                this.UIAPIRawForm.EnableMenu("1289", true);
                this.UIAPIRawForm.EnableMenu("1290", true);
                this.UIAPIRawForm.EnableMenu("1291", true);

                Folder0.Select();
                this.UIAPIRawForm.PaneLevel = 1;
                Matrix0.AddRow();
                Matrix0.SetCellValue("#", Matrix0.VisualRowCount, Matrix0.VisualRowCount.ToString());
                Matrix1.AddRow();
                Matrix1.SetCellValue("#", Matrix1.VisualRowCount, Matrix1.VisualRowCount.ToString());
                Matrix2.AddRow();
                Matrix2.SetCellValue("#", Matrix2.VisualRowCount, Matrix2.VisualRowCount.ToString());
                Matrix2.SetCellValue("Col_1", Matrix2.VisualRowCount, 0);
                Matrix2.SetCellValue("Col_2", Matrix2.VisualRowCount, 0);
               // var ocolumn = (SAPbouiCOM.Column)Matrix2.Columns.Item("Col_8");
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string qry = "SELECT *  FROM \"@PRDSUB_CATEGORY\"  ";
                oRS.DoQuery(qry);
                if (oRS.RecordCount > 0)
                {
                    while (oRS.EoF == false)
                    {
                        ComboBox0.ValidValues.Add(oRS.Fields.Item(0).Value.ToString(), oRS.Fields.Item(1).Value.ToString());
                        oRS.MoveNext();
                    }
                }

                //qry = "SELECT T0.\"Code\", T0.\"Name\" FROM \"@Z_POOL\"  T0 ORDER BY T0.\"Code\" ";
                //oRS.DoQuery(qry);
                //if (oRS.RecordCount > 0)
                //{
                //    while (oRS.EoF == false)
                //    {
                //        ocolumn.ValidValues.Add(oRS.Fields.Item(1).Value.ToString(), oRS.Fields.Item(1).Value.ToString());
                //        oRS.MoveNext();
                //    }
                //}
                UIAPIRawForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            { this.UIAPIRawForm.Freeze(false); }

        }

        private SAPbouiCOM.EditText EditText0;
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
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText7;
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
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText EditText17;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Folder Folder2;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Matrix Matrix2;

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //  oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Meter").Specific;
            try
            {
                if (pVal.ColUID == "Col_0")
                {
                    SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                    if (pCFL.ChooseFromListUID == "CFL_0")
                    {
                        if (pCFL.SelectedObjects != null)
                        {
                            var itemCode = pCFL.SelectedObjects.GetValue("ItemCode", 0).ToString().Trim();
                            if (itemCode != string.Empty)
                            {
                                Matrix0.SetCellValue("Col_2", pVal.Row, pCFL.SelectedObjects.GetValue("ItemName", 0).ToString());
                                Matrix0.SetCellValue("Col_1", pVal.Row, pCFL.SelectedObjects.GetValue("CodeBars", 0).ToString());
                                try
                                {
                                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value = pCFL.SelectedObjects.GetValue("ItemCode", 0).ToString();
                                    //  Matrix0.SetCellValue("Col_0", pVal.Row, pCFL.SelectedObjects.GetValue("ItemCode", 0).ToString());
                                }
                                catch (Exception ex) { }
                                if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                    UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                                if (pVal.Row == Matrix0.VisualRowCount)
                                {
                                   // UIAPIRawForm.DataSources.DBDataSources.Item(1).Clear();
                                    Matrix0.AddRow();
                                    Matrix0.CommonSetting.SetCellEditable(Matrix0.VisualRowCount, 1, true);
                                    Matrix0.SetCellValue("#", Matrix0.VisualRowCount, Matrix0.VisualRowCount.ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }



        }

        private void Matrix1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            if (pVal.ColUID == "Col_0")
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.ChooseFromListUID == "CFL_1")
                {
                    if (pCFL.SelectedObjects != null)
                    {
                        var itemCode = pCFL.SelectedObjects.GetValue("Code", 0).ToString().Trim();
                        if (itemCode != string.Empty)
                        {
                            Matrix1.SetCellValue("Col_3", pVal.Row, pCFL.SelectedObjects.GetValue("U_ItemName", 0).ToString());
                            Matrix1.SetCellValue("Col_2", pVal.Row, pCFL.SelectedObjects.GetValue("U_ItemCode", 0).ToString());
                            Matrix1.SetCellValue("Col_1", pVal.Row, pCFL.SelectedObjects.GetValue("Name", 0).ToString());
                            try
                            {
                                ((SAPbouiCOM.EditText)Matrix1.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value = pCFL.SelectedObjects.GetValue("Code", 0).ToString();
                                //    Matrix1.SetCellValue("Col_0", pVal.Row, pCFL.SelectedObjects.GetValue("Code", 0).ToString());
                            }
                            catch (Exception ex) { }
                            if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                            if (pVal.Row == Matrix1.VisualRowCount)
                            {
                                Matrix1.AddRow();
                                Matrix1.CommonSetting.SetCellEditable(Matrix1.VisualRowCount, 1, true);
                                Matrix1.SetCellValue("#", Matrix1.VisualRowCount, Matrix1.VisualRowCount.ToString());
                            }
                        }
                    }
                }
            }

        }

        private void Matrix2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            if (pVal.ColUID == "Col_0")
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.ChooseFromListUID == "CFL_2")
                {
                    if (pCFL.SelectedObjects != null)
                    {
                        var itemCode = pCFL.SelectedObjects.GetValue("Code", 0).ToString().Trim();
                        if (itemCode != string.Empty)
                        {
                            try
                            {
                                ((SAPbouiCOM.EditText)Matrix2.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).Value = pCFL.SelectedObjects.GetValue("Code", 0).ToString();
                                //Matrix2.SetCellValue("Col_0", pVal.Row, pCFL.SelectedObjects.GetValue("Code", 0).ToString());
                            }
                            catch (Exception ex) { }
                            if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                            if (pVal.Row == Matrix2.VisualRowCount)
                            {
                                Matrix2.AddRow();
                                Matrix2.CommonSetting.SetCellEditable(Matrix2.VisualRowCount, 1, true);
                                Matrix2.SetCellValue("#", Matrix2.VisualRowCount, Matrix2.VisualRowCount.ToString());

                            }
                        }
                    }
                }
            }
        }

        private void Matrix2_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //  throw new System.NotImplementedException(); U_Status
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "Code", "Y", "M", "");

        }


        private void ChooseFromListCondition(SAPbouiCOM.ISBOChooseFromListEventArg pVal, string aliasName, string condVal, string CondType = "", string query = "")
        {
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;

            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
            oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID);
            oChooseFromList.SetConditions(emptyCon);
            oConditions = oChooseFromList.GetConditions();

            if (CondType == "")
            {
                oCondition = oConditions.Add();
                oCondition.Alias = aliasName;
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = condVal;
                oChooseFromList.SetConditions(oConditions);
            }
            else if (CondType == "q")
            {
                SAPbobsCOM.Recordset rsConds = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsConds.DoQuery(query);
                if (rsConds.RecordCount > 0)
                {
                    int j = 1;
                    int i = rsConds.RecordCount;
                    while (rsConds.EoF == false)
                    {
                        condVal = rsConds.Fields.Item(0).Value.ToString();
                        oCondition = oConditions.Add();
                        oCondition.Alias = aliasName;
                        oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCondition.CondVal = condVal;
                        oChooseFromList.SetConditions(oConditions);
                        if (j < i)
                            oConditions.Item(oConditions.Count - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;

                        rsConds.MoveNext();
                        j++;
                    }

                }
                else
                {
                    oCondition = oConditions.Add();
                    oCondition.Alias = aliasName;
                    oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCondition.CondVal = condVal;
                    oChooseFromList.SetConditions(oConditions);
                }

            }
            else
            {
                int j = 1;
                if (Matrix1.RowCount > 0)
                {
                    for (int iRow = 1; iRow <= Matrix1.RowCount; iRow++)
                    {
                        condVal = ((SAPbouiCOM.EditText)Matrix1.Columns.Item("Col_0").Cells.Item(iRow).Specific).Value;
                        oCondition = oConditions.Add();
                        oCondition.Alias = aliasName;
                        oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCondition.CondVal = condVal;
                        oChooseFromList.SetConditions(oConditions);
                        if (j < Matrix1.RowCount)
                            oConditions.Item(oConditions.Count - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;

                        j++;
                    }
                }
                else
                {
                    oCondition = oConditions.Add();
                    oCondition.Alias = aliasName;
                    oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCondition.CondVal = condVal;
                    oChooseFromList.SetConditions(oConditions);
                }

            }
        }

        private void Matrix1_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "U_Status", "N", "", "");


        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //throw new System.NotImplementedException();

            this.GetItem("Item_1").Enabled = false;
            this.GetItem("Item_19").Enabled = false;
            if (Matrix0.RowCount > 0)
            {
                for (int iRow = 1; iRow <= Matrix0.RowCount; iRow++)
                {
                    if (!string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix0.Columns.Item("Col_0").Cells.Item(iRow).Specific).Value))
                    {
                        Matrix0.CommonSetting.SetCellEditable(iRow, 1, false);
                    }
                    else { Matrix0.CommonSetting.SetCellEditable(iRow, 1, true); }
                }
            }
            else
            {
                Matrix0.AddRow();
                Matrix0.SetCellValue("#", Matrix0.VisualRowCount, Matrix0.VisualRowCount.ToString());
                Matrix0.CommonSetting.SetCellEditable(1, 1, true);
            }
            if (Matrix1.RowCount > 0)
            {
                for (int iRow = 1; iRow <= Matrix1.RowCount; iRow++)
                {
                    if (!string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix1.Columns.Item("Col_0").Cells.Item(iRow).Specific).Value))
                    {
                        Matrix1.CommonSetting.SetCellEditable(iRow, 1, false);
                    }
                    else { Matrix1.CommonSetting.SetCellEditable(iRow, 1, true); }
                }
            }
            else
            {
                Matrix1.AddRow();
                Matrix1.SetCellValue("#", Matrix1.VisualRowCount, Matrix1.VisualRowCount.ToString());
                Matrix1.CommonSetting.SetCellEditable(1, 1, true);
            }
            if (Matrix2.RowCount > 0)
            {
                for (int iRow = 1; iRow <= Matrix2.RowCount; iRow++)
                {
                    if (!string.IsNullOrEmpty(((SAPbouiCOM.EditText)Matrix2.Columns.Item("Col_0").Cells.Item(iRow).Specific).Value))
                    {
                        Matrix2.CommonSetting.SetCellEditable(iRow, 1, false);
                    }
                    else { Matrix2.CommonSetting.SetCellEditable(iRow, 1, true); }
                }
            }
            else
            {
                Matrix2.AddRow();
                Matrix2.SetCellValue("#", Matrix1.VisualRowCount, Matrix1.VisualRowCount.ToString());
                Matrix2.CommonSetting.SetCellEditable(1, 1, true);
                Matrix2.SetCellValue("Col_1", Matrix2.VisualRowCount, 0);
                Matrix2.SetCellValue("Col_2", Matrix2.VisualRowCount, 0);
                var oComboBox = (SAPbouiCOM.ComboBox)Matrix2.Columns.Item("Col_4").Cells.Item(Matrix2.VisualRowCount).Specific;
                oComboBox.Select("A4", SAPbouiCOM.BoSearchKey.psk_ByValue);
                oComboBox = (SAPbouiCOM.ComboBox)Matrix2.Columns.Item("Col_5").Cells.Item(Matrix2.VisualRowCount).Specific;
                oComboBox.Select("BW", SAPbouiCOM.BoSearchKey.psk_ByValue);

            }



        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            if (pVal.ActionSuccess && UIAPIRawForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                Load_Model();
            }

        }

        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText EditText18;
        private SAPbouiCOM.ComboBox ComboBox0;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            // throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.EditText EditText20;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText22;
        private SAPbouiCOM.EditText EditText21;
    }
}
