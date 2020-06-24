
CREATE PROCEDURE [dbo].[SP_ITN_purchaseRequest] (@DocKey INT)
AS
BEGIN
	SELECT T1."Requester"
		,OUSR."U_NAME"
		,T1."DocEntry"
		,CASE 
			WHEN T1."DocStatus" = 'O'
				THEN 'Open'
			ELSE 'Closed'
			END AS "Status"
		,CONCAT(ISNULL(T21."BeginStr", '') 
		, CAST(T1."DocNum" AS CHAR(20)) 
		, ISNULL(CAST(T21."EndStr" AS CHAR(20)), '')) AS "ReqNo"
		,T1."DocDate" AS "DocDate"
		--,CONCAT(SUBSTRING(T1."U_ITN_NPDate", 0, 4) 
		--- , '/' , SUBSTRING(T1."U_ITN_NPDate", 5, 2)
		 ---, '/' , SUBSTRING(T1."U_ITN_NPDate", 7, 2)) AS "Miti"
		,[dbo].[ITN_NEPALI_FMT_DATE](T1."U_ITN_NPDate")AS "Miti"
		,T1."TaxDate" AS "TaxDate"
		,T1."DocDueDate" AS "DocDueDate"
		,T1."DocCur" AS "CURRENCY"
		,T1."DocRate" AS "CURRENCY_RATE"
		,T1."DocDueDate" AS "Delivery Date"
		,T1."Department" AS "Department"
		,T2."FreeTxt" AS "Remarks"
		,OT."OnHand"
		,OT."MinLevel"
		,OT."MaxLevel"
		,OT."LastPurPrc"
		,T5."PanNo" AS "LocPAN"
		,T5."CstNo" AS "LocCstNo"
		,T5."EccNo" AS "EXCISE_NO"
		,T5."Street" AS "LOC_Street"
		,T5."Block" AS "Loc_Block"
		,T5."Building" AS "Loc_Building"
		,T5."City" AS "Loc_City"
		,T5."ZipCode" AS "Loc_ZipCode"
		--,'India' AS "LOC_country"
		,T1."CANCELED"
		,Z."SHIP_BLOCK"
		,Z."SHIP_BUILDING"
		,Z."SHIP_STREET"
		,Z."SHIP_CITY"
		,Z."SHIP_ZIPCODE"
		,Z."SHIP_StateName"
		--,Z."Country"
		,T1."DiscPrcnt"
		,T1."DiscSum"
		,T1."VatSum"
		--,CASE ISNULL(CAST(T12."TransCat" AS VARCHAR(10)), '')
		---	WHEN ''
			---	THEN ''
		---	ELSE 'SALE AGAINST ' , CAST(T12."TransCat" AS VARCHAR(10))
		---	END AS "FormType"
		,T12."FormNo"
		,T1."TrackNo" AS "DispatchNo"
		,T1."NumAtCard" AS "RefNo"
		,T6."PymntGroup" AS "PaymentTerm"
		,T2."ItemCode"
		,T2."Dscription"
		,T2."Quantity"
		,T2."VatSum" AS "TaxAmount"
		,T2."PQTReqDate"
		,OT."UserText"
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
		,OADM."Fax" AS "CompanyFax"
		,OADM."E_Mail" AS "CompanyEmail"
		,OADM."Country" AS "CompanyCountryName"
		,ST2."Name" AS "ComStateName"
		,T2."U_ITN_REMK" AS "ItemRemark"
		--,T1."U_ITN_CCEN" AS "CostCentre"
		,T1."U_ITN_REVN" AS "Revision"
		,T1."U_ITN_PRIO" AS "Priority"
	FROM OPRQ T1
	INNER JOIN PRQ1 T2 ON T1."DocEntry" = T2."DocEntry"
	INNER JOIN OITM OT ON T2."ItemCode" = OT."ItemCode"
	LEFT JOIN OCPR T3 ON T1."CntctCode" = T3."CntctCode"
	LEFT JOIN PRQ12 T12 ON T1."DocEntry" = T12."DocEntry"
	INNER JOIN OLCT T5 ON T2."LocCode" = T5."Code"
	LEFT JOIN OCTG T6 ON T1."GroupNum" = T6."GroupNum"
	LEFT JOIN OSCN T13 ON T1."CardCode" = T13."CardCode"
		AND T2."ItemCode" = T13."ItemCode"
	LEFT JOIN (
		SELECT A."WhsCode"
			,A."Street" AS "SHIP_STREET"
			,A."Block" AS "SHIP_BLOCK"
			,A."Building" AS "SHIP_BUILDING"
			,A."City" AS "SHIP_CITY"
			,A."ZipCode" AS "SHIP_ZIPCODE"
			,B."Name" AS "SHIP_StateName"
			--,'India' AS "Country"
		FROM OWHS A
			,OCST B
		WHERE A."State" = B."Code"
			AND A."Country" = B."Country"
		) Z ON T2."WhsCode" = Z."WhsCode"
	INNER JOIN OADM ON 1 = 1
	LEFT JOIN ADM1 ON OADM."Code" = ADM1."Code"
	LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"	
	LEFT JOIN NNM1 T21 ON T21."Series" = T1."Series"
	LEFT JOIN OUSR ON T1."Requester" = OUSR."USER_CODE"
	WHERE T1."DocEntry" = @DocKey;
END



