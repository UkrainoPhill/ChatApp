using ChatApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Infrastructure.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Content).IsRequired();
        builder.HasOne(u => u.User)
            .WithMany(m => m.Messages)
            .HasForeignKey(m => m.UserId);
        builder.HasOne(c => c.Chat)
            .WithMany(m => m.Messages)
            .HasForeignKey(m => m.ChatId);
    }
}