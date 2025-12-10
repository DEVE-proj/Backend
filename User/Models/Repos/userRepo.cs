using Microsoft.EntityFrameworkCore;

public interface IUserRepo
{
    Task<User?> GetTestData();
}

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetTestData()
    {
        return await _context.Users.FirstOrDefaultAsync();
    }
}