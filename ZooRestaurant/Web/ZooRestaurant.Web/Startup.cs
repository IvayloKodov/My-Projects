using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooRestaurant.Web.Startup))]
namespace ZooRestaurant.Web
{
    using Common.Models;
    using Infrastructure.Mapping;

    public partial class Startup
    {
        /// <summary>
        ///     Using IMapping interface to locate assembly with models.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);

            AutoMapperConfig automapper = new AutoMapperConfig();
            automapper.Execute(typeof(IMapping).Assembly);
        }
    }
}