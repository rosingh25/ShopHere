namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItemDescriptionInItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ItemDescription");
        }
    }
}
