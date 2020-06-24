USE [TESTING]
GO
/****** Object:  StoredProcedure [dbo].[ITN_ORINSETSYNCSTATUS]    Script Date: 14/11/2019 1:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ITN_ORINSETSYNCSTATUS]
(
@DocEntry int,@IsRealtime varchar(5),@IsSynced varchar(5),@SyncDate varchar
)
AS
BEGIN
Update ORIN set "U_ITN_Is_RealTime" = '' + @IsRealtime + '', "U_ITN_Is_Synced" = '' + @IsSynced + '' , "U_ITN_Sync_Date" = ISNULL(GETDATE(),NULL) where "DocEntry" = @DocEntry;
END

