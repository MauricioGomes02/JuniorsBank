using AutoMapper;
using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.Interfaces;
using JuniorsBank.Application.ViewModels;
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
        public CheckingAccountViewModel GetById(long id)
        {
            return _mapper.Map<CheckingAccountViewModel>(_checkingAccountService.GetById(id));
        }
        public CheckingAccountViewModel GetByPerson(long id)
        {
            return _mapper.Map<CheckingAccountViewModel>(_checkingAccountService.GetByPerson(id));
        }
        public void Deposit(CheckingAccountInputModel checkingAccountInputModel)
        {
            _checkingAccountService.Deposit(checkingAccountInputModel.Id, checkingAccountInputModel.Value);
        }
        public void Withdrawal(CheckingAccountInputModel checkingAccountInputModel)
        {
            _checkingAccountService.Withdrawn(checkingAccountInputModel.Id, checkingAccountInputModel.Value);
        }
        public void Payment(CheckingAccountInputModel checkingAccountInputModel)
        {
            _checkingAccountService.Payment(checkingAccountInputModel.Id, checkingAccountInputModel.Value);
        }        
    }
}
