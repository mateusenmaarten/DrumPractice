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

    public async Task<List<Exercise>> GetExercisesAsync()
    {
        return await _dataContext.Exercises.ToListAsync();
    }
}
