CREATE PROCEDURE "SP_ITN_SalesRegister" 
AS
BEGIN
SELECT DISTINCT T0."DocEntry"
	,T0."ObjType"
	,T6."SeriesName"
	,'AR Invoice' AS "DOCTYPE"
	,T0."DocNum"
	,T0."DocDate"
	,SUBSTRING(T0."U_UNE_NPDate", 0, 4)
	|| '/' || SUBSTRING(T0."U_UNE_NPDate", 5, 2)
	|| '/' || SUBSTRING(T0."U_UNE_NPDate", 7, 2) AS "NP Date"
	,T0."CardCode"
	,CASE 
		WHEN T0."CANCELED" = 'Y'
			THEN 'CANCEL'
		ELSE T0."CardName"
		END AS "CustomerName"
	,CASE 
		WHEN T0."CANCELED" = 'Y'
			THEN 'CANCELED'
		ELSE T0."CardName"
		END AS "CardName"
	,T0."NumAtCard" AS "Hard Copy No"
	,'' AS "BP PAN NO"
	,T0."DiscSum" AS "Discount"
	,CASE 
		WHEN "CANCELED" = 'Y'
			THEN 0
		ELSE IFNULL((
					SELECT (SUM(INV1."LineTotal") - T0."DiscSum") + SUM(IFNULL(INV1."Weight1", 0))
					FROM INV1
					WHERE T0."DocEntry" = INV1."DocEntry"
						AND T0."VatSum" > 0
					), 0)
		END AS "Taxable Amount"
	,CASE 
		WHEN "CANCELED" = 'Y'
			THEN 0
		ELSE IFNULL((
					SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
					FROM INV1
					WHERE T0."DocEntry" = INV1."DocEntry"
						AND INV1."TaxCode" LIKE 'NIL%'
						AND (
							T7."Country" = 'NP'
							)
					), 0)
		END AS "EXEMPT Amount"
	,CASE 
		WHEN "CANCELED" = 'Y'
			THEN 0
		ELSE IFNULL((
					SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
					FROM INV1
					WHERE T0."DocEntry" = INV1."DocEntry"
						AND T7."Country" <> 'NP'
					), 0)
		END AS "EXEMPT EXPORT"
	,CASE 
		WHEN "CANCELED" = 'Y'
			THEN 0
		ELSE IFNULL(T0."VatSum", 0)
		END AS "ExciseandVat"
	,T0."DocTotal" AS "DocTotal"
	,T5."Location"
	,CASE 
		WHEN T0."CANCELED" = 'Y'
			THEN ''
		ELSE T8."TaxId4"
		END AS "PanNo"
	,IFNULL(T6."BeginStr", '') || '' || CAST(T0."DocNum" AS CHAR(20)) || '' || CAST(T6."EndStr" AS CHAR(20)) AS "InvNo"
FROM OINV T0
INNER JOIN INV1 T1 ON T0."DocEntry" = T1."DocEntry"
LEFT JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
LEFT JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode"
	AND T7."Address" = T0."ShipToCode"
	AND T7."AdresType" = 'S'
LEFT JOIN OCRG t3 ON T2."GroupCode" = t3."GroupCode"
LEFT JOIN OLCT T5 ON T5."Code" = T1."LocCode"
LEFT JOIN NNM1 t6 ON t6."Series" = T0."Series"
LEFT JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode"
	AND T8."Address" = ''
	AND T8."AddrType" = 'S'
WHERE T0."CANCELED" <> 'C'
AND T0."CANCELED" <> 'Y'
AND T0."DocDate" > TO_DATE('30/04/2019', 'DD/MM/YYYY')
ORDER BY 5;
END;