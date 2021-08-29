using JuniorsBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Interfaces.Services
{
    public interface IFinancialTransactionService
    {
        void Add(FinancialTransaction financialTransaction);
    }
}
