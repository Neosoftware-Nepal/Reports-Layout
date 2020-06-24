CREATE PROCEDURE [dbo].[SP_ITN_SalesInvoiceBatch] (@DocKey INT)
AS
BEGIN
	SELECT T2.DistNumber
	,T2.MnfSerial
	,T2.LotNumber
	,T2.MnfDate
	,T2.Notes
	,T1.BaseLinNum
FROM INV1 T0
LEFT JOIN SRI1 T1 ON T0.DocEntry = T1.BaseEntry
	AND T0.LineNum = T1.BaseLinNum
	AND T1.Direction = 1
	AND T1.BaseType in (13,15)
LEFT JOIN osrn T2 ON T1.SysSerial = T2.SysNumber
	AND T1.ItemCode = T2.ItemCode	
WHERE T0.DocEntry = @DocKey
END