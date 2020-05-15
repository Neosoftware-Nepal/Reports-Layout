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
error  int;				-- Result (0 for no error)
error_message nvarchar (200); 		-- Error string to be displayed
begin

error := 0;
error_message := N'Ok';


-----------------------------------------------------------------------------------------------------------------
/* For Vendor E-Mail Address*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
		Declare DocEntry NVARCHAR(100);
    	Declare CardType NVARCHAR(1);
		Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT T0."CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN
		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."E_Mail",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  113;
					 error_message := 'Please Enter E-Mail Address In General Tab ';
				End;
				End If;
END If;
END;
END IF;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/*SP For Vendor Mobile Number*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."Cellular",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  112;
					 error_message := 'Please Enter Mobile Number In General Tab ';
				End;
				End If;
END If;
END;
END IF;
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------
/*SP For DISTRIBUTION AGREEMENT END DATE.*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."U_DISAGEDT",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  111;
					 error_message := 'Please Enter DISTRIBUTION AGREEMENT END DATE ';
				End;
				End If;
END If;
END;
END IF;
-------------------------------------------------------------------------------------------------------------
/*SP For DISTRIBUTION AGREEMENT START DATE*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."U_DISAGSDT",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  110;
					 error_message := 'Please Enter DISTRIBUTION AGREEMENT START DATE ';
				End;
				End If;
END If;
END;
END IF;
------------------------------------------------------------------------------------------------------------
/*SP For Firm Registration Certificate*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."U_FRMREGC",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  109;
					 error_message := 'Please Enter Firm Registration Number ';
				End;
				End If;
END If;
END;
END IF;
-----------------------------------------------------------------------------------------------------------
/*SP For Export Authority Permit Number Internation Vendor*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare CardType NVARCHAR(1);
	Declare VendorType NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
        SELECT T0."CardType" 
        	   ,T0."U_ITN_VendorType" INTO CardType, VendorType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') AND (:VendorType = 'Import') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM OCRD T0 
		where IFNULL(T0."U_EXAPN",'')!=''  
		and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  108;
					 error_message := 'Please Enter Export Authority Permit Number';
				End;
				End If;
END If;
END;
END IF;
-------------------------------------------------------------------------------------------------------
/*SP For FSSAI No.*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT T0."CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."U_FSSAILNO",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  107;
					 error_message := 'Please Enter FSSAI Number ';
				End;
				End If;
END If;
END;
END IF;
----------------------------------------------------------------------------------------------------------------
/* SP For Vedor type */
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
		SELECT T0."CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		WHERE IFNULL(T0."U_ITN_VendorType",'')!='' 
		AND T0."CardCode"=:list_of_cols_val_tab_del;
				
		If (:DocEntry < 1) THEN
			Begin
				error :=  106;
				error_message := 'Please Enter Vendor Type';
			End;
		End If;
END If;
END;
END IF;
--------------------------------------------------------------------------------------------------------------
/*SP For Payment Mode*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where "CardType" = 'S'
		And IFNULL(T0."U_PAYMOD",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  105;
					 error_message := 'Please Enter Payment Mode ';
				End;
				End If;
END IF;
END;
END IF;

--------------------------------------------------------------------------------------------------------------
/*SP For Business Unit (Only for tradable goods - Identified from Vendor Group)*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where T0."GroupCode" in ('103','104')
		And (T0."QryGroup1" = 'N')
		AND  (T0."QryGroup2" = 'N')
		AND  (T0."QryGroup3" = 'N')
		AND  (T0."QryGroup4" = 'N')
		AND  (T0."QryGroup5" = 'N')
		AND  (T0."QryGroup6" = 'N')
		AND  (T0."QryGroup7" = 'N')
		AND  (T0."QryGroup8" = 'N')
		AND  (T0."QryGroup9" = 'N')
		AND  (T0."QryGroup10" = 'N')
		AND  (T0."QryGroup11" = 'N')
		AND  (T0."QryGroup12" = 'N')
		AND  (T0."QryGroup13" = 'N')
		AND  (T0."QryGroup14" = 'N')
		AND T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry >= 1) THEN
					Begin
					 error :=  104;
					 error_message := 'Please Select Atleast one Business Unit in Properties Tab ';
				End;
				End If;
END If;
END;
END IF;
----------------------------------------------------------------------------------------------------------------
/*SP For Vendor Pan No.*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 Inner Join CRD7 T1 on T0."CardCode" = T1."CardCode"
		where IFNULL(T1."TaxId4",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  103;
					 error_message := 'Please Enter Pan No/Vat No. ';
				End;
				End If;
END If;
END;
END IF;
----------------------------------------------------------------------------------------------------------------
/*SP For Bank Details.*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT "BankCode" INTO DocEntry
		FROM  OCRD T0 
		where T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry = '-1') THEN
					Begin
					 error :=  102;
					 error_message := 'Please Enter Bank Details ';
				End;
				End If;
END If;
END;
END IF;

-------------------------------------------------------------------------------------------------------
/*SP For Vendor Contact Person*/
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare CardType NVARCHAR(1);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT "CardType" INTO CardType
		FROM  OCRD T0 
		WHERE T0."CardCode"=:list_of_cols_val_tab_del;
		
		IF (:CardType = 'S') THEN


		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		where IFNULL(T0."CntctPrsn",'')!='' 
				and T0."CardCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  101;
					 error_message := 'Please Enter Contact Person Details ';
				End;
				End If;
