
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos.', 
	N'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos.', 
	N'2018-01-19 22:18:00', 
	NULL, 
	NULL, 
	Id 
FROM [dbo].[Area] WHERE Nombre = N'Ingeniería de Software'
