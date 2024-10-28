using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Business_Watch.Roles.Dto;
using Business_Watch.Users.Dto;

namespace Business_Watch.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
