USE [TESTING]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_StockSummaryTest]    Script Date: 18/05/2020 4:24:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_ITN_StockSummaryTest] (@FromDate DATE
	,@ToDate DATE)

AS
Begin


with TotalCTE as ( SELECT "ItemCode"
		,"Dscription"
		,"Warehouse"
		,Sum(ISNULL("A/R Invoices",0)) AS "A/R Invoices"
		,sum(ISNULL("A/R Credit Memos",0)) AS "A/R Credit Memos"
		,sum(ISNULL("Deliveries",0)) AS "Deliveries"
		,sum(ISNULL("Returns",0)) AS "Returns"
		,sum(ISNULL("A/P Invoices",0)) AS "A/P Invoices"
		,sum(ISNULL("A/P Credit Memos",0)) AS "A/P Credit Memos"
		,sum(ISNULL("Goods Receipt PO",0)) AS "Goods Receipt PO"
		,sum(ISNULL("Goods Return",0)) AS "Goods Return"
		,sum(ISNULL("Receipt from Production",0)) AS "Receipt from Production"
		,sum(ISNULL("Goods Receipt",0)) AS "Goods Receipt"
		,sum(ISNULL("Issue for Production",0)) AS "Issue for Production"
		,sum(ISNULL("Goods Issue",0)) AS "Goods Issue"
		,sum(ISNULL("Inventory Transfers",0)) AS "Inventory Transfers"
		,sum(ISNULL("Inventory Transfer Receipt",0)) AS "Inventory Transfer Receipt"
		,sum(ISNULL("Landed Cost",0)) as "Landed Cost"
		,sum(ISNULL("Inventory Posting",0)) as "Inventory Posting"
		,sum(ISNULL("Inventory Revaluation", 0)) as "Inventory Revalutaion"
	FROM dbo.VW_ITN_TransTypePivot 
	WHERE "DocDate" between CONVERT(VARCHAR, @FromDate, 112)
	AND  CONVERT(VARCHAR, @ToDate, 112 )
		/*AND "Warehouse" = :Warehouse
		AND "ItemCode" = :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse"
		,"Dscription"),

ValueCTE as ( SELECT "ItemCode"
		,"Warehouse"
		,Sum(ISNULL("A/R Invoices Value",0)) as "A/R Invoices Value"
		,Sum(ISNULL("A/R Credit Memos Value",0)) as "A/R Credit Memos Value"
		,Sum(ISNULL("Deliveries Value",0)) as "Deliveries Value"
		,Sum(ISNULL("Returns Value",0)) as "Returns Value"
		,Sum(ISNULL("A/P Invoices Value",0)) as "A/P Invoices Value"
		,Sum(ISNULL("A/P Credit Memos Value",0)) as "A/P Credit Memos Value"
		,Sum(ISNULL("Goods Receipt PO Value",0)) as "Goods Receipt PO Value"
		,Sum(ISNULL("Goods Return Value",0)) as "Goods Return Value"
		,Sum(ISNULL("Receipt from Production Value",0)) as "Receipt from Production Value"
		,Sum(ISNULL("Goods Receipt Value",0)) as "Goods Receipt Value"
		,Sum(ISNULL("Issue for Production Value",0)) as "Issue for Production Value"
		,Sum(ISNULL("Goods Issue Value ", 0)) as "Goods Issue Value" 
		,Sum(ISNULL("Inventory Transfers Value",0)) as "Inventory Transfers Value"
		,Sum(ISNULL("Inventory Transfers Receipt Value",0)) as "Inventory Transfers Receipt Value"
		,sum(ISNULL("Landed Cost Value",0)) as "Landed Cost Value"
		,sum(ISNULL("Inventory Posting Value",0)) as "Inventory Posting Value"
		,sum(ISNULL("Inventory Revaluation Value", 0)) as "Inventory Revalutaion Value"
	FROM dbo.VW_ITN_TransTypeValuePivot 
	WHERE "DocDate" between CONVERT(VARCHAR, @FromDate, 112)
	AND  CONVERT(VARCHAR, @ToDate, 112 )
	/*and "Warehouse" = :Warehouse
	and "ItemCode" =  :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse"),
		
OpeningBalCTE as( SELECT "Warehouse"
		,"ItemCode"
		,Sum(ISNULL("InQty",0)) - sum(ISNULL("OutQty",0)) AS "Opening Balance"
		,Sum(ISNULL("TransValue",0)) as "Opening Balance Value"
	FROM OINM
	WHERE "DocDate" < CONVERT(VARCHAR, @FromDate, 112)
		/*AND "Warehouse" = :Warehouse
		AND "ItemCode" = :ItemCode*/
	GROUP BY "Warehouse"
		,"ItemCode"
		,"Dscription"),
