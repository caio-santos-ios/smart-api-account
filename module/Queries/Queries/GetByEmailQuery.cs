using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Models;
using MediatR;

namespace api_account.module.Queries.Queries
{
    public class GetByEmailQuery : IRequest<Account>
    {
        public string _email{ get; set; }
        public GetByEmailQuery(string email)
        {
            _email = email;
        }
    }
}