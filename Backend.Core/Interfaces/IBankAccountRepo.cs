using Backend.Core.Entities;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IBankAccountRepo
    {
        BankAccount GetBankAccountById(int id);
        BankAccount GetBankAccountByNumber(string accountNumber);
        void UpdateBalanceAmount(BankAccount bankAccount);
    }
}
