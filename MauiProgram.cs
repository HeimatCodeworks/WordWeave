using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WordWeave.Repositories;
using WordWeave.Services;
using Microsoft.EntityFrameworkCore;
using FileSystem = Microsoft.Maui.Storage.FileSystem;
using Path = System.IO.Path;


namespace WordWeave;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "WordWeave.db3");
            options.UseSqlite($"Filename={dbPath}");
        });

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<UserService>();

        return builder.Build();
    }
}
