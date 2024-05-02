using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Commands.Commands;
using api_account.module.Interfaces;
using api_account.module.Models;
using MediatR;

namespace api_account.module.Commands.Handlers
{
    public class RegisterAccountHandler : IRequestHandler<RegisterAccountCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public RegisterAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            await _accountRepository.RegisterAsync(request._account);

            return request._account;
        }
    }
}