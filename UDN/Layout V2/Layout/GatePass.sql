CREATE PROCEDURE "SP_ITN_GatePass" (IN DocKey INT)
AS
BEGIN
select T1."DocEntry"
	   ,IFNULL(T4."BeginStr",'') ||'/'|| CAST(T1."DocNum" as CHAR(20))
	    ||'/'|| IFNULL(T4."EndStr",'') as "Gate Pass No."
	   ,T1."Remark"
	   ,T1."CreateDate" as "DocDate"
	   ,T1."U_PARCODE" as "Customer Code"
	   ,T1."U_PARNAME" as "Customer Name"
	   ,T1."U_WHSCODE" as "Warehouse Code"
	   ,T1."U_WHSNAME" as "Warehouse Name"
	   ,T1."U_GATENNUM" as "GatePass Number"
	   ,T1."U_TRASDETL" as "Transporter Detail"
	   ,T1."U_VEHNUM" as "Vehicles Number"
	   ,T1."U_DRINAME" as "Driver Name"
	   ,T1."U_CONTNUM" 
	   ,T1."U_TRASTYPE" as "Transport Status"
	   ,T1."U_PREPBY" as "Prepared By"
	   ,T1."U_REMARKS" as "Remarks"
	   ,T1."U_EXITTIME" as "Exit Time"
	   ,T1."U_INTIME" as "In Time"
	   ,T1."U_EXITDATE" as "Exit Date"
	   ,T1."U_EXITNPDT" as "Exit Miti"
	   ,T1."U_INDATE" as "In Date"
	   ,T1."U_INNPDATE" as "In Miti"
	   ,T2."U_ITEMCODE" as "Item Code"
	   ,T2."U_NAME" as "Item Name"
	   ,T2."U_QUANTITY" as "Total Case"
	   ,T9."NumInBuy" as "Total PCS"
	   ,T2."U_VALUE" as "Value"
	   ,T2."U_UOM" as "UOm"
	   ,T2."U_INEXTQTY" as "In/Exit QTY"
	   ,IFNULL(T4."BeginStr", '') ||'/'|| CAST(T3."DocNum" as CHAR(20)) 
	   ||'/'|| IFNULL(T4."EndStr",'') as "Invoice No."
	   ,T3."DocDate" as "Invoice Date"
	   ,T5."Address"
	   ,T6."Street" as "BillToAddress"
	   ,T7."Street" as "ShipToAddress" 
	   ,T8."U_NAME"

	   /*   Shipment Tracking */
		--,T10."U_BLDNUM" as "Bilty Number"
		--,T10."U_BLDT" as "Bilty Date"
		--,T10."U_TRANME" as "Transporter Name"
	   
	   
	   
From "@ITN_OGTP" T1
INNER JOIN "@ITN_GTP1" T2 ON T1."DocEntry" = T2."DocEntry"
LEFT JOIN OINV T3 ON T1."DocEntry" = T3."DocEntry"
LEFT JOIN NNM1 T4 On T1."Series" = T4."Series"
LEFT JOIN OCRD T5 On T1."U_PARCODE" = T5."CardCode"
LEFT JOIN CRD1 T6 ON T6."CardCode" = T1."U_PARCODE"
		AND T6."Address" = T3."PayToCode"
		AND T6."AdresType" = 'B'
LEFT JOIN CRD1 T7 ON T7."CardCode" = T1."U_PARCODE"
		AND T7."Address" = T3."ShipToCode"
		AND T7."AdresType" = 'S'
LEFT JOIN OUSR T8 On T1."UserSign" = T8."USERID"
INNER JOIN OITM T9 On T2."U_ITEMCODE" = T9."ItemCode"
WHERE T1."DocEntry" = :DocKey;
END