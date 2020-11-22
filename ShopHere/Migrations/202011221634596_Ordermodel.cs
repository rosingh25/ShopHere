namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ordermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Address = c.String(),
                        OrderPlacedTime = c.DateTime(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ItemId", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "ItemId" });
            DropTable("dbo.Orders");
        }
    }
}
