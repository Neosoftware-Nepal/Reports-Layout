CREATE PROCEDURE ITN_GETBATCHDETAILS (IN RefNum int)
AS
BEGIN
	SELECT T0."LotNumber"
		,T0."MnfSerial"
		,T0."DistNumber"
	FROM OSRN T0
	LEFT JOIN SRI1 T1 ON T1."SysSerial" = T0."SysNumber"
	LEFT JOIN OIGE T2 ON T2."DocNum" = T1."BaseNum"
		AND T2."ObjType" = T1."BaseType"
	WHERE T2."DocNum" = :RefNum;
END
