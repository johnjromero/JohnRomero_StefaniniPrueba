using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infraestructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            //CustomerId
            builder.HasKey(c => c.CustomerId);

            //FullName
            builder.Property(c => c.FullName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            //CreationDate
            builder.Property(c => c.CreationDate)
                .HasColumnType("datetime");
        }
    }
}
