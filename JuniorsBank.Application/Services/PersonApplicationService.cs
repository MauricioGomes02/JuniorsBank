using AutoMapper;
using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.Interfaces;
using JuniorsBank.Application.ViewModels;
using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        public PersonApplicationService(IMapper mapper,
                                        IPersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }
        public PersonViewModel Login(PersonInputModel personInputModel)
        {
            return _mapper.Map<PersonViewModel>(_personService.Login(personInputModel.Email, personInputModel.Password));
        }

        public void Add(PersonInputModel personInputModel)
        {
            var person = _mapper.Map<Person>(personInputModel);
            _personService.Add(person, personInputModel.Password);
        }
    }
}
