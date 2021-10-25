namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Like", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Post", "Round_RoundId", "dbo.Round");
            DropForeignKey("dbo.Round", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Comment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Post", new[] { "Round_RoundId" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Like", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Round", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.Post", name: "Round_RoundId", newName: "RoundId");
            RenameColumn(table: "dbo.Round", name: "ApplicationUser_Id", newName: "Id");
            AddColumn("dbo.TeeTime", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Post", "RoundId", c => c.Int(nullable: false));
            AlterColumn("dbo.Round", "Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Post", "RoundId");
            CreateIndex("dbo.Round", "Id");
            CreateIndex("dbo.TeeTime", "Id");
            AddForeignKey("dbo.TeeTime", "Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Post", "RoundId", "dbo.Round", "RoundId", cascadeDelete: true);
            AddForeignKey("dbo.Round", "Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            DropColumn("dbo.Comment", "ApplicationUser_Id");
            DropColumn("dbo.Post", "ApplicationUser_Id");
            DropColumn("dbo.Like", "OwnerId");
            DropColumn("dbo.Like", "ApplicationUser_Id");
            DropColumn("dbo.Round", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Round", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Like", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Like", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Post", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comment", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Round", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Post", "RoundId", "dbo.Round");
            DropForeignKey("dbo.TeeTime", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.TeeTime", new[] { "Id" });
            DropIndex("dbo.Round", new[] { "Id" });
            DropIndex("dbo.Post", new[] { "RoundId" });
            AlterColumn("dbo.Round", "Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Post", "RoundId", c => c.Int());
            DropColumn("dbo.TeeTime", "Id");
            RenameColumn(table: "dbo.Round", name: "Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Post", name: "RoundId", newName: "Round_RoundId");
            CreateIndex("dbo.Round", "ApplicationUser_Id");
            CreateIndex("dbo.Like", "ApplicationUser_Id");
            CreateIndex("dbo.Post", "ApplicationUser_Id");
            CreateIndex("dbo.Post", "Round_RoundId");
            CreateIndex("dbo.Comment", "ApplicationUser_Id");
            AddForeignKey("dbo.Round", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Post", "Round_RoundId", "dbo.Round", "RoundId");
            AddForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Like", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Comment", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
    }
}
