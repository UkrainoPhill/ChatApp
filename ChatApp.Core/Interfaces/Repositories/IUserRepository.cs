using ChatApp.Core.Models;

namespace ChatApp.Core.Interfaces.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserById(Guid id);
}