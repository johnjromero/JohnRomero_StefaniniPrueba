using Backend.Core.Entities;
using Backend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BankAccount GetBankAccountById(int id)
        {
            var bankAccount = _unitOfWork.BankAccountRepo.GetBankAccountById(id);
            return bankAccount;
        }

        public BankAccount GetBankAccountByNumber(string accountNumber)
        {
            var bankAccount = _unitOfWork.BankAccountRepo.GetBankAccountByNumber(accountNumber);
            return bankAccount;
        }

        public async Task<bool> UpdateBalanceAmount(int id, decimal amount)
        {
            var existingAccount = _unitOfWork.BankAccountRepo.GetBankAccountById(id);
            //si la cuenta existe
            if (existingAccount == null)
            {
                throw new ArgumentNullException(nameof(BankAccount));
            }

            //Verifica si la cuenta tiene saldo
            bool hasFunds = existingAccount.BalanceAmount > decimal.Zero ?
                existingAccount.BalanceAmount >= amount ? true : false : false;
            if (!hasFunds)
            {
                throw new Exception("--> Insufficient funds");
            }

            //calculo el nuevo monto de la cuenta
            decimal newBalanceAmount = existingAccount.BalanceAmount - amount;
            existingAccount.BalanceAmount = newBalanceAmount;
            _unitOfWork.BankAccountRepo.UpdateBalanceAmount(existingAccount);
            bool isUpdate = await _unitOfWork.SaveChangesAsync();
            return isUpdate;
        }
    }
}
