using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.MainLibrary.Utilities;
using GlobalVariable;

namespace ITNepal.Addon.Helpers
{
    public class AddonInfoInfo
    {
        #region Members
        public int Index { get; set; }
        public bool isHana { get; set; }
        #endregion

        #region Constructor
        public AddonInfoInfo()
        {
        }
        #endregion

        #region Methods
        //public static bool InstallUDOs()
        //{
        //    try
        //    {
        //        bool UDOAdded = true;

        //        #region System Tables Fields

        //        //B1Helper.DiCompany.StartTransaction();

        //        //B1Helper.AddField("AllowedForSelfAssign", "Allowed For Self Assign", "OSCP", SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");

        //        //B1Helper.AddField("SalesQuoteWhse", "Default Whse - Sales Quote", "OADM", SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        //// Business Partner Fields
        //        //B1Helper.AddField(FieldNames.BP_Location, FieldNames.BP_Location, TableNames.T_OCRD, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        //// Sales Order Line Fields
        //        //B1Helper.AddField(FieldNames.D_ServiceCallNo, FieldNames.D_ServiceCallNo, TableNames.T_RDR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.D_ServiceCallFlag, FieldNames.D_ServiceCallFlag, TableNames.T_RDR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.D_IsCovered, FieldNames.D_IsCovered, TableNames.T_RDR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");

        //        //// Invoice & Invoice Line Fields
        //        //B1Helper.AddField(FieldNames.I_ContractID, FieldNames.I_ContractID, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 15, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.I_ContractID, FieldNames.I_ContractID, TableNames.T_OINV, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.I_InvoiceType, FieldNames.I_InvoiceType, TableNames.T_OINV, SAPbobsCOM.BoFieldTypes.db_Alpha, 2, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "B", "B,Fixed Billing", "E,Excess Billing", "C,Fixed and Excess", "S,SMA", "M,Service Billing", "L,Lease Billing");
        //        //B1Helper.AddField(FieldNames.I_InvoiceType, FieldNames.I_InvoiceType, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 2, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "B", "B,Fixed Billing", "E,Excess Billing", "C,Fixed and Excess", "S,SMA", "M,Service Billing", "L,Lease Billing");
        //        //B1Helper.AddField(FieldNames.I_FromDate, FieldNames.I_FromDate, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.I_ToDate, FieldNames.I_ToDate, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, false);

        //        ////  B1Helper.AddField(FieldNames.I_Lastbilledmeter, FieldNames.I_Lastbilledmeter, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        ////  B1Helper.AddField(FieldNames.I_Currentmeter, FieldNames.I_Currentmeter, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);

        //        //B1Helper.AddField(FieldNames.I_PoolCode, FieldNames.I_PoolCode, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 15, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.I_UsedMeter, FieldNames.I_UsedMeter, TableNames.T_INV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 15, SAPbobsCOM.BoYesNoEnum.tNO, false);

        //        //// Employee Master Data
        //        //B1Helper.AddField(FieldNames.EP_WebUserName, FieldNames.EP_WebUserName, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.EP_WebPassword, FieldNames.EP_WebPassword, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.EP_Confirmed, FieldNames.EP_Confirmed, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.EP_UserType, FieldNames.EP_UserType, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "", "E,Employee", "T,Technician", "C,Call Center");
        //        //B1Helper.AddField(FieldNames.EP_Location, FieldNames.EP_Location, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.EP_LoclastUpdateTime, FieldNames.EP_LoclastUpdateTime, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Memo, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.O_DebitAccount, FieldNames.O_DebitAccount, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.O_CreditAccount, FieldNames.O_CreditAccount, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.O_Normalrate, FieldNames.O_Normalrate, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, false);
        //        //B1Helper.AddField(FieldNames.O_Overtimerate, FieldNames.O_Overtimerate, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, false);
        //        //B1Helper.AddField(FieldNames.O_Travelrate, FieldNames.O_Travelrate, TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, false);
        //        //B1Helper.AddField(FieldNames.O_TDebitAccount, "Travel Debit Account", TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.O_TCreditAccount, "Travel Credit Account", TableNames.T_OHEM, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, false);

        //        ////USER
        //        //B1Helper.AddField(FieldNames.O_Recall, FieldNames.O_Recall, TableNames.T_OUSR, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //// OADM
        //        //B1Helper.AddField(FieldNames.OADM_NotificationEmail, "Notification Email Setup", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.OADM_ActivityEmail, "Activity Email Setup", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.OADM_ServiceEmail, "Service Email Setup", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.OADM_JournalEmail, "Juornal Calculation Setup", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.OADM_CompanyLogo1, "Compnay Logo 1", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Image, false);
        //        //B1Helper.AddField(FieldNames.OADM_CompanyLogo2, "Compnay Logo 2", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Image, false);
        //        //B1Helper.AddField(FieldNames.OADM_CompanyLogo3, "Compnay Logo 3", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Image, false);
        //        //B1Helper.AddField(FieldNames.OADM_ExcessDay, "Excess Day", TableNames.T_OADM, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, false);
        //        //// Inventory Transfer
        //        //B1Helper.AddField(FieldNames.IT_Notification, FieldNames.IT_Notification, TableNames.T_OWTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.IT_Email, FieldNames.IT_Email, TableNames.T_OWTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        //// Activity
        //        //B1Helper.AddField(FieldNames.IT_Notification, FieldNames.IT_Notification, TableNames.T_OCLG, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.IT_Email, FieldNames.IT_Email, TableNames.T_OCLG, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);


        //        //// Equipment Card Fields
        //        //B1Helper.AddField(FieldNames.EC_PDIDate, FieldNames.EC_PDIDate, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_Endoflife, FieldNames.EC_Endoflife, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_Latitude, FieldNames.EC_Latitude, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_Longitude, FieldNames.EC_Longitude, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_RecallDays, FieldNames.EC_RecallDays, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_InstallationDate, FieldNames.EC_InstallationDate, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_MeterReadHistory, FieldNames.EC_MeterReadHistory, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.EC_MonEndTime, FieldNames.EC_MonEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_TueEndTime, FieldNames.EC_TueEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_WedEndTime, FieldNames.EC_WedEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_ThuEndTime, FieldNames.EC_ThuEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_FriEndTime, FieldNames.EC_FriEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SatEndTime, FieldNames.EC_SatEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SunEndTime, FieldNames.EC_SunEndTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_MonEndTimeOS, FieldNames.EC_MonEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_TueEndTimeOS, FieldNames.EC_TueEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_WedEndTimeOS, FieldNames.EC_WedEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_ThuEndTimeOS, FieldNames.EC_ThuEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_FriEndTimeOS, FieldNames.EC_FriEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SatEndTimeOS, FieldNames.EC_SatEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SunEndTimeOS, FieldNames.EC_SunEndTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);

