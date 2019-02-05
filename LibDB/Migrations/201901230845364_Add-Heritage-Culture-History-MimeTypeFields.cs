namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeritageCultureHistoryMimeTypeFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "MimeTypeHeritage", c => c.String());
            AddColumn("dbo.Organizations", "MimeTypeCulture", c => c.String());
            AddColumn("dbo.Organizations", "MimeTypeHistory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "MimeTypeHistory");
            DropColumn("dbo.Organizations", "MimeTypeCulture");
            DropColumn("dbo.Organizations", "MimeTypeHeritage");
        }
    }
}
