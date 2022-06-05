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

        public IEnumerable<string?> GetNextToken()
        {
            foreach (string? line in _lineReader.GetNextLine())
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
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            sb = new StringBuilder();
                        }
                        yield return c.ToString();
                    }
                    else if (Char.IsWhiteSpace(c))
                    {
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            sb = new StringBuilder();
                        }
                        sb = new StringBuilder();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }

                if (sb.Length > 0)
                {
                    yield return sb.ToString();
                }
            }
        }
    }
}
