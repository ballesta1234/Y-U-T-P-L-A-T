using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YUTPLAT.Startup))]
namespace YUTPLAT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
