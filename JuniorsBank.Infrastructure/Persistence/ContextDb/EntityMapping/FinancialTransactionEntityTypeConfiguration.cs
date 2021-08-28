using JuniorsBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence.ContextDb.EntityMapping
{
    public class FinancialTransactionEntityTypeConfiguration : IEntityTypeConfiguration<FinancialTransaction>
    {
        public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
        {
            builder
                .ToTable(typeof(Person).Name);

            builder
                .HasKey(x => x.Id);
            // Para configurar o nome da chave se necessário...
            //.HasName("")            

            builder
                .Property(x => x.MovementDate)
                .IsRequired()
                .HasColumnName("MovementDate");

            builder
                .Property(x => x.MovimentValue)
                .IsRequired()
                .HasColumnName("MovimentValue");

            builder
                .Property(x => x.PreviousValue)
                .HasColumnName("PreviousValue");

            builder
                .Property(x => x.TransactionType)
                .IsRequired()
                .HasColumnName("TransactionType");

            builder
                .HasOne(x => x.CheckingAccount)
                .WithMany(x => x.FinancialTransactions)
                .HasForeignKey(x => x.CheckingAccountId);
                // Evitar violação de restrição referencial
                // https://docs.microsoft.com/pt-br/ef/core/saving/cascade-delete
                // Esse tipo de relação (necessária) já possui a configuração para
                // exclusão em cascata, não sendo necessário usar a sentença abaixo.
                // .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
