INSERT INTO dbo.Parametros VALUES('UsarLinkedServer', 'false')

DECLARE @ID_INDICADOR_SPI INT 
SELECT @ID_INDICADOR_SPI = IndicadorId FROM dbo.Indicador WHERE Nombre = 'SPI Servicios'

INSERT INTO dbo.IndicadorAutomatico VALUES('IndicadorAutomatico', @ID_INDICADOR_SPI, 1) 


CREATE TABLE dbo.ValoresBORRAR (
	nombre NVARCHAR(MAX) NULL,
	horas_totales INT NULL,	
	horas INT NULL,	
	mes INT NULL,
	anio INT NULL,
	ev INT NULL,
	ac INT NULL,
	cpi decimal(18,2) NULL
);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,1,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,1,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,1,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,1,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,1,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,1,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,1,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,1,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,1,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,1,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,1,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,1,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,1,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,1,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,1,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,1,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,1,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,1,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,1,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,1,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,1,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,1,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,1,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,1,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,1,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,1,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,1,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,1,2017,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,2,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,2,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,2,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,2,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,2,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,2,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,2,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,2,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,2,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,2,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,2,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,2,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,2,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,2,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,2,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,2,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,2,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,2,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,2,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,2,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,2,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,2,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,2,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,2,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,2,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,2,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,2,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,2,2017,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,3,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,3,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,3,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,3,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,3,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,3,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,3,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,3,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,3,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,3,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,3,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,3,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,3,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,3,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,3,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,3,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,3,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,3,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,3,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,3,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,3,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,3,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,3,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,3,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,3,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,3,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,3,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,3,2017,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,4,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,4,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,4,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,4,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,4,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,4,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,4,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,4,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,4,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,4,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,4,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,4,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,4,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,4,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,4,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,4,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,4,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,4,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,4,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,4,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,4,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,4,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,4,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,4,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,4,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,4,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,4,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,4,2017,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,5,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,5,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,5,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,5,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,5,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,5,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,5,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,5,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,5,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,5,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,5,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,5,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,5,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,5,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,5,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,5,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,5,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,5,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,5,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,5,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,5,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,5,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,5,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,5,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,5,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,5,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,5,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,5,2017,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,6,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,6,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,6,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,6,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,6,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,6,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,6,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,6,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,6,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,6,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,6,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,6,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,6,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,6,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,6,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,6,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,6,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,6,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,6,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,6,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,6,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,6,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,6,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,6,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,6,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,6,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,6,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,6,2017,NULL,723224,NULL);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,7,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,7,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,7,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,7,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,7,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,7,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,7,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,7,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,7,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,7,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,7,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,7,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,7,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,7,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,7,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,7,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,7,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,7,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,7,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,7,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,7,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,7,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,7,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,7,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,7,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,7,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,7,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,7,2017,NULL,723224,NULL);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,8,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,8,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,8,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,8,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,8,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,8,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,8,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,8,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,8,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,8,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,8,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,8,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,8,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,8,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,8,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,8,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,8,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,8,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,8,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,8,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,8,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,8,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,8,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,8,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,8,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,8,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,8,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,8,2017,NULL,723224,NULL);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,9,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,9,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,9,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,9,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,9,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,9,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,9,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,9,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,9,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,9,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,9,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,9,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,9,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,9,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,9,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,9,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,9,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,9,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,9,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,9,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,9,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,9,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,9,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,9,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,9,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,9,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,9,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,9,2017,NULL,723224,NULL);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,10,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,10,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,10,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,10,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,10,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,10,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,10,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,10,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,10,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,10,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,10,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,10,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,10,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,10,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,10,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,10,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,10,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,10,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,10,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,10,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,10,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,10,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,10,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,10,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,10,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,10,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,10,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,10,2017,NULL,723224,NULL);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,11,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,11,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,11,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,11,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,11,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,11,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,11,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,11,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,11,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,11,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,11,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,11,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,11,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,11,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,11,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,11,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,11,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,11,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,11,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,11,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,11,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,11,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,11,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,11,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,11,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,11,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,11,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,11,2017,NULL,723224,NULL);

insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,12,2017,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,12,2017,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,12,2017,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,12,2017,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,12,2017,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,12,2017,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,12,2017,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,12,2017,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,12,2017,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,12,2017,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,12,2017,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,12,2017,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,12,2017,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,12,2017,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,12,2017,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,12,2017,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,12,2017,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,12,2017,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,12,2017,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,12,2017,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,12,2017,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,12,2017,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,12,2017,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,12,2017,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,12,2017,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,12,2017,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,12,2017,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,12,2017,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,1,2018,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,1,2018,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,1,2018,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,1,2018,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,1,2018,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,1,2018,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,1,2018,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,1,2018,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,1,2018,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,1,2018,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,1,2018,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,1,2018,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,1,2018,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,1,2018,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,1,2018,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,1,2018,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,1,2018,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,1,2018,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,1,2018,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,1,2018,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,1,2018,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,1,2018,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,1,2018,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,1,2018,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,1,2018,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,1,2018,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,1,2018,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,1,2018,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,2,2018,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,2,2018,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,2,2018,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,2,2018,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,2,2018,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,2,2018,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,2,2018,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,2,2018,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,2,2018,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,2,2018,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,2,2018,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,2,2018,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,2,2018,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,2,2018,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,2,2018,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,2,2018,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,2,2018,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,2,2018,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,2,2018,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,2,2018,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,2,2018,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,2,2018,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,2,2018,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,2,2018,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,2,2018,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,2,2018,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,2,2018,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,2,2018,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,3,2018,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,3,2018,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,3,2018,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,3,2018,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,3,2018,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,3,2018,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,3,2018,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,3,2018,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,3,2018,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,3,2018,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,3,2018,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,3,2018,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,3,2018,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,3,2018,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,3,2018,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,3,2018,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,3,2018,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,3,2018,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,3,2018,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,3,2018,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,3,2018,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,3,2018,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,3,2018,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,3,2018,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,3,2018,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,3,2018,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,3,2018,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,3,2018,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,4,2018,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,4,2018,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,4,2018,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,4,2018,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,4,2018,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,4,2018,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,4,2018,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,4,2018,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,4,2018,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,4,2018,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,4,2018,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,4,2018,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,4,2018,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,4,2018,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,4,2018,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,4,2018,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,4,2018,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,4,2018,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,4,2018,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,4,2018,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,4,2018,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,4,2018,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,4,2018,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,4,2018,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,4,2018,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,4,2018,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,4,2018,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,4,2018,NULL,723224,NULL);


