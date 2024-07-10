using ChatApp.Core.Models;
using ChatApp.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Context;

public class ChatAppContext(DbContextOptions<ChatAppContext> options) : DbContext(options)
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ChatConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.MessageConfiguration());
    }
    
}