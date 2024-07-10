using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Core.Models;

[Table("Chats")]
public class Chat
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
    [ForeignKey("Users")]
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
}