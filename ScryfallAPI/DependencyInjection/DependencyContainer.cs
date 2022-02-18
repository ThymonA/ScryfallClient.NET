namespace ScryfallAPI
{
    using SimpleInjector;

    public static class DependencyContainer
    {
        public static IServiceContainer Current { get; private set; }

        /// <summary>
        /// Register all library dependencies
        /// </summary>
        /// <param name="connection"></param>
        public static void Register(IConnection connection)
        {
            var container = new Container();

            container.Options.AllowOverridingRegistrations = true;

            var serviceContainer = new ServiceContainer(container);

            container.RegisterSingleton<IServiceContainer>(() => serviceContainer);

            Current = serviceContainer;

            container.RegisterSingleton<IConnection>(() => connection);
            container.RegisterSingleton<ICredentials>(() => connection.Credentials);
            container.RegisterSingleton<ICredentialStore>(() => connection.CredentialStore);
            container.RegisterSingleton<IApiPagination, ApiPagination>();
            container.RegisterSingleton<IApiConnection, ApiConnection>();
            container.RegisterSingleton<ISetsClient, SetsClient>();

            container.Verify();
        }

        /// <summary>
        /// Get a instance of <see cref="TService"/>
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns>A <see cref="TService"/> instance</returns>
        public static TService GetService<TService>()
            where TService : class
        {
            return Current.GetService<TService>();
        }
    }
}
