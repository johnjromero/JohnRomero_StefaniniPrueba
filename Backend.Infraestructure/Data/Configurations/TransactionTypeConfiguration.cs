using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infraestructure.Data.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable(nameof(TransactionType));

            //TypeId
            builder.HasKey(t => t.TypeId);

            builder.Property(t => t.TypeId)
                .ValueGeneratedNever()
                .IsRequired();

            //TypeName
            builder.Property(t => t.TypeName)
                .HasMaxLength(40)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
