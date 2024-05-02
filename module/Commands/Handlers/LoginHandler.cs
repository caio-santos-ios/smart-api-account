using api_account.module.Commands.Commands;
using api_account.module.Interfaces;
using api_account.module.Models;
using MediatR;

namespace api_account.module.Commands.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, Object>
    {
        private readonly IAccountService _accountService;

        public LoginHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Object> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            await _accountService.LoginAsync(request._login.Email, request._login.Password);

            return request._login; 
        }
    }
}