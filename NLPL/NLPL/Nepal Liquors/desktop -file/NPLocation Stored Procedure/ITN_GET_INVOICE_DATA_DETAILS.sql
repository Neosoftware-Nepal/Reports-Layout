CREATE PROCEDURE ITN_GET_INVOICE_DATA_DETAILS 
(
@DocEntry integer
)
AS
BEGIN
Declare @FinancialYear NVARCHAR(20);
Declare @TotalSales decimal(18, 2);
Declare @StartLoop integer;
Declare @CounterLoop integer;
Declare @Quantity decimal(18, 2);
Declare @Price decimal(18, 2);
Declare @Discount decimal(18, 2);
Declare @WithOutTotalSales decimal(18, 2);
Declare @WithOutTotalAmount decimal(18, 2);
Declare @WithOutGrandTotalAmount decimal(18, 2);
Declare @INT_VAL INT;

Set @INT_VAL = (SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='TEMP_TYPE' AND TABLE_SCHEMA= (Select SCHEMA_NAME()));
IF(@INT_VAL>0)
DROP TABLE TEMP_TYPE;
END;

CREATE TABLE TEMP_TYPE
(
      ID INTEGER,
      "TaxCode" NVARCHAR(20), 
      "Quantity" DECIMAL(20, 0), 
      "Price" DECIMAL(20, 0), 
      "Discount" DECIMAL(20, 0)
);

SET @TotalSales = (SELECT SUM(ISNULL("PriceBefDi", 0) * ISNULL("Quantity", 0)) FROM INV1 WHERE "DocEntry" = @DocEntry);
                            
INSERT INTO TEMP_TYPE SELECT (ROW_NUMBER() OVER (ORDER BY "LineNum")), "TaxCode", "Quantity", "PriceBefDi", "DiscPrcnt"
                                          FROM INV1 
                                          WHERE "DocEntry" = @DocEntry AND 
                                          ISNULL("TaxCode", '') = '';
      


            Set @CounterLoop = (SELECT COUNT(*) FROM "TEMP_TYPE");
           Set @StartLoop = 1;
            SET @WithOutGrandTotalAmount = 0;
      WHILE @StartLoop <= @CounterLoop 
            BEGIN 
            SET @Quantity = (SELECT "Quantity" FROM "TEMP_TYPE" WHERE ID = @StartLoop);
            SET @Price =(SELECT "Price" FROM "TEMP_TYPE" WHERE ID = @StartLoop);
            SET @Discount =(SELECT "Discount" FROM "TEMP_TYPE" WHERE ID = @StartLoop);
            SET @WithOutTotalSales = @Price * @Quantity;
            SET @WithOutTotalAmount = @WithOutTotalSales - (@WithOutTotalSales * @Discount / 100);
            SET @WithOutGrandTotalAmount = @WithOutGrandTotalAmount + @WithOutTotalAmount;
            Set @StartLoop = @StartLoop + 1;
      END;  
      SELECT DISTINCT T5."U_Username" AS "username", T5."U_Password" AS "password", T7."RevOffice" AS "seller_pan", 
      ISNULL(T3."TaxId4", '') AS "buyer_pan", t8."Indicator" AS "fiscal_year", T0."CardName" AS "buyer_name", 
      CAST(T0."DocNum" AS NVARCHAR(20)) AS "invoice_number", CAST(T0."DocDate" AS NVARCHAR(20)) AS "invoice_date", 
      @TotalSales AS "total_sales", 
      ISNULL(T0."DocTotal", 0) - (ISNULL(T0."VatSum", 0) + ISNULL(T0."RoundDif", 0)) AS "taxable_sales_vat",
      T0."VatSum" AS "vat", 0.0 AS "excisable_amount", 0.0 AS "excise", 0.0 AS "taxable_sales_hst", 0.0 AS "hst",
      0.0 AS "amount_for_esf", 0.0 AS "esf", 0.0 AS "export_sales", @WithOutGrandTotalAmount AS "tax_exempted_sales"    
      FROM OINV  AS T0 
      INNER JOIN INV1 T1 ON T0."DocEntry" = T1."DocEntry" 
      INNER JOIN OCRD T2 ON T2."CardCode" = T0."CardCode" 
      LEFT OUTER JOIN CRD7 T3 ON T3."CardCode" = T2."CardCode" 
      LEFT OUTER JOIN OUSR T4 ON T4.USERID = T0."UserSign" 
      JOIN "@CBMS_CONFIG" T5 ON 1 = 1
      LEFT OUTER JOIN OADM T7 ON 1 = 1 
      LEFT OUTER JOIN NNM1 T8 ON T8."Series" = T0."Series" 
      WHERE T0."DocEntry" = @DocEntry;  
END