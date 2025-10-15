
using MyTimeCapsule.Server.Data;
namespace MyTimeCapsule.Server.Models;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
