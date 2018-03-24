
/*



CREATE TABLE [dbo].[Valores](
	[Id] [int] NOT NULL,
	[Valor] [decimal](18, 3) NULL,
	[Mes] [int] NULL,
	[Proyecto] [varchar](200) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Valores] VALUES(1, 0.123, 1, 'Proyecto 1')
INSERT INTO [dbo].[Valores] VALUES(2, 0.287, 2, 'Proyecto 2')
INSERT INTO [dbo].[Valores] VALUES(3, 0.369, 3, 'Proyecto 3')
INSERT INTO [dbo].[Valores] VALUES(4, 0.400, 4, 'Proyecto 4')
INSERT INTO [dbo].[Valores] VALUES(5, 0.501, 5, 'Proyecto 5')
INSERT INTO [dbo].[Valores] VALUES(6, 0.69, 6, 'Proyecto 6')
INSERT INTO [dbo].[Valores] VALUES(7, 0.789, 7, 'Proyecto 7')
INSERT INTO [dbo].[Valores] VALUES(8, 0.886, 8, 'Proyecto 8')
INSERT INTO [dbo].[Valores] VALUES(9, 0.96, 9, 'Proyecto 9')
INSERT INTO [dbo].[Valores] VALUES(10, 0.10, 10, 'Proyecto 10')
INSERT INTO [dbo].[Valores] VALUES(11, 0.11, 11, 'Proyecto 11')
INSERT INTO [dbo].[Valores] VALUES(12, 0.12, 12, 'Proyecto 12')
GO



CREATE FUNCTION ObtenerTodasMediciones()
RETURNS TABLE
AS
RETURN
(
	SELECT Valor, Mes FROM dbo.Valores
);
GO

SELECT * FROM dbo.ObtenerTodasMediciones()


CREATE FUNCTION [dbo].[ObtenerMedicionPorMes] (@mes int)  
RETURNS decimal(18,3)
AS  
BEGIN  
	DECLARE @VALOR decimal(18, 3)
    SELECT @VALOR = Valor FROM dbo.Valores WHERE Mes = @mes
	RETURN @VALOR
END;  
GO


SELECT dbo.ObtenerMedicionPorMes(9)



CREATE FUNCTION ObtenerDetallesMediciones()
RETURNS TABLE
AS
RETURN
(
	SELECT Valor, Mes, Proyecto FROM dbo.Valores
);
GO

SELECT * FROM dbo.ObtenerDetallesMediciones()


*/
