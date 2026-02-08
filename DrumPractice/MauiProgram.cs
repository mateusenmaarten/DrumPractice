using DrumPractice.Data;
using DrumPractice.Models;
using DrumPractice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace DrumPractice;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "drumpractice.db")}");
        });

        builder.Services.AddMudServices();
        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddScoped<ExerciseService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        var app =  builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Database.EnsureCreated();

            if (!dbContext.Exercises.Any())
            {
                dbContext.Exercises.AddRange(
                    new Exercise { Name = "Single Stroke Roll", Description = "Alternate sticking: RLRL..." },
                    new Exercise { Name = "Double Stroke Roll", Description = "Two strokes per hand: RRLL..." },
                    new Exercise { Name = "Paradiddle", Description = "Combination of single and double strokes: RLRR LRLL..." }
                );
                dbContext.SaveChanges();
            }

            if (!dbContext.Tags.Any())
            {
                dbContext.Tags.AddRange(
                    new Tag { Name = "Beginner" },
                    new Tag { Name = "Intermediate" },
                    new Tag { Name = "Advanced" }
                );
                dbContext.SaveChanges();
            }
        }

        return app;
    }
}
