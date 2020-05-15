USE [TESTING]
GO

/****** Object:  View [dbo].[VW_ITN_TransTypeValuePivot]    Script Date: 15/05/2020 7:38:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE View [dbo].[VW_ITN_TransTypeValuePivot] as 
 
 SELECT  ItemCode
 , Warehouse
 , DocDate

 --A/R Invoice
 , CASE WHEN "TransType" = 13 
 THEN ISNULL("TransValue", 0) 
 END AS "A/R Invoices Value"


 --A/R Credit Memo/ A/R Sales Return
 , CASE WHEN "TransType" = 14 
 THEN ISNULL("TransValue", 0) 
END AS "A/R Credit Memos Value"


-- Delivery
, CASE WHEN "TransType" = 15 
THEN ISNULL("TransValue", 0)
 END AS "Deliveries Value",
 
 
  --A/R Returns
 CASE WHEN "TransType" = 16 
 THEN ISNULL("TransValue", 0) 
 END AS "Returns Value", 


  --A/P Invoice/ Purchase Invocie
CASE WHEN "TransType" = 18 
THEN ISNULL("TransValue", 0) 
END AS "A/P Invoices Value"


--A/P Credit Memo/ Purchase Return
, CASE WHEN "TransType" = 19 
THEN ISNULL("TransValue", 0) 
END AS "A/P Credit Memos Value"


--Goods Receipt PO
, CASE WHEN "TransType" = 20 
THEN ISNULL("TransValue", 0) 
END AS "Goods Receipt PO Value"


--Goods Return
, CASE WHEN "TransType" = 21 
THEN ISNULL("TransValue", 0) 
END AS "Goods Return Value", 


 --Receipt from Production
CASE WHEN "TransType" = 59 and "ApplObj" = 202
THEN ISNULL("TransValue", 0) 
END AS "Receipt from Production Value"

--Goods Receipt
,CASE WHEN "TransType" = 59  and "ApplObj" = -1
THEN ISNULL("TransValue", 0) 
END AS "Goods Receipt Value"


--Issue for Production
, CASE WHEN "TransType" = 60 and "ApplObj" = 202
 THEN ISNULL("TransValue", 0) 
 END AS "Issue for Production Value"

 --Goods Issue
 , CASE WHEN "TransType" = 60 and "ApplObj" = -1
 THEN ISNULL("TransValue", 0) 
 END AS "Goods Issue Value "


 --Inventory Transfers
, CASE WHEN "TransType" = 67 
THEN ISNULL("TransValue", 0) 
END AS "Inventory Transfers Value"


 --Inventory Transfers Receipt
, CASE WHEN "TransType" = 67 
THEN ISNULL("TransValue", 0) 
END AS "Inventory Transfers Receipt Value"


--Landed Cost
, CASE WHEN "TransType" = 69  
THEN ISNULL("TransValue", 0) 
END AS "Landed Cost Value"

--Inventory Posting
, CASE WHEN "TransType" = 10000071   
THEN ISNULL("TransValue", 0) 
END AS "Inventory Posting Value"


--Inventory Revaluation
, CASE WHEN "TransType" = 162  
THEN ISNULL("TransValue", 0) 
END AS "Inventory Revaluation Value"

FROM   dbo.OINM 
GO


