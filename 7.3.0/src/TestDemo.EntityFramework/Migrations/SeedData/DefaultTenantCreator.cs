using System.Linq;
using TestDemo.EntityFramework;
using TestDemo.MultiTenancy;

namespace TestDemo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly TestDemoDbContext _context;

        public DefaultTenantCreator(TestDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
