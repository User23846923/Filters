namespace Filters.Filters
{
    public class ContainsCharacterFilter : IWordFilter
    {
        private readonly char _character;

        public ContainsCharacterFilter(char character)
        {
            _character = character;
        }

        /// <summary>
        /// Word contains our character
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        /// true if word contains our character
        /// </returns>
        public bool WordMatchesCondition(string word)
        {
            return word.Contains(_character);
        }
    }
}
