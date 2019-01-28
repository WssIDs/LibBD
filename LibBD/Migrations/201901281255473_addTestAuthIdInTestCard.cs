namespace LibBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTestAuthIdInTestCard : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TestCards", name: "Auth_Id", newName: "AuthId");
            RenameIndex(table: "dbo.TestCards", name: "IX_Auth_Id", newName: "IX_AuthId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TestCards", name: "IX_AuthId", newName: "IX_Auth_Id");
            RenameColumn(table: "dbo.TestCards", name: "AuthId", newName: "Auth_Id");
        }
    }
}
