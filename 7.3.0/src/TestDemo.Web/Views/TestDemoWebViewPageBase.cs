using Abp.Web.Mvc.Views;

namespace TestDemo.Web.Views
{
    public abstract class TestDemoWebViewPageBase : TestDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class TestDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TestDemoWebViewPageBase()
        {
            LocalizationSourceName = TestDemoConsts.LocalizationSourceName;
        }
    }
}