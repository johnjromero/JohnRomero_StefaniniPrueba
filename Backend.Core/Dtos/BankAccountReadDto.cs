using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Dtos
{
    public class BankAccountReadDto
    {
        public int BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public string Denomination { get; set; }
        public decimal BalanceAmount { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }
    }
}
