using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using TestDemo.EntityFramework;

namespace TestDemo.Migrator
{
    [DependsOn(typeof(TestDemoDataModule))]
    public class TestDemoMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TestDemoDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}