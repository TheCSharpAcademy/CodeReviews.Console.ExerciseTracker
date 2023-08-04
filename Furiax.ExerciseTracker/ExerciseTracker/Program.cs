using ExerciseTracker;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = new HostBuilder()
	.ConfigureServices((hostContext, services) =>
	{
		services.AddDbContext<ExerciseTrackerContext>(options =>
			options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=ExerciseTracker"));
	})
	.Build();

using (var scope = host.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<ExerciseTrackerContext>();
}

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB";

using (SqlConnection connection = new SqlConnection(connectionString))
{
	try
	{
		connection.Open();
		Console.WriteLine("Connection successful!");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Connection failed: {ex.Message}");
	}
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();