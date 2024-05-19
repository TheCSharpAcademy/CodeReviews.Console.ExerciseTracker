using ExerciceTracker.Cactus;
using ExerciseTracker.Cactus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = new HostBuilder()
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<ExerciseDbContext>(options =>
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExerciseDB;Integrated Security=True;"));

            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<ExerciseService>();
            services.AddTransient<ExerciseController>();
        })
        .Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var controller = services.GetRequiredService<ExerciseController>();
            controller.MainMenu();
        }
    }
}
