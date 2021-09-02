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
            //builder
            //    .ToTable(typeof(Person).Name);

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
                .Property(x => x.CurrentValue)
                .HasColumnName("CurrentValue");

            builder
                .Property(x => x.TransactionType)
                .IsRequired()
                .HasColumnName("TransactionType");
        }
    }
}
