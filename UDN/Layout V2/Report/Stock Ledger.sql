CREATE PROCEDURE SP_ITN_StockLedger (IN FromDate DATE
	,In ToDate DATE)
LANGUAGE SQLSCRIPT 
SQL SECURITY INVOKER
READS SQL DATA
AS
Begin
TotalCTE = SELECT "ItemCode"
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
		,sum(IFNULL("Issue for Production ",0)) AS "Issue for Production"
		,sum(IFNULL("Inventory Transfers ",0)) AS "Inventory Transfers"
	FROM VW_ITN_TRANSTYPEPIVOT 
	WHERE "DocDate" >= TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
		AND "DocDate" <= TO_TIMESTAMP (:ToDate, 'YYYY-MM-DD')
		/*AND "Warehouse" = :Warehouse
		AND "ItemCode" = :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse"
		,"Dscription";
ValueCTE = SELECT "ItemCode"
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
		,Sum(IFNULL("Issue for Production Value",0)) as "Issue for Production Value"
		,Sum(IFNULL("Inventory Transfers Value",0)) as "Inventory Transfers Value"
	FROM VW_ITN_TransTypeValuePivot  
	WHERE "DocDate" >=TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
	and "DocDate"<=TO_TIMESTAMP (:ToDate, 'YYYY-MM-DD')
	/*and "Warehouse" = :Warehouse
	and "ItemCode" =  :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse";
		
OpeningBalCTE = SELECT "Warehouse"
		,"ItemCode"
		,Sum(IFNULL("InQty",0)) - sum(IFNULL("OutQty",0)) AS "Opening Balance"
		,Sum(IFNULL("TransValue",0)) as "Opening Balance Value"
	FROM OINM
	WHERE "DocDate" < TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
		/*AND "Warehouse" = :Warehouse
		AND "ItemCode" = :ItemCode*/
	GROUP BY "Warehouse"
		,"ItemCode"
		,"Dscription";
ClosingCTE = SELECT "Warehouse"
		,"ItemCode"
		,sum(IFNULL("InQty",0)) - sum(IFNULL("OutQty",0)) AS "Closing Balance"
		,Sum(IFNULL("TransValue",0)) as "Closing Value"
	FROM OINM
	WHERE "DocDate" >= TO_TIMESTAMP (:FromDate, 'YYYY-MM-DD')
	and "DocDate"<= TO_TIMESTAMP (:ToDate, 'YYYY-MM-DD')
	/*and "Warehouse" = :Warehouse
	and "ItemCode" =  :ItemCode*/
	GROUP BY "ItemCode"
		,"Warehouse";

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
	,"Inventory Transfers"
	,"Inventory Transfers Value"
	,IFNULL(("Opening Balance" + "Closing Balance"),0) as "Closing Balance"
	,IFNULL(("Opening Balance Value" + "Closing Value"),0) as "Closing Balance Value"
FROM :TotalCTE T 
Left JOIN :ValueCTE V ON T."ItemCode" = V."ItemCode"
	AND T."Warehouse" = V."Warehouse"
LEFT JOIN :OpeningBalCTE O ON T."ItemCode" = O."ItemCode"
	AND T."Warehouse" = O."Warehouse"
LEFT JOIN :ClosingCTE C ON T."ItemCode" = C."ItemCode"
	AND T."Warehouse" = C."Warehouse"
Order By T."ItemCode";
END