using Filters.Filters;
using Filters.Services;

namespace Filters
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var seperator = "";

            var filterList = new FilterList(new List<IFilter> {
                new LengthFilter(4),
            });

            var reader = new LineReader(args[0]);
            var tokenizer = new Tokenizer(reader);
            foreach (string? token in tokenizer.NextToken())
            {
                if (token == null)
                {
                    break;
                }

                if (filterList.ShouldFilterOut(token))
                {
                    continue;
                }

                Console.Write(seperator);
                Console.Write(token);
                seperator = " ";
            }
        }
    }
}
