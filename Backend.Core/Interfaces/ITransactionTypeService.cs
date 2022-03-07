using Backend.Core.Entities;
using Backend.Core.Enumerations;
using System.Collections.Generic;

namespace Backend.Core.Interfaces
{
    public interface ITransactionTypeService
    {
        TransactionType GetTransactionTypeById(BankTransactionType transactionType);
        IEnumerable<TransactionType> GetAllTransactionType();
    }
}
