CREATE Procedure SP_ITN_CompanyDetails
AS
BEGIN
SELECT  OADM."CompnyName" AS "CompanyName"
    ,OADM."CompnyAddr" AS "CompanyAddress"
    ,ADM1."Building" AS "CompanyBuilding"
    ,ADM1."Block" AS "CompanyBlock"
    ,ADM1."Street" AS "CompanyStreet"
    ,ADM1."StreetNo" AS "CompanyPoBoX"
    ,ADM1."City" AS "CompanyCity"
    ,ADM1."ZipCode" AS "CompanyZipCode"
    ,OADM."RevOffice" AS "CompanyPAN"
    ,OADM."Phone1" AS "CompanyPhone"
    ,OADM."Fax" AS "CompanyFax"
    ,OADM."E_Mail" AS "CompanyEmail"
    ,OADM."Country" AS "CompanyCountryName"
    ,ST2."Name" AS "ComStateName"    
FROM OADM
LEFT JOIN OCST ST2 ON ST2."Code" = OADM."State"
    AND ST2."Country" = OADM."Country"
LEFT JOIN ADM1 ON OADM."Code" = ADM1."Code";

END;