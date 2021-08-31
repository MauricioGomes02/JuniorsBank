using AutoMapper;
using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.Interfaces;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Application.Services
{
    public class CheckingAccountApplicationService : ICheckingAccountApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ICheckingAccountService _checkingAccountService;
        public CheckingAccountApplicationService(IMapper mapper,
                                                 ICheckingAccountService personService)
        {
            _mapper = mapper;
            _checkingAccountService = personService;
        }
        public void Deposit(CheckingAccountInputModel checkingAccountInputModel)
        {
            _checkingAccountService.Deposit(checkingAccountInputModel.Id, checkingAccountInputModel.Value);
        }
    }
}
