using ChatApp.Core.Models;

namespace ChatApp.Core.Interfaces.Repositories;

public interface IChatRepository
{
    List<Chat> GetAllChats();
    void AddChat(Chat chat);
    Chat GetChatById(Guid id);
    void UpdateChat(Chat chat);
    void DeleteChat(Chat chat);
    void AddUserToChat(Guid chatId, Guid userId);
}