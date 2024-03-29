namespace TechTrack.Common.Pagination
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(IList<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;

            if (pageSize > 0 && totalRecords > 0)
            {
                TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / pageSize));
            }
        }

        public IList<T> Data { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalRecords { get; }

        public int TotalPages { get; }
    }
}
