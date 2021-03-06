namespace ScryfallAPI
{
    using System;
    using System.Globalization;

    public class BearerTokenAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, ICredentials credentials)
        {
            request.ArgumentNotNull(nameof(request));
            credentials.ArgumentNotNull(nameof(credentials));
            credentials.Password.ArgumentNotNull(nameof(credentials.Password));

            var token = credentials.Password;

            if (credentials.Login != null)
            {
                throw new InvalidOperationException("The login must be null for token authentication requests.");
            }

            if (token != null)
            {
                request.Headers["Authorization"] = string.Format(CultureInfo.InvariantCulture, "Bearer {0}", token);
            }
        }
    }
}
