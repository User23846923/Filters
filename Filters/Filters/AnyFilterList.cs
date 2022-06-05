namespace Filters.Filters
{
    /// <summary>
    /// A list of filters combined with "OR"
    /// </summary>
    /// <seealso cref="Filters.IWordFilter" />
    public class AnyFilterList : IWordFilter
    {
        private readonly List<IWordFilter> _filters;

        public AnyFilterList(List<IWordFilter> filters)
        {
            _filters = filters;
        }

        /// <summary>
        /// Word matches any of our filters.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        /// true if word matches any of our filters
        /// </returns>
        public bool WordMatchesCondition(string word)
        {
            return _filters
                .Select(f => f.WordMatchesCondition(word))
                .Any(x => x);
        }
    }
}
