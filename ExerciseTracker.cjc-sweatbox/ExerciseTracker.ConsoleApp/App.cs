using ExerciseTracker.ConsoleApp.Views;
using ExerciseTracker.Services;
using Microsoft.Extensions.Hosting;

namespace ExerciseTracker.ConsoleApp;

/// <summary>
/// A ConsoleApplication implemented as a HostedService.
/// </summary>
internal class App : IHostedService
{
    #region Fields

    private readonly IHostApplicationLifetime _appLifetime;
    private readonly ISeederService _seederService;
    private readonly MainMenuPage _mainMenuPage;
    private int? _exitCode;

    #endregion
    #region Constructors

    public App(IHostApplicationLifetime appLifetime, MainMenuPage mainMenuPage, ISeederService seederService)
    {
        _appLifetime = appLifetime;
        _seederService = seederService;
        _mainMenuPage = mainMenuPage;
    }

    #endregion
    #region Methods

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(async () =>
            {
                try
                {
                    await _seederService.SeedDatabaseAsync();
                    _mainMenuPage.Show();
                    _exitCode = 0;
                }
                catch (Exception exception)
                {
                    MessagePage.Show(exception);
                    _exitCode = 1;
                }
                finally
                {
                    _appLifetime.StopApplication();
                }
            });
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
        return Task.CompletedTask;
    }

    #endregion
}
