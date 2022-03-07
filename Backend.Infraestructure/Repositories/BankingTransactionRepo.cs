using Backend.Core.Entities;
using Backend.Core.Interfaces;
using Backend.Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infraestructure.Repositories
{
    public class BankingTransactionRepo : IBankingTransactionRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<BankingTransaction> _entities;

        public BankingTransactionRepo(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<BankingTransaction>();
        }

        public async Task CreateBankingTransaction(BankingTransaction bankingTransaction)
        {
            if (bankingTransaction == null)
            {
                throw new ArgumentNullException(nameof(BankingTransaction));
            }
            await _entities.AddAsync(bankingTransaction);
        }

        public IEnumerable<BankingTransaction> GetAllBankingTransactions(int customerId) =>
            _entities.Where(x => x.ParentBankAccount.CustomerId == customerId)
            .Include("ParentBankAccount")
            .AsEnumerable();
    }
}
