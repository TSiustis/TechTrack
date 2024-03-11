using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrack.Application.Common.Pagination
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
