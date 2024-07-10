using ChatApp.Core.Models;

namespace ChatApp.Core.Interfaces.Services;

public interface IUserService
{
    Guid AddUser(string username);
    User GetUserById(Guid id);
}