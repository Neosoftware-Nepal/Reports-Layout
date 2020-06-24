CREATE Procedure "SP_ITN_ProductionOrderReceipt"(IN DocKey INT)
AS
BEGIN
SELECT T3."DocNum"
	,IFNULL(T5."BeginStr", '') || '' || CAST(T3."DocNum" AS CHAR(20)) || '' || IFNULL(CAST(T5."EndStr" AS CHAR(20)), '') AS "Production Order No"
	,T3."Status"
	,T3."PostDate"
	,SUBSTRING(T3."U_UNE_NPDate", 0, 4) || '/' || SUBSTRING(T3."U_UNE_NPDate", 5, 2) || '/' || SUBSTRING(T3."U_UNE_NPDate", 7, 2) AS Miti
	,T1."ItemCode" AS "Parent Item Code"
	,T1."Dscription" AS "Parnet Item Name"
	,T4."InvntryUom" AS "Parent Item Uom"
	,T1."Quantity" AS "RECEIPT QTY"
	,T2."U_ITN_PRDL" AS "Production Line"
	,T2."U_ITN_BRKT" AS "Breakdown Type"
	,T2."U_ITN_BRKR" AS "Breakdown Reason"
	,T2."U_ITN_BRKD" AS "Breakdown Duration"
	,T2."U_ITN_SUPR" AS "Line Supervisor"
	,T2."U_ITN_TWRK" AS "Total Workers"
	,T2."U_ITN_PRHO" AS "Production Running Hours"
	,T2."U_ITN_BBIW" AS "Bottle Breakage In Wash"
	,T2."U_ITN_BBIP" AS "Bottle Breakage in Production"
FROM IGN1 T1
LEFT JOIN OIGN T2 ON T2."DocEntry" = T1."DocEntry"
LEFT JOIN OWOR T3 ON CAST(T3."DocNum" AS VARCHAR) = T1."BaseRef"
LEFT JOIN OITM T4 ON T4."ItemCode" = T1."ItemCode"
LEFT JOIN NNM1 T5 ON T5."Series" = T3."Series"
WHERE T3."Status" <> 'C'
AND T3."DocEntry" = :DocKey;
END