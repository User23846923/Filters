﻿using Filters.Filters;

namespace Filters.Services
{
    /// <summary>
    /// Interface for the main processing
    /// </summary>
    public interface IProcessor
    {
        /// <summary>
        /// Processes an individual token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="filterList">The filter list.</param>
        /// <param name="outputFn">The output function.</param>
        /// <param name="separator">The separator, updated if a word is output.</param>
        public void ProcessToken(
            string token,
            AnyFilterList filterList,
            Action<string> outputFn,
            ref string separator);
    }
}
