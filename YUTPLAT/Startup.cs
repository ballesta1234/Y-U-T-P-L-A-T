using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using YUTPLAT.HangfireNinject;
using YUTPLAT.Services.Interface;

[assembly: OwinStartupAttribute(typeof(YUTPLAT.Startup))]
namespace YUTPLAT
{
    public partial class Startup
    {
        public static IEnumerable<IDisposable> GetHangfireConfiguration()
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("YUTPLAT");
            GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
            
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

            RecurringJob.AddOrUpdate<NotificacionService>(
                "NotificacionesJob",
                x => x.Notificar(),
                Cron.Minutely);

            RecurringJob.AddOrUpdate<MedicionService>(
                "CalculoMedicionesJob",
                x => x.CalcularTodasMedicionesAutomaticas(),
                Cron.Minutely);

            // RecurringJob.Trigger("Maktias");
            // RecurringJob.Trigger("Maktias");

        }
    }
}
