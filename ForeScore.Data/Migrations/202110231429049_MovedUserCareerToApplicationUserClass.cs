namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedUserCareerToApplicationUserClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCareerUserCareer", "UserCareer_UserCareerId", "dbo.UserCareer");
            DropForeignKey("dbo.UserCareerUserCareer", "UserCareer_UserCareerId1", "dbo.UserCareer");
            DropIndex("dbo.Post", new[] { "CareerUserId" });
            DropIndex("dbo.Round", new[] { "CareerUserId" });
            DropIndex("dbo.UserCareerUserCareer", new[] { "UserCareer_UserCareerId" });
            DropIndex("dbo.UserCareerUserCareer", new[] { "UserCareer_UserCareerId1" });
            CreateTable(
                "dbo.ApplicationUserApplicationUser",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            AddColumn("dbo.ApplicationUser", "Handicap", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "AverageScoreToPar", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "Aces", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Eagles", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Birdies", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Pars", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "AverageDrivingDistance", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "AveragePutts", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "RoundsPlayed", c => c.Int(nullable: false));
            AlterColumn("dbo.Post", "CareerUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Round", "CareerUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Post", "CareerUserId");
            CreateIndex("dbo.Round", "CareerUserId");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCareerUserCareer",
                c => new
                    {
                        UserCareer_UserCareerId = c.Int(nullable: false),
                        UserCareer_UserCareerId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserCareer_UserCareerId, t.UserCareer_UserCareerId1 });
            
            CreateTable(
                "dbo.UserCareer",
                c => new
                    {
                        UserCareerId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Handicap = c.Single(nullable: false),
                        AverageScoreToPar = c.Single(nullable: false),
                        Aces = c.Int(nullable: false),
                        Eagles = c.Int(nullable: false),
                        Birdies = c.Int(nullable: false),
                        Pars = c.Int(nullable: false),
                        AverageDrivingDistance = c.Single(nullable: false),
                        AveragePutts = c.Single(nullable: false),
                        RoundsPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCareerId);
            
            DropForeignKey("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id1", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserApplicationUser", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUserApplicationUser", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.ApplicationUserApplicationUser", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Round", new[] { "CareerUserId" });
            DropIndex("dbo.Post", new[] { "CareerUserId" });
            AlterColumn("dbo.Round", "CareerUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Post", "CareerUserId", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUser", "RoundsPlayed");
            DropColumn("dbo.ApplicationUser", "AveragePutts");
            DropColumn("dbo.ApplicationUser", "AverageDrivingDistance");
            DropColumn("dbo.ApplicationUser", "Pars");
            DropColumn("dbo.ApplicationUser", "Birdies");
            DropColumn("dbo.ApplicationUser", "Eagles");
            DropColumn("dbo.ApplicationUser", "Aces");
            DropColumn("dbo.ApplicationUser", "AverageScoreToPar");
            DropColumn("dbo.ApplicationUser", "Handicap");
            DropTable("dbo.ApplicationUserApplicationUser");
            CreateIndex("dbo.UserCareerUserCareer", "UserCareer_UserCareerId1");
            CreateIndex("dbo.UserCareerUserCareer", "UserCareer_UserCareerId");
            CreateIndex("dbo.Round", "CareerUserId");
            CreateIndex("dbo.Post", "CareerUserId");
            AddForeignKey("dbo.UserCareerUserCareer", "UserCareer_UserCareerId1", "dbo.UserCareer", "UserCareerId");
            AddForeignKey("dbo.UserCareerUserCareer", "UserCareer_UserCareerId", "dbo.UserCareer", "UserCareerId");
        }
    }
}
