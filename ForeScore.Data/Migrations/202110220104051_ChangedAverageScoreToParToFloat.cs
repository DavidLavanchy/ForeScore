namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAverageScoreToParToFloat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCareer", "AverageScoreToPar", c => c.Single(nullable: false));
            DropColumn("dbo.UserCareer", "AverageScoreOverPar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCareer", "AverageScoreOverPar", c => c.Int(nullable: false));
            DropColumn("dbo.UserCareer", "AverageScoreToPar");
        }
    }
}
