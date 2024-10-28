using Abp.Application.Services;
using Business_Watch.MultiTenancy.Dto;

namespace Business_Watch.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

