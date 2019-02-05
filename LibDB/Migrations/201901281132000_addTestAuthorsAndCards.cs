namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTestAuthorsAndCards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestAuths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Auth_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestAuths", t => t.Auth_Id)
                .Index(t => t.Auth_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCards", "Auth_Id", "dbo.TestAuths");
            DropIndex("dbo.TestCards", new[] { "Auth_Id" });
            DropTable("dbo.TestCards");
            DropTable("dbo.TestAuths");
        }
    }
}
