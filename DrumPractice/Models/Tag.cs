namespace DrumPractice.Models;

public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Exercise>? Exercises { get; set; }
}
