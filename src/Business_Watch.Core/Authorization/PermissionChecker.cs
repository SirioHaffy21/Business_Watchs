using Abp.Authorization;
using Business_Watch.Authorization.Roles;
using Business_Watch.Authorization.Users;

namespace Business_Watch.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
