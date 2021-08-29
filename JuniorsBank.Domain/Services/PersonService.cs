using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorsBank.Domain.Services
{
    public class PersonService: BaseService<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICheckingAccountService _checkingAccountService;
        public PersonService(IPersonRepository repository,
                             ICheckingAccountService checkingAccountService)
            :base(repository)
        {
            _personRepository = repository;
            _checkingAccountService = checkingAccountService;
        }

        public void Add(Person person)
        {
            if (string.IsNullOrEmpty(person.FirstName))
                throw new InvalidOperationException("O Nome deve ser informado!");
            if (string.IsNullOrEmpty(person.LastName))
                throw new InvalidOperationException("O Sobrenome deve ser informado!");
            if (string.IsNullOrEmpty(person.Email))
                throw new InvalidOperationException("O E-mail deve ser informado!");

            _personRepository.Add(person);
            _checkingAccountService.Add(person.Id);
        }

        public Person Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
