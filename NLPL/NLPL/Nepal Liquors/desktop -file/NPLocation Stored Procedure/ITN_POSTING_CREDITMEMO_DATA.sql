CREATE PROCEDURE ITN_POSTING_CREDITMEMO_DATA
(
@DocEntry INTEGER
)
AS
BEGIN
Declare @TotalSales DECIMAL(18, 2);
Declare @StartLoop INTEGER;
Declare @CounterLoop INTEGER;
Declare @Quantity DECIMAL(18, 2);
Declare @Price DECIMAL(18, 2);
Declare @Discount DECIMAL(18, 2);
Declare @WithOutTotalSales DECIMAL(18, 2);
Declare @WithOutTotalAmount DECIMAL(18, 2);
Declare @WithOutGrandTotalAmount DECIMAL(18, 2);
Declare @INT_VAL INT;

Set @INT_VAL =  (SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='TEMP_TYPE' AND TABLE_SCHEMA=(Select SCHEMA_NAME()));
IF(@INT_VAL>0) 
DROP TABLE TEMP_TYPE;
END;

CREATE TABLE TEMP_TYPE
(
      ID INTEGER, 
      "TaxCode" NVARCHAR(20), 
      "Quantity" decimal(20, 0), 
      "Price" decimal(20, 0), 
      "Discount" decimal(20, 0)
);

SET @TotalSales = (SELECT SUM(ISNULL("PriceBefDi", 0) * ISNULL("Quantity", 0)) FROM RIN1 WHERE "DocEntry" = @DocEntry);
                  
INSERT INTO "TEMP_TYPE" SELECT (ROW_NUMBER() OVER (ORDER BY "LineNum")), "TaxCode", "Quantity", "PriceBefDi", "DiscPrcnt"
                                          FROM RIN1 
                                          WHERE "DocEntry" = @DocEntry AND 
                                          ISNULL("TaxCode", '') = '';

SET @CounterLoop =  (SELECT COUNT(*) FROM "TEMP_TYPE");
            SET @StartLoop = 1;
            SET @WithOutGrandTotalAmount = 0;
      WHILE @StartLoop <= @CounterLoop 
            BEGIN 
            SET @Quantity= (SELECT "Quantity" FROM "TEMP_TYPE" WHERE ID = @StartLoop);
            SET @Price= (SELECT "Price" FROM "TEMP_TYPE" WHERE ID = @StartLoop);
            SET @Discount= (SELECT "Discount" FROM "TEMP_TYPE" WHERE ID = @StartLoop);
            SET @WithOutTotalSales = @Price * @Quantity;
            SET @WithOutTotalAmount = @WithOutTotalSales - (@WithOutTotalSales * @Discount / 100);
            SET @WithOutGrandTotalAmount = @WithOutGrandTotalAmount + @WithOutTotalAmount;
            SET @StartLoop = @StartLoop + 1;
      END;


SELECT DISTINCT T9."U_Username" AS "username", T9."U_Password" AS "password", T7."RevOffice" AS "seller_pan", 
ISNULL(T3."TaxId4", '') AS "buyer_pan", T8."Indicator" AS "fiscal_year", 
T0."CardName" AS "buyer_name", '102' AS "ref_invoice_number", CAST(T0."DocDate" AS nvarchar(20)) AS "return_date",
CAST(T0."DocNum" AS nvarchar(50)) AS "credit_note_number", T0."Comments" AS "reason_for_return", @TotalSales AS "total_sales",
  ISNULL(T0."DocTotal", 0) - (ISNULL(T0."VatSum", 0) + ISNULL(T0."RoundDif", 0)) AS "taxable_sales_vat", T0."VatSum" AS "vat", 0.0 AS "excisable_amount", 
  0.0 AS "excise", 0.0 AS "taxable_sales_hst", 0.0 AS "hst", 0.0 AS "amount_for_esf", 0.0 AS "esf", 0.0 AS "export_sales", @WithOutGrandTotalAmount AS "tax_exempted_sales"
  FROM ORIN T0 
 INNER JOIN RIN1 T1 ON T0."DocEntry" = T1."DocEntry" 
 INNER JOIN OCRD T2 ON T2."CardCode" = T0."CardCode" 
 LEFT OUTER JOIN CRD7 T3 ON T3."CardCode" = T2."CardCode" 
 LEFT OUTER JOIN OUSR T4 ON T4.USERID = T0."UserSign"
  LEFT OUTER JOIN INV1 T5 ON T1."BaseEntry" = T5."DocEntry" AND T1."BaseLine" = T5."LineNum" 
 LEFT OUTER JOIN OINV T6 ON T6."DocEntry" = T5."DocEntry" 
LEFT OUTER JOIN OADM T7 ON 1 = 1 
LEFT OUTER JOIN NNM1 T8 ON T8."Series" = T0."Series"
JOIN "@CBMS_CONFIG" T9 on 1 = 1
WHERE T0."DocEntry" = @DocEntry;
END
