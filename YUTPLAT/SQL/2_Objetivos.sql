
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos', 
	N'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Ingeniería de Software'

INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la eficiencia del método de estimación', 
	N'Mejorar la eficiencia del método de estimación', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Ingeniería de Software'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la eficiencia del testing y desarrollo', 
	N'Mejorar la eficiencia del testing y desarrollo', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Ingeniería de Software'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Brindar Servicios Informáticos de alto nivel y adecuada satisfacción de los clientes', 
	N'Brindar Servicios Informáticos de alto nivel y adecuada satisfacción de los clientes', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Capacitación Tecnológica'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la eficiencia del reclutamiento', 
	N'Mejorar la eficiencia del reclutamiento', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Servicios Informáticos de Valor Agregado'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Desalentar la rotación del personal', 
	N'Desalentar la rotación del personal', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'RRHH'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Aumentar el nivel de instrucción del personal', 
	N'Aumentar el nivel de instrucción del personal', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'RRHH'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora', 
	N'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Ingeniería de Software'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la gestión de Solicitudes de Acción', 
	N'Mejorar la gestión de Solicitudes de Acción', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Calidad'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la rentabilidad de los proyectos de desarrollo', 
	N'Mejorar la rentabilidad de los proyectos de desarrollo', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Administración y Finanzas'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la eficacia en la selección de Proveedores', 
	N'Mejorar la eficacia en la selección de Proveedores', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Administración y Finanzas'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la gestión de las compras', 
	N'Mejorar la gestión de las compras', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Administración y Finanzas'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Asegurar una proporción adecuada del presupuesto dedicada a I+D', 
	N'Asegurar una proporción adecuada del presupuesto dedicada a I+D', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Administración y Finanzas'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Evaluar la estimación del Forecast', 
	N'Evaluar la estimación del Forecast', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Administración y Finanzas'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Monitorear la solidez económica', 
	N'Monitorear la solidez económica', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Administración y Finanzas'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Mejorar la satisfacción del cliente', 
	N'Mejorar la satisfacción del cliente', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Comercial'
	
INSERT INTO [dbo].[Objetivo] ([Nombre], [Descripcion], [FechaCreacion], [UltimoUsuarioModifico], [FechaUltimaModificacion], [AreaID]) 
SELECT
	N'Monitorear las tareas comerciales', 
	N'Monitorear las tareas comerciales', 
	GETDATE(), NULL, NULL, Id FROM [dbo].[Area] WHERE Nombre = N'Desarrollo Comercial'
