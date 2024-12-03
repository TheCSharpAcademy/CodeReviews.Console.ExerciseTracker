using ExerciseTracker.TwilightSaw.Model;
using System.IO;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ExerciseTracker.TwilightSaw.Repository;

public class ExerciseDapperRepository<T>(IConfiguration configuration) : IRepository<T> where T : class
{
    private const string TableName = "Exercises";
    public T GetById(int id)
    {
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        return connection.QuerySingleOrDefault<T>($"SELECT * FROM {TableName} WHERE Id == @Id", new {Id = id});
    }

    public IEnumerable<T> GetAllByType(Func<T, bool> predicate)
    {
        return GetAll().Where(predicate);
    }

    public IEnumerable<T> GetAll()
    {
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        return connection.Query<T>($"SELECT * FROM {TableName}").ToList();
    }

    public void Add(T entity)
    {
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        var properties = new List<string> { "StartTime", "EndTime", "Comments", "Type" };
        var columns = string.Join(", ", properties);
        var values = string.Join(", ", properties.Select(p => $"@{p}"));
        var insertQuery = $"INSERT INTO {TableName} ({columns}) VALUES ({values})";
        connection.Execute(insertQuery, entity);
    }

    public void Update(T entity)
    {
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        const string updateQuery = $"UPDATE {TableName} SET StartTime = @StartTime, EndTime = @EndTime, Comments = @Comments, Type = @Type WHERE Id = @Id";
        connection.Execute(updateQuery, entity);
    }

    public void Delete(int id)
    {
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Execute($"DELETE FROM {TableName} WHERE Id = @Id", new { Id = id });
    }
}