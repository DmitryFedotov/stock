namespace Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodarrupdt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductArrivals", "TrInformation", c => c.String());
            DropColumn("dbo.ProductArrivals", "TransactionInformation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductArrivals", "TransactionInformation", c => c.String());
            DropColumn("dbo.ProductArrivals", "TrInformation");
        }
    }
}
