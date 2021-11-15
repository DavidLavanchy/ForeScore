namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullTeeTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeeTime", "DateOfTeeTime", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeeTime", "DateOfTeeTime", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
