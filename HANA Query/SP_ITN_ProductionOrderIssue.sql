CREATE Procedure "SP_ITN_ProductionOrderIssue"(IN DocKey INT)
AS
BEGIN
SELECT T1."DocNum"
	,IFNULL(T8."BeginStr", '') || '' || CAST(T1."DocNum" AS CHAR(20)) || '' || IFNULL(CAST(T8."EndStr" AS CHAR(20)), '') AS "Production Order No"
	,T1."Status"
	,T1."PostDate"
	,SUBSTRING(T1."U_UNE_NPDate", 0, 4) || '/' || SUBSTRING(T1."U_UNE_NPDate", 5, 2) || '/' || SUBSTRING(T1."U_UNE_NPDate", 7, 2) AS Miti
	,T5."ItemCode" AS "Item Code"
	,T5."ItemName" AS "Item Name"
	,T5."InvntryUom" AS "Child UOM"
	,T2."PlannedQty" AS "Child Planned Qty"
	,T2."IssuedQty" AS "ISSUE QUANTITY"
	,T2."IssuedQty" - T2."PlannedQty" AS "WASTAGE QTY"
	,T5."U_ITN_PDSW" AS "Production Std. Wastage"
	,T7."Comments" AS Remarks
FROM OWOR T1
JOIN WOR1 T2 ON T2."DocEntry" = T1."DocEntry"
	AND T2."IssueType" <> 'B'
	AND T2."PlannedQty" > 0
LEFT JOIN OITM T5 ON T5."ItemCode" = T2."ItemCode"
LEFT JOIN IGE1 T6 ON T6."BaseRef" = T1."DocNum"
	AND T6."BaseLine" = T2."LineNum"
LEFT JOIN OIGE T7 ON T7."DocEntry" = T6."DocEntry"
LEFT JOIN NNM1 T8 ON T1."Series" = T8."Series"
WHERE T1."Status" <> 'C'
AND T5."InvntryUom" IS NOT NULL
AND T1."DocEntry" = :DocKey;
END