namespace Filters.Filters
{
    /// <summary>
    /// Interface for a filter for a single word.
    /// </summary>
    public interface IWordFilter
    {
        /// <summary>
        /// Word matches our condition.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>true if matches</returns>
        bool WordMatchesCondition(string word);
    }
}
