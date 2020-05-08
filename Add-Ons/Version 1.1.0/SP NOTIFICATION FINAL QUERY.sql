USE [Hulas_Autocraft_CRP_3]
GO

/****** Object:  StoredProcedure [dbo].[SBO_SP_TransactionNotification]    Script Date: 6/6/2019 10:08:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Alter PROC [dbo].[SBO_SP_TransactionNotification] 
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
			SET @error_message = 'Enter the mandatory fields';
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

	IF @object_type = '20'
		AND (
			@transaction_type IN (
				'A'
				,'U'
				)
			)
	BEGIN
		--Scenario#4: Registration Number with no special characters
		IF EXISTS (
				SELECT T0.DocEntry
				FROM OPDN T0
				LEFT JOIN OSRI T1 ON T0.DocEntry = T1.BaseEntry
					AND T0.ObjType = T1.BaseType
				LEFT JOIN OSRN T2 ON T1.SysSerial = T2.SysNumber
					AND T1.ItemCode = T2.ItemCode
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
				AND (T2."U_ITN_REGNO") like '%[^a-Z0-9]%'
				)
		BEGIN
			SET @error = 103;
			SET @error_message = 'Registration No. should not contain special characters';
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
			SET @error_message = 'Enter the mandatory fields';
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
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND T1."BaseType" <> '17'
					AND T0."DocType" = 'I'
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
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND T1."BaseType" <> '20'
					AND T0."DocType" = 'I'
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
				WHERE T0."DocEntry" = @list_of_cols_val_tab_del
					AND T1."BaseType" <> '15'
					AND T0."DocType" = 'I'
				)
		BEGIN
			SET @error = 107;
			SET @error_message = 'Cannot Add A/R Invoice without Delivery';
		END

		--------------------------------------------------------------------------------------------------------------------------------
		
	END

	-- Select the return values
		SELECT @error
			,@error_message
END
GO


