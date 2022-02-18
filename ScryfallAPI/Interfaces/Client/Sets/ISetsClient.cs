using System.Collections.Generic;

namespace ScryfallAPI
{
    /// <summary>
    /// A client for Scryfall's Sets API
    /// </summary>
    public interface ISetsClient
    {
        /// <summary>
        /// Returns the <see cref="Set"/> specified by id
        /// </summary>
        /// <param name="id">Set Id</param>
        /// <returns>A <see cref="Set"/></returns>
        Set Get(long id);

        /// <summary>
        /// Returns the <see cref="Set"/> specified by code
        /// </summary>
        /// <param name="code">Set code</param>
        /// <returns>A <see cref="Set"/></returns>
        Set Get(string code);

        /// <summary>
        /// Returns a list of all sets
        /// </summary>
        IReadOnlyList<Set> GetAll { get; }
    }
}
