using Microsoft.Extensions.Configuration;

namespace ExerciseTracker.Utilities;

public static class DataExtensions
{
    internal static string GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName)
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        return configuration.GetConnectionString("DatabasePath");
    }
}