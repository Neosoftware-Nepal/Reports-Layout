Alter PROCEDURE "SP_ITN_grPO" (IN DocKey INT)
AS 
BEGIN
SELECT  T0."DocEntry"
		,T0."DiscSum" AS "Discount Amount"   
		,T0."VatSum" AS "Vat Amount"		 
		,T0."DocTotal" 						
		,T0."NumAtCard"	as "CI Invoice"
		,T0."DocDate"		
		,T1."WhsCode" AS "WarehouseCode" 
		,T1."LineNum"   
		,T0."Comments" AS "Remarks" 
		,T33."ItmsGrpNam" as "QTY(Case)"			

/* Numbers   */
		
		,IFNULL(T20."BeginStr", '') 
		|| '/' || CAST(T0."DocNum" AS CHAR(20)) 
		|| '/' || CAST(T20."EndStr" AS CHAR(20)) AS "GRPONo"
		
	 --,IFNULL(T23."BeginStr", '') 
	-- || '/' || CAST(IH."DocNum" AS CHAR(20)) 
	-- || '/' || CAST(T23."EndStr" AS CHAR(20)) 
		,T0."NumAtCard" AS "VendorInvoiceNo"    
	
		,IFNULL(T21."BeginStr", '') 
		|| '/' || CAST(T7."DocNum" AS CHAR(20))  AS "PONo"
		--|| '/' || CAST(T21."EndStr" AS CHAR(20))
	 
	 
/*  Dates  */
	 	,IH."DocDate" as "VendorInvoiceDate"
		,TO_NVARCHAR(T0."DocDate",'YYYY/MM/DD')  AS "GRPODate"
		--,SUBSTRING(T0."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(T0."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(T0."U_ITN_NPDate", 7, 2) AS "Miti"
		,T7."DocDate" AS "PODate"
		,ITN_NEPALI_FMT_DATE(T7."U_ITN_NPDate") as "Miti"
		--,SUBSTRING(T7."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(T7."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(T7."U_ITN_NPDate", 7, 2) AS "PONpDt"
		
		
/*  Vendor Details    */
		,T0."CardCode" AS "VendorCode"
		,T0."CardName" AS "VendorName"
		,T0."Address2" AS "ShipVendorAddress"
		,T0."Address" AS "VendorBilToAdrs"
		,T2."TaxId4" AS "VendorPAN"
		,IFNULL(CAST(AD."Building" AS VARCHAR), '') AS "VendorBuilding"
		,IFNULL(CAST(AD."Street" AS VARCHAR), '') AS "VendorStreet"
		
		,IFNULL(CAST(AD1."Street" AS VARCHAR), '') AS "VendorBuildingS"
		
		,RH."DocNum" AS "RequisitionNum"
		,RH."ReqName" AS "RequesterName"
		,RH."DocDate" AS "RequisitionDate"
		,T5."ChapterID"
		,T5."Dscription" AS "ChIdDes"
		,IFNULL(T1."Quantity", 0) AS "QTY"
		,T12."CurrName" AS "CurrName"
		,T15."WhsName"
		,T15."Building" AS "BrBuilding"
		,T15."City" AS "BrCty"
		,T15."State" AS "BrState"
		,T15."ZipCode" AS "BrZpCod"
	
		
		/*  Line Details */ 
		,T1."ItemCode"
		,T1."Dscription" AS "ItemName"
		,IFNULL(T4."InvntryUom", '') AS "Inventory UoM"
		,IFNULL(T1."Price", 0) AS "Rate"
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
		,T0."OwnerCode" 
		,OUSR."U_NAME" AS "Prepared By"
		,(T1."Quantity" * T1."Price") As "LineAmount"
		,T1."UomCode" as "UOM"
		,T1."unitMsr" as "UOM Name"
		,T1."FreeTxt" as "LineRemark"
		
		
/*   User Defined Feilds   */
		/*,T1."U_BIN" as "BiN"
		,T1."U_BATCHNO" as "Batch No"
		,T1."U_ITNEXPDT" as "Expirey Date"*/
		--,T34."Batch"
		,T0."U_CIINVNUM" as "Purchase Invoice (CI)"
		,T0."U_LC" as "LC Number."
		,T0."U_LOC" as "LOC Number."
		,T0."U_ChlnNum" as "Challan Number"
		,T0."U_ChalnDt" as "Challan Date"
		
		/* ,T37."Quantity"
   ,T36."ExpDate"
   ,T36."MnfDate"
   ,T38."BinCode"
   ,T36."DistNumber" as "Batch"*/
		
/*   Commercial Invoice Date */
		,T31."DocNum" as "Commercial Inv Number"
		,T31."U_REFNUM" as "Vendor Invoice"
		,T31."CreateDate" as "Vendor Invoice Date"
		
/*   Batch Details  */
		/*,T29."Quantity"
		,T29."InDate" as "MFG Date"
		,T29."ExpDate" as "Expiry Date"
		,T29."U_ITNABINCODE" as "Bin Code"
		,T29."BatchNum" as "Batch Number"*/
		,T37."Quantity"
   ,T36."ExpDate"
   ,T36."MnfDate"
   ,T38."BinCode"
   ,T36."DistNumber" as "Batch"  

/*   Shipment Tracking */
		,T32."U_BLDNUM" as "Bilty Number"
		,T32."U_BLDT" as "Bilty Date"
		,T32."U_TRANME" as "Transporter Name"
		
		,IFNULL(CASE 
 		WHEN T0."DocCur" = 'NPR'
			THEN T27."LineTotal"
		ELSE T27."TotalFrgn"
		END, 0) AS "FreightCharge"
		
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
LEFT JOIN POR3 T19 ON T0."DocEntry" = T19."DocEntry"
	 AND T19."ExpnsCode" = 3
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
LEFT JOIN PDN3 T27 ON T0."DocEntry" = T27."DocEntry"
	 AND T27."ExpnsCode" = 2
--Left Join OIBT T29 on T1."ItemCode" = T29."ItemCode" 
--and T29."BaseEntry" = T1."DocEntry" 
--and T29."BaseType" = T1."ObjType"
LEFT JOIN "@ITN_OCIN" T31 ON  T0."U_CIINVNUM" = T31."DocEntry"
LEFT JOIN "@ITN_OSPT" T32 ON T32."U_COMINVNO"  = T31."DocEntry" 
LEFT JOIN OITB T33 On T4."ItmsGrpCod" = T33."ItmsGrpCod"


left join OITL T34 on t1."DocEntry" = T34."ApplyEntry" 
	and T1."LineNum" = T34."ApplyLine" 
	and T34."ApplyType" = 20 
left JOIN ITL1 T35 ON T34."LogEntry" = T35."LogEntry" 
left join OBTN T36 on T36."ItemCode" = T35."ItemCode" 
	and T35."MdAbsEntry" = t36."AbsEntry"
Inner Join OBTL T37 on T37."SnBMDAbs" = T35."MdAbsEntry" and T34."LogEntry" = T37."ITLEntry"
Inner Join OBIN T38 on T38."AbsEntry" = T37."BinAbs"
WHERE T0."DocEntry" = :DocKey;
END