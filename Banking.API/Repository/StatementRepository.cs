using Banking.API.Data;
using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Repository;

public class StatementRepository : IStatementRepository
{
    private readonly BankingContext _bankingContext;
    public StatementRepository(BankingContext bankingContext) => _bankingContext = bankingContext;

    public async Task<Statement> GetStatementById(int statementId)
    {
        var statement = await _bankingContext.Statement
            .Include(s => s.Activities)
            .FirstOrDefaultAsync(s => s.StatementId == statementId);

        if (statement == null)
        {
            throw new KeyNotFoundException($"Statement with ID {statementId} not found.");
        }

        return statement;
    }
}