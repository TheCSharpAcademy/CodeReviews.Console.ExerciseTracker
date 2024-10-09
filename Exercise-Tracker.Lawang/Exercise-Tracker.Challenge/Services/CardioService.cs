using Exercise_Tracker.Challenge.Repositories;
using Spectre.Console;

namespace Exercise_Tracker.Challenge.Services;

public class CardioService
{
    private readonly ICardioRepository _cardioRepository;
    public CardioService(ICardioRepository repo)
    {
        _cardioRepository = repo;
    }
    public async Task<Exercise?> CreateAsync(Exercise entity)
    {
        try
        {
            return await AnsiConsole.Status().StartAsync("Creating in database...", async ctx =>
            {
                return await _cardioRepository.CreateAsync(entity);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }

    public async Task<Exercise?> DeleteAsync(Exercise entity)
    {
        try
        {

            return await AnsiConsole.Status().StartAsync("[bold]Deleting data from repository...[/]", async ctx =>
            {
                return await _cardioRepository.DeleteAsync(entity);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }

    public async Task<List<Exercise>?> GetAllAsync()
    {
        try
        {
            return await AnsiConsole.Status().StartAsync("[bold]Fetching data from repository..[/]", async ctx =>
            {
                return await _cardioRepository.GetAllAsync();
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }

    public async Task<Exercise?> UpdateAsync(Exercise entity)
    {
        try
        {
            return await AnsiConsole.Status().StartAsync("[bold]Updating data in repository...[/]", async ctx =>
            {
                return await _cardioRepository.UpdateAsync(entity);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }
}
