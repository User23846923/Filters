namespace Filters.Filters
{
    public class LengthFilter : IFilter
    {
        private readonly int _length;

        public LengthFilter(int length)
        {
            _length = length;
        }

        public bool ShouldFilterOut(string word)
        {
            return word.Length < _length;
        }
    }
}
