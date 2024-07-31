using Microsoft.Extensions.Hosting;

namespace ExerciseTracker.ConsoleApp.Installers;

/// <summary>
/// Microsoft.Extensions.Hosting.IHostBuilder interface extension methods.
/// </summary>
public static class IHostBuilderExtensions
{
    /// <summary>
    /// Gets the installers for this application and performs the InstallServices method on each.
    /// </summary>
    /// <param name="builder">The IHostBuilder.</param>
    public static void InstallServicesInAssembly(this IHostBuilder builder)
    {
        var installers = typeof(Program).Assembly.ExportedTypes.
            Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
            Select(Activator.CreateInstance).
            Cast<IInstaller>().
            ToList();

        installers.ForEach(installer => installer.InstallServices(builder));
    }
}
