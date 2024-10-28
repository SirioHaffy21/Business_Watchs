using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Extensions;
using Business_Watch.Constants.Enum;
using Business_Watch.Entities;

namespace Business_Watch.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public DateTime? Birthday { get; set; }

        public Sex? Sex { get; set; }

        public string Address { get; set; }

        public Category_User? Category_User { get; set; }

        public string NumberPhone { get; set; }

        public long? BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        public Bank Bank { get; set; }
    }
}
