using Backend.Core.Entities;
using Backend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Services
{
    public class BankService : IBankService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Bank GetBankById(int id)
        {
            var bank = _unitOfWork.BankRepo.GetBankById(id);
            return bank;
        }
    }
}
