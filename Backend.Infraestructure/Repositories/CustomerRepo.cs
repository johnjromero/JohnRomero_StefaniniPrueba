using Backend.Core.Entities;
using Backend.Core.Interfaces;
using Backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infraestructure.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Customer> _entities;

        public CustomerRepo(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<Customer>();
        }

        public Customer GetCustomerById(int id)
        {
            return _entities.Find(id);
        }
    }
}
