namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedonetimepickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyPickUpDate", c => c.String());
            AddColumn("dbo.Customers", "OneTimePickUpDate", c => c.String());
            DropColumn("dbo.Customers", "PickUpDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickUpDate", c => c.String());
            DropColumn("dbo.Customers", "OneTimePickUpDate");
            DropColumn("dbo.Customers", "WeeklyPickUpDate");
        }
    }
}
