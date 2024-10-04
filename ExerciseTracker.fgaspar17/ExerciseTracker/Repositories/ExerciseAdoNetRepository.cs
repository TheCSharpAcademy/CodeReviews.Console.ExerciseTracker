using Microsoft.Data.Sqlite;

namespace ExerciseTracker;

public class ExerciseAdoNetRepository : IRepository<Exercise>
{
    public void Add(Exercise exercise)
    {
        using (SqliteConnection connection = new SqliteConnection(GlobalConfig.ConnectionString))
        {
            connection.Open();
            SqliteCommand cmd = connection.CreateCommand();

            cmd.CommandText = $@"INSERT INTO Exercise (DateStart, DateEnd, Comments) 
                                        VALUES ('{exercise.DateStart}', '{exercise.DateEnd}', '{exercise.Comments}')";

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Delete(Exercise exercise)
    {
        using (SqliteConnection connection = new SqliteConnection(GlobalConfig.ConnectionString))
        {
            connection.Open();
            SqliteCommand cmd = connection.CreateCommand();

            cmd.CommandText = $@"DELETE FROM Exercise
                                        WHERE Id = {exercise.Id}";

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    public IEnumerable<Exercise> GetAll()
    {
        List<Exercise> records = new List<Exercise>();
        using (SqliteConnection connection = new SqliteConnection(GlobalConfig.ConnectionString))
        {
            connection.Open();
            SqliteCommand cmd = connection.CreateCommand();

            cmd.CommandText = $"SELECT Id, DateStart, DateEnd, Comments FROM Exercise";

            SqliteDataReader reader = cmd.ExecuteReader();
            int idIndex = reader.GetOrdinal("Id");
            int dateStartIndex = reader.GetOrdinal("DateStart");
            int dateEndIndex = reader.GetOrdinal("DateEnd");
            int commentsIndex = reader.GetOrdinal("Comments");

            while (reader.Read())
            {
                records.Add(new Exercise()
                {
                    Id = reader.GetFieldValue<int>(idIndex),
                    DateStart = reader.GetFieldValue<DateTime>(dateStartIndex),
                    DateEnd = reader.GetFieldValue<DateTime>(dateEndIndex),
                    Comments = reader.GetFieldValue<string>(commentsIndex),
                });
            }
            connection.Close();
        }

        return records;
    }

    public Exercise? GetById(int id)
    {
        Exercise record = new();
        using (SqliteConnection connection = new SqliteConnection(GlobalConfig.ConnectionString))
        {
            connection.Open();
            SqliteCommand cmd = connection.CreateCommand();

            cmd.CommandText = $"SELECT Id, DateStart, DateEnd, Comments FROM Exercise WHERE Id = {id}";

            SqliteDataReader reader = cmd.ExecuteReader();
            int idIndex = reader.GetOrdinal("Id");
            int dateStartIndex = reader.GetOrdinal("DateStart");
            int dateEndIndex = reader.GetOrdinal("DateEnd");
            int commentsIndex = reader.GetOrdinal("Comments");

            while (reader.Read())
            {

                record.Id = reader.GetFieldValue<int>(idIndex);
                record.DateStart = reader.GetFieldValue<DateTime>(dateStartIndex);
                record.DateEnd = reader.GetFieldValue<DateTime>(dateEndIndex);
                record.Comments = reader.GetFieldValue<string>(commentsIndex);
            }
            connection.Close();
        }

        return record;
    }

    public void Update(Exercise exercise)
    {
        using (SqliteConnection connection = new SqliteConnection(GlobalConfig.ConnectionString))
        {
            connection.Open();
            SqliteCommand cmd = connection.CreateCommand();

            cmd.CommandText = $@"UPDATE Exercise  SET 
                                        DateStart = '{exercise.DateStart}', 
                                        DateEnd = '{exercise.DateEnd}',
                                        Comments = '{exercise.Comments}'
                                        WHERE Id = {exercise.Id}";

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}