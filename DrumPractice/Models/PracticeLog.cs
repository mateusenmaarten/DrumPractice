namespace DrumPractice.Models;

public class PracticeLog
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public DateTime? Date { get; set; }
    public int? SecondsPracticed { get; set; }
    public int? BpmUsed { get; set; }
    public int? Rating { get; set; }

    public Exercise? Exercise { get; set; }
}
