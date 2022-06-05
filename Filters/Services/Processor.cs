using Filters.Filters;

namespace Filters.Services
{
    public class Processor : IProcessor
    {
        public void ProcessToken(
            string token,
            AnyFilterList filterList,
            Action<string> outputFn,
            ref string separator)
        {
            if (token.Length == 1 && char.IsPunctuation(token[0]))
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
