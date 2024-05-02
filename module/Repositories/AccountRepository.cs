using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api_account.module.Interfaces;
using api_account.module.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace api_account.module.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accountsCollection;

        public AccountRepository(IMongoDatabase database)
        {
            _accountsCollection = database.GetCollection<Account>("accounts");
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _accountsCollection.Find(account => account.Email == email).FirstOrDefaultAsync();
        }

        public async Task LoginAsync(string email, string password)
        {
           await _accountsCollection.Find(account => account.Email == email).FirstOrDefaultAsync();
        }

        public async Task RegisterAsync(Account account)
        {
           await _accountsCollection.InsertOneAsync(account);
        }
    }
}