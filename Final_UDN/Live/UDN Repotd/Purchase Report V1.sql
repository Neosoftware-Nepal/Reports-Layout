
SELECT COUNT(*) INTO INT_VAL FROM TABLES WHERE TABLE_NAME='POFPI' AND SCHEMA_NAME=CURRENT_SCHEMA;
IF(INT_VAL>0)
THEN 
DROP TABLE POFPI;
END IF;

IF(:BUnit = '')
THEN
BUnit := '%';
END IF;

IF(:DocNum = '')
THEN
DocNum := '%';
END IF;


SELECT BINTOSTR( HEXTOBIN('0D0A') ) --Carriage return line feed
INTO v_crlf
FROM DUMMY;


CREATE COLUMN TABLE POFPI (
"PRDocNum" varchar(15),"PRCardName" varchar(2000),"PRDscription" varchar(200),"PRQuantity" varchar(1000),
 "PONumAtCard" varchar(200), "POItemCode" varchar(30),
"PODscription" varchar(200),"POQuantity" varchar(1000), "PFI" varchar(1000),
"PODocEntry" varchar(20),"DiffItem" varchar(5),
"DiffQty" varchar(5) , "Line" int);

INSERT INTO POFPI (

SELECT distinct cast( T0."DocNum" as varchar(20)) "DocNum",T3."CardName",  T1."Dscription", 
 left(
 cast( T1."Quantity" as varchar(20)),
 length(cast( T1."Quantity" as varchar(20))) -4 ) || ' Cs @ Rs. ' ||
 left(
 cast( T1."Price" as varchar(20)),
 length(cast( T1."Price" as varchar(20))) -4 )
 "Quantity" ,  T3."NumAtCard", T2."ItemCode",
T2."Dscription",
left(
 cast( T2."Quantity" as varchar(20)),
 length(cast( T2."Quantity" as varchar(20))) -4 ) || ' Cs @ Rs. ' || 
 left(
 cast( T2."Price" as varchar(20)),
 length(cast( T2."Price" as varchar(20))) -4 ) 
  "Quantity" ,
  T2."Dscription" || ' [ ' ||
left(
 cast( T2."U_POQTY" as varchar(20)),
 length(cast( T2."U_POQTY" as varchar(20))) -4 ) || ' Cs @ Rs. ' || 
 left(
 cast( T2."U_POPrice" as varchar(20)),
 length(cast( T2."U_POPrice" as varchar(20))) -4 ) || ' ]' "PFI"
  
  
, T2."DocEntry" 
, case when T1."Dscription" <> T2."Dscription" 
		then 'Y' 
		else 'N' 
		end "DiffItem", 
 case when T1."Quantity" <> T2."Quantity" 
 		then 'Y' 
 		else 'N' 
 		end "Diffqty", T2."LineNum"
FROM OPRQ T0 
right JOIN PRQ1 T1 ON T0."DocEntry" = T1."DocEntry" 
right outer join POR1 T2 on (T2."BaseLine" = T1."LineNum" ) 
		and (T2."BaseEntry" = T1."DocEntry"  ) 
right outer join OPOR T3 ON T2."DocEntry" = T3."DocEntry" 
WHERE T0."DocDate" between :FDate and :TDate 
and T0."U_BUNIT" like :BUnit and
 T0."DocEntry" like :DocNum
 union all 
 SELECT distinct (select "BaseRef" 
 					from POR1 
 					where POR1."DocEntry" = T2."DocEntry" 
 								and "BaseLine"=0) "DocNum", T3."CardName", 
  													'' "Dscription", '' "Quantity",  '' "NumAtCard", T2."ItemCode",
													T2."Dscription",left(cast( T2."Quantity" as varchar(20)),
 													length(cast( T2."Quantity" as varchar(20))) -4 ) || ' Cs @ Rs. ' || 
 													left(cast( T2."Price" as varchar(20)),length(cast( T2."Price" as varchar(20))) -4 ) 
  													"Quantity" , '' "PFI",T3."DocEntry" , 'Y' "DiffItem" ,
 													'Y' "Diffqty", T2."LineNum" 
FROM POR1 T2 
join OPOR T3 ON T2."DocEntry" = T3."DocEntry"
 			and T3."DocEntry" in (select distinct "DocEntry" 
 									from POR1 
 									where "BaseEntry" in(SELECT distinct "DocEntry" 
 														FROM OPRQ 
 														where "DocDate" between :FDate and :TDate 
 														and "U_BUNIT" like :BUnit
														and "DocEntry" like :DocNum
 )) 
 WHERE  
 T2."BaseLine" is null and T2."BaseEntry" is null
);

--select * from POFPI;

select "PRDocNum" "PO Number","PRCardName" "Vendor Name",case when "PRDscription" <> '' then "PRDscription" || ' [ ' ||
"PRQuantity" || ' ]' else '' end "PO Information",  
"PONumAtCard" "PFI Vendor RefNo", "PFI" "PFI Initiated [UDN]", "PODscription" || ' [ ' ||
"POQuantity" || ' ]' "PFI Finalized [Vendor]",  T2."U_REFNUM" "CI Vendor RefNo" , 
T1."U_DSCRIPTION" || ' [ ' || left(
 cast( T1."U_CIQTY" as varchar(20)),
 length(cast( T1."U_CIQTY" as varchar(20))) -4 ) || ' Cs @ Rs. ' ||
 left(
 cast( T1."U_UNP" as varchar(20)),
 length(cast( T1."U_UNP" as varchar(20))) -4 )
"CI Information" 
--,"PODocEntry" 
, T4."DocNum" "GRPO No", T3."Dscription" 
|| ' [ ' || left(
 cast( T3."Quantity" as varchar(20)),
 length(cast( T3."Quantity" as varchar(20))) -4 ) || ' Cs @ Rs. ' ||
 left(
 cast( T3."Quantity" as varchar(20)),
 length(cast( T3."Quantity" as varchar(20))) -4 ) "GRPO Information",
"DiffItem" ,
"DiffQty"  , "Line" 
, T6."U_LCCODE" as " LC Name"
, T6."U_LCAMT" as "LC Amt"

from POFPI T0 
left join  "@ITN_CIN1" T1 on T0."Line" = T1."U_POLNO" and T0."POItemCode" = T1."U_SKU"
and T0."PODocEntry" = T1."U_PILNO"
left join "@ITN_OCIN" T2 on T1."DocEntry" = T2."DocEntry" 
left outer join PDN1 T3 on T3."ItemCode" = T0."POItemCode" and T3."BaseEntry" = T0."PODocEntry" and T3."BaseLine" = T0."Line"
and T3."U_CIENTRY" = T2."DocEntry"
left join OPDN T4 on T3."DocEntry" = T4."DocEntry"
Left  Join "@ITN_LOC2" T5 On T0."PONumAtCard" = T5."U_REFNO"
Left Join "@ITN_OLOC" T6 On T5."DocEntry" = T6."DocEntry"
order by "PRDocNum","Line",T2."U_REFNUM";