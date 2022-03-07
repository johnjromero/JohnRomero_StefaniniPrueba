using Backend.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IAuditReportService
    {
        Task CreateAuditReport(AuditReport auditReport);
    }
}
