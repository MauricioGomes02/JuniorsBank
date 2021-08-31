using JuniorsBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence.ContextDb.EntityMapping
{
    public class CheckingAccountEntityTypeConfiguration : IEntityTypeConfiguration<CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            //builder
            //    .ToTable(typeof(CheckingAccount).Name);

            builder
                .HasKey(x => x.Id);
            // Para configurar o nome da chave se necessário...
            //.HasName("")            

            builder
                .Property(x => x.CreationDate)
                .IsRequired()
                .HasColumnName("CreationDate");

            builder
                .Property(x => x.Balance)
                .IsRequired()
                .HasColumnName("Balance");

            builder
                .HasMany(x => x.FinancialTransactions)
                .WithOne(x => x.CheckingAccount)
                .HasForeignKey(x => x.CheckingAccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
