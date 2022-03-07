using Backend.Core.Enumerations;

namespace Backend.Core.Entities
{
    public class BankingTransaction
    {
        public int TransactionId { get; set; }
        public BankTransactionType TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public decimal GMF { get; set; }
        public int ParentAccount { get; set; }
        public int? DestinationAccount { get; set; }
        public decimal AccountBalance { get; set; }


        public TransactionType TransactionType { get; set; }
        public BankAccount ParentBankAccount { get; set; }
        public BankAccount DestinationBankAccount { get; set; }
    }
}
