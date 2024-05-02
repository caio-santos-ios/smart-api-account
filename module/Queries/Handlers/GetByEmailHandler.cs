using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Interfaces;
using api_account.module.Models;
using api_account.module.Queries.Queries;
using MediatR;

namespace api_account.module.Queries.Handlers
{
    public class GetByEmailHandler : IRequestHandler<GetByEmailQuery, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public GetByEmailHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetByEmailAsync(request._email);
        }
    }
}