END If;
END;
END IF;

--------------------------------------------------------------------------------------------------------------------
/* SP For Business Partner Name */
IF :object_type = '2' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	--Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM  OCRD T0 
		WHERE T0."CardName" !=''
		AND T0."CardCode"=:list_of_cols_val_tab_del;
				
		If (:DocEntry < 1) THEN
			Begin
				error :=  100;
				error_message := 'Please Enter Business Partner Name';
			End;
		End If;
END;
END IF;
--------------------------------------------------------------------------------------------------------
/*SP For OITM Sub Brand Form*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare ItemClass NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

        SELECT "U_ITN_ITEMCLASS" INTO ItemClass
		FROM OITM 
		WHERE "ItemCode"=:list_of_cols_val_tab_del;
		
		IF (:ItemClass = 'Trade') THEN        

		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		where IFNULL(T0."U_SBRNDFRM",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  207;
					 error_message := 'Please Enter SKU Sub Brand Form';
				End;
				End If;
END If;
END;
END IF;
--------------------------------------------------------------------------------------------------------

/*SP For OITM Product Pack*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare ItemClass NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

        SELECT "U_ITN_ITEMCLASS" INTO ItemClass
		FROM OITM 
		WHERE "ItemCode"=:list_of_cols_val_tab_del;
		
		IF (:ItemClass = 'Trade') THEN        

		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		where IFNULL(T0."U_PRODPACK",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  206;
					 error_message := 'Please Enter SKU Product Pack';
				End;
				End If;
END If;
END;
END IF;
--------------------------------------------------------------------------------------------------------
/*SP For OITM Market Catalouge*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare ItemClass NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

        SELECT "U_ITN_ITEMCLASS" INTO ItemClass
		FROM OITM 
		WHERE "ItemCode"=:list_of_cols_val_tab_del;
		
		IF (:ItemClass = 'Trade') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		where "U_ITN_ITEMCLASS" = 'Trade'
		And  IFNULL(T0."U_MRKTCAT",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  205;
					 error_message := 'Please Enter SKU Market Catalouge ';
				End;
				End If;
END If;
END;
END IF;
----------------------------------------------------------------------------------------------------------------
/*SP For OITM Sub Brand*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare ItemClass NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

        SELECT "U_ITN_ITEMCLASS" INTO ItemClass
		FROM OITM 
		WHERE "ItemCode"=:list_of_cols_val_tab_del;
		
		IF (:ItemClass = 'Trade') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		where "U_ITN_ITEMCLASS" = 'Trade'
		And  IFNULL(T0."U_SUBBRND",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  204;
					 error_message := 'Please Enter SKU Sub Brand ';
				End;
				End If;
END If;
END;
END IF;
----------------------------------------------------------------------------------------------------------------

/*SP For OITM Brand*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
    Declare ItemClass NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

        SELECT "U_ITN_ITEMCLASS" INTO ItemClass
		FROM OITM 
		WHERE "ItemCode"=:list_of_cols_val_tab_del;
		
		IF (:ItemClass = 'Trade') THEN

		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		where IFNULL(T0."U_BRND",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  203;
					 error_message := 'Please Enter SKU Brand ';
				End;
				End If;
END If;
END;
END IF;
--------------------------------------------------------------------------------------------------------------
/*SP For Item Category*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare ItemClass NVARCHAR(30);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;
		
		SELECT "U_ITN_ITEMCLASS" INTO ItemClass
		FROM OITM 
		WHERE "ItemCode"=:list_of_cols_val_tab_del;
		
		IF (:ItemClass = 'Trade') THEN
		
		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		WHERE IFNULL(T0."U_CATGORY",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  202;
					 error_message := 'Please Enter SKU Category ';
				End;
				End If;
		END IF;		
END;
END IF;
--------------------------------------------------------------------------------------------------------
/*SP For OITM CLASS*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM  OITM T0 
		where IFNULL(T0."U_ITN_ITEMCLASS",'')!='' 
				and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  201;
					 error_message := 'Please Enter Item Class ';
				End;
				End If;
END;
END IF;
--------------------------------------------------------------------------------------------------------
/*SP For OITM Item Name*/
IF :object_type = '4' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM OITM T0 
		where IFNULL(T0."ItemName",'')!=''  
		and T0."ItemCode"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  200;
					 error_message := 'Please Enter Item Name ';
				End;
				End If;
