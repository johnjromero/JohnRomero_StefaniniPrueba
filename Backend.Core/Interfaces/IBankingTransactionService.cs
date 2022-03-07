using Backend.Core.Entities;
using Backend.Core.Pagination;
using Backend.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IBankingTransactionService
    {
        Task<bool> CreateBankingTransaction(BankingTransaction bankingTransaction);
        PagedList<BankingTransaction> GetAllBankingTransactions(BankingTransactionQueryFilter filter);
    }
}
