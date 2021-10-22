namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedAveragePuttsToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCareer", "AveragePutts", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCareer", "AveragePutts", c => c.Int(nullable: false));
        }
    }
}
