using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WMS.Api.Data;

public class WMSContextFactory : IDesignTimeDbContextFactory<WMSContext>
{
    public WMSContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("WMS")
            ?? "server=localhost; database=WMS; user=root; password=;";

        var optionsBuilder = new DbContextOptionsBuilder<WMSContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("8.0.32-mysql"));

        return new WMSContext(optionsBuilder.Options);
    }
}
