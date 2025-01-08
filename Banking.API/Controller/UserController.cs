using Banking.API.DTO;
using Banking.API.Service;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Banking.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAccount([FromBody] UserDTO newUser)
    {
        if(newUser == null)
        {
            return BadRequest("User data cannot be null");
        }
        var user = await _userService.CreateAccount(newUser);
        return Ok(user);
    }
}