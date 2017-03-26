namespace JokesCrawler.Infrastructure
{
    using Constants;
    using Ninject.Extensions.Conventions;
    using Data;
    using Data.Common.Repositories;
    using Ninject;

    public static class NinjectConfig
    {
        public static void CreateKernel()
        {
            var kernel = new StandardKernel();

            ObjectFactory.Initialize(kernel);

            RegisterServices(kernel);
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(JokesCrawler)).To(typeof(JokesCrawler));
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            kernel.Bind<IJokesCrawlerContext>().To<JokesCrawlerContext>().InSingletonScope();

            kernel.Bind(k => k
                .From(Assemblies.ServiceAssembly)
                .SelectAllClasses()
                .BindDefaultInterface());

        }
    }
}
