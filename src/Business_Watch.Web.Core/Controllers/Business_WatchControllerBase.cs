using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Business_Watch.Controllers
{
    public abstract class Business_WatchControllerBase: AbpController
    {
        protected Business_WatchControllerBase()
        {
            LocalizationSourceName = Business_WatchConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
