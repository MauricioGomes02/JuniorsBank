using AutoMapper;
using JuniorsBank.API.Services;
using JuniorsBank.Application.InputModels;
using JuniorsBank.Application.Interfaces;
using JuniorsBank.Application.ViewModels;
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
    public class PersonController : ControllerBase
    {
        private readonly IPersonApplicationService _personServiceApplication;
        private readonly IMapper _mapper;
        public PersonController(IPersonApplicationService personApplicationService,
                                IMapper mapper)
        {
            _personServiceApplication = personApplicationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        // FromBody não é necessário pois o parâmetro trata-se de um tipo complexo.
        public IActionResult Register(PersonInputModel personInputModel)
        {
            try
            {
                _personServiceApplication.Add(personInputModel);
                return Ok(new { Message = "Cadastrado com Sucesso!"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }            
        }

        [AllowAnonymous]
        [HttpPost("login")]
        // FromBody não é necessário pois o parâmetro trata-se de um tipo complexo.
        public IActionResult Login(PersonInputModel personInputModel)
        {
            try
            {
                var person = _personServiceApplication.Login(personInputModel);
                string token = TokenService.GenerateToken(person);
                person.Token = token;
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
