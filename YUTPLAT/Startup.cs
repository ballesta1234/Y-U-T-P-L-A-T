using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Ninject;
using Owin;
using System;
using System.Collections.Generic;
using YUTPLAT.HangfireNinject;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

[assembly: OwinStartupAttribute(typeof(YUTPLAT.Startup))]
namespace YUTPLAT
{
    public partial class Startup
    {
        static IKernel KernelNinject { get; set; }
               
        public static IEnumerable<IDisposable> GetHangfireConfiguration()
        {
            KernelNinject = new Ninject.Web.Common.Bootstrapper().Kernel;
            GlobalConfiguration.Configuration.UseSqlServerStorage("YUTPLAT");
            GlobalConfiguration.Configuration.UseNinjectActivator(KernelNinject);
            
            yield return new BackgroundJobServer();
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
                        
            app.UseHangfireAspNet(GetHangfireConfiguration);
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new IDashboardAuthorizationFilter[0]
            });
            
            IIndicadorAutomaticoService indicadorAutomaticoService = (IIndicadorAutomaticoService)KernelNinject.GetService(typeof(IIndicadorAutomaticoService));
            indicadorAutomaticoService.GenerarJobsTareasAutomaticas();

            RecurringJob.AddOrUpdate<NotificacionService>(
                "NotificarCarga",
                x => x.NotificarCarga(),
                Cron.Minutely);
                //Cron.Monthly(1, 2, 0)); // Cada 1º de mes a las 2 a.m.
            
            RecurringJob.AddOrUpdate<NotificacionService>(
                "NotificarMetas",
                x => x.NotificarMetas(),
                Cron.Minutely);
                //Cron.Daily(3, 0)); // Cada día a las 3 a.m.
            
            RecurringJob.AddOrUpdate<AnioTableroService>(
                "ProcesoHabilitarAnioSiguiente",
                x => x.ProcesoHabilitarAnioSiguiente(),
                Cron.Yearly(12, 31, 23, 0));                
        }
    }
}
