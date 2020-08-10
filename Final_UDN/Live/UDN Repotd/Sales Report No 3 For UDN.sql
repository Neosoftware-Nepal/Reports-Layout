Select T0."DocEntry"
		,Ifnull(T2."BeginStr", '0') ||''|| CAST(T0."DocNum" as Char(20)) as "SR Document Number"
		,T0."DocDate" as "SR Date"
		,T0."NumAtCard" as "RefNo"
		,T0."Address"
		,T0."CardCode"
		,T3."CardName" as "Party Name"
		--,T3."Zone"
		,T4."WhsName" as "Warehouse Location / Branch"
		,T6."ItmsGrpNam" as "Business Unit"
		,T0."VatSum" as "Vat Amount"
		,T0."DocTotal" as "Net Amount"
		
		/* Item Details   */
		--,T1."RowNumber"
		,T1."Dscription" as "SKU Name"
		,T5."NumInBuy" as "QTY/Case"
		--,T1."U_ExtraPcs" as "QTY(PCS)"
		--,T1."U_QCASE" as "QTY(Case)"
		--,T1."Rate" as "Rate"
		,T1."Price" as "Rate"
		,IFNULL(T1."U_ITNPRODISPR", 0) as "Promotion Discount Percent"
		,T1."U_ITNPRODISAM" as "Promotion Discount Amount"
		,T0."U_ITNTRDDIS" as "TradeDisPrcnt"
		,T0."U_ITNTRDDISAM" as "Trade Discoount Amount"
		,T1."LineTotal"
		,T5."U_BRND" as "Brand"
		,T5."U_SBRNDFRM" as "Sub Brand Firm"
		,T5."SVolume" as "Kgs"
		,T6."ItmsGrpNam" as "Business"
		
		/*   Sales Return Request */
		,Ifnull(T12."BeginStr", '0') ||''|| CAST(T8."DocNum" as Char(20)) as "RetReq Document Number"
		,T8."DocDate"
		
		/* Sales Invoice Detail   */
		,T9."DocEntry"
		--,T10."DocNum"
		,Ifnull(T11."BeginStr", '0') ||''|| CAST(T10."DocNum" as Char(20)) as "SI Document Number"
		,T10."DocDate" as "SI Date" 
From ORIN T0	
Inner Join RIN1 T1 On T0."DocEntry" = T1."DocEntry"
Left Join NNM1	T2 On T0."Series" = T2."Series"
Left Join OCRD T3 On T0."CardCode" = T3."CardCode"
Left Join OWHS T4 On T1."WhsCode" = T4."WhsCode"
Left Join OITM T5 On T1."ItemCode" = T5."ItemCode"
Inner Join OITB T6 On T5."ItmsGrpCod" = T6."ItmsGrpCod"
Left Join RRR1 T7 on T1."BaseEntry" = T7."DocEntry"
			and T1."BaseType" = T7."ObjType"
			and T1."BaseLine" = T7."LineNum"
Left Join ORRR T8 On T7."DocEntry" = T8."DocEntry"
Inner Join NNM1 T12 On T8."Series" = T12."Series"
Left Join INV1 T9 ON T7."BaseEntry" = T9."DocEntry"
			and T7."BaseType" = T9."ObjType"
			and T7."BaseLine" = T9."LineNum"
Left JOin OINV	T10 On T9."DocEntry" = T10."DocEntry"
Inner Join NNM1 T11 On T10."Series" = T11."Series" 






