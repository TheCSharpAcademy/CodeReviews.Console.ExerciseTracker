using System;
using Dapper;
using Exercise_Tracker.Challenge.Data;
using Microsoft.Data.SqlClient;

namespace Exercise_Tracker.Challenge.Repositories;

public class CardioRepository : ICardioRepository
{
    private readonly CardioDbContext _dbContext;
    public CardioRepository(CardioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Exercise?> CreateAsync(Exercise entity)
    {
        try
        {
            var createSql = 
            @"INSERT INTO Cardios
            (DateStart, DateEnd, Comments)
            VALUES (@dateStart, @dateEnd, @comments)
            SELECT CAST(SCOPE_IDENTITY() as int)";

            var param = new {@dateStart = entity.DateStart, @dateEnd = entity.DateEnd, @comments = entity.Comments};

            using var connection = _dbContext.GetConnection();
            var newId = await connection.QuerySingleAsync<int>(createSql, param);
            connection.Close();

            if(newId == 0) return null;
            entity.Id = newId;

            return entity;
        }
        catch(SqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }

    public async Task<Exercise?> DeleteAsync(Exercise entity)
    {
        try
        {
            var deleteSql = 
            @"DELETE FROM Cardios
            WHERE Id = @id
            ";
            using var connection = _dbContext.GetConnection(); 
            var affectedRow = await connection.ExecuteAsync(deleteSql, new {@id = entity.Id});
            connection.Close();

            if(affectedRow == 0) return null;

            return entity;
        }
        catch(SqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }

        return null;
    }

    public async Task<List<Exercise>?> GetAllAsync()
    {
        try
        {
            var getAllSql = 
                @"SELECT * FROM Cardios";

            using var connection = _dbContext.GetConnection();
            var cardios = await connection.QueryAsync<Exercise>(getAllSql);
            connection.Close();

            return cardios.ToList();
            
        }
        catch(SqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }

    public async Task<Exercise?> UpdateAsync(Exercise entity)
    {
        try
        {
            var updateSql = 
                @"UPDATE Cardios
                SET DateStart = @datestart,
                    DateEnd = @enddate,
                    Comments = @comment
                WHERE Id = @id";

            var param = new {@datestart = entity.DateStart, @enddate = entity.DateEnd, @comment = entity.Comments, @id = entity.Id};

            using var connection = _dbContext.GetConnection();
            var updatedCardio = await connection.ExecuteAsync(updateSql, param);

            if(updatedCardio == 0) return null;

            return entity;
                

        }
        catch(SqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }
}
