namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidForRound : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Round", "CareerUserId", "dbo.ApplicationUser");
            DropIndex("dbo.Round", new[] { "CareerUserId" });
            RenameColumn(table: "dbo.Round", name: "CareerUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Round", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Round", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Round", "ApplicationUser_Id");
            AddForeignKey("dbo.Round", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Round", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Round", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Round", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Round", "OwnerId");
            RenameColumn(table: "dbo.Round", name: "ApplicationUser_Id", newName: "CareerUserId");
            CreateIndex("dbo.Round", "CareerUserId");
            AddForeignKey("dbo.Round", "CareerUserId", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
