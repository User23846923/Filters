namespace Filters.Filters
{
    public interface IFilter
    {
        bool ShouldFilterOut(string word);
    }
}
