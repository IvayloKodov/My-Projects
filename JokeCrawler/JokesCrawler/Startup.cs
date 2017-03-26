namespace JokesCrawler
{
    using Infrastructure;
    using Ninject;

    public class Startup
    {
        public static void Main()
        {
            NinjectConfig.CreateKernel();
            var crawler = ObjectFactory.Kernel().Get<JokesCrawler>();

            crawler.Execute();
        }
    }
}
