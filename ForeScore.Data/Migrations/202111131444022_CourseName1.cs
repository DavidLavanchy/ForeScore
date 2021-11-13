namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseName1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeeTime", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeeTime", "CourseName");
        }
    }
}
