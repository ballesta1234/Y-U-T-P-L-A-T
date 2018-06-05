
-- IND_NOMBRE NVARCHAR(MAX),	
-- IND_OBJETIVO NVARCHAR(MAX),		
-- IND_FRECUENCIA_MEDICION NVARCHAR(MAX),	
-- IND_DESCRIPCION NVARCHAR(MAX),	
-- 	
-- MET_INACEPTABLE_VALOR1 DECIMAL(18,3),
-- MET_INACEPTABLE_SIGNO1 INT,
-- MET_INACEPTABLE_SIGNO2 INT,
-- MET_INACEPTABLE_VALOR2 DECIMAL(18,3),
-- 		
-- MET_A_MEJORAR_VALOR1 DECIMAL(18,3),
-- MET_A_MEJORAR_SIGNO1 INT,
-- MET_A_MEJORAR_SIGNO2 INT,
-- MET_A_MEJORAR_VALOR2 DECIMAL(18,3),
-- 	
-- MET_ACEPTABLE_VALOR1 DECIMAL(18,3),
-- MET_ACEPTABLE_SIGNO1 INT,
-- MET_ACEPTABLE_SIGNO2 INT,
-- MET_ACEPTABLE_VALOR2 DECIMAL(18,3),
-- 
-- MET_SATISFACTORIA_VALOR1 DECIMAL(18,3),
-- MET_SATISFACTORIA_SIGNO1 INT,
-- MET_SATISFACTORIA_SIGNO2 INT,
-- MET_SATISFACTORIA_VALOR2 DECIMAL(18,3),
-- 	
-- MET_EXCELENTE_VALOR1 DECIMAL(18,3),
-- MET_EXCELENTE_SIGNO1 INT,
-- MET_EXCELENTE_SIGNO2 INT,
-- MET_EXCELENTE_VALOR2 DECIMAL(18,3),
-- 
-- RES_USERNAME1 NVARCHAR(256),
-- RES_USERNAME2 NVARCHAR(256)

