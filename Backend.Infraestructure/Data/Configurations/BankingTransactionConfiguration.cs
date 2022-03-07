using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infraestructure.Data.Configurations
{
    class BankingTransactionConfiguration : IEntityTypeConfiguration<BankingTransaction>
    {
        public void Configure(EntityTypeBuilder<BankingTransaction> builder)
        {
            builder.ToTable(nameof(BankingTransaction));

            //TransactionId
            builder.HasKey(bt => bt.TransactionId);

            //TransactionTypeId
            builder.Property(bt => bt.TransactionTypeId)
                .IsRequired();

            //Amount
            builder.Property(bt => bt.Amount)
                .HasColumnType("decimal(28,8)")
                .IsRequired();

            //GMF
            builder.Property(bt => bt.GMF)
                .HasColumnType("decimal(28,8)")
                .IsRequired();

            //ParentAccount
            builder.Property(bt => bt.ParentAccount)
                .IsRequired();

            //DestinationAccount
            builder.Property(bt => bt.DestinationAccount);
                

            //AccountBalance
            builder.Property(bt => bt.AccountBalance)
                .HasColumnType("decimal(28,8)")
                .IsRequired();

            //BankingTransaction to TransactionType relationship
            builder.HasOne(bt => bt.TransactionType)
                .WithMany(t => t.BankingTransactions)
                .HasForeignKey(bt => bt.TransactionTypeId)
                .IsRequired();

            //BankingTransaction to BankAccount relationship
            builder.HasOne(bt => bt.ParentBankAccount)
                .WithMany(ba => ba.ParentBankingTransactions)
                .HasForeignKey(bt => bt.ParentAccount)
                .IsRequired();

            //BankingTransaction to BankAccount relationship
            builder.HasOne(bt => bt.DestinationBankAccount)
                .WithMany(ba => ba.DestinationBankingTransactions)
                .HasForeignKey(bt => bt.DestinationAccount)
                .IsRequired(false);
        }
    }
}
