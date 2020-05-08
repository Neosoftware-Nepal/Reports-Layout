alter PROCEDURE "SP_ITN_exciseSalesRegister"
AS
BEGIN
SELECT T1."DocDate" AS "Sales Date"
	,T1."DocEntry"
	,T1."DocNum"
	,ISNULL(T4."BeginStr", '') + CAST(T1."DocNum" AS nvarchar) + ISNULL(CAST(T4."EndStr" AS nvarchar), '') AS "Sales No"
	,[dbo].ITN_NEPALI_FMT_DATE(T1."U_ITN_NPDate") AS "Sales Miti"
	---,SUBSTRING(T1."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(T1."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(T1."U_ITN_NPDate", 7, 2) AS "Sales Miti"
	,SUM(ISNULL(T2."Quantity", 0) * ISNULL(T2."PriceBefDi", 0)) AS "Excisable Amount"
	,SUM(ISNULL(T2."Quantity", 0) * ISNULL(CAST(T2."U_ITN_EXPU" AS INT), 0)) AS "Excise Amount"
	,CASE 
		WHEN T1."CANCELED" = 'Y'
			THEN 'CANCEL'
		ELSE T1."CardName"
		END AS "CustomerName"

		,CASE
		    WHEN T2."PriceBefDi">=0
			and t1."DocType"='Import'--- (t1."DocType"='Import' IS UDF FIELD VALUE)
			THEN '0'
			ELSE '-'
			END AS "ZeroRatedSales"
		

	,T5."TaxId4" AS "Pan No"
	,SUM(ISNULL(T2."Quantity", 0) * ISNULL(T2."PriceBefDi", 0)) AS "EXEMPT Amount"
	,T6."Location" AS Location
FROM OINV T1
LEFT JOIN INV1 T2 ON T1."DocEntry" = T2."DocEntry"
LEFT JOIN OITM T3 ON T3."ItemCode" = T2."ItemCode"
	AND T2."ObjType" = '13'
LEFT JOIN NNM1 T4 ON T4."Series" = T1."Series"
LEFT JOIN CRD7 T5 ON T5."CardCode" = T1."CardCode"
	AND T5."Address" = ''
	AND T5."AddrType" = 'S'
LEFT JOIN OLCT T6 ON T6."Code" = T2."LocCode"	
WHERE T2."TaxCode" in (select TaxCode from OSTC where TaxCode like '%EX30VA13%')
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
    ,T2."PriceBefDi"
    ,t1."DocType"
ORDER BY T1."DocNum";
END