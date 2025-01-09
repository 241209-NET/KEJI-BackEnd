using Banking.API.DTO;
using Banking.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService) => _accountService = accountService;

    [HttpPost]
    public IActionResult CreateNewAccount(AccountRequestDTO account)
    {
        var newAccount = _accountService.CreateAccount(account);

        return Ok(newAccount);
    }

    [HttpGet("{AccountId}")]
    public IActionResult GetAccountBalance(int AccountId)
    {
        var balance = _accountService.GetAccountBalance(AccountId);

        return Ok(balance);
    }

    [HttpPatch("{AccountId}/{Currency}")]
    public IActionResult UpdateAccountCurrency(int AccountId, string Currency)
    {
        _accountService.UpdateAccountCurrency(AccountId, Currency);

        return Ok("Currency Updated");
    }

}