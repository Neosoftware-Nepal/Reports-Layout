CREATE procedure "SP_ITN_VatPuchaseReturnRagister"
As Begin
SELECT DISTINCT 'Vat Purchase Return Register' as "ReportType"
         ,T0."DocEntry"
		--,T0."ObjType"
		,T6."SeriesName"
		--,'Vat Purchase Credit Memo' AS "DOCTYPE"
		,t0."DocNum"
		,t0."DocDate"
		,t0."CardCode"

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
						SELECT (((SUM(PCH1."LineTotal") - T0."DiscSum")*0.3)+Sum(PCH1."LineTotal"))
						FROM PCH1
						WHERE T0."DocEntry" = PCH1."DocEntry"
							AND T0."VatSum" > 0
						), 0)
			END AS "Taxable Amount"

		,CASE 
			WHEN "CANCELED" = 'Y'
				THEN 0
			ELSE IFNULL((
						SELECT (SUM(PCH1."LineTotal") - T0."DiscSum")
						FROM PCH1
						WHERE T0."DocEntry" = PCH1."DocEntry"
							AND PCH1."TaxCode" LIKE 'EXMPT%'
							AND (
								T7."Country" = 'NP'
								OR T7."Country" IS NULL
								)
						), 0)
			END AS "EXEMPT Return Amount"
		

		,CASE 
			WHEN "CANCELED" = 'Y'
				THEN 0
			ELSE IFNULL((
						SELECT (SUM(PCH1."LineTotal") - T0."DiscSum")
						FROM PCH1
						WHERE T0."DocEntry" = PCH1."DocEntry"
							AND T7."Country" <> 'NP'
						), 0)
			END AS "EXEMPT Return EXPORT"

		,CASE 
			WHEN "CANCELED" = 'Y'
				THEN 0
			ELSE IFNULL(T0."VatSum", 0)
			END AS "VatSum"
		--,T0."DocTotal" AS "DocTotal"
		,T5."Location"

		,CASE 
			WHEN T0."CANCELED" = 'Y'
				THEN ''
			ELSE T8."TaxId4"
			END AS "PanNo"

		,IFNULL(T6."BeginStr", '') ||'' || CAST(T0."DocNum" AS CHAR(20)) || '' || CAST(T6."EndStr" AS CHAR(20)) AS "InvNo"
		
		,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate") AS "Purchase Miti"
		

		,Case when T1."TaxCode" = 'VAT@13'
			  Then (SELECT SUM(tx."BaseSum") from RPC4 tx where  tx."DocEntry" = T0."DocEntry" and tx."StaCode" = 'VAT13') 
			  Else T0."U_TaxblVal"
			  End as "Value"
		,Case when T1."TaxCode" = 'VAT@13'
			  Then (SELECT SUM(tx."TaxSum") from RPC4 tx where tx."DocEntry" = T0."DocEntry" and tx."StaCode" = 'VAT13') 
			  Else T0."U_VATAmt"
			  End as "Tax"
		,0 AS "ZeroRatedPurchase"
	--,T5."TaxId4" AS "Pan No"
		, 0  AS "EXEMPT Amount"

	FROM ORPC T0
	INNER JOIN RPC1 T1 ON T0."DocEntry" = T1."DocEntry"
	LEFT OUTER JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
	LEFT OUTER JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode"
		AND T7."Address" = T0."ShipToCode"
		AND T7."AdresType" = 'S'
	LEFT OUTER JOIN OCRG t3 ON T2."GroupCode" = t3."GroupCode"
	LEFT OUTER JOIN OLCT T5 ON T5."Code" = T1."LocCode"
	LEFT OUTER JOIN NNM1 t6 ON t6."Series" = T0."Series"
	LEFT OUTER JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode"
		AND T8."Address" = ''
		AND T8."AddrType" = 'S'
	WHERE T0."CANCELED" <> 'C';
	End