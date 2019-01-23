namespace LibBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeritageCultureHistoryFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "ImageHeritage", c => c.Binary());
            AddColumn("dbo.Organizations", "ImageCulture", c => c.Binary());
            AddColumn("dbo.Organizations", "ImageHistory", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "ImageHistory");
            DropColumn("dbo.Organizations", "ImageCulture");
            DropColumn("dbo.Organizations", "ImageHeritage");
        }
    }
}
