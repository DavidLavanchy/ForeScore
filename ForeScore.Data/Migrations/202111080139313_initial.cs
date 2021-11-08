namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(),
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
                        Title = c.String(),
                        RoundId = c.Int(nullable: false),
                        Content = c.String(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        OwnerId = c.String(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Round", t => t.RoundId, cascadeDelete: true)
                .Index(t => t.RoundId);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        OwnerId = c.String(),
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
                        IsPublic = c.Boolean(),
                        IsFeatured = c.Boolean(),
                        DateOfRound = c.DateTimeOffset(precision: 7),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RoundId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slope = c.Single(nullable: false),
                        Rating = c.Single(nullable: false),
                        Par = c.Int(nullable: false),
                        OwnerId = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        StateOfResidence = c.Int(nullable: false),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Hole",
                c => new
                    {
                        HoleId = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoleId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.HoleData",
                c => new
                    {
                        HoleDataId = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        DrivingDistance = c.Int(),
                        Putts = c.Int(),
                        Penalty = c.Boolean(),
                        FairwayHit = c.Boolean(),
                        RoundId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoleDataId)
                .ForeignKey("dbo.Round", t => t.RoundId, cascadeDelete: true)
                .Index(t => t.RoundId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Handicap = c.Single(nullable: false),
                        AverageScoreToPar = c.Single(nullable: false),
                        Aces = c.Int(nullable: false),
                        Eagles = c.Int(nullable: false),
                        Birdies = c.Int(nullable: false),
                        Pars = c.Int(nullable: false),
                        AverageDrivingDistance = c.Single(nullable: false),
                        AveragePutts = c.Single(nullable: false),
                        RoundsPlayed = c.Int(nullable: false),
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
                "dbo.FollowedBy",
                c => new
                    {
                        FollowingId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FullName = c.String(),
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
                        FullName = c.String(),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FollowingId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
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
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.TeeTime",
                c => new
                    {
                        TeeTimeId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        DateOfTeeTime = c.DateTimeOffset(nullable: false, precision: 7),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TeeTimeId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "RoundId", "dbo.Round");
            DropForeignKey("dbo.Round", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TeeTime", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TeeTime", "CourseId", "dbo.Course");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Following", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FollowedBy", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.HoleData", "RoundId", "dbo.Round");
            DropForeignKey("dbo.Round", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Hole", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.TeeTime", new[] { "Id" });
            DropIndex("dbo.TeeTime", new[] { "CourseId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Following", new[] { "Id" });
            DropIndex("dbo.FollowedBy", new[] { "Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.HoleData", new[] { "RoundId" });
            DropIndex("dbo.Hole", new[] { "CourseId" });
            DropIndex("dbo.Round", new[] { "Id" });
            DropIndex("dbo.Round", new[] { "CourseId" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "RoundId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.TeeTime");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.Following");
            DropTable("dbo.FollowedBy");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.HoleData");
            DropTable("dbo.Hole");
            DropTable("dbo.Course");
            DropTable("dbo.Round");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
