Select "ListNum" from OCRD


Select * from OPLN


Select * from ITM1 Where ITM1."ItemCode" Like 'BTA%56'


Select distinct  T2."PriceList" ,T1."ListName" ,T2."ItemCode" ,T2."Price"
From OCRD T0
Left Join OPLN T1 ON T0."ListNum" =  T1."ListNum"
Left Join ITM1 T2 ON T1."ListNum" = T2."PriceList"


Select distinct  T0."CardCode" ,T4."PriceList" 
,T3."ListName" 
,T4."ItemCode" 
,T4."Price"
From OQUT T0
LEFT Join QUT1 T1 On T0."DocEntry" = T1."DocEntry"
Inner Join OCRD T2 On T0."CardCode" = T2."CardCode"
Left Join OPLN T3 ON T2."ListNum" =  T3."ListNum"
Left Join ITM1 T4 ON T3."ListNum" = T4."PriceList"
Where $[T1."ItemCode"] = T4."ItemCode"
