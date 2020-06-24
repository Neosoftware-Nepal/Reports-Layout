alter PROCEDURE "SP_ITN_SalesReturnRegister" 
AS 
BEGIN 
		SELECT DISTINCT t0."DocEntry", T0."ObjType", t6."SeriesName", 'AR Invoice' AS "DOCTYPE", t0."DocNum", t0."DocDate", 
		t0."CardCode", CASE WHEN T0."CANCELED" = 'Y' THEN 'CANCEL'  else T0."CardName" END AS "CustomerName" ,
		
		CASE WHEN T0."CANCELED" = 'Y' THEN 'CANCELED'  else T0."CardName" END AS "CardName", T0."NumAtCard" AS "Hard Copy No", '' AS "BP PAN NO", 
		T0."DiscSum" AS "Discount", 
		 CASE WHEN "CANCELED"='Y' THEN 0 ELSE IFNULL((SELECT (SUM(RIN1."LineTotal") - T0."DiscSum") 
		FROM RIN1 WHERE T0."DocEntry" = RIN1."DocEntry" AND T0."VatSum" > 0), 0) END AS "Taxable Amount", 
		CASE WHEN "CANCELED"='Y' THEN 0 ELSE IFNULL((SELECT (SUM(RIN1."LineTotal") - T0."DiscSum") 
		FROM RIN1 WHERE T0."DocEntry" = RIN1."DocEntry" AND RIN1."TaxCode" LIKE 'NIL%' 
		AND (T7."Country" = 'NP' OR T7."Country" IS NULL)), 0) END  AS "EXEMPT Amount", 
		CASE WHEN "CANCELED"='Y' THEN 0 ELSE IFNULL((SELECT (SUM(RIN1."LineTotal") - T0."DiscSum") 
		FROM RIN1 WHERE T0."DocEntry" = RIN1."DocEntry" AND T7."Country" <> 'NP'), 0)END  AS "EXEMPT EXPORT", 
		CASE WHEN "CANCELED"='Y' THEN 0 ELSE IFNULL(T0."VatSum", 0)END  AS "VatSum", 
		 T0."DocTotal"  AS "DocTotal", T5."Location", 
		 CASE WHEN T0."CANCELED"='Y' THEN '' ELSE T8."TaxId4" END as "PanNo",
		 
		 IFNULL(T6."BeginStr",'') ||''|| CAST(T0."DocNum" AS char(20)) ||''|| CAST (T6."EndStr" as CHAR (20)) AS "InvNo" 
		 ,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate") AS "Sales Miti"
		 --,SUBSTRING(T0."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(T0."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(T0."U_ITN_NPDate", 7, 2) AS "Sales Miti"
	FROM ORIN T0 
		INNER JOIN RIN1 T1 ON T0."DocEntry" = T1."DocEntry" 
		LEFT OUTER JOIN OCRD T2 ON T0."CardCode" = T2."CardCode" 
		LEFT OUTER JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode" AND T7."Address"=T0."ShipToCode" AND T7."AdresType"='S'
		LEFT OUTER JOIN OCRG t3 ON T2."GroupCode" = t3."GroupCode" 
		LEFT OUTER JOIN OLCT T5 ON T5."Code" = T1."LocCode" 
		LEFT OUTER JOIN NNM1 t6 ON t6."Series" = T0."Series" 
		LEFT OUTER JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode" AND T8."Address" = '' AND T8."AddrType" = 'S'
	WHERE T0."CANCELED" <> 'C'; 
END;
