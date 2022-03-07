using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Interfaces;

namespace Backend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuditReportRepo AuditReportRepo { get; }
        IBankAccountRepo BankAccountRepo { get; }
        IBankingTransactionRepo BankingTransactionRepo { get; }
        IBankRepo BankRepo { get; }
        ICustomerRepo CustomerRepo { get; }
        ITransactionTypeRepo TransactionTypeRepo { get; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
