namespace TestDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product", "Title", c => c.String());
            AddColumn("dbo.product", "Attachment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.product", "Attachment");
            DropColumn("dbo.product", "Title");
        }
    }
}
