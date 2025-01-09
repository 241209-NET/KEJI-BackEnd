using Banking.API.Data;
using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Repository;

public class StatementRepository : IStatementRepository
{
    private readonly BankingContext _bankingContext;
    public StatementRepository(BankingContext bankingContext) => _bankingContext = bankingContext;

    public async Task<Statement> GetStatement(DateOnly date, int accountId)
    {
        var statement = await _bankingContext.Statement
            .Include(s => s.Activities)
            .FirstOrDefaultAsync(s => s.StartDate == date);

        if (statement == null)
        {
            Statement newStatement =  new (){
                StartDate = date, 
                AccountId = accountId
            };
            _bankingContext.Statement.Add(newStatement);
            _bankingContext.SaveChanges();
            return newStatement;
        }

        return statement;
    }
}