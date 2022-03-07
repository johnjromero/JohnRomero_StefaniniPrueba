using Backend.Core.Entities;
using Backend.Core.Enumerations;
using Backend.Core.Interfaces;
using Backend.Core.Pagination;
using Backend.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class BankingTransactionService : IBankingTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public BankingTransactionService(
            IUnitOfWork unitOfWork,
            IOptions<PaginationOptions> options
            )
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }


        public async Task<bool> CreateBankingTransaction(BankingTransaction bankingTransaction)
        {
            //Consultamos la cuenta padre
            var existingAccount = _unitOfWork.BankAccountRepo.GetBankAccountById(bankingTransaction.ParentAccount);
            if (existingAccount == null)
            {
                throw new ArgumentNullException(nameof(BankAccount));
            }

            //Verifica si la cuenta tiene saldo
            bool hasFunds = existingAccount.BalanceAmount > decimal.Zero ?
                existingAccount.BalanceAmount >= bankingTransaction.Amount ? true : false : false;
            if (!hasFunds)
            {
                throw new Exception("--> Insufficient funds");
            }

            //Cálculo del GMF
            decimal GMF = decimal.Zero;
            //si es retiro
            if (bankingTransaction.TransactionTypeId == BankTransactionType.Withdrawal)
            {
                decimal withdrawalMin = 9600000.00000000m;
                if (bankingTransaction.Amount >= withdrawalMin)
                {
                    GMF = (bankingTransaction.Amount * 4) / 100;
                }
            }
            //si es transferencia
            else if (bankingTransaction.TransactionTypeId == BankTransactionType.Transfer)
            {
                //obtenemos la cuenta destino
                var destinationAccount = _unitOfWork.BankAccountRepo
                    .GetBankAccountById(bankingTransaction.DestinationAccount.Value);
                if (destinationAccount == null)
                {
                    throw new ArgumentNullException(nameof(BankAccount));
                }
                GMF = (bankingTransaction.Amount * 4) / 100;

                //Actualizamos el saldo de la cuenta destino
                destinationAccount.BalanceAmount += bankingTransaction.Amount;
                _unitOfWork.BankAccountRepo.UpdateBalanceAmount(destinationAccount);
            }

            //Verifica si la cuenta tiene saldo
            hasFunds = bankingTransaction.Amount + GMF <= existingAccount.BalanceAmount ?
                true : false;
            if (!hasFunds)
            {
                throw new Exception("--> Insufficient funds");
            }


            //calculo el nuevo monto de la cuenta
            decimal newBalanceAmount = existingAccount.BalanceAmount - bankingTransaction.Amount - GMF;
            existingAccount.BalanceAmount = newBalanceAmount;

            //Creamos la transacción
            bankingTransaction.GMF = GMF;
            bankingTransaction.AccountBalance = newBalanceAmount;
            await _unitOfWork.BankingTransactionRepo.CreateBankingTransaction(bankingTransaction);
            //Actualizamos el saldo de la cuenta bancaria
            _unitOfWork.BankAccountRepo.UpdateBalanceAmount(existingAccount);

            var isSuccess = await _unitOfWork.SaveChangesAsync();
            return (isSuccess);
        }


        public PagedList<BankingTransaction> GetAllBankingTransactions(BankingTransactionQueryFilter filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? _paginationOptions.DefaultPageSize : filter.PageSize;

            var transactions = _unitOfWork.BankingTransactionRepo.GetAllBankingTransactions(filter.CustomerId);

            var pagedTransactions = PagedList<BankingTransaction>.Create(transactions, filter.PageNumber, filter.PageSize);
            return pagedTransactions;
        }
    }
}
