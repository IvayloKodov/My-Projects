using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CameraBazaar.Web.Startup))]
namespace CameraBazaar.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
