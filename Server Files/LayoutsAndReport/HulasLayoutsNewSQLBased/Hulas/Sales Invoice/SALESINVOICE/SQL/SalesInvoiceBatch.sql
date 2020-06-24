ALTER PROCEDURE [dbo].[SP_ITN_SalesInvoiceBatch] (@DocKey INT)
AS
BEGIN
	SELECT T2.*,T2.DistNumber
	,T2.MnfSerial
	,T2.LotNumber
	,T2.MnfDate
	,T2.Notes
	,T1.BaseLinNum
   ,UF.Descr AS "Colour"
FROM INV1 T0
LEFT JOIN SRI1 T1 ON 
T1.BaseEntry = CASE WHEN T0.BaseType =15 then T0.BaseEntry else  T0.DocEntry end
and T1.BaseType = case when T0.BaseType = 15 then T0.BaseType else 13 end 
and T1.BaseLinNum = case when T0.BaseType = 15 then T0.BaseLine else T0.LineNum end
--T1.BaseEntry = isnull(T0.BaseEntry, T0.DocEntry )
--and T1.BaseType = isnull( case when T0.BaseType = -1 then NULL else T0.BaseType end ,13)
---and T1.BaseLinNum = isnull(T0.BaseLine, T0.LineNum)
	--T0.BaseEntry = T1.BaseEntry
	--AND T0.LineNum = T1.BaseLinNum
	AND T1.Direction = 1
	--AND T1.BaseType in (T0.BaseType)
LEFT JOIN osrn T2 ON T1.SysSerial = T2.SysNumber
	AND T1.ItemCode = T2.ItemCode	
LEFT  JOIN UFD1 UF ON UF.FldValue=T2.U_ITN_CLR
AND UF.TableID='OSRN'
LEFT JOIN CUFD CU ON CU.FieldID=UF.FieldID
AND CU.AliasID='ITN_CLR'
and CU.TableID='OSRN'
WHERE T0.DocEntry = @DocKey;
END