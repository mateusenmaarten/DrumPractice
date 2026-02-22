using DrumPractice.Data;
using DrumPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DrumPractice.Services;

public class PracticeLogService
{
    private DataContext _dataContext;
    public PracticeLogService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PracticeLog?> GetPracticeLogByIdAsync(int id)
    {
        return await _dataContext.PracticeLogs.FindAsync(id);
    }

    public async Task<List<PracticeLog>> GetPracticeLogsAsync()
    {
        return await _dataContext.PracticeLogs.Include(e => e.Exercise).ToListAsync();
    }

    public async Task<List<PracticeLog>> GetPracticeLogsByExerciseIdAsync(int exerciseId)
    {
        return await _dataContext.PracticeLogs
            .Where(e => e.ExerciseId! == exerciseId)
            .ToListAsync();
    }

    public async Task AddPracticeLogAsync(PracticeLog practiceLog)
    {
        _dataContext.PracticeLogs.Add(practiceLog);
        await _dataContext.SaveChangesAsync();
    }
}
