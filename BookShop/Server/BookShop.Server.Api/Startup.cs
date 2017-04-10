using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookShop.Server.Api.Startup))]

namespace BookShop.Server.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
