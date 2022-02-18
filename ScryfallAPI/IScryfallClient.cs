namespace ScryfallAPI
{
    using System;

    public interface IScryfallClient
    {
        /// <summary>
        /// Set the Scryfall Api request timeout.
        /// </summary>
        /// <param name="timeout">The Timeout value</param>
        void SetRequestTimeout(TimeSpan timeout);

        /// <summary>
        /// Provides a client connection to make HTTP requests to endpoints
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// A connection for making API requests against URI endpoints
        /// </summary>
        IApiConnection ApiConnection { get; }

        /// <summary>
        /// Access Scryfall's User API.
        /// </summary>
        ISetsClient Sets { get; }
    }
}
