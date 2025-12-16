using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/user")]

public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<GetUserDto?>> GetUser([FromBody] LoginUserDto userData)
    {
        var result = await _userService.GetUser(userData.login, userData.password);

        if(result != null)
        {
            return Ok(new GetUserDto(){Name = result.Name});
        }

        return Unauthorized();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userData)
    {
        if(await _userService.CreateUser(userData))
        {
            return Ok("user was successfully created!");
        }
        else
            return BadRequest("Failed to create user");
    }
}