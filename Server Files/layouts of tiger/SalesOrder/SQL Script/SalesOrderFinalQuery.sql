ALTER PROCEDURE "SP_ITN_TB_salesOrder" (IN DocKey INT)
AS
  BEGIN
 
 SELECT T0."DocEntry"
		
			
			,IFNULL(T20."BeginStr", '')
			 || '' || CAST(T0."DocNum" AS CHAR(20)) 
			 || '' || IFNULL(CAST(T20."EndStr" AS CHAR(20)), '') AS "SONumber"
			,T0."CardCode"   AS "CustomerCode"
			,T0."CardName"   AS "CustomerName"
			,T0."Address2"   AS "CustomerAddress"
			,T0."Address"    AS "CustomerBilToAdrs"			
			,T0."DocDate"    AS "PostingDate"
			,T0."DocDueDate" AS "DeliveryDate"
			,T0."TaxDate"	 AS "DocumentDate"
			,SUBSTRING(T0."U_ITN_NPDate",0,4)
			 ||'/'||SUBSTRING(T0."U_ITN_NPDate",5,2)
			 ||'/'||SUBSTRING(T0."U_ITN_NPDate",7,2) AS Miti
			,OADM."CompnyName" AS "CompanyName"
			,OADM."CompnyAddr" AS "CompanyAddress"
			,ADM1."Building" AS "CompanyBuilding"
			,ADM1."Block" AS "CompanyBlock"
			,ADM1."Street" AS "CompanyStreet"
			,ADM1."StreetNo"  AS "CompanyPoBoX"
			,ADM1."City"  AS "CompanyCity"
			,ADM1."ZipCode"  AS "CompanyZipCode"
			,OADM."RevOffice" AS "CompanyPAN"
			,OADM."Phone1" AS "CompanyPhone"
			,OADM."Phone2" AS "Mobile"
			,OADM."Fax" AS "CompanyFax"
			,OADM."E_Mail" AS "CompanyEmail"
			,OADM."Country" AS "CompanyCountryName"
			,ST2."Name" AS "ComStateName"
			,T0."OwnerCode" AS "PreparedBy"
			,IFNULL(CAST(AD."Building" AS VARCHAR), '') AS "CustomerBuilding"
			,IFNULL(AD."City", '') AS "CustomerCity"
			,IFNULL(ST."Name", '') AS "CustomerState"
			,IFNULL(AD."ZipCode", '') AS "CustomerZipCode"
			,IFNULL(AD."Country", '') AS "CustomerCountry"
			,T17."Name" AS "CustCountryName"
			,IFNULL(CAST(AD1."Street" AS VARCHAR), '') AS "CustomerBuildingS"
			,IFNULL(AD1."City", '') AS "CustomerCityS"
			,IFNULL(ST1."Name", '') AS "CustomerStateS"
			,IFNULL(AD1."ZipCode", '') AS "CustomerZipCodeS"
			,IFNULL(AD1."Country", '') AS "CustomerCountryS"
			,T4."U_ITN_ITMB" AS "Brand"
			,OUSR."U_NAME" AS "USER_CODE"
		 	,T1."ItemCode" As "Product Code"
		 	,T1."Dscription" As "Product Name"
		 	,T1."Quantity"
		 	,T1."unitMsr" As "Uom"
			,T1."Price" As "UnitPrice"
			,IFNULL(M."Name", '') AS "CustContName"
			,IFNULL(T16."Phone1", '') AS "CustContMobileNo"
			,IFNULL(M."Tel1" , '')    AS "CustContTel"
			,IFNULL(T16."E_Mail", '')  AS "CustContEmail"
			,T3."TaxId4"  AS "CustomerPAN"
			,T3."TaxId1"  AS "CustomerCSTNo"
			,T3."TaxId2"  AS "CustomerLSTNo"
			,T3."TaxId11" AS "CustomerTINNo"
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
	LEFT JOIN OCTG T9 ON T9."GroupNum" = T0."GroupNum"
	LEFT JOIN OCRN T12 ON T0."DocCur" = T12."CurrCode"
	LEFT JOIN RDR12 T13 ON T13."DocEntry" = T1."DocEntry"
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
	LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
		AND M."CardCode" = T0."CardCode"
    --LEFT JOIN V_ITN_ITEMORD Pivot ON Pivot."ItemCode" = T4."ItemCode"
    --AND Pivot."DocEntry" = T0."DocEntry"
    LEFT JOIN OCRY T17 ON T17."Code" = AD."Country"
    LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
		AND ST2."Country" = OADM."Country"	
    WHERE T0."DocEntry" = :DocKey
	GROUP BY T0."DocEntry"
			,IFNULL(T20."BeginStr", '')
			 || '' || CAST(T0."DocNum" AS CHAR(20)) 
			 || '' || IFNULL(CAST(T20."EndStr" AS CHAR(20)), '')
			,T0."CardCode"
			,T0."CardName"
			,T0."Address2"
			,T0."Address" 			
			,T0."DocDate"
			,T0."DocDueDate"
			,T0."TaxDate"
			,T1."ItemCode"
			,T1."Dscription"
			,T1."Quantity"
			,SUBSTRING(T0."U_ITN_NPDate",0,4)
			||'/'||SUBSTRING(T0."U_ITN_NPDate",5,2)
			||'/'||SUBSTRING(T0."U_ITN_NPDate",7,2)
			,OADM."CompnyName"
			,OADM."CompnyAddr"
			,ADM1."Building"
			,ADM1."Block"
			,ADM1."Street"
			,ADM1."StreetNo"
			,ADM1."City"
			,ADM1."ZipCode"
			,OADM."RevOffice"
			,OADM."Phone1"
			,OADM."Fax"
			,OADM."E_Mail"
			,OADM."Country"
			,T0."OwnerCode"
			,IFNULL(CAST(AD."Building" AS VARCHAR), '')
			,IFNULL(ST."Name", '')
			,IFNULL(AD."City", '')
			,IFNULL(AD."ZipCode", '')
			,IFNULL(AD."Country", '')
			,T17."Name"
			,IFNULL(CAST(AD1."Street" AS VARCHAR), '')
			,IFNULL(AD1."City", '') 
			,IFNULL(ST1."Name", '') 
			,IFNULL(AD1."ZipCode", '')
			,IFNULL(AD1."Country", '') 
			,T4."U_ITN_ITMB"
			,OUSR."U_NAME"
			,M."Name"
			,T16."Phone1"
			,M."Tel1"
			,T16."E_Mail"
			,T3."TaxId4"
		    ,T3."TaxId1"
            ,T3."TaxId2"
            ,T3."TaxId11"
            ,ST2."Name"
            ,OADM."Phone2"
             ,T1."unitMsr" 
			,T1."Price";
                END
