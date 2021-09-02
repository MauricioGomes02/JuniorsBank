using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var finalcialTransactions = _financialTransactionRepository.GetAll();
            long financialTransactionId = 1;
            if (finalcialTransactions.Count() > 0)
            {
                var peopleOrderned = finalcialTransactions.OrderBy(x => x.Id);
                financialTransactionId = peopleOrderned.Last().Id + 1;
            }

            financialTransaction.Id = financialTransactionId;

            financialTransaction.MovementDate = DateTime.Now;
            _financialTransactionRepository.Add(financialTransaction);
        }
    }
}
