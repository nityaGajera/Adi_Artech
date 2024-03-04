namespace TestDemo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class product1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductChild",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Attachment = c.String(),
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
                    { "DynamicFilter_Productchild_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.product", "Attachment", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductChild", new[] { "IsDeleted" });
            DropColumn("dbo.product", "Attachment");
            DropTable("dbo.ProductChild",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Productchild_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
