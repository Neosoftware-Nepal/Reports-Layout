USE  [TESTING]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_PurchaseInvoice]    Script Date: 19/02/2020 11:10:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_ITN_PurchaseInvoice] (@DocKey INT)
AS
BEGIN
	SELECT 	Distinct	T0."DocEntry"
		,T0."DocNum"
		,T0."DocStatus" AS "DocStatus"
		,T0."Printed" AS "PrintStatus"
		,T0."U_ITN_Print_Count"
		,T0."DocDate" as "DocDate"
		,T0."DocDueDate" AS "Due Date"
		,T0."DocTotal" As "DocTotal"
		,T0."CardCode"
		,T0."CardName"
		,T0."DocCur" AS "Currency"
		,T0."Comments" AS "Remarks"
		,T0."NumAtCard" AS "VendorRefNo"
		,T0."DiscPrcnt" AS "Discount%"
		,T0."DiscSum" AS "DiscountSum"
		,T0."GSTTranTyp" AS "TransactionType"
		,T0."CntctCode" AS "Contact Person"
		,T0."U_ITN_PPD" AS "PPDate"
		,T0."U_ITN_PP" AS "PPNo."
		,T0."TaxDate" AS "TaxDate"
		,T0."U_ITN_NPDate" AS "Miti"
		,T0."U_ITN_WO" as "Work Order No."
		--,[dbo].[ITN_NEPALI_FMT_DATE](OPDN."U_ITN_NPDate") AS "GRNNpDt"
		--,[dbo].[ITN_NEPALI_FMT_DATE](OPOR."U_ITN_NPDate") AS "PurchaseorderNpDt"

		/*  Vendor Details  */
		,T17."Address" as "V Address"
		,T2."TaxId4" as "Vendor PAN"
		,T16."Phone1"
		,T16."E_Mail"
		,T17."Street" As "Vendor Address"

		/*  Location Details   */
		,l.Location as "Issued from"
		,T1."LocCode"

		/*  Ware House Location */
		,OW1."WhsName" AS "Location"
		,OW1."U_ITN_Email" as "LocationEmail"
		,ow1."U_ITN_Phone" as "LocationPhone"
		,ow1."Location" as "Issued from"

		

		/*  Billing and shiping address  */
		,T0."ShipToCode"
		,T0."Address" AS "BilToAdrs"


	    /*   Line Details */
		,T1."ItemCode" 
		,T1."Quantity"
		, T1."Dscription" As "Description"
		,T1."AcctCode" As "General Ledger"
		,T5."AcctName" AS "G/L Account Name" 
		,T1."TaxCode" AS "TaxCode"
		,T1."WtCalced" 
		,T1."LocCode" AS "LineLocation"
		,T1."Price" AS "Price"
		,T1."PriceBefDi" AS "PriceBeforeDiscount"
		,T1."LineVat" As "VATAmt"
		,T1."DiscPrcnt"
		,((T1."DiscPrcnt" / 100) * T1."LineTotal") as "DisAmt"
		,T1."LineTotal"

		/*  VAT AMOUNT  */
		,isnull((SELECT sum(TX.TaxSum) FROM PCH4 TX WHERE TX.DocEntry=T0.DocEntry and CharIndex('EX',  TX.StaCode) = 1),0) AS "LineExcise"
		,isnull((SELECT sum(TX.TaxSum) FROM PCH4 TX WHERE TX.DocEntry=T0.DocEntry and CharIndex('VAT',  TX.StaCode) = 1), 0) AS "LineVAT"
		,(SELECT "TaxRate" FROM PCH4 TX WHERE TX.DocEntry=T0.DocEntry and TX."staType" = 7) as "EXPct"
		

		/*  User Details */
		,OUSR."USER_CODE"

		
	FROM OPCH T0	
	INNER JOIN PCH1 T1 ON T0.DocEntry = T1.DocEntry
	LEFT JOIN CRD7 T2 ON T0."CardCode" = T2."CardCode"
	left join OWHS OW1 ON T1.WhsCode = OW1.WhsCode
	LEFT JOIN OADM ON 1 = 1
	LEFT JOIN OACT T5 On T5.AcctCode = T1.AcctCode
	LEFT JOIN OCRD T16 ON T16."CardCode" = T0."CardCode"
	LEFT JOIN CRD1 T17 ON T16."CardCode" = T17."CardCode"
	LEFT JOIN OLCT L ON L."Code" = OW1."Location"
	LEFT JOIN OCPR M ON M."CntctCode" = T0."CntctCode"
		AND M."CardCode" = T0."CardCode"
	LEFT JOIN OUSR ON T0."UserSign" = OUSR."USERID"

--LEFT JOIN RDR4 RD ON RD.DocEntry=T1.DocEntry	

	WHERE T0."DocType" = 'I' and T0."DocEntry" = @DocKey;
END









