namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingmigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "CareerUserId", "dbo.ApplicationUser");
            DropIndex("dbo.Post", new[] { "CareerUserId" });
            RenameColumn(table: "dbo.Post", name: "CareerUserId", newName: "ApplicationUser_Id");
            AlterColumn("dbo.Post", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Post", "ApplicationUser_Id");
            AddForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Post", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Post", name: "ApplicationUser_Id", newName: "CareerUserId");
            CreateIndex("dbo.Post", "CareerUserId");
            AddForeignKey("dbo.Post", "CareerUserId", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
