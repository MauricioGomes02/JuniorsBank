﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Entities
{
    public class Person : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
    }
}
