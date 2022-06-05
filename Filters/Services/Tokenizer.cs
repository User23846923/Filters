using System.Text;

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

                var sb = new StringBuilder();
                foreach (var c in line)
                {
                    if (Char.IsPunctuation(c))
                    {
                        yield return c.ToString();
                    }
                    else if (Char.IsWhiteSpace(c))
                    {
                        yield return sb.ToString();
                        sb = new StringBuilder();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }
        }
    }
}
