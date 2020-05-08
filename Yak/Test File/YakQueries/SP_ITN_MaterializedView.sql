CREATE PROCEDURE "SP_ITN_MaterializedView" 
AS 
BEGIN 
SELECT DISTINCT T0."DocEntry"
	,T0."PIndicator"
	,T0."ObjType"
	,T0."DocStatus"
	,T0."CANCELED"
	,t6."SeriesName"
	,'AR INVOICE' AS "DOCTYPE"
	,T1."BaseRef"
	,IFNULL(t6."BeginStr", '') || '' || CAST(T0."DocNum" AS CHAR(20)) || '' || IFNULL(CAST(t6."EndStr" AS CHAR(20)), '') AS "DocNo"
	,SUBSTRING(T0."U_UNE_NPDate", 0, 4) || '/' || SUBSTRING(T0."U_UNE_NPDate", 5, 2) || '/' || SUBSTRING(T0."U_UNE_NPDate", 7, 2) AS "NP Date"
	,T0."DocDate"
	,T0."CardCode"
	,T0."CardName"
	,T0."NumAtCard" AS "Hard Copy No"
	,CRD7."TaxId4" AS "BP PAN NO"
	,SUM(T1."LineTotal") AS "Befor Disc"
	,T0."DiscSum" AS "Discount"
	,(
		CASE 
			WHEN T0."CANCELED" = 'C'
				THEN - (
						IFNULL((
								SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
								FROM INV1
								WHERE T0."DocEntry" = INV1."DocEntry"
									AND T0."VatSum" > 0
								), 0)
						)
			ELSE IFNULL((
						SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
						FROM INV1
						WHERE T0."DocEntry" = INV1."DocEntry"
							AND T0."VatSum" > 0
						), 0)
			END
		) AS "Taxable Amount"
	,(
		CASE 
			WHEN T0."CANCELED" = 'C'
				THEN - (
						IFNULL((
								SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
								FROM INV1
								WHERE T0."DocEntry" = INV1."DocEntry"
									AND INV1."TaxCode" LIKE 'EX%'
									AND (
										T7."Country" = 'NP'
										OR T7."Country" IS NULL
										)
								), 0)
						)
			ELSE IFNULL((
						SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
						FROM INV1
						WHERE T0."DocEntry" = INV1."DocEntry"
							AND INV1."TaxCode" LIKE 'EX%'
							AND (
								T7."Country" = 'NP'
								OR T7."Country" IS NULL
								)
						), 0)
			END
		) AS "EXEMPT Amount"
	,(
		CASE 
			WHEN T0."CANCELED" = 'C'
				THEN - (
						IFNULL((
								SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
								FROM INV1
								WHERE T0."DocEntry" = INV1."DocEntry"
									AND T7."Country" <> 'NP'
								), 0)
						)
			ELSE (
					IFNULL((
							SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
							FROM INV1
							WHERE T0."DocEntry" = INV1."DocEntry"
								AND T7."Country" <> 'NP'
							), 0)
					)
			END
		) AS "EXEMPT EXPORT"
	,(
		CASE 
			WHEN T0."CANCELED" = 'C'
				THEN - (IFNULL(T0."VatSum", 0))
			ELSE (IFNULL(T0."VatSum", 0))
			END
		) AS "VatSum"
	,(
		CASE 
			WHEN T0."CANCELED" = 'C'
				THEN - T0."DocTotal"
			ELSE T0."DocTotal"
			END
		) AS "DocTotal"
	,T1."WhsCode"
	,T5."Location"
	,'' AS "U_ReasonRet"
	,(CAST(FLOOR(T0."DocTime" / 100) AS VARCHAR) || ':' || CAST(RIGHT(T0."DocTime", 2) AS VARCHAR)) AS "DocTime"
	,T0."Printed"
	,T7."U_NAME"
FROM OINV T0
INNER JOIN INV1 T1 ON T0."DocEntry" = T1."DocEntry"
LEFT JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
LEFT JOIN CRD1 T10 ON T10."CardCode" = T2."CardCode"
LEFT JOIN OCRG t3 ON T2."GroupCode" = t3."GroupCode"
LEFT JOIN OLCT T5 ON T5."Code" = T1."LocCode"
LEFT JOIN NNM1 t6 ON t6."Series" = t0."Series"
LEFT JOIN CRD7  ON CRD7."CardCode" = T0."CardCode"
		AND CRD7."Address" = ''
		AND CRD7."AddrType" = 'S'
LEFT JOIN OUSR T7 ON T0."UserSign" = T7."USERID"
GROUP BY T0."DocEntry"
,t6."BeginStr"
,t6."EndStr"
	,T0."DocNum"
	,T0."U_UNE_NPDate"
	,T0."DocDate"
	,T0."CardCode"
	,T0."CardName"
	,T0."VatSum"
	,T0."DiscSum"
	,T0."DocTotal"
	,T1."WhsCode"
	,T2."CardFName"
	,T0."NumAtCard"
	,T5."Location"
	,t6."SeriesName"
	,T10."Country"
	,T0."ObjType"
	,T0."PIndicator"
	,T0."DocTime"
	,T0."Printed"
	,T0."DocStatus"
	,T7."U_NAME"
	,T0."CANCELED"
	,T7."Country"
	,T1."BaseRef"
	,CRD7."TaxId4";
	END;