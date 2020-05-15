using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.Addon.Helpers;

namespace ITNepal.Addon.Forms
{
    [FormAttribute("ITNepal.Addon.Forms.MeterSetupForm", "Forms/MeterSetupForm.b1f")]
    class MeterSetupForm : B1FormBase
    {
        public MeterSetupForm()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtMtrCode = ((SAPbouiCOM.EditText)(this.GetItem("ed_MtrCd").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtMtrName = ((SAPbouiCOM.EditText)(this.GetItem("ed_MtrTxt").Specific));
            this.txtItemCode = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.txtItemCode.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.txtItemCode_ChooseFromListBefore);
            this.txtItemCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtItemCode_ChooseFromListAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.chkActive = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_8").Specific));
            this.btnOk = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnOk.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnOk_PressedBefore);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.oDBs_Head = ((SAPbouiCOM.DBDataSource)(this.UIAPIRawForm.DataSources.DBDataSources.Item("@Z_OMTR")));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }



        private void OnCustomInitialize()
        {
            this.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_ADD_MODE;
            this.UIAPIRawForm.Items.Item("ed_MtrCd").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.Items.Item("Item_1").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            this.UIAPIRawForm.Items.Item("ed_MtrCd").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 2, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
            this.UIAPIRawForm.EnableMenu("1281", true);
            this.UIAPIRawForm.EnableMenu("1282", true);

            this.UIAPIRawForm.EnableMenu("1288", true);
            this.UIAPIRawForm.EnableMenu("1289", true);
            this.UIAPIRawForm.EnableMenu("1290", true);
            this.UIAPIRawForm.EnableMenu("1291", true);

            this.UIAPIRawForm.DataBrowser.BrowseBy = "ed_MtrCd";
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText txtMtrCode;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtMtrName;
        private SAPbouiCOM.EditText txtItemCode;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.CheckBox chkActive;
        private SAPbouiCOM.Button btnOk;
        private SAPbouiCOM.Button btnCancel;
        SAPbouiCOM.DBDataSource oDBs_Head;
        private SAPbouiCOM.EditText EditText0;

        private void txtItemCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg pCFL = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            if (pCFL.SelectedObjects != null)
            {
                oDBs_Head.SetValue("U_ItemCode", 0, pCFL.SelectedObjects.GetValue(0, 0).ToString());
                oDBs_Head.SetValue("U_ItemName", 0, pCFL.SelectedObjects.GetValue(1, 0).ToString());
            }
        }


        /// <summary>
        /// Check if the Item already eist with the Meter
        /// </summary>
        private bool CheckItemExists()
        {
            if (this.txtItemCode.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Item Code", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }
            else
            {
                //check 
                //string query = "SELECT T0.\"U_ItemCode\" FROM \"@Z_OMTR\"  T0  WHERE  T0.\"U_ItemCode\" ='" + txtItemCode.Value + "'";
                //SAPbobsCOM.Recordset orsCheck = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                //orsCheck.DoQuery(query);
                //if (orsCheck.RecordCount > 0)
                //{
                //    Application.SBO_Application.SetStatusBarMessage("Entry Already exists with this ItemCode -" + txtItemCode.Value, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                //    return true;
                //}
                return false;
            }
        }

        private bool Validation()
        {
            if (this.txtMtrCode.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Meter Code", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }

            if (this.txtMtrName.Value == string.Empty)
            {
                Application.SBO_Application.SetStatusBarMessage("Please Enter Meter Name", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return true;
            }

            return CheckItemExists();

        }


        private void btnOk_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (pVal.FormMode == (int)SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                if (Validation())
                {
                    BubbleEvent = false;
                    return;
                }
            }

            BubbleEvent = true;

        }

        private void txtItemCode_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var ppVal = pVal as SAPbouiCOM.ISBOChooseFromListEventArg;

            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.Condition oCondition;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.Conditions emptyCon = new SAPbouiCOM.Conditions();
            oChooseFromList = this.UIAPIRawForm.ChooseFromLists.Item(ppVal.ChooseFromListUID);
            oChooseFromList.SetConditions(emptyCon);
            oConditions = oChooseFromList.GetConditions();

            oCondition = oConditions.Add();
            oCondition.Alias = "InvntItem";
            oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCondition.CondVal = "N";
            oChooseFromList.SetConditions(oConditions);

            oCondition.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;
            oCondition = oConditions.Add();
            oCondition.Alias = "PrchseItem";
            oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCondition.CondVal = "N";
            oChooseFromList.SetConditions(oConditions);

            oCondition.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;
            oCondition = oConditions.Add();
            oCondition.Alias = "TreeType";
            oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCondition.CondVal = "N";
            oChooseFromList.SetConditions(oConditions);
        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
       //     throw new System.NotImplementedException();

        }

    }
}
