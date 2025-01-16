using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Utils;

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

    public Token_statement GetStatementById(int id){
        var statement = _statementRepository.GetStatementById(id);

        Token_statement res = new(){
            Activities = []
        };

        EntityToDTORequest<Statement, Token_statement>.ToDTO(statement, res);

        foreach(Activity a in statement.Activities!){
            Token_activity temp = new();
            EntityToDTORequest<Activity, Token_activity>.ToDTO(a, temp);
            res.Activities!.Add(temp);
        }

        return res;
    }
}