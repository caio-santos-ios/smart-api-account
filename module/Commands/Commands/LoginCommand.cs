using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Models;
using MediatR;

namespace api_account.module.Commands.Commands
{
    public class LoginCommand : IRequest<Object>
    {
        public Login _login { get; private set; }

        public LoginCommand(Login login) 
        {
            _login = login;
        }
    }
}