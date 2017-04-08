using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningSystem.Web
{
    using Common.Mappings;
    using Models.ViewModels.MapInterface;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            DatabaseConfig.Initialize();
            AutofacConfig.RegisterAutofac();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var automapper = new AutoMapperConfig();
            automapper.Execute(typeof(IViewModel).Assembly);
        }
    }
}
