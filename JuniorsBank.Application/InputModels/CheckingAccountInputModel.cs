using JuniorsBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JuniorsBank.Application.InputModels
{
    public class CheckingAccountInputModel
    {
        [JsonIgnore]
        public long Id { get; set; }
        public decimal Value { get; set; }
        public long PersonId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
