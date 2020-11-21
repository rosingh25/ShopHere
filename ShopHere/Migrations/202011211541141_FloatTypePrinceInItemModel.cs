namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloatTypePrinceInItemModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Price", c => c.Int(nullable: false));
        }
    }
}
