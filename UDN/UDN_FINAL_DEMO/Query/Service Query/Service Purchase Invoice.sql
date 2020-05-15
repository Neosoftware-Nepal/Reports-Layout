ALTER PROCEDURE "SP_ITN_ServicePurchaseInvoice" (IN DocKey INT)
AS
BEGIN
	SELECT 		T0."DocEntry"
		,IFNULL(T7."BeginStr", '') 
		|| '' || CAST(T0."DocNum" AS CHAR(20)) 
		|| '' || CAST(T7."EndStr" AS CHAR(20)) as "Invoice Number"
		,T0."DocStatus" AS "DocStatus"
		,T0."Printed" AS "PrintStatus"
		,Case When T0."DocCur" = 'NPR'
			Then 1
			Else T6."Rate" 
			END as "Currency Rate"
		,T0."DocDate" as "Invoice Date"
		,T0."DocDueDate" AS "Due Date"
		,T0."DocTotal" As "DocTotal"
		,T0."VatSum" as "Vat Amount"
		,T0."DocCur" AS "Currency"
		,T0."DocRate" as "CurRate"
		,T0."Comments" AS "Remarks"
		,T0."NumAtCard" AS "VendorRefNo"
		,T0."DiscPrcnt" AS "Discount%"
		,T0."DiscSum" AS "DiscountSum"
		,T0."GSTTranTyp" AS "TransactionType"
		,T0."CntctCode" AS "Contact Person"
		,T0."U_BUSUNIT" as "TAGS"
		,T0."U_LC" as "LC Number."
		,T0."DiscPrcnt" as "Discount Percent"
		,T0."VatPercent" as "Vat Percent"
		,T0."TaxDate" AS "TaxDate"
		,T0."U_ITN_NPDate" AS "Miti"
		,T0."PeyMethod" as "Mode of payment"
		--,[dbo].[ITN_NEPALI_FMT_DATE](OPDN."U_ITN_NPDate") AS "GRNNpDt"
		--,[dbo].[ITN_NEPALI_FMT_DATE](OPOR."U_ITN_NPDate") AS "PurchaseorderNpDt"

		/*  Vendor Details  */
		,T0."CardCode"
		,T0."CardName"
		,T17."Address" as "Vendor Address"
		,T2."TaxId4" as "Vendor PAN"

		/*  Location Details   */
		,l."Location" as "Issued from"
		,T1."LocCode"

		/*  Ware House Location */
		,OW1."WhsName" AS "Location"
		
		,ow1."Location" as "Issued from"

		

		/*  Billing and shiping address  */
		,T0."ShipToCode"
		,T0."Address" AS "BilToAdrs"
		,T0."Address2" as "ShipToAddress"


	    /*   Line Details */
		,T1."ItemCode" 
		,T1."Quantity"
		,T1."Dscription" As "Particulars"
		,T1."AcctCode" As "General Ledger"
		,T5."AcctName" AS "G/L Account Name" 
		,T1."TaxCode" AS "TaxCode"
		,T1."WtCalced" 
		,T1."Quantity" as "Total Quantity"
		,0 as "PCS"
		,T1."unitMsr" as "Unit"
		,T1."Rate" as "Rate(PCS)"
		,T1."LineTotal" as "Amount"
		,T1."LocCode" AS "LineLocation"
		,T1."Price" AS "Price"
		,T1."PriceBefDi" AS "PriceBeforeDiscount"
		,T1."LineVat" As "VATAmt"
		,T1."DiscPrcnt"
		,T3."NumInBuy" as "QTY/Case"
		
		,((T1."DiscPrcnt" / 100) * T1."LineTotal") as "DisAmt"
		,T1."LineTotal"

		/*  VAT AMOUNT  */
		--,IFNULL((SELECT sum(TX.TaxSum) FROM PCH4 TX WHERE TX.DocEntry=T0.DocEntry and CharIndex('EX',  TX.StaCode) = 1),0) AS "LineExcise"
		--,IFNULL((SELECT sum(TX.TaxSum) FROM PCH4 TX WHERE TX.DocEntry=T0.DocEntry and CharIndex('VAT',  TX.StaCode) = 1), 0) AS "LineVAT"
		--,(SELECT "TaxRate" FROM PCH4 TX WHERE TX.DocEntry=T0.DocEntry and TX."staType" = 7) as "EXPct"
		,IFNULL((SELECT INV4."TaxSum" FROM INV4 WHERE T0."DocEntry" = INV4."DocEntry" AND INV4."LineNum" = T1."LineNum" AND INV4."staType" = 1), 0) AS "LineVatAmt"
		,IFNULL((SELECT INV4."TaxSum" FROM INV4 WHERE T0."DocEntry" = INV4."DocEntry" AND INV4."LineNum" = T1."LineNum" AND INV4."staType" = 7), 0) AS "LineExciseAmount"
		,IFNULL((SELECT sum(INV4."BaseSum") FROM INV4 WHERE T0."DocEntry" = INV4."DocEntry" AND INV4."LineNum" = T1."LineNum" AND INV4."staType" = 1), 0) AS "TaxableAmount"

		/*  User Details */
		,OUSR."U_NAME" as "Prepared By"
		

		
	FROM OPCH T0	
	INNER JOIN PCH1 T1 ON T0."DocEntry" = T1."DocEntry"
	LEFT JOIN CRD7 T2 ON T0."CardCode" = T2."CardCode"
	Left JOIN OITM T3 ON T1."ItemCode" = T3."ItemCode"
	LEFT JOIN ORTT T6 On T0."DocCur" = T6."Currency"
	left join OWHS OW1 ON T1."WhsCode" = OW1."WhsCode"
	LEFT JOIN OADM ON 1 = 1
	LEFT JOIN OACT T5 On T5."AcctCode" = T1."AcctCode"
	LEFT JOIN OCRD T16 ON T16."CardCode" = T0."CardCode"
	LEFT JOIN CRD1 T17 ON T16."CardCode" = T17."CardCode"
	LEFT JOIN OLCT L ON L."Code" = OW1."Location"
	LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
		AND M."CardCode" = T0."CardCode"
	LEFT JOIN NNM1 T7 ON T0."Series" = T7."Series"
	LEFT JOIN OUSR ON T0."UserSign" = OUSR."USERID"

   --Payment Terms OCTG

	WHERE T0."DocType" = 'S' and T0."DocEntry" = :DocKey;
END