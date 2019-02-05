namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCardRemoveRequariedMiddleName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "MiddleName", c => c.String(nullable: false));
        }
    }
}
