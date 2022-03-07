using Backend.Core.Entities;
using Backend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class AuditReportService : IAuditReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAuditReport(AuditReport auditReport)
        {
            await _unitOfWork.AuditReportRepo.CreateAuditReport(auditReport);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
