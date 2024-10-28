using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Business_Watch.Authorization;

namespace Business_Watch
{
    [DependsOn(
        typeof(Business_WatchCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Business_WatchApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Business_WatchAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Business_WatchApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
