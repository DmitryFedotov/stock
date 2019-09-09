namespace Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductArrivals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProductName = c.String(),
                        ProductUnit = c.String(),
                        ProductAmount = c.String(),
                        ProductPriceForOne = c.String(),
                        ShipperName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        Amount = c.Int(nullable: false),
                        PriceForOne = c.String(),
                        ShipperId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shippers", t => t.ShipperId)
                .Index(t => t.ShipperId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Information = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Products", new[] { "ShipperId" });
            DropTable("dbo.Shippers");
            DropTable("dbo.Products");
            DropTable("dbo.ProductArrivals");
        }
    }
}
