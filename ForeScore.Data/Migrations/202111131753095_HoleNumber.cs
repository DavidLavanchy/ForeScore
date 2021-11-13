namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HoleNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoleData", "HolePar", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUser", "Handicap");
            DropColumn("dbo.ApplicationUser", "AverageScoreToPar");
            DropColumn("dbo.ApplicationUser", "Aces");
            DropColumn("dbo.ApplicationUser", "Eagles");
            DropColumn("dbo.ApplicationUser", "Birdies");
            DropColumn("dbo.ApplicationUser", "Pars");
            DropColumn("dbo.ApplicationUser", "AverageDrivingDistance");
            DropColumn("dbo.ApplicationUser", "AveragePutts");
            DropColumn("dbo.ApplicationUser", "RoundsPlayed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "RoundsPlayed", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "AveragePutts", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "AverageDrivingDistance", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "Pars", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Birdies", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Eagles", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Aces", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "AverageScoreToPar", c => c.Single(nullable: false));
            AddColumn("dbo.ApplicationUser", "Handicap", c => c.Single(nullable: false));
            DropColumn("dbo.HoleData", "HolePar");
        }
    }
}