END;
END IF;
--------------------------------------------------------------------------------------------------------
/* Sp For A/P Credit Memo */
IF :object_type = '19' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	--Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM  ORPC T0 
		WHERE T0."U_ResonRtn" !=''
		AND T0."DocEntry"=:list_of_cols_val_tab_del;
				
		If (:DocEntry < 1) THEN
			Begin
				error :=  301;
				error_message := 'Please Enter Return Reson';
			End;
		End If;
END;
END IF;
-----------------------------------------------------------------------------------------
/* Sp For A/P Credit Memo */
IF :object_type = '19' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	--Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM  ORPC T0 
		WHERE  T0."RevRefNo" !=''
		And T0."RevRefDate" !=''
		AND T0."DocEntry"=:list_of_cols_val_tab_del;
				
		If (:DocEntry < 1) THEN
			Begin
				error :=  300;
				error_message := 'Please Enter Original Ref. No. And Date in Tax Tab ';
			End;
		End If;
END;
END IF;
-----------------------------------------------------------------------------------------------------------------
/*SP For GRPO Vendor Ref No.*/
IF :object_type = '20' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM OPDN T0 
		where IFNULL(T0."NumAtCard",'')!=''  
		and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  400;
					 error_message := 'Please Enter Vendor Refrence No.';
				End;
				End If;
END;
END IF;
-----------------------------------------------------------------------------------------------------------------
/* Sp For A/P Invoice */
IF :object_type = '18' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	--Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM  OPCH T0 
		WHERE  T0."U_APInvTyp" !=''
		AND T0."DocEntry"=:list_of_cols_val_tab_del;
				
		If (:DocEntry < 1) THEN
			Begin
				error :=  500;
				error_message := 'Please Select A/P Invoice Type ';
			End;
		End If;
END;
END IF;
-----------------------------------------------------------------------------------------------------------------
/*IF :Object_type = '17' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
	BEGIN

		DECLARE DocEntry NVARCHAR(50);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
		 --/Scenario#: Sales Quotation is mandatory For Sales Order
				SELECT Distinct T0."DocEntry" into DocEntry
				FROM ORDR T0
				INNER JOIN RDR1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE  T1."BaseType" <> '23'
					AND T0."DocType" = 'I'
					--AND T2."ManSerNum" = 'Y'
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 700;
						    error_message :='Cannot Add Sales Order without Sales Quotation';
                         
                                  END;
                                  END IF;     
				                  
END;
END IF;*/
-----------------------------------------------------------------------------------------------------------------
IF :Object_type = '17' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

       DECLARE DocEntry NVARCHAR(50);
       
       DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299

              BEGIN
                     DocEntry :='';
              END;
                                SELECT T0."DocEntry" into DocEntry 
                                from RDR1 T0 
                                Inner Join OQUT On OQUT."DocEntry" = T0."BaseEntry"
                                Inner Join ORDR T1 ON T1."DocEntry" = T0."DocEntry"
                                where T0."DocEntry" = :list_of_cols_val_tab_del and
                                               DAYS_Between(OQUT."DocDueDate", Current_Date)>0 ;
                               
                                IF (:DocEntry <> '') THEN                                        
                                     BEGIN
                                      error := 701;
                                      error_message := 'You can not Create Sales Order Because Sales Quotation has Expired';
                                END;
                       	        END IF;                    
