using ChatApp.Core.Interfaces;
using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Models;
using ChatApp.Core.Services;
using ChatApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class ChatRepository(ChatAppContext context) : IChatRepository
{
    public List<Chat> GetAllChats()
    {
        var chats = context.Chats.AsNoTracking().ToList();
        return chats;
    }
    
    public void AddChat(Chat chat)
    {
        context.Chats.Add(chat);
        context.SaveChanges();
    }
    
    public Chat GetChatById(Guid id)
    {
        var chat = context.Chats.AsNoTracking().FirstOrDefault(c => c.Id == id);
        return chat;
    }
    
    public void UpdateChat(Chat chat)
    {
        context.Chats.Update(chat);
        context.SaveChanges();
    }

    public void DeleteChat(Chat chat)
    {
        context.Chats.Remove(chat);
        context.SaveChanges();
    }
    
    public void AddUserToChat(Guid chatId, Guid userId)
    {
        var chat = context.Chats.Include(c => c.Users).FirstOrDefault(c => c.Id == chatId);
        var user = context.Users.FirstOrDefault(u => u.Id == userId); 
        if (chat != null && user != null)
        {
            chat.Users ??= new List<User>(); // Ensure the Users collection is initialized
            chat.Users.Add(user);
            context.SaveChanges();
        }
        else
        {
            throw new Exception("Chat or user not found");
        }
    }
}