using JuniorsBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Interfaces.Services
{
    public interface IPersonService : IBaseService<Person>
    {
        public void Add(Person person);
        public Person Login(string email, string password);
    }
}
