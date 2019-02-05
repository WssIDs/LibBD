namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameAuthToBaseInTestCard : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TestCards", name: "AuthId", newName: "BaseId");
            RenameIndex(table: "dbo.TestCards", name: "IX_AuthId", newName: "IX_BaseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TestCards", name: "IX_BaseId", newName: "IX_AuthId");
            RenameColumn(table: "dbo.TestCards", name: "BaseId", newName: "AuthId");
        }
    }
}
