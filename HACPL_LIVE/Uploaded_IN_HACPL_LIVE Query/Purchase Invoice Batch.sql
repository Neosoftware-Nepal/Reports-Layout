USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_PurchaseInvoiceBatch]    Script Date: 02/04/2020 9:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_ITN_PurchaseInvoiceBatch] (@DocKey INT)
AS
BEGIN
	SELECT  r.BaseLinNum
	,r1.MnfDate MfgDate
	,r1.MnfSerial EngineNumber
	,r1.DistNumber ChassisNo
	,r1.Notes BatteryNo
    ,r1.LotNumber RegNo
    ,UF.Descr AS COLOUR
    ,r1."InDate" as "AdmissionDate"
    ,R1.LotNumber AS "WorkOrderNo"
FROM OPCH T0
Inner Join PCH1 T1 ON T1."DocEntry" = T0."DocEntry"
Left Join sri1 r on T1."ItemCode" = r."ItemCode"
		And T1."LineNum" = r."BaseLinNum"
		And T1."DocEntry" = r."BaseEntry"
INNER JOIN OSRN r1 ON r1.SysNumber = r.SysSerial
	AND r1.ItemCode = r.ItemCode
--INNER JOIN pdn1 n1 ON n1.DocEntry = r.BaseEntry
--	AND n1.ItemCode = r.ItemCode
	--AND n1.LineNum = r.BaseLinNum
--INNER JOIN opdn n ON n.DocEntry = n1.DocEntry
--LEFT OUTER JOIN opor pr ON pr.docentry = n1.baseentry
	--AND n1.basetype = '22'
	
LEFT  JOIN UFD1 UF ON UF.FldValue=R1.U_ITN_CLR
AND UF.TableID='OSRN'
LEFT JOIN CUFD CU ON CU.FieldID=UF.FieldID
AND CU.AliasID='ITN_CLR'
and CU.TableID='OSRN'
WHERE T0.DocEntry = @DocKey
order by SUBSTRING(DistNumber,15, 17) asc;
END
