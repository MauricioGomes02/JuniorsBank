using JuniorsBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        bool Exists(string email);
        Person GetByEmail(string email);
    }
}
