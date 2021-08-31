using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.ViewModels
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
