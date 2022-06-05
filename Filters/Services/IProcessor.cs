namespace Filters.Services
{
    /// <summary>
    /// Interface for the main processing
    /// </summary>
    public interface IProcessor
    {
        /// <summary>
        /// Processes the tokens, calling the output method for each.
        /// </summary>
        /// <param name="outputFn">The token callback function.</param>
        void ProcessTokens(Action<string> outputFn);
    }
}
