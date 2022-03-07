using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IBankAccountService
    {
        BankAccount GetBankAccountById(int id);
        BankAccount GetBankAccountByNumber(string accountNumber);
        Task<bool> UpdateBalanceAmount(int id, decimal amount);
    }
}
