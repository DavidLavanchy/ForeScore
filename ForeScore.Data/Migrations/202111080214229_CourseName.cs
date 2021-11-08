namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Round", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Round", "CourseName");
        }
    }
}
