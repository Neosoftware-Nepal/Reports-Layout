ALTER PROCEDURE "SP_ITN_StockSummaryTest" (IN FromDate DATE
	, IN ToDate DATE)
LANGUAGE SQLSCRIPT 
SQL SECURITY INVOKER
READS SQL DATA
AS
Begin

with TCTE as (  SELECT "ItemCode"
		,"Dscription"
		,"Warehouse"
		,Sum(IFNULL("A/R Invoices ",0)) AS "A/R Invoices"
		,sum(IFNULL("A/R Credit Memos ",0)) AS "A/R Credit Memos"
		,sum(IFNULL("Deliveries ",0)) AS "Deliveries"
		,sum(IFNULL("Returns ",0)) AS "Returns"
		,sum(IFNULL("A/P Invoices ",0)) AS "A/P Invoices"
		,sum(IFNULL("A/P Credit Memos ",0)) AS "A/P Credit Memos"
		,sum(IFNULL("Goods Receipt PO ",0)) AS "Goods Receipt PO"
		,sum(IFNULL("Goods Return ",0)) AS "Goods Return"
		,sum(IFNULL("Receipt from Production ",0)) AS "Receipt from Production"
		,sum(IFNULL("Goods Receipt",0)) AS "Goods Receipt"
		,sum(IFNULL("Issue for Production ",0)) AS "Issue for Production"
		,sum(IFNULL("Goods Issue ",0)) AS "Goods Issue"
		,sum(IFNULL("Inventory Transfers ",0)) AS "Inventory Transfers"
		,sum(IFNULL("Inventory Transfers Receipt ",0)) AS "Inventory Transfer Receipt"
		,sum(IFNULL("Landed Cost ",0)) as "Landed Cost"
		,sum(IFNULL("Inventory Posting ",0)) as "Inventory Posting"
		,sum(IFNULL("Inventory Revaluation ", 0)) as "Inventory Revalutaion"
	FROM VW_ITN_TransTypePivot 
	WHERE "DocDate" between TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
		AND  TO_TIMESTAMP (:ToDate, 'YYYY-MM-DD')
	/*CAST(VARCHAR, :FromDate, 112)
	AND  CAST(VARCHAR, :ToDate, 112 )*/
		/*AND "Warehouse" = :Warehouse
		AND "ItemCode" = :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse"
		,"Dscription"),

VCTE as ( SELECT "ItemCode"
		,"Warehouse"
		,Sum(IFNULL("A/R Invoices Value",0)) as "A/R Invoices Value"
		,Sum(IFNULL("A/R Credit Memos Value",0)) as "A/R Credit Memos Value"
		,Sum(IFNULL("Deliveries Value",0)) as "Deliveries Value"
		,Sum(IFNULL("Returns Value",0)) as "Returns Value"
		,Sum(IFNULL("A/P Invoices Value",0)) as "A/P Invoices Value"
		,Sum(IFNULL("A/P Credit Memos Value",0)) as "A/P Credit Memos Value"
		,Sum(IFNULL("Goods Receipt PO Value",0)) as "Goods Receipt PO Value"
		,Sum(IFNULL("Goods Return value",0)) as "Goods Return Value"
		,Sum(IFNULL("Receipt from Production Value",0)) as "Receipt from Production Value"
		,Sum(IFNULL("Goods Receipt Value",0)) as "Goods Receipt Value"
		,Sum(IFNULL("Issue for Production Value",0)) as "Issue for Production Value"
		,Sum(IFNULL("Goods Issue Value ", 0)) as "Goods Issue Value" 
		,Sum(IFNULL("Inventory Transfers Value",0)) as "Inventory Transfers Value"
		,Sum(IFNULL("Inventory Transfers Receipt Value",0)) as "Inventory Transfers Receipt Value"
		,sum(IFNULL("Landed Cost Value",0)) as "Landed Cost Value"
		,sum(IFNULL("Inventory Posting Value",0)) as "Inventory Posting Value"
		,sum(IFNULL("Inventory Revaluation Value", 0)) as "Inventory Revalutaion Value"
	FROM VW_ITN_TransTypeValuePivot 
	WHERE "DocDate" between TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
		AND  TO_TIMESTAMP (:ToDate, 'YYYY-MM-DD')
	/*CAST(VARCHAR, :FromDate, 112)
	AND  CAST(VARCHAR, :ToDate, 112 )*/
	/*and "Warehouse" = :Warehouse
	and "ItemCode" =  :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse"),
		
OBCTE as ( SELECT "Warehouse"
		,"ItemCode"
		,Sum(IFNULL("InQty",0)) - sum(IFNULL("OutQty",0)) AS "Opening Balance"
		,Sum(IFNULL("TransValue",0)) as "Opening Balance Value"
	FROM OINM
	WHERE "DocDate" < TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
		--AND  TO_TIMESTAMP (:ToDate, 'YYYY-MM-DD')
	--CONVERT(VARCHAR, :FromDate, 112)
		/*AND "Warehouse" = :Warehouse
		AND "ItemCode" = :ItemCode*/
	GROUP BY "Warehouse"
		,"ItemCode"
		,"Dscription"),
CCTE as ( SELECT "Warehouse"
		,"ItemCode"
		,sum(IFNULL("InQty",0)) - sum(IFNULL("OutQty",0)) AS "Closing Balance"
		,Sum(IFNULL("TransValue",0)) as "Closing Value"
	FROM OINM
	WHERE "DocDate" <= TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
	--CONVERT(VARCHAR, :FromDate, 112)
	--and "DocDate"<= Convert (Varchar, @ToDate, 'YYYY-MM-DD')
	/*and "Warehouse" = :Warehouse
	and "ItemCode" =  :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse")

SELECT T."ItemCode"
	,T."Warehouse"
	,T."Dscription"
	,IFNULL(O."Opening Balance",0) as "Opening Balance"
	,IFNULL(O."Opening Balance Value",0) as "Opening Balance Value"
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

	,C."Closing Balance"
	,C."Closing Value"
	,IFNULL(("Opening Balance" + "Closing Balance"),0) as "Closing Balance1"
	,IFNULL(("Opening Balance Value" + "Closing Value"),0) as "Closing Value1"
	--,T1."U_ITN_PRDW"
	--,(("Opening Balance" + "A/R Credit Memos" + "Returns" + "A/P Invoices" + "Goods Receipt PO" + "Receipt from Production" ) - ("A/R Invoices" + "Deliveries" + "A/P Credit Memos" + "Goods Return" + "Issue for Production")) as ABC
FROM TCTE T 
Left JOIN VCTE V ON T."ItemCode" = V."ItemCode"
	--AND T."Warehouse" = V."Warehouse"
LEFT JOIN OBCTE O ON T."ItemCode" = O."ItemCode"
	AND T."Warehouse" = O."Warehouse"
LEFT JOIN CCTE C ON T."ItemCode" = C."ItemCode"
	AND T."Warehouse" = C."Warehouse"
--LEFT JOIN IGE1 T1 ON T."ItemCode" = T1."ItemCode"
Order By T."ItemCode";
END