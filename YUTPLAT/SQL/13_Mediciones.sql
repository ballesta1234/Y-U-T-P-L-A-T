
DECLARE @ID_INDICADOR INT

SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'SPI'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 1.00, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 1, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.80, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.85, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'SPI Servicios'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 1, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 1, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.85, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.80, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'SPI Proyectos llave en mano'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 1.00, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 1.00, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 1, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.90, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'CPI'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 1.12, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 1.21, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.90, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 1.10, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'CPI Servicios'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 1.14, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 1.22, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 1.10, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.80, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'CPI Proyectos llave en mano'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.96, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.98, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.94, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 1, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Retrospectivas realizadas / Total que correspondan'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.85, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.85, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.80, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.76, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = '% Retrabajo por detección externa'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.02, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.03, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.04, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.03, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Entregas con testing incompleto / Total que corresponda'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'amolinari', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0, GETDATE(), 'amolinari', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Grado de satisfacción de los alumnos en cuanto al curso en general'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Grado de satisfacción de los alumnos en cuanto al docente que imparte el curso'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0, GETDATE(), 'cfontela', NULL, 2018, 0, 1)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'No conformidades de auditorías internas / Total de ítems auditados para los procesos del Sistema de Gestión de Calidad'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.37, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.37, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.37, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.37, GETDATE(), 'aromero', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Oportunidades de Mejora implementadas, detectadas en las auditorías internas  / Total de Oportunidades de Mejora detectadas en las auditorías internas'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.45, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.45, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.45, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.45, GETDATE(), 'aromero', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Días de atraso en el cumplimiento del plan de auditorías interna / cantidad de días totales de dichas auditorías (respecto de fecha original de fin de auditoría)'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'aromero', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'aromero', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'aromero', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0, GETDATE(), 'aromero', NULL, 2018, 0, 1)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Total de Solicitudes de Acción vencidas sobre total de Solicitudes de Acción'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.04, GETDATE(), 'aromero', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Solicitudes de acción aplicadas sobre solicitudes de acción requeridas'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.86, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.86, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.86, GETDATE(), 'aromero', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.75, GETDATE(), 'aromero', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = '(Precio de Venta - Costo) / Costo (Incluyendo costos directos e indirectos)'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, -0.17, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, -0.35, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, -0.08, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.26, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = '(Rentabilidad acumulada del año actual - Rentabilidad acumulada en el mismo período del año anterior) / Rentabilidad acumulada del año actual'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, -1.43, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, -1.26, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, -5.97, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, -3.88, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Total de votos negativos y neutrales / Total de votos'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Total de compras vencidas y replanificadas / total de compras'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.16, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.16, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.28, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.27, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Inversión total en I+D / Gastos totales de la organización en las actividades promovidas'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.05, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.06, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.07, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.70, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Forecast real / Forecast presupuestado'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 1.13, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.84, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.79, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 1.44, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Rentabilidad bruta: (Facturación - Mano de obra directa) / Facturación'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, -0.01, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, -0.51, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.40, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Rentabilidad neta: (Rentabilidad bruta - Costos indirectos) / Facturación'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, -0.1, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, -0.64, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, -0.14, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.17, GETDATE(), 'jdelvalle', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Promedio de puntajes de satisfacción global en la encuesta al cliente'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.72, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.72, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.72, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.72, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Encuesta al Cliente (Proyectos)'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0.58, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0.58, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0.58, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0.58, GETDATE(), 'nvaniggia', NULL, 2018, 0, 0)



SELECT @ID_INDICADOR = IndicadorID FROM dbo.Indicador WHERE Nombre = 'Encuesta al Cliente (Capacitaciones)'

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 1, 0, GETDATE(), 'nvaniggia', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 2, 0, GETDATE(), 'nvaniggia', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 3, 0, GETDATE(), 'nvaniggia', NULL, 2018, 0, 1)

INSERT INTO dbo.Medicion(IndicadorID, Mes, Valor, FechaCarga, UsuarioCargo, Comentario, Anio, SeDebeNotificar, NoAplica)
VALUES(@ID_INDICADOR, 4, 0, GETDATE(), 'nvaniggia', NULL, 2018, 0, 1)

