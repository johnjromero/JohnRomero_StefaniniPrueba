using Backend.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.QueryFilters
{
    public class BankingTransactionQueryFilter
    {
        public int CustomerId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
