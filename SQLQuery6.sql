select [DESKTOP-NAIO2G5\SQLEXPRESS].KAIROS_BUXIS.DBO.VALORES

/****** Object:  LinkedServer [10.2.1.95]    Script Date: 28/02/2018 05:30:44 p.m. ******/
EXEC master.dbo.sp_addlinkedserver @server = N'DESKTOP-NAIO2G5\SQLEXPRESS', @srvproduct=N'SQL Server'
 /* For security reasons the linked server remote logins password is changed with ######## */
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'DESKTOP-NAIO2G5\SQLEXPRESS',@useself=N'True',@locallogin=N'DESKTOP-NAIO2G5\SQLEXPRESS'


EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'10.2.1.93',@useself=N'False',@locallogin=N'sa',@rmtuser=N'sa',@rmtpassword='Factory.07'
GO