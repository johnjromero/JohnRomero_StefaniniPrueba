using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public string Denomination { get; set; }
        public decimal BalanceAmount { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }


        public Customer Customer { get; set; }
        public Bank Bank { get; set; }
        public ICollection<BankingTransaction> ParentBankingTransactions { get; set; }
        public ICollection<BankingTransaction> DestinationBankingTransactions { get; set; }
    }
}
