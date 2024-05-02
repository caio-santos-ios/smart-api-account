using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_account.module.Models;
using MongoDB.Driver;

namespace api_account.module.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Account> _accountCollection;
        public MongoDbService(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration["MongoDBSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDBSettings:DatabaseName"]);
            _accountCollection = database.GetCollection<Account>("accounts");
        }
    }
}