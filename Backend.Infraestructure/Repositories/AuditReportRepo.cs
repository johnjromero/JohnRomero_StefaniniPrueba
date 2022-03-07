using Backend.Core.Entities;
using Backend.Core.Interfaces;
using Backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infraestructure.Repositories
{
    public class AuditReportRepo : IAuditReportRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<AuditReport> _entities;

        public AuditReportRepo(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<AuditReport>();
        }

        public async Task CreateAuditReport(AuditReport auditReport)
        {
            if (auditReport == null)
            {
                throw new ArgumentNullException(nameof(AuditReport));
            }
            await _entities.AddAsync(auditReport);
        }
    }
}
