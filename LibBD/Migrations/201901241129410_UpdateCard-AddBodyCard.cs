namespace LibBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCardAddBodyCard : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cards");
            AddColumn("dbo.Cards", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Cards", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Cards", "Body", c => c.String());
            DropColumn("dbo.Cards", "CardTitle");
            DropColumn("dbo.Cards", "CardYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "CardYear", c => c.Int(nullable: false));
            AddColumn("dbo.Cards", "CardTitle", c => c.String(nullable: false));
            DropPrimaryKey("dbo.Cards");
            DropColumn("dbo.Cards", "Body");
            DropColumn("dbo.Cards", "Year");
            DropColumn("dbo.Cards", "Title");
            AddPrimaryKey("dbo.Cards", "CardId");
        }
    }
}
