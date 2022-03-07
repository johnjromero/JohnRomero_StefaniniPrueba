using Backend.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Entities
{
    public class AuditReport
    {
        public int AuditId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Module { get; set; }
        public string IssuerIP { get; set; }
        public string UserAgent { get; set; }
        public string OperationType { get; set; }
        public string ResultOperation { get; set; }
        public string ResultMessage { get; set; }
    }
}
