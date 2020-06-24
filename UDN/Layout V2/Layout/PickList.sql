CREATE PROCEDURE "SP_ITN_PICKLIST" (IN DocKey INT)
AS 
BEGIN
Select T0."DocEntry"
	  ,IFNULL(T7."BeginStr", '') ||'/'|| CAST(T5."DocNum" as CHAR(20)) 
	  ||'/'|| IFNULL(T7."EndStr", '') as "Document Number"
	  ,T5."CreateDate"
	  ,T5."U_CUST" as "Customer Name"
	  ,T0."Address"
	  ,T5."U_MITI" as "Miti"
	  ,T5."U_BUSUNIT" as "Business Unit"
	
	  
	  ,T1."ItemCode"
	  ,0 as "PCS"
	   ,T4."U_NAME" as "Item Name"
	  ,T1."Quantity" as "Total Quantity"
	  ,T1."Price"
	  ,T1."TaxCode"
	  --,T1."U_ITNBATCHNO"
	  --,T1."U_ITNBINLOC"
	  --,T1."U_ITNQTY" as "Batch Quantity"
	  
	  --,Left(T1."U_ITNQTY", 3) as "1st BQTY"
	 -- ,Right(T1."U_ITNQTY", 3) as "2nd BQTY"
	
	  
	  ,T2."Location"
	  
	  
	  
	  ,T3."WhsCode" as "WareHouse Code"
	  
	  ,T4."U_BATCH" as "BatchNo"
	  ,T4."U_BIN" as "BIN"
	  ,T4."U_PICKQTY" as "Batch QTY"
	  ,T8."InDate" as "MFG Date"
	  ,T8."ExpDate" as "Exp Date"
	  ,T9."NumInBuy" as "UPC"
	  
	  ,T5."Remark"
	  ,T5."Creator"
	  ,T6."U_NAME" as "Prepared By"
from ORDR T0
Inner Join RDR1 T1 On T0."DocEntry" = T1."DocEntry"
Left Join OITM T9 On T1."ItemCode" = T9."ItemCode"
Left Join OLCT T2 On T1."LocCode" = T2."Code"
Left Join OWHS T3 On T1."WhsCode" = T3."WhsCode"
Left Join "@ITN_PCL1" T4 On T1."ItemCode" = T4."U_ITEMCODE"
Left Join "@ITN_OPCL" T5 on T4."DocEntry" = T5."DocEntry"
Left Join OUSR T6 On T5."UserSign" = T6."USERID"
Left Join NNM1 T7 On T5."Series" = T7."Series"
Left Join OIBT T8 On T1."ItemCode" = T8."ItemCode" 
--and T1."DocEntry" = T8."BaseEntry"
--and T8."BaseType" = 17
WHERE T0."DocEntry" = :DocKey; 
END