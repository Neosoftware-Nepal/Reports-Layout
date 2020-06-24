/* Number 1 - Mulple price list with same codes are there in ITM1.
so, The selected item price can be any one in it which is confusing for me */
Select distinct 
T4."Price"
--,T3."ListName"
From OQUT T0
LEFT Join QUT1 T1 On T0."DocEntry" = T1."DocEntry"
Inner Join OCRD T2 On T0."CardCode" = T2."CardCode"
Left Join OPLN T3 ON T2."ListNum" =  T3."ListNum"
Left Join ITM1 T4 ON T3."ListNum" = T4."PriceList"
Where $[T0."CardCode"] = T2."CardCode" and $[T1."ItemCode"] = T4."ItemCode"



/* Number 5   */

/* OcrCode2 and OcrdCode3 Dimension should not be NULL for A/R Invoice  */
IF :object_type = '13' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
		Declare DocEntry NVARCHAR(100);
		Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
			Select  T1."DocEntry" --into DocEntry
			From OINV T0
			Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
			Where T1."OcrCode" != ''  
					and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry <> '') THEN
					Begin
					 error :=  115;
					 error_message := 'Dimensions are Mandatory for A/R Invoice ';
				End;
				End If;

END;
END IF;



IF :object_type = '13' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
		Declare DocEntry NVARCHAR(100);
		Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
			Select T1."DocEntry" into DocEntry
			From OINV T0
			Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
			Where T1."OcrCode2" != '' 
					and T2."OcrCode2" != '' 
					and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry <> '') THEN
					Begin
					 error :=  116;
					 error_message := 'Dimensions are Mandatory for A/R Invoice ';
				End;
				End If;

END;
END IF;


/* OcrCode2 and OcrdCode3 Dimension should not be NULL for A/P Invoice  */

IF :object_type = '18' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
		Declare DocEntry NVARCHAR(100);
		Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
		Select  T1."DocEntry" into DocEntry
		From OPCH T0
		Left Join PCH1 T1 On T0."DocEntry" = T1."DocEntry"
		Where T1."OcrCode2" != '' 
				and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry <> '') THEN
					Begin
					 error :=  117;
					 error_message := 'Dimensions are Mandatory for A/R Invoice ';
				End;
				End If;

END;
END IF;



IF :object_type = '18' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
		Declare DocEntry NVARCHAR(100);
		Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
		Select  T1."DocEntry" into DocEntry 
		From OPCH T0
		Left Join PCH1 T1 On T0."DocEntry" = T1."DocEntry"
		Where  T2."OcrCode3" != ''
				and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry <> '') THEN
					Begin
					 error :=  118;
					 error_message := 'Dimensions are Mandatory for A/R Invoice ';
				End;
				End If;
END;
END IF;

/* OcrCode2 and OcrdCode3 Dimension should not be NULL for Inventory Transfer */
67

Select "OcrCode2" from OWTR
-- no dimention column is assigned



/* OcrCode2 and OcrdCode3 Dimension should not be NULL for Finance */
60
Select "OcrCode2" from OIGE
-- no dimention column is assigned



/*  Number 2 Total capacity for bin location master UDF */

Select ($[OBIN."U_ITNLEN"] * $[OBIN."U_ITNWITH"] * $[OBIN."U_ITNHIGT"] ) AS "Total Capacity" 
from OBIN 


/*   Number 3  Sales Request is mandatory for Sales Order     */

IF :Object_type = '17' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(100);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
	
				SELECT Distinct T1."BaseType" into DocEntry
				FROM ORDR T0
				INNER JOIN RDR1 T1 ON T1."DocEntry" = T0."DocEntry" 		
				--Left Join QUT1 T2 On T1."BaseEntry" = T2."DocEntry" 
				--Left Join OQUT T3 On T2."DocEntry" = T3."DocEntry" 	 		
				WHERE T0."DocType" = 'I'
					AND DAYS_Between(T3."DocDueDate", Current_Date)> 0
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (ifnull(:DocEntry,'') <> '23') THEN
	                              BEGIN
	                        error := 119;
						    error_message :='Cannot Add Sales Order without Sales Request';
                         
                                  END;
                                  END IF;     
			                                             
END;
END IF;	                  



/*  Number 3      */
IF :Object_type = '14' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(100);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
			
			Select T0."DocEntry" into DocEntry--, T0."U_RetTyp", T2."WhsCode"  
			from ORIN T0
			Inner Join RIN1 T1 On T0."DocEntry" = T1."DocEntry"
			Left Join OWHS T2 On T1."WhsCode" = T2."WhsCode"
			Where  T0."U_RetTyp" Like 'DE' 
					and ((T2."WhsCode" Like  '%Z') OR (T2."WhsCode" Like  '%X'))
						AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 119;
						    error_message := 'Add the Expiry Or Damaged Warehouse';
                         
                                  END;
                                  END IF;     
			                                             
END;
END IF;	                  





Select * from OWHS 
where OWHS."WhsCode" Like  '%Z' OR OWHS."WhsCode" Like  '%X'



/* Business partner master data    */











