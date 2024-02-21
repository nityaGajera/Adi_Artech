using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TestDemo.MultiTenancy;

namespace TestDemo.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}