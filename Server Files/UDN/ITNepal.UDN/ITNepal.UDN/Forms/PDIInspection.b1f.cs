using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.Addon.Helpers;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.MainLibrary.Utilities;


namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.PDIInspection", "Forms/PDIInspection.b1f")]
    class PDIInspection : B1FormBase
    {
        public PDIInspection()
        {
        }
        private SAPbouiCOM.DBDataSource oDBs_Head, oDBs_Row;
        private string SerialUpdate = string.Empty;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.EditText2.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.EditText2_ChooseFromListBefore);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.EditText4.ValidateBefore += new SAPbouiCOM._IEditTextEvents_ValidateBeforeEventHandler(this.EditText4_ValidateBefore);
            //  this.EditText4.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText4_LostFocusAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.EditText8.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText8_ChooseFromListAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_18").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_23").Specific));
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_24").Specific));
            this.OptionBtn2 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_25").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_27").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_29").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_32").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_33").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_34").Specific));
            this.Matrix1.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.Matrix1_LostFocusAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_35").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("Item_36").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("Item_30").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.DataUpdateAfter += new SAPbouiCOM.Framework.FormBase.DataUpdateAfterHandler(this.Form_DataUpdateAfter);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            OptionBtn1.GroupWith("Item_23");
            OptionBtn2.GroupWith("Item_23");
            OptionBtn0.Selected = true;
            UIAPIRawForm.Freeze(true);
            try
            {
                oDBs_Head = this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_PDIINSPECTION");
                Folder0.Select();
                Load_PDICheckLists();
                //  SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                //ChooseFromListCondition("Serial", "DistNumber");
                this.UIAPIRawForm.EnableMenu("1282", true);
                this.UIAPIRawForm.EnableMenu("1281", true);

                this.UIAPIRawForm.EnableMenu("1288", true);
                this.UIAPIRawForm.EnableMenu("1289", true);
                this.UIAPIRawForm.EnableMenu("1290", true);
                this.UIAPIRawForm.EnableMenu("1291", true);
                UIAPIRawForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
                UIAPIRawForm.DataBrowser.BrowseBy = "Item_20";
                UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            { UIAPIRawForm.Freeze(false); }

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText3;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
        private SAPbouiCOM.CheckBox oCheckBox;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.OptionBtn OptionBtn2;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText EditText13;

        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    // string dd = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                    oDBs_Head.SetValue("U_PDIModelN", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("Name", 0).ToString());
                    oDBs_Head.SetValue("U_PDIModel", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("Code", 0).ToString());
                    if (!string.IsNullOrEmpty(pCFL.SelectedObjects.GetValue("Code", 0).ToString()))
                        Load_PDIMeterReading(pCFL.SelectedObjects.GetValue("Code", 0).ToString());
                    //  this.UIAPIRawForm.DataSources.UserDataSources.Item("U_PDIModel").Value = dd; // pCFL.SelectedObjects.GetValue(0, 0).ToString();

                }
            }

            catch (Exception ex)
            {
                Utility.LogException("Error at PDI Inspection Method: " + ex.Message);
            }

        }

        private void EditText2_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            ChooseFromListCondition(pCFL, "DistNumber");
        }

        private void EditText2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);

                if (pCFL.SelectedObjects != null)
                {
                    // this.UIAPIRawForm.DataSources.UserDataSources.Item("U_PDISNumber").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                    oDBs_Head.SetValue("U_PDISNumber", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("DistNumber", 0).ToString());
                    //  Load_PDIMeterReading();
                }
            }

            catch (Exception ex)
            {
                Utility.LogException("Error at PDI Inspection Method: " + ex.Message);
            }

        }

        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText14;

        private void EditText8_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();  U_UserName
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
                if (pCFL.SelectedObjects != null)
                {
                    SAPbobsCOM.Recordset rsOHEM = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string query = "SELECT T0.\"U_UserName\" FROM OHEM T0 WHERE T0.\"empID\" = '" + pCFL.SelectedObjects.GetValue("empID", 0).ToString() + "'";
                    rsOHEM.DoQuery(query);
                    // this.UIAPIRawForm.DataSources.UserDataSources.Item("U_PDISNumber").Value = pCFL.SelectedObjects.GetValue(0, 0).ToString();
                    oDBs_Head.SetValue("U_PDITechnician", oDBs_Head.Offset, rsOHEM.Fields.Item(0).Value.ToString());
                    oDBs_Head.SetValue("U_PDITechnicianC", oDBs_Head.Offset, pCFL.SelectedObjects.GetValue("empID", 0).ToString());
                }
            }

            catch (Exception ex)
            {
                Utility.LogException("Error at PDI Inspection Method: " + ex.Message);
            }

        }

        private void Load_PDICheckLists()
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);

                // oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Meter").Specific;
                SAPbobsCOM.Recordset rsCheckLists = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = " SELECT T0.\"U_PDICLItem\", T0.\"U_PDIActive\" FROM \"@Z_PDICHECKLT\"  T0 WHERE T0.\"U_PDIActive\" = 'Y' ORDER BY ifnull(T0.\"Name\",0) ";
                rsCheckLists.DoQuery(query);
                Matrix0.Clear();
                if (rsCheckLists.RecordCount > 0)
                {
                    while (rsCheckLists.EoF == false)
                    {
                        Matrix0.AddRow();
                        Matrix0.SetCellValue("#", Matrix0.VisualRowCount, Matrix0.VisualRowCount.ToString());
                        Matrix0.SetCellValue("Col_0", Matrix0.VisualRowCount, rsCheckLists.Fields.Item("U_PDICLItem").Value.ToString());
                        //oCheckBox = (SAPbouiCOM.CheckBox)Matrix0.Columns.Item("Col_1").Cells.Item(Matrix0.VisualRowCount).Specific;

                        //if (rsCheckLists.Fields.Item("U_PDIActive").Value.ToString() == "Y")
                        //{
                        //    // Matrix0.SetCellValue("Col_1", Matrix0.VisualRowCount, "Y");
                        //    oCheckBox.Checked = true;
                        //}
                        //else
                        //{ //Matrix0.SetCellValue("Col_1", Matrix0.VisualRowCount, "N");
                        //    oCheckBox.Checked = false;
                        //}

                        rsCheckLists.MoveNext();
                    }
                }
                this.UIAPIRawForm.Freeze(false);
            }

            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at PDI Inspection.Load PDICheckLists Method: " + ex.Message);
            }
        }

        private void Load_PDIMeterReading(string model)
        {
            try
            {
                this.UIAPIRawForm.Freeze(true);
                string interSN = "ABC0001000"; //  ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_4").Specific).Value;
                // oMatrix = (SAPbouiCOM.Matrix)this.UIAPIRawForm.Items.Item("mtx_Meter").Specific;
                SAPbobsCOM.Recordset rsCheckLists = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = " SELECT T1.\"LineId\" ,T1.\"U_Code\" FROM \"@MODEL\"  T0 JOIN \"@Z_METERSETUP\"  T1 ON T0.\"Code\" = T1.\"Code\" WHERE T0.\"Code\"  = '" + model + "' GROUP BY T1.\"LineId\" ,T1.\"U_Code\"";
                rsCheckLists.DoQuery(query);
                Matrix1.Clear();
                if (rsCheckLists.RecordCount > 0)
                {
                    while (rsCheckLists.EoF == false)
                    {
                        Matrix1.AddRow();
                        Matrix1.SetCellValue("#", Matrix1.VisualRowCount, Matrix1.VisualRowCount.ToString());
                        Matrix1.SetCellValue("Col_0", Matrix1.VisualRowCount, rsCheckLists.Fields.Item("U_Code").Value.ToString());
                        //    Matrix1.SetCellValue("Col_1", Matrix1.VisualRowCount, rsCheckLists.Fields.Item("U_PDIActive").Value.ToString());
                        rsCheckLists.MoveNext();
                    }
                }
                this.UIAPIRawForm.Freeze(false);
            }
            catch (Exception ex)
            {
                this.UIAPIRawForm.Freeze(false);
                Utility.LogException("Error at PDI Inspection.Load Load_PDIMeterReading Method: " + ex.Message);
            }
        }

        private void Matrix1_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            int meterreading = 0;
            if (pVal.ItemUID == "Item_34" && pVal.ColUID == "Col_1")
            {
                for (int imLoop = 1; imLoop <= Matrix1.RowCount; imLoop++)
                {
                    var reading = ((SAPbouiCOM.EditText)Matrix1.Columns.Item("Col_1").Cells.Item(imLoop).Specific).Value;
                    if (reading != "")
                    {
                        meterreading += Convert.ToInt32(reading);
                    }
                }

                ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_14").Specific).Value = Convert.ToString(meterreading);

            }




        }
        private void ChooseFromListCondition(SAPbouiCOM.ISBOChooseFromListEventArg pVal, string aliasName)
        //  private void ChooseFromListCondition(string cfl, string aliasName)
        {
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;
            string condVal;
            //  string query = "SELECT T0.\"DistNumber\" FROM OSRN T0  left join \"@Z_PDIINSPECTION\"  T1 on T0.\"DistNumber\" = T1.\"U_PDISNumber\" WHERE ifnull( T1.\"U_Status\",3) = 3 and T0.\"U_PDIStatus\" = 'NotDone' ";
            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
            oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID); //cfl
            oChooseFromList.SetConditions(emptyCon);
            oConditions = oChooseFromList.GetConditions();

            //  SAPbobsCOM.Recordset rsConds = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            //  condVal = rsConds.Fields.Item(0).Value.ToString();
            oCondition = oConditions.Add();
            oCondition.Alias = "U_PDIStatus";
            oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_CONTAIN;
            oCondition.CondVal = "NotDone";
            oChooseFromList.SetConditions(oConditions);


            //  rsConds.DoQuery(query);
            //if (rsConds.RecordCount > 0)
            //{
            //    int j = 1;
            //    int i = rsConds.RecordCount;
            //    while (rsConds.EoF == false)
            //    {
            //        condVal = rsConds.Fields.Item(0).Value.ToString();
            //        oCondition = oConditions.Add();
            //        oCondition.Alias = aliasName;
            //        oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_CONTAIN;
            //        oCondition.CondVal =  condVal;
            //        oChooseFromList.SetConditions(oConditions);

            //        if (j < i)
            //            oConditions.Item(oConditions.Count - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;

            //        rsConds.MoveNext();
            //        j++;
            //    }

            //}



        }

        private void EditText4_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            //   TimeSpan STime = TimeSpan.Parse("00:00"), ETime = TimeSpan.Parse("00:00");
            TimeSpan STime = TimeSpan.Parse("00:00"), ETime = TimeSpan.Parse("00:00");

            string starttime = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_6").Specific).Value;
            string Endtime = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_8").Specific).Value;
            if (starttime != "" && Endtime != "")
            {
                //switch (starttime.Length)
                //{
                //    case 4:
                //        STime = TimeSpan.Parse(starttime.Substring(0, 2) + ":" + starttime.Substring(2, 2) + ":00");
                //        break;

                //    case 3:
                //        STime = TimeSpan.Parse(Convert.ToString(starttime) + ":00");
                //        break;


                //}
                //if (starttime.Length == 4)
                //{ }
                //TimeSpan STime = TimeSpan.Parse(Convert.ToString(starttime) + ":00");
                //    TimeSpan ETime = TimeSpan.Parse(Convert.ToString(Endtime) + ":00");

                STime = TimeSpan.Parse(starttime.Substring(0, 2) + ":" + starttime.Substring(2, 2) + ":00");
                ETime = TimeSpan.Parse(Endtime.Substring(0, 2) + ":" + Endtime.Substring(2, 2) + ":00");
                TimeSpan Result = ETime.Subtract(STime);
                ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_10").Specific).Value = Result.ToString(@"hh\:mm");
            }
        }

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            // throw new System.NotImplementedException();
            try
            {
                if (Validation())
                {
                    BubbleEvent = false;
                    return;
                }
            }
            catch (Exception Ex)
            {
                Application.SBO_Application.SetStatusBarMessage(Ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private bool Validation()
        {
            try
            {
                SerialUpdate = string.Empty;
                switch (UIAPIRawForm.Mode)
                {
                    case SAPbouiCOM.BoFormMode.fm_ADD_MODE:

                        if (OptionBtn2.Selected == true)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Status should not be Closed ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }

                        if (this.EditText0.Value == string.Empty)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Modal should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }
                        if (this.EditText2.Value == string.Empty)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Serial should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }
                        if (this.EditText8.Value == string.Empty)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Technician should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }

                        //if (OptionBtn1.Selected == true)
                        //{
                        //    if (this.EditText13.Value == string.Empty)
                        //    {
                        //        Application.SBO_Application.SetStatusBarMessage("Pending Remarks should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        //        return true;
                        //    }
                        //}


                        break;
                    case SAPbouiCOM.BoFormMode.fm_UPDATE_MODE:
                        if (this.EditText0.Value == string.Empty)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Modal should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }
                        if (this.EditText2.Value == string.Empty)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Serial should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }
                        if (this.EditText8.Value == string.Empty)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Technician should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            return true;
                        }

                        if (OptionBtn1.Selected == true)
                        {
                            if (this.EditText13.Value == string.Empty)
                            {
                                Application.SBO_Application.SetStatusBarMessage("Pending Remarks should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                                return true;
                            }
                        }
                        else if (OptionBtn2.Selected == true)
                        {
                            if (this.EditText5.Value == string.Empty)
                            {
                                Application.SBO_Application.SetStatusBarMessage("Total Duration should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                                return true;
                            }
                            //if (this.EditText7.Value == string.Empty)
                            //{
                            //    Application.SBO_Application.SetStatusBarMessage("Total Meter Reading should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            //    return true;
                            //}
                            if (this.EditText12.Value == string.Empty)
                            {
                                Application.SBO_Application.SetStatusBarMessage("PDI Date should not be Empty ...!", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                                return true;
                            }

                            SerialUpdate = "UPDATE OSRN set \"U_PDIStatus\" =  'Done', \"U_PDIDate\"= '" + this.EditText12.Value + "', \"U_PDITech\" = '" + this.EditText8.Value + "' where \"DistNumber\" = '" + this.EditText2.Value + "' ";
                        }
                        break;

                }


                return false;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
        }

        private void Form_DataUpdateAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //throw new System.NotImplementedException();
            if (SerialUpdate.Length > 0)
            {
                SAPbobsCOM.Recordset rsupdateserial = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsupdateserial.DoQuery(SerialUpdate);
                SerialUpdate = string.Empty;
            }
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //throw new System.NotImplementedException();
            if (OptionBtn2.Selected == true)
            {
                Matrix0.Columns.Item("Col_1").Editable = false;
                Matrix1.Columns.Item("Col_1").Editable = false;
                this.UIAPIRawForm.ActiveItem = "Item_21";
                this.UIAPIRawForm.Items.Item("Item_1").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_4").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_6").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_8").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_12").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_16").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_27").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_36").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_23").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_24").Enabled = false;
                this.UIAPIRawForm.Items.Item("Item_25").Enabled = false;
            }
            else
            {
                {
                    Matrix0.Columns.Item("Col_1").Editable = true;
                    Matrix1.Columns.Item("Col_1").Editable = true;
                    this.UIAPIRawForm.ActiveItem = "Item_21";
                    this.UIAPIRawForm.Items.Item("Item_1").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_4").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_6").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_8").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_12").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_16").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_27").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_36").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_23").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_24").Enabled = true;
                    this.UIAPIRawForm.Items.Item("Item_25").Enabled = true;
                }
            }
        }

        private void EditText4_ValidateBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //  throw new System.NotImplementedException();
            TimeSpan STime = TimeSpan.Parse("00:00"), ETime = TimeSpan.Parse("00:00");

            string starttime = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_6").Specific).Value;
            string Endtime = ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_8").Specific).Value;
            if (starttime != "" && Endtime != "")
            {
                //switch (starttime.Length)
                //{
                //    case 4:
                //        STime = TimeSpan.Parse(starttime.Substring(0, 2) + ":" + starttime.Substring(2, 2) + ":00");
                //        break;

                //    case 3:
                //        STime = TimeSpan.Parse(Convert.ToString(starttime) + ":00");
                //        break;


                //}
                //if (starttime.Length == 4)
                //{ }
                //TimeSpan STime = TimeSpan.Parse(Convert.ToString(starttime) + ":00");
                //    TimeSpan ETime = TimeSpan.Parse(Convert.ToString(Endtime) + ":00");

                STime = TimeSpan.Parse(starttime.Substring(0, 2) + ":" + starttime.Substring(2, 2) + ":00");
                ETime = TimeSpan.Parse(Endtime.Substring(0, 2) + ":" + Endtime.Substring(2, 2) + ":00");
                TimeSpan Result = ETime.Subtract(STime);
                if (Result.Ticks >=0)
                { ((SAPbouiCOM.EditText)this.UIAPIRawForm.Items.Item("Item_10").Specific).Value = Result.ToString(@"hh\:mm"); }
                else {
                    Utility.LogException("End time should not be earlier then Start time ......! ");
                    BubbleEvent = false;
                    return;
                }
                
            }
        }
    }
}
