namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageTypeAndData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Organizations", "MimeTypeHeritage");
            DropColumn("dbo.Organizations", "ImageHeritage");
            DropColumn("dbo.Organizations", "MimeTypeCulture");
            DropColumn("dbo.Organizations", "ImageCulture");
            DropColumn("dbo.Organizations", "MimeTypeHistory");
            DropColumn("dbo.Organizations", "ImageHistory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "ImageHistory", c => c.Binary());
            AddColumn("dbo.Organizations", "MimeTypeHistory", c => c.String());
            AddColumn("dbo.Organizations", "ImageCulture", c => c.Binary());
            AddColumn("dbo.Organizations", "MimeTypeCulture", c => c.String());
            AddColumn("dbo.Organizations", "ImageHeritage", c => c.Binary());
            AddColumn("dbo.Organizations", "MimeTypeHeritage", c => c.String());
        }
    }
}
