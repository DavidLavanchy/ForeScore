namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class HoleDataMigration : DbMigration
    {
        public override void Up()
        {
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
        }

        public override void Down()
        {
            DropForeignKey("dbo.HoleData", "RoundId", "dbo.Round");
            DropIndex("dbo.HoleData", new[] { "RoundId" });
        }
    }
}
