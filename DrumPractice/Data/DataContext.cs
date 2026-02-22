using DrumPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DrumPractice.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options){ }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PracticeLog> PracticeLogs { get; set; }
}
