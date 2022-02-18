namespace ScryfallAPI
{
    using System;

    public class ScryfallClient : IScryfallClient
    {
        public static string ScryfallUrl { get; set; } = "https://api.scryfall.com/";

        public static Uri ScryfallUri => new Uri(ScryfallUrl);

        public ScryfallClient(string applicationName)
            : this(new ProductHeaderValue(applicationName))
        {
        }

        public ScryfallClient(string applicationName, string baseAddress)
            : this(new ProductHeaderValue(applicationName), new Uri(baseAddress))
        {
            ScryfallUrl = baseAddress;
        }

        public ScryfallClient(string applicationName, Uri baseAddress)
            : this(new ProductHeaderValue(applicationName), baseAddress)
        {
        }

        public ScryfallClient(IProductHeaderValue productInformation)
            : this(new Connection(productInformation, ScryfallUri))
        {
        }

        public ScryfallClient(IProductHeaderValue productInformation, string baseAddress)
            : this(productInformation, new Uri(baseAddress))
        {
        }

        public ScryfallClient(IProductHeaderValue productInformation, Uri baseAddress)
            : this(new Connection(productInformation, GetApiUri(baseAddress)))
        {
            ScryfallUrl = GetApiUri(baseAddress).ToString();
        }

        public ScryfallClient(IProductHeaderValue productInformation, ICredentialStore credentialStore, string baseAddress)
            : this(productInformation, credentialStore, new Uri(baseAddress))
        {
        }

        public ScryfallClient(IProductHeaderValue productInformation, ICredentialStore credentialStore, Uri baseAddress)
            : this(new Connection(productInformation, GetApiUri(baseAddress), credentialStore))
        {
            ScryfallUrl = GetApiUri(baseAddress).ToString();
        }

        public ScryfallClient(IConnection connection)
        {
            connection.ArgumentNotNull(nameof(connection));

            DependencyContainer.Register(connection);

            Connection = DependencyContainer.GetService<IConnection>();
            ApiConnection = DependencyContainer.GetService<IApiConnection>();
            Sets = DependencyContainer.GetService<ISetsClient>();
        }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            Connection.SetRequestTimeout(timeout);
        }

        public IConnection Connection { get; }

        public IApiConnection ApiConnection { get; }

        public ISetsClient Sets { get; }

        private static Uri GetApiUri(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            if (uri.Host.Contains("api/"))
            {
                uri = new Uri(uri.ToString().Split(new[] { "api/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            }

            return new Uri(uri, new Uri("/api/v4/", UriKind.Relative));
        }
    }
}
