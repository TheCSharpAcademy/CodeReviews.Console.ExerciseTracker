using Bogus;
using ExerciseTracker.Configurations;
using ExerciseTracker.Data.Contexts;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExerciseTracker.Services;

/// <summary>
/// Service to seed data into the database when configured to.
/// </summary>
public class SeederService : ISeederService
{
    #region Fields

    private readonly IOptions<DatabaseOptions> _databaseOptions;
    private readonly IExerciseService _exerciseService;
    private readonly IExerciseTypeService _exerciseTypeService;
    private readonly EntityFrameworkDbContext _databaseContext;

    #endregion
    #region Constructors

    public SeederService(IOptions<DatabaseOptions> databaseOptions, IExerciseService exerciseService, IExerciseTypeService exerciseTypeService, EntityFrameworkDbContext databaseContext)
    {
        _databaseOptions = databaseOptions;
        _exerciseService = exerciseService;
        _exerciseTypeService = exerciseTypeService;
        _databaseContext = databaseContext;
    }

    #endregion
    #region Methods

    public async Task SeedDatabaseAsync()
    {
        // Perform any outstanding migrations.
        await _databaseContext.Database.MigrateAsync();

        if (_databaseOptions.Value.SeedDatabase && !_exerciseService.ReturnAsync().Result.Any())
        {
            var exerciseTypes = await _exerciseTypeService.ReturnAsync();
            if (!exerciseTypes.Any())
            {
                return;
            }

            string[] comments =
            [
                "","","","","",
                "That was easy",
                "That was hard",
                "Max effort",
                "Felt strong"
            ];

            var seedData = new Faker<Exercise>()
                .RuleFor(o => o.DateStart, f => f.Date.Past(1, DateTime.Now))
                .RuleFor(o => o.DateEnd, (f, o) => o.DateStart.AddSeconds(f.Random.Double(0, 7200)))
                .RuleFor(o => o.Duration, (f, o) => o.DateEnd - o.DateStart)
                .RuleFor(o => o.Comments, f => f.PickRandom(comments))
                .RuleFor(o => o.ExerciseType, f => f.PickRandom<ExerciseType>(exerciseTypes));

            foreach (var exercise in seedData.Generate(100))
            {
                await _exerciseService.CreateAsync(exercise);
            }
        }
    }

    #endregion
}
