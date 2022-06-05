namespace Filters.Services
{
    public class Tokenizer : ITokenizer
    {
        private readonly ILineReader _lineReader;

        public Tokenizer(ILineReader lineReader)
        {
            _lineReader = lineReader;
        }

        public IEnumerable<string?> NextToken()
        {
            foreach (string? line in _lineReader.NextLine())
            {
                if (line == null)
                {
                    yield return null;
                    break;
                }

                string[]? tokens = line.Split(' ');
                foreach (string? token in tokens)
                {
                    yield return token;
                }
            }
        }
    }
}
