namespace ScryfallAPI
{
    using SimpleInjector;
    using System.Collections.Generic;

    public sealed class ServiceContainer : IServiceContainer
    {
        private readonly Container container;

        public ServiceContainer(Container container)
        {
            this.container = container;
        }

        public TService GetService<TService>()
            where TService : class
        {
            return container.GetInstance<TService>();
        }

        public IEnumerable<TService> GetServices<TService>()
            where TService : class
        {
            return container.GetAllInstances<TService>();
        }
    }
}
