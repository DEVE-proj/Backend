using Microsoft.AspNetCore.Http.HttpResults;

public interface IUserService
{
    public Task<bool> CreateUser(CreateUserDto userData);
    public Task<User?> GetUser(string login, string password);
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

    public async Task<bool> CreateUser(CreateUserDto userData)
    {
        try
        {
            await _userRepo.CreateUser(new User(){Name = userData.Name, Login = userData.Login, Password = userData.Password});
            await _userRepo.SaveChangesAsync();

            return true;
        }

        catch
        {
            return false;
        }
    }

    public async Task<User?> GetUser(string login, string password)
    {
        return await _userRepo.GetUser(login, password);
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