using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using JuniorsBank.Domain.Services;
using JuniorsBank.Infrastructure.Persistence;
using JuniorsBank.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.DI
{
    public class Initializer
    {
        /// <summary>
        /// Método utilizado para injeção dos serviços e comunicação com o banco de dados.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connection"></param>
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<JuniorsBankDbContext>(options => options.UseSqlServer(connection));

            // INFRASTRUCTURE
            services.AddScoped(typeof(IPersonRepository), typeof(PersonRepository));
            services.AddScoped(typeof(ICheckingAccountRepository), typeof(CheckingAccountRepository));
            services.AddScoped(typeof(IFinancialTransactionRepository), typeof(FinancialTransactionRepository));

            // SERVICES (DOMAIN)
            services.AddScoped(typeof(IPersonService), typeof(PersonService));
            services.AddScoped(typeof(ICheckingAccountService), typeof(CheckingAccountService));
            services.AddScoped(typeof(IFinancialTransactionService), typeof(FinancialTransactionService));
        }
    }
}
