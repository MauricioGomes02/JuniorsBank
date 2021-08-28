using JuniorsBank.Domain.Entities;
using JuniorsBank.Infrastructure.Persistence.ContextDb.EntityMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence
{
    public class JuniorsBankDbContext : DbContext
    {
        public JuniorsBankDbContext(DbContextOptions<JuniorsBankDbContext> options)
            :base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialTransactionEntityTypeConfiguration());
        }
    }
}
