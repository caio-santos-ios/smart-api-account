using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_account.module.Commands.Commands;
using api_account.module.Models;
using api_account.module.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_account.module.Controllers
{
    [ApiController]
    [Route("api/v1/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        // [Authorize]
        [ActionName(nameof(RegisterAsync))]
        public async Task<IActionResult> RegisterAsync([FromBody] Account account) 
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password, 12);
        
            var command = new RegisterAccountCommand(account);
            var result = await _mediator.Send(command);
          
            return CreatedAtAction(nameof(RegisterAsync), new { id = result.Id }, result);
        }

        [HttpPost("login")]
        [ActionName(nameof(LoginAsync))]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            var command = new LoginCommand(login);
            
            await _mediator.Send(command);
            
            var token = new GenerateToken().Generate(login.Email);
            
            return Ok(new { token = token });
        }
    }
}