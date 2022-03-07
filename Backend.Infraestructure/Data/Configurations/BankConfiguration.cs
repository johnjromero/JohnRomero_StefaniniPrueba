using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infraestructure.Data.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable(nameof(Bank));

            //BankId
            builder.HasKey(b => b.BankId);

            builder.Property(b => b.BankId)
                .ValueGeneratedNever()
                .IsRequired();

            //BankName
            builder.Property(b => b.BankName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
