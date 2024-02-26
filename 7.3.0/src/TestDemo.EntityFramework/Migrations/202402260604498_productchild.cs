namespace TestDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productchild : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DocumentChild", newName: "ProductChild");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductChild", newName: "DocumentChild");
        }
    }
}
