using System.Threading.Tasks;
using Abp.Application.Services;
using TestDemo.Configuration.Dto;

namespace TestDemo.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}