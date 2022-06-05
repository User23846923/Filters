﻿namespace Filters.Services
{
    public class LineReader : ILineReader, IDisposable
    {
        private readonly StreamReader _stream;

        public LineReader(string filePath)
        {
            _stream = new StreamReader(filePath);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (_stream != null)
            {
                _stream.Dispose();
            }
        }

        public IEnumerable<string> GetNextLine()
        {
            while (!_stream.EndOfStream)
            {
                yield return _stream.ReadLine() ?? throw new Exception("Unexpected end of file");
            }
        }
    }
}
