using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Exercisetacker.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Exercisetacker.UI;

public class ConsoleAppService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHostApplicationLifetime _appLifetime;

    public ConsoleAppService(IServiceProvider serviceProvider, IHostApplicationLifetime appLifetime)
    {
        _serviceProvider = serviceProvider;
        _appLifetime = appLifetime;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var joggingController = scope.ServiceProvider.GetRequiredService<JoggingController>();
            var cardioController = scope.ServiceProvider.GetRequiredService<CardioController>();

            var menu = new Menu();
            var runApplication = true;
            while (runApplication)
            {
                Console.Clear();
                var choice = menu.GetMainMenu();
                switch (choice)
                {
                    case "Joggings":
                        await DisplayJoggingMenu(joggingController, menu);
                        break;
                    case "Cardios":
                        await DisplayCardioMenu(cardioController, menu);
                        break;
                    case "Exit":
                        runApplication = false;
                        _appLifetime.StopApplication();
                        break;
                    default:
                        break;
                }
            }
        }
        await Task.CompletedTask;
    }

    private async Task DisplayJoggingMenu(JoggingController joggingController, Menu menu)
    {
        while (true)
        {
            Console.Clear();
            var choice = menu.GetJoggingsMenu();
            switch (choice)
            {
                case "View All Jogging Sessions":
                    await joggingController.DisplayAllExerciseSessions();
                    break;
                case "Add Jogging Session":
                    await joggingController.AddExercise();
                    break;
                case "Update Jogging Session":
                    await joggingController.UpdateExercise();
                    break;
                case "Delete Jogging Session":
                    await joggingController.DeleteExercise();
                    break;
                case $"[maroon]Go Back[/]":
                    return;
                default:
                    break;
            }
        }
    }

    private async Task DisplayCardioMenu(CardioController cardioController, Menu menu)
    {
        while (true)
        {
            Console.Clear();
            var choice = menu.GetCardiosMenu();
            switch (choice)
            {
                case "View All Cardio Sessions":
                    await cardioController.DisplayAllExerciseSessions();
                    break;
                case "Add Cardio Session":
                    await cardioController.AddExercise();
                    break;
                case "Update Cardio Session":
                    await cardioController.UpdateExercise();
                    break;
                case "Delete Cardio Session":
                    await cardioController.DeleteExercise();
                    break;
                case $"[maroon]Go Back[/]":
                    return;
                default:
                    break;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

}
