ALTER PROCEDURE SBO_SP_TransactionNotification
(
	in object_type nvarchar(30), 				-- SBO Object Type
	in transaction_type nchar(1),			-- [A]dd, [U]pdate, [D]elete, [C]ancel, C[L]ose
	in num_of_cols_in_key int,
	in list_of_key_cols_tab_del nvarchar(255),
	in list_of_cols_val_tab_del nvarchar(255)
)
LANGUAGE SQLSCRIPT
AS
	
	
	

-- Return values
--DECLARE cnt INT
error  int;				-- Result (0 for no error)
error_message nvarchar (200); 		-- Error string to be displayed
begin

error := 0;
error_message := N'Ok';

--------------------------------------------------------------------------------------------------------------------------------

 
--------------------------------------------------------------------------------------------------------------------------------
/* Vendor Refreence Number is compulsary in A/P Invoice */

IF :Object_type = '18' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(50);
       
       DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299

              BEGIN
                     DocEntry :='';
              END;

                     Select T0."DocEntry" into DocEntry from 
                     OPCH T0 
                     Where ifnull(T0."NumAtCard" ,'')='' and  
                     T0."DocEntry"=:list_of_cols_val_tab_del;
              
                           IF (:DocEntry <> '') THEN
                                  BEGIN
                           error := 5;
                           error_message :='Vendor refence number is mandatory on A/P invoice';
                                  END;
                                  END IF;                    
END;
END IF;

 

	
	
   
--------------------------------------------------------------------------------------------------------------------------------

	   
--------------------------------------------------------------------------------------------------------------------------------

/* Vendor Refreence Number is compulsary in Goods Receipt Note  */
IF :Object_type = '20' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(50);
       
       DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299

              BEGIN
                     DocEntry :='';
              END;

                     Select T0."DocEntry" into DocEntry 
                     from OPDN T0 
                     Where ifnull(T0."NumAtCard" ,'')='' and  
                     T0."DocEntry"=:list_of_cols_val_tab_del;
              
                           IF (:DocEntry <> '') THEN
                                  BEGIN
                           error := 6;
                           error_message :='Vendor refence number is mandatory on Goods Recipt Note';
                                  END;
                                  END IF;                    
END;
END IF;
	
      
--------------------------------------------------------------------------------------------------------------------------------

/* Cellular number is compulsary A/R CASH  Invoice */
IF :Object_type = '11' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(10);
       
	   Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;


		Select T0."CntctCode" into DocEntry
        from OCPR T0 
        Where 	T0."CardCode" = 'CASH' and
                T0."CntctCode"=:list_of_cols_val_tab_del
                and ifnull(T0."Cellolar" ,'')='';

             IF (:DocEntry <> '') THEN
             BEGIN
             error := 13;
             error_message :='Cellolar Number is mandatory on A/R Cash Invoice ';
             END;
             END IF;  
			
                                                   
END;
END IF;  
	
--------------------------------------------------------------------------------------------------------------------------------

/* Cellular number must be 10 Digits 
IF :Object_type = '11' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(10);
       
       DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299

              BEGIN
                     DocEntry :='';
              END;

                     Select T0."CntctCode" --into DocEntry
                     from OCPR T0 
                     Where ifnull(T0."Cellolar", '') != '' and
                     T0."CardCode" = 'CASH' and
                     T0."CntctCode"=:list_of_cols_val_tab_del;
              
                           IF (:DocEntry <> '') THEN
                                  BEGIN
                           error := 14;
                           error_message :='Tel2 Number is mandatory ';
                                  END;
                                  END IF;                    
END;
END IF; */
	
--------------------------------------------------------------------------------------------------------------------------------

/* Vendor Refreence Number is compulsary in A/P Credit Memo  */
IF :Object_type = '19' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(50);
       
       DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299

              BEGIN
                     DocEntry :='';
              END;

                     Select T0."DocEntry" into DocEntry from 
                     ORPC T0 
                     Where ifnull(T0."NumAtCard" ,'')='' and  
                     T0."DocEntry"=:list_of_cols_val_tab_del;
              
                           IF (:DocEntry <> '') THEN
                                  BEGIN
                           error := 6;
                           error_message :='Vendor refence number is mandatory on A/P Credit Memo';
                                  END;
                                  END IF;                    
END;
END IF;

 -------------------------------------------------------------------------------------------------------------------------------
