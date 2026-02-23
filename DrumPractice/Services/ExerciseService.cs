using DrumPractice.Data;
using DrumPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DrumPractice.Services;

public class ExerciseService
{
    private DataContext _dataContext;
    public ExerciseService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Exercise?> GetExerciseByIdAsync(int id)
    {
        return await _dataContext.Exercises.FindAsync(id);
    }

    public async Task<List<Exercise>> GetExercisesAsync()
    {
        return await _dataContext.Exercises.Include(e => e.Tags).ToListAsync();
    }

    public async Task<List<Exercise>> GetExercisesByTagAsync(string tagName)
    {
        return await _dataContext.Exercises
            .Where(e => e.Tags!.Any(t => t.Name == tagName))
            .Include(e => e.Tags)
            .ToListAsync();
    }

    public async Task<Exercise> AddExerciseAsync(Exercise exercise, ICollection<Tag> tags)
    {
        // Attach existing tags to avoid duplicate inserts
        foreach (var tag in tags)
        {
            if (tag.Id > 0)
                _dataContext.Tags.Attach(tag);
            else
                _dataContext.Tags.Add(tag);
        }

        exercise.Tags = tags;
        _dataContext.Exercises.Add(exercise);
        await _dataContext.SaveChangesAsync();
        return exercise;
    }

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _dataContext.Tags.ToListAsync();
    }
}
