using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Exercise_Tracker.Challenge.Data;

public class CardioDbContext
{
    private readonly string _connectionString;
    public CardioDbContext()
    {
        _connectionString = ApplicationConnection.ConnectionString ?? "";
        try
        {
            using var connection = new SqlConnection(_connectionString);
            var createSql =
                @"IF NOT EXISTS
                (
                    SELECT * FROM sys.tables
                    WHERE name = 'Cardios' AND schema_id = SCHEMA_ID('dbo') 
                )
                BEGIN
                    CREATE TABLE Cardios
                    (
                        Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        DateStart DATETIME2,
                        DateEnd DATETIME2,
                        Comments NVARCHAR(MAX)
                    );
                END";

            connection.Execute(createSql);

            var seedData = 
                @"IF NOT EXISTS (SELECT 1 FROM Cardios)
                BEGIN
                    INSERT INTO Cardios
                        (DateStart, DateEnd, Comments)
                    VALUES
                        (@start1, @end1, @comment1),
                        (@start2, @end2, @comment2),
                        (@start3, @end3, @comment3)
                END
                ";

            var param = new 
            {
                @start1 = new DateTime(2024, 01, 01), @end1 = new DateTime(2024, 01, 30), @comment1 = "It was tough in the beginning but got the work done",
                @start2 = new DateTime(2024, 03, 01), @end2 = new DateTime(2024, 03, 30), @comment2 = "Finally achieved the total running distance of 5km",
                @start3 = new DateTime(2024, 06, 01), @end3 = new DateTime(2024, 07, 05), @comment3 = "It was fun completing the cardio routine."
            };

            connection.Execute(seedData, param);

            connection.Close();
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }


    }

    public IDbConnection GetConnection() => new SqlConnection(_connectionString);
}
