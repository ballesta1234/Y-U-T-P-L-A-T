

CREATE TABLE [dbo].[ValoresBORRAR](
	[Id] [int] NOT NULL,
	[Valor] [decimal](18, 0) NULL,
	[Mes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO [dbo].[ValoresBORRAR] VALUES(1, 1, 1)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(2, 2, 2)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(3, 3, 3)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(4, 14, 4)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(5, 15, 5)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(6, 16, 6)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(7, 17, 7)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(8, 18, 8)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(9, 19, 9)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(10, 20, 10)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(11, 21, 11)
INSERT INTO [dbo].[ValoresBORRAR] VALUES(12, 22, 12)


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
CREATE PROCEDURE dbo.ObtenerMedicionPorMes @Mes int
AS 
BEGIN
	BEGIN TRY
		DECLARE @Valor decimal
		DECLARE @ParmDefinition nvarchar(500);

		SET @ParmDefinition = N''@paramMes int, @retvalOUT int OUTPUT'';

		EXEC [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.sp_executesql N''SELECT @retvalOUT = [KAIROS_BUXIS].dbo.ObtenerMedicionPorMes(@paramMes)'', @ParmDefinition,  @paramMes = @mes, @retvalOUT=@Valor OUTPUT;
		RETURN @Valor
	END TRY
	BEGIN CATCH
		RETURN 67
	END CATCH
END
')

EXEC('
CREATE PROCEDURE dbo.ObtenerTodasMediciones
AS
BEGIN
	BEGIN TRY
		EXEC [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.sp_executesql N''SELECT Valor, Mes FROM [KAIROS_BUXIS].dbo.ObtenerTodasMediciones()'';
	END TRY
	BEGIN CATCH
		SELECT Valor, Mes FROM dbo.ValoresBORRAR
	END CATCH
END
')
