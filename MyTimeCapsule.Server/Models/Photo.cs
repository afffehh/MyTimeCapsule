
namespace MyTimeCapsule.Server.Models;

public class Photo
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;

    // Path where the photo is stored on the server
    public string FilePath { get; set; } = string.Empty;

    // In case you want to store the URL of the photo if hosted externally
    public string? Url { get; set; }

    public string? Caption { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public int AlbumId { get; set; }
    public Album? Album { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}