CREATE PROCEDURE "SP_ITN_ARDownpayment" (IN DocKey INT)
AS
BEGIN
Select 
/*   Header Document    */
	   T0."DocDate"
	  ,T0."DocEntry"
	  ,T0."DocNum"
	  ,T0."DocType"
	  ,T0."DocDueDate"
	  ,T0."CardCode"
	  ,T0."CardName"
	  ,T0."Address"
	  ,T0."VatSum"
	  ,T0."DiscSum"
	  ,T0."NumAtCard"
	  --,T0."DisSum"
	  ,T0."DocTotal"
	  ,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate")AS "Miti"
	  ,T0."DiscPrcnt"
	  ,IFNULL(T3."SeriesName", '') 
		|| '' || CAST(T0."DocNum" AS CHAR(20)) As "DownpaymentNo"
	  ,T0."Comments" as "Remark"
	  
/*   Line Document */

	 ,T1."ItemCode"
	 ,T1."Dscription"
	 ,T1."Quantity"
	 ,T1."Price"
	 ,T1."LineTotal"
	 ,T1."Currency"
	 ,T1."WhsCode"
	 ,T1."AcctCode"
	 ,T1."BaseRef"
	 ,T1."TaxCode"
	 ,T1."LineVat"
	 ,T1."PriceBefDi"	  
	 
/* Sales Order Document*/
	 ,IFNULL(T3."SeriesName", '') 
		|| '' || CAST(T2."DocNum" AS CHAR(20)) AS "SalesOrderNo"
	 ,ITN_NEPALI_FMT_DATE(T2."U_ITN_NPDate")AS "SOMiti"
	 ,T2."DocDate" As "SODate"
	 
	 /* vendor Details  */
	 ,T4."TaxId4" as "PanNo"
	 ,ifnull(T5."Phone1", T5."Phone2") as "VendorPhone"
	 
	 
	 ,T6."U_NAME"
	

/*   Series */	 
	 ,T3."SeriesName"
	 		,IFNULL((SELECT DPI4."TaxSum" FROM DPI4 
	 		 WHERE T0."DocEntry" = DPI4."DocEntry" 
	 		 AND DPI4."LineNum" = T1."LineNum" 
	 		 AND DPI4."staType" = 1), 0) AS "LineVatAmt"
from ODPI T0
Inner Join DPI1 T1 On T0."DocEntry" = T1."DocEntry"
Left Join ORDR T2 On T1."BaseRef" = T2."DocNum"
Left Join NNM1 T3 On T0."Series" = T3."Series"
LEFT JOIN CRD7 T4 ON T4."CardCode" = T0."CardCode"
		AND T4."Address" = ''
		AND T4."AddrType" = 'S'
left join OCRD T5 ON T5."CardCode"=T0."CardCode"
left join OUSR T6 ON T0."UserSign" = T6."USERID"
WHERE T0."DocEntry" = :DocKey;
END