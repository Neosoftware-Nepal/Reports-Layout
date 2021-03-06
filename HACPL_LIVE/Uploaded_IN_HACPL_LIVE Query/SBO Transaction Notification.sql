USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SBO_SP_TransactionNotification]    Script Date: 02/04/2020 9:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[SBO_SP_TransactionNotification] 
	@object_type NVARCHAR(30)	,-- SBO Object Type
	@transaction_type NCHAR(1)	,-- [A]dd, [U]pdate, [D]elete, [C]ancel, C[L]ose
	@num_of_cols_in_key INT
	,@list_of_key_cols_tab_del NVARCHAR(255)
	,@list_of_cols_val_tab_del NVARCHAR(255)
AS
BEGIN
	-- Return values
	DECLARE @cnt INT
	DECLARE @error INT -- Result (0 for no error)
	DECLARE @error_message NVARCHAR(200) -- Error string to be displayed

	SELECT @error = 0

	SELECT @error_message = N'Ok'

	--------------------------------------------------------------------------------------------------------------------------------
	--	ADD	YOUR	CODE	HERE
	IF @object_type = '20'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#1: Chassis number, engine number and color are mandatory IN GRPO
		IF EXISTS (
				SELECT T0.DocEntry
				FROM OPDN T0
				LEFT JOIN OSRI T1 ON T0.DocEntry = T1.BaseEntry
					AND T0.ObjType = T1.BaseType
				LEFT JOIN OSRN T2 ON T1.SysSerial = T2.SysNumber
					AND T1.ItemCode = T2.ItemCode
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND (
						ISNULL(T2."MnfSerial", '') = ''
						OR ISNULL(T2."DistNumber", '') = ''
						OR ISNULL(T2."U_ITN_CLR", '') = ''
						)
				)
		BEGIN
			SET @error = 100;
			SET @error_message = 'Enter the mandatory fields: Chassis number, engine number or color';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type = '20'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#2: Chassis number character should be 17 characters  with no special characters 
		IF EXISTS (
				SELECT T0.DocEntry
				FROM OPDN T0
				LEFT JOIN OSRI T1 ON T0.DocEntry = T1.BaseEntry
					AND T0.ObjType = T1.BaseType
				LEFT JOIN OSRN T2 ON T1.SysSerial = T2.SysNumber
					AND T1.ItemCode = T2.ItemCode
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (Len(T2."DistNumber") > 17 
				OR (T2."DistNumber") like '%[^a-Z0-9]%')
				)
		BEGIN
			SET @error = 101;
			SET @error_message = 'Chassis Number should not exceed 17 characters and must not contain special characters';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type = '20'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#3: Battery Number and Engine Number should be no more than 11 digits
		IF EXISTS (
				SELECT T0.DocEntry
				FROM OPDN T0
				LEFT JOIN OSRI T1 ON T0.DocEntry = T1.BaseEntry
					AND T0.ObjType = T1.BaseType
				LEFT JOIN OSRN T2 ON T1.SysSerial = T2.SysNumber
					AND T1.ItemCode = T2.ItemCode
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (Len(T2."MnfSerial") > 11 
				OR LEN(CAST(T2."Notes" As nvarchar(max))) > 11)
				)
		BEGIN
			SET @error = 102;
			SET @error_message = 'Battery Number or Engine Number should be no more than 11 digits';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END


	IF @object_type = '202'
		AND (
			@transaction_type IN (
				 'U'
				)
			)
	BEGIN
		--Scenario#5: Production close must not be done if the goods are still in WIP process
		IF EXISTS (
				SELECT T1.PlannedQty
				FROM OWOR T0
				INNER JOIN WOR1 T1 ON T1.DocEntry = T0.DocEntry
				WHERE T0.DocEntry = @list_of_cols_val_tab_del
					AND T0.STATUS = 'L'
					AND T1.PlannedQty > T1.IssuedQty
								)
		BEGIN
			SET @error = 104;
			SET @error_message = 'Production order cannot be closed as goods are still in WIP';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END


	IF @object_type = '59'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#6: Chassis number, engine number, color and manufacturing date is mandatory in receipt from production
		IF EXISTS (
				SELECT T0.DocEntry
				FROM OIGN T0
				LEFT JOIN OSRI T1 ON T0.DocEntry = T1.BaseEntry
					AND T0.ObjType = T1.BaseType
				LEFT JOIN OSRN T2 ON T1.SysSerial = T2.SysNumber
					AND T1.ItemCode = T2.ItemCode
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND (
						ISNULL(T2."MnfSerial", '') = ''
						OR ISNULL(T2."DistNumber", '') = ''
						OR ISNULL(T2."U_ITN_CLR", '') = ''
						OR ISNULL(T2."MnfDate", '') = ''
						)
				)
		BEGIN
			SET @error = 105;
			SET @error_message = 'Enter the mandatory fields: Chassis number, engine number, color or manufacturing date';
		END
		

		--------------------------------------------------------------------------------------------------------------------------------
		
	END
	

	IF @object_type = '15'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#7: Sales order shall be mandatory for delivery
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ODLN T0
				INNER JOIN DLN1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND T1."BaseType" <> '17'
					AND T0."DocType" = 'I'
					AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 106;
			SET @error_message = 'Cannot Add Delivery without Sales Order';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type = '18'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#8: GRPO is mandatory before AP invoice 
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OPCH T0
				INNER JOIN PCH1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND T1."BaseType" <> '20'
					AND T0."DocType" = 'I'
					AND T2."ItemCode" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Cannot Add A/P Invoice without Goods Receipt PO';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type = '13'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: delivery is mandatory before AR Invoice
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OINV T0
				INNER JOIN INV1 T1 ON t1."DocEntry" = t0."DocEntry"
				INNER JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND T1."BaseType" <> '15'
					AND T0."DocType" = 'I'
					AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Cannot Add A/R Invoice without Delivery';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type = '14'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: Add reason for return.
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORIN T0
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_Reason" is null or T0."U_ITN_Reason" = '')
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add reason for return.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('13')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OINV T0
				INNER JOIN INV1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('14')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORIN T0
				INNER JOIN RIN1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('15')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ODLN T0
				INNER JOIN DLN1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('16')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORDN T0
				INNER JOIN RDN1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('17')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORDR T0
				INNER JOIN RDR1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('18')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OPCH T0
				INNER JOIN PCH1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('19')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORPC T0
				INNER JOIN RPC1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND  (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('20')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OPDN T0
				INNER JOIN PDN1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('21')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORPD T0
				INNER JOIN RPD1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('59')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OIGN T0
				INNER JOIN IGN1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('60')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OIGE T0
				INNER JOIN IGE1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('67')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OWTR T0
				INNER JOIN WTR1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('202')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM OWOR T0
				INNER JOIN WOR1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('203')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ODPI T0
				INNER JOIN DPI1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	IF @object_type In ('204')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: add workorder number
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ODPO T0
				INNER JOIN DPO1 T1 ON T1."DocEntry" = T0."DocEntry"
				Inner JOIN OITM T2 ON T1."ItemCode" = T2."ItemCode"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T0."U_ITN_WO" is null or T0."U_ITN_WO" = '')
				AND T2."ManSerNum" = 'Y'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Add workorder number.';
		END

		--------------------------------------------------------------------------------------------------------------------------------
				
	END

	IF @Object_type IN ('13') 
	AND 
	 (
	 @transaction_type IN
	  ('A'
	  , 'U'
	  )
	  )
	  --Scenario#9: Blocking back date Entry
	BEGIN 
	IF not exists (
	SELECT T0.BaseEntry, T0.DocEntry 
	FROM OINV T0 
	INNER JOIN INV1 T1 ON T1.DOCENTRY = T0.DOCENTRY
	WHERE T0.docdate = T0.CreateDate
	and T0.DOCENTRY = @list_of_cols_val_tab_del
	)
	BEGIN
	SET @error = 108;
	SET @error_message = 'Posting date must be current date'
	END 
	----------------------------------------------------------------------------------------------------------------------------------------
	END	
	
	IF @Object_type IN ('14') 
	AND 
	 (
	 @transaction_type IN
	  ('A'
	  , 'U'
	  )
	  )
	  --Scenario#9: Blocking back date Entry in A/R Credit Memo
	BEGIN 
	IF not exists (
	SELECT T0.BaseEntry, T0.DocEntry 
	FROM ORIN T0 
	INNER JOIN RIN1 T1 ON T1.DOCENTRY = T0.DOCENTRY
	WHERE T0.docdate = T0.CreateDate
	and T0.DOCENTRY = @list_of_cols_val_tab_del
	)
	BEGIN
	SET @error = 108;
	SET @error_message = 'Posting date must be current date'
	END
