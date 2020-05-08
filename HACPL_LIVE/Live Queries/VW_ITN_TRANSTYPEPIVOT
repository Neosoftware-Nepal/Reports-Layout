CREATE VIEW "YDPL_LIVE"."VW_ITN_TRANSTYPEPIVOT" ( "ItemCode",
	 "Dscription",
	 "Warehouse",
	 "DocDate",
	 "A/R Invoices",
	 "A/R Credit Memos",
	 "Deliveries",
	 "Returns",
	 "A/P Invoices",
	 "A/P Credit Memos",
	 "Goods Receipt PO",
	 "Goods Return",
	 "Receipt from Production",
	 "Issue for Production",
	 "Inventory Transfers" ) AS SELECT
	 "ItemCode" ,
	 "Dscription" ,
	 "Warehouse" ,
	 "DocDate" ,
	 CASE WHEN "TransType" = 13 
THEN IfNull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "A/R Invoices" ,
	 CASE WHEN "TransType" = 14 
THEN IfNull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "A/R Credit Memos" ,
	 CASE WHEN "TransType" = 15 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Deliveries" ,
	 CASE WHEN "TransType" = 16 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Returns" ,
	 CASE WHEN "TransType" = 18 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "A/P Invoices" ,
	 CASE WHEN "TransType" = 19 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "A/P Credit Memos" ,
	 CASE WHEN "TransType" = 20 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Goods Receipt PO" ,
	 CASE WHEN "TransType" = 21 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Goods Return" ,
	 CASE WHEN "TransType" = 59 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Receipt from Production" ,
	 CASE WHEN "TransType" = 60 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Issue for Production" ,
	 CASE WHEN "TransType" = 67 
THEN Ifnull("InQty",
	 0) - Ifnull("OutQty",
	 0) 
END AS "Inventory Transfers" 
FROM OINM WITH READ ONLY