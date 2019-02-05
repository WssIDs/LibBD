namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvirtualpropertyTestCards : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestCards", "AuthId", "dbo.TestAuths");
            DropIndex("dbo.TestCards", new[] { "AuthId" });
            AlterColumn("dbo.TestCards", "AuthId", c => c.Int(nullable: false));
            CreateIndex("dbo.TestCards", "AuthId");
            AddForeignKey("dbo.TestCards", "AuthId", "dbo.TestAuths", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCards", "AuthId", "dbo.TestAuths");
            DropIndex("dbo.TestCards", new[] { "AuthId" });
            AlterColumn("dbo.TestCards", "AuthId", c => c.Int());
            CreateIndex("dbo.TestCards", "AuthId");
            AddForeignKey("dbo.TestCards", "AuthId", "dbo.TestAuths", "Id");
        }
    }
}
