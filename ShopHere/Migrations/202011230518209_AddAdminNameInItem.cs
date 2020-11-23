namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminNameInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "AdminName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "AdminName");
        }
    }
}
