using ExerciseTrackerCarDioLogics.Data;
using ExerciseTrackerCarDioLogics.Repositories;

namespace ExerciseTrackerCarDioLogics.Helpers;

public class DependencyInjectorMethods
{
    public ExSessionController EFImplementationService()
    {
        //test
        Console.WriteLine("Entity framework is being used!");
        Console.ReadLine();

        ExSessionContext exSessionContext = new ExSessionContext();
        IExSessionRepository eFExSessionRepository = new EFExSessionRepository(exSessionContext);
        ExSessionService exSessionServiceEF = new ExSessionService(eFExSessionRepository);
        ExSessionController exSessionControllerEF = new ExSessionController(exSessionServiceEF);

        return exSessionControllerEF;
    }

    public ExSessionController RawSQLImplementationService()
    {
        //test
        Console.WriteLine("Raw SQL is being used!");
        Console.ReadLine();

        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ExerciseTrackerDB;Trusted_Connection=True;";
        IExSessionRepository rawSQLExSessionRepository = new RawSQLExSessionRepository(connectionString);
        ExSessionService exSessionServiceRawSQL = new ExSessionService(rawSQLExSessionRepository);
        ExSessionController exSessionControllerRawSQL = new ExSessionController(exSessionServiceRawSQL);

        return exSessionControllerRawSQL;
    }
}
