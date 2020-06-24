Alter PROCEDURE "SP_ITN_salesOrder" (IN DocKey INT)
AS
BEGIN
SELECT distinct T0."DocEntry"
 		,T0."DocTotal"
 /*  Sales order number  */
			,IFNULL(T20."BeginStr", '') || '/' ||
			 CAST(T0."DocNum" AS CHAR(20)) || '/' || IFNULL(T20."EndStr", '') AS "OrderNo"
			 ,T0."VatSum"
			 ,T1."VatPrcnt" as "VatPrcnt"
			 ,T0."U_ITNTRDDIS" as "VolumeDisPrcnt"
			 ,T0."U_ITNTRDDISAM" as "Volume Discount Amount"
			 ,T0."U_ITNSPDIS" as "TradeDisPrcnt"
			 ,T0."U_ITNSPDISAM" as "Trade Discount Amount"
			 ,T0."U_ITNCProD" as "ConsumerDisPrcnt"
			 ,T0."U_ITNCProAmt" as "Consumer Discount Amount"
			 
			 
			  /*  customer details    */
			,T0."CardCode"   AS "CustomerCode"
			,T0."CardName"   AS "CustomerName"
			,T0."Address2"   AS "CustomerAddress"
			,T0."Address"    AS "CustomerBilToAdrs"			
			,T0."DocDate"    AS "OrderDate"
			,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate")AS "Miti"
			,T0."DocDueDate" AS "DeliveryDate"
			,T0."TaxDate" 	 AS "DocumentDate"
			--,CAST(LEFT(T0."DocTime", 2) ||':'|| RIGHT(LEFT(T0."DocTime", 4), 2) AS TIME) as "SOTime"
			
		    /*,IFNULL(M."FirstName", '')AS "CustContFName"
		    ,IFNULL(M."MiddleName",'')AS "CustContMName"
		    ,IFNULL(M."LastName", '') AS "CustContLName" */
			,IFNULL(T16."Phone1", '') AS "CustContMobileNo"
			,IFNULL(M."Tel1" , '')    AS "CustContTel"
			,IFNULL(T16."E_Mail", '')  AS "CustContEmail" 
			,T3."TaxId4"  AS "CustomerPAN"
			
			
			 /*  Nepali date ADD-on  */
			--,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate")AS "Miti"

			--,SUBSTRING(T0."U_ITN_NPDate",0,4)
			 --||'/'||SUBSTRING(T0."U_ITN_NPDate",5,2)
			 ---||'/'||SUBSTRING(T0."U_ITN_NPDate",7,2) AS Miti

			
			 /*  Customer address Bill to address  */
			,IFNULL(CAST(AD."Street" AS NVARCHAR), '') AS "BillToAddress"
			,IFNULL(AD."City", '') AS "CustomerCity"
			,IFNULL(ST."Name", '') AS "CustomerState"
			,IFNULL(AD."ZipCode", '') AS "CustomerZipCode"
			,IFNULL(AD."Country", '') AS "CustomerCountry"
			,T17."Name" AS "CustCountryName"
			,T9."PymntGroup" as "Payment Group"
			
			
			
			 /*   Customer address Ship to address */
			,IFNULL(CAST(AD1."Street" AS NVARCHAR), '') AS "ShipToAddress"
			,IFNULL(AD1."City", '') AS "CustomerCityS"
			,IFNULL(ST1."Name", '') AS "CustomerStateS"
			,IFNULL(AD1."ZipCode", '') AS "CustomerZipCodeS"
			,IFNULL(AD1."Country", '') AS "CustomerCountryS"
			--,T4."U_ITN_ITMB" AS "Brand"
			
			
		
			/*  Line details */
			
			
		 	,T1."ItemCode" As "Product Code"
		 	,T1."Dscription" As "Product Name"
		 	,T1."Quantity" As "Total Pcs"
		 	,0 as "QTY(Pcs)"
		 	,T1."unitMsr" As "Uom"
			,T1."Price" As "UnitPrice"
			,T1."LineTotal" As "Amount"
			,T4."NumInBuy" as "QTY/CASE"
			,T19."ItmsGrpNam" as "Business Unit"
			,T1."U_ITNPRODISPR" as "Promotion Discount Percent"
			,ifnull(T1."U_ITNPRODISAM",0) as "Promotion Discount Amount"
			,T1."DiscPrcnt" as "Production Discount"
			,T1."Rate"
			,IFNULL((T1."Price" * T1."Quantity"),'0') as "LineAmount"
			
			/*  Employee Details  */
			,T18."SlpName"
			,OUSR."U_NAME" as "Prepared By"
			
			,T0."Comments" as "Remark"
			,IFNULL((SELECT SUM(RDR4."BaseSum") FROM RDR4 WHERE T0."DocEntry" = RDR4."DocEntry" AND RDR4."LineNum" = T1."LineNum" AND RDR4."staType" = 1), 0) AS "TaxableAmount"
			
	FROM ORDR T0
	INNER JOIN RDR1 T1 ON T0."DocEntry" = T1."DocEntry"
	LEFT JOIN OADM OADM ON 1 = 1
	LEFT JOIN ADM1 ADM1 ON ADM1."Code" = OADM."Code"
	LEFT JOIN OCRD T16 ON T16."CardCode" = T0."CardCode"
	LEFT JOIN OUSR ON T0."UserSign" = OUSR."USERID"
	INNER JOIN NNM1 T20 ON T20."Series" = T0."Series"
	LEFT JOIN CRD7 T2 ON T2."CardCode" = T0."CardCode"
		AND T2."Address" = T0."ShipToCode"
		AND T2."AddrType" = 'S'
	LEFT JOIN CRD7 T3 ON T3."CardCode" = T0."CardCode"
		AND T3."Address" = ''
		AND T3."AddrType" = 'S'
	LEFT JOIN OITM T4 ON T4."ItemCode" = T1."ItemCode"
	Inner Join OITB T19 On T4."ItmsGrpCod" = T19."ItmsGrpCod"
	LEFT JOIN OCTG T9 ON T9."GroupNum" = T0."GroupNum"
	LEFT JOIN OCRN T12 ON T0."DocCur" = T12."CurrCode"
	LEFT JOIN RDR12 T13 ON T13."DocEntry" = T1."DocEntry"
	LEFT JOIN OWHS T15 ON T1."WhsCode" = T15."WhsCode"
	LEFT JOIN OLCT L ON L."Code" = T15."Location"
	LEFT JOIN CRD1 AD ON AD."CardCode" = T0."CardCode"
		AND AD."AdresType" = 'B'
	LEFT JOIN OCST ST ON ST."Code" = AD."State"
		AND ST."Country" = AD."Country"
	LEFT JOIN CRD1 AD1 ON AD1."CardCode" = T0."CardCode"
		AND AD1."AdresType" = 'S'
	LEFT JOIN OCST ST1 ON ST1."Code" = AD1."State"
		AND ST1."Country" = AD1."Country"
	LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
		AND M."CardCode" = T0."CardCode"
    LEFT JOIN OCRY T17 ON T17."Code" = AD."Country"
    LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"
	LEFT JOIN OSLP T18 ON T18."SlpCode" = T0."SlpCode"

	WHERE T0."DocEntry" = :DocKey;
	END