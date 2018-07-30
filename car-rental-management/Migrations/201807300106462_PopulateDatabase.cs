namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, Gender, Email, PhoneNumber, Address) VALUES (Tan, true, tan@gmail.com, 1111, tphcm)");
            Sql("INSERT INTO Customers (Name, Gender, Email, PhoneNumber, Address) VALUES (Tam, false, tam@gmail.com, 2222, tphcm)");

            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (7CYZ284, tphcm)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (7BTV475, tphcm)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (6YVX443, hanoi)");

            Sql("INSERT INTO Bookings (DateFrom, DateTo) VALUES (2018-01-18, 2018-02-24, 1, 1)");
            Sql("INSERT INTO Bookings (DateFrom, DateTo) VALUES (2018-03-14, 2018-06-01, 1, 2)");
            Sql("INSERT INTO Bookings (DateFrom, DateTo) VALUES (2018-02-04, 2018-09-01, 2, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