insert into dbo.ValoresBORRAR values('Análisis Funcional',1077,31,5,2018,NULL,403358,NULL);
insert into dbo.ValoresBORRAR values('Area Diseño',1007,2,5,2018,NULL,214692,NULL);
insert into dbo.ValoresBORRAR values('BAPRO',1401,440,5,2018,960000,404368,2.37);
insert into dbo.ValoresBORRAR values('Bienes Patrimoniales',12139,839,5,2018,0,4627787,0.00);
insert into dbo.ValoresBORRAR values('Boletin NACION',12954,839,5,2018,0,4253374,0.00);
insert into dbo.ValoresBORRAR values('Braford Mantenimiento',3656,30,5,2018,NULL,565282,NULL);
insert into dbo.ValoresBORRAR values('Central Puerto - Ambientales',1281,3,5,2018,502150,519655,0.97);
insert into dbo.ValoresBORRAR values('Central Puerto - Combustibles',5611,206,5,2018,1295400,1898651,0.68);
insert into dbo.ValoresBORRAR values('Central Puerto - Synergy',8240,236,5,2018,NULL,1156089,NULL);
insert into dbo.ValoresBORRAR values('Centrales de la Costa',7057,53,5,2018,0,2214652,0.00);
insert into dbo.ValoresBORRAR values('Clasificacion Docente 2014',34461,618,5,2018,NULL,9540169,NULL);
insert into dbo.ValoresBORRAR values('Compras AFIP',5045,648,5,2018,NULL,1612438,NULL);
insert into dbo.ValoresBORRAR values('Compras Buenos Aires',6408,603,5,2018,0,2472244,0.00);
insert into dbo.ValoresBORRAR values('Compras Nación',31343,1873,5,2018,0,9882567,0.00);
insert into dbo.ValoresBORRAR values('Compras Santa Fe',4091,48,5,2018,NULL,1642289,NULL);
insert into dbo.ValoresBORRAR values('Compras SBASE',3362,24,5,2018,NULL,1155273,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR',7313,243,5,2018,NULL,1957283,NULL);
insert into dbo.ValoresBORRAR values('CONTRAT.AR Ejecución',8070,1263,5,2018,NULL,2457581,NULL);
insert into dbo.ValoresBORRAR values('Document Technologies',5178,198,5,2018,0,1409438,0.00);
insert into dbo.ValoresBORRAR values('Figaro',23977,762,5,2018,NULL,8091435,NULL);
insert into dbo.ValoresBORRAR values('Firma y Conversión PDF - SLyT',1230,121,5,2018,0,432308,0.00);
insert into dbo.ValoresBORRAR values('Obra Pública Ciudad',3609,527,5,2018,NULL,1025339,NULL);
insert into dbo.ValoresBORRAR values('Obra Publica Provincia',753,169,5,2018,0,187570,0.00);
insert into dbo.ValoresBORRAR values('Prudential - Mejoras Siniestros',1209,244,5,2018,0,382779,0.00);
insert into dbo.ValoresBORRAR values('Rel Parlamentarias',494,188,5,2018,NULL,192984,NULL);
insert into dbo.ValoresBORRAR values('SCHRODERS_OMS',914,5,5,2018,0,350052,0.00);
insert into dbo.ValoresBORRAR values('SEAC - Renglón 2',105317,1882,5,2018,NULL,20093973,NULL);
insert into dbo.ValoresBORRAR values('SUBAST.AR',1793,124,5,2018,NULL,723224,NULL);




EXEC('
CREATE FUNCTION [dbo].[Indicadores](@mes int, @anio int)  
RETURNS TABLE  
AS  
RETURN   
( 
	SELECT nombre
		  ,horas_totales
		  ,horas
		  ,mes
		  ,anio
		  ,ev
		  ,ac
		  ,cpi
	  FROM dbo.ValoresBORRAR
	  WHERE  anio = @anio AND mes = @mes
);  
')


EXEC('
CREATE PROCEDURE [dbo].[ObtenerMedicionesPorMesAnio] 
@Mes int,
@Anio int
AS 
BEGIN	
	DECLARE @UsarLinkedServer VARCHAR(300)
	SELECT @UsarLinkedServer = Valor FROM dbo.Parametros WHERE Clave = ''UsarLinkedServer''
	
	IF(@UsarLinkedServer = ''true'')
	BEGIN 	
		SELECT [nombre]
		  ,[horas_totales]
		  ,[horas]
		  ,[mes]
		  ,[anio]
		  ,[ev]
		  ,[ac]
		  ,[cpi]
		FROM [kronosnet2-prod].dbo.Indicadores(@Mes,@Anio);
	END
	ELSE
	BEGIN
		SELECT 
		   [nombre]
		  ,[horas_totales]
		  ,[horas]
		  ,[mes]
		  ,[anio]
		  ,[ev]
		  ,[ac]
		  ,[cpi]
		FROM [dbo].Indicadores(@Mes,@Anio);
	END
END

')
