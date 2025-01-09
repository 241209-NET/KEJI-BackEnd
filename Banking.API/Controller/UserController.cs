using Banking.API.DTO;
using Banking.API.Model;
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
    public IActionResult CreateUser(UserDTO newUserDTO)
    {
        var user = _userService.CreateUser(newUserDTO);
        return Ok(user);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user =await _userService.GetUserById(userId);
        if(user==null)
        {
            return NotFound($"User with ID {userId} not found.");
        }
        return Ok(userId);
    }
}