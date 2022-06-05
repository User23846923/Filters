using Filters.Filters;
using Filters.Services;

namespace Filters
{
    /// <summary>
    ///    Read from a txt file
    /// • Create and apply the following 3 filters:
    /// – Filter1 – filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters
    /// ("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather"
    /// should not be)
    /// – Filter2 – filter out words that have length less than 3
    /// – Filter3 – filter out words that contains the letter ‘t’
    /// • After all filters have completed display the resulted text in the console;
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: Filters fileName");
                return;
            }

            var filterList = new AnyFilterList(new List<IWordFilter> {
                new VowelInTheMiddleFilter(),
                new LengthLessThanFilter(3),
                new ContainsCharacterFilter('t'),
            });

            var reader = new LineReader(args[0]);
            var tokenizer = new Tokenizer(reader);

            var processor = new Processor();
            var separator = "";
            foreach (var token in tokenizer.GetNextToken())
            {
                processor.ProcessToken(token, filterList, Console.Write, ref separator);
            }
        }
    }
}
