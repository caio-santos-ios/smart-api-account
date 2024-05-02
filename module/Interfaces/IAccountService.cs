using api_account.module.Models;

namespace api_account.module.Interfaces
{
    public interface IAccountService
    {
        public Task RegisterAsync(Account account);
        public Task LoginAsync(string email,  string password);
        public Task<Account> GetByEmailAsync(string email);
    }
}