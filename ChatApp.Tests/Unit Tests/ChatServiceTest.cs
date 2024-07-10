namespace ChatApp.Test.Unit_Tests;
using Moq;
using Xunit;
using ChatApp.Core.Interfaces.Repositories;
using ChatApp.Core.Services;
using ChatApp.Core.Models;
using System;

public class ChatServiceTest
{
    private readonly Mock<IChatRepository> _chatRepositoryMock = new Mock<IChatRepository>();
    private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
    private readonly ChatService _chatService;

    public ChatServiceTest()
    {
        _chatService = new ChatService(_chatRepositoryMock.Object, _userRepositoryMock.Object);
    }

    [Fact]
    public void AddChat_ValidUser_AddsChat()
    {
        var ownerId = Guid.NewGuid();
        var chatName = "Test Chat";

        _userRepositoryMock.Setup(x => x.GetUserById(ownerId)).Returns(new User { Id = ownerId });

        _chatService.AddChat(chatName, ownerId);

        _chatRepositoryMock.Verify(x => x.AddChat(It.IsAny<Chat>()), Times.Once);
    }
}