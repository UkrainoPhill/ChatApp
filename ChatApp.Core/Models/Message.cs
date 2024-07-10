using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Core.Models;

[Table("Messages")]
public class Message
{
    [Key]
    public int Id { get; set; }
    public string? Content { get; set; }
    [ForeignKey("Users")]
    public Guid UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Chats")]
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public DateTime Timestamp { get; set; }
}