-------------------------------------------------------------------------------------------------------------------------------------------------
	END

	IF @Object_type IN ('13') 
	AND 
	 (
	 @transaction_type IN
	  ('A'
	  , 'U'
	  )
	  )
	  --Scenario#9: Blocking document series according to location
	BEGIN 
	IF not exists (
	select OINV.DocNum, NNM1.SeriesName, NNM1.Remark  
	from OINV 
	join INV1 on OINV.DocEntry = INV1.DocEntry
	join OLCT on INV1.LocCode = OLCT.Code
	join NNM1 on ObjectCode = 13 and nnm1.series= oinv.Series
	where OLCT.Location = NNM1.Remark 
	AND  concat(dbo.RemoveNonAlphaCharacters(NNM1.SeriesName), '%') not like NNM1.Remark --AND NNM1.Remark not like concat(dbo.RemoveNonAlphaCharacters(NNM1.SeriesName), '%')
	and OINV.DOCENTRY = @list_of_cols_val_tab_del
	)
	BEGIN
	SET @error = 10;
	SET @error_message = 'Location must be according to document series'
	END
---------------------------------------------------------------------------------------------------------------------------------
	/*END

	IF @Object_type IN ('46') 
	AND 
	 (
	 @transaction_type IN
	  ('A'
	  , 'U'
	  )
	  )
	  --Scenario#16: Blocking Cash amount
	BEGIN 
	IF not exists (
	select DocEntry, CashAcct, NNM1.SeriesName
	from OVPM
	join NNM1 on ObjectCode = 46 and NNM1.Series = OVPM.Series
	where  NNM1.SeriesName  like 'C%' and  OVPM.DocEntry = @list_of_cols_val_tab_del
	)

	BEGIN
	SET @error = 404;
	SET @error_message = 'Series of Cash must be start with C'
	END

	
	---------------------------------------------------------------------------------------------------------------------------------------
		END

	IF @Object_type IN ('46') 
	AND 
	 (
	 @transaction_type IN
	  ('A'
	  , 'U'
	  )
	  )
	  --Scenario#16: Blocking Cash amount
	BEGIN 
	IF  exists (
	select OVPM.DocEntry, RCT1.CheckAct, NNM1.SeriesName
	from OVPM
	Join RCT1 on OVPM.DocEntry = RCT1.DocNum
	join NNM1 on ObjectCode = 46 and NNM1.Series = OVPM.Series
	where  NNM1.SeriesName not like 'C%'  and  OVPM.DocEntry = @list_of_cols_val_tab_del
	)

	BEGIN
	SET @error = 405;
	SET @error_message = 'Series of Cheque must not start with C'
	END*/
	
	---------------------------------------------------------------------------------------------------------------------------------------
		End
	
	IF @object_type In ('17')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#9: TaxCode is mandatory in Sales Order
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORDR T0
				INNER JOIN RDR1 T1 ON T1."DocEntry" = T0."DocEntry"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND ISNULL(T1."TaxCode", '') = '' --and T1."TaxCode" = 'NULL'
				)
		BEGIN
			SET @error = 207;
			SET @error_message = 'Please enter TaxCode';
		END
		




	------------------------------------------------------------------------------------------------------------------------------------------------
	END

	
	IF @object_type In ('15')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#10: TaxCode is mandatory in Delivery
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ODLN T0
				INNER JOIN DLN1 T1 ON T1."DocEntry" = T0."DocEntry"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND ISNULL(T1."TaxCode", '') = '' --and T1."TaxCode" = 'NULL'
				)
		BEGIN
			SET @error = 207;
			SET @error_message = 'Please enter TaxCode';
		END
	

	------------------------------------------------------------------------------------------------------------------------------------------------
	End
	
	IF @object_type In ('17')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#11: Price is mandatory in Sales Order
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ORDR T0
				INNER JOIN RDR1 T1 ON T1."DocEntry" = T0."DocEntry"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND T1."Price" = '0' 
				)
		BEGIN
			SET @error = 207;
			SET @error_message = 'Please enter Price';
		END
		
	------------------------------------------------------------------------------------------------------------------------------------------------
	END

	
	IF @object_type In ('15')
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#12: Price is mandatory in Delivery
		IF EXISTS (
				SELECT T0."DocEntry"
				FROM ODLN T0
				INNER JOIN DLN1 T1 ON T1."DocEntry" = T0."DocEntry"
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND T1."Price" = '0' 
				)
		BEGIN
			SET @error = 207;
			SET @error_message = 'Please enter Price';
		END
		------------------------------------------------------------------------------------------------------------------------------------
	END
	-- Sele
	-- Select the return values
		SELECT @error
			,@error_message
END