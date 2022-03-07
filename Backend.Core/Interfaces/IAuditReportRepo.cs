using Backend.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IAuditReportRepo
    {
        Task CreateAuditReport(AuditReport auditReport);
    }
}
