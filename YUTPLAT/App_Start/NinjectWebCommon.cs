[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YUTPLAT.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(YUTPLAT.App_Start.NinjectWebCommon), "Stop")]

namespace YUTPLAT.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Repositories.Interface;
    using Repositories;
    using Services.Interface;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterRepositories(kernel);
                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterRepositories(IKernel kernel)
        {
            kernel.Bind<IAreaRepository>().To<AreaRepository>();
            kernel.Bind<IObjetivoRepository>().To<ObjetivoRepository>();
            kernel.Bind<IIndicadorRepository>().To<IndicadorRepository>();
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAreaService>().To<AreaService>();
            kernel.Bind<IObjetivoService>().To<ObjetivoService>();
            kernel.Bind<IIndicadorService>().To<IndicadorService>();
        }        
    }
}
