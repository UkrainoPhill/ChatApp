using ChatApp.Core.Models;

namespace ChatApp.Core.Interfaces.Services;

public interface IChatService
{
    List<Chat> GetAllChats();
    void AddChat(string Name, Guid OwnerId);
    void UpdateChat(Guid id, string name);
    void DeleteChat(Guid chatId, Guid userId);
    void AddUserToChat(Guid chatId, Guid userId);
    Chat GetChatById(Guid id);
}