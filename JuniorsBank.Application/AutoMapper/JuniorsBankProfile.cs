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
        }
    }
}
