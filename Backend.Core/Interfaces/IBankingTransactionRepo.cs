using Backend.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IBankingTransactionRepo
    {
        Task CreateBankingTransaction(BankingTransaction bankingTransaction);
        IEnumerable<BankingTransaction> GetAllBankingTransactions(int customerId);
    }
}
