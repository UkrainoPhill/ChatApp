using ChatApp.Core.Models;

namespace ChatApp.Core.Interfaces.Repositories;

public interface IMessageRepository
{
    void AddMessage(Message message);
}