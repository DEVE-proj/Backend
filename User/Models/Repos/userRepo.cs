using Microsoft.EntityFrameworkCore;

public interface IUserRepo
{
    Task<User?> GetUser(string login, string password);
    Task CreateUser(User UserData);
    Task<int> SaveChangesAsync();
}

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(string login, string password)
    {
        return await _context.Users.Where(e => e.Login == login).Where(e => e.Password == password).FirstOrDefaultAsync();
    }

    public async Task CreateUser(User UserData)
    {
        await _context.Users.AddAsync(UserData);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}