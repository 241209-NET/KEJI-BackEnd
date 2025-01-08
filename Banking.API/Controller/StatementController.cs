using Banking.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class StatementController : ControllerBase
{
    private readonly IStatementService _statementService;
    public StatementController(IStatementService statementService) => _statementService = statementService;
    
    [HttpGet("{statementId}")]
    public async Task<IActionResult> GetStatementById(int statementId)
    {
        try
        {
            var statement = await _statementService.GetStatementById(statementId);
            return Ok(statement);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}