using Banking.API.DTO;

namespace Banking.API.Service;

public interface IAccountService
{
    AccountResponseDTO CreateAccount(AccountRequestDTO account);
    
    double GetAccountBalance(int AccountId);

    void UpdateAccountCurrency(int AccountId, string Currency);
}