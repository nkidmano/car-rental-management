namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicleModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String());
        }
    }
}
