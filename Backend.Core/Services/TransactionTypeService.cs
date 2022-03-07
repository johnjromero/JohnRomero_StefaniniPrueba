using Backend.Core.Entities;
using Backend.Core.Enumerations;
using Backend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TransactionType> GetAllTransactionType()
        {
            return _unitOfWork.TransactionTypeRepo.GetAllTransactionType();
        }

        public TransactionType GetTransactionTypeById(BankTransactionType transactionType)
        {
            return _unitOfWork.TransactionTypeRepo.GetTransactionTypeById(transactionType);
        }
    }
}
