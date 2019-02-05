namespace LibDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAuthorsToCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardTitle = c.String(nullable: false),
                        CardYear = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CardId);
            
            DropTable("dbo.Authors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        CardTitle = c.String(nullable: false),
                        CardYear = c.Int(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Collaborators = c.String(),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Pages = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            DropTable("dbo.Cards");
        }
    }
}
