namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkpickedupstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "isPickedUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "isPickedUp");
        }
    }
}
