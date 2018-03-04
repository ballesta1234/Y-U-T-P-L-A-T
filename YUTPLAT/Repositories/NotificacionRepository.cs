using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;

namespace YUTPLAT.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        YutplatDbContext context;

        public NotificacionRepository(YutplatDbContext context)
        {
            this.context = context;
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}