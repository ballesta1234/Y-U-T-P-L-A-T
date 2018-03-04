
exec sp_droplinkedsrvlogin @rmtsrvname=N'DESKTOP-NAIO2G5\SQLEXPRESS',@locallogin=N'DESKTOP-NAIO2G5\balle'
exec sp_dropserver @server = N'DESKTOP-NAIO2G5\SQLEXPRESS'

exec sp_dropserver @server = N'10.2.1.93'

EXEC master.dbo.sp_droplinkedsrvlogin @rmtsrvname=N'10.2.1.93',@useself=N'True',@locallogin=NULL,@rmtuser=NULL,@rmtpassword=NULL
EXEC master.dbo.sp_droplinkedsrvlogin @rmtsrvname=N'10.2.1.93',@locallogin=N'sa'



EXEC master.dbo.sp_addlinkedserver @server = N'DESKTOP-NAIO2G5\SQLEXPRESS', @srvproduct=N'SQL Server'
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'DESKTOP-NAIO2G5\SQLEXPRESS', @useself=N'True', @locallogin=N'DESKTOP-NAIO2G5\balle', @rmtuser=N'DESKTOP-NAIO2G5\balle'

select * from [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].[dbo].[Valores]

select [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.ObtenerMedicion()

EXEC [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].dbo.sp_executesql N'select [KAIROS_BUXIS].dbo.ObtenerMedicion()'


select * from [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].[dbo].[Valores]
BEGIN TRY       
select * from [DESKTIO25\SQLEXPRESS].[KAIROS_BUXIS].[dbo].[Valores]

END TRY  
BEGIN CATCH      
END CATCH 
select * from [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].[dbo].[Valores]

select * from [DESKTOP-NAIO2G5\SQLEXPRESS].[KAIROS_BUXIS].[dbo].[Valores]
