using TestDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace TestDemo.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TestDemoDbContext _context;

        public InitialHostDbBuilder(TestDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
