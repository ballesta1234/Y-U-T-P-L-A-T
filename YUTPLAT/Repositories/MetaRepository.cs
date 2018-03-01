using YUTPLAT.Models;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;
using System.Threading.Tasks;

namespace YUTPLAT.Repositories
{
    public class MetaRepository : IMetaRepository
    {
        YutplatDbContext context;

        public MetaRepository(YutplatDbContext context)
        {
            this.context = context;
        }
        
        public async Task<int> Guardar(Meta meta)
        {
            this.context.Metas.AddOrUpdate(meta);
            await this.context.SaveChangesAsync();

            return meta.MetaId;
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}