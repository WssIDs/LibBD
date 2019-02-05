namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCardsAddNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestCards", "Header", c => c.String());
            AddColumn("dbo.TestCards", "Body", c => c.String());
            AddColumn("dbo.TestCards", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestCards", "Description");
            DropColumn("dbo.TestCards", "Body");
            DropColumn("dbo.TestCards", "Header");
        }
    }
}
