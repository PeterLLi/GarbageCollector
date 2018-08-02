namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filteraddedemployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Filter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Filter");
        }
    }
}
