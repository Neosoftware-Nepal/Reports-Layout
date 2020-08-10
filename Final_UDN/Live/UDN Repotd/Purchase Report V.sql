
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