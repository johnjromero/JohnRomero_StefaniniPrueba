using Backend.Core.Entities;
using Backend.Core.Interfaces;
using Backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infraestructure.Repositories
{
    public class BankRepo : IBankRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Bank> _entities;

        public BankRepo(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<Bank>();
        }

        public Bank GetBankById(int id)
        {
            return _entities.Find(id);
        }
    }
}
