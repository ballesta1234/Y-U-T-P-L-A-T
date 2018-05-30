
-- 5	<=
-- 1	<
-- CREATE TABLE TEMP_INDICADORES (

-- 	ID int IDENTITY(1,1) PRIMARY KEY,
	
-- 	IND_NOMBRE NVARCHAR(MAX),
-- 	IND_DESCRIPCION NVARCHAR(MAX),	
-- 	IND_FRECUENCIA_MEDICION NVARCHAR(MAX),	
-- 	IND_OBJETIVO NVARCHAR(MAX),
	
-- 	MET_INACEPTABLE_VALOR1 DECIMAL(18,3),
-- 	MET_INACEPTABLE_VALOR2 DECIMAL(18,3),
-- 	MET_INACEPTABLE_SIGNO1 INT,
-- 	MET_INACEPTABLE_SIGNO2 INT,
	
-- 	MET_A_MEJORAR_VALOR1 DECIMAL(18,3),
-- 	MET_A_MEJORAR_VALOR2 DECIMAL(18,3),
-- 	MET_A_MEJORAR_SIGNO1 INT,
-- 	MET_A_MEJORAR_SIGNO2 INT,
	
-- 	MET_ACEPTABLE_VALOR1 DECIMAL(18,3),
-- 	MET_ACEPTABLE_VALOR2 DECIMAL(18,3),
-- 	MET_ACEPTABLE_SIGNO1 INT,
-- 	MET_ACEPTABLE_SIGNO2 INT,
	
-- 	MET_SATISFACTORIA_VALOR1 DECIMAL(18,3),
-- 	MET_SATISFACTORIA_VALOR2 DECIMAL(18,3),
-- 	MET_SATISFACTORIA_SIGNO1 INT,
-- 	MET_SATISFACTORIA_SIGNO2 INT,
	
-- 	MET_EXCELENTE_VALOR1 DECIMAL(18,3),
-- 	MET_EXCELENTE_VALOR2 DECIMAL(18,3),
-- 	MET_EXCELENTE_SIGNO1 INT,
-- 	MET_EXCELENTE_SIGNO2 INT,
	
--	RES_USERNAME1 NVARCHAR(256),
--	RES_USERNAME2 NVARCHAR(256)
-- );

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI',
	'SPI o Schedule Performance Index: Earned Value / Planned Value de los proyectos activos llave en mano, incluyendo en garantía',	
	'Mensual',	
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	0.00, 0.49, 5, 1, 	
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI Servicios',
	'SPI Servicios',	
	'Mensual',	
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI Proyectos llave en mano',
	'SPI Proyectos llave en mano',	
	'Mensual',	
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'CPI',
	'CPI o Cost Performance Index: Earned Value/Actual Cost de los proyectos activos llave en mano, incluyendo en garantía',	
	'Mensual',	
	'Mejorar la eficiencia del método de estimación',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'CPI Servicios',
	'CPI Servicios',	
	'Mensual',	
	'Mejorar la eficiencia del método de estimación',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'CPI Proyectos llave en mano',
	'CPI Proyectos llave en mano',	
	'Mensual',	
	'Mejorar la eficiencia del método de estimación',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Retrospectivas realizadas / Total que correspondan',
	'Retrospectivas realizadas / Total que correspondan',	
	'Mensual',	
	'Mejorar la eficiencia del testing y desarrollo',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'% Retrabajo por detección externa',
	'% Retrabajo por detección externa',	
	'Mensual',	
	'Mejorar la eficiencia del testing y desarrollo',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Entregas con testing incompleto / Total que corresponda',
	'Entregas con testing incompleto / Total que corresponda',	
	'Mensual',	
	'Mejorar la eficiencia del testing y desarrollo',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de satisfacción de los alumnos en cuanto al curso en general',
	'Grado de satisfacción de los alumnos en cuanto al curso en general',	
	'Mensual',	
	'Brindar Servicios Informáticos de alto nivel y adecuada satisfacción de los clientes',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de satisfacción de los alumnos en cuanto al docente que imparte el curso',
	'Grado de satisfacción de los alumnos en cuanto al docente que imparte el curso',	
	'Mensual',	
	'Brindar Servicios Informáticos de alto nivel y adecuada satisfacción de los clientes',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Nuevos ingresos / candidatos derivados a entrevista',
	'Nuevos ingresos / candidatos derivados a entrevista',	
	'Mensual',	
	'Mejorar la eficiencia del reclutamiento',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia: Egresos / Staff total (Acumulado)',
	'Grado de permanencia: Egresos / Staff total (Acumulado)',	
	'Mensual',	
	'Mejorar la eficiencia del reclutamiento',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia menor a 3 meses (Acumulado)',
	'Grado de permanencia menor a 3 meses (Acumulado)',	
	'Mensual',	
	'Mejorar la eficiencia del reclutamiento',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia mayor a 3 meses (Acumulado)',
	'Grado de permanencia mayor a 3 meses (Acumulado)',	
	'Mensual',	
	'Mejorar la eficiencia del reclutamiento',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Personal que renuncia por año (referidos a la dotación promedio anual) (Acumulado)',
	'Personal que renuncia por año (referidos a la dotación promedio anual) (Acumulado)',	
	'Mensual',	
	'Desalentar la rotación del personal',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Personal que renuncia SIVA (Acumulado)',
	'Personal que renuncia SIVA (Acumulado)',	
	'Mensual',	
	'Desalentar la rotación del personal',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Personal que renuncia Casa Central (Acumulado)',
	'Personal que renuncia Casa Central (Acumulado)',	
	'Mensual',	
	'Desalentar la rotación del personal',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total Horas Capacitación reales (excluye la inducción del primer mes) / Total de horas de Capacitación previstas (Acumulada)',
	'Total Horas Capacitación reales (excluye la inducción del primer mes) / Total de horas de Capacitación previstas (Acumulada)',	
	'Mensual',	
	'Aumentar el nivel de instrucción del personal',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'No conformidades de auditorías internas / Total de ítems auditados para los procesos del Sistema de Gestión de Calidad',
	'No conformidades de auditorías internas / Total de ítems auditados para los procesos del Sistema de Gestión de Calidad',	
	'Mensual',	
	'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Oportunidades de Mejora implementadas, detectadas en las auditorías internas  / Total de Oportunidades de Mejora detectadas en las auditorías internas',
	'Oportunidades de Mejora implementadas, detectadas en las auditorías internas  / Total de Oportunidades de Mejora detectadas en las auditorías internas',	
	'Mensual',	
	'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Días de atraso en el cumplimiento del plan de auditorías interna / cantidad de días totales de dichas auditorías (respecto de fecha original de fin de auditoría)',
	'Días de atraso en el cumplimiento del plan de auditorías interna / cantidad de días totales de dichas auditorías (respecto de fecha original de fin de auditoría)',	
	'Mensual',	
	'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total de Solicitudes de Acción vencidas sobre total de Solicitudes de Acción',
	'Total de Solicitudes de Acción vencidas sobre total de Solicitudes de Acción',	
	'Mensual',	
	'Mejorar la gestión de Solicitudes de Acción',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Solicitudes de acción aplicadas sobre solicitudes de acción requeridas',
	'Solicitudes de acción aplicadas sobre solicitudes de acción requeridas',	
	'Mensual',	
	'Mejorar la gestión de Solicitudes de Acción',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'(Precio de Venta - Costo) / Costo (Incluyendo costos directos e indirectos)',
	'(Precio de Venta - Costo) / Costo (Incluyendo costos directos e indirectos)',	
	'Mensual',	
	'Mejorar la rentabilidad de los proyectos de desarrollo',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'(Rentabilidad acumulada del año actual - Rentabilidad acumulada en el mismo período del año anterior) / Rentabilidad acumulada del año actual',
	'(Rentabilidad acumulada del año actual - Rentabilidad acumulada en el mismo período del año anterior) / Rentabilidad acumulada del año actual',	
	'Mensual',	
	'Mejorar la rentabilidad de los proyectos de desarrollo',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total de votos negativos y neutrales / Total de votos',
	'Total de votos negativos y neutrales / Total de votos',	
	'Mensual',	
	'Mejorar la eficacia en la selección de Proveedores',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total de compras vencidas y replanificadas / total de compras',
	'Total de compras vencidas y replanificadas / total de compras',	
	'Mensual',	
	'Mejorar la gestión de las compras',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Inversión total en I+D / Gastos totales de la organización en las actividades promovidas',
	'Inversión total en I+D / Gastos totales de la organización en las actividades promovidas',	
	'Mensual',	
	'Asegurar una proporción adecuada del presupuesto dedicada a I+D',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Forecast real / Forecast presupuestado',
	'Forecast real / Forecast presupuestado',	
	'Mensual',	
	'Evaluar la estimación del Forecast',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Rentabilidad bruta: (Facturación - Mano de obra directa) / Facturación',
	'Rentabilidad bruta: (Facturación - Mano de obra directa) / Facturación',	
	'Mensual',	
	'Monitorear la solidez económica',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Rentabilidad neta: (Rentabilidad bruta - Costos indirectos) / Facturación',
	'Rentabilidad neta: (Rentabilidad bruta - Costos indirectos) / Facturación',	
	'Mensual',	
	'Monitorear la solidez económica',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Promedio de puntajes de satisfacción global en la encuesta al cliente',
	'Promedio de puntajes de satisfacción global en la encuesta al cliente',	
	'Mensual',	
	'Mejorar la satisfacción del cliente',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Encuesta al Cliente (Proyectos)',
	'Encuesta al Cliente (Proyectos)',	
	'Mensual',	
	'Mejorar la satisfacción del cliente',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Encuesta al Cliente (Capacitaciones)',
	'Encuesta al Cliente (Capacitaciones)',	
	'Mensual',	
	'Mejorar la satisfacción del cliente',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Reuniones generadas / Prospects contactados',
	'Reuniones generadas / Prospects contactados',	
	'Mensual',	
	'Monitorear las tareas comerciales',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Nuevos clientes obtenidos',
	'Nuevos clientes obtenidos',	
	'Mensual',	
	'Monitorear las tareas comerciales',
	0.00, 0.49, 5, 1,
	0.49, 0.7, 5, 1,
	0.7, 0.8, 5, 1,
	0.8, 0.99, 5, 1,
	0.99, NULL, 5, 0,
	'amolinari',
	'jbarbosa'
);

