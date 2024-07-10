using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Interfaces.Services;
using ChatApp.Core.Models;

namespace ChatApp.Core.Services;

public class MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IChatRepository chatRepository) : IMessageService
{
    public void AddMessage(string message, Guid userId, Guid chatId, DateTime sentAt)
    {
        var user = userRepository.GetUserById(userId);
        var chat = chatRepository.GetChatById(chatId);
        var newMessage = new Message
        {
            Content = message,
            UserId = userId,
            ChatId = chatId,
            Timestamp = sentAt
        };
        messageRepository.AddMessage(newMessage);
    }
}