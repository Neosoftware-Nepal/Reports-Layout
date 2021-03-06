USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_CostSheet]    Script Date: 02/04/2020 9:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_ITN_CostSheet] 
AS
BEGIN
select  * from (SELECT 
          T0.DocNum
          ,T4.DocDate AS PostingDate
          ,T4.U_ITN_PP as PPNo
          ,T4.U_ITN_WO
          ,T1.ItemCode
          ,T1.Quantity
          ,T1.LineTotal
                  ,T1.FobValue as "GRPO Total Amount" 
                 ,T1.TtlExpndLC as "Landed Cost Total"
                           ,T1.FobValue+T1.TtlExpndLC as TotalCost 
          
         , T5.[AlcName]
          --T0.[CostSum] as "Total Landed Cost",
          ,T2.[CostSum]
FROM OIPF T0  
inner JOIN IPF1 T1 ON T0.[DocEntry] = T1.[DocEntry] 
Left JOIN IPF2 T2 ON T0.[DocEntry] = T2.[DocEntry] 
Left Join PDN1 T3 ON T1."BaseEntry" = T3."DocEntry" and T1."BaseType" = T3."ObjType" 
Left JOIN OPDN T4 ON T3.[DocEntry]  = T4.[DocEntry] and T0."AgentNum" = T4."U_ITN_WO"
inner  join OALC T5 ON T2.AlcCode = T5.AlcCode ) t  
  PIVOT(
    max(t.[CostSum]) 
   
    for t.AlcName IN ( 
          "Nepal Custom Clearing Expenses", 
             "Custom Duty", 
             "Bank Charges",
             "Freight up to Border",
             "Road Development Fee",
             "Indian Custom Clearing Expense",
             "Port Clearing",
             "Transit Expenses",
             "Local Freight",
             "Insurance Premium",
             "Detention Charges",
             "Excise Duty",
             "CTD Expenses",
             "Usance Interest",
             "Unloading Expenses",
             "Photo Expenses",
             "Road Maint Tax",
             "Registration Expenses",
             "Custom Service Fee (CSF)",
             "Other Expenses"
             )
        ) a

	
END


