using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookShop.Server.Api.Startup))]

namespace BookShop.Server.Api
{
    using System.Reflection;
    using System.Web.Http;
    using Common.Mappings;
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


            AutoMapperConfig automapper = new AutoMapperConfig();
            automapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
