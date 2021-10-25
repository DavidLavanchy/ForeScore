namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowDataEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id1", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUserApplicationUser", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserApplicationUser", new[] { "ApplicationUser_Id1" });
            CreateTable(
                "dbo.FollowedBy",
                c => new
                    {
                        FollowingId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FollowingId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Following",
                c => new
                    {
                        FollowingId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FollowingId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            AddColumn("dbo.Like", "OwnerId", c => c.String());
            AlterColumn("dbo.Comment", "OwnerId", c => c.String());
            AlterColumn("dbo.Post", "OwnerId", c => c.String());
            DropTable("dbo.ApplicationUserApplicationUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserApplicationUser",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 });
            
            DropForeignKey("dbo.Following", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FollowedBy", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Following", new[] { "Id" });
            DropIndex("dbo.FollowedBy", new[] { "Id" });
            AlterColumn("dbo.Post", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Comment", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Like", "OwnerId");
            DropTable("dbo.Following");
            DropTable("dbo.FollowedBy");
            CreateIndex("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id1");
            CreateIndex("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id1", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
    }
}
