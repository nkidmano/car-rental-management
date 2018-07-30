namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "BookingId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "BookingId");
            CreateIndex("dbo.Vehicles", "BookingId");
            AddForeignKey("dbo.Customers", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Customers", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Vehicles", new[] { "BookingId" });
            DropIndex("dbo.Customers", new[] { "BookingId" });
            DropColumn("dbo.Vehicles", "BookingId");
            DropColumn("dbo.Customers", "BookingId");
            DropTable("dbo.Bookings");
        }
    }
}
