Alter PROCEDURE "SP_ITN_OutgoingPayment"(IN DocKey INT)
	AS
	BEGIN
select  'OutGoingPayment'
	,TO_NVARCHAR(T2."DocDate",'YYYY/MM/DD') AS "DocDate"
	,T2."Comments" as "Remark"
	,T2."DocNum"
	,T3."FormatCode"
	,T2."PrjCode"
	,T3."AcctName" AS "AccountName"
	,T1."LineMemo"
	,T1."Debit"
	,T1."Credit"
		--,SUBSTRING(T2."U_ITN_NPDate", 0, 4) || '/' || SUBSTRING(T2."U_ITN_NPDate", 5, 2) || '/' || SUBSTRING(T2."U_ITN_NPDate", 7, 2) AS "NP Date"
	,IFNULL(T4."SeriesName", '') || '' || CAST(T2."DocNum" AS CHAR(20)) AS "Voucher No"
	,IFNULL(T5."PrcName",'') AS "Employee"
	,IFNULL(T6."PrcName",'') AS "Department"
	,IFNULL(T7."PrcName",'') AS "Division"
	,IFNULL(T8."PrcName",'') AS "Asset"
	,IFNULL(T9."PrcName",'') AS "Others"
	

,CASE 
		WHEN T10."Descrip" != ''
			THEN T10."Descrip"
		ELSE T0."Memo"
		END AS "Rmk"
	,T0."TransId"
	,T2."TransId" AS "DCno"
	,T2."DocEntry"
	
	,B."U_NAME"
	,T2."Canceled"
	
	,CASE 
	    WHEN  T2."CashSum" <> 0
	         THEN 'Cash Payment'
	    WHEN T2."CreditSum"<>  0
	         THEN 'Credit Payment'
	    WHEN T2."CheckSum" <>  0
	         THEN 'Cheque Payment'
	    WHEN T2."TrsfrSum"<> 0
	        THEN 'Bank  Payment'
    END AS "PaymentType"  
    ,T13."NumAtCard"
    ,T13."CardCode"
    ,T13."CardName"
    ,T13."DocDate" as "Invoice Date"
    ,IFNULL(T15."BeginStr", '') 
    || '' ||CAST(T13."DocNum" AS CHAR(20)) 
    || '' || IFNULL(T15."EndStr", '') as "Invoice Number"
    ,T11."Address"
    ,T2."JrnlMemo" as "Narration"
    ,T14."CheckNum"
    ,T2."DocCurr"
    ,DS."BankName"
    ,DS."BankCode"
  
from  OJDT T0
INNER JOIN JDT1 T1 ON T0."TransId" = T1."TransId"
inner JOIN OVPM T2 ON T1."TransId" = T2."TransId"
Left Join VPM1 T14 ON T2."DocEntry" = T14."DocNum"
inner join ODSC DS on T14."BankCode" = DS."BankCode"
LEFT JOIN OACT T3 ON T1."ShortName" = T3."AcctCode"
LEFT JOIN NNM1 T4 ON T4."Series" = T2."Series"
LEFT JOIN OPRC T5 ON T5."PrcCode" = T1."ProfitCode"
LEFT JOIN OPRC T6 ON T6."PrcCode" = T1."OcrCode2"
LEFT JOIN OPRC T7 ON T7."PrcCode" = T1."OcrCode3"
LEFT JOIN OPRC T8 ON T8."PrcCode" = T1."OcrCode4"
LEFT JOIN OPRC T9 ON T9."PrcCode" = T1."OcrCode5"
LEFT JOIN VPM4 T10 ON T10."DocNum" = T2."DocEntry"
	AND T10."AcctCode" = T1."Account"
	AND T10."LineId" = T1."Line_ID" - 1
LEFT JOIN OCRD T11 ON T11."CardCode" = T1."ShortName"
Left JOIN OUSR B ON T0."UserSign" = B."INTERNAL_K"
LEFT JOIN OPCH T13 ON T13."DocEntry" = T2."DocEntry"
LEFT JOIN NNM1 T15 ON T13."Series" = T15."Series"
WHERE T2."DocEntry"=:DocKey
ORDER BY T1."Line_ID";
END







