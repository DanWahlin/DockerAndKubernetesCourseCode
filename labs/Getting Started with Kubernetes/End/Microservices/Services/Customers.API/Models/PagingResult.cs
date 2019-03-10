using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Models
{
    public struct PagingResult<T>
    {
        public IEnumerable<T> Records { get; set; }
        public int TotalRecords { get; set; }

        public PagingResult(IEnumerable<T> items, int totalRecords)
        {
            TotalRecords = totalRecords;
            Records = items;
        }
    }
}
