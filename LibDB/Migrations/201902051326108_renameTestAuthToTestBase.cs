namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameTestAuthToTestBase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TestAuths", newName: "TestBases");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TestBases", newName: "TestAuths");
        }
    }
}
