namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoleData", "DrivingDistance", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoleData", "DrivingDistance", c => c.Single());
        }
    }
}
