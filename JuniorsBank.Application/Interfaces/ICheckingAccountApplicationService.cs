using JuniorsBank.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.Interfaces
{
    public interface ICheckingAccountApplicationService
    {
        void Deposit(CheckingAccountInputModel checkingAccountInputModel);
    }
}