        //        //B1Helper.AddField(FieldNames.EC_PACINumber, FieldNames.EC_PACINumber, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.EC_ResponseTime, FieldNames.EC_ResponseTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_MonStartTime, FieldNames.EC_MonStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_TueStartTime, FieldNames.EC_TueStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_WedStartTime, FieldNames.EC_WedStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_ThuStartTime, FieldNames.EC_ThuStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_FriStartTime, FieldNames.EC_FriStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SatStartTime, FieldNames.EC_SatStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SunStartTime, FieldNames.EC_SunStartTime, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);

        //        //B1Helper.AddField(FieldNames.EC_MonStartTimeOS, FieldNames.EC_MonStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_TueStartTimeOS, FieldNames.EC_TueStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_WedStartTimeOS, FieldNames.EC_WedStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_ThuStartTimeOS, FieldNames.EC_ThuStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_FriStartTimeOS, FieldNames.EC_FriStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SatStartTimeOS, FieldNames.EC_SatStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_SunStartTimeOS, FieldNames.EC_SunStartTimeOS, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);


        //        //B1Helper.AddField(FieldNames.EC_CustomerWrkHrs, FieldNames.EC_CustomerWrkHrs, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.EC_MonWDay, FieldNames.EC_MonWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_TueWDay, FieldNames.EC_TueWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_WedWDay, FieldNames.EC_WedWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_ThurWDay, FieldNames.EC_ThurWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_FriWDay, FieldNames.EC_FriWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_SatWDay, FieldNames.EC_SatWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_SunWDay, FieldNames.EC_SunWDay, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "Y", "Y,Y", "N,N");
        //        //B1Helper.AddField(FieldNames.EC_GatePassRequired, FieldNames.EC_GatePassRequired, TableNames.T_OINS, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Y", "N,N");

        //        //////// Service Call Table Fields
        //        //B1Helper.AddField(FieldNames.SC_PoolID, FieldNames.SC_PoolID, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.SC_PoolCode, FieldNames.SC_PoolCode, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.SC_RealTimeTimer, FieldNames.SC_RealTimeTimer, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.SC_CustomerWorkingHrs, FieldNames.SC_CustomerWorkingHrs, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.SC_Recall, FieldNames.SC_Recall, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.SC_JEN, FieldNames.SC_JEN, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.SC_JET, FieldNames.SC_JET, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //B1Helper.AddField(FieldNames.A_respByTime, FieldNames.A_respByTime, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.A_respByDate, FieldNames.A_respByDate, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        //B1Helper.AddField(FieldNames.SC_RONTime, FieldNames.SC_RONTime, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.SC_RONDate, FieldNames.SC_RONDate, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.SC_ResTime, FieldNames.SC_ResTime, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);

        //        //B1Helper.AddField(FieldNames.IT_Notification, FieldNames.IT_Notification, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.IT_Email, FieldNames.IT_Email, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);


        //        ////B1Helper.AddField(FieldNames.SC_PoolCode, FieldNames.SC_PoolCode, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        //// B1Helper.AddField(FieldNames.SC_PoolCode, FieldNames.SC_PoolCode, TableNames.T_OSCL, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, false);
        //        ////Activity

        //        //B1Helper.AddField(FieldNames.A_respByTime, FieldNames.A_respByTime, TableNames.T_OCGL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, false);
        //        //B1Helper.AddField(FieldNames.A_respByDate, FieldNames.A_respByDate, TableNames.T_OCGL, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        //// Service Contract Fields
        //        //B1Helper.AddField(FieldNames.SH_PoolSize, FieldNames.SH_PoolSize, TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.SH_ContractType, FieldNames.SH_ContractType, TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.SH_IsPoolContract, FieldNames.SH_IsPoolContract, TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.SH_ContractCoverage, FieldNames.SH_ContractCoverage, TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "C", "C,Contract Level", "M,Machine Level");
        //        //B1Helper.AddField(FieldNames.SH_PriceType, FieldNames.SH_PriceType, TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "S", "S,Standard", "P,Pool Price and Slab", "F,Fixed Price", "M,Service Billing", "W,Warranty");

        //        //B1Helper.AddField("Auth1", "Auth1", TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField("Auth2", "Auth2", TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField("Auth3", "Auth3", TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField("Auth4", "Auth4", TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField("Auth5", "Auth5", TableNames.T_OCTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        ////Service Contract Item Fields
        //        //B1Helper.AddField(FieldNames.SI_Source, FieldNames.SI_Source, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, ".", ".,");
        //        //B1Helper.AddField(FieldNames.SI_AMCV, FieldNames.SI_AMCV, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Numeric, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Quantity, false);
        //        //B1Helper.AddField(FieldNames.SI_RMCV, FieldNames.SI_RMCV, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Numeric, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Quantity, false);
        //        //B1Helper.AddField(FieldNames.SI_ServiceAmount, FieldNames.SI_ServiceAmount, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, false);
        //        //B1Helper.AddField(FieldNames.SI_ApplyCoverage, FieldNames.SI_ApplyCoverage, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 30, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "", "A,Apply Coverage");
        //        //B1Helper.AddField(FieldNames.SI_PoolCode, FieldNames.SI_PoolCode, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false, "0", "0,");
        //        //B1Helper.AddField(FieldNames.SI_Termination, FieldNames.SI_Termination, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 5, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);
        //        //B1Helper.AddField(FieldNames.MP_ModelNumber, FieldNames.MP_ModelNumber, TableNames.T_CTR1, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, false);

        //        // Utility.LogException("Ending Transaction: System Tables Fields");
        //        B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        #endregion

        //        //#region User Defined Tables
        //        //B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: User Defined Tables");

        //        //// Service Call Meter Readings Tables
        //        //B1Helper.AddTable(TableNames.Z_OSCM, TableNames.Z_OSCM, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_SCM1, TableNames.Z_SCM1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Service Call Installations 
        //        //B1Helper.AddTable(TableNames.Z_OINSS, TableNames.Z_OINSS, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_INSS1, TableNames.Z_INSS1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Equipment Card Master and  Child Tables
        //        //B1Helper.AddTable(TableNames.Z_OECC, TableNames.Z_OECC, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_ECM1, TableNames.Z_ECM1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);
        //        //B1Helper.AddTable(TableNames.Z_ECD2, TableNames.Z_ECD2, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);
        //        //B1Helper.AddTable(TableNames.Z_ECH3, TableNames.Z_ECH3, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //B1Helper.AddTable(TableNames.Z_ECMD, TableNames.Z_ECMD, SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);
        //        //B1Helper.AddTable(TableNames.Z_PLDT, TableNames.Z_PLDT, SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);
        //        //// Approval Stage

        //        //B1Helper.AddTable(TableNames.Z_OAPS, TableNames.Z_OAPS, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_APS1, TableNames.Z_APS1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);


