using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace TestDemo.EntityFramework.Repositories
{
    public abstract class TestDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TestDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TestDemoRepositoryBase(IDbContextProvider<TestDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TestDemoRepositoryBase<TEntity> : TestDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TestDemoRepositoryBase(IDbContextProvider<TestDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
