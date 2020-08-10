Select /*  Sales Order       */
		T0."DocEntry"
		,T0."DocNum"
		,IFNULL(S0."BeginStr", '0') ||''|| CAST(T0."DocNum" as CHAR(20)) as "SO Document Number"
		,T0."DocDate"
		,T0."CardCode"
		,C0."CardName" as "Customer Name"
		,C0."Address" as "BP Address"
		,W0."WhsName" as "Location"
		
		,IFNULL(S3."BeginStr", '0') ||''|| CAST(T7."DocNum" as CHAR(20)) as "SalesRequest Document Number"
		,IFNULL(S4."BeginStr", '0') ||''|| CAST(T8."DocNum" as CHAR(20)) as "GatePass Document Number"

		,T1."Dscription" as "Sku Name"
		,T9."NumInBuy" as "CTN"
		,T1."U_QCASE" as "Total Cases"
		,T1."U_ExtraPcs" as "QTY(PCS)"
		,T1."Quantity" as "Qty in PCS"
		,T1."unitMsr" as "Sales UOM"
		,T17."UomName" as "UOM Group"
		,T1."Price" as "Rate"
		,T1."LineTotal" as "Gross Amount"
		,IFNULL(T1."U_ITNPRODISPR", 0) as "Promotion Discount Percent"
		,T1."U_ITNPRODISAM" as "Promotion Discount Amount"
		,T0."DocTotal" - T0."VatSum" as "Taxable Amount"
		,T0."VatSum"
		,T0."DocTotal" as "Total Amount"
		,T15."ItmsGrpNam" as "Business Unit"
		,T9."U_BRND" as "Brand"
		,T9."U_SUBBRND" as "Sub Brand"
		,T14."U_NAME" as "Creator"
		,T10."Address" as "Ship To Address"
		,T11."TaxId4" as "Customer PAN"
		,Ifnull(T12."Phone1",T12."Phone2") as "Contact No"
		,T9."U_SBRNDFRM" as "Sub Brand Firm"
		,T13."Building" as "Billing Town"
		

--,IFNULL(S1."BeginStr", '0') ||''|| CAST(T3."DocNum" as CHAR(20)) as "Delivery Document Number"
		
		--,T2."ObjType"
--, T2."BaseEntry",T1."LineNum",T2."BaseLine",  T2."DocEntry", T3."DocEntry", T4."DocEntry", T5."DocEntry" 
From ORDR T0
Inner Join RDR1 T1 ON T0."DocEntry" = T1."DocEntry"
Inner Join NNM1 S0 ON T0."Series" = S0."Series"
Left Join OCRD C0 ON T0."CardCode" = C0."CardCode"
Left Join OWHS W0 On T1."WhsCode" = W0."WhsCode"


Left JOin DLN1 T2 ON T1."TargetType" = T2."ObjType" and T1."DocEntry" = T2."BaseEntry"
			And T1."LineNum" = T2."BaseLine"
Left Join ODLN T3 On T2."DocEntry" = T3."DocEntry"
Inner Join NNM1 S1 ON T3."Series" = S1."Series"

Left Join INV1	T4 On T2."TargetType" = T4."ObjType" and T2."DocEntry" = T4."BaseEntry"
			And T2."LineNum" = T4."BaseLine"
Left Join OINV T5 On T4."DocEntry" = T5."DocEntry"
Inner Join NNM1 S2 ON T5."Series" = S2."Series"


Left Join QUT1 T6 On T1."DocEntry" = T6."TrgetEntry"
			and T6."TargetType" = T1."ObjType"
			And T6."LineNum" = T1."BaseLine"
Left Join OQUT T7 On T6."DocEntry" = T7."DocEntry"
Inner Join NNM1 S3 ON T7."Series" = S3."Series"

Left Join "@ITN_OGTP" T8 On T5."DocEntry" = T8."DocEntry"
Left Join NNM1 S4 ON T8."Series" = S4."Series"

Inner Join OITM T9 On T1."ItemCode" = T9."ItemCode"
Left Join CRD1 T10 ON T10."CardCode" = T0."CardCode"
		And T10."AdresType" = 'S'
Left Join CRD7 T11 ON T11."CardCode" = T0."CardCode"
		And T11."AddrType" = 'S'
Left Join OCRD T12 On T0."CardCode" = T12."CardCode"
Left Join CRD1 T13 ON T13."CardCode" = T0."CardCode"
		And T13."AdresType" = 'B'
Inner Join OUSR	T14 On T0."UserSign" = T14."USERID"
Inner Join OITB T15 On T9."ItmsGrpCod" = T15."ItmsGrpCod"
Inner Join UGP1 T16 On T9."UgpEntry" = T16."UgpEntry"
Inner Join OUOM	T17 On T16."UomEntry" = T17."UomEntry"
	