        //        //// Service Contract Billing Tables
        //        //B1Helper.AddTable(TableNames.Z_OSRB, TableNames.Z_OSRB, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_SRB1, TableNames.Z_SRB1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //B1Helper.AddTable(TableNames.Z_OSRM, TableNames.Z_OSRM, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_SRM1, TableNames.Z_SRM1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);
        //        //B1Helper.AddTable(TableNames.Z_OSRP, TableNames.Z_OSRP, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_SRP1, TableNames.Z_SRP1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Service Contract Scheduler Tables
        //        //B1Helper.AddTable(TableNames.Z_OCSC, TableNames.Z_OCSC, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_CSC1, TableNames.Z_CSC1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Machine Pricing Master Tables
        //        //B1Helper.AddTable(TableNames.Z_MPRM, TableNames.Z_MPRM, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_MPM1, TableNames.Z_MPM1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Technical Skill Master Tables
        //        //B1Helper.AddTable(TableNames.Z_OTSM, TableNames.Z_OTSM, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_TSM1, TableNames.Z_TSM1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Meter Setup Master Table and Fields
        //        //B1Helper.AddTable(TableNames.Z_OMTR, TableNames.Z_OMTR, SAPbobsCOM.BoUTBTableType.bott_MasterData);

        //        //// Coverages Master table
        //        //B1Helper.AddTable(TableNames.Z_OCVM, TableNames.Z_OCVM, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_CVM1, TableNames.Z_CVM1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Contract Coverage Table 
        //        //B1Helper.AddTable(TableNames.Z_OCCV, TableNames.Z_OCCV, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_CCV1, TableNames.Z_CCV1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //// Lease Contract Table
        //        //B1Helper.AddTable(TableNames.Z_OLCM, TableNames.Z_OLCM, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_LCIT, TableNames.Z_LCIT, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);
        //        //B1Helper.AddTable(TableNames.Z_LCDD, TableNames.Z_LCDD, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //B1Helper.AddTable(TableNames.Z_LCLB, TableNames.Z_LCLB, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //B1Helper.AddTable(TableNames.Z_SCHEDULER, TableNames.Z_SCHEDULER, SAPbobsCOM.BoUTBTableType.bott_NoObject);
        //        ////Service GL
        //        //B1Helper.AddTable(TableNames.Z_SCGL, TableNames.Z_SCGL, SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);

        //        //// Recurring Schedule Table
        //        //B1Helper.AddTable(TableNames.Z_ORSS, TableNames.Z_ORSS, SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_RSS1, TableNames.Z_RSS1, SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);

        //        //B1Helper.AddTable(TableNames.Z_InstChecklist, "Installation Checklist", SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);
        //        //B1Helper.AddTable(TableNames.Z_PDIChecklist, "PDI Checklist - Setup", SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);
        //        //B1Helper.AddTable(TableNames.Z_PDIInspection, TableNames.Z_PDIInspection, SAPbobsCOM.BoUTBTableType.bott_Document);
        //        //B1Helper.AddTable(TableNames.Z_PDIInsChecklist, TableNames.Z_PDIInsChecklist, SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
        //        //B1Helper.AddTable(TableNames.Z_PDIInsMeterReading, TableNames.Z_PDIInsMeterReading, SAPbobsCOM.BoUTBTableType.bott_DocumentLines);

        //        //B1Helper.AddTable(TableNames.Z_Model, "Model Master", SAPbobsCOM.BoUTBTableType.bott_MasterData);
        //        //B1Helper.AddTable(TableNames.Z_RelatedItem, "Related Item", SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);
        //        //B1Helper.AddTable(TableNames.Z_MeterSetup, "Meter Setup", SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);
        //        //B1Helper.AddTable(TableNames.Z_Price, "Price Setup", SAPbobsCOM.BoUTBTableType.bott_MasterDataLines);


        //        //// Notifications table
        //        //B1Helper.AddTable(TableNames.Z_NOTIF, TableNames.Z_NOTIF, SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);

        //        //// Utility.LogException("Ending Transaction: User Defined Tables");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Service Call Meter Readings Fields
        //        //B1Helper.DiCompany.StartTransaction();
        //        ////  Utility.LogException("Starting Transaction: Service Call Meter Readings Fields");

        //        //// Service Call Meter Readings Fields
        //        //B1Helper.AddField(FieldNames.SC_SerCallDocNum, FieldNames.SC_SerCallDocNum, TableNames.Z_OSCM, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, true);

        //        //B1Helper.AddField(FieldNames.SC_MeterCode, FieldNames.SC_MeterCode, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.SC_Description, FieldNames.SC_Description, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.SC_LastReading, FieldNames.SC_LastReading, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_LastReadingDate, FieldNames.EM_LastReadingDate, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_CurrentReading, FieldNames.SC_CurrentReading, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_ItemCode, FieldNames.SC_ItemCode, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.SC_ItemName, FieldNames.SC_ItemName, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.SC_ManuFSN, FieldNames.SC_ManuFSN, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.SC_InternalSN, FieldNames.SC_InternalSN, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_MeterReset, FieldNames.SC_MeterReset, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.SC_ContractNo, FieldNames.SC_ContractNo, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_Billed, FieldNames.SC_Billed, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.SC_A3MeterReading, FieldNames.SC_A3MeterReading, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_CountedA3inA4, FieldNames.EM_CountedA3inA4, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_DocEntry, FieldNames.SC_DocEntry, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_DocType, FieldNames.SC_DocType, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 30, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_PoolCode, FieldNames.SC_PoolCode, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_Attachment, FieldNames.SC_Attachment, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 250, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_Line, FieldNames.SC_Line, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_CodeT, FieldNames.EM_CodeT, TableNames.Z_SCM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        ////  Utility.LogException("Ending Transaction: Service Call Meter Readings Fields");

        //        //B1Helper.AddField(FieldNames.SC_DocEntry, "Service Call", TableNames.Z_OINSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.PDI_CheckListItem, "Checklist item", TableNames.Z_INSS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Active, "Active", TableNames.Z_INSS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);


        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Equipment Card UDTs Fields
        //        //B1Helper.DiCompany.StartTransaction();
        //        ////  Utility.LogException("Starting Transaction: Equipment Card UDF Header & Childs for (Meter, Component & Consumption)");

        //        //// Equipment Card UDF Header and childs for (Meter, component and consumption)
        //        //B1Helper.AddField(FieldNames.EM_InsNo, FieldNames.EM_InsNo, TableNames.Z_OECC, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, true);

        //        //B1Helper.AddField(FieldNames.EM_MeterCode, FieldNames.EM_MeterCode, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_MeterName, FieldNames.EM_MeterName, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_ItemMeterCode, FieldNames.EM_ItemMeterCode, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_PrintType, FieldNames.EM_PrintType, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_PaperType, FieldNames.EM_PaperType, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_BasePrice, FieldNames.EM_BasePrice, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.EM_ExcessPrice, FieldNames.EM_ExcessPrice, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.EM_CountedA3inA4, FieldNames.EM_CountedA3inA4, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.EM_LastReading, FieldNames.EM_LastReading, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_LastReadingDate, FieldNames.EM_LastReadingDate, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_SerialNo, FieldNames.EM_SerialNo, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_Line, FieldNames.EM_Line, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_CodeT, FieldNames.EM_Line, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EM_Model, FieldNames.EM_Model, TableNames.Z_ECM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);


