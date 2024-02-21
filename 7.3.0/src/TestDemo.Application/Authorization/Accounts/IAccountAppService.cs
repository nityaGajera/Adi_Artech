using System.Threading.Tasks;
using Abp.Application.Services;
using TestDemo.Authorization.Accounts.Dto;

namespace TestDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
