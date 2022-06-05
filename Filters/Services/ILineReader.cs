namespace Filters.Services
{
    public interface ILineReader
    {
        public IEnumerable<string?> NextLine();
    }
}
