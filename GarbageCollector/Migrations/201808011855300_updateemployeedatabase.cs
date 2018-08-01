namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateemployeedatabase : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Employees", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "WeeklyisPickedUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "OneTimeisPickedUp", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Employees", "isPickedUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "isPickedUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "Id" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "OneTimeisPickedUp");
            DropColumn("dbo.Employees", "WeeklyisPickedUp");
            DropColumn("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Employees", "UserId");
        }
    }
}
