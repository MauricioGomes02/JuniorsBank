using AutoMapper;
using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.ViewModels;
using JuniorsBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.AutoMapper
{
    public class JuniorsBankProfile : Profile
    {
        public JuniorsBankProfile()
        {
            CreateMap<PersonInputModel, Person>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<CheckingAccountInputModel, CheckingAccount>();
            CreateMap<CheckingAccount, CheckingAccountViewModel>()
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Person.FirstName + ' ' + o.Person.LastName))
                .ForMember(d => d.FinancialTransactions, m => m.MapFrom(o => o.FinancialTransactions));
            CreateMap<FinancialTransaction, FinancialTransactionViewModel>();
        }
    }
}
