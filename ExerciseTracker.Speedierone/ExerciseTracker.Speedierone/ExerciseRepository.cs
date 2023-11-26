using ExerciseTracker.Speedierone.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;

namespace ExerciseTracker.Speedierone
{
    public class ExerciseRepository : IExerciseRepository<Exercises>
    {
        public void Add(Exercises entity)
        {

        }

        public void Delete(Exercises entity)
        {

        }

        public IEnumerable<Exercises> GetAll()
        {           
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString")))
                {
                    connection.Open();
                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText =
                        $"SELECT * FROM Exercise Tracker";

                    List<Exercises> tableData = new();

                    using (SqlDataReader reader = tableCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tableData.Add(new Exercises
                                {
                                    Id = reader.GetInt32(0),
                                    DateStart = reader.GetDateTime(1),
                                    DateEnd = reader.GetDateTime(2),
                                    Duration = reader.GetTimeSpan(3)
                                });
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found");
                            return Enumerable.Empty<Exercises>();
                        }
                    }
                    return tableData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Exercises>();
            }
        }
        public Exercises Get(int id)
        {
            return null;
        }

        public void Update(Exercises entity)
        {

        }
    }
}