        //        //// Equipment Card - Cmponent Details
        //        //B1Helper.AddField(FieldNames.EC_ProductCode, FieldNames.EC_ProductCode, TableNames.Z_ECD2, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EC_ProductName, FieldNames.EC_ProductName, TableNames.Z_ECD2, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EC_Active, FieldNames.EC_Active, TableNames.Z_ECD2, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, true);

        //        ///////Equipment Card - Consumption History Details
        //        //B1Helper.AddField(FieldNames.EH_ProductCode, FieldNames.EH_ProductCode, TableNames.Z_ECH3, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EH_ProductName, FieldNames.EH_ProductName, TableNames.Z_ECH3, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EH_Yield, FieldNames.EH_Yield, TableNames.Z_ECH3, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EH_Type, FieldNames.EH_Type, TableNames.Z_ECH3, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EH_Active, FieldNames.EH_Active, TableNames.Z_ECH3, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.EH_YieldN, FieldNames.EH_YieldN, TableNames.Z_ECH3, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //// Equipment Card - Machine Details
        //        //B1Helper.AddField(FieldNames.MD_BillDate, FieldNames.MD_BillDate, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_DocNum, FieldNames.MD_DocNum, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_MeterCode, FieldNames.MD_MeterCode, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_MeterName, FieldNames.MD_MeterName, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_ItemCode, FieldNames.MD_ItemCode, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_SerialNum, FieldNames.MD_SerialNum, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_PoolCode, FieldNames.MD_PoolCode, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_StartMeterReading, FieldNames.MD_StartMeterReading, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_LastMeterReading, FieldNames.MD_LastMeterReading, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_CurntMeterReading, FieldNames.MD_CurntMeterReading, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_RLastMeterReading, FieldNames.MD_RLastMeterReading, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_RCurntMeterReading, FieldNames.MD_RCurntMeterReading, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.MD_Billed, FieldNames.MD_Billed, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.MD_Reset, FieldNames.MD_Reset, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "N", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.EM_CountedA3inA4, FieldNames.EM_CountedA3inA4, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_EligQuantity, FieldNames.MD_EligQuantity, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Quantity, true);
        //        //B1Helper.AddField(FieldNames.MD_Price, FieldNames.MD_Price, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.MD_ExcessPrice, FieldNames.MD_ExcessPrice, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.MD_DocType, FieldNames.MD_DocType, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 30, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_MeterCde, FieldNames.MD_MeterCde, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MD_LastReading, FieldNames.MD_LastReading, TableNames.Z_ECMD, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        ////MD_LastReading
        //        //// Equipment Card - Machine Details
        //        //B1Helper.AddField(FieldNames.PL_BillDate, FieldNames.PL_BillDate, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_DocNo, FieldNames.PL_DocNo, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_DocumentTyp, FieldNames.PL_DocumentTyp, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Alpha, 30, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_DocEntry, FieldNames.PL_DocEntry, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_PoolCode, FieldNames.PL_PoolCode, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_StartMeter, FieldNames.PL_StartMeter, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_EndMeter, FieldNames.PL_EndMeter, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_Used, FieldNames.PL_Used, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_FreeCopied, FieldNames.PL_FreeCopied, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_Excess, FieldNames.PL_Excess, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_BillingPrice, FieldNames.PL_BillingPrice, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.PL_ExcessPrice, FieldNames.PL_ExcessPrice, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.PL_Total, FieldNames.PL_Total, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.PL_IsBilled, FieldNames.PL_IsBilled, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PL_MeterConsider, FieldNames.PL_MeterConsider, TableNames.Z_PLDT, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////  Utility.LogException("Ending Transaction: Equipment Card UDF Header & Childs for (Meter, Component & Consumption)");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Service Contract UDTs Fields
        //        //B1Helper.DiCompany.StartTransaction();
        //        ////  Utility.LogException("Starting Transaction: Service Contract Pricing, Meter, & Schedule Tables Fields");

        //        //B1Helper.AddField(FieldNames.SB_ContractNo, FieldNames.SB_ContractNo, TableNames.Z_OSRM, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SB_ContractNo, FieldNames.SB_ContractNo, TableNames.Z_OSRP, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SB_IsFixedPrice, FieldNames.SB_IsFixedPrice, TableNames.Z_OSRP, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "N", "Y,Yes", "N,No");

        //        //B1Helper.AddField(FieldNames.SH_PoolCode, FieldNames.SH_PoolCode, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_MeterCode, FieldNames.SH_MeterCode, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_MeterName, FieldNames.SH_MeterName, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SI_StartMtrReading, FieldNames.SI_StartMtrReading, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Measurement, true);
        //        //B1Helper.AddField(FieldNames.SH_ItemCode, FieldNames.SH_ItemCode, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_Serial, FieldNames.SH_Serial, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_MItemCode, FieldNames.SH_MItemCode, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_Flag, FieldNames.SH_Flag, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 3, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_FixedPrice, FieldNames.SH_FixedPrice, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SH_Interval, FieldNames.SH_Interval, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_SKIP, FieldNames.SH_SKIP, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 3, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_Line, FieldNames.EM_Line, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 3, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_CodeT, FieldNames.EM_CodeT, TableNames.Z_SRM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 3, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);


        //        //B1Helper.AddField(FieldNames.SP_PoolCode, FieldNames.SP_PoolCode, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SP_EligQuantity, FieldNames.SP_EligQuantity, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Quantity, true);
        //        //B1Helper.AddField(FieldNames.SP_Price, FieldNames.SP_Price, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SP_ExcessPrice, FieldNames.SP_ExcessPrice, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SP_ItemCode, FieldNames.SP_ItemCode, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SH_MItemCode, FieldNames.SH_MItemCode, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SP_FPrice, FieldNames.SP_FPrice, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SP_TPrice, FieldNames.SP_TPrice, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SH_MeterCode, FieldNames.SH_MeterCode, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_Line, FieldNames.EM_Line, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 3, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.EM_CodeT, FieldNames.EM_CodeT, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 3, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MP_ModelNumber, FieldNames.MP_ModelNumber, TableNames.Z_SRP1, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //// Service Contract - Schedule Fields
        //        //B1Helper.AddField(FieldNames.SC_ContractNo, FieldNames.SC_ContractNo, TableNames.Z_OCSC, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.SC_ScheduleType, FieldNames.SC_ScheduleType, TableNames.Z_CSC1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_Frequency, FieldNames.SC_Frequency, TableNames.Z_CSC1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "D", "D,Daily", "M,Monthly", "Q,Quaterly", "S,Semi-Annual", "A,Annual");
        //        //B1Helper.AddField(FieldNames.SC_Interval, FieldNames.SC_Interval, TableNames.Z_CSC1, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_Day, FieldNames.SC_Day, TableNames.Z_CSC1, SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_Posted, FieldNames.SC_Posted, TableNames.Z_CSC1, SAPbobsCOM.BoFieldTypes.db_Alpha, 2, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////  Utility.LogException("Ending Transaction: Service Contract Pricing, Meter, & Schedule Tables Fields");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Billing & Machine Pricing Fields
        //        //B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: Billing & Machine Pricing Fields");

