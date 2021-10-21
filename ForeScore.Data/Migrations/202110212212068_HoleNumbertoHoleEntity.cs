namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HoleNumbertoHoleEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hole", "HoleNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hole", "HoleNumber");
        }
    }
}
