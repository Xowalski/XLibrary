namespace XLibrary.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    ReservedBookId = c.String(),
                    ReaderId = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}
