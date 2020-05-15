ALTER PROCEDURE "SP_ITN_LCREPORT" 
AS
BEGIN
Select T0."DocEntry"
	  ,T0."DocNum"
	  ,T0."U_LCCODE" as "LC Number"
	  ,T0."U_NAME" as "LC Name"
	  ,T0."U_VENCODE" as "Vendor Code"
	  --,T0."U_VENNAME" as "Vendor Name"
	  ,T1."CardName" as "Vendor Name/Party Name"
	  ,T0."U_LCBANK" as "Bank Name"
	  --,T0."U_CURR" as "Currency"
	  ,T2."CurrName" as "Currency"
	  --,T3."Rate" as "Exchange Rate"
	  ,T0."U_EXRATE" as "Exchange Rate"
	  ,T0."U_TAGS" as "Business Unit"
	  ,T0."U_LCAMT" as "Amount"
	  ,T0."U_MODOFPAY" as "Mode Of Payment"
	  ,T0."U_RMKS" as "Remarks"
	  ,T0."Remark"
	  ,T0."U_COUNTRY" as "Country"
	  ,T0."CreateDate" as "Date of Issue"
	  ,T0."U_VALDATE" as "Valid Till"
	  ,T0."Status" as "Status"
from "@ITN_OLOC" T0
Left Join OCRD T1 ON T1."CardCode" = T0."U_VENCODE"
Left Join OCRN T2 ON T0."U_CURR" = T2."CurrCode"
Left Join ORTT T3 ON T0."U_CURR" = T3."Currency";
END