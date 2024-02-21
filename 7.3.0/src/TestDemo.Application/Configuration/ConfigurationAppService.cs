using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TestDemo.Configuration.Dto;

namespace TestDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TestDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
