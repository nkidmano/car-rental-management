namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.Int(nullable: false));
        }
    }
}
