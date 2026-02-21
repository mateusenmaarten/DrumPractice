using DrumPractice.Data;
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

            SeedExercisesAndTags.Seed(dbContext);
        }

        return app;
    }
}
