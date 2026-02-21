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
}
