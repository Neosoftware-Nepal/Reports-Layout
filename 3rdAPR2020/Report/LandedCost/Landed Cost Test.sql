Select Distinct Ifnull(T7."BeginStr",'0') ||''|| T0."DocNum" as "Purchase Invoice Number"
	,T0."DocEntry" 
	,Ifnull(T10."BeginStr",'0') ||''|| T8."DocNum" as "Purchase Order Number"
	,T6."DocDate" as "Date"
	,T6."SuppName" as "VendorName"
	,T0."U_LC" as "LC(Payment Mode)"
	,T16."ItmsGrpNam" as "Business(Profit Center)"
	,T2."ItemCode" as "SKUCode"
	,T2."Dscription" as "SKUName"
	,T1."InvQty" as "Inverntry Quantity" 
	,T1."Quantity" as "Purchase Quantity"
	,T0."DocCur" as "Currency"
	,T1."Price" as "RealAltLc"
	,T1."LineTotal" as "Line Total" 
	,T0."DocTotal" as "TotalBillAmtDisplay"
	,T0."DocRate" as "Currency Rate"
	,T2."TtlExpndLC" as "LandedCostLC"
	,T2."Quantity" as "LandedCostQty"
	,T0."U_PPNo" as "PPNumber"
	,T0."U_PPDat" as "PPDate"
	,(T2."FobValue"+T2."TtlExpndLC") as "Total Cost"
	,T14."CostSum"
	,T15."AlcCode"
	 ,Case When T15."AlcName" = 'LC COMMISSION'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "LC COMMISSION"
	 ,Case When T15."AlcName" = 'TRANSIT INSURANCE'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "TRANSIT INSURANCE"
	 ,Case When T15."AlcName" = 'KOLKATA PORT CLEARING CHARGES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "KOLKATA PORT CLEARING CHARGES"
	 ,Case When T15."AlcName" = 'DETENTION CHARGES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "DETENTION CHARGES"	
	 ,Case When T15."AlcName" = 'DETENTION CHARGES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "KOLKATA TO BRJ TRANSPORTATION CHARGES"
	 ,Case When T15."AlcName" = 'KOLKATA TO BRJ TRANSPORTATION CHARGES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "KOLKATA TO BRJ TRANSPORTATION CHARGES"
	  ,Case When T15."AlcName" = 'ImportDutyP'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "ImportDutyP"
	  ,Case When T15."AlcName" = 'Excise Duty'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "Excise Duty"
	  ,Case When T15."AlcName" = 'Clearing Agent Charge'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "Clearing Agent Charge"		
	  ,Case When T15."AlcName" = 'CUSTOMS CLEARING EXPENSES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "CUSTOMS CLEARING EXPENSES"		
	  ,Case When T15."AlcName" = 'CSF CHARGES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "CSF CHARGES"		
	 ,Case When T15."AlcName" = 'BRJ to KTM Transportation Expe'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "BRJ to KTM Transportation Expe"
	 ,Case When T15."AlcName" = 'LOAD UNLOAD GODOWN EXPENSES'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "LOAD UNLOAD GODOWN EXPENSES"
	 ,Case When T15."AlcName" = 'Other Purchase Cost'
	 		Then T14."CostSum"
	 		Else 0
	 		End as "Other Purchase Cost"  
	--Delivery Term

from OPCH T0
Inner Join PCH1 T1 ON T0."DocEntry" = T1."DocEntry"
Left Join IPF1 T2 ON T1."DocEntry" = T2."BaseEntry" and T2."LineNum" = T1."BaseLine" and T1."ObjType" = T2."BaseType"
--Left Join OPRQ T3 ON T3."DocEntry" = T0."DocEntry"
--Left Join OCRD T4 ON T0."CardCode" = T4."CardCode"
--Inner JOin PRQ1	T5 ON T3."DocEntry" = T5."DocEntry"
Inner Join OIPF T6 ON T6."DocEntry" = T2."DocEntry"
Left Join PDN1 T12 On T1."BaseEntry" = T12."DocEntry" --and T12."ObjType" = 20
Left join OPDN T13 ON T12."DocEntry" = T13."DocEntry"
LEFT JOIN NNM1 T7 ON T0."Series" = T7."Series"
Left Join POR1 T11 ON T12."BaseEntry" = T11."DocEntry" --and T11."ObjType" = 22
LEFT JOIN OPOR T8 ON T11."DocEntry" = T8."DocEntry"
LEFT JOIN OITM T9 ON T1."ItemCode" = T9."ItemCode"
Left Join OITB T16 On T9."ItmsGrpCod" = T16."ItmsGrpCod"
Left JOIN IPF2 T14 ON T2."DocEntry" = T14."DocEntry"
Left Join NNM1 T10 On T8."Series" = T10."Series"
Left Join OALC T15 On T14."AlcCode" = T15."AlcCode" 