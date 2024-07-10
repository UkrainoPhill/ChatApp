using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Core.Models;

[Table("Users")]
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public List<Chat> Chats { get; set; }
    public List<Message> Messages { get; set; }
    public List<Chat> OwnedChats { get; set; }
}