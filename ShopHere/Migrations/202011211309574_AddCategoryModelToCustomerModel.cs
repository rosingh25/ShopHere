namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryModelToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "CategoryId", c => c.Int(nullable: true));
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropColumn("dbo.Items", "CategoryId");
        }
    }
}
