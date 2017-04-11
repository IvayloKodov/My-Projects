﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookShop.Server.Api.Startup))]

namespace BookShop.Server.Api
{
    using System.Web.Http;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
               .UseNinjectMiddleware(NinjectConfig.CreateKernel)
               .UseNinjectWebApi(httpConfig);
        }
    }
}
