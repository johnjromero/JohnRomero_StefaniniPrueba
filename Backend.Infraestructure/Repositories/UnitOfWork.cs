using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Interfaces;
using Backend.Core.Entities;
using Backend.Infraestructure.Data;
using System.Threading.Tasks;

namespace Backend.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IAuditReportRepo _auditReportRepo;
        private readonly IBankAccountRepo _bankAccountRepo;
        private readonly IBankingTransactionRepo _bankingTransactionRepo;
        private readonly IBankRepo _bankRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly ITransactionTypeRepo _transactionTypeRepo;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAuditReportRepo AuditReportRepo => _auditReportRepo ?? new AuditReportRepo(_context);

        public IBankAccountRepo BankAccountRepo => _bankAccountRepo ?? new BankAccountRepo(_context);

        public IBankingTransactionRepo BankingTransactionRepo => _bankingTransactionRepo ?? new BankingTransactionRepo(_context);

        public IBankRepo BankRepo => _bankRepo ?? new BankRepo(_context);

        public ICustomerRepo CustomerRepo => _customerRepo ?? new CustomerRepo(_context);

        public ITransactionTypeRepo TransactionTypeRepo => _transactionTypeRepo ?? new TransactionTypeRepo(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
