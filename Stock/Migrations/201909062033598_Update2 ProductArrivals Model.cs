namespace Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2ProductArrivalsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductArrivals", "TrInformation", c => c.String());
            DropColumn("dbo.ProductArrivals", "Information");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductArrivals", "Information", c => c.String());
            DropColumn("dbo.ProductArrivals", "TrInformation");
        }
    }
}
