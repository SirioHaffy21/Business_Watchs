using System.Threading.Tasks;
using Business_Watch.Configuration.Dto;

namespace Business_Watch.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
