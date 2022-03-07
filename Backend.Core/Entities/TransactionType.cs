using Backend.Core.Enumerations;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public class TransactionType
    {
        public BankTransactionType TypeId { get; set; }
        public string TypeName { get; set; }


        public ICollection<BankingTransaction> BankingTransactions { get; set; }
    }
}
