namespace Filters.Services
{
    public class LineReader : ILineReader
    {
        private readonly StreamReader _stream;

        public LineReader(string filePath)
        {
            _stream = new StreamReader(filePath);
        }

        public IEnumerable<string?> NextLine()
        {
            while (_stream.Peek() != -1)
            {
                yield return _stream.ReadLine();
            }

            yield return null;
        }
    }
}
