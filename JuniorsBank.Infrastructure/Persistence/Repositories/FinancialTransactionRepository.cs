using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence.Repositories
{
    public class FinancialTransactionRepository : BaseRepository<FinancialTransaction>, IFinancialTransactionRepository
    {
        private readonly JuniorsBankDbContext _context;
        public FinancialTransactionRepository(JuniorsBankDbContext context)
            :base(context)
        {
            _context = context;
        }
    }
}
