using Backend.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Dtos
{
    public class BankingTransactionCreateDto
    {
        public BankTransactionType TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public int ParentAccount { get; set; }
        public int? DestinationAccount { get; set; }
    }
}
