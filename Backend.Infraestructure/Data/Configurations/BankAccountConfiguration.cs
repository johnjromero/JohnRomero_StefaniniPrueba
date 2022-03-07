using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Backend.Infraestructure.Data.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable(nameof(BankAccount));

            //BankAccountId
            builder.HasKey(ba => ba.BankAccountId);

            //AccountNumber
            builder.Property(ba => ba.AccountNumber)
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode(false);

            //Denomination
            builder.Property(ba => ba.Denomination)
                .HasMaxLength(4)
                .IsRequired()
                .IsUnicode(false);

            //BalanceAmount
            builder.Property(ba => ba.BalanceAmount)
                .HasColumnType("decimal(28,8)")
                .IsRequired();

            //CustomerId
            builder.Property(ba => ba.CustomerId)
                .IsRequired();

            //BankId
            builder.Property(ba => ba.BankId)
                .IsRequired();

            //BankAccount to Customer relationship
            builder.HasOne(ba => ba.Customer)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(ba => ba.CustomerId)
                .IsRequired();

            //BankAccount to Bank relationship
            builder.HasOne(ba => ba.Bank)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(ba => ba.BankId)
                .IsRequired();
        }
    }
}
