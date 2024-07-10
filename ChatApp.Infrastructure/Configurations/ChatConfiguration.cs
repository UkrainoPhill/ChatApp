using ChatApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Infrastructure.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired();
        builder.HasMany(u => u.Users)
            .WithMany(c => c.Chats);
        builder.HasMany(m => m.Messages)
            .WithOne(c => c.Chat);
        builder.HasOne(o => o.Owner)
            .WithMany(c => c.OwnedChats)
            .HasForeignKey(c => c.OwnerId);
    }
}