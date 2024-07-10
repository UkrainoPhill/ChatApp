using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Models;
using ChatApp.Infrastructure.Context;

namespace ChatApp.Infrastructure.Repositories;

public class MessageRepository(ChatAppContext context) : IMessageRepository
{
    public void AddMessage(Message message)
    {
        context.Messages.Add(message);
        context.SaveChanges();
    }
}