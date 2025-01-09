using Banking.API.Data;
using Banking.API.Model;

namespace Banking.API.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly BankingContext _bankingContext;

    public AccountRepository(BankingContext bankingContext) => _bankingContext = bankingContext;

    public Account CreateAccount(Account account)
    {
        _bankingContext.Account.Add(account);
        _bankingContext.SaveChanges();

        return account;
    }

    public double GetAccountBalance(int AccountId)
    {
        double balance = _bankingContext.Account.Single(a => a.AccountId == AccountId).Balance;

        return balance;
    }

    public void UpdateAccountCurrency(int AccountId, string Currency)
    {
        _bankingContext.Account.Single(a => a.AccountId == AccountId).Currency = Currency;
        _bankingContext.SaveChanges();
    }
}
