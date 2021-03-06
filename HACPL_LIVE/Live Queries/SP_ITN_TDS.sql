USE [TESTING]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_HC_TDS]    Script Date: 16/03/2020 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_ITN_HC_TDS] 
AS 
BEGIN
SELECT T2."DocNum"
	  --,T0."DocDate"
	  
	  , T2."CardCode"
	  , T4."WTCode"
	  , T2."CardName"
	  , T2."BaseAmnt"
	  , T4."Rate"
	  , T4."TaxbleAmnt"
	  , T4."TDSType"
	  , T4."WTAmnt"
	  , T0."BSRCode"
	  , T0."ChallanNo"
	  , T1."DueDate"
	  , T2."DocDate"
	  , T1."CheckNum"
	  , T1."CheckSum" 
	  , T2.DocTotal
	  , T2.WTSum
	  , T2.WTApplied
	  , T2.WTDetails
	  ,T2.DocEntry
	  , T7.Location
	  
	  ,[dbo].ITN_NEPALI_FMT_DATE(T2."U_ITN_NPDate") AS "Purchase Miti"
	  ,ISNULL(T5."BeginStr", '') + CAST(T2."DocNum" AS nvarchar) + ISNULL(CAST(T5."EndStr" AS nvarchar), '') AS "Purchase No"
	
FROM OVPM T0 
INNER JOIN VPM1 T1 ON T0.DocEntry = T1.DocNum 
INNER JOIN OPCH T2 ON T0.DocEntry = T2.DepositNum 
INNER JOIN PCH1 T3 ON T2.DocEntry = T3.DocEntry 
INNER JOIN PCH5 T4 ON T2.DocEntry = T4.AbsEntry 
INNER JOIN NNM1 T5 ON T2.Series = T5.Series
LEFT JOIN OJDT T6 ON T6.TransId = T6.TransId
LEFT JOIN OLCT T7 ON T7.UserSign = T2.UserSign


/*
SELECT T1.WTCode
	  ,T1.Rate
	  ,T1.TaxbleAmnt
	  ,T1.WTAmnt 
from OPCH T0
Left join PCH5 T1 ON */





END
Select PCH5.AbsEntry,PCH5.WTCode, PCH5.Rate, PCH5.TaxbleAmnt, OPCH.DocTotal, OPCH.DocNum
,OPCH.DocEntry, OPCH.WTApplied, OPCH.WTSum, OPCH.WTDetails, OPCH.WTSumFC, OPCH.WTApplied
,OPCH.WTSum from PCH5 left join OPCH on PCH5.AbsEntry = OPCH.DocEntry