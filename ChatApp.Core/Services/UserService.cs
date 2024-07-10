using ChatApp.Core.Interfaces;
using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Interfaces.Services;
using ChatApp.Core.Models;

namespace ChatApp.Core.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public Guid AddUser(string username)
    {
        var user = new User
        {
            Username = username
        };
        repository.AddUser(user);
        return user.Id;
    }
    public User GetUserById(Guid id)
    {
        var user = repository.GetUserById(id);
        return user;
    }
}