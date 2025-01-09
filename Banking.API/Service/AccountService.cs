using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Utils;

namespace Banking.API.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;

    public AccountResponseDTO CreateAccount(AccountRequestDTO account)
    {
        Account req = new();
        DTOToEntityRequest<AccountRequestDTO, Account>.ToEntity(account, req);

        var repo_res = _accountRepository.CreateAccount(req);

        AccountResponseDTO res = new();
        EntityToDTORequest<Account, AccountResponseDTO>.ToDTO(repo_res, res);

        return res;
    }

    public double GetAccountBalance(int AccountId)
    {
        return _accountRepository.GetAccountBalance(AccountId);
    }

    public void UpdateAccountCurrency(int AccountId, string Currency)
    {
        _accountRepository.UpdateAccountCurrency(AccountId, Currency);
    }
}
