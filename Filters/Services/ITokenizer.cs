namespace Filters.Services
{
    /// <summary>
    /// interface for a Tokenizer 
    /// </summary>
    public interface ITokenizer
    {
        /// <summary>
        /// Gets the next token.
        /// </summary>
        public IEnumerable<string?> GetNextToken();
    }
}
