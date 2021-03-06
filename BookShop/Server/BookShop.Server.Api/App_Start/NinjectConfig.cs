﻿namespace BookShop.Server.Api
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Data;
    using Data.Common.Repositories;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services.Data.Contracts;

    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<BookShopContext>().InRequestScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            kernel.Bind(k => k
                .From(typeof(IService).Assembly)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}