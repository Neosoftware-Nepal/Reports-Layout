CREATE Procedure [dbo].[ITN_GETUNSYNCEDORIN]
AS
BEGIN
SELECT "DocNum", "DocEntry"
	,CONVERT(VARCHAR(10), "DocDate", 103) as "DocDate"
	,"CardName"
FROM ORIN
WHERE (cast("U_ITN_Is_Synced" AS NVARCHAR(max)) <> 'true'
	OR ISNULL(cast("U_ITN_Is_Synced" AS NVARCHAR(max)), '') = '')
END
GO