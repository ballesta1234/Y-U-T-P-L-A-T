using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Threading.Tasks;

namespace YUTPLAT.Repositories
{
    public class IndicadorAutomaticoRepository : IIndicadorAutomaticoRepository
    {
        YutplatDbContext context;

        public IndicadorAutomaticoRepository(YutplatDbContext context)
        {
            this.context = context;
        }
                
        public IQueryable<IndicadorAutomatico> Todos()
        {
            return this.context.IndicadoresAutomaticos;
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}