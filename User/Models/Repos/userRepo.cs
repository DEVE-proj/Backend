using Microsoft.EntityFrameworkCore;

public interface IUserRepo
{
    Task<User?> GetUser(string login, string password);
    Task CreateUser(User UserData);
    public Task<bool> DeleteUser(string login);
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
        User? user = await _context.Users.Where(e => e.Login == login).Where(e => e.Password == password).FirstOrDefaultAsync();
        return user;
    }

    public async Task CreateUser(User UserData)
    {
        try
        {
            await _context.Users.AddAsync(UserData);
            await _context.SaveChangesAsync();
        }

        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteUser(string login)
    {
        try
        {
            await _context.Users.Where(e => e.Login == login).ExecuteDeleteAsync();

            return true;
        }

        catch
        {
            return false;
        }
    }
}