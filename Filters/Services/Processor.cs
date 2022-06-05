using Filters.Filters;

namespace Filters.Services
{
    public class Processor : IProcessor
    {
        private readonly ITokenizer _tokenizer;
        private readonly IWordFilter _wordFilter;

        public Processor(ITokenizer tokenizer, IWordFilter wordFilter)
        {
            _tokenizer = tokenizer;
            _wordFilter = wordFilter;
        }

        public void ProcessTokens(Action<string> outputFn)
        {
            var separator = "";
            foreach (var token in _tokenizer.GetNextToken())
            {
                ProcessToken(token, _wordFilter, outputFn, ref separator);
            }
        }

        private static void ProcessToken(
            string token,
            IWordFilter wordFilter,
            Action<string> outputFn,
            ref string separator)
        {
            if (token.Length == 1 && char.IsPunctuation(token[0]))
            {
                outputFn(token);
                separator = " ";
                return;
            }

            if (wordFilter.WordMatchesCondition(token))
            {
                return;
            }

            outputFn(separator);
            outputFn(token);
            separator = " ";
        }
    }
}
