namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "RoundId", "dbo.Round");
            DropIndex("dbo.Post", new[] { "RoundId" });
            AlterColumn("dbo.Post", "RoundId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoleData", "Score", c => c.Int());
            CreateIndex("dbo.Post", "RoundId");
            AddForeignKey("dbo.Post", "RoundId", "dbo.Round", "RoundId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "RoundId", "dbo.Round");
            DropIndex("dbo.Post", new[] { "RoundId" });
            AlterColumn("dbo.HoleData", "Score", c => c.Int(nullable: false));
            AlterColumn("dbo.Post", "RoundId", c => c.Int());
            CreateIndex("dbo.Post", "RoundId");
            AddForeignKey("dbo.Post", "RoundId", "dbo.Round", "RoundId");
        }
    }
}
