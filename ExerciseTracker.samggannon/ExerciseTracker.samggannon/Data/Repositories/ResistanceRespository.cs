using ExerciseTracker.samggannon.Data.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ExerciseTracker.samggannon.Data.Repositories;

internal class ResistanceRespository : IExerciseRepository
{
    private readonly string _connectionString;

    public ResistanceRespository()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
    }

    public void Add(Exercise entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO dbo.ExerciseTrackerDB (sessionType, dateStart, dateEnd, sessionDuration, sessionComments) " +
                "VALUES (@Type, @DateStart, @DateEnd, @Duration, @Comments)",
                connection);

            command.Parameters.AddWithValue("@Type", entity.Type ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DateStart", entity.DateStart);
            command.Parameters.AddWithValue("@DateEnd", entity.DateEnd);
            command.Parameters.AddWithValue("@Duration", entity.Duration);
            command.Parameters.AddWithValue("@Comments", entity.Comments ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }
    }

    public List<Exercise> GetAllSessions()
    {
        var exercises = new List<Exercise>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM dbo.ExerciseTracker", connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var exercise = new Exercise
                    {
                        Id = reader.GetInt32(0),
                        Type = reader.GetString(1),
                        DateStart = reader.GetDateTime(2),
                        DateEnd = reader.GetDateTime(3),
                        Duration = reader.GetTimeSpan(4),
                        Comments = reader.GetString(5)
                    };

                    exercises.Add(exercise);
                }
            }
        }

        return exercises;
    }

    public Exercise GetSessionById(int sessionId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM dbo.ExerciseTrackerDB WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", sessionId);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Exercise
                    {
                        Id = reader.GetInt32(0),
                        Type = reader.GetString(1),
                        DateStart = reader.GetDateTime(2),
                        DateEnd = reader.GetDateTime(3),
                        Duration = reader.GetTimeSpan(4),
                        Comments = reader.GetString(5)
                    };
                }
            }
        }

        return null; // Or throw an exception if not found
    }

    public void Update(Exercise entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand(
                "UPDATE dbo.ExerciseTrackerDB SET sessionType = @Type, dateStart = @DateStart, dateEnd = @DateEnd, sessionDuration = @Duration, sessionComments = @Comments WHERE Id = @Id",
                connection);

            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Type", entity.Type ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DateStart", entity.DateStart);
            command.Parameters.AddWithValue("@DateEnd", entity.DateEnd);
            command.Parameters.AddWithValue("@Duration", entity.Duration);
            command.Parameters.AddWithValue("@Comments", entity.Comments ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }
    }


    public void Delete(Exercise entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("DELETE FROM dbo.ExerciseTracker WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", entity.Id);

            command.ExecuteNonQuery();
        }
    }
}
