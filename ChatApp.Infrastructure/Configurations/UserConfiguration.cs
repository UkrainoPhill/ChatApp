using ChatApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username)
            .IsRequired();
        builder.HasMany(u => u.Chats)
            .WithMany(c => c.Users);
        builder.HasMany(u => u.Messages)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
        builder.HasMany(u => u.OwnedChats)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId);
    }
}