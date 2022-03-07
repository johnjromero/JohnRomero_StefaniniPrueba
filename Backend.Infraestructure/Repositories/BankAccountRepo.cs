using Backend.Core.Entities;
using Backend.Core.Interfaces;
using Backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infraestructure.Repositories
{
    public class BankAccountRepo : IBankAccountRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<BankAccount> _entities;
        public BankAccountRepo(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<BankAccount>();
        }

        public BankAccount GetBankAccountById(int id)
        {
            return _entities.Where(x => x.BankAccountId == id).Include("Bank").FirstOrDefault();
        }

        public BankAccount GetBankAccountByNumber(string accountNumber)
        {
            return _entities.Where(ba => ba.AccountNumber == accountNumber).FirstOrDefault();
        }

        public void UpdateBalanceAmount(BankAccount bankAccount)
        {
            _entities.Update(bankAccount).State = EntityState.Modified;
        }
    }
}
