ALTER PROCEDURE "SP_ITN_salesInvoice" (IN DocKey INT)
AS
BEGIN
SELECT /*  Head Details   */
		T0."DocEntry" 
		,T0."DocStatus"
		,T0."CardCode"
		,T0."CardName"
		,T0."Printed" AS "PrintStatus"
		,T0."Address2" AS "Address"
		,T0."Address" AS "BilToAdrs"
		,T0."DocTotal"
		,T0."DocCur" AS "Currency"
		,T0."Comments" AS "Remarks"
		,T0."NumAtCard" AS "PONo"
		,T0."DocDate" AS "InvDt"
		,T0."OwnerCode" AS "PreparedBy"
		,T0."DiscPrcnt" AS "HeadDiscntPct"
		,T0."DiscSum"
		,T0."TotalExpns"
		,T0."PeyMethod" AS "PaymentMode"
		,T0."U_ITNTRDDIS" as "VolumeDisPrcnt"
			 ,T0."U_ITNTRDDISAM" as "Volume Discount Amount"
			
			 ,T0."U_ITNCProD" as "ConsumerDisPrcnt"
			 ,T0."U_ITNCProAmt" as "Consumer Discount Amount"
		,T0."U_ITNTRDDIS" as "TradeDisPrcnt"
			,T0."U_ITNTRDDISAM" as "Trade Discoount Amount"
			 
		,IFNULL(T21."BeginStr", '') 
		|| '' || CAST(T0."DocNum" AS CHAR(20)) || '' || IFNULL(T21."EndStr", '')  AS "InvoiceNo"
		,T0."VatSum" as "VatAmt"
		,T0."VatPercent" 
		,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate")AS "Inv Miti"
		,AD1."Address" as "ShipToAddress"
		
		
		
		
		,IFNULL(T21."BeginStr", '') 
		|| '' || CAST(ODLN."DocNum" AS CHAR(20)) || '' || IFNULL(T21."EndStr", '')  AS "OrderNo"
		,ODLN."DocDate" AS "OrderDT"
		--,ITN_NEPALI_FMT_DATE(ODLN."U_ITN_NPDate")AS "OrdrNpDt"
		--,SUBSTRING(ODLN."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(ODLN."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(ODLN."U_ITN_NPDate", 7, 2) AS "OrdrNpDt"	
		
		
		
		/* Line Details  */
		,T1."ItemCode" AS "ItemCode"
		,T1."Dscription" AS "Dscription"
		,T1."Quantity" AS "Total Pcs"
		,T1."UomCode" AS "UOM(PCS)"
		,T1."unitMsr" AS "UOM"
		,T1."PriceBefDi" As "Rate"
		,T1."Price" 
		,T1."LineTotal" as "Amount"
		,T1."VatPrcnt" AS "TAXRATE"
		,T1."DiscPrcnt" AS "LineDisc"
		,IFNULL(T1."U_ITNPRODISPR", 0) as "Promotion Discount Percent"
			,T1."U_ITNPRODISAM" as "Promotion Discount Amount"
			,T29."ItmsGrpNam" as "Business Unit"
	
			,T4."NumInBuy" as "QTY/CASE"
			,0 as "QTY(PCS)"
		
		--,(SELECT sum(TX."TaxSum") FROM INV4 TX WHERE TX."DocEntry"=T0."DocEntry" And TX."staType" = 1) AS "LineVAT"
		--,(SELECT sum(TX."TaxSum") FROM INV4 TX WHERE TX."DocEntry"=T0."DocEntry" And TX."staType" = 7) AS "LineExcise"
		,IFNULL((SELECT INV4."TaxSum" FROM INV4 WHERE T0."DocEntry" = INV4."DocEntry" AND INV4."LineNum" = T1."LineNum" AND INV4."staType" = 1), 0) AS "LineVatAmt"
		,IFNULL((SELECT INV4."TaxSum" FROM INV4 WHERE T0."DocEntry" = INV4."DocEntry" AND INV4."LineNum" = T1."LineNum" AND INV4."staType" = 7), 0) AS "LineExciseAmount"
		,IFNULL((SELECT sum(INV4."BaseSum") FROM INV4 WHERE T0."DocEntry" = INV4."DocEntry" AND INV4."LineNum" = T1."LineNum" AND INV4."staType" = 1), 0) AS "TaxableAmount"
		--,IFNULL(T1."U_ITN_EXPU", 0) * T1."Quantity" AS "LineExcise"

		,T1."VatPrcnt"
		,T1."LineNum" AS "Line No"
		--,T1."Price" AS "Rate"
		
		--,T1."unitMsr" AS "UoM"
		,T4."SalUnitMsr" AS "B/P Uom"
		
		
		,(IFNULL(T1."Quantity", 0) * IFNULL(T1."PriceBefDi", 0)) AS "LineAmt"
	
		
		,T3."TaxId4" AS "PANNo"
		
		,T5."ChapterID"
		,T5."Dscription" AS "ChIdDes"
		,T9."PymntGroup" AS "PaymntMethd"
		,IFNULL(T0."WTSum", 0) AS "TCS"
		,T0."RoundDif" AS "RoundOf"
		,T12."CurrName" AS "CurrName"
		
		,T12."F100Name" AS "CurrName2"
		,T13."TransCat" AS "SalAgstFrm"
		
		
		,CASE 
			WHEN T1."DiscPrcnt" = 0.0
				THEN (IFNULL(T1."Quantity", 0) * IFNULL(T1."Price", 0))
			ELSE (IFNULL(T1."Quantity", 0) * IFNULL(T1."Price", 0)) * (T1."DiscPrcnt") - T1."LineTotal"
			END AS "Amt"
		,T15."Building" AS "BrBuilding"
		,T15."City" AS "BrCty"
		,T15."State" AS "BrState"
		,T15."ZipCode" AS "BrZpCod"
		,IFNULL(CAST(AD."Street" AS NVARCHAR), '') AS "Street"
		,IFNULL(AD."City", '') AS "City"
		,IFNULL(ST."Name", '') AS "State"
		,IFNULL(AD."ZipCode", '') AS "ZipCode"
		,IFNULL(AD."Country", '') AS "Country"
		/*,IFNULL(CAST(AD1."Street" AS NVARCHAR), '') AS "BuildingS"
		,IFNULL(AD1."City", '') AS "CityS"
		,IFNULL(ST1."Name", '') AS "StateS"
		,IFNULL(AD1."ZipCode", '') AS "ZipCodeS"
		,IFNULL(AD1."Country", '') AS "CountryS"*/
	
		,OUSR."U_NAME" AS "Prepared By"
		,CASE 
			WHEN T0."TotalExpns" < '0'
				THEN T0."TotalExpns" * (- 1)
			ELSE T0."TotalExpns"
			END AS "frt"
		,((IFNULL(T1."PriceBefDi", 0) - IFNULL(T1."Price", 0)) * IFNULL(T1."Quantity", 0)) + IFNULL(T0."DiscSum", 0) AS "DisAmt"
		,IFNULL(T16."Cellular", T16."Phone1") AS "CustNumber"
		,IFNULL(M."FirstName", '')AS "CustContFName"
		,IFNULL(M."MiddleName",'')AS "CustContMName"
		,IFNULL(M."LastName", '') AS "CustContLName"
		,IFNULL(M."Cellolar", '') AS "CustContMobileNo"
		,IFNULL(M."Tel1", '') AS "Tel"
		,IFNULL(M."E_MailL", '')  AS "CustContEmail"
		
		,T16."Balance"
		
		
		--,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate")"NP Date"
		--,SUBSTRING(T0."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(T0."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(T0."U_ITN_NPDate", 7, 2) AS "NP Date"
		--,T0."U_ITN_VECN" AS "VehicleNo"
		--,T0."U_ITN_MDPY" AS "ModeofPay"
		
		--,T4."U_ITN_BOTS" AS "BottelSize"
		--,T4."U_ITN_ITMB" AS "ItemBrand"
		--,UPPER(T4."U_ITN_SGRP") AS "ItemStrength"
		--,TO_VARCHAR(ROUND(T4."U_ITN_PAKQ", 0)) AS "PackQuantity"
		/*,CASE 
		WHEN T0."DocCur" = 'NPR'
			THEN IfNULL(I27."LineTotal",0)
		ELSE IfNULL(I27."TotalFrgn",0)
		END AS "TotalFreight"*/
		
	FROM OINV T0
	INNER JOIN INV1 T1 ON T0."DocEntry" = T1."DocEntry"
	LEFT JOIN OADM ON 1 = 1
	LEFT JOIN ADM1 ON OADM."Code" = ADM1."Code"
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
		AND T1."ObjType" = '13'
	Inner Join OITB T29 ON T4."ItmsGrpCod" = T29."ItmsGrpCod"
	LEFT JOIN OCHP T5 ON T5."AbsEntry" = T4."ChapterID"
	LEFT JOIN DLN1 T6 ON T1."DocEntry" = T6."TrgetEntry"
		AND T6."ObjType" = T1."BaseType"
		AND T6."LineNum" = T1."BaseLine"
	LEFT JOIN ODLN ON T6."DocEntry" = ODLN."DocEntry"
	LEFT JOIN NNM1 T21 ON T21."Series" = ODLN."Series"
	LEFT JOIN RDR1 T23 ON T6."DocEntry" = T23."TrgetEntry"
		AND T23."ObjType" = T6."BaseType"
		AND T23."LineNum" = T6."BaseLine"
	LEFT JOIN ORDR ON T23."DocEntry" = ORDR."DocEntry"
	LEFT JOIN OCTG T9 ON T9."GroupNum" = T0."GroupNum"
	LEFT JOIN OCRN T12 ON T0."DocCur" = T12."CurrCode"
	LEFT JOIN INV12 T13 ON T13."DocEntry" = T1."DocEntry"
	LEFT JOIN OWHS T15 ON T1."WhsCode" = T15."WhsCode"
	LEFT JOIN OLCT L ON L."Code" = T15."Location"
	LEFT JOIN CRD1 AD ON AD."CardCode" = T0."CardCode"
		AND AD."Address" = T0."PayToCode"
		AND AD."AdresType" = 'B'
	LEFT JOIN OCST ST ON ST."Code" = AD."State"
		AND ST."Country" = AD."Country"
	LEFT JOIN CRD1 AD1 ON AD1."CardCode" = T0."CardCode"
		AND AD1."Address" = T0."ShipToCode"
		AND AD1."AdresType" = 'S'
	LEFT JOIN OCST ST1 ON ST1."Code" = AD1."State"
		AND ST1."Country" = AD1."Country"
	LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"	
	LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
		AND M."CardCode" = T0."CardCode"
LEFT JOIN INV3 I27 ON T0."DocEntry" = I27."DocEntry"
	 AND I27."ExpnsCode" = 8
LEFT JOIN OEXD I28 ON I27."ExpnsCode" = I28."ExpnsCode"
	AND I28."ExpnsCode" = 8 
	WHERE T0."DocEntry" = :DocKey;
END