namespace ChatApp.Core.Interfaces.Services;

public interface IMessageService
{
    void AddMessage(string message, Guid userId, Guid chatId, DateTime sentAt);
}