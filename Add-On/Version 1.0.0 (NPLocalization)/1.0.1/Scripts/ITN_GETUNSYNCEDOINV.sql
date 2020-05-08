CREATE Procedure [dbo].[ITN_GETUNSYNCEDOINV]
AS
BEGIN
SELECT "DocNum", "DocEntry"
	,CONVERT(VARCHAR(10), "DocDate", 103) as "DocDate"
	,"CardName"
FROM OINV
WHERE (cast("U_ITN_Is_Synced" AS NVARCHAR(max)) <> 'true'
	OR ISNULL(cast("U_ITN_Is_Synced" AS NVARCHAR(max)), '') = ''
	)
END