END;
END IF;

-----------------------------------------------------------------------------------------------------------------
/*SP For Sales Return Type.*/
IF :object_type = '234000031' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM ORRR T0 
		where IFNULL(T0."U_RetTyp",'')!=''  
		and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  702;
					 error_message := 'Please Enter Sales Return Type.';
				End;
				End If;
END;
END IF;
---------------------------------------------------------------------------------------------
/*SP For Reason For Return.*/
IF :object_type = '234000031' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
	Declare DocEntry NVARCHAR(100);
	Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
	
		BEGIN
			DocEntry := '';
		END;

		SELECT COUNT(1) INTO DocEntry
		FROM ORRR T0 
		where IFNULL(T0."U_Reason",'')!=''  
		and T0."DocEntry"=:list_of_cols_val_tab_del;
				
				If (:DocEntry < 1) THEN
					Begin
					 error :=  703;
					 error_message := 'Please Enter Sales Reason For Return.';
				End;
				End If;
END;
END IF;
------------------------------------------------------------------------------------------


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
				WHERE  --T1."BaseType" = '23'
					--AND 
                 T0."DocType" = 'I'
				--	AND DAYS_Between(T3."DocDueDate", Current_Date)> 0
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (ifnull(:DocEntry,'') <> '23') THEN
	                              BEGIN
	                        error := 119;
						    error_message :='Cannot Add Sales Order without Sales Request';
                         
                                  END;
                                  END IF;     
			                                             
END;
END IF;	                               

-------------------------------------------------------------------------------------
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
---------------------------------------------------------------------------------------------

IF :Object_type = '22' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(100);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
					Select T0."DocEntry" into DocEntry --, IfNull(DAYS_BETWEEN(T1."U_DISAGEDT", Current_Date), 0)
					from OPOR T0
					Left Join OCRD T1 On T0."CardCode" = T1."CardCode"
					Where DAYS_BETWEEN(T1."U_DISAGEDT", Current_Date)>= 0 
						AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 120;
						    error_message := 'Distribution Agreement Date is out of Date cannot make Purchase Order';
                         
                                  END;
                                  END IF;     
			                                             
END;
END IF;
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 /* Number 1   */

 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Purchase Request  */
IF :object_type = '1470000113' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OPRQ T0
                  Left Join PRQ1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  201;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Purhcase Request ';
                        End;
                        End If;

END;
END IF;
 
 
 
 
 
 --------------------------------------------------------------------------------
 /* Number 1.2    */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Purchase Quotation  */
IF :object_type = '540000006' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OPQT T0
                  Left Join PQT1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  202;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Purchase Quotation ';
                        End;
                        End If;

END;
END IF;
 
 
 
 --------------------------------------------------------------------------------
 /* Number 1.3    */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for GRPO  */


IF :object_type = '20' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OPDN T0
                  Left Join PDN1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  203;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for GRPO ';
                        End;
                        End If;

END;
END IF;
 
 
 --------------------------------------------------------------------------------
 /* Number 1.4    */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Goods Return Request  


IF :object_type = '' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  204;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Goods Return Request ';
                        End;
                        End If;

END;
END IF; */
 
 
 
 --------------------------------------------------------------------------------
 /* Number 1.5    */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Goods Return */


IF :object_type = '21' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  205;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Goods Return ';
                        End;
                        End If;

END;
END IF;
 
 
 
 --------------------------------------------------------------------------------
 /* Number 1.6   */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/P Down Payment Request  

IF :object_type = '' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  206;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/P Down Payment Request ';
                        End;
                        End If;

END;
END IF;    */

 --------------------------------------------------------------------------------
 /* Number 1.7    */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/P Down Payment Invoice  */

IF :object_type = '204' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ODPO T0
                  Left Join DPO1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  207;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/P Down Payment Invoice ';
                        End;
                        End If;

