namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HoleData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoleData",
                c => new
                    {
                        HoleDataId = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        DrivingDistance = c.Single(nullable: false),
                        Putts = c.Int(nullable: false),
                        Penalty = c.Boolean(nullable: false),
                        FairwayHit = c.Boolean(nullable: false),
                        HoleId = c.Int(nullable: false),
                        Round_RoundId = c.Int(),
                    })
                .PrimaryKey(t => t.HoleDataId)
                .ForeignKey("dbo.Hole", t => t.HoleId, cascadeDelete: true)
                .ForeignKey("dbo.Round", t => t.Round_RoundId)
                .Index(t => t.HoleId)
                .Index(t => t.Round_RoundId);
            
            DropColumn("dbo.Hole", "Score");
            DropColumn("dbo.Hole", "DrivingDistance");
            DropColumn("dbo.Hole", "Putts");
            DropColumn("dbo.Hole", "Penalty");
            DropColumn("dbo.Hole", "FairwayHit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hole", "FairwayHit", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hole", "Penalty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hole", "Putts", c => c.Int(nullable: false));
            AddColumn("dbo.Hole", "DrivingDistance", c => c.Single(nullable: false));
            AddColumn("dbo.Hole", "Score", c => c.Int(nullable: false));
            DropForeignKey("dbo.HoleData", "Round_RoundId", "dbo.Round");
            DropForeignKey("dbo.HoleData", "HoleId", "dbo.Hole");
            DropIndex("dbo.HoleData", new[] { "Round_RoundId" });
            DropIndex("dbo.HoleData", new[] { "HoleId" });
            DropTable("dbo.HoleData");
        }
    }
}
