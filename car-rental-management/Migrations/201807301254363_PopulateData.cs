namespace car_rental_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, Gender, Email, PhoneNumber, Address) VALUES (Tan, 1, tan@gmail, 27198327, hcm)");
            Sql("INSERT INTO Customers (Name, Gender, Email, PhoneNumber, Address) VALUES (Tam, 0, tam@gmail, 22321322, hanoi)");

            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (ABCD, 98)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (ABCD, 150)");
            Sql("INSERT INTO Vehicles (RegNumber, CurrentMileage) VALUES (ABCD, 60)");

            Sql("INSERT INTO Bookings (DateForm, DateTo, CustomerId, VehicleId) VALUES (2018-01-19, 2018-02-19, 1, 1)");
            Sql("INSERT INTO Bookings (DateForm, DateTo, CustomerId, VehicleId) VALUES (2018-03-01, 2018-05-01, 1, 2)");
            Sql("INSERT INTO Bookings (DateForm, DateTo, CustomerId, VehicleId) VALUES (2018-05-11, 2018-08-11, 2, 3)");

            Sql("INSERT INTO Invoices (InvoiceDate, Price, BookingId) VALUES (2018-01-19, 899, 1");
            Sql("INSERT INTO Invoices (InvoiceDate, Price, BookingId) VALUES (2018-03-01, 677, 2");
            Sql("INSERT INTO Invoices (InvoiceDate, Price, BookingId) VALUES (2018-05-11, 400, 3");
        }
        
        public override void Down()
        {
        }
    }
}
