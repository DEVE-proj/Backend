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

    [HttpGet]
    public async Task<GetUserDataDto?> GetUserByLogin([FromQuery] string login)
    {
        var result = await _userService.GetUserByLogin(login);

        if(result != null)
        {
            return new GetUserDataDto(){Name = result.Name};
        }

        return null;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] IUserDto UserData)
    {
       return Ok("");
    }
}