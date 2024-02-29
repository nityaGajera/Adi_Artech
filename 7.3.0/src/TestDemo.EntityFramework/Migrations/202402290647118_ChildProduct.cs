namespace TestDemo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ChildProduct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductMaster", new[] { "IsDeleted" });
            DropTable("dbo.ProductMaster",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Productmaster_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductComment = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Productmaster_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProductMaster", "IsDeleted");
        }
    }
}
