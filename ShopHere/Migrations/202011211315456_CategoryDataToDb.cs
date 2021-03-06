namespace ShopHere.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryDataToDb : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[Categories] ON");
            Sql("INSERT INTO[dbo].[Categories]([Id], [CategoryName]) VALUES(1, N'Electronics')");
            Sql("INSERT INTO[dbo].[Categories] ([Id], [CategoryName]) VALUES(2, N'Clothes')");
            Sql("INSERT INTO[dbo].[Categories] ([Id], [CategoryName]) VALUES(3, N'Kids')");
            Sql("INSERT INTO[dbo].[Categories] ([Id], [CategoryName]) VALUES(4, N'HomeAndFurniture')");
            Sql("INSERT INTO[dbo].[Categories] ([Id], [CategoryName]) VALUES(5, N'Sports')");
            Sql("INSERT INTO[dbo].[Categories] ([Id], [CategoryName]) VALUES(6, N'Books')");
            Sql("INSERT INTO[dbo].[Categories] ([Id], [CategoryName]) VALUES(7, N'Other')");
            Sql("SET IDENTITY_INSERT[dbo].[Categories] OFF");

        }

        public override void Down()
        {
        }
    }
}
