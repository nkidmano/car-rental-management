namespace car_rental_management.Migrations
{
    using car_rental_management.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<car_rental_management.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(car_rental_management.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(x => x.Id,
                new Customer() { Id = 1, Name = "Tan", Gender = true, Email = "tan@gmail.com", PhoneNumber = 0942646809, Address = "hcm" },
                new Customer() { Id = 2, Name = "Tam", Gender = false, Email = "tam@gmail.com", PhoneNumber = 01677470895, Address = "hanoi" }
                );

            context.Vehicles.AddOrUpdate(x => x.Id,
                new Vehicle() { Id = 1, RegNumber = "ABCD 111", CurrentMileage = 98 },
                new Vehicle() { Id = 2, RegNumber = "EFGX 222", CurrentMileage = 126 },
                new Vehicle() { Id = 3, RegNumber = "HUNV 333", CurrentMileage = 324 }
                );
        }
    }
}
