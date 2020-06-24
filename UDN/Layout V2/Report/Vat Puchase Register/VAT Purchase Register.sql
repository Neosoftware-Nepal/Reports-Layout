CREATE Procedure "SP_ITN_VatPurchaseRegister"
AS BEGIN

--DECLARE FromDate DATETIME;
--DECLARE ToDate DATETIME;

--SELECT min(T0."DocDate") INTO FromDate FROM OIGE T0 WHERE T0."DocDate" >= '[%0]';
--SELECT max(T0."DocDate") INTO ToDate FROM OIGE T0 WHERE T0."DocDate" <= '[%1]';

SELECT DISTINCT  T0."DocEntry"
                ,T0."ObjType"
                ,T6."SeriesName"
                ,'AP Invoice' AS "DOCTYPE"
                ,T0."DocDate"
                ,ITN_NEPALI_FMT_DATE(T0."U_ITN_NPDate") AS "Miti"
                 --,SUBSTRING(T0."U_PPMiti", 0, 4)
                 --|| '/' || SUBSTRING(T0."U_PPMiti", 5, 2)
                 --|| '/' || SUBSTRING(T0."U_PPMiti", 7, 2) AS "NP Date"
                ,IFNULL(T6."BeginStr", '')
                || '' || CAST(T0."DocNum" AS CHAR(20))
                || '' || CAST(T6."EndStr" AS CHAR(20)) AS "InvNo"
                ,CASE 
                   WHEN T0."CANCELED" = 'Y'
                    THEN 'CANCEL'
                    ELSE T0."CardName"
                   END AS "CardName"
                 ,T0."U_CusOffNam" AS "Custom Office"
                 ,T0."U_PPNo" AS "PP Number"
				 ,T0."U_PPDat" AS "PP Date"
                 ,T0."NumAtCard" AS "PartyBilNo"
				 ,T8."TaxId4" AS "PanNo"
                 ,T0."DiscSum" AS "Discount"
                 ,0 As "VatNo"
                 ,T5."Location"
                 ,CASE 
                   WHEN T0."U_PURTYPE" <> 'Import'
                      THEN T0."DocTotal"
                      ELSE T0."U_VATAmt" + T0."U_TaxblVal"
                   END AS "Total Purchase"
                                                
                  ,IFNULL(( SELECT (SUM(PCH1."LineTotal") - T0."DiscSum")
                            FROM PCH1
                            WHERE T0."DocEntry" = PCH1."DocEntry"
                                   AND T0."U_PURTYPE" <> 'Import'
                                   AND PCH1."TaxCode" = 'EXEMPT'
                          ), 0) AS "EXEMPT Purchase"
                 ,IFNULL((SELECT (SUM(PCH1."LineTotal") - T0."DiscSum")
                                FROM PCH1
                                WHERE T0."DocEntry" = PCH1."DocEntry"
                                      AND T0."U_PURTYPE" <> 'Import'
                                      AND T0."VatSum" > 0
                                      AND PCH1."TaxCode" LIKE '%VAT%'), 0) AS "LocalPurchaseTaxableAmount"
                 ,IFNULL((SELECT SUM(PCH4."TaxSum")
                                FROM PCH4
                                WHERE T0."DocEntry" = PCH4."DocEntry"
                                      AND T0."U_PURTYPE" <> 'Import'
                                      AND PCH4."staType" = 1), 0) AS "LocalPurchaseTaxAmount"
                ,IFNULL((SELECT (OPCH."U_TaxblVal")
                                 FROM OPCH
                                 WHERE T0."DocEntry" = OPCH."DocEntry"
                                       AND T0."U_PURTYPE" = 'Import'), 0) AS "ImportTaxableAmount"
                ,IFNULL((SELECT (OPCH."U_VATAmt")
                                FROM OPCH
                                WHERE T0."DocEntry" = OPCH."DocEntry"
                                      AND T0."U_PURTYPE" = 'Import'), 0) AS "ImportVatAmount"
FROM OPCH T0
INNER JOIN PCH1 T1 ON T0."DocEntry" = T1."DocEntry"
LEFT OUTER JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
LEFT OUTER JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode"
LEFT OUTER JOIN OCRG T3 ON T2."GroupCode" = T3."GroupCode"
LEFT OUTER JOIN OLCT T5 ON T5."Code" = T1."LocCode"
LEFT OUTER JOIN NNM1 T6 ON T6."Series" = T0."Series"
LEFT OUTER JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode"
                AND T8."Address" = ''
                AND T8."AddrType" = 'S'                
WHERE T0."CANCELED" NOT IN ('C', 'Y')
--AND T0."DocDate" > TO_DATE('30/04/2019', 'DD/MM/YYYY')
--AND T0."DocDate" >=FromDate AND T0."DocDate" <=ToDate
ORDER BY 5;
END;