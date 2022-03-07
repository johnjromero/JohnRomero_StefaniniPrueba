using Backend.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Dtos
{
    public class BankingTransactionReadDto
    {
        public int TransactionId { get; set; }
        public BankTransactionType TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public decimal GMF { get; set; }
        public int ParentAccount { get; set; }
        public int? DestinationAccount { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
