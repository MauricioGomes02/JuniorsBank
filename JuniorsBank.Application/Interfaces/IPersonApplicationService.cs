using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.Interfaces
{
    public interface IPersonApplicationService
    {
        PersonViewModel Login(PersonInputModel personInputModel);
        void Add(PersonInputModel personInputModel);
    }
}
