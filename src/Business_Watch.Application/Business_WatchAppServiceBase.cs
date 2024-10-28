using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Business_Watch.Authorization.Users;
using Business_Watch.MultiTenancy;
using Business_Watch.IoC;
using Abp.Dependency;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Http;

namespace Business_Watch
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class Business_WatchAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        public IWorkScope WorkScope { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        protected Business_WatchAppServiceBase()
        {
            LocalizationSourceName = Business_WatchConsts.LocalizationSourceName;
            WorkScope = IocManager.Instance.Resolve<IWorkScope>();
            ObjectMapper = IocManager.Instance.Resolve<IObjectMapper>();
            _httpContextAccessor = IocManager.Instance.Resolve<IHttpContextAccessor>();
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
