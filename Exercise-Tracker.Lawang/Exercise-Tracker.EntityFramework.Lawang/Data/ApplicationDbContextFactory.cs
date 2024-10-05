using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Exercise_Tracker.EntityFramework.Lawang.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> 
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        DotNetEnv.Env.Load();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
