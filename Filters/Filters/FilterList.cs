namespace Filters.Filters
{
    public class FilterList : IFilter
    {
        private readonly List<IFilter> _filters;

        public FilterList(List<IFilter> filters)
        {
            _filters = filters;
        }

        public bool ShouldFilterOut(string word)
        {
            foreach (IFilter? filter in _filters)
            {
                if (filter.ShouldFilterOut(word))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
