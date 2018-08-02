namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedispickeduptocustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyisPickedUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "OneTimeisPickedUp", c => c.Boolean(nullable: false));
            DropColumn("dbo.Employees", "WeeklyisPickedUp");
            DropColumn("dbo.Employees", "OneTimeisPickedUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "OneTimeisPickedUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "WeeklyisPickedUp", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "OneTimeisPickedUp");
            DropColumn("dbo.Customers", "WeeklyisPickedUp");
        }
    }
}
