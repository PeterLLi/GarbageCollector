namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "user_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AddPrimaryKey("dbo.Customers", "CustomerId");
            CreateIndex("dbo.Customers", "user_Id");
            AddForeignKey("dbo.Customers", "user_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "user_Id" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Customers", "user_Id");
            DropColumn("dbo.Customers", "userId");
            DropColumn("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.Customers", "FirstName");
        }
    }
}
