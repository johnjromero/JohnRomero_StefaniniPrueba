using Backend.Core.Enumerations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Log
{
    public interface IAuditor
    {
        Task CreateAudit(string module, OperationType operation, HttpContext httpContext, bool success);
    }
}
