
UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Capacitación Tecnológica')
WHERE
	UserName = 'cfontela'

UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Comercial')
WHERE
	UserName = 'ncaniggia'

UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Desarrollo Comercial')
WHERE
	UserName = 'lbertuzzi'

UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'RRHH')
WHERE
	UserName = 'econtreras'

UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'RRHH')
WHERE
	UserName = 'mfernandez'
	
UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Calidad')
WHERE
	UserName = 'mlrosas'

UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Administración y Finanzas')
WHERE
	UserName = 'jdelvalle'