END;
END IF;
 --------------------------------------------------------------------------------
 /* Number 1.8   */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/R Invoice  */

IF :object_type = '13' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  200;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/R Invoice ';
                        End;
                        End If;

END;
END IF;
 
 --------------------------------------------------------------------------------
 /* Number 1.9    */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/P Invoice */

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
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  208;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/P Invoice ';
                        End;
                        End If;

END;
END IF;
 
 
 --------------------------------------------------------------------------------
 /* Number 1.10   */
 
 
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/P Credit Memo  */

IF :object_type = '19' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ORPC T0
                  Left Join RPC1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  210;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/P Credit Memo ';
                        End;
                        End If;

END;
END IF;
 
 --------------------------------------------------------------------------------
 /* Number 1.11   */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Incoming Payment  */

IF :object_type = '24' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocNum" into DocEntry
                  From ORCT T0
                  Left Join RCT4 T1 On T0."DocEntry" = T1."DocNum"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  211;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Incoming Payment';
                        End;
                        End If;

END;
END IF;
 
 --------------------------------------------------------------------------------
 /* Number 1.12    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Outgoing Payment  */

IF :object_type = '46' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocNum" into DocEntry
                  From OVPM T0
                  Left Join VPM4 T1 On T0."DocEntry" = T1."DocNum"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  212;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Outgoing Payment ';
                        End;
                        End If;

END;
END IF;
 
 
 --------------------------------------------------------------------------------
 /* Number 1.13    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Journal Entry  

IF :object_type = '30' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare TransId NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  TransId := '';
            END;
            
                  Select  T1."TransId" into TransId
                  From OJDT T0
                  Left Join JDT1 T1 On T0."TransId" = T1."TransId"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."TransId"=:list_of_cols_val_tab_del;
                        
                        If (:TransId <> '') THEN
                              Begin
                              error :=  213;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Journal Entry ';
                        End;
                        End If;

END;
END IF; */


 ---------------------------------------------------------------------------------
/* Number 1.14    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Journal Voucher  


IF :object_type = '28' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OBTF T0
                  Left Join BTF1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  214;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Journal Voucher ';
                        End;
                        End If;

END;
END IF;			*/



--------------------------------------------------------------------------------------

/* Number 1.15    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Goods issue  */

IF :object_type = '60' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OIGE T0
                  Left Join IGE1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  215;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Goods issue ';
                        End;
                        End If;

END;
END IF;





----------------------------------------------------------------------------------
/* Number 1.16    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Goods Receipt 

IF :object_type = '13' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  216;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Goods Receipt ';
                        End;
                        End If;

END;
END IF;			*/




-------------------------------------------------------------------------------------
 /* Number 1.17    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Inventory Transfer Request  */

IF :object_type = '1250000001' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OWTQ T0
                  Left Join WTQ1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  217;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Inventory Transfer Request ';
                        End;
                        End If;

END;
END IF;
 
 --------------------------------------------------------------------------------
 /* Number 1.18    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Inventory  Transfer  */


IF :object_type = '67' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OWTR T0
                  Left Join WTR1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  218;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Inventory  Transfer ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.19    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Inventory Posting  */

IF :object_type = '10000071' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OIQR T0
                  Left Join IQR1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  219;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Inventory Posting ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.20    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Inventory Counting.
  */
  
IF :object_type = '1470000065' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINC T0
                  Left Join INC1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."ProjCode",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  220;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Inventory Counting ';
                        End;
                        End If;

END;
END IF;

-------------------------------------------------------------------------------------
 /* Number 1.21    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Purchase Order
  */
  
IF :object_type = '22' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OPOR T0
                  Left Join POR1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  222;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Purchase Order ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.22    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Landed Cost
  */
  
IF :object_type = '69' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OIPF T0
                  Left Join IPF1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  223;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Landed Cost ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.23    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Sales Quotation
  */
  
IF :object_type = '23' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OQUT T0
                  Left Join QUT1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  224;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Sales Quotation ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.24    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Sales Order
  */
  
IF :object_type = '17' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ORDR T0
                  Left Join RDR1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  225;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Sales Order ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.25    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Delivery
  */
  
