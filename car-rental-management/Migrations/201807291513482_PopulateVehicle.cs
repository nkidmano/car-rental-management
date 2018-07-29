namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicle : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (5102, 134)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (1149, 64)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (1014, 78)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (5588, 294)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (7598, 100)");
        }

        public override void Down()
        {
        }
    }
}
