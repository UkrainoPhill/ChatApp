using ChatApp.Core.Interfaces;
using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Interfaces.Services;
using ChatApp.Core.Models;

namespace ChatApp.Core.Services;

public class ChatService(IChatRepository chatRepository, IUserRepository userRepository) : IChatService
{
    public List<Chat> GetAllChats()
    {
        var chats = chatRepository.GetAllChats();
        return chats;
    }

    public void AddChat(string Name, Guid OwnerId)
    {
        var user = userRepository.GetUserById(OwnerId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var chat = new Chat
        {
            Name = Name,
            OwnerId = OwnerId
        };
        chatRepository.AddChat(chat);
    }

    public void UpdateChat(Guid id, string name)
    {
        var chat = chatRepository.GetChatById(id);
        if (chat == null)
        {
            throw new Exception("Chat not found");
        }
        chat.Name = name;
        chatRepository.UpdateChat(chat);
    }
    
    public void DeleteChat(Guid chatId, Guid userId)
    {
        if (chatRepository.GetChatById(chatId) == null)
        {
            throw new Exception("Chat not found");
        }
        var chat = chatRepository.GetChatById(chatId);
        if (chat.OwnerId != userId)
        {
            throw new Exception("You are not the owner of this chat");
        }
        chatRepository.DeleteChat(chat);
    }
    
    public void AddUserToChat(Guid chatId, Guid userId)
    {
        if (chatRepository.GetChatById(chatId) == null)
        {
            throw new Exception("Chat not found");
        }
        if (userRepository.GetUserById(userId) == null)
        {
            throw new Exception("User not found");
        }
        chatRepository.AddUserToChat(chatId, userId);
    }

    public Chat GetChatById(Guid id)
    {
        if (chatRepository.GetChatById(id) == null)
        {
            throw new Exception("Chat not found");
        }
        var chat = chatRepository.GetChatById(id);
        return chat;
    }

}