        //        ////Billing Fields
        //        //B1Helper.AddField(FieldNames.SB_ContractNo, FieldNames.SB_ContractNo, TableNames.Z_OSRB, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.SB_BillingType, FieldNames.SB_BillingType, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, " ", " ", "B,Fixed Billing", "E,Excess Billing");
        //        //B1Helper.AddField(FieldNames.SB_BillingProcessType, FieldNames.SB_BillingProcessType, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "A", "A,Advance Billing", "C,Credit Billing");
        //        //B1Helper.AddField(FieldNames.SB_BillingCycle, FieldNames.SB_BillingCycle, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "1", "12,Monthly", "4,Quaterly", "2,Semi-Annual", "1,Yearly");
        //        //B1Helper.AddField(FieldNames.SB_BillStartDate, FieldNames.SB_BillStartDate, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SB_LastBilledDate, FieldNames.SB_LastBilledDate, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SB_NextBilledDate, FieldNames.SB_NextBilledDate, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SB_FixedPrice, FieldNames.SB_FixedPrice, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SB_FixedItem, FieldNames.SB_FixedItem, TableNames.Z_SRB1, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //// Machine Pricing Master Fields
        //        //B1Helper.AddField(FieldNames.MP_ModelNumber, FieldNames.MP_ModelNumber, TableNames.Z_MPRM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tYES, true);
        //        //B1Helper.AddField(FieldNames.MP_ModelName, FieldNames.MP_ModelName, TableNames.Z_MPRM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tYES, true);

        //        //// Machine Pricing Master Row Fields
        //        //B1Helper.AddField(FieldNames.MP_ProductCategory, FieldNames.MP_ProductCategory, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.MP_MeterCode, FieldNames.MP_MeterCode, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, true);
        //        //B1Helper.AddField(FieldNames.MP_PaperSize, FieldNames.MP_PaperSize, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "A4", "A4,A4", "A3,A3");
        //        //B1Helper.AddField(FieldNames.MP_Color, FieldNames.MP_Color, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "BW", "BW,Black & White", "CL,Color");
        //        //B1Helper.AddField(FieldNames.MP_StartRange, FieldNames.MP_StartRange, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.MP_ToRange, FieldNames.MP_ToRange, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.MP_BasePrice, FieldNames.MP_BasePrice, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.MP_ExcessPrice, FieldNames.MP_ExcessPrice, TableNames.Z_MPM1, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_Price, true);

        //        //// Utility.LogException("Ending Transaction: Billing & Machine Pricing Fields");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Technical Skills & Coverage Fields
        //        //B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: Technical Skills & Coverage Fields");

        //        //// Technical Skill Master Fields
        //        //B1Helper.AddField(FieldNames.TS_ModelNumber, FieldNames.TS_ModelNumber, TableNames.Z_OTSM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tYES, true);
        //        //B1Helper.AddField(FieldNames.TS_ModelName, FieldNames.TS_ModelName, TableNames.Z_OTSM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tYES, true);

        //        //// Technical Skill Master Fields
        //        //B1Helper.AddField(FieldNames.TS_TechnicianCode, FieldNames.TS_TechnicianCode, TableNames.Z_TSM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 20, SAPbobsCOM.BoYesNoEnum.tYES, true);
        //        //B1Helper.AddField(FieldNames.TS_TechnicianName, FieldNames.TS_TechnicianName, TableNames.Z_TSM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tYES, true);

        //        //B1Helper.AddField(FieldNames.ItemCode, FieldNames.ItemCode, TableNames.Z_OMTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tYES, true);
        //        //B1Helper.AddField(FieldNames.ItemName, FieldNames.ItemName, TableNames.Z_OMTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tYES, true);
        //        //B1Helper.AddField(FieldNames.Status, FieldNames.Status, TableNames.Z_OMTR, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "N");

        //        ////Coverage Master Fileds
        //        //B1Helper.AddField(FieldNames.CV_Remarks, FieldNames.CV_Remarks, TableNames.Z_OCVM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.CV_Active, FieldNames.CV_Active, TableNames.Z_OCVM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.CV_CoverageDate, FieldNames.CV_CoverageDate, TableNames.Z_OCVM, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////Coverage DocuasterMment Line Fields
        //        //B1Helper.AddField(FieldNames.CV_ItemGrpCode, FieldNames.CV_ItemGrpCode, TableNames.Z_CVM1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////Contract Coverage Master Fields 
        //        //B1Helper.AddField(FieldNames.CC_ContractNo, FieldNames.CC_ContractNo, TableNames.Z_OCCV, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.CC_ItemCode, FieldNames.CC_ItemCode, TableNames.Z_OCCV, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.CC_CoverageCode, FieldNames.CC_CoverageCode, TableNames.Z_OCCV, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.CC_CoverageName, FieldNames.CC_CoverageName, TableNames.Z_OCCV, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.CC_Serial, FieldNames.CC_Serial, TableNames.Z_OCCV, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////Coverage Coverage Line Fields
        //        //B1Helper.AddField(FieldNames.CC_ItemGroupCode, FieldNames.CC_ItemGroupCode, TableNames.Z_CCV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.CC_Active, FieldNames.CC_Active, TableNames.Z_CCV1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");

        //        ////  Utility.LogException("Ending Transaction: Technical Skills & Coverage Fields");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Leasing Contract Fields
        //        //B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: Leasing Contract Fields");

        //        //B1Helper.AddField(FieldNames.LC_CustomerCode, FieldNames.LC_CustomerCode, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_CustomerName, FieldNames.LC_CustomerName, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_ContctCode, FieldNames.LC_ContctCode, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_StartDate, FieldNames.LC_StartDate, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_EndDate, FieldNames.LC_EndDate, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_Status, FieldNames.LC_Status, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LC_ContractType, FieldNames.LC_ContractType, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "F,Finance Leasing", "O,Operating Lease");
        //        ////B1Helper.AddField(FieldNames.LC_BillingCycle, FieldNames.LC_BillingCycle, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "M,Monthly", "Q,Quaterly", "H,Half-Yearly", "Y,Yearly");
        //        //B1Helper.AddField(FieldNames.LC_BillingCycle, FieldNames.LC_BillingCycle, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "M,Monthly", "Q,Quaterly");
        //        //B1Helper.AddField(FieldNames.LC_SODocNo, FieldNames.LC_SODocNo, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_ContractValue, FieldNames.LC_ContractValue, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LC_ContractNo, FieldNames.LC_ContractNo, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_BillingDay, FieldNames.LC_BillingDay, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 2, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_BillInterval, FieldNames.LC_BillInterval, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_BillStartDate, FieldNames.LC_BillStartDate, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);


