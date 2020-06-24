Create PROCEDURE ITN_GetApiDetails
AS
BEGIN
select "U_BillApiUrl", "U_BillReturnApiUrl", "U_Enabled" from "@CBMS_CONFIG";
END;