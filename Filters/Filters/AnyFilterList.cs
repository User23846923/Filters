namespace Filters.Filters
{
    /// <summary>
    /// A list of filters combined with "OR"
    /// </summary>
    /// <seealso cref="Filters.Filters.IWordFilter" />
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
            foreach (var filter in _filters)
            {
                if (filter.WordMatchesCondition(word))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
