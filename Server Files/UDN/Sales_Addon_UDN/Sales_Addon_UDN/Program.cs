using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;
using SAPbobsCOM;
using System.Configuration;

namespace Sales_Addon_UDN
{
    class Program
    {
        #region Variables

        public static SAPbobsCOM.Company oCompany;
        public static SAPbouiCOM.Application SBO_Application;
        public static SAPbouiCOM.Form oForm { get; set; }

        public static UDClass objUDclass;
        #endregion

        /// <summary_>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application oApp = null;

                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    oApp = new Application(args[0]);
                }


                var i = SAPbouiCOM.Framework.Application.SBO_Application;
                SBO_Application = SAPbouiCOM.Framework.Application.SBO_Application;
                oCompany = (SAPbobsCOM.Company)SBO_Application.Company.GetDICompany();



                ///this will be called when running addon connects first time as this will generate the UDF's and required tables.
                ///
                if (ConfigurationSettings.AppSettings["UDF"].ToString() == "N")
                    objUDclass = new UDClass(oCompany);

                CreateFMS();

                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();

                Program.SBO_Application.StatusBar.SetText("Addon is Connected.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);

                //Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                Application.SBO_Application.RightClickEvent += new SAPbouiCOM._IApplicationEvents_RightClickEventEventHandler(SBO_ApplicationRightClickEvent);
                oApp.Run();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        static void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    break;
                default:
                    break;
            }
        }

        //private static void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)  //item event for close the form
        //{
        //    BubbleEvent = true;
        //}//end

        private static void SBO_ApplicationRightClickEvent(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {

            BubbleEvent = true;

        }

        public static void CreateFMS()
        {
            int UserQueryCategoryID = GetUserQueryCategoryID("FMS", true);

            #region Anish
            //***Get Group data
            string PreFetchDocEQry = "Select Distinct U_BRND  as \"Brand\"  from OITM Where ifnull(U_BRND,'') <> ''";
            int PreFetchDocNQID = CreateUserQuery("Brand List", PreFetchDocEQry, UserQueryCategoryID);
            AssignQuery(PreFetchDocNQID, "BILLNTRD", "Item_6", "Brand", false, "Brand");
            #endregion

            #region Promotion Setup Brand
            //***Get Group data
            string PreFetchDocEQue = "Select Distinct U_BRND  as \"Applicable Value\"   from OITM Where ifnull(U_BRND,'') <> '' and $[@ITN_PRO1.U_APPTYPE] = 'B'"+
                                        "Union all Select Distinct U_SUBBRND  from OITM Where ifnull(U_SUBBRND,'') <> ''  and $[@ITN_PRO1.U_APPTYPE] = 'SB' "+
                                        "union all Select \"ItemCode\"  from OITM  where $[@ITN_PRO1.U_APPTYPE] = 'S'";

            int PreFetchDocNQUEID = CreateUserQuery("Brand", PreFetchDocEQue, UserQueryCategoryID);

            AssignQuery(PreFetchDocNQUEID, "PROSTUP", "Item_30", "AppVal", false, "AppVal");

            string Province = "Select U_CODE , U_NAME From \"@ITNPROV\"";
            int ProvinceID = CreateUserQuery("Province", Province, UserQueryCategoryID);
            AssignQuery(ProvinceID, "-134", "U_PROVCD", "-1", false, "U_PROVCD");

            string District = "Select U_CODE , U_NAME From \"@ITNDIST\"";
            int DistrictID = CreateUserQuery("District", District, UserQueryCategoryID);
            AssignQuery(DistrictID, "-134", "U_DISTCD", "-1", false, "U_DISTCD");

            string TOWN = "Select U_CODE , U_NAME From \"@ITNTOWN\"";
            int TOWNID = CreateUserQuery("Town", TOWN, UserQueryCategoryID);
            AssignQuery(TOWNID, "-134", "U_TOWNCD", "-1", false, "U_TOWNCD");

            //string TOWN = "Select U_CODE , U_NAME From \"@ITNTOWN\"";
            //int TOWNID = CreateUserQuery("Town", TOWN, UserQueryCategoryID);
            //AssignQuery(TOWNID, "-134", "U_TOWNCD", "-1", false, "U_TOWNCD");

            #endregion

        }

        public static int GetUserQueryCategoryID(string categoryName, bool autoCreateCategory = false)
        {
            // Create a new User Category if the categoryName specified does not exist
            // Returns the Internal Key ID of the Category
            int catid = 0;
            SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            try
            {

                oRecordSet.DoQuery("SELECT \"CategoryId\", \"CatName\" FROM \"OQCN\" WHERE \"CatName\" = '" + categoryName + "'");

                if (!oRecordSet.EoF)
                {
                    catid = Convert.ToInt32(oRecordSet.Fields.Item("CategoryId").Value);
                }
                else
                {
                    if (autoCreateCategory)
                    {
                        // Add a New Query Category Called Integratech to the [OQCN] Table
                        SAPbobsCOM.QueryCategories qc = (SAPbobsCOM.QueryCategories)Program.oCompany.GetBusinessObject(BoObjectTypes.oQueryCategories);
                        qc.Name = categoryName;
                        qc.Permissions = "YYYYYYYYYYYYYYY";
                        if (qc.Add() == 0)
                        {
                            return Convert.ToInt32(Program.oCompany.GetNewObjectKey());
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // GC Release
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
            }

            return catid;
        }
        public static int CreateUserQuery(string name, string sql, int queryCategoryId)
        {
            // Check if query name exists first
            int queryId = GetUserQueryID(name);

            // Create if query doesn't exist
            if (queryId == 0)
            {
                SAPbobsCOM.UserQueries userQuery = (SAPbobsCOM.UserQueries)Program.oCompany.GetBusinessObject(BoObjectTypes.oUserQueries);
                try
                {


                    // Create new Query
                    userQuery.QueryType = UserQueryTypeEnum.uqtWizard;
                    userQuery.QueryCategory = queryCategoryId;
                    userQuery.QueryDescription = name;
                    userQuery.Query = sql;

                    if (userQuery.Add() == 0)
                    {
                        queryId = GetUserQueryID(name);
                        //**** Not Exist Query
                        return queryId;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userQuery);
                }
            }

            else
            {

            }
            return queryId;
        }
        //*** return the query Id if new then otherwise  > 0
        public static int GetUserQueryID(string name)
        {
            // Creates a new User Query if the name specified does not exist
            // Returns the Internal Key ID of the Query

            int queryID = 0;

            #region Lookup Query Name and Get ID if exists

            Recordset oRecordset = (Recordset)Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            try
            {
                string sql = "SELECT \"IntrnalKey\" FROM \"OUQR\" WHERE \"QName\" = '" + name + "'";

                oRecordset.DoQuery(sql);
                if (!oRecordset.EoF)
                {
                    // Return query ID as it already exists
                    return Convert.ToInt32(oRecordset.Fields.Item("intrnalkey").Value);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
            }

            #endregion

            // Garbage Collection
            GC.Collect();

            return queryID;
        }
        public static void AssignQuery(int queryId, string formId, string itemId, string column = "-1", bool AutoRefresh = false, string FieldId = "")
        {
            // This will assign a query to a form item & column 
            // This will reassign a query to an item that already has a query assigned
            // CSHS Table = User Defined Values Table

            SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            try
            {
                // Validate query exists
                oRecordSet.DoQuery("SELECT \"IntrnalKey\", \"QName\" FROM \"OUQR\" WHERE \"IntrnalKey\" = " + queryId);
                bool queryExists = false;
                if (!oRecordSet.EoF)
                {
                    queryExists = true;
                }
                else
                {

                }

                if (queryExists)
                {
                    // Values Example
                    //string form = "VoucherCodes.Form1";
                    //string item = "PMatrix";
                    //string column = "PName";  // Matrix Column Name 

                    // Get UDV For Form Item
                    oRecordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    oRecordSet.DoQuery("SELECT \"IndexID\" FROM \"CSHS\" WHERE \"FormID\" = '" + formId + "' AND \"ItemID\" = '" + itemId + "' AND \"ColID\" = '" + column + "'");
                    if (!oRecordSet.EoF)
                    {
                        #region Update Existing

                        SAPbobsCOM.FormattedSearches fms = (SAPbobsCOM.FormattedSearches)Program.oCompany.GetBusinessObject(BoObjectTypes.oFormattedSearches);
                        fms.GetByKey(Convert.ToInt32(oRecordSet.Fields.Item("IndexID").Value));
                        fms.Action = BoFormattedSearchActionEnum.bofsaQuery;
                        if (AutoRefresh)
                        {
                            fms.ForceRefresh = BoYesNoEnum.tYES;
                            fms.FieldID = FieldId;
                            fms.Refresh = BoYesNoEnum.tYES;
                        }
                        fms.FormID = formId;
                        fms.ItemID = itemId;
                        fms.ColumnID = column;
                        fms.QueryID = queryId;
                        fms.Update();
                        //  Program.ErrorHandler(fms.Update(), "updating a form items assigned user defined values(fms)"); 

                        #endregion
                    }
                    else
                    {
                        #region Add New

                        SAPbobsCOM.FormattedSearches fms = (SAPbobsCOM.FormattedSearches)Program.oCompany.GetBusinessObject(BoObjectTypes.oFormattedSearches);
                        fms.Action = BoFormattedSearchActionEnum.bofsaQuery;
                        if (AutoRefresh)
                        {
                            fms.ForceRefresh = BoYesNoEnum.tYES;
                            fms.FieldID = FieldId;
                            fms.Refresh = BoYesNoEnum.tYES;
                        }
                        fms.FormID = formId;
                        fms.ItemID = itemId;
                        fms.ColumnID = column;
                        fms.QueryID = queryId;
                        fms.Add();
                        //  Program.ErrorHandler(fms.Add(), "adding a user defined value to form item");

                        #endregion
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // GC Release
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
            }
        }

    }
}
