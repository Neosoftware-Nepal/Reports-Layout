CREATE PROCEDURE ITN_POSTING_CREDITMEMO_DATA
(
IN DocEntry INTEGER
)
AS
TotalSales DECIMAL(18, 2);
StartLoop INTEGER;
CounterLoop INTEGER;
Quantity DECIMAL(18, 2);
Price DECIMAL(18, 2);
Discount DECIMAL(18, 2);
WithOutTotalSales DECIMAL(18, 2);
WithOutTotalAmount DECIMAL(18, 2);
WithOutGrandTotalAmount DECIMAL(18, 2);
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
      "Quantity" decimal(20, 0), 
      "Price" decimal(20, 0), 
      "Discount" decimal(20, 0)
);
SELECT 
      (
            SELECT SUM(ifnull("PriceBefDi", 0) * IFNULL("Quantity", 0)) FROM RIN1 WHERE "DocEntry" = :DocEntry
      ) 
                  INTO TotalSales 
                  FROM DUMMY;
                  
                  INSERT INTO "TEMP_TYPE"(
                                          SELECT (ROW_NUMBER() OVER (ORDER BY "LineNum")), "TaxCode", "Quantity", "PriceBefDi", "DiscPrcnt"
                                          FROM RIN1 
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


SELECT DISTINCT T9."U_Username" AS "username", T9."U_Password" AS "password", T7."RevOffice" AS "seller_pan", 
IFNULL(T3."TaxId4", '') AS "buyer_pan", T8."Indicator" AS "fiscal_year", 
T0."CardName" AS "buyer_name", '102' AS "ref_invoice_number", CAST(T0."DocDate" AS nvarchar(20)) AS "return_date",
CAST(T0."DocNum" AS nvarchar(50)) AS "credit_note_number", T0."Comments" AS "reason_for_return", :TotalSales AS "total_sales",
  IFNULL(T0."DocTotal", 0) - (IFNULL(T0."VatSum", 0) + IFNULL(T0."RoundDif", 0)) AS "taxable_sales_vat", T0."VatSum" AS "vat", 0.0 AS "excisable_amount", 
  0.0 AS "excise", 0.0 AS "taxable_sales_hst", 0.0 AS "hst", 0.0 AS "amount_for_esf", 0.0 AS "esf", 0.0 AS "export_sales", :WithOutGrandTotalAmount AS "tax_exempted_sales", (CAST(NOW() AS nvarchar(20)) || '  ' || RIGHT('' || LTRIM(RIGHT(CAST(NOW() AS varchar), 8)), 8)) AS "Currentdate"
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
WHERE T0."DocEntry" = :DocEntry;
END;