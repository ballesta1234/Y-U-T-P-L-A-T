
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories
{
    public class YutplatDbContext : DbContext
    {
        public virtual IDbSet<Area> Areas { get; set; }

        public virtual IDbSet<Objetivo> Objetivos { get; set; }

        public YutplatDbContext() : base("DefaultConnection")
        {
        }

        public static YutplatDbContext Create()
        {
            return new YutplatDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }    
}