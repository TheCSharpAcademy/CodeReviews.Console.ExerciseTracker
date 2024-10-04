namespace ExerciseTracker;

public static class GlobalConfig
{
    public static string? ConnectionString { get; set; }
    public static DbOption CurrentDatabase { get; set; }

    public static void InitializeConnectionString(string? connectionString)
    {
        ConnectionString = connectionString;
    }

    public static void ChangeCurrentDatabase()
    {
        CurrentDatabase = CurrentDatabase switch
        {
            DbOption.SqlServerEntityFramework => DbOption.SqliteAdoNet,
            DbOption.SqliteAdoNet => DbOption.SqlServerEntityFramework,
            _ => throw new NotImplementedException()
        };
    }
}