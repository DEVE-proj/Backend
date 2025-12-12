using Microsoft.EntityFrameworkCore;

public interface IUserRepo
{
    Task<User?> GetUserByLogin(string login);
    Task AddUser(User UserData);
    Task<int> SaveChangesAsync();
}

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByLogin(string login)
    {
        return await _context.Users.Where(e => e.Login == login).FirstOrDefaultAsync();
    }

    public async Task AddUser(User UserData)
    {
        await _context.Users.AddAsync(UserData);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}