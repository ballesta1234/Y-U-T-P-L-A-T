using YUTPLAT.Models;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;

namespace YUTPLAT.Repositories
{
    public class MetaRepository : IMetaRepository
    {
        YutplatDbContext context;

        public MetaRepository(YutplatDbContext context)
        {
            this.context = context;
        }
        
        public int Guardar(Meta meta)
        {
            this.context.Metas.AddOrUpdate(meta);
            this.context.SaveChanges();

            return meta.MetaId;
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}