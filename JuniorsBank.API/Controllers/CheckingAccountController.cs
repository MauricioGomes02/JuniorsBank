using AutoMapper;
using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorsBank.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/{controller}")]
    public class CheckingAccountController : ControllerBase
    {
        private readonly ICheckingAccountApplicationService _checkingAccountServiceApplication;
        private readonly IMapper _mapper;
        public CheckingAccountController(ICheckingAccountApplicationService checkingAccountServiceApplication,
                                IMapper mapper)
        {
            _checkingAccountServiceApplication = checkingAccountServiceApplication;
            _mapper = mapper;
        }

        [HttpPost("deposit")]
        public IActionResult Deposit(CheckingAccountInputModel checkingAccountInputModel)
        {
            try
            {
                _checkingAccountServiceApplication.Deposit(checkingAccountInputModel);
                return Ok(new { Message = "Depositado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }            
        }
    }
}
