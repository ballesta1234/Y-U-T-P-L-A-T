
-- 4	<=
-- 1	<
-- CREATE TABLE TEMP_INDICADORES (

-- 	ID int IDENTITY(1,1) PRIMARY KEY,
	
-- 	IND_NOMBRE NVARCHAR(MAX),
-- 	IND_DESCRIPCION NVARCHAR(MAX),	
-- 	IND_FRECUENCIA_MEDICION NVARCHAR(MAX),	
-- 	IND_OBJETIVO NVARCHAR(MAX),	
--  IND_ES_AUTOMATICO BIT,
	
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
	'SPI o Schedule Performance Index: Earned Value / Planned Value de los proyectos activos llave en mano, incluyendo en garantía',
	'SPI o Schedule Performance Index: Earned Value / Planned Value de los proyectos activos llave en mano, incluyendo en garantía',	
	'Mensual',	
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',
	1,	
	0.00, 0.49, 4, 1, 	
	0.49, 0.7, 4, 1,
	0.7, 0.8, 4, 1,
	0.8, 0.99, 4, 1,
	0.99, NULL, 4, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'SPI Servicios',
	'SPI Servicios',	
	'Mensual',	
	'Medir el progreso de los proyectos en curso en comparación con el progreso planeado para corregir posibles desvíos',	
	1,
	0.00, 0.49, 4, 1,
	0.49, 0.7, 4, 1,
	0.7, 0.8, 4, 1,
	0.8, 0.99, 4, 1,
	0.99, NULL, 4, 0,
	'amolinari',
	'jbarbosa'
);

INSERT INTO TEMP_INDICADORES VALUES(
	'Grado de permanencia: Egresos / Staff total (Acumulado)',
	'Grado de permanencia: Egresos / Staff total (Acumulado)',	
	'Mensual',	
	'Mejorar la eficiencia del reclutamiento',		
	0,
	0.35, NULL, 1, 0,	
	0.20, 0.35, 1, 4,	
	0.15, 0.2, 1, 4,		
	0.1, 0.15, 1, 4,	
	0, 0.1, 4, 4,
	'econtreras',
	NULL
);
