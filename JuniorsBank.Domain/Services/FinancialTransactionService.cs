using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Services
{    
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IFinancialTransactionRepository _financialTransactionRepository;
        public FinancialTransactionService(IFinancialTransactionRepository repository)
        {
            _financialTransactionRepository = repository;
        }

        public void Add(FinancialTransaction financialTransaction)
        {
            financialTransaction.MovementDate = DateTime.Now;
            _financialTransactionRepository.Update(financialTransaction);
        }
    }
}
