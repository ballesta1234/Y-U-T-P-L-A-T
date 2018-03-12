INSERT INTO dbo.Parametros VALUES('UsarLinkedServer', 'false')

CREATE TABLE [dbo].[ValoresBORRAR](
	[Id] [int] NOT NULL,
	[Valor] [decimal](18, 3) NULL,
	[Mes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO [dbo].[ValoresBORRAR] VALUES(1, 0.01, 1)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(2, 0.2, 2)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(3, 0.3, 3)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(4, 0.4, 4)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(5, 0.5, 5)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(6, 0.6, 6)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(7, 0.7, 7)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(8, 0.8, 8)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(9, 0.9, 9)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(10, 0.10, 10)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(11, 0.11, 11)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(12, 0.12, 12)


EXEC('
CREATE PROCEDURE CrearLinkedServer AS
   BEGIN TRY
      EXEC master.dbo.sp_addlinkedserver @server = N''DESKTOP-NAIO2G5\SQLEXPRESS'', @srvproduct=N''SQL Server''
	  EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N''DESKTOP-NAIO2G5\SQLEXPRESS'', @useself=N''True'', @locallogin=N''DESKTOP-NAIO2G5\balle'', @rmtuser=N''DESKTOP-NAIO2G5\balle''
   END TRY
   BEGIN CATCH      
   END CATCH
')


EXEC('
CREATE PROCEDURE dbo.ObtenerMedicionPorMes 
@Mes int,
@ValorOutput decimal(18,3) OUTPUT
AS 
BEGIN	
	DECLARE @UsarLinkedServer VARCHAR(300)
	SELECT @UsarLinkedServer = Valor FROM dbo.Parametros WHERE Clave = ''UsarLinkedServer''
	
	IF(@UsarLinkedServer = ''true'')
	BEGIN		
		DECLARE @ParmDefinition nvarchar(500);
		SET @ParmDefinition = N''@paramMes int, @retvalOUT decimal(18,3) OUTPUT'';

		EXEC [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.sp_executesql N''SELECT @retvalOUT = [KAIROS_BUXIS].dbo.ObtenerMedicionPorMes(@paramMes)'', @ParmDefinition,  @paramMes = @mes, @retvalOUT = @ValorOutput OUTPUT;
	END
	ELSE
	BEGIN
		SELECT @ValorOutput = Valor FROM dbo.ValoresBORRAR WHERE Mes = @Mes
	END
END
')

EXEC('
CREATE PROCEDURE dbo.ObtenerTodasMediciones
AS
BEGIN
	DECLARE @UsarLinkedServer VARCHAR(300)
	SELECT @UsarLinkedServer = Valor FROM dbo.Parametros WHERE Clave = ''UsarLinkedServer''
	
	IF(@UsarLinkedServer = ''true'')
	BEGIN 	
		EXEC [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.sp_executesql N''SELECT Valor, Mes FROM [KAIROS_BUXIS].dbo.ObtenerTodasMediciones()'';
	END
	ELSE
	BEGIN
		SELECT Valor, Mes FROM dbo.ValoresBORRAR
	END
END
')