IF :object_type = '15' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ODLN T0
                  Left Join DLN1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  226;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Delivery ';
                        End;
                        End If;

END;
END IF;



-------------------------------------------------------------------------------------
 /* Number 1.26    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Return Request
  */
  
IF :object_type = '13' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  227;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Return Request ';
                        End;
                        End If;

END;
END IF;


-------------------------------------------------------------------------------------
 /* Number 1.27    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for Return 
  */
  
IF :object_type = '16' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ORDN T0
                  Left Join RDN1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  228;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for Return ';
                        End;
                        End If;

END;
END IF;



-------------------------------------------------------------------------------------

 /* Number 1.28    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/R Down Payment Request 
  
  
IF :object_type = '13' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From OINV T0
                  Left Join INV1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  229;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/R Down Payment Request ';
                        End;
                        End If;

END;
END IF;	*/

-------------------------------------------------------------------------------------

 /* Number 1.29    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/R Down Payment Invoice 
  */
  
IF :object_type = '203' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ODPI T0
                  Left Join DPI1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  230;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/R Down Payment Invoice ';
                        End;
                        End If;

END;
END IF;

-------------------------------------------------------------------------------------

 /* Number 1.30    */
 
  
/* OcrCode (Business Unit) , OcrdCode2 (Location) 
& Project should not be NULL for A/R Credit Memo
  */
  
IF :object_type = '14' and  (:transaction_type = 'A' OR  :transaction_type = 'U') Then
BEGIN
            Declare DocEntry NVARCHAR(100);
            Declare EXIT HANDLER FOR SQL_ERROR_CODE 1299
      
            BEGIN
                  DocEntry := '';
            END;
            
                  Select  T1."DocEntry" into DocEntry
                  From ORIN T0
                  Left Join RIN1 T1 On T0."DocEntry" = T1."DocEntry"
                  Where (ifnull(T1."OcrCode",'') != '' or ifnull(T1."OcrCode2",'') != '' or  ifnull(T1."Project",'') != '')   
                              and T0."DocEntry"=:list_of_cols_val_tab_del;
                        
                        If (:DocEntry <> '') THEN
                              Begin
                              error :=  231;
                              error_message := 'Business Unit & Depts and Location & Project are Mandatory for A/R Credit Memo ';
                        End;
                        End If;

END;
END IF;
----------------------------------------------------------------------------------
 /* Number 2 */
 
 
 /* Blocking Purchase order if the Distribution agreement date ends*/
 
 
 IF :Object_type = '22' AND (:transaction_type = 'A' OR :transaction_type = 'U') THEN
BEGIN

		DECLARE DocEntry NVARCHAR(100);
		
		DECLARE EXIT HANDLER FOR SQL_ERROR_CODE 1299
		
			BEGIN
			
 				DocEntry :='';
 				
			END;
					Select T0."DocEntry" into DocEntry  --, IfNull(DAYS_BETWEEN(T1."U_DISAGEDT", Current_Date), 0)
					from OPOR T0
					Left Join OCRD T1 On T0."CardCode" = T1."CardCode"
					Where DAYS_BETWEEN(T1."U_DISAGEDT", Current_Date) >= 0  
						AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (:DocEntry <> '') THEN
	                              BEGIN
	                        error := 120;
						    error_message := 'Distribution Agreement Date is out of Date cannot make Purchase Order';
                         
                                  END;
                                  END IF;     
			                                             
END;
END IF;	

-------------------------------------------------------------------------------------
/* Number 3*/

/* Blocking A/R Credit memo if the wastage is not in damaged or expired warehouse */ 

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

------------------------------------------------------------------------------------------------

/* Number 4 */

/*  Sales  Request is mandatory for sales Order    */  


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
					--AND DAYS_Between(T3."DocDueDate", Current_Date)> 0
					AND T0."DocEntry" =:list_of_cols_val_tab_del;
					
						  IF (ifnull(:DocEntry,'') <> '23') THEN
	                              BEGIN
	                        error := 119;
						    error_message :='Cannot Add Sales Order without Sales Request';
                         
                                  END;
                                  END IF;     
			                                             
END;
END IF;	  



--------------------------------------------------------------------------
-- Select the return values
select :error, :error_message FROM dummy;

end;