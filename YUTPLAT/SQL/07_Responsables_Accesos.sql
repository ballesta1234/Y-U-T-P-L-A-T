
INSERT INTO dbo.InteresadoIndicador (IndicadorID, PersonaID)
SELECT 
	IND.IndicadorID, US.Id
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME1 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME1 IS NOT NULL

INSERT INTO dbo.InteresadoIndicador (IndicadorID, PersonaID)
SELECT 
	IND.IndicadorID, US.Id
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME2 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME2 IS NOT NULL

	
INSERT INTO dbo.ResponsableIndicador (IndicadorID, PersonaID)
SELECT 
	IND.IndicadorID, US.Id
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME1 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME1 IS NOT NULL

INSERT INTO dbo.ResponsableIndicador (IndicadorID, PersonaID)
SELECT 
	IND.IndicadorID, US.Id
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME2 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME2 IS NOT NULL
	

INSERT INTO dbo.AccesoIndicador (IndicadorID, PersonaID, PermisoIndicador)
SELECT 
	IND.IndicadorID, US.Id, 2
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME1 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME1 IS NOT NULL

INSERT INTO dbo.AccesoIndicador (IndicadorID, PersonaID, PermisoIndicador)
SELECT 
	IND.IndicadorID, US.Id, 2
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME2 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME2 IS NOT NULL
	
	
INSERT INTO dbo.AccesoIndicador (IndicadorID, PersonaID, PermisoIndicador)
SELECT 
	IND.IndicadorID, US.Id, 1
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME1 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME1 IS NOT NULL

INSERT INTO dbo.AccesoIndicador (IndicadorID, PersonaID, PermisoIndicador)
SELECT 
	IND.IndicadorID, US.Id, 1
FROM 
	dbo.AspNetUsers US
	INNER JOIN dbo.TEMP_INDICADORES TI on TI.RES_USERNAME2 = US.UserName
	INNER JOIN dbo.Indicador IND ON IND.ID_TEMP = TI.ID
WHERE 
	TI.RES_USERNAME2 IS NOT NULL
	