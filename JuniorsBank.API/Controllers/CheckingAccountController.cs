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

        [HttpGet("getByPerson/{id}")]
        public IActionResult GetByPerson(int id)
        {
            try
            {
                //checkingAccountInputModel.Id = id;
                var checkingAccountViewModel = _checkingAccountServiceApplication.GetByPerson(id);
                return Ok(checkingAccountViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("{id}/deposit")]
        public IActionResult Deposit(int id, CheckingAccountInputModel checkingAccountInputModel)
        {
            try
            {
                checkingAccountInputModel.Id = id;
                _checkingAccountServiceApplication.Deposit(checkingAccountInputModel);
                return Ok(new { Message = "Depositado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }            
        }

        [HttpPost("{id}/withdrawal")]
        public IActionResult Withdrawal(int id, CheckingAccountInputModel checkingAccountInputModel)
        {
            try
            {
                checkingAccountInputModel.Id = id;
                _checkingAccountServiceApplication.Withdrawal(checkingAccountInputModel);
                return Ok(new { Message = "Retirado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("{id}/payment")]
        public IActionResult Payment(int id, CheckingAccountInputModel checkingAccountInputModel)
        {
            try
            {
                checkingAccountInputModel.Id = id;
                _checkingAccountServiceApplication.Payment(checkingAccountInputModel);
                return Ok(new { Message = "Pago com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
