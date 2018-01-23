
DECLARE @META_EXCELENTE INT
DECLARE @META_SATISFACTORIA INT
DECLARE @META_ACEPTABLE INT
DECLARE @META_A_MEJORAR INT
DECLARE @META_INACEPTABLE INT

INSERT INTO [dbo].[Meta] ([Valor1], [Valor2], [Signo1], [Signo2]) VALUES (CAST(0.700 AS Decimal(18, 3)), CAST(0.810 AS Decimal(18, 3)), 4, 1)
SET @META_ACEPTABLE = @@IDENTITY

INSERT INTO [dbo].[Meta] ([Valor1], [Valor2], [Signo1], [Signo2]) VALUES (CAST(0.490 AS Decimal(18, 3)), CAST(0.700 AS Decimal(18, 3)), 4, 1)
SET @META_A_MEJORAR = @@IDENTITY

INSERT INTO [dbo].[Meta] ([Valor1], [Valor2], [Signo1], [Signo2]) VALUES (CAST(0.990 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 4, 0)
SET @META_EXCELENTE = @@IDENTITY

INSERT INTO [dbo].[Meta] ([Valor1], [Valor2], [Signo1], [Signo2]) VALUES (CAST(0.000 AS Decimal(18, 3)), CAST(0.490 AS Decimal(18, 3)), 4, 1)
SET @META_INACEPTABLE = @@IDENTITY

INSERT INTO [dbo].[Meta] ([Valor1], [Valor2], [Signo1], [Signo2]) VALUES (CAST(0.810 AS Decimal(18, 3)), CAST(0.990 AS Decimal(18, 3)), 4, 1)
SET @META_SATISFACTORIA = @@IDENTITY

INSERT INTO [dbo].[Indicador] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], 
								[FechaUltimaModificacion], [ObjetivoID], [FrecuenciaMedicionIndicadorID], 
								[MetaInaceptableMetaID], 
								[MetaAMejorarMetaID], [MetaAceptableMetaID], [MetaSatisfactoriaMetaID], [MetaExcelenteMetaID], [Grupo])
SELECT 
	N'2 modificado', 
	N'SPI o Schedule Performance Index: Earned Value  / Planned Value de los proyectos activos llave en mano, incluyendo en garantía. 65777', 
	N'2018-01-19 22:20:00', 
	N'mballestero', 
	N'2018-01-20 21:28:00', 
	Id,
	2, 
	@META_INACEPTABLE, 
	@META_A_MEJORAR, 
	@META_ACEPTABLE, 
	@META_SATISFACTORIA, 
	@META_EXCELENTE, 
	1
FROM 
	[dbo].[Objetivo]
WHERE [Nombre] = N'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos.'

UPDATE [dbo].[Indicador] SET [Grupo] = @@IDENTITY
