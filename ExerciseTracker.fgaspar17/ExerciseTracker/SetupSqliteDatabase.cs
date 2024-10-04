using Microsoft.Data.Sqlite;

namespace ExerciseTracker;

public class SetupSqliteDatabase
{
    public static void InitializeSqliteDatabase()
    {
        try
        {
            using (SqliteConnection connection = new SqliteConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();

                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS ""Exercise"" (
	                            ""Id""	INTEGER NOT NULL,
	                            ""DateStart""	TEXT NOT NULL,
	                            ""DateEnd""	TEXT NOT NULL,
	                            ""Comments""	TEXT NOT NULL,
	                            PRIMARY KEY(""Id"" AUTOINCREMENT)
                                );";
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error ocurred: {ex.Message}");
        }
    }
}
