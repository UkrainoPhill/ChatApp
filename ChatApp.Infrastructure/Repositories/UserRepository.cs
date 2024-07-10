using ChatApp.Core.Interfaces;
using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Models;
using ChatApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class UserRepository(ChatAppContext context) : IUserRepository
{
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
    public User GetUserById(Guid id)
    {
        var user = context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        return user;
    }
}