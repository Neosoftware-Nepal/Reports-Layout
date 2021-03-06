USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_HC_CCSL]    Script Date: 02/04/2020 9:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_ITN_HC_CCSL]  (@FromDate DATE
	,@ToDate DATE)
AS 
BEGIN

WITH SUBLEDGER AS (
SELECT    T1."TransId"
         ,T2."RefDate"
         ,T1."Account"
         ,T4."AcctName"
         ,T1."Debit"
         ,T1."Credit"
         ,T1."OcrCode2"
		 ,T3."PrcName"
From JDT1 T1
JOIN OJDT T2
       ON T1."TransId" = T2."TransId"
JOIN OPRC T3
       ON T3."PrcCode" = T1."OcrCode2"
JOIN OACT T4 ON T1."Account" = T4."AcctCode")

SELECT  T1."Account" as "Account Code"
       ,T1."AcctName" as "Account Name"
       ,T1."OcrCode2" as "Cost Center Code"
	   ,T1."PrcName" as "Cost Center Name"
          ,SUM(T1."Debit")  AS "Debit Balance"
       ,SUM(T1."Credit") AS "Credit Balance"
          ,(SELECT ISNULL(SUM(T5."Debit"),0) 
               From JDT1 T5
              JOIN OJDT T6
                     ON T5."TransId" = T6."TransId" 
              WHERE T5.Account = T1.Account
              AND T5.OcrCode2 = T1.OcrCode2
              AND T6."RefDate" < @FromDate) AS "Opening Debit Balance" --'[%0]'
       ,(SELECT ISNULL(SUM(T5."Credit"), 0) 
               From JDT1 T5
              JOIN OJDT T6
                     ON T5."TransId" = T6."TransId" 
              WHERE T5.Account = T1.Account
              AND T5.OcrCode2 = T1.OcrCode2
              AND T6."RefDate" < @FromDate) AS "Opening Credit Balance" -- '[%0]'
	   
FROM SUBLEDGER T1
WHERE T1."RefDate" BETWEEN @FromDate And @ToDate   --'[%0]' AND '[%1]'
GROUP BY T1."Account"
              ,T1."AcctName"
              ,T1."OcrCode2"
			  ,T1."PrcName"
END