
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YUTPLAT.Models;

namespace YUTPLAT.Context
{
    public class YutplatDbContext : IdentityDbContext<Persona>
    {
        public virtual IDbSet<Meta> Metas { get; set; }
        public virtual IDbSet<Area> Areas { get; set; }
        public virtual IDbSet<Objetivo> Objetivos { get; set; }
        public virtual IDbSet<Indicador> Indicadores { get; set; }
        public virtual IDbSet<FrecuenciaMedicionIndicador> FrecuenciasMedicionIndicadores { get; set; }
        public virtual IDbSet<InteresadoIndicador> InteresadosIndicador { get; set; }
        public virtual IDbSet<ResponsableIndicador> ResponsablesIndicador { get; set; }
        public virtual IDbSet<Medicion> Mediciones { get; set; }

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

            modelBuilder.Entity<Medicion>().Property(x => x.Valor).HasPrecision(18, 3);
            modelBuilder.Entity<Meta>().Property(x => x.Valor1).HasPrecision(18, 3);
            modelBuilder.Entity<Meta>().Property(x => x.Valor2).HasPrecision(18, 3);
        }
    }    
}