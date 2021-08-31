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
                throw new ArgumentException("O Nome deve ser informado!");
            if (string.IsNullOrEmpty(person.LastName))
                throw new ArgumentException("O Sobrenome deve ser informado!");
            if (string.IsNullOrEmpty(person.Email))
                throw new ArgumentException("O E-mail deve ser informado!");

            if (_personRepository.Exists(person.Email))
                throw new InvalidOperationException($"O E-mail '{person.Email}' já foi cadastrado na plataforma!");

            var people = _personRepository.GetAll();
            long personId = 1;
            if (people.Count() > 0)
            {
                var peopleOrderned = people.OrderBy(x => x.Id);
                personId = peopleOrderned.Last().Id++;
            }

            person.Id = personId;

            _personRepository.Add(person);
            _checkingAccountService.Add(person.Id);
        }

        public Person Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("O E-mail deve ser informado!");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("A Senha deve ser informada!");

            Person person = _personRepository.GetByEmail(email);

            if (person == null)
                throw new InvalidOperationException("Não foi encontrado nenhum usuário com o Email informado!");

            if (person.Password != password)
                throw new InvalidOperationException("Senha incorreta!");

            return person;
        }
    }
}
