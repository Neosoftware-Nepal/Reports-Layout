USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_VatPurchaseRegister]    Script Date: 02/04/2020 10:00:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_ITN_VatPurchaseRegister]
AS
BEGIN

WITH ExciseCTE
AS (
	SELECT T2."DocEntry"
		,Sum(CASE 
				WHEN (
						T1."TaxCode" LIKE '%VAT'
						AND T2."staType" = 7
						)
					THEN (T1."LineTotal" + T2."TaxSum")
				WHEN T1."TaxCode" LIKE 'VAT%'
					THEN T1."LineTotal"
				WHEN (
						T1."TaxCode" = 'NIL'
						OR T1."TaxCode" = 'EXEMPT'
						)
					THEN 0
				END) AS "PurchaseTotal"
		,Sum(CASE 
				WHEN T1."TaxCode" = 'NIL'
					OR T1."TaxCode" = 'EXEMPT'
					THEN T1."LineTotal"
				ELSE 0
				END) AS "ExemptTotal"
	FROM PCH1 T1
	JOIN PCH4 T2 ON T1."DocEntry" = T2."DocEntry"
		AND T1."LineNum" = T2."LineNum"
		AND T1."TaxCode" = T2."StcCode"
	GROUP BY T2."DocEntry"
	)
SELECT DISTINCT T0."DocEntry"
	,T0."ObjType"
	,T6."SeriesName"
	,'AP Invoice' AS "DOCTYPE"
	,T0."DocDate"
	,T0."U_ITN_PurType"
	,[dbo].[ITN_NEPALI_FMT_DATE](T0."U_ITN_NPDate") AS " Miti"
	--,concat(SUBSTRING(T0."U_ITN_NPDate", 0, 5), SUBSTRING(T0."U_ITN_NPDate", 6, 2),SUBSTRING(T0."U_ITN_NPDate", 9, 2)) AS "NP Date"
	,ISNULL(T6."BeginStr", '') + '' + CAST(T0."DocNum" AS CHAR(6)) + '' + CAST(T6."EndStr" AS CHAR(6)) AS "InvNo"
	,CASE 
		WHEN T0."CANCELED" = 'Y'
			THEN 'CANCEL'
		ELSE T0."CardName"
		END AS "Vendor"
	,T0."CardName" AS "CardName"
	,T0."NumAtCard" AS "PartyBilNo"
	,T8."TaxId4" AS "PanNo"
	,T8."TaxId3" As "VatNo"
	,T0."DiscSum" AS "Discount"
	,T5.Location as "Location"
	,T9.ImpORExp


/*  Total Taxable for Import    */
	,CASE when T9.ImpORExp = 'Y'
		Then (
			SELECT (OPCH."U_ITN_VatAmt")
			FROM OPCH
			WHERE T0."DocEntry" = OPCH."DocEntry"
				AND T0."U_ITN_PurType" = 'Import'
			)
		Else 0
		End As "TotalImportTaxable Amount"


/*  Total Taxable for Local */
	,CASE when T9.ImpORExp = 'N'
		Then T4."PurchaseTotal"
		Else 0
		End As "Total Local Taxable Amount"



/*  Total VAT for Import     */
	,CASE when T9.ImpORExp = 'Y'
		Then (
			SELECT (OPCH."U_ITN_Vat")
			FROM OPCH
			WHERE T0."DocEntry" = OPCH."DocEntry"
				AND T0."U_ITN_PurType" = 'Import'
			)
		Else 0
		End As "Total Import Tax Amount"


/*  Total VAT for Local   */
	,CASE when T9.ImpORExp = 'N'
		Then ISNULL((
					SELECT SUM(PCH4."TaxSum")
					FROM PCH4
					WHERE T0."DocEntry" = PCH4."DocEntry"
						--AND T3."GroupName" <> 'Oversease Suppliers'
						AND PCH4."staType" = 1
					), 0)
		Else 0
		End As "Total Local Tax Amount"


	
/*  Total purchase  */
	,CASE 
		WHEN T0."U_ITN_PurType" = 'Import'
			THEN ISNULL((cast(T0."U_ITN_VatAmt" as int) + cast(T0."U_ITN_VAT" as int)),0)
		ELSE ISNULL((T0."DocTotal"),0)
		END AS "Total Purchase"

/*   Exempt Purchase */
	,CASE 
		WHEN T0."U_ITN_PurType" = 'Import' OR  T0."U_ITN_PurType" = 'Local' OR T0."U_ITN_PurType" = 'Capital'
			THEN 0
		ELSE ISNULL(((T4."ExemptTotal" - T0."DiscSum")), 0)
		END AS "EXEMPT Purchase"


