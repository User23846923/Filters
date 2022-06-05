using Filters.Filters;

namespace Filters.Services
{
    public class Processor : IProcessor
    {
        public void ProcessFile(
            string filePath,
            AnyFilterList filterList,
            Action<string> outputFn)
        {
            var reader = new LineReader(filePath);
            var tokenizer = new Tokenizer(reader);

            var separator = "";
            foreach (var token in tokenizer.GetNextToken())
            {
                ProcessToken(token, filterList, outputFn, ref separator);
            }
        }

        public void ProcessToken(
            string token,
            AnyFilterList filterList,
            Action<string> outputFn,
            ref string separator)
        {
            if (token.Length == 1 && Char.IsPunctuation(token[0]))
            {
                outputFn(token);
                separator = " ";
                return;
            }

            if (filterList.WordMatchesCondition(token))
            {
                return;
            }

            outputFn(separator);
            outputFn(token);
            separator = " ";
        }
    }
}
