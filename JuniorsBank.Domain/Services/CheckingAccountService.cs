using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorsBank.Domain.Services
{
    public class CheckingAccountService : BaseService<CheckingAccount>, ICheckingAccountService
    {
        #region Fields
        private readonly ICheckingAccountRepository _checkingAccountRepository;
        private readonly IFinancialTransactionService _financialTransactionService;
        #endregion

        #region Constructor
        public CheckingAccountService(ICheckingAccountRepository repository,
                                      IFinancialTransactionService financialTransactionService)
            :base(repository)
        {
            _checkingAccountRepository = repository;
            _financialTransactionService = financialTransactionService;
        }
        #endregion

        #region Methods
        public void Add(long personId)
        {
            var person = _checkingAccountRepository.GetByPerson(personId);
            if (person != null)
                throw new InvalidOperationException("O usuário já possui uma Conta Corrente!");

            var checkingAccounts = _checkingAccountRepository.GetAll();
            long checkingAccountId = 1;
            if (checkingAccounts.Count() > 0)
            {
                var peopleOrderned = checkingAccounts.OrderBy(x => x.Id);
                checkingAccountId = peopleOrderned.Last().Id + 1;
            }

            _checkingAccountRepository.Add(new CheckingAccount()
            {
                Id = checkingAccountId,
                CreationDate = DateTime.Now,
                Balance = 0,
                PersonId = personId
            });
        }

        public CheckingAccount GetByPerson(long personId)
        {
            var checkingAccount = _checkingAccountRepository.GetByPerson(personId);
            if (checkingAccount == null)
                throw new InvalidOperationException("Não há nenhuma Conta Corrente vinculada ao usuário solicitado!");
            return checkingAccount;
        }

        public void Deposit(long checkingAccountId, decimal value)
        {
            var checkingAccount = _checkingAccountRepository.GetById(checkingAccountId);
            if (checkingAccount == null)
                throw new InvalidOperationException("A Conta Corrente solicitada não foi encontrada!");

            if (value <= 0)
                throw new ArgumentException("O Valor a ser depositado deve ser maior que zero!");

            decimal previousValue = checkingAccount.Balance;
            checkingAccount.Balance += value;
            _checkingAccountRepository.Update(checkingAccount);
            _financialTransactionService.Add(new FinancialTransaction()
            {
                MovimentValue = value,
                PreviousValue = previousValue,
                CurrentValue = previousValue + value,
                TransactionType = Enums.TransactionTypeEnum.Deposit,
                CheckingAccountId = checkingAccountId
            });
        }        

        public void Payment(long checkingAccountId, decimal value)
        {
            var checkingAccount = _checkingAccountRepository.GetById(checkingAccountId);
            if (checkingAccount == null)
                throw new InvalidOperationException("A Conta Corrente solicitada não foi encontrada!");

            if (value <= 0)
                throw new ArgumentException("O Valor a ser pago deve ser maior que zero!");

            if (checkingAccount.Balance < value)
                throw new ArgumentException("O Saldo da Conta Corrente deve ser maior ou igual ao valor a ser pago!");

            decimal previousValue = checkingAccount.Balance;
            checkingAccount.Balance -= value;
            _checkingAccountRepository.Update(checkingAccount);
            _financialTransactionService.Add(new FinancialTransaction()
            {
                MovimentValue = value,
                PreviousValue = previousValue,
                CurrentValue = previousValue - value,
                TransactionType = Enums.TransactionTypeEnum.Payment,
                CheckingAccountId = checkingAccountId
            });
        }

        public void Withdrawn(long checkingAccountId, decimal value)
        {
            var checkingAccount = _checkingAccountRepository.GetById(checkingAccountId);
            if (checkingAccount == null)
                throw new InvalidOperationException("A Conta Corrente solicitada não foi encontrada!");

            if (value <= 0)
                throw new ArgumentException("O Valor a ser sacado deve ser maior que zero!");

            if (checkingAccount.Balance < value)
                throw new ArgumentException("O Saldo da Conta Corrente deve ser maior ou igual ao valor a ser sacado!");

            decimal previousValue = checkingAccount.Balance;
            checkingAccount.Balance -= value;
            _checkingAccountRepository.Update(checkingAccount);
            _financialTransactionService.Add(new FinancialTransaction()
            {
                MovimentValue = value,
                PreviousValue = previousValue,
                CurrentValue = previousValue - value,
                TransactionType = Enums.TransactionTypeEnum.Withdrawal,
                CheckingAccountId = checkingAccountId
            });
        }
        #endregion
    }
}
