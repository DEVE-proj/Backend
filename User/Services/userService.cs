public interface IUserService
{
    public Task<bool> CreateUser(IUserDto userData);
    public Task<User?> GetUserByLogin(string login);
    public Task<bool> UpdateUserLogin(string newLogin);
    public Task<bool> UpdateUserName(string newName);
    public Task<bool> UpdateUserPassword(string newPassword);

}

public class UserService : IUserService
{

    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    public async Task<bool> CreateUser(IUserDto userData)
    {
        return true;
    }
    public async Task<User?> GetUserByLogin(string login)
    {
        return await _userRepo.GetUserByLogin(login);
    }
    public async Task<bool> UpdateUserLogin(string newLogin)
    {
        return true;
    }
    public async Task<bool> UpdateUserName(string newName)
    {
        return true;
    }
    public async Task<bool> UpdateUserPassword(string newPassword)
    {
        return true;
    }
}