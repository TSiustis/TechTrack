﻿using System.Linq.Expressions;
using TechTrack.Application.Common.Pagination;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Equipments.Dtos
{
    public class EquipmentFilterDto : PaginationFilter
    {
        public EquipmentFilterDto(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public Expression<Func<Equipment, bool>> SearchFilter { get; set; }

        public Expression<Func<Equipment, object>> SortExpression { get; set; }
        
        public bool SortAscending { get; set; }
    }
}
