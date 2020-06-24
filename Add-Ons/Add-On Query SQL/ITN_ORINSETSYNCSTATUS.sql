CREATE PROCEDURE [dbo].[ITN_ORINSETSYNCSTATUS]
(
@DocEntry int,@IsRealtime varchar(5),@IsSynced varchar(5),@SyncDate Date
)
AS
BEGIN
Update ORIN set "U_ITN_Is_RealTime" = '' + @IsRealtime + '', "U_ITN_Is_Synced" = '' + @IsSynced + '' , "U_ITN_Sync_Date" = ISNULL(@SyncDate, NULL) where "DocEntry" = @DocEntry;
END
GO