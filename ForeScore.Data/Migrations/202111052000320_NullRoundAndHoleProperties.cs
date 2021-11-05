namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullRoundAndHoleProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Round", "IsPublic", c => c.Boolean());
            AlterColumn("dbo.Round", "IsFeatured", c => c.Boolean());
            AlterColumn("dbo.Round", "DateOfRound", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.HoleData", "DrivingDistance", c => c.Single());
            AlterColumn("dbo.HoleData", "Putts", c => c.Int());
            AlterColumn("dbo.HoleData", "Penalty", c => c.Boolean());
            AlterColumn("dbo.HoleData", "FairwayHit", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoleData", "FairwayHit", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HoleData", "Penalty", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HoleData", "Putts", c => c.Int(nullable: false));
            AlterColumn("dbo.HoleData", "DrivingDistance", c => c.Single(nullable: false));
            AlterColumn("dbo.Round", "DateOfRound", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Round", "IsFeatured", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Round", "IsPublic", c => c.Boolean(nullable: false));
        }
    }
}
