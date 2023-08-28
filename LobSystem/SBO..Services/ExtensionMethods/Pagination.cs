using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.ExtensionMethods
{

    public static class PaginationService
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
        {
            if ( pageSize == 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "PageSize can't be 0");
            }
            if ( pageNumZeroStart != 0 )
            {
                query = query.Skip((pageNumZeroStart - 1) * pageSize);
            }
            return query.Take(pageSize);
        }
    }
}
