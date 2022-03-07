using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Entities;
using Backend.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infraestructure.Data.Configurations
{
    public class AuditReportConfiguration : IEntityTypeConfiguration<AuditReport>
    {
        public void Configure(EntityTypeBuilder<AuditReport> builder)
        {
            builder.ToTable(nameof(AuditReport));

            //AuditId
            builder.HasKey(a => a.AuditId);

            //CreationDate
            builder.Property(a => a.CreationDate)
                .HasColumnType("datetime")
                .IsRequired();

            //Module
            builder.Property(a => a.Module)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false);

            //IssuerIP
            builder.Property(a => a.IssuerIP)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

            //UserAgent
            builder.Property(a => a.UserAgent)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);

            //OperationType
            builder.Property(a => a.OperationType)
                .HasMaxLength(20)
                .IsRequired()
                .IsUnicode(false);

            //ResultOperation
            builder.Property(a => a.ResultOperation)
                .HasMaxLength(10)
                .IsRequired()
                .IsUnicode(false);

            //ResultMessage
            builder.Property(a => a.ResultMessage)
                .HasMaxLength(100)
                .IsRequired(false)
                .IsUnicode(false);

        }
    }
}
