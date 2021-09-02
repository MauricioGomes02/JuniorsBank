using JuniorsBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.ViewModels
{
    public class CheckingAccountViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<FinancialTransactionViewModel> FinancialTransactions { get; set; }
    }
}
