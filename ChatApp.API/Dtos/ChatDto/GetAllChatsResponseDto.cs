namespace ChatApp.Dtos.ChatDto;

public record GetAllChatsResponseDto(Guid id, string Name, Guid OwnerId);