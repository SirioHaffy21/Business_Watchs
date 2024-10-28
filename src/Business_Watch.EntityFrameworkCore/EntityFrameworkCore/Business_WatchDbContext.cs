using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Business_Watch.Authorization.Roles;
using Business_Watch.Authorization.Users;
using Business_Watch.MultiTenancy;

namespace Business_Watch.EntityFrameworkCore
{
    public class Business_WatchDbContext : AbpZeroDbContext<Tenant, Role, User, Business_WatchDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public Business_WatchDbContext(DbContextOptions<Business_WatchDbContext> options)
            : base(options)
        {
        }
    }
}
