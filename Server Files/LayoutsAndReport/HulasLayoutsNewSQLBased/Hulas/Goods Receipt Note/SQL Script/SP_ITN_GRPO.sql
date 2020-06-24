create PROCEDURE [dbo].[SP_ITN_HC_grPO] (@DocKey INT)
AS 
BEGIN
SELECT 	 T0."DocEntry"
		,CONCAT(ISNULL(T20."BeginStr", '') 
		, CAST(T0."DocNum" AS nvarchar) 
		, CAST(T20."EndStr" AS CHAR(20))) AS "GRPONo"
		,CONCAT(ISNULL(T22."BeginStr", '') 
	 , CAST(RH."DocNum" AS nvarchar) 
	 , ISNULL(CAST(T22."EndStr" AS nvarchar), '')) AS "IndentNo"
	 ,CONCAT(ISNULL(T23."BeginStr", '') 
	 , CAST(IH."DocNum" AS nvarchar) 
	 ,ISNULL(CAST(T23."EndStr" AS CHAR(20)), '')) AS "InvoiceNo"
	 	,IH."DocDate" as "InvoiceDate"
		,(T0."DocDate")  AS "GRPODate"
		,[dbo].ITN_NEPALI_FMT_DATE (T0.U_ITN_NPDate) AS "Miti"
		--,CONCAT(SUBSTRING(T0."U_ITN_NPDate", 0, 4) , '/' , SUBSTRING(T0."U_ITN_NPDate", 5, 2) , '/' , SUBSTRING(T0."U_ITN_NPDate", 7, 2)) AS "Miti"
		,T0."CardCode" AS "VendorCode"
		,T0."CardName" AS "VendorName"
		,T0."Address2" AS "VendorAddress"
		,T0."Address" AS "VendorBilToAdrs"
		,T16."E_Mail" AS "VendorEmail"
		,T16."Phone1" AS "VendorPhone"
		,T16."Fax" AS "VendorFax"
		,T2."TaxId2" AS "VendorPAN"
		,ISNULL(CAST(AD."Building" AS VARCHAR), '') AS "VendorBuilding"
		,ISNULL(AD."City", '') AS "VendorCity"
		,ISNULL(ST."Name", '') AS "VendorState"
		,ISNULL(CAST(AD."Street" AS VARCHAR), '') AS "VendorStreet"
		,ISNULL(AD."ZipCode", '') AS "VendorZipCode"
		,ISNULL(AD."Country", '') AS "VendorCountryCode"
		,ISNULL(CN."Name", '') AS "VendorCountryName"
		,ISNULL(CAST(AD1."Street" AS VARCHAR), '') AS "VendorBuildingS"
		,ISNULL(AD1."City", '') AS "VendorCityS"
		,ISNULL(ST1."Name", '') AS "VendorStateS"
		,ISNULL(AD1."ZipCode", '') AS "VendorZipCodeS"
		,ISNULL(AD1."Country", '') AS "VendorCountryS"
		,CONCAT(ISNULL(T21."BeginStr", '') 
		, CAST(T7."DocNum" AS CHAR(20)) 
		, CAST(T21."EndStr" AS CHAR(20))) AS "PONo"
		,T7."DocDate" AS "PODate"
		,[dbo].ITN_NEPALI_FMT_DATE (T7.U_ITN_NPDate) AS "PONpDt"
		---,CONCAT(SUBSTRING(T7."U_ITN_NPDate", 0, 4) , '/' , SUBSTRING(T7."U_ITN_NPDate", 5, 2) , '/' , SUBSTRING(T7."U_ITN_NPDate", 7, 2)) AS "PONpDt"
		,RH."DocNum" AS "RequisitionNum"
		,RH."ReqName" AS "RequesterName"
		,RH."DocDate" AS "RequisitionDate"
		,T5."ChapterID"
		,T5."Dscription" AS "ChIdDes"
		,ISNULL(T1."Quantity", 0) AS "PartyWt"
		,T12."CurrName" AS "CurrName"
		,T15."WhsName"
		,ISNULL(T1."Quantity", 0) AS "NetCoreWt"
		,T1.LineNum
		,T1."ItemCode"
		,T1."Dscription" AS "ItemName"
		,T6."Quantity" AS "Challan Qty"
		,ISNULL(T1."Quantity", 0) AS "Quantity"
		,ISNULL(T4."InvntryUom", '') AS "UoM"
		,ISNULL(T1."Price", 0) AS "Rate"
		,T1."Price" * T1."Quantity" AS "LineTotal"
		--,T4."U_UNE_EXPU" * T1."Quantity" AS "ExciseLineAmt"
		,CASE 
			WHEN T0."DocCur" = 'NPR'
				THEN T1."VatSum"
			ELSE T1."VatSumFrgn"
			END AS "VAT AMOUNT"
		,CASE 
			WHEN T0."DocCur" = 'NPR'
				THEN T0."DocTotal"
			ELSE T0."DocTotalFC"
			END AS "GRPOTotal"
		,T0."OwnerCode" AS "PreparedBy"
		,OUSR."U_NAME" AS "USER_CODE"
		,T0."Comments" AS "Remarks"
		,ISNULL(T1."U_ITN_AQTY",0) AS "AcceptedQty"
	,T0."U_ITN_INDT" AS "InspectionDate"
	--,T0."U_ITN_CFRM" As "Custom Form No"
	,T0."U_ITN_TRAN"  AS "TransportName"
	,T0."U_ITN_GEDT" AS "GateEntryDate"
	,T0."U_ITN_GENO" AS "GateEntryNo"
	,T0."U_ITN_VECN" AS "VehicleNo"
	,T0."U_ITN_VETY" AS "VehicleType"
	--,T0."U_ITN_CFRD" AS "CustomFormDate"
    --,T0."U_ITN_LRNO" AS "LR/Bilty No"
