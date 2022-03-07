using AutoMapper;
using Backend.Api.Log;
using Backend.Api.Responses;
using Backend.Core.Dtos;
using Backend.Core.Entities;
using Backend.Core.Enumerations;
using Backend.Core.Interfaces;
using Backend.Core.Pagination;
using Backend.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuditor _auditor;
        private readonly IAuditReportService _auditReportService;
        private readonly IBankAccountService _bankAccountService;
        private readonly IBankingTransactionService _bankingTransactionService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="auditor"></param>
        /// <param name="auditReportService"></param>
        /// <param name="bankAccountService"></param>
        /// <param name="bankingTransactionService"></param>
        public TransactionController(
            IMapper mapper,
            IAuditor auditor,
            IAuditReportService auditReportService,
            IBankAccountService bankAccountService,
            IBankingTransactionService bankingTransactionService)
        {
            _mapper = mapper;
            _auditor = auditor;
            _auditReportService = auditReportService;
            _bankAccountService = bankAccountService;
            _bankingTransactionService = bankingTransactionService;
        }


        public static string Algo()
        {
            return "ESO";
        }

        /// <summary>
        /// Consulta todas las transacciones bancarias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiGeneralResponse<IEnumerable<BankingTransactionReadDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromQuery] BankingTransactionQueryFilter filter)
        {
            var transactions = _bankingTransactionService
                .GetAllBankingTransactions(filter);
            var transactionsDto = _mapper.Map<IEnumerable<BankingTransactionReadDto>>(transactions);

            var metadata = new Metadata
            {
                TotalCount = transactions.TotalCount,
                PageSize = transactions.PageSize,
                CurrentPage = transactions.CurrentPage,
                TotalPages = transactions.TotalPages,
                HasPreviousPage = transactions.HasPreviousPage,
                HasNextPage = transactions.HasNextPage,
            };

            var response = new ApiGeneralResponse<IEnumerable<BankingTransactionReadDto>>(transactionsDto)
            {
                Metadata = metadata
            };

            await _auditor.CreateAudit(nameof(BankingTransaction), OperationType.Read, HttpContext, true);
            return Ok(response);
        }


        /// <summary>
        /// Crea una transacción de retiro o transferencia
        /// </summary>
        /// <param name="transactionCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBankingTransaction(BankingTransactionCreateDto transactionCreateDto)
        {
            //Creamos la transacción
            var transactionModel = _mapper.Map<BankingTransaction>(transactionCreateDto);
            var isCreated = await _bankingTransactionService.CreateBankingTransaction(transactionModel);

            //Auditamos
            await _auditor.CreateAudit(nameof(BankingTransaction), OperationType.Create, HttpContext, isCreated);
            await _auditor.CreateAudit(nameof(BankAccount), OperationType.Update, HttpContext, isCreated);

            return Ok(isCreated);
        }
    }
}
