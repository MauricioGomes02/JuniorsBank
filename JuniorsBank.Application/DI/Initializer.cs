using JuniorsBank.Infrastructure.Persistence;
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
            //services.AddScoped()
        }
    }
}
