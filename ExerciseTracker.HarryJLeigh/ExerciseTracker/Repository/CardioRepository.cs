using System.Data;
using ExerciseTracker.Models;
using ExerciseTracker.Utilities;
using Microsoft.Data.SqlClient;

namespace ExerciseTracker.Repository;

public class CardioRepository : IRepository<Cardio>
{
    private readonly string _connectionString = DataExtensions.GetConnectionString();

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public Cardio GetById(int id)
    {
        const string query = "SELECT * FROM CardioSessions WHERE Id = @Id";

        try
        {
            using var connection = CreateConnection();
            connection.Open();

            using var command = new SqlCommand(query, (SqlConnection)connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return MapReaderToCardio(reader);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching Cardio entry by ID.", ex);
        }

        return null;
    }

    public IEnumerable<Cardio> GetAll()
    {
        const string query = "SELECT * FROM CardioSessions";
        var cardioSessions = new List<Cardio>();

        try
        {
            using var connection = CreateConnection();
            connection.Open();

            using var command = new SqlCommand(query, (SqlConnection)connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                cardioSessions.Add(MapReaderToCardio(reader));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching all Cardio entries.", ex);
        }

        return cardioSessions;
    }

    public void Add(Cardio cardio)
    {
        const string query = @"INSERT INTO CardioSessions (DateStart, DateEnd, Distance, Duration, Comments)
                               VALUES (@DateStart, @DateEnd, @Distance,@Duration, @Comments)";

        try
        {
            using var connection = CreateConnection();
            connection.Open();

            using var command = new SqlCommand(query, (SqlConnection)connection);
            AddCardioParameters(command, cardio);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding Cardio entry.", ex);
        }
    }

    public void Update(Cardio cardio)
    {
        const string query = @"UPDATE CardioSessions 
                               SET DateStart = @DateStart, 
                                   DateEnd = @DateEnd, 
                                   Distance = @Distance, 
                                   Duration = @Duration,
                                   Comments = @Comments
                               WHERE Id = @Id";

        try
        {
            using var connection = CreateConnection();
            connection.Open();

            using var command = new SqlCommand(query, (SqlConnection)connection);
            AddCardioParameters(command, cardio);
            command.Parameters.AddWithValue("@Id", cardio.Id);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating Cardio entry.", ex);
        }
    }

    public void Delete(Cardio cardio)
    {
        const string query = "DELETE FROM CardioSessions WHERE Id = @Id";

        try
        {
            using var connection = CreateConnection();
            connection.Open();

            using var command = new SqlCommand(query, (SqlConnection)connection);
            command.Parameters.AddWithValue("@Id", cardio.Id);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting Cardio entry.", ex);
        }
    }

    private Cardio MapReaderToCardio(SqlDataReader reader)
    {
        return new Cardio
        {
            Id = Convert.ToInt32(reader["Id"]),
            DateStart = DateTime.Parse(reader["DateStart"].ToString()),
            DateEnd = DateTime.Parse(reader["DateEnd"].ToString()),
            Duration = TimeSpan.Parse(reader["Duration"].ToString()),
            Distance = Convert.ToDouble(reader["Distance"]),
            Comments = reader["Comments"].ToString()
        };
    }

    private void AddCardioParameters(SqlCommand command, Cardio cardio)
    {
        command.Parameters.AddWithValue("@DateStart", cardio.DateStart);
        command.Parameters.AddWithValue("@DateEnd", cardio.DateEnd);
        command.Parameters.AddWithValue("@Distance", cardio.Distance);
        command.Parameters.AddWithValue("@Duration", cardio.Duration);
        command.Parameters.AddWithValue("@Comments", cardio.Comments);
    }
}