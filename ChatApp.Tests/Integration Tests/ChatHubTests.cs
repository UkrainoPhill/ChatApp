using ChatApp.Core.Interfaces.Services;
using ChatApp.Core.Services;
using ChatApp.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatApp.Test.Integration_Tests;

using Xunit;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using ChatApp;

public class ChatHubTests
{
    private readonly TestServer _server;
    private readonly HubConnection _connection;

    public ChatHubTests()
    {
        _server = new TestServer(new WebHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddSignalR();
                services.AddScoped<IChatService, ChatService>();
            })
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<ChatHub>("/chat");
                });
            }));
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5059/chat")
            .Build();
    }

    [Fact]
    public async Task SendMessage_UserSendsMessage_MessageReceived()
    {
        await _connection.StartAsync();
        var messageReceived = false;
        _connection.On<string>("ReceiveMessage", message =>
        {
            messageReceived = true;
        });
        await _connection.InvokeAsync("SendMessage", "Test User", "Hello, World!");
        await Task.Delay(1000);
        Assert.True(messageReceived);
        await _connection.StopAsync();
    }
}