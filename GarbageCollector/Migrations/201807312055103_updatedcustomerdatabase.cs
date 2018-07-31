namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcustomerdatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "userId", c => c.Int(nullable: false));
        }
    }
}