        //        //B1Helper.AddField(FieldNames.LC_InterestRate, FieldNames.LC_InterestRate, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Rate, true);
        //        //B1Helper.AddField(FieldNames.LC_RevRecogAcct, FieldNames.LC_RevRecogAcct, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_RevenueAcct, FieldNames.LC_RevenueAcct, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_InterestAcct, FieldNames.LC_InterestAcct, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_DiffIntAcct, FieldNames.LC_DiffIntAcct, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LC_MonthlyValue, FieldNames.LC_MonthlyValue, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LC_PaymentTerms, FieldNames.LC_PaymentTerms, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_ServiceTotal, FieldNames.LC_ServiceTotal, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LC_ItemCode, FieldNames.LC_ItemCode, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_ItemDesc, FieldNames.LC_ItemDesc, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_ItemCodeLR, FieldNames.LC_ItemCodeLR, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_ItemDescLR, FieldNames.LC_ItemDescLR, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LC_InterestAmt, FieldNames.LC_InterestAmt, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LC_LoanAmt, FieldNames.LC_LoanAmt, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LC_Termdate, FieldNames.LC_Termdate, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_DocEntry, FieldNames.LC_DocEntry, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_JENumber, FieldNames.LC_JENumber, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_JEDate, FieldNames.LC_JEDate, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LC_Remarks, FieldNames.LC_Remarks, TableNames.Z_OLCM, SAPbobsCOM.BoFieldTypes.db_Alpha, 150, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LI_ItemCode, FieldNames.LI_ItemCode, TableNames.Z_LCIT, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LI_ItemDesc, FieldNames.LI_ItemDesc, TableNames.Z_LCIT, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LI_Quantity, FieldNames.LI_Quantity, TableNames.Z_LCIT, SAPbobsCOM.BoFieldTypes.db_Float, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Quantity, true);
        //        //B1Helper.AddField(FieldNames.LI_SerialNo, FieldNames.LI_SerialNo, TableNames.Z_LCIT, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LD_DocumentTyp, FieldNames.LD_DocumentTyp, TableNames.Z_LCDD, SAPbobsCOM.BoFieldTypes.db_Alpha, 2, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LD_DocNo, FieldNames.LD_DocNo, TableNames.Z_LCDD, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LD_DocDate, FieldNames.LD_DocDate, TableNames.Z_LCDD, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LD_DocStatus, FieldNames.LD_DocStatus, TableNames.Z_LCDD, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LB_Interval, FieldNames.LB_Interval, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LB_LBDate, FieldNames.LB_LBDate, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LB_LeaseBilling, FieldNames.LB_LeaseBilling, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LB_Status, FieldNames.LB_Status, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LB_InvoiceNo, FieldNames.LB_InvoiceNo, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.LB_Posted, FieldNames.LB_Posted, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.LB_Balance, FieldNames.LB_Balance, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LB_Principal, FieldNames.LB_Principal, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.LB_Interest, FieldNames.LB_Interest, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);

        //        //B1Helper.AddField(FieldNames.LB_IStatus, FieldNames.LB_IStatus, TableNames.Z_LCLB, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);



        //        //B1Helper.AddField(FieldNames.SC_CallSource, FieldNames.SC_CallSource, TableNames.Z_SCHEDULER, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_ProbSubType, FieldNames.SC_ProbSubType, TableNames.Z_SCHEDULER, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_ActivityChannel, FieldNames.SC_ActivityChannel, TableNames.Z_SCHEDULER, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_CallType, FieldNames.SC_CallType, TableNames.Z_SCHEDULER, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////Service GL Acc
        //        //B1Helper.AddField(FieldNames.SC_Account, FieldNames.SC_Account, TableNames.Z_SCGL, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.SC_BillProcees, FieldNames.SC_BillProcees, TableNames.Z_SCGL, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        ////Recurring Schedule Field
        //        //B1Helper.AddField(FieldNames.RS_StartDate, FieldNames.RS_StartDate, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_EndDate, FieldNames.RS_EndDate, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_ContractNo, FieldNames.RS_ContractNo, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_BillProcess, FieldNames.RS_BillProcess, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_BillValue, FieldNames.RS_BillValue, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.RS_BillTerms, FieldNames.RS_BillTerms, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_DayValue, FieldNames.RS_DayValue, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.RS_MonthValue, FieldNames.RS_MonthValue, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.RS_DebitAcc, FieldNames.RS_DebitAcc, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_CreditAcc, FieldNames.RS_CreditAcc, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_Customer, FieldNames.RS_Customer, TableNames.Z_ORSS, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.RS_Month, FieldNames.RS_Month, TableNames.Z_RSS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_RAmount, FieldNames.RS_RAmount, TableNames.Z_RSS1, SAPbobsCOM.BoFieldTypes.db_Float, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.RS_RPosted, FieldNames.RS_RPosted, TableNames.Z_RSS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_RStatus, FieldNames.RS_RStatus, TableNames.Z_RSS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        ////B1Helper.AddField(FieldNames.RS_RDate, FieldNames.RS_RDate, TableNames.Z_RSS1, SAPbobsCOM.BoFieldTypes.db_Date, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RS_RYear, FieldNames.RS_RYear, TableNames.Z_RSS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddTable(TableNames.Z_Pool, TableNames.Z_Pool, SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);

        //        //// Utility.LogException("Ending Transaction: Leasing Contract Fields");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region PDI – requirements
        //        //B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: Leasing Contract Fields");
        //        //// PDI


        //        //B1Helper.AddField(FieldNames.PDI_CheckListItem, "Checklist item", TableNames.Z_InstChecklist, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Active, "Active", TableNames.Z_InstChecklist, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.PDI_CheckListItem, "Checklist item", TableNames.Z_PDIChecklist, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Active, "Active", TableNames.Z_PDIChecklist, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");


        //        //B1Helper.AddField(FieldNames.PDI_Model, FieldNames.PDI_Model, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_ModelN, FieldNames.PDI_ModelN, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 200, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_SerialNumber, FieldNames.PDI_SerialNumber, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Status, FieldNames.PDI_Status, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Starttime, FieldNames.PDI_Starttime, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, true);
        //        //B1Helper.AddField(FieldNames.PDI_date, FieldNames.PDI_date, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Endtime, FieldNames.PDI_Endtime, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, true);
        //        //B1Helper.AddField(FieldNames.PDI_Totalduration, FieldNames.PDI_Totalduration, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, true);
        //        //B1Helper.AddField(FieldNames.PDI_Remarks, FieldNames.PDI_Remarks, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_PendingRemarks, FieldNames.PDI_PendingRemarks, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_TotalMeterReading, FieldNames.PDI_TotalMeterReading, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Technician, FieldNames.PDI_Technician, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 200, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_PDISign, FieldNames.PDI_PDISign, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Memo, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Link, true);
        //        //B1Helper.AddField(FieldNames.PDI_TechnicianC, FieldNames.PDI_TechnicianC, TableNames.Z_PDIInspection, SAPbobsCOM.BoFieldTypes.db_Alpha, 30, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.PDI_CheckListItem, "Checklist item", TableNames.Z_PDIInsChecklist, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Active, FieldNames.PDI_Active, TableNames.Z_PDIInsChecklist, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_Meter, FieldNames.PDI_Meter, TableNames.Z_PDIInsMeterReading, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PDI_MeterReading, FieldNames.PDI_MeterReading, TableNames.Z_PDIInsMeterReading, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //// Utility.LogException("Ending Transaction: Leasing Contract Fields");
        //        //B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region MODEL – requirements
        //        //// B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: Leasing Contract Fields");
        //        //// PDI


