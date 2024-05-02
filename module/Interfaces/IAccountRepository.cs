using api_account.module.Models;

namespace api_account.module.Interfaces
{
    public interface IAccountRepository
    {
        public Task RegisterAsync(Account account);
        public Task Login(string email, string password);
    }
}