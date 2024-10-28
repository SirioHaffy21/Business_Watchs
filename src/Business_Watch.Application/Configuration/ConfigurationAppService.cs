using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Business_Watch.Configuration.Dto;

namespace Business_Watch.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Business_WatchAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
