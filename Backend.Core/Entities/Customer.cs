using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime CreationDate { get; set; }


        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
