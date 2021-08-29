using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence.Repositories
{
    public class CheckingAccountRepository : BaseRepository<CheckingAccount>, ICheckingAccountRepository
    {
        private readonly JuniorsBankDbContext _context;
        public CheckingAccountRepository(JuniorsBankDbContext context)
            :base(context)
        {
            _context = context;
        }
        public CheckingAccount GetByPerson(long id)
        {
            return _context.CheckingAccounts
                // LEFT JOIN
                .Include(x => x.FinancialTransactions)
                .FirstOrDefault(x => x.PersonId == id);
        }
    }
}
