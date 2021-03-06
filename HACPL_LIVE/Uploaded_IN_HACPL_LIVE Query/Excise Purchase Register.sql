USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_excisePurchaseRegister]    Script Date: 02/04/2020 9:59:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_ITN_excisePurchaseRegister]
AS
BEGIN
---for hulas auoto craft
SELECT Distinct T1."DocDate" AS "Purchase Date"
	,T1."DocEntry"
	,T1."DocNum"
	,ISNULL(T4."BeginStr", '') + CAST(T1."DocNum" AS nvarchar) + ISNULL(CAST(T4."EndStr" AS nvarchar), '') AS "Purchase No"
	
	,T1."U_ITN_WO"
	,T1."CardName"
	,T1."U_ITN_PurType"
	,Cast (T1."U_ITN_ExisableAmt"  as  int)
	,cast (T1."U_ITN_ExciseDty" as int)


	--Nepali Date
	,[dbo].ITN_NEPALI_FMT_DATE(T1."U_ITN_NPDate") AS "Purchase Miti"

	/*
	--Excise Amount 
	,CASE WHEN T2.TaxCode LIKE 'EX%' 
		THEN SUM(ISNULL(T2.LineTotal, 0))
	ELSE
		0
	END AS "Excisable Amount"
	,CASE WHEN T2.TaxCode LIKE 'EX%'
		THEN  SUM(T7.TaxSum)
	ELSE
		0
	END AS "Excise Amount"
	,CASE WHEN T1."CANCELED" = 'Y'
			THEN 'CANCEL'
		ELSE T1."CardName"
		END AS "CustomerName"*/
	,0 AS "ZeroRatedPurchase"
	--,T5."TaxId4" AS "Pan No"
	, 0  AS "EXEMPT Amount"
	,T3."Location" AS Location
	,T5."TaxId4" AS "Pan No"
	
FROM OPCH T1
LEFT JOIN PCH1 T2 ON T1."DocEntry" = T2."DocEntry"
LEFT JOIN OLCT T3 ON T3."Code" = T2."LocCode"	
LEFT JOIN NNM1 T4 ON T1."Series" = T4."Series"
LEFT JOIN CRD7 T5 ON T5."CardCode" = T1."CardCode"
	--AND T5."Address" = ''
	--AND T5."AddrType" = 'S'
GROUP BY T1."CANCELED"
	,T1."DocDate"
	,T1."DocEntry"
	,T1."DocNum"
	,T1."CardName"
	,T2."TaxCode"
	,T4."BeginStr"
	,T4."EndStr"
	,T1."U_ITN_NPDate"
	,T3."Location"
    ,T1."DocType"
	,T1."U_ITN_ExciseDty"
	,T1."U_ITN_WO"
	,T1."CardName"
	,T5."TaxId4" 
	,T1."U_ITN_PurType"
	,T1."U_ITN_ExisableAmt"
ORDER BY T1."DocNum";
END