/*	Nepali Date Check in Journal Entry*/
 
 /* IF :Object_type = '13' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(50);
       DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299

              BEGIN
                     DocEntry :='';
              END;

                     Select T0."TransId" into DocEntry from 
                     OJDT T0 
                     Where IFNULL(T0."U_ITN_NPDate", 'Null') = 'Null' and  
                     T0."TransId"=:list_of_cols_val_tab_del;
              
                           IF (:DocEntry <> '') THEN
                                  BEGIN
                           error := 5;
                           error_message :='Nepali Date is Empty';
                                  END;
                                  END IF;    


                
END;
END IF; */
	
--------------------------------------------------------------------------------------------------------------------------------

IF :Object_type = '15' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(50);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
		--Scenario#9: Sales order shall be mandatory for delivery
	
				SELECT Distinct T0."DocEntry" into DocEntry
				FROM ODLN T0
				INNER JOIN DLN1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE  T1."BaseType" <> '17'
					AND T0."DocType" = 'I'
					AND T2."ManBtchNum" = 'Y'
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 106;
						    error_message :='Cannot Add Delivery without Sales Order';
                         
                                  END;
                                  END IF;     
				                  
END;
END IF;
		

-------------------------------------------------------------------------------------------------------------------
IF :Object_type = '20' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(50);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
		 --Scenario#10: GRPO is mandatory before AP invoice
				SELECT Distinct T0."DocEntry" into DocEntry
				FROM OPDN T0
				INNER JOIN PDN1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE  T1."BaseType" <> '22'
					AND T0."DocType" = 'I'
					AND T2."ManBtchNum" = 'Y'
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 107;
						    error_message :='Cannot Add GRPO without Purchase Order';
                         
                                  END;
                                  END IF;     
				                  
END;
END IF;
---------------------------------------------------------------------------------------------------------------
IF :Object_type = '18' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(50);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
		 --Scenario#10: GRPO is mandatory before AP invoice
				SELECT Distinct T0."DocEntry" into DocEntry
				FROM OPCH T0
				INNER JOIN PCH1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE  T1."BaseType" <> '20'
					AND T0."DocType" = 'I'
					AND T2."ManBtchNum" = 'Y'
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 107;
						    error_message :='Cannot Add GRPO without Purchase Order';
                         
                                  END;
                                  END IF;     
				                  
END;
END IF;
---------------------------------------------------------------------------------------------------------------
IF :Object_type = '13' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(50);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
		--Scenario#11: delivery is mandatory before AR Invoice
	
				SELECT Distinct T0."DocEntry" into DocEntry
				FROM OINV T0
				INNER JOIN INV1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" =:list_of_cols_val_tab_del
					AND T1."BaseType" <> '15'
					AND T0."DocType" = 'I'
					AND T2."ManBtchNum" = 'Y'
					AND T0."CardCode" Like 'FR%';
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 107;
						    error_message :='Cannot Add A/R Invoice without Delivery';
                         
                                  END;
                                  END IF;     
				                  
END;
END IF;


--------------------------------------------------------------------------------------------------------------------------------

IF :Object_type = '13' AND (:transaction_type = 'A') THEN
BEGIN

    CREATE COLUMN TABLE  LOCALTEMPTABLE  ("BaseEntry" int , "BaseLine" int ,"Quantity"  decimal(16,2) );
    

	 insert into LOCALTEMPTABLE
	 		SELECT T0."BaseEntry",T0."BaseLine", T4."Quantity" FROM RRR1 T0
		INNER JOIN RIN1 T4 ON T4."BaseEntry" = T0."DocEntry" AND T4."BaseLine" = T0."LineNum"
		WHERE T4."DocEntry" =:list_of_cols_val_tab_del;

	--SELECT * FROM #LOCALTEMPTABLE ;
	
	UPDATE INV1 T2 
	SET T2."U_ITN_Stock" = T2."U_ITN_Stock" - T1."Quantity"		
	FROM INV1 T0
	INNER JOIN LOCALTEMPTABLE T1 on T1."BaseEntry" = T0."DocEntry" and T1."BaseLine" = T0."LineNum";
	
	    drop table LOCALTEMPTABLE;

END;
END IF;



--------------------------------------------------------------------------------------------------------------------------------




-- Select the return values
select :error, :error_message FROM dummy;

end;