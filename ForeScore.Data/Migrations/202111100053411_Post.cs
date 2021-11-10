namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "RoundId", "dbo.Round");
            DropIndex("dbo.Post", new[] { "RoundId" });
            DropIndex("dbo.Like", new[] { "PostId" });
            AlterColumn("dbo.Post", "RoundId", c => c.Int());
            AlterColumn("dbo.Course", "Slope", c => c.Single());
            AlterColumn("dbo.Course", "Rating", c => c.Single());
            AlterColumn("dbo.Course", "Par", c => c.Int());
            AlterColumn("dbo.Hole", "Par", c => c.Int());
            AlterColumn("dbo.Hole", "Distance", c => c.Int());
            CreateIndex("dbo.Post", "RoundId");
            AddForeignKey("dbo.Post", "RoundId", "dbo.Round", "RoundId");
            DropTable("dbo.Like");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        OwnerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Post", "RoundId", "dbo.Round");
            DropIndex("dbo.Post", new[] { "RoundId" });
            AlterColumn("dbo.Hole", "Distance", c => c.Int(nullable: false));
            AlterColumn("dbo.Hole", "Par", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "Par", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "Rating", c => c.Single(nullable: false));
            AlterColumn("dbo.Course", "Slope", c => c.Single(nullable: false));
            AlterColumn("dbo.Post", "RoundId", c => c.Int(nullable: false));
            CreateIndex("dbo.Like", "PostId");
            CreateIndex("dbo.Post", "RoundId");
            AddForeignKey("dbo.Post", "RoundId", "dbo.Round", "RoundId", cascadeDelete: true);
            AddForeignKey("dbo.Like", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
        }
    }
}
