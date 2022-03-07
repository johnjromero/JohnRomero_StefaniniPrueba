using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }


        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
