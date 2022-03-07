using Backend.Core.Entities;
using Backend.Core.Enumerations;
using Backend.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Log
{
    public class Auditor : IAuditor
    {
        private readonly IAuditReportService _auditReportService;
        public Auditor(IAuditReportService auditReportService)
        {
            _auditReportService = auditReportService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        /// <param name="operation"></param>
        /// <param name="httpContext"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        public async Task CreateAudit(string module, OperationType operation, HttpContext httpContext, bool success)
        {
            AuditReport auditRpt = new AuditReport
            {
                Module = module,
                IssuerIP = httpContext.Connection.RemoteIpAddress.ToString(),
                UserAgent = httpContext.Request.Headers["User-Agent"],
                OperationType = operation.ToString(),
                ResultOperation = success.ToString(),
                ResultMessage = success ? $"--> {operation} {module}" : string.Empty
            };
            await _auditReportService.CreateAuditReport(auditRpt);
        }
    }
}
