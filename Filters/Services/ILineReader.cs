namespace Filters.Services
{
    /// <summary>
    /// Interface for a line by line reader
    /// </summary>
    public interface ILineReader
    {
        /// <summary>
        /// Gets the next line.
        /// </summary>
        public IEnumerable<string> GetNextLine();
    }
}
