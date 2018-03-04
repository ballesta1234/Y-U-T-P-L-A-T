CREATE PROCEDURE CrearLinkedServer AS
   BEGIN TRY
      EXEC master.dbo.sp_addlinkedserver @server = N'DESKTOP-NAIO2G5\SQLEXPRESS', @srvproduct=N'SQL Server'
	  EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'DESKTOP-NAIO2G5\SQLEXPRESS', @useself=N'True', @locallogin=N'DESKTOP-NAIO2G5\balle', @rmtuser=N'DESKTOP-NAIO2G5\balle'
   END TRY
   BEGIN CATCH      
   END CATCH


   EXEC CrearLinkedServer


alter PROCEDURE dbo.pepe
AS 
BEGIN
    DECLARE @VALOR decimal
	DECLARE @ParmDefinition nvarchar(500);

	SET @ParmDefinition = N'@retvalOUT int OUTPUT';

    EXEC [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.sp_executesql N'SELECT @retvalOUT = [KAIROS_BUXIS].dbo.ObtenerMedicion()', @ParmDefinition, @retvalOUT=@VALOR OUTPUT;
    RETURN @VALOR
END

declare @aaa decimal
exec @aaa =  dbo.pepe
print @aaa
