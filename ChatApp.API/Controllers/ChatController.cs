using ChatApp.Core.Interfaces;
using ChatApp.Core.Interfaces.Services;
using ChatApp.Core.Models;
using ChatApp.Dtos.ChatDto;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController(IChatService service) : ControllerBase
{
    [HttpGet("GetAllChats")]
    public OkObjectResult GetAllChats()
    {
        var chats = service.GetAllChats();
        var chatDtos = chats.Select(chat => new GetAllChatsResponseDto(chat.Id, chat.Name, chat.OwnerId)).ToList();
        return Ok(chatDtos);
    }
    
    [HttpPost("AddChat")]
    public OkResult AddChat([FromBody] AddChatRequestDto dto)
    {
        service.AddChat(dto.Name, dto.OwnerId);
        return Ok();
    }
    
    [HttpPatch("UpdateChat")]
    public OkResult ChangeName([FromBody] UpdateChatRequestDto dto)
    {
        service.UpdateChat(dto.ChatId, dto.Name);
        return Ok();
    }
    
    [HttpDelete("DeleteChat")]
    public OkResult DeleteChat([FromBody] DeleteChatRequestDto dto)
    {
        service.DeleteChat(dto.ChatId, dto.UserId);
        return Ok();
    }
}