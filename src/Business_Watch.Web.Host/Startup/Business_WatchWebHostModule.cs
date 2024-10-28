using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Business_Watch.Configuration;

namespace Business_Watch.Web.Host.Startup
{
    [DependsOn(
       typeof(Business_WatchWebCoreModule))]
    public class Business_WatchWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Business_WatchWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Business_WatchWebHostModule).GetAssembly());
        }
    }
}
