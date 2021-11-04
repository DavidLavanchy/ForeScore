namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "ContactInformation_Address", c => c.String(maxLength: 100));
            AddColumn("dbo.Course", "ContactInformation_City", c => c.String(maxLength: 100));
            AddColumn("dbo.Course", "ContactInformation_StateOfResidence", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "ContactInformation_ZipCode", c => c.String(maxLength: 5));
            AddColumn("dbo.Course", "ContactInformation_PhoneNumber", c => c.String());
            AddColumn("dbo.Course", "ContactInformation_EmailAddress", c => c.String(maxLength: 200));
            AddColumn("dbo.Course", "ContactInformation_Website", c => c.String());
            DropColumn("dbo.Course", "Address");
            DropColumn("dbo.Course", "City");
            DropColumn("dbo.Course", "StateOfResidence");
            DropColumn("dbo.Course", "ZipCode");
            DropColumn("dbo.Course", "PhoneNumber");
            DropColumn("dbo.Course", "EmailAddress");
            DropColumn("dbo.Course", "Website");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "Website", c => c.String());
            AddColumn("dbo.Course", "EmailAddress", c => c.String(maxLength: 200));
            AddColumn("dbo.Course", "PhoneNumber", c => c.String());
            AddColumn("dbo.Course", "ZipCode", c => c.String(maxLength: 5));
            AddColumn("dbo.Course", "StateOfResidence", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "City", c => c.String(maxLength: 100));
            AddColumn("dbo.Course", "Address", c => c.String(maxLength: 100));
            DropColumn("dbo.Course", "ContactInformation_Website");
            DropColumn("dbo.Course", "ContactInformation_EmailAddress");
            DropColumn("dbo.Course", "ContactInformation_PhoneNumber");
            DropColumn("dbo.Course", "ContactInformation_ZipCode");
            DropColumn("dbo.Course", "ContactInformation_StateOfResidence");
            DropColumn("dbo.Course", "ContactInformation_City");
            DropColumn("dbo.Course", "ContactInformation_Address");
        }
    }
}
