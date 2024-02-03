using Dapper;
using exerciseTracker.doc415.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace exerciseTracker.doc415.Repository;

internal class ExerciseRepositoryDapper : IExerciseRepository
{
    private readonly string _connectionString;
    public ExerciseRepositoryDapper()
    {
        _connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Exercise; Integrated Security=true;";
    }

    public IEnumerable<Exercise> GetAll()
    {
        var task = TGetAll();
        task.Wait();
        return task.Result;
    }
    private async Task<IEnumerable<Exercise>> TGetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        string getAllDataQuery = @"SELECT * FROM Exercies";
        using var dbReturns = await connection.QueryMultipleAsync(getAllDataQuery);
        var exerciseList = dbReturns.Read<Exercise>().ToList();
        return exerciseList;
    }

    public Exercise GetById(int id)
    {
        var task = TGetById(id);
        task.Wait();
        return task.Result;
    }

    private async Task<Exercise> TGetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        string getByIdDataQuery = @"SELECT * FROM Exercies Where Id={0}";
        using var dbReturn = await connection.QuerySingleAsync(getByIdDataQuery, new { Id = id });
        var exercise = dbReturn.Read<Exercise>();
        return exercise;
    }

    public void Delete(int id)
    {
        var task = TDelete(id);
        task.Wait();
    }
    private async Task TDelete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        string deleteDataQuery = @"DELETE FROM Exercies Where Id={0}";
        var affectedRows = await connection.ExecuteAsync(deleteDataQuery, new { Id = id });
        Console.Error.WriteLine(affectedRows);
    }

    public void Insert(Exercise exercise)
    {
        var task= TInsert(exercise);
        task.Wait();
    }
    private async Task TInsert(Exercise exercise)
    {
        using var connection = new SqlConnection(_connectionString);
        string insertDataQuery = $"INSERT INTO Exercies(Id,DateStart,DateEnd,Duration,Comments) values({0},{1},{2},{3},{4})";
        var affectedRows = await connection.ExecuteAsync(insertDataQuery, new
        {
            Id = exercise.Id,
            DateStart = exercise.DateStart,
            DateEnd = exercise.DateEnd,
            Duration = exercise.Duration,
            Comments = exercise.Comments
        });
        Console.Error.WriteLine(affectedRows);
    }

    public void Update(Exercise exercise)
    {
        var task = TUpdate(exercise);
        task.Wait();
    }
    private async Task TUpdate(Exercise exercise)
    {
        var updateDataQuery = @"UPDATE Exercies SET (DateStart,DateEnd,Duration,Comments) VALUES ({1},{2},{3},{4}) WHERE Id = {0}";
        using var connection = new SqlConnection(_connectionString);

        var affectedRows = connection.Execute(updateDataQuery, new
        {
            Id = exercise.Id,
            DateStart = exercise.DateStart,
            DateEnd = exercise.DateEnd,
            Duration = exercise.Duration,
            Comments = exercise.Comments
        });

        Console.WriteLine($"Affected Rows: {affectedRows}");
    }

}


