using JuniorsBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.InputModels
{
    public class CheckingAccountInputModel
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public long PersonId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
