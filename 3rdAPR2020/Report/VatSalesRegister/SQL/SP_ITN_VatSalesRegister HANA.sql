
ALTER procedure "SP_ITN_VaTSalesRegisTer"
as
Begin
SELECT DISTINCT T0."DocEntry"
		,T0."ObjType"
		,T6."SeriesName"
		,'CrediT Memo' AS "DOCTYPE"
		,T0."DocNum"
		,T0."DocDate"
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
		,T0."DiscSum" AS "DiscounT"
		,CASE 
			WHEN "CANCELED" = 'Y'
				THEN 0
			ELSE IFNULL((
						SELECT (((SUM(INV1."LineTotal") - T0."DiscSum") * 0.3) + Sum(INV1."LineTotal"))
						FROM INV1
						WHERE T0."DocEntry" = INV1."DocEntry"
							AND T0."VatSum" > 0
						), 0)
			END AS "Taxable AmounT"
		,CASE 
			WHEN "CANCELED" = 'Y'
				THEN 0
			ELSE IFNULL((
						SELECT (SUM(INV1."LineTotal") - T0."DiscSum")
						FROM INV1
						WHERE T0."DocEntry" = INV1."DocEntry"
							AND INV1."TaxCode" LIKE 'EXMPT%'
							AND (
								T7."Country" = 'NP'
								OR T7."Country" IS NULL
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
			END AS "VatSum"
		,T0."DocTotal" AS "DocTotal"
		,T5."Location"
		,CASE 
			WHEN T0."CANCELED" = 'Y'
				THEN ''
			ELSE T8."TaxId4"
			END AS "PanNo"
		,IFNULL(T6."BeginStr", '') ||'' || CAST(T0."DocNum" AS CHAR(20)) ||'' ||CAST(T6."EndStr" AS CHAR(20)) AS "InvNo"
		,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate") AS "Sales MiTi"
		--,SUBSTRING(T0."U_ITN_NPDaTe", 0, 4) || '/' || SUBSTRING(T0."U_ITN_NPDaTe", 5, 2) || '/' || SUBSTRING(T0."U_ITN_NPDaTe", 7, 2) AS "Sales MiTi"

	FROM OINV T0
	INNER JOIN INV1 T1 ON T0."DocEntry" = T1."DocEntry"
	LEFT OUTER JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
	LEFT OUTER JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode"
		AND T7."Address" = T0."ShipToCode"
		AND T7."AdresType" = 'S'
	LEFT OUTER JOIN OCRG T3 ON T2."GroupCode" = T3."GroupCode"
	LEFT OUTER JOIN OLCT T5 ON T5."Code" = T1."LocCode"
	LEFT OUTER JOIN NNM1 T6 ON T6."Series" = T0."Series"
	LEFT OUTER JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode"
		AND T8."Address" = ''
		AND T8."AddrType" = 'S'
	WHERE T0."CANCELED" <> 'C';
	end 
