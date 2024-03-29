namespace TechTrack.Common.Pagination
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int GetSkipCount()
        {
            return (PageNumber - 1) * PageSize;
        }
    }
}
