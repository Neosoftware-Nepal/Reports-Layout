create PROCEDURE [dbo].[SP_ITN_HC_dispatchOrder] (@DocKey INT)
AS
BEGIN
SELECT 	 T0."DocEntry"
		,CONCAT(ISNULL(T20."BeginStr", '') 
		,CAST(T0."DocNum" AS NVARCHAR) 
		,ISNULL(CAST(T20."EndStr" AS CHAR(20)), '')) AS "DONumber"
		,T0."DocDueDate" AS "DeliveryDate"
		,T0."DocDate"    AS "PostingDate"
		,T0."TaxDate"	 AS "DocumentDate"
		,[dbo].ITN_NEPALI_FMT_DATE (T0.U_ITN_NPDate) AS "Miti"
		--,CONCAT(SUBSTRING(T0."U_ITN_NPDate",0,4)
		 --,'/', SUBSTRING(T0."U_ITN_NPDate",5,2)
		-- ,'/', SUBSTRING(T0."U_ITN_NPDate",7,2) AS "Miti"
		,T0."CardCode" AS "CustomerCode"
		,T0."CardName" AS "CustomerName"
		,T0."Address2" AS "CustomerAddress"
		,T0."Address" AS "CustomerBilToAdrs"
		,T11."TaxId2" AS "CustomerPAN"
		,T1.LineNum
		,OADM."CompnyName" AS "CompanyName"
		,OADM."CompnyAddr" AS "CompanyAddress"
		,ADM1."Building" AS "CompanyBuilding"
	    ,T0."OwnerCode" AS "PreparedBy"
		--,T0."U_ITN_TRAN" AS "Shipper"
		,T9."SlpName" AS "Sales Employee"
		,T0."U_ITN_VECN" AS "VehicleNo"
		,T0."U_ITN_DRNM" AS "DriverName"
		,ISNULL(CAST(AD."Building" AS VARCHAR), '') AS "CustomerBuilding"
		,ISNULL(AD."City", '') AS "CustomerCity"
		,ISNULL(ST."Name", '') AS "CustomerState"
		,ISNULL(AD."ZipCode", '') AS "CustomerZipCode"
		,ISNULL(AD."Country", '') AS "CustomerCountry"
		,T17."Name" AS "CustCountryName"
		,ISNULL(CAST(AD1."Street" AS VARCHAR), '') AS "CustomerBuildingS"
		,ISNULL(AD1."City", '') AS "CustomerCityS"
		,ISNULL(ST1."Name", '') AS "CustomerStateS"
		,ISNULL(AD1."ZipCode", '') AS "CustomerZipCodeS"
		,ISNULL(AD1."Country", '') AS "CustomerCountryS"
		,T1."ItemCode" as "ItemCode"
		--,T4."U_ITN_ITMB" AS "Brand"
		,T1."Dscription" as "ItemDescription"
		,T1."Quantity" as "Quantity"
		,OUSR."U_NAME" AS "USER_CODE"
		,ISNULL(M."Name", '') AS "CustContName"
		,ISNULL(T10."Phone1", '') AS "CustContMobileNo"
		,ISNULL(M."Tel1" , '')    AS "CustContTel"
		,ISNULL(T10."E_Mail", '')  AS "CustContEmail"
		,T11."TaxId4"  AS "CustomerPAN"
		,T11."TaxId1"  AS "CustomerCSTNo"
		,T11."TaxId2"  AS "CustomerLSTNo"
		,T11."TaxId11" AS "CustomerTINNo"
		,cONCAT(ISNULL(T21."BeginStr", '') 
		, CAST(T18."DocNum" AS NVARCHAR) 
		, ISNULL(CAST(T21."EndStr" AS CHAR(20)), '')) AS "SONumber"
		,T18."DocDate" AS "SODate"
		,[dbo].ITN_NEPALI_FMT_DATE (T18.U_ITN_NPDate) AS "SOMiti"
		--,CONCAT(SUBSTRING(T18."U_ITN_NPDate",0,4)
		-- ,'/',SUBSTRING(T18."U_ITN_NPDate",5,2)
		 --,'/',SUBSTRING(T18."U_ITN_NPDate",7,2)) AS "SOMiti"
		 ,T0."U_ITN_DRCN" AS "Driver Number"
		 ,T0."U_ITN_GEIT" as "GateEntryInTime"
		 ,T0."U_ITN_GEOT" as "GateEntryOutTime"
		 ,T0."U_ITN_WEBB" as "WeighBridgeBefore"
		 ,T0."U_ITN_WEBA" as "WeighBridgeAfter"
		 --,T0."U_ITN_LOST" as "LoadingStartTime"
		 --,T0."U_ITN_LOET" as "LoadingEndTime"
	FROM ODLN T0
	LEFT JOIN DLN1 T1 ON T0."DocEntry" = T1."DocEntry"
	LEFT JOIN OADM ON 1 = 1
	LEFT JOIN ADM1 ON ADM1."Code" = OADM."Code"
	LEFT JOIN ORDR T18 ON T18."DocNum" = T1."BaseRef"
	LEFT JOIN OSHP T7 ON T7."TrnspCode" = T0."TrnspCode"
	LEFT JOIN OCTG T8 ON T8."GroupNum" = T0."GroupNum"
	LEFT JOIN OSLP T9 ON T9."SlpCode" = T0."SlpCode"
	LEFT JOIN OCRD T10 ON T10."CardCode" = T0."CardCode"
	LEFT JOIN OUSR ON T0."UserSign" = OUSR."USERID"
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
	LEFT JOIN CRD7 T11 ON T11."CardCode" = T0."CardCode"
		AND T11."Address" = ''
		AND T11."AddrType" = 'S'
	LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
		AND M."CardCode" = T0."CardCode"
	LEFT JOIN OITM T4 ON T4."ItemCode" = T1."ItemCode"
	--LEFT JOIN V_ITN_ITEMDLN Pivot ON Pivot."ItemCode" = T4."ItemCode"
    --AND Pivot."DocEntry" = T0."DocEntry"
	LEFT JOIN OCRY T17 ON T17."Code" = AD."Country"
	LEFT JOIN NNM1 T20 ON T20."Series" = T0."Series"
	LEFT JOIN NNM1 T21 ON T21."Series" = T18."Series"
	LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"
	WHERE T0."DocEntry" = @DocKey;
		END