ClosingCTE as ( SELECT "Warehouse"
		,"ItemCode"
		,sum(ISNULL("InQty",0)) - sum(ISNULL("OutQty",0)) AS "Closing Balance"
		,Sum(ISNULL("TransValue",0)) as "Closing Value"
	FROM OINM
	WHERE "DocDate" between CONVERT(VARCHAR, @FromDate, 112)
	AND  CONVERT(VARCHAR, @ToDate, 112 )
	--and "DocDate"<= Convert (Varchar, @ToDate, 'YYYY-MM-DD')
	/*and "Warehouse" = :Warehouse
	and "ItemCode" =  :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse")

SELECT T."ItemCode"
	,T."Warehouse"
	,T."Dscription"
	,ISNULL(O."Opening Balance",0) as "Opening Balance"
	,ISNULL(O."Opening Balance Value",0) as "Opening Balance Value"
	,"A/R Invoices"
	,"A/R Invoices Value"
	,"A/R Credit Memos"
	,"A/R Credit Memos Value"
	,"Deliveries"
	,"Deliveries Value"
	,"Returns"
	,"Returns Value"
	,"A/P Invoices"
	,"A/P Invoices Value"
	,"A/P Credit Memos"
	,"A/P Credit Memos Value"
	,"Goods Receipt PO"
	,"Goods Receipt PO Value"
	,"Goods Return"
	,"Goods Return Value"
	,"Receipt from Production"
	,"Receipt from Production Value"
	,"Issue for Production"
	,"Issue for Production Value"
	,"Goods Issue"
	,"Goods Receipt"
	,"Goods Issue Value"
	,"Goods Receipt Value"
	,"Inventory Transfers"
	,"Inventory Transfers Value"
	,"Inventory Transfer Receipt"
	,"Inventory Transfers Receipt Value"
	,"Landed Cost"
	,"Landed Cost Value"
	,"Inventory Posting"
	,"Inventory Posting Value"
	,"Inventory Revalutaion"
	,"Inventory Revalutaion Value"

	,ISNULL((C."Closing Balance"),0) as "Closing Balance"
	,ISNULL((C."Closing Value"),0) as "Closing Value"
	--,ISNULL(("Opening Balance" + "Closing Balance"),0) as "Closing Balance"
	--,ISNULL(("Opening Balance Value" + "Closing Value"),0) as "Closing Value"
	--,T1."U_ITN_PRDW"
	,(([Opening Balance] + [A/R Credit Memos] + [Returns] + [A/P Invoices] + [Goods Receipt PO] + [Receipt from Production] ) - ([A/R Invoices] + [Deliveries] + [A/P Credit Memos] + [Goods Return] + [Issue for Production])) as ABC
FROM TotalCTE T 
Left JOIN ValueCTE V ON T."ItemCode" = V."ItemCode"
	AND T."Warehouse" = V."Warehouse"
LEFT JOIN OpeningBalCTE O ON T."ItemCode" = O."ItemCode"
	AND T."Warehouse" = O."Warehouse"
LEFT JOIN ClosingCTE C ON T."ItemCode" = C."ItemCode"
	AND T."Warehouse" = C."Warehouse"
--LEFT JOIN IGE1 T1 ON T."ItemCode" = T1."ItemCode"
Order By T."ItemCode";
END