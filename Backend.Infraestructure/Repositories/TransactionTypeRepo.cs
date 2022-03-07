using Backend.Core.Entities;
using Backend.Core.Enumerations;
using Backend.Core.Interfaces;
using Backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Infraestructure.Repositories
{
    public class TransactionTypeRepo : ITransactionTypeRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TransactionType> _entities;

        public TransactionTypeRepo(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<TransactionType>();
        }

        public IEnumerable<TransactionType> GetAllTransactionType() =>
            _entities.AsEnumerable();

        public TransactionType GetTransactionTypeById(BankTransactionType transactionType) =>
            _entities.Find((int)transactionType);
    }
}
