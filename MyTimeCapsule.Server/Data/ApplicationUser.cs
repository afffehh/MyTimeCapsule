using Microsoft.AspNetCore.Identity;
using MyTimeCapsule.Server.Models;
namespace MyTimeCapsule.Server.Data;


public class ApplicationUser : IdentityUser
{
    public string? DisplayName { get; set; }

    public ICollection<Album> Albums { get; set; } = new List<Album>();
}