/* Local Purchase Taxable and Tax Amount  */
	,CASE 
		WHEN T0."U_ITN_PurType" = 'Local'
			THEN T4."PurchaseTotal"
		ELSE 0
		END AS "LocalPurchaseTaxableAmount"


	,CASE 
		WHEN T0."U_ITN_PurType" = 'Local'
			THEN ISNULL((
					SELECT SUM(PCH4."TaxSum")
					FROM PCH4
					WHERE T0."DocEntry" = PCH4."DocEntry"
						AND PCH4."staType" = 1
					), 0)
		ELSE 0
		END AS "LocalPurchaseTaxAmount"   
		

/*  Import Purchase Taxable and Tax Amount */
	,ISNULL((
			SELECT cast(OPCH."U_ITN_VatAmt" as int)
			FROM OPCH
			WHERE T0."DocEntry" = OPCH."DocEntry"
				AND T0."U_ITN_PurType" = 'Import'
			), 0) AS "ImportTaxableAmount"


	,ISNULL((
			SELECT cast(OPCH."U_ITN_VAT" as int)
			FROM OPCH
			WHERE T0."DocEntry" = OPCH."DocEntry"
				AND T0."U_ITN_PurType" = 'Import'
			), 0) AS "ImportVatAmount"


/* Capital Puchase Taxable and Tax Amount   */
,CASE 
		WHEN T0."U_ITN_PurType" = 'Capital'
			THEN T4."PurchaseTotal"
		ELSE 0
		END AS "CapitalTaxableAmount"


	,CASE 
		WHEN T0."U_ITN_PurType" = 'Capital'
			THEN ISNULL((
					SELECT SUM(PCH4."TaxSum")
					FROM PCH4
					WHERE T0."DocEntry" = PCH4."DocEntry"
						AND PCH4."staType" = 1
					), 0)
		ELSE 0
		END AS "CapitalTaxAmount"

	/*,ISNULL((
			SELECT cast(OPCH."U_ITN_VatAmt" as int)
			FROM OPCH
			WHERE T0."DocEntry" = OPCH."DocEntry"
				AND T0."U_ITN_PurType" = 'Capital'
			), 0) AS "CapitalTaxableAmount"


	,ISNULL((
			SELECT cast(OPCH."U_ITN_VAT" as int)
			FROM OPCH
			WHERE T0."DocEntry" = OPCH."DocEntry"
				AND T0."U_ITN_PurType" = 'Capital'
			), 0) AS "CapitalVatAmount" */


FROM OPCH T0
INNER JOIN PCH1 T1 ON T0."DocEntry" = T1."DocEntry"
INNER JOIN PCH12 T9 ON T0."DocEntry" = T9."DocEntry"
LEFT JOIN ExciseCTE T4 ON T0."DocEntry" = T4."DocEntry"
--left join ExemptCTE T9 on T0."DocEntry" = T9."DocEntry"
LEFT OUTER JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
LEFT OUTER JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode"
LEFT OUTER JOIN OCRG T3 ON T2."GroupCode" = T3."GroupCode"
LEFT OUTER JOIN OLCT T5 ON T5."Code" = T1."LocCode"
LEFT OUTER JOIN NNM1 T6 ON T6."Series" = T0."Series"
LEFT OUTER JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode"
	AND T8."Address" = ''
	AND T8."AddrType" = 'S'
WHERE T0."CANCELED" NOT IN (
		'C'
		,'Y'
		)  and T0.U_ITN_PurType != 'Null' and T0.U_ITN_AGT = 'No'
--AND T0."DocDate" > TO_DATE('30/04/2019', 'DD/MM/YYYY')
GROUP BY T0."DiscSum"
	,T0."DocEntry"
	,T0."ObjType"
	,T6."SeriesName"
	,T8."TaxId3"
	,T0."DocDate"
	,T6."BeginStr"
	,T0."DocNum"
	,T6."EndStr"
	,T0."CardName"
	,T0."CANCELED"
	,T0."NumAtCard"
	,T8."TaxId4"
	,T0."U_ITN_NPDate"
	--,T0."U_ITN_TAXABLE_AMT"
	--,T0."U_ITN_VAT_AMT"
	,T0."U_ITN_VatAmt"
	,T0."U_ITN_VAT"
	,T3."GroupName"
	,T0."DocTotal"
	,T0."U_ITN_PurType"
	,T4."ExemptTotal"
	,T4."PurchaseTotal"
	,T5.Location
	,T9.ImpORExp
ORDER BY 5;


END