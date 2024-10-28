using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Business_Watch.EntityFrameworkCore
{
    public static class Business_WatchDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Business_WatchDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Business_WatchDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
