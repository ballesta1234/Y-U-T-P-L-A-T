
/*



CREATE TABLE [dbo].[Valores](
	[Id] [int] NOT NULL,
	[Valor] [decimal](18, 3) NULL,
	[Mes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Valores] VALUES(1, 0.123, 1)
INSERT INTO [dbo].[Valores] VALUES(2, 0.287, 2)
INSERT INTO [dbo].[Valores] VALUES(3, 0.369, 3)
INSERT INTO [dbo].[Valores] VALUES(4, 0.400, 4)
INSERT INTO [dbo].[Valores] VALUES(5, 0.501, 5)
INSERT INTO [dbo].[Valores] VALUES(6, 0.69, 6)
INSERT INTO [dbo].[Valores] VALUES(7, 0.789, 7)
INSERT INTO [dbo].[Valores] VALUES(8, 0.886, 8)
INSERT INTO [dbo].[Valores] VALUES(9, 0.96, 9)
INSERT INTO [dbo].[Valores] VALUES(10, 0.10, 10)
INSERT INTO [dbo].[Valores] VALUES(11, 0.11, 11)
INSERT INTO [dbo].[Valores] VALUES(12, 0.12, 12)
GO



CREATE FUNCTION ObtenerTodasMediciones()
RETURNS TABLE
AS
RETURN
(
	SELECT Valor, Mes from dbo.Valores
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

*/
