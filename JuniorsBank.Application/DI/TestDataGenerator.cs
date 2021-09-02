using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using JuniorsBank.Domain.Services;
using JuniorsBank.Infrastructure.Persistence;
using JuniorsBank.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorsBank.Application.Services
{
    public class TestDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JuniorsBankDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<JuniorsBankDbContext>>()))
            {
                if (context.People.Any())
                    return;
                byte[] passwordHash, passwordSalt;
                PersonService.CreatePasswordHash("123", out passwordHash, out passwordSalt);
                context.People.AddRange(
                    new Person
                    {
                        FirstName = "Maurício",
                        LastName = "Andrade Gomes",
                        Email = "mauricioandradegomes@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    },
                    new Person
                    {
                        FirstName = "Warren",
                        LastName = "Brasil",
                        Email = "warren@warren.com.br",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    });

                context.CheckingAccounts.AddRange(
                    new CheckingAccount
                    {
                        Id = 1,
                        CreationDate = DateTime.Now,
                        Balance = 1000,
                        PersonId = 1
                    },
                    new CheckingAccount
                    {
                        Id = 2,
                        CreationDate = DateTime.Now,
                        Balance = 100000,
                        PersonId = 2
                    });

                context.FinancialTransactions.AddRange(
                    new FinancialTransaction
                    {
                        Id = 1,
                        MovementDate = DateTime.Now,
                        MovimentValue = 1000,
                        PreviousValue = 0,
                        CurrentValue = 1000,
                        TransactionType = Domain.Enums.TransactionTypeEnum.Deposit,
                        CheckingAccountId = 1
                    },
                    new FinancialTransaction
                    {
                        Id = 2,
                        MovementDate = DateTime.Now,
                        MovimentValue = 100000,
                        PreviousValue = 0,
                        CurrentValue = 1000,
                        TransactionType = Domain.Enums.TransactionTypeEnum.Deposit,
                        CheckingAccountId = 2
                    });

                context.SaveChanges();
            }                     
        }
    }
}
