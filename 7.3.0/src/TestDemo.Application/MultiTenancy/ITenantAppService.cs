using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TestDemo.MultiTenancy.Dto;

namespace TestDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
