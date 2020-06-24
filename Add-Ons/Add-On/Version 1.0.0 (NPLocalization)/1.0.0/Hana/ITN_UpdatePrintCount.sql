CREATE PROCEDURE ITN_UPDATEPRINTCOUNT (IN DocKey INT)
AS
printCount INT;
BEGIN
	Select (
			SELECT "U_ITN_Print_Count"
			FROM OINV
			WHERE "DocEntry" = :DocKey
			) into printCount from DUMMY;

	IF (:printCount IS NULL)
	Then
		UPDATE OINV
		SET "U_ITN_Print_Count" = 1
		WHERE "DocEntry" = :DocKey;
	ELSE
		UPDATE OINV
		SET "U_ITN_Print_Count" = (:printCount + 1)
		WHERE "DocEntry" = :DocKey;
	END IF;
END;