        //        //B1Helper.AddField(FieldNames.MODEL_ReCallCopy, FieldNames.MODEL_ReCallCopy, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_Recall, FieldNames.MODEL_Recall, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_MxExpAmc, FieldNames.MODEL_MxExpAmc, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_MExAMC, FieldNames.MODEL_MExAMC, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_EOL, FieldNames.MODEL_EOL, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_EOS, FieldNames.MODEL_EOS, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_SOT, FieldNames.MODEL_SOT, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_JbTime, FieldNames.MODEL_JbTime, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Time, true);
        //        //B1Helper.AddField(FieldNames.MODEL_PrdSubCat, FieldNames.MODEL_PrdSubCat, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_BWSpeed, FieldNames.MODEL_BWSpeed, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Alpha, 25, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_ClrSpeed, FieldNames.MODEL_ClrSpeed, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_ResTime, FieldNames.MODEL_ResTime, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_Ctgry, FieldNames.MODEL_Ctgry, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_PlnDays, FieldNames.MODEL_PlnDays, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_PlnCpy, FieldNames.MODEL_PlnCpy, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Numeric, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MODEL_Jbwgt, FieldNames.MODEL_Jbwgt, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Quantity, true);
        //        //B1Helper.AddField(FieldNames.PRICE_SMAPrice, FieldNames.PRICE_SMAPrice, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);

        //        //B1Helper.AddField(FieldNames.MODEL_Type, FieldNames.MODEL_Type, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Alpha, 5, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "NA", "Mon,Mono", "Color,Color", "NA,Not Applicable");
        //        //B1Helper.AddField(FieldNames.MODEL_DflEmail, FieldNames.MODEL_DflEmail, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Alpha, 200, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.MODEL_QuoteLimit, FieldNames.MODEL_QuoteLimit, TableNames.Z_Model, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Rate, true);

        //        //B1Helper.AddField(FieldNames.RITM_ItemCode, FieldNames.RITM_ItemCode, TableNames.Z_RelatedItem, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RITM_PartN, FieldNames.RITM_PartN, TableNames.Z_RelatedItem, SAPbobsCOM.BoFieldTypes.db_Alpha, 150, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RITM_Descp, FieldNames.RITM_Descp, TableNames.Z_RelatedItem, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.RITM_Status, FieldNames.RITM_Status, TableNames.Z_RelatedItem, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");

        //        //B1Helper.AddField(FieldNames.METER_MeterCode, FieldNames.METER_MeterCode, TableNames.Z_MeterSetup, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.METER_MeterName, FieldNames.METER_MeterName, TableNames.Z_MeterSetup, SAPbobsCOM.BoFieldTypes.db_Alpha, 150, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.METER_BillingCode, FieldNames.METER_BillingCode, TableNames.Z_MeterSetup, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.METER_BillingName, FieldNames.METER_BillingName, TableNames.Z_MeterSetup, SAPbobsCOM.BoFieldTypes.db_Alpha, 150, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

        //        //B1Helper.AddField(FieldNames.PRICE_MeterCode, FieldNames.PRICE_MeterCode, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.PRICE_SRange, FieldNames.PRICE_SRange, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.PRICE_TRange, FieldNames.PRICE_TRange, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.SI_PoolCode, FieldNames.SI_PoolCode, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.MP_PaperSize, FieldNames.MP_PaperSize, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "A4", "A4,A4", "A3,A3");
        //        //B1Helper.AddField(FieldNames.MP_Color, FieldNames.MP_Color, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoFldSubTypes.st_None, true, "BW", "BW,Black & White", "CL,Color");
        //        //B1Helper.AddField(FieldNames.MP_BasePrice, FieldNames.MP_BasePrice, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);
        //        //B1Helper.AddField(FieldNames.MP_ExcessPrice, FieldNames.MP_ExcessPrice, TableNames.Z_Price, SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_Price, true);


        //        //// Utility.LogException("Ending Transaction: Leasing Contract Fields");
        //        ////B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //#region Notification
        //        //B1Helper.AddField(FieldNames.NOT_Type, FieldNames.NOT_Type, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_Code, FieldNames.NOT_Code, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_Title, FieldNames.NOT_Title, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_Details, FieldNames.NOT_Details, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_PageUrl, FieldNames.NOT_PageUrl, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 249, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_Sender, FieldNames.NOT_Sender, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_SentTo, FieldNames.NOT_SentTo, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_IsRead, FieldNames.NOT_IsRead, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.NOT_IsDeleted, FieldNames.NOT_IsDeleted, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.NOT_IsReminder, FieldNames.NOT_IsReminder, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true, "", "Y,Yes", "N,No");
        //        //B1Helper.AddField(FieldNames.NOT_CreateDate, FieldNames.NOT_CreateDate, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.NOT_UpdateDate, FieldNames.NOT_UpdateDate, TableNames.Z_NOTIF, SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //#endregion

        //        //#region Approval Stage
        //        //B1Helper.AddField(FieldNames.A_Owner, FieldNames.A_Owner, TableNames.Z_OAPS, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.A_Auth, FieldNames.A_Auth, TableNames.Z_APS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //B1Helper.AddField(FieldNames.A_Code, FieldNames.A_Code, TableNames.Z_APS1, SAPbobsCOM.BoFieldTypes.db_Alpha, 100, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
        //        //#endregion

        //        //#region UDOs
        //        ////  B1Helper.DiCompany.StartTransaction();
        //        //// Utility.LogException("Starting Transaction: UDOs Creation Process");

        //        //var UDPMPRM = B1Helper.CreateUdo(UDONames.UDOMPRM, "Machine Price Master UDO", TableNames.Z_MPRM, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_MPM1);
        //        //UDOAdded = UDOAdded && UDPMPRM;

        //        //var UDOOTSM = B1Helper.CreateUdo(UDONames.UDOTSKM, "Technical Skill Master UDO", TableNames.Z_OTSM, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_TSM1);
        //        //UDOAdded = UDOAdded && UDOOTSM;

        //        //var UDOOMTR = B1Helper.CreateUdo(UDONames.UDOOMTR, "MeterSetup Master UDO", TableNames.Z_OMTR, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>());
        //        //UDOAdded = UDOAdded && UDOOMTR;

        //        //var UDOOSRM = B1Helper.CreateUdo(UDONames.UDOOSRM, "Service Meter UDO", TableNames.Z_OSRM, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_SRM1);
        //        //UDOAdded = UDOAdded && UDOOSRM;

        //        //var UDOSRBI = B1Helper.CreateUdo(UDONames.UDOSRBI, "Service Billing UDO", TableNames.Z_OSRB, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_SRB1);
        //        //UDOAdded = UDOAdded && UDOSRBI;

