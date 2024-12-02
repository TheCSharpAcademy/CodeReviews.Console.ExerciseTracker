using ExerciseTracker.TwilightSaw.Model;
using System.IO;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExerciseTracker.TwilightSaw.Repository;

public class ExerciseDapperRepository<T>(IConfiguration configuration) : IRepository<T> where T : class
{
    private readonly IDbConnection _connection;

    public T GetById(int id)
    {
        var tableName = typeof(T).Name;
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        return connection.QuerySingleOrDefault<T>($"SELECT * FROM {tableName} WHERE Id == @Id", new {Id = id});
    }

    public IEnumerable<T> GetAllByType(Func<T, bool> predicate)
    {
        return GetAll().Where(predicate);
    }

    public IEnumerable<T> GetAll()
    {
        var tableName = typeof(T).Name;
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        return connection.Query<T>($"SELECT * FROM {tableName}").ToList();
    }

    public void Add(T entity)
    {
        var tableName = typeof(T).Name;
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Execute(GenerateInsertQuery(entity), entity);
    }

    public void Update(T entity)
    {
        var tableName = typeof(T).Name;
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Execute(GenerateUpdateQuery(entity), entity);
    }

    public void Delete(int id)
    {
        var tableName = typeof(T).Name;
        using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        connection.Execute($"DELETE FROM {tableName} WHERE Id = @Id", new { Id = id });
    }

    private string GenerateInsertQuery(T entity)
    {
        var properties = typeof(T).GetProperties().Select(p => p.Name);
        var columns = string.Join(", ", properties);
        var values = string.Join(", ", properties.Select(p => $"@{p}"));
        return $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})";
    }
    private string GenerateUpdateQuery(T entity)
    {
        var properties = typeof(T).GetProperties().Select(p => $"{p.Name} = @{p.Name}");
        var setClause = string.Join(", ", properties);
        return $"UPDATE {typeof(T).Name} SET {setClause} WHERE Id = @Id";
    }
}