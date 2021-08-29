using JuniorsBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Entities
{
    public class CheckingAccount : Base
    {        
        public DateTime CreationDate { get; set; }
        public decimal Balance { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public IEnumerable<FinancialTransaction> FinancialTransactions { get; set; }        
    }
}
