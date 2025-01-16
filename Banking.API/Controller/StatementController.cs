using Banking.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class StatementController : ControllerBase
{
    private readonly IStatementService _statementService;
    public StatementController(IStatementService statementService) => _statementService = statementService;
    
    [HttpGet("{month}/{day}/{year}/{AccountId}")]
    public async Task<IActionResult> GetStatement( int month, int day, int year, int AccountId)
    {
        try
        {
            var date = new DateOnly(year, month, day);
            var statement = await _statementService.GetStatement(date, AccountId);
            return Ok(statement);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetStatementById(int id){
        var statement = _statementService.GetStatementById(id);

        return Ok(statement);
    }
}