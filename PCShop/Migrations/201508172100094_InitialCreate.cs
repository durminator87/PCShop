namespace PCShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BasketID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Details = c.String(),
                        Category_CategoryID = c.Int(),
                        Basket_BasketID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.Baskets", t => t.Basket_BasketID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Basket_BasketID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        CardID = c.String(),
                        CBasket_BasketID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Baskets", t => t.CBasket_BasketID)
                .Index(t => t.CBasket_BasketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CBasket_BasketID", "dbo.Baskets");
            DropForeignKey("dbo.Products", "Basket_BasketID", "dbo.Baskets");
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.Customers", new[] { "CBasket_BasketID" });
            DropIndex("dbo.Products", new[] { "Basket_BasketID" });
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Baskets");
        }
    }
}
