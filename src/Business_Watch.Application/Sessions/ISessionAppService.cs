using System.Threading.Tasks;
using Abp.Application.Services;
using Business_Watch.Sessions.Dto;

namespace Business_Watch.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
