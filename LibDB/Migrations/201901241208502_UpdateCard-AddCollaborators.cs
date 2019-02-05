namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCardAddCollaborators : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "Collaborators", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "Collaborators");
        }
    }
}
