using Microsoft.AspNetCore.Http.HttpResults;
using BCrypt.Net;

public interface IUserService
{
    public Task<Guid?> CreateUser(CreateUserRequestDto userData);
    public Task<User?> GetUser(string login, string password);
    public Task<bool> UpdateUserLogin(string newLogin);
    public Task<bool> UpdateUserName(string newName);
    public Task<bool> UpdateUserPassword(string newPassword);
    public Task<bool> DeleteUser(string login);

}

public class UserService : IUserService
{

    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<Guid?> CreateUser(CreateUserRequestDto userData)
    {
        try
        {
            Guid userId = Guid.NewGuid();

            await _userRepo.CreateUser(new User(){Name = userData.Name, Login = userData.Login, Password = BCrypt.Net.BCrypt.HashPassword(userData.Password), UserId = userId});

            return userId;
        }

        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<User?> GetUser(string login, string password)
    {
        return await _userRepo.GetUser(login, password);
    }

    public async Task<bool> DeleteUser(string login)
    {
        return await _userRepo.DeleteUser(login);
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