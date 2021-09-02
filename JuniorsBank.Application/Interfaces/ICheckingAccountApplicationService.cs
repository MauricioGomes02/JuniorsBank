using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.Interfaces
{
    public interface ICheckingAccountApplicationService
    {
        CheckingAccountViewModel GetById(long id);
        CheckingAccountViewModel GetByPerson(long id);
        void Deposit(CheckingAccountInputModel checkingAccountInputModel);
        void Withdrawal(CheckingAccountInputModel checkingAccountInputModel);
        void Payment(CheckingAccountInputModel checkingAccountInputModel);
    }
}
