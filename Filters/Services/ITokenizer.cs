namespace Filters.Services
{
    public interface ITokenizer
    {
        public IEnumerable<string?> NextToken();
    }
}
