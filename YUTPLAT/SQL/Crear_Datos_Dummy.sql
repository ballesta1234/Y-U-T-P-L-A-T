
/*



CREATE TABLE [dbo].[Valores](
	[Id] [int] NOT NULL,
	[Valor] [decimal](18, 0) NULL,
	[Mes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Valores] VALUES(1, 1, 1)
INSERT INTO [dbo].[Valores] VALUES(2, 2, 2)
INSERT INTO [dbo].[Valores] VALUES(3, 3, 3)
INSERT INTO [dbo].[Valores] VALUES(4, 14, 4)
INSERT INTO [dbo].[Valores] VALUES(5, 15, 5)
INSERT INTO [dbo].[Valores] VALUES(6, 16, 6)
INSERT INTO [dbo].[Valores] VALUES(7, 17, 7)
INSERT INTO [dbo].[Valores] VALUES(8, 18, 8)
INSERT INTO [dbo].[Valores] VALUES(9, 19, 9)
INSERT INTO [dbo].[Valores] VALUES(10, 20, 10)
INSERT INTO [dbo].[Valores] VALUES(11, 21, 11)
INSERT INTO [dbo].[Valores] VALUES(12, 22, 12)
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
RETURNS decimal  
AS  
BEGIN  
	DECLARE @VALOR decimal
    SELECT @VALOR = Valor FROM dbo.Valores WHERE Mes = @mes
	RETURN @VALOR
END;  
GO


SELECT dbo.ObtenerMedicionPorMes(9)




*/
