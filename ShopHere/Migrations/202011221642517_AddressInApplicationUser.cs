namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressInApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
