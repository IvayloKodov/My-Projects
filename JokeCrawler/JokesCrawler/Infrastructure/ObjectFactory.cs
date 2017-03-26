namespace JokesCrawler.Infrastructure
{
    using Ninject;

    public static class ObjectFactory
    {
        private static IKernel kernel;

        public static void Initialize(IKernel kernelInstance)
        {
            kernel = kernelInstance;
        }


        public static IKernel Kernel()
        {
            return kernel;
        }
    }
}
