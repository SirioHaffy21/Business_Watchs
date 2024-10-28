using System.Threading.Tasks;
using Abp.Application.Services;
using Business_Watch.Authorization.Accounts.Dto;

namespace Business_Watch.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