-- 5 <=
-- 1 <
-- 2 >
-- 3 >=

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI',
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	'Mensual',	
	'SPI o Schedule Performance Index: Earned Value / Planned Value de los proyectos activos llave en mano, incluyendo en garantía',	
		
	0.00, 5, 1, 0.49, 	
	0.49, 5, 1, 0.70,
	0.70, 5, 1, 0.80,
	0.80, 5, 1, 0.99,
	0.99, 5, 0 , NULL,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI Servicios',
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	'Mensual',	
	'SPI Servicios',	
	
	0.00, 5, 1, 0.49, 	
	0.49, 5, 1, 0.70,
	0.70, 5, 1, 0.80,
	0.80, 5, 1, 0.99,
	0.99, 5, 0 , NULL,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI Proyectos llave en mano',
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	'Mensual',	
	'SPI Proyectos llave en mano',	
	
	0.00, 5, 1, 0.49, 	
	0.49, 5, 1, 0.70,
	0.70, 5, 1, 0.80,
	0.80, 5, 1, 0.99,
	0.99, 5, 0 , NULL,

	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'CPI',
	'Mejorar la eficiencia del método de estimación',
	'Mensual',	
	'CPI o Cost Performance Index: Earned Value/Actual Cost de los proyectos activos llave en mano, incluyendo en garantía',	
	
	0.00, 5, 1, 0.49, 	
	0.49, 5, 1, 0.70,
	0.70, 5, 1, 0.80,
	0.80, 5, 1, 0.99,
	0.99, 5, 0 , NULL,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'CPI Servicios',
	'Mejorar la eficiencia del método de estimación',
	'Mensual',	
	'CPI Servicios',	
	
	0.00, 5, 1, 0.49, 	
	0.49, 5, 1, 0.70,
	0.70, 5, 1, 0.80,
	0.80, 5, 1, 0.99,
	0.99, 5, 0 , NULL,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'CPI Proyectos llave en mano',
	'Mejorar la eficiencia del método de estimación',
	'Mensual',	
	'CPI Proyectos llave en mano',	
	
	0.00, 5, 1, 0.49, 	
	0.49, 5, 1, 0.70,
	0.70, 5, 1, 0.80,
	0.80, 5, 1, 0.99,
	0.99, 5, 0 , NULL,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Retrospectivas realizadas / Total que correspondan',
	'Mejorar la eficiencia del testing y desarrollo',
	'Mensual',	
	'Retrospectivas realizadas / Total que correspondan',	

	0.00, 5, 1, 0.40, 
	0.40, 5, 1, 0.60, 
	0.60, 5, 1, 0.70, 
	0.70, 5, 1, 0.90, 
	0.90, 5, 5, 1,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'% Retrabajo por detección externa',
	'Mejorar la eficiencia del testing y desarrollo',
	'Mensual',	
	'% Retrabajo por detección externa',
	
	0.15, 1, 0, NULL,
	0.12, 1, 5, 0.15,
	0.08, 1, 5, 0.12, 
	0.04, 1, 5, 0.08,
	0.00, 1, 5, 0.04,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Entregas con testing incompleto / Total que corresponda',
	'Mejorar la eficiencia del testing y desarrollo',
	'Mensual',	
	'Entregas con testing incompleto / Total que corresponda',
	
	0.30, 1, 0, NULL,
	0.20, 1, 5, 0.30,
	0.10, 1, 5, 0.20, 
	0.00, 1, 5, 0.10,
	0.00, 3, 0, NULL,
	
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de satisfacción de los alumnos en cuanto al curso en general',
	'Brindar Servicios Informáticos de alto nivel y adecuada satisfacción de los clientes',
	'Mensual',	
	'Grado de satisfacción de los alumnos en cuanto al curso en general',	
	
	0.00, 5, 1, 0.65,
	0.65, 5, 1, 0.75,
	0.75, 5, 1, 0.85, 
	0.85, 5, 1, 0.95,
	0.95, 5, 5, 1.00,
	
	'cfontela',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de satisfacción de los alumnos en cuanto al docente que imparte el curso',
	'Brindar Servicios Informáticos de alto nivel y adecuada satisfacción de los clientes',
	'Mensual',	
	'Grado de satisfacción de los alumnos en cuanto al docente que imparte el curso',	
	
	0.00, 5, 1, 0.65,
	0.65, 5, 1, 0.75,
	0.75, 5, 1, 0.85, 
	0.85, 5, 1, 0.95,
	0.95, 5, 5, 1.00,
	
	'cfontela',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Nuevos ingresos / candidatos derivados a entrevista',
	'Mejorar la eficiencia del reclutamiento',
	'Mensual',	
	'Nuevos ingresos / candidatos derivados a entrevista',	
	
	0.00, 5, 5, 0.12,
	0.12, 1, 5, 0.15,
	0.15, 1, 5, 0.17, 
	0.17, 1, 5, 0.21,
	0.21, 1, 0, NULL,
	
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia: Egresos / Staff total (Acumulado)',
	'Mejorar la eficiencia del reclutamiento',
	'Mensual',	
	'Grado de permanencia: Egresos / Staff total (Acumulado)',	
	
	0.35, 1, 0, NULL,
	0.20, 1, 5, 0.35,
	0.15, 1, 5, 0.20, 
	0.10, 1, 5, 0.15,
	0.00, 5, 5, 0.10,
		
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia menor a 3 meses (Acumulado)',
	'Mejorar la eficiencia del reclutamiento',
	'Mensual',	
	'Grado de permanencia menor a 3 meses (Acumulado)',	
	
	0.35, 1, 0, NULL,
	0.20, 1, 5, 0.35,
	0.15, 1, 5, 0.20, 
	0.10, 1, 5, 0.15,
	0.00, 5, 5, 0.10,
	
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia mayor a 3 meses (Acumulado)',
	'Mejorar la eficiencia del reclutamiento',
	'Mensual',	
	'Grado de permanencia mayor a 3 meses (Acumulado)',	
	
	0.35, 1, 0, NULL,
	0.20, 1, 5, 0.35,
	0.15, 1, 5, 0.20, 
	0.10, 1, 5, 0.15,
	0.00, 5, 5, 0.10,
	
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Personal que renuncia por año (referidos a la dotación promedio anual) (Acumulado)',
	'Desalentar la rotación del personal',
	'Mensual',	
	'Personal que renuncia por año (referidos a la dotación promedio anual) (Acumulado)',	
	
	0.35, 1, 0, NULL,
	0.20, 1, 5, 0.35,
	0.15, 1, 5, 0.20, 
	0.10, 1, 5, 0.15,
	0.00, 5, 5, 0.10,
	
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Personal que renuncia SIVA (Acumulado)',
	'Desalentar la rotación del personal',
	'Mensual',	
	'Personal que renuncia SIVA (Acumulado)',	

	0.35, 1, 0, NULL,
	0.20, 1, 5, 0.35,
	0.15, 1, 5, 0.20, 
	0.10, 1, 5, 0.15,
	0.00, 5, 5, 0.10,
	
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Personal que renuncia Casa Central (Acumulado)',
	'Desalentar la rotación del personal',
	'Mensual',	
	'Personal que renuncia Casa Central (Acumulado)',	

	0.35, 1, 0, NULL,
	0.20, 1, 5, 0.35,
	0.15, 1, 5, 0.20, 
	0.10, 1, 5, 0.15,
	0.00, 5, 5, 0.10,
	
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total Horas Capacitación reales (excluye la inducción del primer mes) / Total de horas de Capacitación previstas (Acumulada)',
	'Aumentar el nivel de instrucción del personal',
	'Mensual',	
	'Total Horas Capacitación reales (excluye la inducción del primer mes) / Total de horas de Capacitación previstas (Acumulada)',	
	
	0.00, 5, 5, 0.65,
	0.65, 1, 5, 0.75,
	0.75, 1, 5, 0.85, 
	0.85, 1, 5, 0.95,
	0.95, 1, 0, NULL,
		
	'econtreras',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'No conformidades de auditorías internas / Total de ítems auditados para los procesos del Sistema de Gestión de Calidad',
	'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora',
	'Mensual',	
	'No conformidades de auditorías internas / Total de ítems auditados para los procesos del Sistema de Gestión de Calidad',	
	
	0.50, 1, 5, 1.00,
	0.35, 1, 5, 0.50,
	0.20, 1, 5, 0.35, 
	0.05, 1, 5, 0.20,
	0.00, 5, 5, 0.05,
	
	'aromero',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Oportunidades de Mejora implementadas, detectadas en las auditorías internas  / Total de Oportunidades de Mejora detectadas en las auditorías internas',
	'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora',
	'Mensual',	
	'Oportunidades de Mejora implementadas, detectadas en las auditorías internas  / Total de Oportunidades de Mejora detectadas en las auditorías internas',	
	
	0.00, 5, 1, 0.45,
	0.45, 5, 1, 0.60,
	0.60, 5, 1, 0.75, 
	0.75, 5, 1, 0.90,
	0.90, 5, 5, 1.00,
	
	'aromero',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Días de atraso en el cumplimiento del plan de auditorías interna / cantidad de días totales de dichas auditorías (respecto de fecha original de fin de auditoría)',
	'Evaluar el desempeño de los procesos y la implementación de oportunidades de mejora',
	'Mensual',	
	'Días de atraso en el cumplimiento del plan de auditorías interna / cantidad de días totales de dichas auditorías (respecto de fecha original de fin de auditoría)',	
	
	0.70, 1, 5, 1.00,
	0.50, 1, 5, 0.70,
	0.35, 1, 5, 0.50, 
	0.15, 1, 5, 0.35,
	0.00, 5, 5, 0.15,
	
	'aromero',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total de Solicitudes de Acción vencidas sobre total de Solicitudes de Acción',
	'Mejorar la gestión de Solicitudes de Acción',
	'Mensual',	
	'Total de Solicitudes de Acción vencidas sobre total de Solicitudes de Acción',	
	
	0.50, 1, 5, 1.00,
	0.35, 1, 5, 0.50,
	0.20, 1, 5, 0.35, 
	0.05, 1, 5, 0.20,
	0.00, 5, 5, 0.05,
		
	'aromero',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Solicitudes de acción aplicadas sobre solicitudes de acción requeridas',
	'Mejorar la gestión de Solicitudes de Acción',
	'Mensual',	
	'Solicitudes de acción aplicadas sobre solicitudes de acción requeridas',	
	
	0.00, 5, 1, 0.30,
	0.30, 5, 1, 0.50,
	0.50, 5, 1, 0.75, 
	0.75, 5, 1, 0.90,
	0.90, 5, 5, 1.00,
	
	'aromero',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'(Precio de Venta - Costo) / Costo (Incluyendo costos directos e indirectos)',
	'Mejorar la rentabilidad de los proyectos de desarrollo',
	'Mensual',	
	'(Precio de Venta - Costo) / Costo (Incluyendo costos directos e indirectos)',	
	
	0.00, 1, 0, NULL,
	0.00, 5, 1, 0.05,
	0.05, 5, 1, 0.15, 
	0.15, 5, 1, 0.25,
	0.25, 5, 0, NULL,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'(Rentabilidad acumulada del año actual - Rentabilidad acumulada en el mismo período del año anterior) / Rentabilidad acumulada del año actual',
	'Mejorar la rentabilidad de los proyectos de desarrollo',
	'Mensual',	
	'(Rentabilidad acumulada del año actual - Rentabilidad acumulada en el mismo período del año anterior) / Rentabilidad acumulada del año actual',	
	
	0.00, 1, 0, NULL,
	0.00, 5, 1, 0.05,
	0.05, 5, 1, 0.15, 
	0.15, 5, 1, 0.25,
	0.25, 5, 0, NULL,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total de votos negativos y neutrales / Total de votos',
	'Mejorar la eficacia en la selección de Proveedores',
	'Mensual',	
	'Total de votos negativos y neutrales / Total de votos',	
	
	0.50, 1, 5, 1.00,
	0.35, 1, 5, 0.50,
	0.20, 1, 5, 0.35, 
	0.05, 1, 5, 0.20,
	0.00, 1, 5, 0.05,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Total de compras vencidas y replanificadas / total de compras',
	'Mejorar la gestión de las compras',
	'Mensual',	
	'Total de compras vencidas y replanificadas / total de compras',	
	
	0.50, 1, 5, 1.00,
	0.35, 1, 5, 0.50,
	0.20, 1, 5, 0.35, 
	0.05, 1, 5, 0.20,
	0.00, 1, 5, 0.05,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Inversión total en I+D / Gastos totales de la organización en las actividades promovidas',
	'Asegurar una proporción adecuada del presupuesto dedicada a I+D',
	'Mensual',	
	'Inversión total en I+D / Gastos totales de la organización en las actividades promovidas',	
	
	0.00, 5, 1, 0.015,
	0.015, 5, 1, 0.03,
	0.03, 5, 1, 0.04, 
	0.04, 5, 1, 0.05,
	0.05, 5, 1, 0.06,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Forecast real / Forecast presupuestado',
	'Evaluar la estimación del Forecast',
	'Mensual',	
	'Forecast real / Forecast presupuestado',	
	
	0.00, 5, 1, 0.80,
	0.80, 5, 1, 0.90,
	0.90, 5, 1, 1.02, 
	1.02, 5, 1, 1.10,
	1.10, 5, 1, 1.30,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Rentabilidad bruta: (Facturación - Mano de obra directa) / Facturación',
	'Monitorear la solidez económica',
	'Mensual',	
	'Rentabilidad bruta: (Facturación - Mano de obra directa) / Facturación',	
	
	0.10, 1, 0, NULL,
	0.10, 5, 1, 0.20,
	0.20, 5, 1, 0.25, 
	0.25, 5, 1, 0.30,
	0.30, 5, 0, NULL,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Rentabilidad neta: (Rentabilidad bruta - Costos indirectos) / Facturación',
	'Monitorear la solidez económica',
	'Mensual',	
	'Rentabilidad neta: (Rentabilidad bruta - Costos indirectos) / Facturación',	
	
	0.10, 1, 0, NULL,
	0.10, 5, 1, 0.20,
	0.20, 5, 1, 0.25, 
	0.25, 5, 1, 0.30,
	0.30, 5, 0, NULL,
	
	'jdelvalle',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Promedio de puntajes de satisfacción global en la encuesta al cliente',
	'Mejorar la satisfacción del cliente',
	'Mensual',	
	'Promedio de puntajes de satisfacción global en la encuesta al cliente',	
	
	0.00, 5, 1, 0.30,
	0.30, 5, 1, 0.60,
	0.60, 5, 1, 0.70, 
	0.70, 5, 1, 0.90,
	0.90, 5, 1, 1.00,
	
	'ncaniggia',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Encuesta al Cliente (Proyectos)',
	'Mejorar la satisfacción del cliente',
	'Mensual',	
	'Encuesta al Cliente (Proyectos)',	
	
	0.00, 5, 1, 0.30,
	0.30, 5, 1, 0.60,
	0.60, 5, 1, 0.70, 
	0.70, 5, 1, 0.90,
	0.90, 5, 1, 1.00,
	
	'ncaniggia',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Encuesta al Cliente (Capacitaciones)',
	'Mejorar la satisfacción del cliente',
	'Mensual',	
	'Encuesta al Cliente (Capacitaciones)',	
	
	0.00, 5, 1, 0.30,
	0.30, 5, 1, 0.60,
	0.60, 5, 1, 0.70, 
	0.70, 5, 1, 0.90,
	0.90, 5, 1, 1.00,
	
	'ncaniggia',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Reuniones generadas / Prospects contactados',
	'Monitorear las tareas comerciales',
	'Mensual',	
	'Reuniones generadas / Prospects contactados',	
	
	0.00, 5, 1, 0.10,
	0.10, 5, 1, 0.20,
	0.20, 5, 1, 0.30, 
	0.30, 5, 1, 0.40,
	0.40, 5, 0, NULL,
	
	'ncaniggia',
	NULL
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Nuevos clientes obtenidos',
	'Monitorear las tareas comerciales',
	'Mensual',	
	'Nuevos clientes obtenidos',	
	
	0.00, 5, 1, 1.00,
	1.00, 5, 1, 2.00,
	2.00, 5, 1, 3.00, 
	3.00, 5, 1, 4.00,
	4.00, 5, 0, NULL,
	
	'ncaniggia',
	NULL
);
