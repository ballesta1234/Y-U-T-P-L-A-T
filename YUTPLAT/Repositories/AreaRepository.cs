
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;

namespace YUTPLAT.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        YutplatDbContext context;

        public AreaRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Area> Todas()
        {
            return this.context.Areas;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}