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

        public void Add(Person person, string password)
        {
            if (string.IsNullOrEmpty(person.FirstName))
                throw new ArgumentException("O Nome deve ser informado!");
            if (string.IsNullOrEmpty(person.LastName))
                throw new ArgumentException("O Sobrenome deve ser informado!");
            if (string.IsNullOrEmpty(person.Email))
                throw new ArgumentException("O E-mail deve ser informado!");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("A Senha deve ser informada!");

            if (_personRepository.Exists(person.Email))
                throw new InvalidOperationException($"O E-mail '{person.Email}' já foi cadastrado na plataforma!");

            var people = _personRepository.GetAll();
            long personId = 1;
            if (people.Count() > 0)
            {
                var peopleOrderned = people.OrderBy(x => x.Id);
                personId = peopleOrderned.Last().Id + 1;
            }

            person.Id = personId;

            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            person.PasswordHash = passwordHash;
            person.PasswordSalt = passwordSalt;

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

            if (!VerifyPasswordHash(password, person.PasswordHash, person.PasswordSalt))
                throw new InvalidOperationException("Senha incorreta!");

            return person;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("A senha não pode ter espaços em branco.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("A senha não pode ter espaços em branco.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Tamanho inválido para o hash da senha (esperado 64 bytes).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Tamanho inválido para o salt da senha (esperado 128 bytes).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
