using ExerciseTracker.ConsoleApp.Installers;
using Microsoft.Extensions.Hosting;

namespace ExerciseTracker.ConsoleApp;

/// <summary>
/// Main insertion point for the console application.
/// Configures the application as a HostedServices and launches as a Console.
/// </summary>
internal class Program
{
    #region Methods

    private static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);

        // Add services to the container.
        builder.InstallServicesInAssembly();

        await builder.RunConsoleAsync();                    
    }

    #endregion
}
