namespace TestDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attachment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductChild", "Attachment", c => c.String());
            DropColumn("dbo.product", "Title");
            DropColumn("dbo.ProductChild", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductChild", "FileName", c => c.String());
            AddColumn("dbo.product", "Title", c => c.String());
            DropColumn("dbo.ProductChild", "Attachment");
        }
    }
}
