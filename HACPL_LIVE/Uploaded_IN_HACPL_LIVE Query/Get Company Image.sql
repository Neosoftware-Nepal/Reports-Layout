USE [HACPL_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITN_GetCompanyImage]    Script Date: 02/04/2020 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_ITN_GetCompanyImage]
AS 
Begin
Select concat("BitmapPath","LogoFile")  From OADP;
End