FROM OPDN T0
INNER JOIN PDN1 T1 ON T0."DocEntry" = T1."DocEntry"
LEFT JOIN OADM ON 1 = 1
LEFT JOIN ADM1 ON OADM."Code" = ADM1."Code"
LEFT JOIN OCRD T16 ON T16."CardCode" = T0."CardCode"
LEFT JOIN OUSR ON T0."UserSign" = OUSR."USERID"
INNER JOIN NNM1 T20 ON T20."Series" = T0."Series"
LEFT JOIN CRD7 T2 ON T2."CardCode" = T0."CardCode"
	AND T2."Address" = T0."ShipToCode"
	AND T2."AddrType" = 'S'
LEFT JOIN OITM T4 ON T4."ItemCode" = T1."ItemCode"
	AND T1."ObjType" = '20'
LEFT JOIN OCHP T5 ON T5."AbsEntry" = T4."ChapterID"
LEFT JOIN POR1 T6 ON T6."DocEntry" = T1."BaseEntry"
	AND T6."ObjType" = T1."BaseType"
	AND T6."LineNum" = T1."BaseLine"
LEFT JOIN OPOR T7 ON T6."DocEntry" = T7."DocEntry"
LEFT JOIN NNM1 T21 ON T21."Series" = T7."Series"
LEFT JOIN OCRN T12 ON T0."DocCur" = T12."CurrCode"
LEFT JOIN OWHS T15 ON T1."WhsCode" = T15."WhsCode"
LEFT JOIN OLCT L ON L."Code" = T15."Location"
LEFT JOIN CRD1 AD ON AD."CardCode" = T0."CardCode"
	AND AD."Address" = T0."PayToCode"
	AND AD."AdresType" = 'B'
LEFT JOIN OCST ST ON ST."Code" = AD."State"
	AND ST."Country" = AD."Country"
LEFT JOIN OCRY CN ON CN."Code" = AD."Country"
LEFT JOIN CRD1 AD1 ON AD1."CardCode" = T0."CardCode"
	AND AD1."Address" = T0."ShipToCode"
	AND AD1."AdresType" = 'S'
LEFT JOIN OCST ST1 ON ST1."Code" = AD1."State"
	AND ST1."Country" = AD1."Country"
LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
	AND M."CardCode" = T0."CardCode"
LEFT JOIN PRQ1 RQ ON RQ."DocEntry" = T6."BaseEntry"
	AND RQ."ObjType" = T6."BaseType"
	AND RQ."LineNum" = T6."BaseLine"
LEFT JOIN OPRQ RH ON RH."DocEntry" = RQ."DocEntry"
LEFT JOIN NNM1 T22 ON T22."Series" = RH."Series"
Left Join PCH1 IL ON T1."DocEntry" = IL."BaseEntry"
	AND T1."LineNum" = IL."BaseLine"
Left JOIN OPCH IH on IH."DocEntry" = IL."DocEntry"
LEFT JOIN NNM1 T23 ON T23."Series" = IH."Series"
LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"
WHERE T0."DocEntry" = @DocKey;
END


