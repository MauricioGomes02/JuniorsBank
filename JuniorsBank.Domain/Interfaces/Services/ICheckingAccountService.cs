using JuniorsBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Interfaces.Services
{
    public interface ICheckingAccountService : IBaseService<CheckingAccount>
    {
        void Add(long personId);
        CheckingAccount GetByPerson(long personId);
        void Deposit(long checkingAccountId, decimal value);
        void Withdrawn(long checkingAccountId, decimal value);
        void Payment(long checkingAccountId, decimal value);
    }
}
