using Firebase.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System.IO;
using WordWeave.Repositories;
using WordWeave.Services;

namespace WordWeave;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        var configFileName = "firebaseConfig.Production.json";

#if DEBUG
        configFileName = "firebaseConfig.Development.json";
#endif

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(configFileName, optional: false, reloadOnChange: true)
            .Build();

        var firebaseConfig = config.GetSection("Firebase");

        var firebaseApiKey = firebaseConfig["ApiKey"];
        var firebaseAuthDomain = firebaseConfig["AuthDomain"];
        var firebaseProjectId = firebaseConfig["ProjectId"];

        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey));
        builder.Services.AddSingleton(authProvider);

        builder.Services.AddSingleton<FirestoreService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<UserService>();

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

        return builder.Build();
    }
}
