﻿namespace ScryfallAPI
{
    public interface IApiOptions
    {
        /// <summary>
        /// Specify the start page for pagination actions
        /// </summary>
        int? StartPage { get; }

        /// <summary>
        /// Specify the number of results to return for each page
        /// </summary>
        int? PageCount { get; }

        /// <summary>
        /// Specify the number of results to return for each page
        /// </summary>
        int? PageSize { get; }
    }
}
