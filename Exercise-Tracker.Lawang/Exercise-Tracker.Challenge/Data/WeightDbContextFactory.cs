using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Exercise_Tracker.Challenge.Data;

public class WeightDbContextFactory : IDesignTimeDbContextFactory<WeightDbContext>
{
    public WeightDbContext CreateDbContext(string[] args)
    {
        DotNetEnv.Env.Load();
        var optionsBuilder = new DbContextOptionsBuilder<WeightDbContext>();
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
        return new WeightDbContext(optionsBuilder.Options);
    }

    
}
