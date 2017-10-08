﻿
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;

namespace YUTPLAT.Repositories
{
    public class IndicadorRepository : IIndicadorRepository
    {
        YutplatDbContext context;

        public IndicadorRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Indicador> GetById(int id)
        {
            return this.context.Indicadores.Where(i => i.IndicadorID == id);
        }

        public void Guardar(Indicador indicador)
        {
            this.context.Indicadores.AddOrUpdate(indicador);
            this.context.SaveChanges();
        }

        public IQueryable<Indicador> Todas()
        {
            return this.context.Indicadores;
        }

        public IQueryable<Indicador> Buscar(IndicadorViewModel filtro)
        {
            IQueryable<Indicador> queryable = this.context.Indicadores;

            if (filtro.Nombre != null && !string.IsNullOrEmpty(filtro.Nombre.Trim()))
            {
                queryable = queryable.Where(a => a.Nombre.Contains(filtro.Nombre.Trim()));
            }
            if (!string.IsNullOrEmpty(filtro.FechaCreacion))
            {
                DateTime desde = DateTime.Parse(filtro.FechaCreacion);
                queryable = queryable.Where(a => a.FechaCreacion >= desde);

                DateTime hasta = desde.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaCreacion <= hasta);
            }
            if (filtro.UltimoUsuarioModifico != null && !string.IsNullOrEmpty(filtro.UltimoUsuarioModifico.Trim()))
            {
                queryable = queryable.Where(a => a.UltimoUsuarioModifico.Contains(filtro.UltimoUsuarioModifico.Trim()));
            }
            if (!string.IsNullOrEmpty(filtro.FechaUltimaModificacion))
            {
                DateTime desde = DateTime.Parse(filtro.FechaUltimaModificacion);
                queryable = queryable.Where(a => a.FechaUltimaModificacion >= desde);

                DateTime hasta = desde.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaUltimaModificacion <= hasta);
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}