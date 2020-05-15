
ALTER PROCEDURE "SP_ITN_purchaseRequest" (IN DocKey INT)
AS
BEGIN
	SELECT T1."Requester"
		,T1."DocEntry"
		,IFNULL(T21."BeginStr", '') 
		||'/'|| CAST(T1."DocNum" AS CHAR(20)) 
		||'/'|| IFNULL(T21."EndStr", '') AS "ReqNo"
		,T1."DocDate" AS "DocDate"
		,T1."DocDueDate" AS "DueDate"
		,T1."ReqName" as "Requester Name"
		,SUBSTRING(T1."U_ITN_NPDate", 0, 4) 
		 ||'/'||   SUBSTRING(T1."U_ITN_NPDate", 7, 2)
		  ||'/'||   SUBSTRING(T1."U_ITN_NPDate", 9, 2) AS "Miti"
		--,ITN_NEPALI_FMT_DATE](T1."U_ITN_NPDate")AS "Miti"
		,T1."TaxDate" AS "TaxDate"
		,T1."DocDueDate" AS "DocDueDate"
		,T1."DocCur" AS "CURRENCY"
		,T1."DocRate" AS "CURRENCY_RATE"
		,T1."ReqDate" AS "Request Date"
		,T15."Name" AS "Department"
		
		
		,T5."PanNo" AS "LocPAN"
		
	
		,T1."CANCELED"
		
		,T1."DiscPrcnt"
		,T1."DiscSum"
		,T1."VatSum"
	
		,T12."FormNo"
		,T1."TrackNo" AS "DispatchNo"
		,T1."NumAtCard" AS "RefNo"
		,T6."PymntGroup" AS "PaymentTerm"
		,T2."ItemCode"
		,T2."Dscription"
		,T2."Quantity"
		,T2."VatSum" AS "TaxAmount"
		,T2."PQTReqDate"
		
		,CASE 
			WHEN T1."WddStatus" = 'P'
				THEN 'APPROVED'
			ELSE 'NOT APPROVED'
			END AS "Approval"
		,T2."Price"
		,T2."unitMsr"
		,T2."LineTotal"
		,T13."Substitute"
		,T1."DocTotal"
		,T1."Comments" AS "Remark"
		,T1."RoundDif"
		,OUSR."U_NAME"
		
	FROM OPRQ T1
	INNER JOIN PRQ1 T2 ON T1."DocEntry" = T2."DocEntry"
	INNER JOIN OITM OT ON T2."ItemCode" = OT."ItemCode"
	LEFT JOIN OCPR T3 ON T1."CntctCode" = T3."CntctCode"
	LEFT JOIN PRQ12 T12 ON T1."DocEntry" = T12."DocEntry"
	INNER JOIN OLCT T5 ON T2."LocCode" = T5."Code"
	LEFT JOIN OCTG T6 ON T1."GroupNum" = T6."GroupNum"
	LEFT JOIN OSCN T13 ON T1."CardCode" = T13."CardCode"
		AND T2."ItemCode" = T13."ItemCode"
	INNER JOIN OADM ON 1 = 1
	LEFT JOIN ADM1 ON OADM."Code" = ADM1."Code"
	LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"	
	LEFT JOIN NNM1 T21 ON T21."Series" = T1."Series"
	LEFT JOIN OUSR ON T1."Requester" = OUSR."USER_CODE"
	INNER JOIN OUDP T15 On T1."Department" = T15."Code" 
	WHERE T1."DocEntry" = :DocKey;
END

