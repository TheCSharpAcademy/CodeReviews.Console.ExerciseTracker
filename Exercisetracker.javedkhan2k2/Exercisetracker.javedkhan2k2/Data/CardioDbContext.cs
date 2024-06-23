using Dapper;
using Exercisetacker.Entities;
using Microsoft.Data.SqlClient;

namespace Exercisetacker.Data;

public class CardioDbContext
{
    private string ConnectionString { get; init; }

    public CardioDbContext(string connectionString)
    {
        ConnectionString = connectionString;
        CreateTable();
    }

    private SqlConnection? GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }

    private void CreateTable()
    {
        var sql = @"IF OBJECT_ID(N'[dbo].[Cardios]', 'U') IS NULL
                Create Table Cardios (
                    Id INT IDENTITY (1,1) NOT NULL,
                    DateStart DateTime2 NOT NULL,
                    DateEnd DateTime2 NOT NULL,
                    Duration TIME NOT NULL,
                    Comments VARCHAR(255) NOT NULL,
                    CONSTRAINT [PK_Cardios] Primary Key CLUSTERED ([Id] Asc)
                )";
        using (var connection = GetConnection())
        {
            connection.Open();
            connection.Execute(sql);
        }
    }

    public async Task<List<Excercise>> GetAllAsync()
    {
        var sql = @$"Select * from Cardios ORDER BY Id Asc;";
        using (var connection = GetConnection())
        {
            connection.Open();
            var result = await connection.QueryAsync<Excercise>(sql);
            return result.ToList();
        }
    }

    public async Task<Excercise> FirstOrDefaultAsync(int id)
    {
        var sql = @$"Select * from Cardios WHERE Id = @Id;";
        using (var connection = GetConnection())
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<Excercise>(sql, new { Id = id });
            return result;
        }
    }

    internal async Task<Excercise> Add(Excercise parameters)
    {
        var sql = @$"INSERT INTO Cardios 
                        (DateStart, DateEnd, Duration, Comments) 
                        VALUES(@DateStart, @DateEnd, @Duration, @Comments);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
        using (var connection = GetConnection())
        {
            connection.Open();
            var newId = await connection.ExecuteScalarAsync<int>(sql, parameters);
            var addedJogging = await FirstOrDefaultAsync(newId);
            return addedJogging;
        }
    }

    internal async Task<int> Update(Excercise parameters)
    {
        var sql = @$"UPDATE Cardios 
                    SET 
                        DateStart = @DateStart, 
                        DateEnd   = @DateEnd, 
                        Duration  = @Duration,
                        Comments  = @Comments
                    WHERE Id = @Id
                    ";
        using (var connection = GetConnection())
        {
            connection.Open();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }

    internal async Task<int> Remove(Excercise parameters)
    {
        var sql = @$"DELETE FROM Cardios 
                    WHERE Id = @Id
                    ";
        using (var connection = GetConnection())
        {
            connection.Open();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }

}