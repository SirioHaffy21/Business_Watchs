using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Business_Watch.Authorization
{
    public class Business_WatchAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Business_WatchConsts.LocalizationSourceName);
        }
    }
}
