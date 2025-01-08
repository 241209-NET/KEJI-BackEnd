using Banking.API.Model;
using Banking.API.Repository;

namespace Banking.API.Service;

public class StatementService : IStatementService
{
    private readonly IStatementRepository _statementRepository;
    public StatementService(IStatementRepository statementRepository) => _statementRepository = statementRepository;
    
    public async Task<Statement> GetStatementById(int statementId)
    {
        var statement = await _statementRepository.GetStatementById(statementId);
        if (statement == null)
        {
            throw new KeyNotFoundException($"Statement with ID {statementId} not found.");
        }
        return statement;
    }
}