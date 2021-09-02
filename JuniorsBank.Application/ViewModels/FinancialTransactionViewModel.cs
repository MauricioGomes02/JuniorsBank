using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.ViewModels
{
    public class FinancialTransactionViewModel
    {
        public DateTime MovementDate { get; set; }
        public decimal MovimentValue { get; set; }
        public decimal PreviousValue { get; set; }
        public decimal CurrentValue { get; set; }
        public int? TransactionType { get; set; }
        public long CheckingAccountId { get; set; }
    }
}
