namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringlengthInItemDescriptionIncreased : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemDescription", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemDescription", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
