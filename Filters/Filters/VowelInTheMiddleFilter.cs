namespace Filters.Filters
{
    public class VowelInTheMiddleFilter : IWordFilter
    {
        private readonly List<char> _vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        /// <summary>
        /// Word contains a vowel in the centre 1 or 2 characters
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        /// true if word contains a vowel in the centre 1 or 2 characters
        /// </returns>
        public bool WordMatchesCondition(string word)
        {
            return word.Length % 2 != 0
                ? _vowels.Contains(word[word.Length / 2])
                : _vowels.Contains(word[(word.Length / 2) -1]) || _vowels.Contains(word[word.Length / 2]);
        }
    }
}
