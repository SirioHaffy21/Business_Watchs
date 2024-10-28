using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Business_Watch.Configuration;
using Business_Watch.Web;

namespace Business_Watch.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Business_WatchDbContextFactory : IDesignTimeDbContextFactory<Business_WatchDbContext>
    {
        public Business_WatchDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Business_WatchDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Business_WatchDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Business_WatchConsts.ConnectionStringName));

            return new Business_WatchDbContext(builder.Options);
        }
    }
}
