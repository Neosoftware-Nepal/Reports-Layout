
/****** Object:  StoredProcedure [dbo].[SP_ITN_SalesInvoice]    Script Date: 5/9/2019 2:32:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[SP_ITN_SalesInvoice] (@DocKey INT)
AS
BEGIN
	SELECT T0."DocEntry"
		,T0."CardCode"
		,T0."CardName"
		,T0."Printed" AS "PrintStatus"
		,T0."DocStatus" AS "DocStatus"
		,OADM."CompnyName" AS "CompanyName"
		,OADM."CompnyAddr" AS "CompanyAddress"
		,ADM1."Building" AS "CompanyBuilding"
		,ADM1."Block" AS "CompanyBlock"
		,ADM1."Street" AS "CompanyStreet"
		,ADM1."StreetNo"  AS "CompanyPoBoX"
		,ADM1."City"  AS "CompanyCity"
		,ADM1."ZipCode"  AS "CompanyZipCode"
		,ADM1."EccNo" AS "ExciseRegNo"
		,OADM."RevOffice" AS "CompanyPAN"
		,OADM."Phone1" AS "CompanyPhone"
		,OADM."Phone2" AS "MobileNumber"
		,OADM."Fax" AS "CompanyFax"
		,OADM."E_Mail" AS "CompanyEmail"
		,OADM."Country" AS "CompanyCountryName"
		,ST2."Name" AS "ComStateName"
		,T0."Address2" AS "Address"
		,T0."Address" AS "BilToAdrs"
		,T0."DocTotal"
		,T0."DocCur" AS "Currency"
		,T0."Comments" AS "Remarks"
		,'' AS "NoOfPkgs"
		,'' AS "CntPerPack"
		,T0."NumAtCard" AS "PONo"
		,ISNULL(T21."BeginStr", '') + CAST(ODLN."DocNum" AS CHAR(20)) + ISNULL(CAST(T21."EndStr" AS CHAR(20)), '') AS "OrderNo"
		,ODLN."DocDate" AS "OrderDT"
		,SUBSTRING(Convert(varchar(10),ODLN."U_ITN_NPDate"), 0, 5) + '/' + SUBSTRING(Convert(varchar(10),ODLN."U_ITN_NPDate"), 5, 2) + '/' + SUBSTRING(Convert(varchar(10),ODLN."U_ITN_NPDate"), 7, 2) AS "OrdrNpDt"	
		,ISNULL(T20."BeginStr", '') + CAST(T0."DocNum" AS CHAR(20)) + ISNULL(CAST(T20."EndStr" AS CHAR(20)), '') AS "InvNo"
		,T0."DocDate" AS "InvDt"
		,T1."ItemCode" AS "ItemCode"
		,T1."Dscription" AS "Dscription"
		,T1."Quantity" AS "Quantity"
		--,T1."unitMsr" AS "UoM"
		,T4."SalUnitMsr" AS "UoM"
		,T0."OwnerCode" AS "PreparedBy"
		,T1."PriceBefDi" AS "Price"
		,(ISNULL(T1."Quantity", 0) * ISNULL(T1."PriceBefDi", 0)) AS "LineAmt"
		,T1."LineTotal"
		,T2."TaxId8" AS "ECCNo"
		,T2."CERange"
		,T0."VatSum"
		,T2."CEDivis"
		,T2."CEComRate"
		,T1."LineNum" AS "Line No"
		,T3."TaxId4" AS "PANNo"
		,T3."TaxId1" AS "CSTNo"
		,T3."TaxId2" AS "LSTNo"
		,T3."TaxId11" AS "TINNo"
		,T5."ChapterID"
		,T5."Dscription" AS "ChIdDes"
		,T9."PymntGroup" AS "PaymntMethd"
		,ISNULL(T0."WTSum", 0) AS "TCS"
		,T0."RoundDif" AS "RoundOf"
		,T12."CurrName" AS "CurrName"
		,T1."VatPrcnt" AS "TAXRATE"
		,T12."F100Name" AS "CurrName2"
		,T13."TransCat" AS "SalAgstFrm"
		,T1."DiscPrcnt" AS "LineDisc"
		,CASE 
			WHEN T1."DiscPrcnt" = 0.0
				THEN (ISNULL(T1."Quantity", 0) * ISNULL(T1."Price", 0))
			ELSE (ISNULL(T1."Quantity", 0) * ISNULL(T1."Price", 0)) * (T1."DiscPrcnt") - T1."LineTotal"
			END AS "Amt"
		,T15."Building" AS "BrBuilding"
		,T15."City" AS "BrCty"
		,T15."State" AS "BrState"
		,T15."ZipCode" AS "BrZpCod"
		,ISNULL(CAST(AD."Building" AS VARCHAR), '') AS "Building"
		,ISNULL(AD."City", '') AS "City"
		,ISNULL(ST."Name", '') AS "State"
		,ISNULL(AD."ZipCode", '') AS "ZipCode"
		,ISNULL(AD."Country", '') AS "Country"
		,ISNULL(CAST(AD1."Street" AS VARCHAR), '') AS "BuildingS"
		,ISNULL(AD1."City", '') AS "CityS"
		,ISNULL(ST1."Name", '') AS "StateS"
		,ISNULL(AD1."ZipCode", '') AS "ZipCodeS"
		,ISNULL(AD1."Country", '') AS "CountryS"
		,L."LstVatNo"
		,L."CstNo"
		,T0."DiscPrcnt" AS "DiscntPct"
		,T0."DiscSum"
		,T0."TotalExpns"
		,OUSR."U_NAME" AS "USER_CODE"
		,CASE 
			WHEN T0."TotalExpns" < '0'
				THEN T0."TotalExpns" * (- 1)
			ELSE T0."TotalExpns"
			END AS "frt"
		,((ISNULL(T1."PriceBefDi", 0) - ISNULL(T1."Price", 0)) * ISNULL(T1."Quantity", 0)) + ISNULL(T0."DiscSum", 0) AS "DisAmt"
		,ISNULL(T16."Cellular", T16."Phone1") AS "CustNumber"
		,ISNULL(M."Name", '') AS "CustContName"
		,ISNULL(M."Cellolar", '') AS "CustContMobileNo"
		,ISNULL(M."Tel1", '') AS "Tel"
		,ISNULL(M."E_MailL", '')  AS "CustContEmail"
		,T1."VatPrcnt"
		,T16."Balance"
		,T0."PeyMethod" AS "PaymentMode"
		,SUBSTRING(Convert(varchar(10),T0."U_ITN_NPDate"), 0, 5) + '/' + SUBSTRING(Convert(varchar(10),T0."U_ITN_NPDate"), 5, 2) + '/' + SUBSTRING(Convert(varchar(10),T0."U_ITN_NPDate"), 7, 2) AS "NP Date"
		,T0."U_ITN_VECN" AS "VehicleNo"
		,T0."U_ITN_MDPY" AS "ModeofPay"
		,ISNULL(T1."U_ITN_EXPU", 0) * T1."Quantity" AS "LineExcise"
		--,T4."U_ITN_BOTS" AS "BottelSize"
		--,T4."U_ITN_ITMB" AS "ItemBrand"
		--,UPPER(T4."U_ITN_SGRP") AS "ItemStrength"
		--,TO_VARCHAR(ROUND(T4."U_ITN_PAKQ", 0)) AS "PackQuantity"
		,T0.U_ITN_Print_Count AS "Print Count"
		,CASE 
		WHEN T0."DocCur" = 'NPR'
			THEN ISNULL(I27."LineTotal",0)
		ELSE ISNULL(I27."TotalFrgn",0)
		END AS "TotalFreight"
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
	WHERE T0."DocEntry" = @DocKey;
END

GO


