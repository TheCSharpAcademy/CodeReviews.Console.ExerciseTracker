using Microsoft.Extensions.Hosting;

namespace ExerciseTracker.ConsoleApp.Installers;

public interface IInstaller
{
    void InstallServices(IHostBuilder builder);
}
