using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using TestDemo.Authorization.Roles;
using TestDemo.Authorization.Users;
using TestDemo.FileUploadByDirective;
using TestDemo.MultiTenancy;
using TestDemo.Product;

namespace TestDemo.EntityFramework
{
    public class TestDemoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public virtual IDbSet<products> product { get; set; }
        //public virtual IDbSet<Productmaster> Productmasters { get; set; }
        public virtual IDbSet<Productchild> Productchildren { get; set; }
        public TestDemoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TestDemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TestDemoDbContext since ABP automatically handles it.
         */
        public TestDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TestDemoDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TestDemoDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
