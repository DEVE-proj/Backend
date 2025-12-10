using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/user")]

public class UserController : ControllerBase
{

    private readonly IUserRepo _userRepo;

    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet("get")]
    public async Task<User?> GetMyName()
    {
        return await _userRepo.GetTestData();
    }
}