        //        //var UDOOSRP = B1Helper.CreateUdo(UDONames.UDOOSRP, "Service Pricing UDO", TableNames.Z_OSRP, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_SRP1);
        //        //UDOAdded = UDOAdded && UDOOSRP;

        //        //var UDOOCSC = B1Helper.CreateUdo(UDONames.UDOOCSC, "Contract Schedule UDO", TableNames.Z_OCSC, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_CSC1);
        //        //UDOAdded = UDOAdded && UDOOCSC;

        //        //var UDOOCVD = B1Helper.CreateUdo(UDONames.UDOOCVM, "Coverage Master UDO", TableNames.Z_OCVM, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_CVM1);
        //        //UDOAdded = UDOAdded && UDOOCVD;

        //        //var UDOOCCV = B1Helper.CreateUdo(UDONames.UDOOCCV, "Contract Coverage UDO", TableNames.Z_OCCV, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_CCV1);
        //        //UDOAdded = UDOAdded && UDOOCCV;

        //        //var UDOOLCM = B1Helper.CreateUdo(UDONames.UDOOLCM, "Lease Contract Master UDO", TableNames.Z_OLCM, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_LCIT, TableNames.Z_LCDD, TableNames.Z_LCLB);
        //        //UDOAdded = UDOAdded && UDOOLCM;


        //        //var UDOOECC = B1Helper.CreateUdo(UDONames.UDOOECC, "Equipment Card Child UDO", TableNames.Z_OECC, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_ECM1, TableNames.Z_ECD2, TableNames.Z_ECH3);
        //        //UDOAdded = UDOAdded && UDOOECC;

        //        //var UDOOSCM = B1Helper.CreateUdo(UDONames.UDOOSCM, "Service Call Meter UDO", TableNames.Z_OSCM, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_SCM1);
        //        //UDOAdded = UDOAdded && UDOOSCM;

        //        //var UDOOINSS = B1Helper.CreateUdo(UDONames.UDOOINSS, "Installationr UDO", TableNames.Z_OINSS, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_INSS1);
        //        //UDOAdded = UDOAdded && UDOOINSS;

        //        ////***************Recurring Schedule UDO
        //        //var UDOORSS = B1Helper.CreateUdo(UDONames.UDOORSS, "Recurring Schedule UDO", TableNames.Z_ORSS, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_RSS1);
        //        //UDOAdded = UDOAdded && UDOORSS;

        //        //// PDI

        //        //var UDOOPDI = B1Helper.CreateUdo(UDONames.UDOOPDI, "PDI requirements UDO", TableNames.Z_PDIInspection, SAPbobsCOM.BoUDOObjType.boud_Document, new List<string>(), TableNames.Z_PDIInsChecklist, TableNames.Z_PDIInsMeterReading);
        //        //UDOAdded = UDOAdded && UDOOPDI;

        //        //// MODEL

        //        //var UDOMODEL = B1Helper.CreateUdo(UDONames.UDOMODEL, "MODEL", TableNames.Z_Model, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_RelatedItem, TableNames.Z_MeterSetup, TableNames.Z_Price);
        //        //UDOAdded = UDOAdded && UDOOPDI;

        //        //var UDOAPPS = B1Helper.CreateUdo(UDONames.UDOAPP, "Approval Stage", TableNames.Z_OAPS, SAPbobsCOM.BoUDOObjType.boud_MasterData, new List<string>(), TableNames.Z_APS1);
        //        //UDOAdded = UDOAdded && UDOOPDI;

        //        ////  Utility.LogException("Ending Transaction: UDOs Creation Process");
        //        //// B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
        //        //#endregion

        //        //return UDOAdded;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.LogException(ex);
        //        B1Helper.DiCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
        //        return false;
        //    }
        //}

        public static bool GetCommonSettings()
        {
            string query = "SELECT T0.\"U_A_Email\", T0.\"U_S_Email\", T0.\"U_J_Email\" , \"U_ExcessDay\" , \"U_N_Email\" FROM OADM T0";
            SAPbobsCOM.Recordset rsQry = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsQry.DoQuery(query);
            if (rsQry.RecordCount > 0)
            {
                Globals.SetsAEmail(rsQry.Fields.Item(0).Value.ToString());
                Globals.SetsSEmail(rsQry.Fields.Item(1).Value.ToString());
                Globals.SetsJournal(rsQry.Fields.Item(2).Value.ToString());
                Globals.SetsExcessDay(Convert.ToDouble(rsQry.Fields.Item(3).Value.ToString()));
                Globals.SetsNEmail(rsQry.Fields.Item(4).Value.ToString());
            }

            query = "SELECT T0.\"U_BillProcees\", T0.\"U_Account\" FROM \"@Z_SCGL\"  T0";
            rsQry = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsQry.DoQuery(query);
            if (rsQry.RecordCount > 0)
            {
                while (rsQry.EoF == false)
                {
                    if (rsQry.Fields.Item(0).Value.ToString() == "A")
                    { Globals.SetsSAdvance(rsQry.Fields.Item(1).Value.ToString()); }
                    else if (rsQry.Fields.Item(0).Value.ToString() == "C") { Globals.SetsSCredit(rsQry.Fields.Item(1).Value.ToString()); }
                    rsQry.MoveNext();
                }
            }
            rsQry = null;
            return true;

        }
        public static void SetFormFilter()
        {
            try
            {
                //SAPbouiCOM.EventFilters objFilters = new SAPbouiCOM.EventFilters();
                //SAPbouiCOM.EventFilter objFilter;

                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_FORM_LOAD);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_FORM_CLOSE);
                //objFilter.AddEx("frm_TransferItems");



                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_MENU_CLICK);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED);
                //objFilter.AddEx("frm_TransferItems");



                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_COMBO_SELECT);
                //objFilter.AddEx("frm_TransferItems");

                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_KEY_DOWN);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_LOST_FOCUS);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_VALIDATE);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_FORM_DATA_LOAD);
                //objFilter.AddEx("frm_TransferItems");



                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_CLICK);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_RIGHT_CLICK);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_DOUBLE_CLICK);
                //objFilter.AddEx("frm_TransferItems");

                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_PICKER_CLICKED);
                //objFilter.AddEx("frm_TransferItems");


                //SetFilter(objFilters);
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                // Log.LogException(LogLevel.Error, ex);
            }
        }
        public static void RemoveMenu(string menuId)
        {
            Application.SBO_Application.Menus.RemoveEx(menuId);
        }
        public static string GetNextEntryIndex(string tableName)
        {
            try
            {
                var result = B1Helper.GetNextEntryIndex(tableName);
                if (result.Equals(string.Empty))
                    result = "0";
                else
                    if (result.Equals("0"))
                    {
                        result = "1";
                    }

                return result;
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                // Log.LogException(LogLevel.Error, ex);
                return null;
            }

        }
        protected static void SetFilter(SAPbouiCOM.EventFilters Filters)
        {
            Application.SBO_Application.SetFilter(Filters);
        }
        #endregion
    }
}

