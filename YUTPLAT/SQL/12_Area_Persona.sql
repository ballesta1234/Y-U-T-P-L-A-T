
UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Capacitación Tecnológica')
WHERE
	UserName = 'cfontela'
	
UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'RRHH')
WHERE
	UserName = 'econtreras'
	
UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Calidad')
WHERE
	UserName = 'aromero'

UPDATE 
	dbo.AspNetUsers
SET  AreaID = (SELECT Id FROM dbo.Area WHERE Nombre = 'Administración y Finanzas')
WHERE
	UserName = 'jdelvalle'
