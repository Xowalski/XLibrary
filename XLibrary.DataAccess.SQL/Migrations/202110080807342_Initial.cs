namespace XLibrary.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        PublicationYear = c.Int(nullable: false),
                        Description = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Image = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ReservedBookId = c.String(),
                        ReaderId = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
            DropTable("dbo.Readers");
            DropTable("dbo.Books");
        }
    }
}
