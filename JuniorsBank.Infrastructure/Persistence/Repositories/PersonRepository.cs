using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly JuniorsBankDbContext _context;
        public PersonRepository(JuniorsBankDbContext context)
            :base(context)
        {
            _context = context;
        }
        public bool Exists(string email)
        {
            return _context.People
                .Any(x => x.Email == email);
        }

        public Person GetByEmail(string email)
        {
            return _context.People
                .SingleOrDefault(x => x.Email == email);
        }
    }
}
