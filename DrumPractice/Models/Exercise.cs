namespace DrumPractice.Models;

public class Exercise
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? MediaUrl { get; set; }
    public bool IsFavorite { get; set; }

    public ICollection<Tag>? Tags { get; set; }
}
