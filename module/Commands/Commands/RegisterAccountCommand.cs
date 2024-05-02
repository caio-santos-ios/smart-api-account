using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Models;
using MediatR;

namespace api_account.module.Commands.Commands
{
    public class RegisterAccountCommand : IRequest<Account>
    {
        public Account _account{ get; private set; }

        public RegisterAccountCommand(Account account) 
        {
            _account = account;
        } 
    }
}