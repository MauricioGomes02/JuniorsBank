using JuniorsBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Entities
{
    public class FinancialTransaction : Base
    {        
        public DateTime MovementDate { get; set; }
        public decimal MovimentValue { get; set; }
        public decimal PreviousValue { get; set; }
        public decimal CurrentValue { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public long CheckingAccountId { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
    }
}
