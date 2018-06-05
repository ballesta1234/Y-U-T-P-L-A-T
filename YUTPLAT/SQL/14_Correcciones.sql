
update dbo.Meta
set Signo2 = 5
where MetaId in
(
select MetaExcelenteMetaID from dbo.Indicador
where nombre = 'Retrospectivas realizadas / Total que correspondan'
)

update dbo.Meta
set Signo1 = 2
where MetaId in
(
select MetaInaceptableMetaID from dbo.Indicador
where nombre = '(Precio de Venta - Costo) / Costo (Incluyendo costos directos e indirectos)'
)

update dbo.Meta
set Signo1 = 2
where MetaId in
(
select MetaInaceptableMetaID from dbo.Indicador
where nombre = '(Rentabilidad acumulada del año actual - Rentabilidad acumulada en el mismo período del año anterior) / Rentabilidad acumulada del año actual'
)

update dbo.Meta
set Signo1 = 5
where MetaId in
(
select MetaExcelenteMetaID from dbo.Indicador
where nombre = 'Total de votos negativos y neutrales / Total de votos'
)

update dbo.Meta
set Signo1 = 5
where MetaId in
(
select MetaExcelenteMetaID from dbo.Indicador
where nombre = 'Total de compras vencidas y replanificadas / total de compras'
)


update dbo.Meta
set Signo1 = 2
where MetaId in
(
select MetaInaceptableMetaID from dbo.Indicador
where nombre = 'Rentabilidad bruta: (Facturación - Mano de obra directa) / Facturación'
)

update dbo.Meta
set Signo1 = 2
where MetaId in
(
select MetaInaceptableMetaID from dbo.Indicador
where nombre = 'Rentabilidad neta: (Rentabilidad bruta - Costos indirectos) / Facturación'
)

update dbo.Meta
set Signo2 = 5
where MetaId in
(
select MetaExcelenteMetaID from dbo.Indicador
where nombre = 'Promedio de puntajes de satisfacción global en la encuesta al cliente'
)

update dbo.Meta
set Signo2 = 5
where MetaId in
(
select MetaExcelenteMetaID from dbo.Indicador
where nombre = 'Encuesta al Cliente (Proyectos)'
)

update dbo.Meta
set Signo2 = 5
where MetaId in
(
select MetaExcelenteMetaID from dbo.Indicador
where nombre = 'Encuesta al Cliente (Capacitaciones)'
)
