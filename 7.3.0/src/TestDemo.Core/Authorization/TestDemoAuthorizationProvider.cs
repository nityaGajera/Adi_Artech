using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TestDemo.Authorization
{
    public class TestDemoAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
           
            var product = context.CreatePermission(PermissionNames.Pages_Product, L("Product"));
            product.CreateChildPermission(PermissionNames.Pages_Product_Create, L("Create_Product"));
            product.CreateChildPermission(PermissionNames.Pages_Product_Update, L("Update_Product"));
            product.CreateChildPermission(PermissionNames.Pages_Product_Delete, L("Delete_Product"));


            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TestDemoConsts.LocalizationSourceName);
        }
    }
}
