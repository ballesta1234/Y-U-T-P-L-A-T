using Hangfire;
using Hangfire.Highlighter.Jobs;
using Hangfire.Dashboard;
using Hangfire.Highlighter;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(YUTPLAT.Startup))]
namespace YUTPLAT
{
    public partial class Startup
    {
        public static IEnumerable<IDisposable> GetHangfireConfiguration()
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            yield return new BackgroundJobServer();
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            /*
            app.UseHangfireAspNet(GetHangfireConfiguration);
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new IDashboardAuthorizationFilter[0]
            });

            RecurringJob.AddOrUpdate<SnippetHighlighter>(
                "Maktias",
                x => x.CleanUpAsync(),
                Cron.Minutely);

           //  RecurringJob.Trigger("Maktias");
          //  RecurringJob.Trigger("Maktias");
          */
        }
    }
}
