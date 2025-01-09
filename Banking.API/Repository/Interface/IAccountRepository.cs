using Banking.API.Model;

namespace Banking.API.Repository;

public interface IAccountRepository
{
    Account CreateAccount(Account account);
    
    double GetAccountBalance(int AccountId);

    void UpdateAccountCurrency(int AccountId, string Currency);
}