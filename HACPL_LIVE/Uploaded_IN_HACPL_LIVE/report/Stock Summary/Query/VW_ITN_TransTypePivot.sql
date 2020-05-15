USE [TESTING]
GO

/****** Object:  View [dbo].[VW_ITN_TransTypePivot]    Script Date: 15/05/2020 7:29:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[VW_ITN_TransTypePivot] as 
SELECT  ItemCode
, Dscription
, Warehouse
, DocDate

--A/R Invoice
, CASE WHEN "TransType" = 13
	THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0) 
	END AS "A/R Invoices" 

	--A/R Credit Memo/ A/R Sales Return
, CASE WHEN "TransType" = 14 
	THEN ISNULL("InQty", 0)  - ISNULL("OutQty", 0) 
	END AS "A/R Credit Memos"

	-- Delivery 
, CASE WHEN "TransType" = 15 
	 THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	 END AS Deliveries

	 --A/R Returns
, CASE WHEN "TransType" = 16 
	 THEN ISNULL("InQty", 0)  - ISNULL("OutQty", 0) 
	 END AS "Returns"

	 --A/P Invoice/ Purchase Invocie
, CASE WHEN "TransType" = 18 
	THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0) 
	END AS "A/P Invoices"

	--A/P Credit Memo/ Purchase Return
, CASE WHEN "TransType" = 19
	THEN ISNULL("InQty", 0)  - ISNULL("OutQty", 0)
    END AS "A/P Credit Memos"

	--Goods Receipt PO
, CASE WHEN "TransType" = 20
	 THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	 END AS "Goods Receipt PO"

	 --Goods Return
, CASE WHEN "TransType" = 21 
	 THEN ISNULL("InQty", 0)- ISNULL("OutQty", 0)
	 END AS "Goods Return"

	 --Receipt from Production/Goods receipt
, CASE WHEN "TransType" = 59 and "ApplObj" = 202
	  THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	  END AS "Receipt from Production"

 --Goods receipt
, CASE WHEN "TransType" = 59 and "ApplObj" = -1
	  THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	  END AS "Goods Receipt"

	  --Issue for Production
, CASE WHEN "TransType" = 60 and "ApplObj" = 202
	 THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	 END AS "Issue for Production"

	  --Goods Issue
, CASE WHEN "TransType" = 60 and "ApplObj" = -1
	 THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	 END AS "Goods Issue"

	 --Inventory Transfers
, CASE WHEN "TransType" = 67 
	THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	END AS "Inventory Transfers"


	 --Inventory Transfers Receipt
, CASE WHEN "TransType" = 67 
	THEN ABS(ISNULL("InQty", 0) - ISNULL("OutQty", 0))
	END AS "Inventory Transfer Receipt"

	--Landed Cost
, Case When "TransType" = 69 
	THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0) 
	END AS "Landed Cost"

	--Inventory Posting
, Case When "TransType" = 10000071 
	THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0)
	END AS "Inventory Posting"

	--Inventory Revaluation
, Case When "TransType" = 162
	THEN ISNULL("InQty", 0) - ISNULL("OutQty", 0) 
	END AS "Inventory Revaluation"
FROM  dbo.OINM
--where TransNum = 2252
GO


