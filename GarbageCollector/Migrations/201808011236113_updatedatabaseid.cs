namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "Id");
            RenameIndex(table: "dbo.Customers", name: "IX_UserId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Customers", name: "Id", newName: "UserId");
        }
    }
}
