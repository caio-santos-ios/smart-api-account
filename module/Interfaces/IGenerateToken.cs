using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Models;

namespace api_account.module.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(Account account);
    }
}