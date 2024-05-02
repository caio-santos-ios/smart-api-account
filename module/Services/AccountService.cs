using api_account.module.Exceptions;
using api_account.module.Interfaces;
using api_account.module.Models;

namespace api_account.module.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }

        public Task<Account> GetByEmailAsync(string email)
        {
            return _accountRepository.GetByEmailAsync(email);
        }

        public async Task LoginAsync(string email, string password)
        {
            var find = await _accountRepository.GetByEmailAsync(email);
            if (find == null) {
                throw new NotFoundException();
            }

            var verifyPassword = BCrypt.Net.BCrypt.Verify(password, find.Password);

            if(!verifyPassword) {
                // bad request - senha ou email incorreto
                throw new NotFoundException();
            }        
        }

        public async Task RegisterAsync(Account account)
        {
            await _accountRepository.RegisterAsync(account);
        }
    }
}