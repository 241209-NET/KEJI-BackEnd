using Banking.API.Model;
using Banking.API.Repository;
using Microsoft.Identity.Client;

namespace Banking.API.Service;

public class StatementService : IStatementService
{
    private readonly IStatementRepository _statementRepository;
    public StatementService(IStatementRepository statementRepository) => _statementRepository = statementRepository;
    
    public async Task<Statement> GetStatement(DateOnly date, int accountId)
    {
        var statement = await _statementRepository.GetStatement(date, accountId);
        
        return statement;
    }
}