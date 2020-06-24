
	
		SELECT DISTINCT t0."DocEntry"
			,T0."ObjType"
			,t6."SeriesName"
			,'AP Invoice' AS "DOCTYPE"
			,t0."DocNum"
			,t0."DocDate"
			,CASE 
				WHEN T0."CANCELED" = 'Y'
					THEN 'CANCEL'
				ELSE T0."CardName"
				END AS "Vendor"
			,T0."CardName" AS "CardName"
			,T0."NumAtCard" AS "VendorRefNo"
			,'' AS "BP PAN NO"
			,T0."DiscSum" AS "Discount"
			,(
				SELECT "Name"
				FROM OCPR
				WHERE OCPR."CntctCode" = T0."CntctCode"
				) AS "ContactPerson"
			,ISNULL((
					SELECT (SUM(PCH1."LineTotal") - T0."DiscSum")
					FROM PCH1
					WHERE T0."DocEntry" = PCH1."DocEntry"
						AND T0."VatSum" > 0
						AND T0.U_ITN_DOC_TYPE='Local'
					AND T0."DocType" = 'I'
						AND PCH1."TaxCode"  LIKE '%vat%'
					), 0) AS "LocalPurchaseTaxableAmount"
			
			
			,ISNULL((
					CASE 
						WHEN T0.U_ITN_DOC_TYPE='Local'
							and T1.TaxCode LIKE 'VAT%'
							AND T0."DocType" = 'I'
							THEN ISNULL(T0."VatSum", 0)
							
						END
					), 0) AS "LocalPurchaseTaxAmount"
			,ISNULL((
					SELECT (SUM(PCH1."LineTotal") - T0."DiscSum")
					FROM PCH1
					WHERE T0."DocEntry" = PCH1."DocEntry"
						AND T0.U_ITN_DOC_TYPE<>'Import'
					    AND PCH1.TaxCode LIKE '%EXEMPT%'
					), 0) AS "EXEMPT_PURCHASE"
			
			
			
			,ISNULL((
				SELECT (OPCH."U_ITN_TAXABLE_AMT")
				FROM OPCH
				WHERE T0."DocEntry" = OPCH."DocEntry"
					--AND OPCH."U_VAM" > 0
					AND T0.U_ITN_DOC_TYPE = 'Import'
					), 0) AS "ImportTaxableAmount"
			
			,ISNULL((
				SELECT (OPCH."U_ITN_VAT_AMT")
				FROM OPCH
				WHERE T0."DocEntry" = OPCH."DocEntry"
					--AND OPCH."U_VAM" > 0
					AND T0.U_ITN_DOC_TYPE = 'Import'
					), 0) AS "ImportVatAmount"
			
			
				,ISNULL((
				SELECT (OPCH."DocTotal"-OPCH.DiscSum)
				FROM OPCH
				WHERE T0."DocEntry" = OPCH."DocEntry"
					AND T0.DocType ='S'
					AND OPCH.U_ITN_EXPENSES_TYPE='Yes'
				), 0) AS "AdministrativeTaxableAmt_Exps"
			
				,ISNULL((
				SELECT (OPCH.VatSum)
				FROM OPCH
				WHERE T0."DocEntry" = OPCH."DocEntry"
					AND T0.DocType ='S'
					AND OPCH.U_ITN_EXPENSES_TYPE='Yes'
				), 0) AS "AdministrativeTaxAmt_Exps"
			
			--U_ITN_EXPENSES_TYPE
			
			--,T0."DocTotal" AS "DocTotal"
			,T5."Location"
			,T8."TaxId4" AS "PanNo"
			--,T0."U_PPN" AS "PP NO"
			,T0."NumAtCard" AS "PartyBilNo"
			,concat(ISNULL(T6."BeginStr", '') , '' , CAST(T0."DocNum" AS CHAR(20)) , '' , CAST(T6."EndStr" AS CHAR(20))) AS "InvoiceNo"
			,[dbo].[ITN_NEPALI_FMT_DATE](T0."U_ITN_NPDate") AS "NPDate"
			,T1."TaxCode"
		FROM OPCH T0
		INNER JOIN PCH1 T1 ON T0."DocEntry" = T1."DocEntry"
		LEFT OUTER JOIN OCRD T2 ON T0."CardCode" = T2."CardCode"
		LEFT OUTER JOIN CRD1 T7 ON T7."CardCode" = T2."CardCode"
		LEFT OUTER JOIN OCRG t3 ON T2."GroupCode" = t3."GroupCode"
		LEFT OUTER JOIN OLCT T5 ON T5."Code" = T1."LocCode"
		LEFT OUTER JOIN NNM1 t6 ON t6."Series" = T0."Series"
		LEFT OUTER JOIN CRD7 T8 ON T8."CardCode" = T0."CardCode"
			AND T8."Address" = ''
			AND T8."AddrType" = 'S'
		WHERE T0."CANCELED" NOT IN (
				'C'
				,'Y'
				)
			




			SELECT DocType FROM OPCH

			select * from OPCH where docnum=13