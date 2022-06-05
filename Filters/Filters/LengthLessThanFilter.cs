namespace Filters.Filters
{
    public class LengthLessThanFilter : IWordFilter
    {
        private readonly int _maxLength;

        public LengthLessThanFilter(int maxLength)
        {
            _maxLength = maxLength;
        }

        /// <summary>
        /// Word length is less than our limit.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        /// true if word length is less than our limit
        /// </returns>
        public bool WordMatchesCondition(string word)
        {
            return word.Length < _maxLength;
        }
    }
}
