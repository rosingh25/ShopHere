namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotationsInItemModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "ItemDescription", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemDescription", c => c.String());
            AlterColumn("dbo.Items", "ItemName", c => c.String());
        }
    }
}
