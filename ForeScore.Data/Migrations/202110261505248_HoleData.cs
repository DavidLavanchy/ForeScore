namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HoleData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoleData", "Round_RoundId", "dbo.Round");
            DropIndex("dbo.HoleData", new[] { "Round_RoundId" });
            RenameColumn(table: "dbo.HoleData", name: "Round_RoundId", newName: "RoundId");
            AlterColumn("dbo.HoleData", "RoundId", c => c.Int(nullable: false));
            CreateIndex("dbo.HoleData", "RoundId");
            AddForeignKey("dbo.HoleData", "RoundId", "dbo.Round", "RoundId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoleData", "RoundId", "dbo.Round");
            DropIndex("dbo.HoleData", new[] { "RoundId" });
            AlterColumn("dbo.HoleData", "RoundId", c => c.Int());
            RenameColumn(table: "dbo.HoleData", name: "RoundId", newName: "Round_RoundId");
            CreateIndex("dbo.HoleData", "Round_RoundId");
            AddForeignKey("dbo.HoleData", "Round_RoundId", "dbo.Round", "RoundId");
        }
    }
}
