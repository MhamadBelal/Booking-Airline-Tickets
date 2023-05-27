namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useredit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Payments", name: "UsereId", newName: "UserId");
            RenameIndex(table: "dbo.Payments", name: "IX_UsereId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Payments", name: "IX_UserId", newName: "IX_UsereId");
            RenameColumn(table: "dbo.Payments", name: "UserId", newName: "UsereId");
        }
    }
}
