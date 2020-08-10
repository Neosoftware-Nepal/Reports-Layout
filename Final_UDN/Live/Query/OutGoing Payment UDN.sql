ALTER PROCEDURE "SP_ITN_OutgoingPayment"(IN DocKey INT)
AS
BEGIN
SELECT  "OPCH"."DocNum" as "Purchase Invoice Number"
, "OVPM"."DocEntry"
--, "OVPM"."U_ITN_NPDate" 
--,SUBSTRING(OVPM."U_ITN_NPDate", 0, 4) || '/' ||
-- SUBSTRING(OVPM."U_ITN_NPDate", 5, 2) || '/' || 
-- SUBSTRING(OVPM."U_ITN_NPDate", 7, 2) AS "NP Date"
, "OPCH"."DocTotal" as "Total Amount"
, "OVPM"."DocEntry"
, "VPM1"."CheckNum" as "Cheque Number"

, "OVPM"."CashSum" as "Cash Payment"
, "OVPM"."CheckSum" as "Cheque Payment"
, (IFNULL("NNM1"."SeriesName",'') ||'/'|| "OVPM"."DocNum") as "Document Number"
, "OVPM"."CardCode"
, "OVPM"."DocDate" as "Date"
, "OVPM"."DocType" as "Document Type"
, "OVPM"."NoDocSum" as "Credit Payment"
, "VPM2"."SumApplied" as "A/P Amount"
, "VPM2"."DocEntry"
, "OLCT". "Location"
, "VPM4"."DocNum"
, "VPM4"."AcctName" as "Acount Name"
, "VPM4"."SumApplied" as "Cash Amount"
, "VPM2"."DocNum" 
, "VPM4"."LineId"
, "OPCH"."NumAtCard" as "Vendor Ref No"
, "OVPM"."CardName" as "vendor Name"
, "OVPM"."Comments" as "Remark"
, "VPM2"."InvType" as "Invoice Type"
, "OPCH"."TaxDate"
, "VPM4"."AcctCode" as "Acount Number"
, "OCRD"."City"
, "OVPM"."TrsfrSum" as "Bank Transfer"
, "OVPM"."DocCurr" as "Currency"
, "VPM4"."OcrCode" as "LC"
, "OVPM"."Address" as "Address"
, "OVPM"."PIndicator" as "Period Indicator"
, "VPM1"."LineID" 
, "VPM1"."AcctNum" as "Bank Code"
, "ODSC"."BankName" as "Bank Name"
,CASE 
                    WHEN  OVPM."CashSum" <> 0
                         THEN "OVPM"."CashAcct"
                    WHEN OVPM."CheckSum" <>  0
                         THEN "VPM1"."AcctNum"
                    WHEN OVPM."TrsfrSum"<> 0
                        THEN "OVPM"."TrsfrAcct"
    END AS "PaymentFrom"  
,CASE 
                    WHEN  OVPM."CashSum" <> 0
                         THEN (Select "OACT"."AcctName" 
                        		from "OACT" where "OACT"."AcctCode" = "OVPM"."CashAcct" )
                    WHEN OVPM."CheckSum" <>  0
                         THEN "ODSC"."BankName"
                    WHEN OVPM."TrsfrSum"<> 0
                        THEN (Select "OACT"."AcctName" 
                        		from "OACT" where "OACT"."AcctCode" = "OVPM"."TrsfrAcct" )
    END AS "PaymentFromName"    
    ,CASE 
                    WHEN  OVPM."CashSum" <> 0
                         THEN 'Cash Payment'
                    WHEN OVPM."CreditSum"<>  0
                         THEN 'Credit Payment'
                    WHEN OVPM."CheckSum" <>  0
                         THEN 'Cheque Payment'
                    WHEN OVPM."TrsfrSum"<> 0
                        THEN 'Bank  Payment'
    END AS "PaymentType"  
,CASE 
                    WHEN  OVPM."CashSum" <> 0
                         THEN OVPM."CashSum"
                    WHEN OVPM."CreditSum"<>  0
                         THEN OVPM."NoDocSum"
                    WHEN OVPM."CheckSum" <>  0
                         THEN VPM1."CheckSum"
                    WHEN OVPM."TrsfrSum"<> 0
                        THEN OVPM."TrsfrSum" END AS "Amount" 

,"OUSR"."U_NAME" as "Prepared By"
 FROM   OVPM 
 LEFT OUTER JOIN OCRD ON "OVPM"."CardCode"="OCRD"."CardCode"
 FULL OUTER JOIN VPM2 ON "OVPM"."DocEntry"="VPM2"."DocNum"
 LEFT OUTER JOIN VPM1 ON "OVPM"."DocEntry"="VPM1"."DocNum"
 LEFT OUTER JOIN VPM4 ON "OVPM"."DocEntry"="VPM4"."DocNum"
 LEFT OUTER JOIN "OPCH" ON ("VPM2"."DocEntry"="OPCH"."DocEntry") 
 	AND ("VPM2"."InvType"="OPCH"."ObjType")
 Left JOIN ODSC  on "VPM1"."BankCode" = "ODSC"."BankCode"
 Left JOIN OUSR ON OVPM."UserSign" = OUSR."USERID" 
 INNER Join NNM1 ON OVPM."Series" = NNM1."Series"
 Left Join OLCT On OVPM."LocCode" = OLCT."Code"
  WHERE OVPM."DocEntry"=:DocKey
ORDER BY "OVPM"."DocNum", "VPM2"."DocEntry", "VPM4"."LineId";
END
