namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        CareerUserId = c.Int(nullable: false),
                        Round_RoundId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Round", t => t.Round_RoundId)
                .ForeignKey("dbo.UserCareer", t => t.CareerUserId, cascadeDelete: true)
                .Index(t => t.CareerUserId)
                .Index(t => t.Round_RoundId);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Round",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Description = c.String(),
                        Score = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        DateOfRound = c.DateTimeOffset(nullable: false, precision: 7),
                        CareerUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.UserCareer", t => t.CareerUserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.CareerUserId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slope = c.Single(nullable: false),
                        Rating = c.Single(nullable: false),
                        Par = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        StateOfResidence = c.Int(nullable: false),
                        ZipCode = c.String(maxLength: 5),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(maxLength: 200),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Hole",
                c => new
                    {
                        HoleId = c.Int(nullable: false, identity: true),
                        Par = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        DrivingDistance = c.Single(nullable: false),
                        Putts = c.Int(nullable: false),
                        Penalty = c.Boolean(nullable: false),
                        FairwayHit = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoleId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.UserCareer",
                c => new
                    {
                        UserCareerId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Handicap = c.Single(nullable: false),
                        AverageScoreOverPar = c.Int(nullable: false),
                        Aces = c.Int(nullable: false),
                        Eagles = c.Int(nullable: false),
                        Birdies = c.Int(nullable: false),
                        Pars = c.Int(nullable: false),
                        AverageDrivingDistance = c.Single(nullable: false),
                        AveragePutts = c.Int(nullable: false),
                        RoundsPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCareerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TeeTime",
                c => new
                    {
                        TeeTimeId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TeeTimeId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserCareerUserCareer",
                c => new
                    {
                        UserCareer_UserCareerId = c.Int(nullable: false),
                        UserCareer_UserCareerId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserCareer_UserCareerId, t.UserCareer_UserCareerId1 })
                .ForeignKey("dbo.UserCareer", t => t.UserCareer_UserCareerId)
                .ForeignKey("dbo.UserCareer", t => t.UserCareer_UserCareerId1)
                .Index(t => t.UserCareer_UserCareerId)
                .Index(t => t.UserCareer_UserCareerId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TeeTime", "CourseId", "dbo.Course");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "CareerUserId", "dbo.UserCareer");
            DropForeignKey("dbo.Post", "Round_RoundId", "dbo.Round");
            DropForeignKey("dbo.Round", "CareerUserId", "dbo.UserCareer");
            DropForeignKey("dbo.UserCareerUserCareer", "UserCareer_UserCareerId1", "dbo.UserCareer");
            DropForeignKey("dbo.UserCareerUserCareer", "UserCareer_UserCareerId", "dbo.UserCareer");
            DropForeignKey("dbo.Round", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Hole", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.UserCareerUserCareer", new[] { "UserCareer_UserCareerId1" });
            DropIndex("dbo.UserCareerUserCareer", new[] { "UserCareer_UserCareerId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TeeTime", new[] { "CourseId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Hole", new[] { "CourseId" });
            DropIndex("dbo.Round", new[] { "CareerUserId" });
            DropIndex("dbo.Round", new[] { "CourseId" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "Round_RoundId" });
            DropIndex("dbo.Post", new[] { "CareerUserId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropTable("dbo.UserCareerUserCareer");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.TeeTime");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.UserCareer");
            DropTable("dbo.Hole");
            DropTable("dbo.Course");
            DropTable("dbo.Round");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
