using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Business_Watch.EntityFrameworkCore;
using Business_Watch.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Business_Watch.Web.Tests
{
    [DependsOn(
        typeof(Business_WatchWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Business_WatchWebTestModule : AbpModule
    {
        public Business_WatchWebTestModule(Business_WatchEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Business_WatchWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Business_WatchWebMvcModule).Assembly);
        }
    }
}