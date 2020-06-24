CREATE PROCEDURE ITN_GET_INVOICE_DATA_DETAILS 
(
IN DocEntry integer
)
AS
FinancialYear NVARCHAR(20);
TotalSales decimal(18, 2);
StartLoop integer;
CounterLoop integer;
Quantity decimal(18, 2);
Price decimal(18, 2);
Discount decimal(18, 2);
WithOutTotalSales decimal(18, 2);
WithOutTotalAmount decimal(18, 2);
WithOutGrandTotalAmount decimal(18, 2);
INT_VAL INT;
BEGIN
SELECT COUNT(*) INTO INT_VAL FROM TABLES WHERE TABLE_NAME='TEMP_TYPE' AND SCHEMA_NAME=CURRENT_SCHEMA;
IF(INT_VAL>0)
THEN 
DROP TABLE TEMP_TYPE;
END IF;
CREATE COLUMN TABLE TEMP_TYPE
(
      ID INTEGER,
      "TaxCode" NVARCHAR(20), 
      "Quantity" DECIMAL(20, 0), 
      "Price" DECIMAL(20, 0), 
      "Discount" DECIMAL(20, 0)
);
SELECT 
(
SELECT SUM(IFNULL("PriceBefDi", 0) * IFNULL("Quantity", 0)) FROM INV1 WHERE "DocEntry" = :DocEntry
) 
INTO TotalSales FROM DUMMY;                              
      INSERT INTO "TEMP_TYPE"(
                                          SELECT (ROW_NUMBER() OVER (ORDER BY "LineNum")), "TaxCode", "Quantity", "PriceBefDi", "DiscPrcnt"
                                          FROM INV1 
                                          WHERE "DocEntry" = :DocEntry AND 
                                          IFNULL("TaxCode", '') = ''
                                    )     ;
      


            SELECT (SELECT COUNT(*) FROM "TEMP_TYPE") INTO CounterLoop FROM DUMMY;
            StartLoop := 1;
            WithOutGrandTotalAmount := 0;
      WHILE :StartLoop <= :CounterLoop 
            DO 
            SELECT (SELECT "Quantity" FROM "TEMP_TYPE" WHERE ID = :StartLoop) INTO Quantity FROM DUMMY;
            SELECT (SELECT "Price" FROM "TEMP_TYPE" WHERE ID = :StartLoop) INTO Price FROM DUMMY;
            SELECT (SELECT "Discount" FROM "TEMP_TYPE" WHERE ID = :StartLoop) INTO Discount FROM DUMMY;
            WithOutTotalSales := :Price * :Quantity;
            WithOutTotalAmount := :WithOutTotalSales - (:WithOutTotalSales * :Discount / 100);
            WithOutGrandTotalAmount := :WithOutGrandTotalAmount + :WithOutTotalAmount;
            StartLoop := :StartLoop + 1;
      END WHILE;  
      SELECT DISTINCT T5."U_Username" AS "username", T5."U_Password" AS "password", T7."RevOffice" AS "seller_pan", 
      IFNULL(T3."TaxId4", '') AS "buyer_pan", t8."Indicator" AS "fiscal_year", T0."CardName" AS "buyer_name", 
      CAST(T0."DocNum" AS NVARCHAR(20)) AS "invoice_number", CAST(T0."DocDate" AS NVARCHAR(20)) AS "invoice_date", 
      :TotalSales AS "total_sales", 
      IFNULL(T0."DocTotal", 0) - (IFNULL(T0."VatSum", 0) + IFNULL(T0."RoundDif", 0)) AS "taxable_sales_vat",
      T0."VatSum" AS "vat", 0.0 AS "excisable_amount", 0.0 AS "excise", 0.0 AS "taxable_sales_hst", 0.0 AS "hst",
      0.0 AS "amount_for_esf", 0.0 AS "esf", 0.0 AS "export_sales", :WithOutGrandTotalAmount AS "tax_exempted_sales", (CAST(NOW() AS NVARCHAR(20)) || '  ' || RIGHT('' || LTRIM(RIGHT(CAST(NOW() AS varchar), 8)), 8)) AS "Currentdate"
      
      FROM OINV  AS T0 
      INNER JOIN INV1 T1 ON T0."DocEntry" = T1."DocEntry" 
      INNER JOIN OCRD T2 ON T2."CardCode" = T0."CardCode" 
      LEFT OUTER JOIN CRD7 T3 ON T3."CardCode" = T2."CardCode" 
      LEFT OUTER JOIN OUSR T4 ON T4.USERID = T0."UserSign" 
      JOIN "@CBMS_CONFIG" T5 ON 1 = 1
      LEFT OUTER JOIN OADM T7 ON 1 = 1 
      LEFT OUTER JOIN NNM1 T8 ON T8."Series" = T0."Series" 
      WHERE T0."DocEntry" = :DocEntry;  
END;