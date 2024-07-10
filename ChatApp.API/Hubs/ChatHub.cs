using ChatApp.Core.Interfaces.Services;
using ChatApp.Core.Models;
using ChatApp.Dtos.ChatDto;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs;

public class ChatHub(IChatService chatService, IUserService userService, IMessageService messageService) : Hub
{
    [HubMethodName("SendMessage")]
    public async Task SendMessage(string Message, Guid UserId, Guid ChatId)
    {
        var chat = chatService.GetChatById(ChatId);
        var user = userService.GetUserById(UserId);
        if (chat == null)
        {
            throw new HubException("Chat not found");
        }
        if (user == null)
        {
            throw new HubException("User not found");
        }
        if (string.IsNullOrEmpty(Message))
        {
            throw new HubException("Message cannot be empty");
        }
        messageService.AddMessage(Message, UserId, ChatId, DateTime.Now.ToUniversalTime());
        await Clients.Group(chat.Name).SendAsync("ReceiveMessage", $"{user.Username}: {Message}");
    }

    [HubMethodName("JoinChat")]
    public async Task JoinChat(Guid userId, Guid chatId)
    {
        var chat = chatService.GetChatById(chatId);
        var user = userService.GetUserById(userId);
        if (chat == null)
        {
            throw new HubException("Chat not found");
        }
        if (user == null)
        {
            throw new HubException("User not found");
        }
        await Groups.AddToGroupAsync(Context.ConnectionId, chat.Name);
        chatService.AddUserToChat(chatId, userId);
        await Clients.Group(chat.Name).SendAsync("ReceiveMessage", $"{user.Username} has joined the chat");
    }
    
    [HubMethodName("LeaveChat")]
    public async Task LeaveChat(Guid ChatId, Guid UserId)
    {
        var chat = chatService.GetChatById(ChatId);
        var user = userService.GetUserById(UserId);
        if (chat == null)
        {
            throw new HubException("Chat not found");
        }
        if (user == null)
        {
            throw new HubException("User not found");
        }
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chat.Name);
        if (chat.OwnerId == UserId || chat.Users.Count == 1)
        {
            chatService.DeleteChat(ChatId, UserId);
        }
        await Clients.Group(chat.Name).SendAsync("ReceiveMessage", $"{user.Username} has left the chat");
    }
}