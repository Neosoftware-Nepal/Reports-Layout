USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_exciseSalesRegister]    Script Date: 02/04/2020 9:59:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_ITN_exciseSalesRegister]
AS
BEGIN
---for hulas auoto craft
SELECT Distinct T1."DocDate" AS "Sales Date"
	,T1."DocEntry"
	,T1."DocNum"
	,ISNULL(T4."BeginStr", '') + CAST(T1."DocNum" AS nvarchar) + ISNULL(CAST(T4."EndStr" AS nvarchar), '') AS "Sales No"

	--Nepali Date
	,[dbo].ITN_NEPALI_FMT_DATE(T1."U_ITN_NPDate") AS "Sales Miti"

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
		END AS "CustomerName"
	,0 AS "ZeroRatedSales"
	,T5."TaxId4" AS "Pan No"
	, 0  AS "EXEMPT Amount"
	,T6."Location" AS Location
FROM OINV T1
LEFT JOIN INV1 T2 ON T1."DocEntry" = T2."DocEntry"
LEFT JOIN INV4 T7 ON T1."DOcEntry" = T7."DocEntry"
	AND StaCode LIKE 'EX%'
LEFT JOIN NNM1 T4 ON T4."Series" = T1."Series"
LEFT JOIN CRD7 T5 ON T5."CardCode" = T1."CardCode"
	AND T5."Address" = ''
	AND T5."AddrType" = 'S'
LEFT JOIN OLCT T6 ON T6."Code" = T2."LocCode"	
WHERE T2.TaxCode LIKE 'EX%'
GROUP BY T1."CANCELED"
	,T1."DocDate"
	,T1."DocEntry"
	,T1."DocNum"
	,T4."BeginStr"
	,T1."CardName"
	,T2."TaxCode"
	,T4."EndStr"
	,T1."U_ITN_NPDate"
	,T5."TaxId4"
	,T6."Location"
    ,t1."DocType"
ORDER BY T1."DocNum";
END