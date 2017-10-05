
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YUTPLAT.Models;

namespace YUTPLAT.Context
{
    public class YutplatDbContext : IdentityDbContext<Persona>
    {
        public virtual IDbSet<Area> Areas { get; set; }
        public virtual IDbSet<Objetivo> Objetivos { get; set; }
        public virtual IDbSet<Indicador> Indicadores { get; set; }
        public virtual IDbSet<FrecuenciaMedicionIndicador> FrecuenciasMedicionIndicadores { get; set; }

        public YutplatDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static YutplatDbContext Create()
        {
            return new YutplatDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }    
}