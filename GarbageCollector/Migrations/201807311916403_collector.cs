namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                        DateExclusionStart = c.DateTime(),
                        DateExclusionEnd = c.DateTime(),
                        CurrentBill = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FirstName);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "PickUpDate");
            DropColumn("dbo.AspNetUsers", "DateExclusionStart");
            DropColumn("dbo.AspNetUsers", "DateExclusionEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DateExclusionEnd", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "DateExclusionStart", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "PickUpDate", c => c.String());
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
