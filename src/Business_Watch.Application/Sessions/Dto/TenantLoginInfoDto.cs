using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Business_Watch.MultiTenancy;

namespace Business_Watch.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
