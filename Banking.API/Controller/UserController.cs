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

    [HttpPost("register")]
    public IActionResult Register([FromBody]UserRequestDTO userDTO)
    {
        var result = _userService.Register(userDTO);
        return Ok(result);
    }



    [HttpPost("login")]
    public IActionResult Login([FromBody]LoginDTO loginDTO)
    {
        var token = _userService.Login(loginDTO);
        if (token == null)
            return Unauthorized(new { Message = "Invalid email or password." });
        return Ok(new { Message = "Login successful", Token = token });
    }



    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user =await _userService.GetUserById(userId);
        if(user==null)
        {
            return NotFound($"User with ID {userId} not found.");
        }
        return Ok(user);
    }

    [HttpGet("check-email/{email}")]
    public IActionResult CheckEmail(string email)
    {
        email = Uri.UnescapeDataString(email); // Decode the email back
        Console.WriteLine($"Decoded email: {email}");
        var user = _userService.GetByEmail(email);
        if (user == null)
            return NotFound(new { Message = "Email does not exist." });

        return Ok(new
        {
            UserName = user.UserName,
            Password = user.Password
        });
    }

    [HttpPatch("amount/{amount}/{id}")]
    public IActionResult UpdateAmmount(double amount, int id){
        _userService.UpdateAmmount(amount, id);

        return Ok("Updated");
    }
}